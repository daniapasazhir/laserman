using System;
using System.Drawing;
using System.Windows.Forms;

namespace laserman {
	internal static class Program {
        static public PointList     points = new PointList();
        static public DeviceProfile deviceProfile = new DeviceProfile();
        static public MainForm      mainForm;
        static public IOPort        ioPort;
        static public bool          ScalePosition { get {
                return mainForm.scaleSurfaceCoordinatesToolStripMenuItem.Checked;
        } }
        static public bool          DisplayPositioningError { get {
                return mainForm.displayPositioningErrorToolStripMenuItem.Checked;
        } }
        static public float Distance(PointF point1, PointF point2) {
            var vec = new PointF(point1.X - point2.X, point1.Y - point2.Y);
            return vec.X * vec.X + vec.Y * vec.Y;
        }

		[STAThread]
		static void Main() {

            Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
            mainForm = new MainForm();
			Application.Run(mainForm);
        }
	}
}
