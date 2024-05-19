using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laserman {
    public partial class DebugInfo : Form {
        public DataTable debugInfo;
        public DebugInfo() {
            InitializeComponent();
            this.debugInfo = new DataTable();
            debugInfo.Columns.Add(new DataColumn("ID",          typeof(int)));
            debugInfo.Columns.Add(new DataColumn("Sender",      typeof(string)));
            debugInfo.Columns.Add(new DataColumn("CRC",         typeof(string)));
            debugInfo.Columns.Add(new DataColumn("ThisACK",     typeof(byte)));
            debugInfo.Columns.Add(new DataColumn("ThatACK",     typeof(byte)));
            debugInfo.Columns.Add(new DataColumn("Auxiliary",   typeof(bool)));
            debugInfo.Columns.Add(new DataColumn("Message",     typeof(string)));

            debugInfoGrid.DataSource = debugInfo.Copy();
            foreach (DataGridViewColumn column in debugInfoGrid.Columns) {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            debugInfoGrid.Columns[debugInfoGrid.Columns.Count - 1].AutoSizeMode
                = DataGridViewAutoSizeColumnMode.Fill;
            debugInfoGrid.Columns[debugInfoGrid.Columns.Count - 1].DefaultCellStyle.Font
                = new Font(FontFamily.GenericMonospace, debugInfoGrid.Font.Size);
        }
        public void AddDebugInfo(byte[] frame, string who) {
            var message = new byte[6];
            Array.Copy(frame, 0, message, 0, 6);
            debugInfo.Rows.Add(
                debugInfo.Rows.Count,
                who,
                BitConverter.ToString(new byte[] { frame[6 + 3] }),
                frame[6 + 0],
                frame[6 + 1],
                frame[6 + 2] != 0,
                BitConverter.ToString(message)
            );
        }
        private void echoButton_Click(object sender, EventArgs e) {
            if (Program.ioPort.IsOpen) {
                Program.ioPort.Send(Message.Echo());
            }
        }

        private void clearButton_Click(object sender, EventArgs e) {
            debugInfo.Clear();
            debugInfoGrid.DataSource = debugInfo.Copy();
        }
        private void filter() {
            bool sThis = selectThisCheckbox.Checked;
            bool sDevice = selectDeviceCheckbox.Checked;
            bool sAux = selectAux.Checked;
            bool sNotAux = selectNotAux.Checked;
            (debugInfoGrid.DataSource as DataTable).DefaultView.RowFilter =
                "(" + (sThis ? "Sender = 'this'" : "FALSE") + " OR " +
                (sDevice ? "Sender = 'device'" : "FALSE") + ") AND (" +
                (sAux ? "Auxiliary = 1" : "FALSE") + " OR " +
                (sNotAux ? "Auxiliary = 0" : "FALSE") + ")";
        }
        private void checkStateChanged(object sender, EventArgs e) {
            filter();
        }
        private void updateButton_Click(object sender, EventArgs e) {
            debugInfoGrid.DataSource = debugInfo.Copy();
            filter();
        }
    }
}
