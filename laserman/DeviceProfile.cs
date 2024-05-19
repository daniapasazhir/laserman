using System;
using System.Drawing;

namespace laserman {
	public class DeviceProfile {
		private float       screenSize          = 1.0f;
		private float       screenDistance      = 1.0f;
		private float       mirrorDistance      = 0.1f;
		private UInt32      stepsPerRotation    = 4096;
		private UInt32      backlashX           = 0;
		private UInt32      backlashY           = 0;
		private float       maxSpeed            = 100.0f;
        public float[][]   compensationPointsX = new float[4][] {
            new float[4],
            new float[4],
            new float[4],
            new float[4],
        };
        public float[][]   compensationPointsY = new float[4][] {
            new float[4],
            new float[4],
            new float[4],
            new float[4],
        };
        private static float[] calibrationValues() {
            return new float[4] { -1f, -1f / 3f, 1f / 3f, 1f };
        }
        private static int findIndex(float pos) {
            var calVals = calibrationValues();
            int index = 0;
            for (int i = 0; i < calVals.Length - 1; i++) {
                if (pos > calVals[i]) {
                    index = i;
                } else break;
            }
            return index;
        }
        public static PointF calibrationValue(int index) {
            var calVals = calibrationValues();
            return new PointF(
                calVals[index % calVals.Length],
                calVals[index / calVals.Length]
            );
        }
        public PointF calibrationPoint(int index) {
            var calVals = calibrationValues();
            return new PointF(
                compensationPointsX[index / calVals.Length][index % calVals.Length],
                compensationPointsY[index / calVals.Length][index % calVals.Length]
            );
        }
        private static float interpolate(float pos1, float val1, float pos2, float val2, float pos) {
            return val1 + (val2 - val1) / (pos2 - pos1) * (pos - pos1);
        }
        private static float interpolate2D(float[][] compensationPoints, PointF point) {
            int indexX = findIndex(point.X);
            int indexY = findIndex(point.Y);
            var calVals = calibrationValues();
            return interpolate(
                calVals[indexY],
                interpolate(
                    calVals[indexX],
                    compensationPoints[indexY][indexX],
                    calVals[indexX + 1],
                    compensationPoints[indexY][indexX + 1],
                    point.X
                ),
                calVals[indexY + 1],
                interpolate(
                    calVals[indexX],
                    compensationPoints[indexY + 1][indexX],
                    calVals[indexX + 1],
                    compensationPoints[indexY + 1][indexX + 1],
                    point.X
                ),
                point.Y
            );
        }
        public PointF Compensate(PointF point) {
            return new PointF(
                point.X + interpolate2D(compensationPointsX, point),
                point.Y + interpolate2D(compensationPointsY, point)
            );
        }
        public int FindClosestPointIndex(PointF point) {
            var pointCount = Program.deviceProfile.CompensationPointsX.Length * Program.deviceProfile.CompensationPointsX.Length;
            int minIndex = 0;
            float minDistance = float.MaxValue;
            for (int i = 0; i < pointCount; i++) {
                var calPoint = new PointF(
                    calibrationValue(i).X + calibrationPoint(i).X,
                    calibrationValue(i).Y + calibrationPoint(i).Y
                );
                float distance = Program.Distance(calPoint, point);
                if (distance < minDistance) {
                    minDistance = distance;
                    minIndex = i;
                }
            }
            return minIndex;
        }
        public Int16[] ToMotorSteps(PointF motorAngle) {
            Func<float, Int16> transform = (x) => Convert.ToInt16(x * StepsPerRotation / (Math.PI * 2));
            var origin = MotorAngles(new PointF(0, 0));
            return new Int16[] {
                transform(-motorAngle.X + origin.X),
                transform(motorAngle.Y - origin.Y)
            };
        }
        public PointF ToMotorAngles(Int16[] motorSteps) {
            Func<Int16, float> transform = (x) => (float)(x * (Math.PI * 2) / stepsPerRotation);
            var origin = MotorAngles(new PointF(0, 0));
            return new PointF(
                origin.X - transform(motorSteps[0]),
                origin.Y + transform(motorSteps[1])
            );
        }
        public PointF LaserPositionMetersFromMotorSteps(Int16[] motorSteps) {
            var motorAngle = ToMotorAngles(motorSteps);
            return new PointF(
                (float)((ScreenDistance / Math.Sin(2 * motorAngle.Y) + MirrorDistance) / Math.Tan(2 * motorAngle.X)),
                (float)(ScreenDistance / Math.Tan(2 * motorAngle.Y))
            );
        }
        public double PositioningError(PointF laserPosition) {
            var pos = MotorPositionCompensated(laserPosition);
            var pos2 = new Int16[] { (short)(pos[0] + 1), (short)(pos[1] + 1) };
            return Math.Sqrt(Program.Distance(LaserPositionMetersFromMotorSteps(pos), LaserPositionMetersFromMotorSteps(pos2)));
        }
        public PointF MotorAngles(PointF laserPositionMeters) {
            Func<double, double> transform = (x) => x + ((x < 0) ? Math.PI / 2 : 0);
            double beta = transform(Math.Atan(ScreenDistance / laserPositionMeters.Y) / 2);
            double alpha = transform(Math.Atan((ScreenDistance / Math.Sin(2 * beta) + MirrorDistance) / laserPositionMeters.X) / 2);
            return new PointF((float)alpha, (float)beta);
        }
        public Int16[] MotorPosition(PointF laserPosition) {
            return ToMotorSteps(MotorAngles(LaserPositionMeters(laserPosition)));
        }
        public Int16[] MotorPositionCompensated(PointF laserPosition) {
            return MotorPosition(Compensate(laserPosition));
        }
        public PointF LaserPositionMeters(PointF laserPosition) {
            return new PointF(
                laserPosition.X * ScreenSize / 2,
                laserPosition.Y * ScreenSize / 2
            );
        }

        public float[][]    CompensationPointsX { get { return compensationPointsX; }   set { compensationPointsX = value; } }
		public float[][]    CompensationPointsY { get { return compensationPointsY; }   set { compensationPointsY = value; } }
		public float        ScreenSize          { get { return screenSize; }            set { screenSize        = value; } }
		public float        ScreenDistance      { get { return screenDistance; }        set { screenDistance    = value; } }
		public float        MirrorDistance      { get { return mirrorDistance; }        set { mirrorDistance    = value; } }
		public UInt32       StepsPerRotation    { get { return stepsPerRotation; }      set { stepsPerRotation  = value; } }
		public UInt32       BacklashX           { get { return backlashX; }             set { backlashX         = value; } }
		public UInt32       BacklashY           { get { return backlashY; }             set { backlashY         = value; } }
		public float        MaxSpeed            { get { return maxSpeed; }              set { maxSpeed          = value; } }

		public DeviceProfile() { }
	}
}
