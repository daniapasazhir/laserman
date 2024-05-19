using NullFX.CRC;
using System;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using MessageQueue = System.Collections.Concurrent.ConcurrentQueue<byte[]>;

namespace laserman {
    internal class IOPort {
        public void Send(byte[] message) {
            if (!IsOpen) return;
            messagesToSend.Enqueue(message);
            if (isLastMessageApproved) {
                TrySendNext();
            }
        }
        private void SendAuxiliary() {
            if (!IsOpen) return;
            byte[] frame = MakeFrame(
                new byte[messageSize],
                thisACK,
                thatACK,
                (byte)1
            );
            serialPort.Write(frame, 0, frameSize);
            OnFrame(frame, "this");
        }
        private void TrySend() {
            if (!IsOpen) return;
            pendingFrame[messageSize + 1] = thatACK;
            serialPort.Write(pendingFrame, 0, frameSize);
            OnFrame(pendingFrame, "this");
        }
        private bool TrySendNext() {
            if (messagesToSend.IsEmpty || !isLastMessageApproved) {
                return false;
            }
            byte[] message;
            if (messagesToSend.TryDequeue(out message)) {
                isLastMessageApproved = false;
                thisACK = Next(thisACK);
                pendingFrame = MakeFrame(
                    message,
                    thisACK,
                    thatACK,
                    0
                );
                TrySend();
                timer.Start();
                return true;
            }
            return false;
        }
        private static bool ValidateFrame(byte[] bytes) {
            return Crc8.ComputeChecksum(bytes) == 0;
        }
        private void Receive() {
            if (!IsOpen) return;
            if (serialPort.BytesToRead < frameSize) {
                return;
            }
            var frame = new byte[frameSize];
            serialPort.Read(frame, 0, frameSize);
            OnFrame(frame, "device");
            if (ValidateFrame(frame)) {
                Process(frame);
            } else {
                serialPort.DiscardInBuffer();
            }
        }
        private void Process(byte[] frame) {
            isLastMessageApproved = (frame[messageSize + 1] == thisACK) || isLastMessageApproved;    //POV: receiver - this -> header.that
            bool isIncomingMessageNew = frame[messageSize + 0] != thatACK;  //POV: receiver - that -> header.this
            var isAuxiliary = frame[messageSize + 2];

            if (isLastMessageApproved) {
                timer.Stop();
            }

            if (isIncomingMessageNew && isAuxiliary == 0) {
                thatACK = frame[messageSize + 0];
                var message = new byte[messageSize];
                Array.Copy(frame, 0, message, 0, messageSize);
                Thread thread = new Thread(() => OnReceive(message));
                thread.Start();
            }
            if (!TrySendNext() && isAuxiliary == 0) {
                SendAuxiliary();
            }
        }
        private static byte Next(byte num) {
            return (byte)((num == 255) ? 0 : num + 1);
        }
        private static byte[] AddChecksum(byte[] message) {
            byte[] checksum = new byte[] { Crc8.ComputeChecksum(message) };
            return message.Concat(checksum).ToArray();
        }
        private byte[] MakeFrame(
            byte[] message,
            byte thisMessageID,
            byte thatMessageID,
            byte isAuxiliary
        ) {
            if (message.Length != messageSize) {
                throw new ArgumentException("Wrong message size, got " + message.Length.ToString());
            }
            var messageWithIDs = message.Concat(new byte[] { thisMessageID, thatMessageID, isAuxiliary }).ToArray();
            return AddChecksum(messageWithIDs);
        }
        public IOPort(SerialPort serialPort, int messageSize) {
            this.serialPort = serialPort;
            this.messageSize = messageSize;
            frameSize = messageSize + headerSize;
            serialPort.DataReceived += new SerialDataReceivedEventHandler(
                (object sender, SerialDataReceivedEventArgs e) => Receive()
            );
            timer.Interval = responseTimeoutMs;
            timer.AutoReset = true;
            timer.Elapsed += new ElapsedEventHandler(
                (object sender, ElapsedEventArgs e) => TrySend()
            );
        }

        private SerialPort serialPort;
        private volatile byte thisACK = 0;
        private volatile byte thatACK = 0;
        private volatile bool isLastMessageApproved = true;
        private MessageQueue messagesToSend = new MessageQueue();
        public OnReceiveFunc OnReceive;
        private static int responseTimeoutMs = 300;
        private int messageSize;
        private const int headerSize = 4;
        private byte[] pendingFrame;
        private int frameSize;
        public OnFrameFunc OnFrame = new OnFrameFunc((byte[] frame, string who) => { });
        private System.Timers.Timer timer = new System.Timers.Timer();

        public delegate void OnFrameFunc(byte[] frame, string who);
        public delegate void OnReceiveFunc(byte[] message);

        public void Open() {
            serialPort.Open();
        }
        public void Close() {
            serialPort.Close();
        }
        public string PortName {
            get {
                return serialPort.PortName;
            }
            set {
                serialPort.PortName = value;
            }
        }
        public int BaudRate {
            get {
                return serialPort.BaudRate;
            }
            set {
                serialPort.BaudRate = value;
            }
        }
        public bool IsOpen {
            get {
                return serialPort.IsOpen;
            }
        }
    }
}
