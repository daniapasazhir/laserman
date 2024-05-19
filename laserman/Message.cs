using System;
using System.Linq;

namespace laserman {
	enum SerialMessageType : byte {
		SetSpeed        = 0,
		SetBacklashX    = 1,
		SetBacklashY    = 2,
		ResetMotors     = 3,
		AddTarget       = 4,
        EndTrajectory   = 5,
		ClearBuffer     = 6,
        Echo            = 7,
		TargetReached   = 8,
		DebugInfo       = 9,
	}
	static internal class Message {
		private static byte[] BuildCommand(SerialMessageType type, byte[] payload) {
			return PadArray(payload, 5).Concat(new byte[] {(byte)type}).ToArray();
		}
		public static byte[] SetSpeed(float speed) {
			return BuildCommand(SerialMessageType.SetSpeed, BitConverter.GetBytes(speed));
		}
		public static byte[] AddTarget(Int16[] target, byte intencity) {
			return BuildCommand(SerialMessageType.AddTarget, GetTargetBytes(target).Concat(new byte[] {intencity}).ToArray());
		}
		public static byte[] SetBacklashX(Int16 offset) {
			return BuildCommand(SerialMessageType.SetBacklashX, BitConverter.GetBytes(offset));
		}
		public static byte[] SetBacklashY(Int16 offset) {
			return BuildCommand(SerialMessageType.SetBacklashY, BitConverter.GetBytes(offset));
		}
		public static byte[] ClearBuffer() {
			return BuildCommand(SerialMessageType.ClearBuffer, new byte[0]);
		}
		public static byte[] Echo() {
			return BuildCommand(SerialMessageType.Echo, new byte[0]);
		}
		public static byte[] ResetMotors() {
			return BuildCommand(SerialMessageType.ResetMotors, new byte[0]);
		}
        public static byte[] EndTrajectory() {
            return BuildCommand(SerialMessageType.EndTrajectory, new byte[0]);
        }
        private static byte[] PadArray(byte[] array, int length) {
			byte[] zeros = new byte[length - array.Length];
			Array.Clear(zeros, 0, length - array.Length);
			return array.Concat(zeros).ToArray();
		}
		private static byte[] GetTargetBytes(Int16[] target) {
			return BitConverter.GetBytes(target[0]).Concat(BitConverter.GetBytes(target[1])).ToArray();
		}
	}
}
