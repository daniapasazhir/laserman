using System;
using System.Drawing;
using System.Windows.Forms;

namespace laserman {
    internal class LaserControllerGraphics {
        private Panel laserControlPanel;
        private Cursor cursor;
        private Pen redPen = new Pen(Brushes.Red, 1.0f);
        private Pen bluePen = new Pen(Brushes.Blue, 1.0f);
        private Pen lightGrayPen = new Pen(Brushes.LightGray, 1.0f);
        private int centerMarkSize = 10;
        private int motorMarkSize = 10;
        private float zoneRelativeSize = 0.9f;
        private int maxBorderSize = 25;
        private Image background = new Bitmap(10, 10);
        private Bitmap cachedBackground = new Bitmap(10, 10);
        private bool drawing = false;

        public void SetBackgroundImage(Image background) {
            this.background = background;
        }
        public LaserControllerGraphics(Panel laserControlPanel, Cursor cursor, int maxBorderSize) {
            this.cursor = cursor;
            this.laserControlPanel = laserControlPanel;
            this.maxBorderSize = maxBorderSize;
            laserControlPanel.MouseLeave += new System.EventHandler(
                (object sender, EventArgs e) => this.cursor.Hide()
            );
        }
        private int GetZoneSize() {
            var panelSize = Convert.ToDouble(Math.Min(laserControlPanel.Size.Width, laserControlPanel.Size.Height));
            return Convert.ToInt32(Math.Max(panelSize * zoneRelativeSize, panelSize - maxBorderSize * 2));
        }
        private Point GetZonePointI(PointF point) {
            return new Point(
                GetCenter().X + Convert.ToInt32(GetZoneSize() * point.X / 2),
                GetCenter().Y - Convert.ToInt32(GetZoneSize() * point.Y / 2)
            );
        }
        public PointF GetZonePointF(Point point) {
            return new PointF(
                (float)(point.X - GetCenter().X) / GetZoneSize() * 2,
                -(float)(point.Y - GetCenter().Y) / GetZoneSize() * 2
            );
        }
        private Point GetCenter() {
            var size = laserControlPanel.Size;
            return new Point((size.Width - 1) / 2, (size.Height - 1) / 2);
        }
        public void Redraw(
            PointF selectedPointPosition,
            PointF laserPosition,
            Color traceColor,
            bool drawPreview,
            bool vizualizeIntencity,
            bool redrawCache
        ) {
            if (drawing) return;
            drawing = true;
            cursor.SetSize(laserControlPanel.Size);
            if (redrawCache) {
                cachedBackground = new Bitmap(laserControlPanel.Width, laserControlPanel.Height);
                Graphics graphics = Graphics.FromImage(cachedBackground);
                graphics.Clear(Color.White);
                DrawZone(graphics);
                if (drawPreview) {
                    DrawPreview(graphics, traceColor, vizualizeIntencity);
                }
                DrawCenter(graphics);
            }
            Bitmap backroundBitmap = new Bitmap(cachedBackground);
            Graphics backgroundGraphics = Graphics.FromImage(backroundBitmap);
            
            DrawLaserMark(backgroundGraphics, GetZonePointI(selectedPointPosition), motorMarkSize, bluePen);
            DrawLaserMark(backgroundGraphics, GetZonePointI(laserPosition), motorMarkSize, redPen);
            laserControlPanel.BackgroundImage = backroundBitmap;
            drawing = false;
        }
        public void Redraw2(
            bool redrawCache
        ) {
            if (drawing) return;
            drawing = true;
            cursor.SetSize(laserControlPanel.Size);
            if (redrawCache) {
                cachedBackground = new Bitmap(laserControlPanel.Width, laserControlPanel.Height);
                Graphics graphics = Graphics.FromImage(cachedBackground);
                graphics.Clear(Color.White);
                DrawCenter(graphics);
                DrawCalibration(graphics, false);
                DrawCalibration(graphics, true);
            }
            Bitmap backroundBitmap = new Bitmap(cachedBackground);

            laserControlPanel.BackgroundImage = backroundBitmap;
            drawing = false;
        }
        public void HideCursor() {
            cursor.Hide();
        }
        public void UpdateCursor(PointF laserPosition, Point mousePoint, bool xFixed, bool yFixed) {
            var pos = GetLaserPosition(mousePoint);
            cursor.Update(
                GetCursorPosition(laserPosition, mousePoint, xFixed, yFixed),
                (Program.ScalePosition ? Program.deviceProfile.LaserPositionMeters(pos) : pos).ToString()
//                 + "\n" +Program.deviceProfile.MotorPositionCompensated(pos)[0].ToString() + " " + Program.deviceProfile.MotorPositionCompensated(pos)[1].ToString()
//                + "\n" + Program.deviceProfile.LaserPositionMetersFromMotorSteps(Program.deviceProfile.MotorPositionCompensated(pos)).ToString()
//                + "\n" + Program.deviceProfile.MotorAngles(Program.deviceProfile.LaserPositionMeters(pos)).ToString()
//                + "\n" + Program.deviceProfile.ToMotorAngles(Program.deviceProfile.MotorPositionCompensated(pos)).ToString()
                + (Program.DisplayPositioningError ? "\nError: " + Program.deviceProfile.PositioningError(pos).ToString() : "")
             );
        }
        public PointF GetLaserPosition(Point mousePoint) {
            return GetZonePointF(mousePoint);
        }
        private void DrawPreview(Graphics graphics, Color traceColor, bool vizualizeIntencity) {
            var points = Program.points;
            for (int i = 0; i < Program.points.points.Rows.Count - 1; i++) {
                if (points.Intesity(i) == 0) continue;
                var color = Color.FromArgb((int)Math.Sqrt(points.Intesity(i)) * 16, traceColor);
                var pen = vizualizeIntencity ? new Pen(color, ((float)points.Intesity(i)) / 30) : new Pen(traceColor);
                graphics.DrawLine(
                    pen,
                    GetZonePointI(points.PointF(i)),
                    GetZonePointI(points.PointF(i + 1))
                );
            }
            if (Program.points.points.Rows.Count > 0) {
                int i = Program.points.points.Rows.Count - 1;
                if (points.Intesity(i) == 0) return;
                var color = Color.FromArgb((int)Math.Sqrt(points.Intesity(i)) * 16, traceColor);
                var pen = vizualizeIntencity ? new Pen(color, ((float)points.Intesity(i)) / 30) : new Pen(traceColor);
                graphics.DrawLine(
                    pen,
                    GetZonePointI(points.PointF(i)),
                    GetZonePointI(points.PointF(0))
                );
            }
        }
        private void DrawCalibration(Graphics graphics, bool drawReal) {
            var pointCount = Program.deviceProfile.CompensationPointsX.Length * Program.deviceProfile.CompensationPointsX.Length;
            var pen =  new Pen(drawReal ? Color.Red : Color.Gray);
            PointF[] points = new PointF[pointCount];
            int[] pointSequence = new int[] {1, 0, 4, 8, 12, 13, 14, 15, 11, 7, 3, 2, 1, 5, 4, 8, 9, 13, 14, 10, 11, 7, 6, 2, 6, 5, 9, 10, 6};
            for (int i = 0; i < pointCount; i++) {
                var point = DeviceProfile.calibrationValue(i);
                points[i] = drawReal ? Program.deviceProfile.Compensate(point) : point;
            }
            for (int i = 0; i < pointSequence.Length - 1; i++) {
                graphics.DrawLine(
                    pen,
                    GetZonePointI(points[pointSequence[i]]),
                    GetZonePointI(points[pointSequence[i + 1]])
                );
            }
        }
        private Point GetCursorPosition(PointF laserPosition, Point mousePoint, bool xFixed, bool yFixed) {
            return new Point(
                (xFixed) ? GetZonePointI(laserPosition).X : mousePoint.X,
                (yFixed) ? GetZonePointI(laserPosition).Y : mousePoint.Y
            );
        }
        private void DrawCenter(Graphics backgroundGraphics) {
            var size = laserControlPanel.Size;
            backgroundGraphics.DrawEllipse(
                redPen,
                GetCenter().X - centerMarkSize / 2,
                GetCenter().Y - centerMarkSize / 2,
                centerMarkSize,
                centerMarkSize
            );
        }
        private void DrawLaserMark(Graphics graphics, Point position, int radius, Pen pen) {
            graphics.DrawLine(pen,
                position.X - radius,
                position.Y,
                position.X + radius,
                position.Y
            );
            graphics.DrawLine(pen,
                position.X,
                position.Y - radius,
                position.X,
                position.Y + radius
            );
        }
        private void DrawZone(Graphics graphics) {
            var zoneSize = GetZoneSize();
            var zoneRect = new Rectangle(
                GetZonePointI(new PointF(-1, 1)),
                new Size(zoneSize, zoneSize)
            );
            graphics.DrawImage(background, zoneRect);
            graphics.DrawRectangle(lightGrayPen, zoneRect);
        }
    }
}
