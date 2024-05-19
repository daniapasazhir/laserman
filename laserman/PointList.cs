using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration.Attributes;

namespace laserman {
	internal class PointList {
		public DataTable points = new DataTable();
        private class PointData {
            [Name("X")]
            public float X { get; set; }
            [Name("Y")]
            public float Y { get; set; }
            [Name("Intensity")]
            public int Intensity { get; set; }
            public PointData(float X, float Y, int Intensity) {
                this.X = X;
                this.Y = Y;
                this.Intensity = Intensity;
            }
        }
		public PointList() {
            points.TableName = "pointList";
			points.Columns.Add(new DataColumn("X", typeof(float)));
			points.Columns.Add(new DataColumn("Y", typeof(float)));
			points.Columns.Add(new DataColumn("I", typeof(int)));
            points.Rows.Add(0.0f, 0.0f, 0);
            points.ColumnChanging += points_ColumnChanging;
        }
        private void points_ColumnChanging(object sender, DataColumnChangeEventArgs e) {
            if (e.Column.ColumnName == "I") {
                e.ProposedValue = Math.Min(Math.Max((int)e.ProposedValue, 0), 255);
            } else {
                if ((float)e.ProposedValue != normalize((float)e.ProposedValue)) {
                    e.ProposedValue = normalize((float)e.ProposedValue);
                }
            }
        }
        static private Func<float, float> normalize = x => Math.Min(Math.Max(x, -1.0f), 1.0f);
        static private PointF NewPoint(PointF newPoint, PointF oldPoint, bool xFixed, bool yFixed) {
            return new PointF(
                (xFixed) ? oldPoint.X : normalize(newPoint.X),
                (yFixed) ? oldPoint.Y : normalize(newPoint.Y)
            );
        }
		public PointF InsertPointAt(
            PointF newPoint,
            PointF oldPoint,
            int oldIntensity,
            int index,
            bool xFixed,
            bool yFixed
        ) {
			var newRow = points.NewRow();
            var point = NewPoint(newPoint, oldPoint, xFixed, yFixed);

            newRow[0] = point.X;
			newRow[1] = point.Y;
			newRow[2] = oldIntensity;
            points.Rows.InsertAt(newRow, index + 1);
			return point;
		}
        public PointF SetPointAt(PointF newPoint, int index, bool xFixed, bool yFixed) {
            var oldRaw = points.Rows[index];
            var point = NewPoint(newPoint, new PointF((float)oldRaw[0], (float)oldRaw[1]), xFixed, yFixed);
            points.Rows[index][0] = point.X;
            points.Rows[index][1] = point.Y;
			return point;
        }
        public PointF PointF(int index) {
            return new PointF(
                (float)points.Rows[index][0],
                (float)points.Rows[index][1]
            );
        }
        public int Intesity(int index) {
            return (int)points.Rows[index][2];
        }
        public void InvertPointIntensity(int rowIndex) {
            int val = (int)points.Rows[rowIndex][2];
            points.Rows[rowIndex][2] = (val == 0) ? 255 : 0;
        }
        public int Length {
            get {
                return points.Rows.Count;
            }
        }
        public int FindClosestPointIndex(PointF point) {
            int minIndex = 0;
            float minDistance = float.MaxValue;
            for (int i = 0; i < points.Rows.Count; i++) {
                float distance = Program.Distance(PointF(i), point);
                if (distance < minDistance) {
                    minDistance = distance;
                    minIndex = i;
                }
            }
            return minIndex;
        }
        public void LoadCsv(string filename) {
            var count = points.Rows.Count;
            var reader = new StreamReader(filename);
            var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);
            var records = csvReader.GetRecords<PointData>();
            foreach (var record in records) {
                var newRow = points.NewRow();
                newRow[0] = record.X;
                newRow[1] = record.Y;
                newRow[2] = record.Intensity;
                points.Rows.Add(newRow);
            }
            var count2 = points.Rows.Count;

            for (int i = 0; i < Math.Min(count, count2 - 1); i++) {
                points.Rows[0].Delete();
            }
        }
        public void SaveCsv(string filename) {
            var writer = new StreamWriter(filename);
            var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);
            var res = new List<PointData>();
            foreach (DataRow row in points.Rows) {
                res.Add(new PointData((float)row[0], (float)row[1], (int)row[2]));
            }
            csvWriter.WriteRecords(res);
            csvWriter.Dispose();
            writer.Dispose();
        }
    }
}
