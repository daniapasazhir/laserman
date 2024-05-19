using System.Drawing;
using System.Windows.Forms;

namespace laserman {
    internal class Cursor {
        public Panel cursorHorizontalLine;
        public Panel cursorVerticalLine;
        public Label coordinatesLabel;

        public Cursor(
            Panel cursorHorizontalLine,
            Panel cursorVerticalLine,
            Label coordinatesLabel
        ) {
            this.cursorHorizontalLine = cursorHorizontalLine;
            this.cursorVerticalLine = cursorVerticalLine;
            this.coordinatesLabel = coordinatesLabel;
            Hide();
            cursorHorizontalLine.Enabled = false;
            cursorVerticalLine.Enabled = false;
            coordinatesLabel.Enabled = false;
        }
        public void SetSize(Size size) {
            cursorHorizontalLine.Size = new Size(size.Width, 1);
            cursorVerticalLine.Size = new Size(1, size.Height);
        }
        public void Update(Point point, string text) {
            cursorHorizontalLine.Location = new Point(0, point.Y);
            cursorVerticalLine.Location = new Point(point.X, 0);
            coordinatesLabel.Location = new Point(point.X + 10, point.Y + 1);
            coordinatesLabel.Text = text;
            cursorHorizontalLine.Show();
            cursorVerticalLine.Show();
            coordinatesLabel.Show();
        }
        public void Hide() {
            cursorHorizontalLine.Hide();
            cursorVerticalLine.Hide();
            coordinatesLabel.Hide();
        }

    }
}
