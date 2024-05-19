using System;
using System.Windows.Forms;

namespace laserman {
	public partial class DeviceProfileForm : Form {
		public DeviceProfileForm(DeviceProfile deviceProfile) {
			InitializeComponent();
			screenSizeSetter.Value          = (decimal)deviceProfile.ScreenSize;
			screenDistanceSetter.Value      = (decimal)deviceProfile.ScreenDistance;
			mirrorDistanceSetter.Value      = (decimal)deviceProfile.MirrorDistance;
			stepsPerRotationSetter.Value    = deviceProfile.StepsPerRotation;
			backlashSetterX.Value           = deviceProfile.BacklashX;
			backlashSetterY.Value           = deviceProfile.BacklashY;
            maxSpeedSetter.Value            = (decimal)deviceProfile.MaxSpeed;
            Program.mainForm.SetMaxSpeed(maxSpeedSetter.Value);
        }
        private void applyButton_Click(object sender, EventArgs e) {
            Program.deviceProfile.ScreenSize        = (float)screenSizeSetter.Value;
            Program.deviceProfile.ScreenDistance    = (float)screenDistanceSetter.Value;
            Program.deviceProfile.MirrorDistance    = (float)mirrorDistanceSetter.Value;
            Program.deviceProfile.StepsPerRotation  = (uint)stepsPerRotationSetter.Value;
            Program.deviceProfile.BacklashX         = (uint)backlashSetterX.Value;
            Program.deviceProfile.BacklashY         = (uint)backlashSetterY.Value;
            Program.deviceProfile.MaxSpeed          = (float)maxSpeedSetter.Value;
            Program.mainForm.SetMaxSpeed(maxSpeedSetter.Value);
        }

        private void calibrationButton_Click(object sender, EventArgs e) {
            new CalibrationForm().Show();
        }
    }
}
