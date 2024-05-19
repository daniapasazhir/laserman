using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace laserman {
    public partial class CalibrationForm : Form {
        private LaserControllerGraphics calibrationGraphics;
        private Point cursorToPanelLocation = new Point();
        Stopwatch stopWatch = new Stopwatch();
        public CalibrationForm() {
            InitializeComponent();
            calibrationGraphics = new LaserControllerGraphics(
                panel1,
                new Cursor(panel2, panel3, label1),
                100
            );
            stopWatch.Start();
        }
        public void redrawPanel(bool redrawCache = true) {
            calibrationGraphics.Redraw2(redrawCache);
        }
        private void RedrawOnEvent(object sender, EventArgs e) {
            redrawPanel();
        }
        public void drawPanelWithCursor(Point mousePoint) {
            calibrationGraphics.UpdateCursor(new PointF(), mousePoint, false, false);
        }
        private void panel1_MouseMove(object sender, MouseEventArgs e) {
            cursorToPanelLocation = e.Location;
            if (stopWatch.ElapsedMilliseconds > 50) {
                drawPanelWithCursor(cursorToPanelLocation);
                stopWatch.Restart();
            }
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e) {
            var point = calibrationGraphics.GetZonePointF(e.Location);
            var index = Program.deviceProfile.FindClosestPointIndex(point);
            Program.deviceProfile.compensationPointsX[index / 4][index % 4] = point.X - DeviceProfile.calibrationValue(index).X;
            Program.deviceProfile.compensationPointsY[index / 4][index % 4] = point.Y - DeviceProfile.calibrationValue(index).Y;
            redrawPanel();
        }
    }
}
