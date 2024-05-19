namespace laserman {
    partial class DeviceProfileForm {
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.screenSizeSetter = new System.Windows.Forms.NumericUpDown();
            this.screenDistanceSetter = new System.Windows.Forms.NumericUpDown();
            this.mirrorDistanceSetter = new System.Windows.Forms.NumericUpDown();
            this.stepsPerRotationSetter = new System.Windows.Forms.NumericUpDown();
            this.backlashSetterX = new System.Windows.Forms.NumericUpDown();
            this.maxSpeedSetter = new System.Windows.Forms.NumericUpDown();
            this.applyButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.backlashSetterY = new System.Windows.Forms.NumericUpDown();
            this.calibrationButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.screenSizeSetter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.screenDistanceSetter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mirrorDistanceSetter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stepsPerRotationSetter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backlashSetterX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxSpeedSetter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backlashSetterY)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Backlash X (steps)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Screen size (m)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Screen distance (m)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Mirror distance (m)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 170);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Steps per rotation";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Max speed (steps/s)";
            // 
            // screenSizeSetter
            // 
            this.screenSizeSetter.DecimalPlaces = 10;
            this.screenSizeSetter.Location = new System.Drawing.Point(121, 12);
            this.screenSizeSetter.Maximum = new decimal(new int[] {
            1661992959,
            1808227885,
            5,
            0});
            this.screenSizeSetter.Name = "screenSizeSetter";
            this.screenSizeSetter.Size = new System.Drawing.Size(120, 20);
            this.screenSizeSetter.TabIndex = 6;
            // 
            // screenDistanceSetter
            // 
            this.screenDistanceSetter.DecimalPlaces = 10;
            this.screenDistanceSetter.Location = new System.Drawing.Point(121, 38);
            this.screenDistanceSetter.Maximum = new decimal(new int[] {
            1661992959,
            1808227885,
            5,
            0});
            this.screenDistanceSetter.Name = "screenDistanceSetter";
            this.screenDistanceSetter.Size = new System.Drawing.Size(120, 20);
            this.screenDistanceSetter.TabIndex = 7;
            // 
            // mirrorDistanceSetter
            // 
            this.mirrorDistanceSetter.DecimalPlaces = 10;
            this.mirrorDistanceSetter.Location = new System.Drawing.Point(121, 64);
            this.mirrorDistanceSetter.Maximum = new decimal(new int[] {
            1661992959,
            1808227885,
            5,
            0});
            this.mirrorDistanceSetter.Name = "mirrorDistanceSetter";
            this.mirrorDistanceSetter.Size = new System.Drawing.Size(120, 20);
            this.mirrorDistanceSetter.TabIndex = 8;
            // 
            // stepsPerRotationSetter
            // 
            this.stepsPerRotationSetter.Location = new System.Drawing.Point(121, 168);
            this.stepsPerRotationSetter.Maximum = new decimal(new int[] {
            1661992959,
            1808227885,
            5,
            0});
            this.stepsPerRotationSetter.Name = "stepsPerRotationSetter";
            this.stepsPerRotationSetter.Size = new System.Drawing.Size(120, 20);
            this.stepsPerRotationSetter.TabIndex = 9;
            // 
            // backlashSetterX
            // 
            this.backlashSetterX.Location = new System.Drawing.Point(121, 116);
            this.backlashSetterX.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.backlashSetterX.Name = "backlashSetterX";
            this.backlashSetterX.Size = new System.Drawing.Size(120, 20);
            this.backlashSetterX.TabIndex = 10;
            // 
            // maxSpeedSetter
            // 
            this.maxSpeedSetter.DecimalPlaces = 10;
            this.maxSpeedSetter.Location = new System.Drawing.Point(121, 90);
            this.maxSpeedSetter.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.maxSpeedSetter.Name = "maxSpeedSetter";
            this.maxSpeedSetter.Size = new System.Drawing.Size(120, 20);
            this.maxSpeedSetter.TabIndex = 11;
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(121, 194);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(120, 23);
            this.applyButton.TabIndex = 12;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 144);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Backlash Y (steps)";
            // 
            // backlashSetterY
            // 
            this.backlashSetterY.Location = new System.Drawing.Point(121, 142);
            this.backlashSetterY.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.backlashSetterY.Name = "backlashSetterY";
            this.backlashSetterY.Size = new System.Drawing.Size(120, 20);
            this.backlashSetterY.TabIndex = 14;
            // 
            // calibrationButton
            // 
            this.calibrationButton.Location = new System.Drawing.Point(12, 195);
            this.calibrationButton.Name = "calibrationButton";
            this.calibrationButton.Size = new System.Drawing.Size(103, 23);
            this.calibrationButton.TabIndex = 15;
            this.calibrationButton.Text = "Calibrate";
            this.calibrationButton.UseVisualStyleBackColor = true;
            this.calibrationButton.Click += new System.EventHandler(this.calibrationButton_Click);
            // 
            // DeviceProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 230);
            this.Controls.Add(this.calibrationButton);
            this.Controls.Add(this.backlashSetterY);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.maxSpeedSetter);
            this.Controls.Add(this.backlashSetterX);
            this.Controls.Add(this.stepsPerRotationSetter);
            this.Controls.Add(this.mirrorDistanceSetter);
            this.Controls.Add(this.screenDistanceSetter);
            this.Controls.Add(this.screenSizeSetter);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "DeviceProfileForm";
            this.Text = "Device profile";
            ((System.ComponentModel.ISupportInitialize)(this.screenSizeSetter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.screenDistanceSetter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mirrorDistanceSetter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stepsPerRotationSetter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backlashSetterX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxSpeedSetter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backlashSetterY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown screenSizeSetter;
        private System.Windows.Forms.NumericUpDown screenDistanceSetter;
        private System.Windows.Forms.NumericUpDown mirrorDistanceSetter;
        private System.Windows.Forms.NumericUpDown stepsPerRotationSetter;
        private System.Windows.Forms.NumericUpDown backlashSetterX;
        private System.Windows.Forms.NumericUpDown maxSpeedSetter;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown backlashSetterY;
        private System.Windows.Forms.Button calibrationButton;
    }
}