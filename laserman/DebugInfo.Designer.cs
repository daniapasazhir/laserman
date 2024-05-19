namespace laserman {
    partial class DebugInfo {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.debugInfoGrid = new System.Windows.Forms.DataGridView();
            this.echoButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.selectThisCheckbox = new System.Windows.Forms.CheckBox();
            this.selectDeviceCheckbox = new System.Windows.Forms.CheckBox();
            this.selectAux = new System.Windows.Forms.CheckBox();
            this.selectNotAux = new System.Windows.Forms.CheckBox();
            this.updateButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.debugInfoGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // debugInfoGrid
            // 
            this.debugInfoGrid.AllowUserToAddRows = false;
            this.debugInfoGrid.AllowUserToDeleteRows = false;
            this.debugInfoGrid.AllowUserToResizeRows = false;
            this.debugInfoGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.debugInfoGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.debugInfoGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.debugInfoGrid.Location = new System.Drawing.Point(12, 12);
            this.debugInfoGrid.Name = "debugInfoGrid";
            this.debugInfoGrid.ReadOnly = true;
            this.debugInfoGrid.RowHeadersVisible = false;
            this.debugInfoGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.debugInfoGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.debugInfoGrid.Size = new System.Drawing.Size(603, 275);
            this.debugInfoGrid.TabIndex = 0;
            // 
            // echoButton
            // 
            this.echoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.echoButton.Location = new System.Drawing.Point(93, 293);
            this.echoButton.Name = "echoButton";
            this.echoButton.Size = new System.Drawing.Size(75, 23);
            this.echoButton.TabIndex = 1;
            this.echoButton.Text = "Echo";
            this.echoButton.UseVisualStyleBackColor = true;
            this.echoButton.Click += new System.EventHandler(this.echoButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.clearButton.Location = new System.Drawing.Point(174, 293);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 2;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // selectThisCheckbox
            // 
            this.selectThisCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.selectThisCheckbox.AutoSize = true;
            this.selectThisCheckbox.Checked = true;
            this.selectThisCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.selectThisCheckbox.Location = new System.Drawing.Point(255, 297);
            this.selectThisCheckbox.Name = "selectThisCheckbox";
            this.selectThisCheckbox.Size = new System.Drawing.Size(46, 17);
            this.selectThisCheckbox.TabIndex = 3;
            this.selectThisCheckbox.Text = "This";
            this.selectThisCheckbox.UseVisualStyleBackColor = true;
            this.selectThisCheckbox.CheckStateChanged += new System.EventHandler(this.checkStateChanged);
            // 
            // selectDeviceCheckbox
            // 
            this.selectDeviceCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.selectDeviceCheckbox.AutoSize = true;
            this.selectDeviceCheckbox.Checked = true;
            this.selectDeviceCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.selectDeviceCheckbox.Location = new System.Drawing.Point(308, 297);
            this.selectDeviceCheckbox.Name = "selectDeviceCheckbox";
            this.selectDeviceCheckbox.Size = new System.Drawing.Size(60, 17);
            this.selectDeviceCheckbox.TabIndex = 4;
            this.selectDeviceCheckbox.Text = "Device";
            this.selectDeviceCheckbox.UseVisualStyleBackColor = true;
            this.selectDeviceCheckbox.CheckStateChanged += new System.EventHandler(this.checkStateChanged);
            // 
            // selectAux
            // 
            this.selectAux.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.selectAux.AutoSize = true;
            this.selectAux.Checked = true;
            this.selectAux.CheckState = System.Windows.Forms.CheckState.Checked;
            this.selectAux.Location = new System.Drawing.Point(374, 297);
            this.selectAux.Name = "selectAux";
            this.selectAux.Size = new System.Drawing.Size(64, 17);
            this.selectAux.TabIndex = 5;
            this.selectAux.Text = "Auxiliary";
            this.selectAux.UseVisualStyleBackColor = true;
            this.selectAux.CheckedChanged += new System.EventHandler(this.checkStateChanged);
            // 
            // selectNotAux
            // 
            this.selectNotAux.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.selectNotAux.AutoSize = true;
            this.selectNotAux.Checked = true;
            this.selectNotAux.CheckState = System.Windows.Forms.CheckState.Checked;
            this.selectNotAux.Location = new System.Drawing.Point(444, 297);
            this.selectNotAux.Name = "selectNotAux";
            this.selectNotAux.Size = new System.Drawing.Size(83, 17);
            this.selectNotAux.TabIndex = 6;
            this.selectNotAux.Text = "Not auxiliary";
            this.selectNotAux.UseVisualStyleBackColor = true;
            this.selectNotAux.CheckedChanged += new System.EventHandler(this.checkStateChanged);
            // 
            // updateButton
            // 
            this.updateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.updateButton.Location = new System.Drawing.Point(12, 293);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(75, 23);
            this.updateButton.TabIndex = 8;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // DebugInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 328);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.selectNotAux);
            this.Controls.Add(this.selectAux);
            this.Controls.Add(this.selectDeviceCheckbox);
            this.Controls.Add(this.selectThisCheckbox);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.echoButton);
            this.Controls.Add(this.debugInfoGrid);
            this.Name = "DebugInfo";
            this.Text = "Debug Info";
            ((System.ComponentModel.ISupportInitialize)(this.debugInfoGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView debugInfoGrid;
        private System.Windows.Forms.Button echoButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.CheckBox selectThisCheckbox;
        private System.Windows.Forms.CheckBox selectDeviceCheckbox;
        private System.Windows.Forms.CheckBox selectAux;
        private System.Windows.Forms.CheckBox selectNotAux;
        private System.Windows.Forms.Button updateButton;
    }
}