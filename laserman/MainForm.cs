using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO.Ports;
using System.Diagnostics;
using System.IO;
using System.Text.Json;

namespace laserman {
    public partial class MainForm : Form {
        enum Mode : int {
            Stop    = 0,
            Manual  = 1,
            Auto    = 2,
            Repeat  = 3,
        }
        private void MessageOnError(Action method) {
            try {
                method();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        private bool XFixed() { return ModifierKeys.HasFlag(Keys.Control); }
        private bool YFixed() { return ModifierKeys.HasFlag(Keys.Shift); }
        private Mode mode {
            get {
                return (Mode)modeSelector.SelectedIndex;
            }
            set {
                modeSelector.SelectedIndex = (int)value;
            }
        }
        
        public byte Intensity(int index) {
            return (byte)Program.points.Intesity(index);
        }
        public byte ScaleIntensity(byte intensity) {
            return (byte)(((double)intensity) / 100 * (double)intensitySetter.Value);
        }
        public PointF SelectedPointPosition() {
            return Program.points.PointF(pointDataGrid.SelectedIndex);
        }
        public void SetMaxSpeed(decimal speed) {
            speedSetter.Maximum = speed;
        }
        private bool IsAuto { get { return mode == Mode.Auto || mode == Mode.Repeat; } }

        //MAIN BEHAVIOR
        private void UpdateMenu() {
            bool isOpen = ioPort.IsOpen;
            if (!isOpen) {
                mode = Mode.Stop;
            }
            connectionButton.Text = isOpen ? "Disconnect" : "Connect";
            modeSelector.Enabled = isOpen;
            baudRateSetter.Enabled = !isOpen;
            serialPortSelector.Enabled = !isOpen;
            moveTo00ToolStripMenuItem.Enabled = isOpen;
            resetMotorCountersToolStripMenuItem.Enabled = isOpen;
        }
        //also set target on value change in queue
        private void SetTarget() {
            if (mode == Mode.Manual) {
                ioPort.Send(Message.ClearBuffer());
                ioPort.Send(Message.AddTarget(
                    Program.deviceProfile.MotorPositionCompensated(SelectedPointPosition()),
                    ScaleIntensity(Intensity(pointDataGrid.SelectedIndex)))
                );
                ioPort.Send(Message.EndTrajectory());
            } else {
                redrawPanel(false);
            }
        }
        private void laserControlPanel_MouseDown(object sender, MouseEventArgs e) {
            var pointIndex = pointDataGrid.SelectedIndex;
            var newPosition = laserControllerGraphics.GetLaserPosition(e.Location);
            if (ModifierKeys.HasFlag(Keys.Alt)) {
                if (e.Button == MouseButtons.Left) {
                    pointDataGrid.SelectedIndex = Program.points.FindClosestPointIndex(newPosition);
                } else if (e.Button == MouseButtons.Right) {
                    var index = Program.points.FindClosestPointIndex(newPosition);
                    Program.points.InsertPointAt(newPosition, Program.points.PointF(index), Intensity(index), pointIndex, !YFixed(), !XFixed());
                    pointDataGrid.SelectedIndex++;
                }
            } else if (e.Button == MouseButtons.Left) {
                Program.points.SetPointAt(newPosition, pointIndex, XFixed(), YFixed());
            } else if (e.Button == MouseButtons.Right) {
                Program.points.InsertPointAt(newPosition, SelectedPointPosition(), Intensity(pointDataGrid.SelectedIndex), pointIndex, XFixed(), YFixed());
                pointDataGrid.SelectedIndex++;
            } else return;
            if (IsAuto) mode = Mode.Manual;
            else SetTarget();
            redrawPanel();
        }
        private void modeSelector_SelectedIndexChanged(object sender, EventArgs e) {
            if (mode == Mode.Stop) {
                ioPort.Send(Message.ClearBuffer());
            } else if (mode == Mode.Manual) {
                SetTarget();
            } else if (IsAuto) {
                ioPort.Send(Message.ClearBuffer());
                pointToSelectIndex = pointDataGrid.SelectedIndex;
                nextPointToSendIndex = pointDataGrid.SelectedIndex;
                for (int i = 0; i < 8; i++) { AddNext(); }
            }
        }
        private void AddNext() {
            if (nextPointToSendIndex >= Program.points.Length && mode == Mode.Repeat) {
                nextPointToSendIndex = 0;
            } else if (nextPointToSendIndex == Program.points.Length && mode == Mode.Auto) {
                ioPort.Send(Message.EndTrajectory());
            }
            if (nextPointToSendIndex < Program.points.Length) {
                ioPort.Send(Message.AddTarget(
                    Program.deviceProfile.MotorPositionCompensated(Program.points.PointF(nextPointToSendIndex)),
                    ScaleIntensity(Intensity(nextPointToSendIndex))
                ));
            }
            nextPointToSendIndex++;
            if (nextPointToSendIndex == Program.points.Length && mode == Mode.Auto) {
                ioPort.Send(Message.EndTrajectory());
            }
        }
        private void onReceive(byte[] message) {
            if (message[5] != (byte)SerialMessageType.TargetReached) {
                return;
            }
            modeSelector.Invoke(new MethodInvoker(delegate {
                laserPosition = SelectedPointPosition();
                if (IsAuto) {
                    if (pointToSelectIndex + 1 >= Program.points.Length) {
                        if (mode == Mode.Repeat) {
                            pointToSelectIndex = 0;
                        }
                    } else {
                        pointToSelectIndex++;
                    }
                    AddNext();
                    pointDataGrid.SelectedIndex = pointToSelectIndex;
                }
            }));
            redrawPanel(false);
        }
        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e) {
            SetTarget();
            redrawPanel(false);
        }

        //CONTROLS
        //serialPortSelector
        private void serialPortSelector_DropDown(object sender, EventArgs e) {
            serialPortSelector.Items.Clear();
            serialPortSelector.Items.AddRange(SerialPort.GetPortNames());
        }
        private void serialPortSelector_SelectedIndexChanged(object sender, EventArgs e) {
            ioPort.PortName = serialPortSelector.SelectedItem.ToString();
        }
        //menu
        private void chooseBackgroundToolStripMenuItem_Click(object sender, EventArgs e) {
            if (openFileDialogBackground.ShowDialog() != DialogResult.OK) return;
            laserControllerGraphics.SetBackgroundImage(new Bitmap(openFileDialogBackground.FileName));
            redrawPanel();
        }
        private void clearBackgroundToolStripMenuItem_Click(object sender, EventArgs e) {
            laserControllerGraphics.SetBackgroundImage(new Bitmap(10, 10));
            redrawPanel();
        }
        private void baudRateSetter_ValueChanged(object sender, EventArgs e) {
            serialPort1.BaudRate = (int)baudRateSetter.Value;
        }
        private void connectionButton_Click(object sender, EventArgs e) {
            if (ioPort.IsOpen) {
                ioPort.Close();
            } else {
                MessageOnError(delegate() {
                    ioPort.Open();
                });
            }
            UpdateMenu();
        }
        private void speedSetter_ValueChanged(object sender, EventArgs e) {
            ioPort.Send(Message.SetSpeed((float)speedSetter.Value)); //add limitation control
            ioPort.Send(Message.SetBacklashX((short)Program.deviceProfile.BacklashX));
            ioPort.Send(Message.SetBacklashY((short)Program.deviceProfile.BacklashY));
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            if (ioPort.IsOpen) {
                ioPort.Close();
            }
        }
        //menu items
        private void importDeviceProfileToolStripMenuItem_Click(object sender, EventArgs e) {
            MessageOnError(delegate() {
                if (openFileDialogDeviceProfile.ShowDialog() == DialogResult.OK)
                    Program.deviceProfile = JsonSerializer.Deserialize<DeviceProfile>(
                        File.ReadAllText(openFileDialogDeviceProfile.FileName)
                    );
            });
        }
        private void exportDeviceProfileToolStripMenuItem_Click(object sender, EventArgs e) {
            MessageOnError(delegate() {
                if (saveFileDialogDeviceProfile.ShowDialog() == DialogResult.OK)
                    File.WriteAllText(
                       saveFileDialogDeviceProfile.FileName,
                       JsonSerializer.Serialize(Program.deviceProfile)
                    );
            });
        }
        private void importPointListToolStripMenuItem_Click(object sender, EventArgs e) {
            MessageOnError(delegate() {
                if (openFileDialogPointList.ShowDialog() == DialogResult.OK) {
                    Program.points.LoadCsv(openFileDialogPointList.FileName);
                    redrawPanel();
                }
            });
        }
        private void exportPointListToolStripMenuItem_Click(object sender, EventArgs e) {
            MessageOnError(delegate() {
                if (saveFileDialogPointList.ShowDialog() == DialogResult.OK)
                    Program.points.SaveCsv(saveFileDialogPointList.FileName);
            });
        }
        private void configureDeviceToolStripMenuItem_Click(object sender, EventArgs e) {
            new DeviceProfileForm(Program.deviceProfile).Show(this);
        }
        private void moveTo00ToolStripMenuItem_Click(object sender, EventArgs e) {
            ioPort.Send(Message.ClearBuffer());
            ioPort.Send(Message.AddTarget(new Int16[] {0, 0}, 0));
            ioPort.Send(Message.EndTrajectory());
        }
        private void debugInfoToolStripMenuItem_Click(object sender, EventArgs e) {
            var debugInfo = new DebugInfo();
            ioPort.OnFrame = new IOPort.OnFrameFunc((byte[] frame, string who) => {
                debugInfo.AddDebugInfo(frame, who);
            });
            debugInfo.Show();
        }
        //GRAPHICS
        public void drawPanelWithCursor(Point mousePoint) {
            if (ModifierKeys.HasFlag(Keys.Alt)) {
                laserControllerGraphics.UpdateCursor(
                    Program.points.PointF(Program.points.FindClosestPointIndex(laserControllerGraphics.GetLaserPosition(mousePoint))),
                    mousePoint,
                    !YFixed(),
                    !XFixed()
                );
            } else {
                laserControllerGraphics.UpdateCursor(SelectedPointPosition(), mousePoint, XFixed(), YFixed());
            }
        }
        public void redrawPanel(bool redrawCache = true) {
            laserControllerGraphics.Redraw(
                SelectedPointPosition(),
                laserPosition,
                traceColorDialog.Color,
                showPreviewToolStripMenuItem.Checked,
                visualizeIntensityToolStripMenuItem.Checked,
                redrawCache
            );
        }
        private void laserControlPanel_MouseMove(object sender, MouseEventArgs e) {
            cursorToPanelLocation = e.Location;
            if (stopWatch.ElapsedMilliseconds > 50) {
                drawPanelWithCursor(cursorToPanelLocation);
                stopWatch.Restart();
            }
        }
        private void RedrawOnEvent(object sender, EventArgs e) {
            redrawPanel();
        }

        //SERIAL
        private void serialPort1_ErrorReceived(object sender, SerialErrorReceivedEventArgs e) {
            UpdateMenu();
            MessageBox.Show(e.ToString());
        }

        private LaserControllerGraphics laserControllerGraphics;
        private Point cursorToPanelLocation = new Point();
        private PointF laserPosition = new PointF(0, 0);
        private PointDataGridView pointDataGrid;
        private IOPort ioPort;
        private int pointToSelectIndex = 0;
        private int nextPointToSendIndex = 0;
        Stopwatch stopWatch = new Stopwatch();
        public MainForm() {
            InitializeComponent();
            ioPort = new IOPort(serialPort1, 6);
            Program.ioPort = ioPort;
            ioPort.OnReceive = (byte[] message) => onReceive(message);
            pointDataGrid = new PointDataGridView(dataGridView1, Program.points);
            laserControllerGraphics = new LaserControllerGraphics(
                laserControlPanel,
                new Cursor(cursorHorizontalLine, cursorVerticalLine, coordinatesLabel),
                25
            );
            modeSelector.SelectedIndex = 0;
            stopWatch.Start();
            UpdateMenu();
        }

        private void speedSetter_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                e.SuppressKeyPress = true;
            }
        }
        private void setVisualizationColorToolStripMenuItem_Click(object sender, EventArgs e) {
            traceColorDialog.ShowDialog();
            redrawPanel();
        }
        private void resetMotorCountersToolStripMenuItem_Click(object sender, EventArgs e) {
            ioPort.Send(Message.ClearBuffer());
            ioPort.Send(Message.ResetMotors());
        }
    }
}
