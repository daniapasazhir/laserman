using System;
using System.Windows.Forms;

namespace laserman {
    internal class PointDataGridView {
        public DataGridView dataGridView;
        public PointList points;
        public PointDataGridView(DataGridView dataGridView, PointList points) {
            this.points = points;
            this.dataGridView = dataGridView;
            this.dataGridView.DataSource = points.points;
            this.dataGridView.RowHeadersWidth = 25;
            this.dataGridView.DataSource = Program.points.points;
            foreach (DataGridViewColumn column in dataGridView.Columns) {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dataGridView.CellMouseUp += new DataGridViewCellMouseEventHandler(
                (object sender, DataGridViewCellMouseEventArgs e) => CellMouseUp(sender, e)
            );
            dataGridView.UserDeletingRow += new DataGridViewRowCancelEventHandler(
                (object sender, DataGridViewRowCancelEventArgs e) => UserDeletingRow(sender, e)
            );
        }
        public int SelectedIndex {
            get {
                return dataGridView.CurrentRow.Index;
            }
            set {
                if (value >= 0 && value < points.Length) {
                    dataGridView.CurrentCell = dataGridView.Rows[value].Cells[0];
                }
            }
        }
        public void CellMouseUp(object sender, DataGridViewCellMouseEventArgs e) {
            if (e.ColumnIndex != 2) {
                return;
            }
            if (e.Button == MouseButtons.Right) {
                points.InvertPointIntensity(e.RowIndex);
            }
        }
        public void UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e) {
            if (points.points.Rows.Count <= 1) {
                e.Cancel = true;
            }
        }
    }
}
