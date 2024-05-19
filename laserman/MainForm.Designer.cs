using System;

namespace laserman
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.serialPortSelector = new System.Windows.Forms.ComboBox();
            this.connectionButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.baudRateSetter = new System.Windows.Forms.NumericUpDown();
            this.laserControlPanel = new System.Windows.Forms.Panel();
            this.coordinatesLabel = new System.Windows.Forms.Label();
            this.cursorVerticalLine = new System.Windows.Forms.Panel();
            this.cursorHorizontalLine = new System.Windows.Forms.Panel();
            this.openFileDialogBackground = new System.Windows.Forms.OpenFileDialog();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label5 = new System.Windows.Forms.Label();
            this.intensitySetter = new System.Windows.Forms.NumericUpDown();
            this.modeSelector = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.speedSetter = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openDeviceProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveDeviceProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openPointListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.savePointListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chooseBackgroundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearBackgroundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureDeviceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visualizeIntensityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setVisualizationColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scaleSurfaceCoordinatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveTo00ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetMotorCountersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialogDeviceProfile = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialogDeviceProfile = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogPointList = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialogPointList = new System.Windows.Forms.SaveFileDialog();
            this.traceColorDialog = new System.Windows.Forms.ColorDialog();
            this.displayPositioningErrorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.baudRateSetter)).BeginInit();
            this.laserControlPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.intensitySetter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedSetter)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.ErrorReceived += new System.IO.Ports.SerialErrorReceivedEventHandler(this.serialPort1_ErrorReceived);
            // 
            // serialPortSelector
            // 
            this.serialPortSelector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serialPortSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.serialPortSelector.FormattingEnabled = true;
            this.serialPortSelector.Location = new System.Drawing.Point(62, 3);
            this.serialPortSelector.Name = "serialPortSelector";
            this.serialPortSelector.Size = new System.Drawing.Size(134, 21);
            this.serialPortSelector.TabIndex = 0;
            this.serialPortSelector.DropDown += new System.EventHandler(this.serialPortSelector_DropDown);
            this.serialPortSelector.SelectedIndexChanged += new System.EventHandler(this.serialPortSelector_SelectedIndexChanged);
            // 
            // connectionButton
            // 
            this.connectionButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.connectionButton.Location = new System.Drawing.Point(62, 57);
            this.connectionButton.Name = "connectionButton";
            this.connectionButton.Size = new System.Drawing.Size(135, 23);
            this.connectionButton.TabIndex = 1;
            this.connectionButton.Text = "Connect";
            this.connectionButton.UseVisualStyleBackColor = true;
            this.connectionButton.Click += new System.EventHandler(this.connectionButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Port";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Baud rate";
            // 
            // baudRateSetter
            // 
            this.baudRateSetter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.baudRateSetter.Location = new System.Drawing.Point(62, 30);
            this.baudRateSetter.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.baudRateSetter.Name = "baudRateSetter";
            this.baudRateSetter.Size = new System.Drawing.Size(134, 20);
            this.baudRateSetter.TabIndex = 6;
            this.baudRateSetter.Value = new decimal(new int[] {
            9600,
            0,
            0,
            0});
            this.baudRateSetter.ValueChanged += new System.EventHandler(this.baudRateSetter_ValueChanged);
            // 
            // laserControlPanel
            // 
            this.laserControlPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.laserControlPanel.BackColor = System.Drawing.Color.White;
            this.laserControlPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.laserControlPanel.Controls.Add(this.coordinatesLabel);
            this.laserControlPanel.Controls.Add(this.cursorVerticalLine);
            this.laserControlPanel.Controls.Add(this.cursorHorizontalLine);
            this.laserControlPanel.Location = new System.Drawing.Point(3, 3);
            this.laserControlPanel.Name = "laserControlPanel";
            this.laserControlPanel.Size = new System.Drawing.Size(364, 366);
            this.laserControlPanel.TabIndex = 10;
            this.laserControlPanel.SizeChanged += new System.EventHandler(this.RedrawOnEvent);
            this.laserControlPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.laserControlPanel_MouseDown);
            this.laserControlPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.laserControlPanel_MouseMove);
            // 
            // coordinatesLabel
            // 
            this.coordinatesLabel.AutoSize = true;
            this.coordinatesLabel.BackColor = System.Drawing.Color.White;
            this.coordinatesLabel.ForeColor = System.Drawing.Color.Black;
            this.coordinatesLabel.Location = new System.Drawing.Point(142, 323);
            this.coordinatesLabel.Name = "coordinatesLabel";
            this.coordinatesLabel.Size = new System.Drawing.Size(88, 13);
            this.coordinatesLabel.TabIndex = 2;
            this.coordinatesLabel.Text = "coordinatesLabel";
            // 
            // cursorVerticalLine
            // 
            this.cursorVerticalLine.BackColor = System.Drawing.Color.DimGray;
            this.cursorVerticalLine.Enabled = false;
            this.cursorVerticalLine.Location = new System.Drawing.Point(135, -1);
            this.cursorVerticalLine.Name = "cursorVerticalLine";
            this.cursorVerticalLine.Size = new System.Drawing.Size(1, 595);
            this.cursorVerticalLine.TabIndex = 1;
            // 
            // cursorHorizontalLine
            // 
            this.cursorHorizontalLine.BackColor = System.Drawing.Color.DimGray;
            this.cursorHorizontalLine.Enabled = false;
            this.cursorHorizontalLine.Location = new System.Drawing.Point(0, 319);
            this.cursorHorizontalLine.Name = "cursorHorizontalLine";
            this.cursorHorizontalLine.Size = new System.Drawing.Size(524, 1);
            this.cursorHorizontalLine.TabIndex = 0;
            // 
            // openFileDialogBackground
            // 
            this.openFileDialogBackground.FileName = "openFileDialog1";
            this.openFileDialogBackground.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";
            this.openFileDialogBackground.Title = "Choose background";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 166);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(194, 203);
            this.dataGridView1.TabIndex = 15;
            this.dataGridView1.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseUp);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(12, 27);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.intensitySetter);
            this.splitContainer1.Panel1.Controls.Add(this.modeSelector);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.speedSetter);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            this.splitContainer1.Panel1.Controls.Add(this.serialPortSelector);
            this.splitContainer1.Panel1.Controls.Add(this.connectionButton);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.baudRateSetter);
            this.splitContainer1.Panel1MinSize = 200;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.laserControlPanel);
            this.splitContainer1.Panel2MinSize = 0;
            this.splitContainer1.Size = new System.Drawing.Size(574, 372);
            this.splitContainer1.SplitterDistance = 200;
            this.splitContainer1.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Intensity %";
            // 
            // intensitySetter
            // 
            this.intensitySetter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.intensitySetter.Location = new System.Drawing.Point(62, 140);
            this.intensitySetter.Name = "intensitySetter";
            this.intensitySetter.Size = new System.Drawing.Size(134, 20);
            this.intensitySetter.TabIndex = 22;
            this.intensitySetter.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // modeSelector
            // 
            this.modeSelector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.modeSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.modeSelector.FormattingEnabled = true;
            this.modeSelector.Items.AddRange(new object[] {
            "Stop",
            "Manual",
            "Auto",
            "Repeat"});
            this.modeSelector.Location = new System.Drawing.Point(62, 113);
            this.modeSelector.Name = "modeSelector";
            this.modeSelector.Size = new System.Drawing.Size(134, 21);
            this.modeSelector.TabIndex = 21;
            this.modeSelector.SelectedIndexChanged += new System.EventHandler(this.modeSelector_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Mode";
            // 
            // speedSetter
            // 
            this.speedSetter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.speedSetter.DecimalPlaces = 10;
            this.speedSetter.Location = new System.Drawing.Point(62, 86);
            this.speedSetter.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.speedSetter.Name = "speedSetter";
            this.speedSetter.Size = new System.Drawing.Size(134, 20);
            this.speedSetter.TabIndex = 19;
            this.speedSetter.ValueChanged += new System.EventHandler(this.speedSetter_ValueChanged);
            this.speedSetter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.speedSetter_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Speed";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.actionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(598, 24);
            this.menuStrip1.TabIndex = 19;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openDeviceProfileToolStripMenuItem,
            this.saveDeviceProfileToolStripMenuItem,
            this.openPointListToolStripMenuItem,
            this.savePointListToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openDeviceProfileToolStripMenuItem
            // 
            this.openDeviceProfileToolStripMenuItem.Name = "openDeviceProfileToolStripMenuItem";
            this.openDeviceProfileToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.openDeviceProfileToolStripMenuItem.Text = "Import device profile";
            this.openDeviceProfileToolStripMenuItem.Click += new System.EventHandler(this.importDeviceProfileToolStripMenuItem_Click);
            // 
            // saveDeviceProfileToolStripMenuItem
            // 
            this.saveDeviceProfileToolStripMenuItem.Name = "saveDeviceProfileToolStripMenuItem";
            this.saveDeviceProfileToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.saveDeviceProfileToolStripMenuItem.Text = "Export device profile";
            this.saveDeviceProfileToolStripMenuItem.Click += new System.EventHandler(this.exportDeviceProfileToolStripMenuItem_Click);
            // 
            // openPointListToolStripMenuItem
            // 
            this.openPointListToolStripMenuItem.Name = "openPointListToolStripMenuItem";
            this.openPointListToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.openPointListToolStripMenuItem.Text = "Import point list";
            this.openPointListToolStripMenuItem.Click += new System.EventHandler(this.importPointListToolStripMenuItem_Click);
            // 
            // savePointListToolStripMenuItem
            // 
            this.savePointListToolStripMenuItem.Name = "savePointListToolStripMenuItem";
            this.savePointListToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.savePointListToolStripMenuItem.Text = "Export point list";
            this.savePointListToolStripMenuItem.Click += new System.EventHandler(this.exportPointListToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chooseBackgroundToolStripMenuItem,
            this.clearBackgroundToolStripMenuItem,
            this.configureDeviceToolStripMenuItem,
            this.showPreviewToolStripMenuItem,
            this.visualizeIntensityToolStripMenuItem,
            this.setVisualizationColorToolStripMenuItem,
            this.scaleSurfaceCoordinatesToolStripMenuItem,
            this.displayPositioningErrorToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.viewToolStripMenuItem.Text = "Options";
            // 
            // chooseBackgroundToolStripMenuItem
            // 
            this.chooseBackgroundToolStripMenuItem.Name = "chooseBackgroundToolStripMenuItem";
            this.chooseBackgroundToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.chooseBackgroundToolStripMenuItem.Text = "Choose background";
            this.chooseBackgroundToolStripMenuItem.Click += new System.EventHandler(this.chooseBackgroundToolStripMenuItem_Click);
            // 
            // clearBackgroundToolStripMenuItem
            // 
            this.clearBackgroundToolStripMenuItem.Name = "clearBackgroundToolStripMenuItem";
            this.clearBackgroundToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.clearBackgroundToolStripMenuItem.Text = "Clear background";
            this.clearBackgroundToolStripMenuItem.Click += new System.EventHandler(this.clearBackgroundToolStripMenuItem_Click);
            // 
            // configureDeviceToolStripMenuItem
            // 
            this.configureDeviceToolStripMenuItem.Name = "configureDeviceToolStripMenuItem";
            this.configureDeviceToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.configureDeviceToolStripMenuItem.Text = "Configure device";
            this.configureDeviceToolStripMenuItem.Click += new System.EventHandler(this.configureDeviceToolStripMenuItem_Click);
            // 
            // showPreviewToolStripMenuItem
            // 
            this.showPreviewToolStripMenuItem.Checked = true;
            this.showPreviewToolStripMenuItem.CheckOnClick = true;
            this.showPreviewToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showPreviewToolStripMenuItem.Name = "showPreviewToolStripMenuItem";
            this.showPreviewToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.showPreviewToolStripMenuItem.Text = "Display preview";
            this.showPreviewToolStripMenuItem.CheckedChanged += new System.EventHandler(this.RedrawOnEvent);
            // 
            // visualizeIntensityToolStripMenuItem
            // 
            this.visualizeIntensityToolStripMenuItem.CheckOnClick = true;
            this.visualizeIntensityToolStripMenuItem.Name = "visualizeIntensityToolStripMenuItem";
            this.visualizeIntensityToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.visualizeIntensityToolStripMenuItem.Text = "Visualize Intensity";
            this.visualizeIntensityToolStripMenuItem.CheckedChanged += new System.EventHandler(this.RedrawOnEvent);
            // 
            // setVisualizationColorToolStripMenuItem
            // 
            this.setVisualizationColorToolStripMenuItem.Name = "setVisualizationColorToolStripMenuItem";
            this.setVisualizationColorToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.setVisualizationColorToolStripMenuItem.Text = "Set Visualization Color";
            this.setVisualizationColorToolStripMenuItem.Click += new System.EventHandler(this.setVisualizationColorToolStripMenuItem_Click);
            // 
            // scaleSurfaceCoordinatesToolStripMenuItem
            // 
            this.scaleSurfaceCoordinatesToolStripMenuItem.Checked = true;
            this.scaleSurfaceCoordinatesToolStripMenuItem.CheckOnClick = true;
            this.scaleSurfaceCoordinatesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.scaleSurfaceCoordinatesToolStripMenuItem.Name = "scaleSurfaceCoordinatesToolStripMenuItem";
            this.scaleSurfaceCoordinatesToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.scaleSurfaceCoordinatesToolStripMenuItem.Text = "Scale Surface Coordinates";
            // 
            // actionToolStripMenuItem
            // 
            this.actionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moveTo00ToolStripMenuItem,
            this.debugInfoToolStripMenuItem,
            this.resetMotorCountersToolStripMenuItem});
            this.actionToolStripMenuItem.Name = "actionToolStripMenuItem";
            this.actionToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.actionToolStripMenuItem.Text = "Action";
            // 
            // moveTo00ToolStripMenuItem
            // 
            this.moveTo00ToolStripMenuItem.Name = "moveTo00ToolStripMenuItem";
            this.moveTo00ToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.moveTo00ToolStripMenuItem.Text = "Move to (0, 0)";
            this.moveTo00ToolStripMenuItem.Click += new System.EventHandler(this.moveTo00ToolStripMenuItem_Click);
            // 
            // debugInfoToolStripMenuItem
            // 
            this.debugInfoToolStripMenuItem.Name = "debugInfoToolStripMenuItem";
            this.debugInfoToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.debugInfoToolStripMenuItem.Text = "Debug info";
            this.debugInfoToolStripMenuItem.Click += new System.EventHandler(this.debugInfoToolStripMenuItem_Click);
            // 
            // resetMotorCountersToolStripMenuItem
            // 
            this.resetMotorCountersToolStripMenuItem.Name = "resetMotorCountersToolStripMenuItem";
            this.resetMotorCountersToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.resetMotorCountersToolStripMenuItem.Text = "Reset Motor Counters";
            this.resetMotorCountersToolStripMenuItem.Click += new System.EventHandler(this.resetMotorCountersToolStripMenuItem_Click);
            // 
            // saveFileDialogDeviceProfile
            // 
            this.saveFileDialogDeviceProfile.Filter = "Json files (*.json)|*.json|All files (*.*)|*.*";
            // 
            // openFileDialogDeviceProfile
            // 
            this.openFileDialogDeviceProfile.FileName = "openFileDialog1";
            this.openFileDialogDeviceProfile.Filter = "Json files (*.json)|*.json|All files (*.*)|*.*";
            // 
            // openFileDialogPointList
            // 
            this.openFileDialogPointList.FileName = "openFileDialog1";
            this.openFileDialogPointList.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            // 
            // saveFileDialogPointList
            // 
            this.saveFileDialogPointList.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            // 
            // displayPositioningErrorToolStripMenuItem
            // 
            this.displayPositioningErrorToolStripMenuItem.CheckOnClick = true;
            this.displayPositioningErrorToolStripMenuItem.Name = "displayPositioningErrorToolStripMenuItem";
            this.displayPositioningErrorToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.displayPositioningErrorToolStripMenuItem.Text = "Display Positioning Error";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 411);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(400, 350);
            this.Name = "MainForm";
            this.Text = "laserman";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.RedrawOnEvent);
            ((System.ComponentModel.ISupportInitialize)(this.baudRateSetter)).EndInit();
            this.laserControlPanel.ResumeLayout(false);
            this.laserControlPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.intensitySetter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedSetter)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.ComboBox serialPortSelector;
        private System.Windows.Forms.Button connectionButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown baudRateSetter;
        private System.Windows.Forms.Panel laserControlPanel;
        private System.Windows.Forms.OpenFileDialog openFileDialogBackground;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown speedSetter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox modeSelector;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openDeviceProfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveDeviceProfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openPointListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem savePointListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chooseBackgroundToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearBackgroundToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveTo00ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configureDeviceToolStripMenuItem;
        private System.Windows.Forms.Panel cursorHorizontalLine;
        private System.Windows.Forms.Panel cursorVerticalLine;
        private System.Windows.Forms.Label coordinatesLabel;
        private System.Windows.Forms.ToolStripMenuItem debugInfoToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialogDeviceProfile;
        private System.Windows.Forms.OpenFileDialog openFileDialogDeviceProfile;
        private System.Windows.Forms.OpenFileDialog openFileDialogPointList;
        private System.Windows.Forms.SaveFileDialog saveFileDialogPointList;
        private System.Windows.Forms.ToolStripMenuItem showPreviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visualizeIntensityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setVisualizationColorToolStripMenuItem;
        private System.Windows.Forms.ColorDialog traceColorDialog;
        private System.Windows.Forms.NumericUpDown intensitySetter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripMenuItem resetMotorCountersToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem scaleSurfaceCoordinatesToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem displayPositioningErrorToolStripMenuItem;
    }
}

