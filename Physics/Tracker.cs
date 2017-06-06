using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;
using OxyPlot.Annotations;

namespace Physics
{
    public class Tracker
    {
        private PlotModel model;
        private LineAnnotation MainLine;
        private LineAnnotation RealLine;
        private LineAnnotation TheoryLine;

        public int point { get; set; }
        public double X { get; set; }

        string MainLine_name;
        string AddLine_name;

        public Tracker(PlotModel _model, string _MainLine_name, string _AddLine_name)
        {
            model = _model;
            MainLine_name = _MainLine_name;
            AddLine_name = _AddLine_name;
            LineInit();
        }

        private void LineInit()
        {
            MainLineInit();
            TheoryLineInit();
            RealLineInit();
        }

        private void MainLineInit()
        {
            MainLine = new LineAnnotation
            {
                Type = LineAnnotationType.Vertical,
                TextOrientation = AnnotationTextOrientation.Horizontal,
                TextHorizontalAlignment = HorizontalAlignment.Left,
                TextVerticalAlignment = VerticalAlignment.Bottom,
                Color = OxyColors.Blue,
                TextLinePosition = 0,
                TextPadding = 8
            };

            MainLine.MouseDown += (s, e) =>
            {
                if (e.ChangedButton != OxyMouseButton.Left)
                {
                    return;
                }

                MainLine.StrokeThickness *= 5;
                model.InvalidatePlot(true);
                e.Handled = true;
            };

            MainLine.MouseMove += (s, e) =>
            {
                NewX(MainLine.InverseTransform(e.Position).X);
                e.Handled = true;
            };

            MainLine.MouseUp += (s, e) =>
            {
                MainLine.StrokeThickness /= 5;
                model.InvalidatePlot(true);
                e.Handled = true;
            };
        }

        private void RealLineInit()
        {
            RealLine = new LineAnnotation
            {
                Type = LineAnnotationType.Horizontal,
                TextOrientation = AnnotationTextOrientation.Horizontal,
                Color = OxyColors.Brown,
                TextColor = OxyColors.Brown,
                TextLinePosition = 1,
                TextPadding = 8,
                TextHorizontalAlignment = HorizontalAlignment.Right,
                TextVerticalAlignment = VerticalAlignment.Bottom
            };
        }

        private void TheoryLineInit()
        {
            TheoryLine = new LineAnnotation
            {
                Type = LineAnnotationType.Horizontal,
                TextOrientation = AnnotationTextOrientation.Horizontal,
                Color = OxyColors.Red,
                TextColor = OxyColors.Red,
                TextLinePosition = 0,
                TextPadding = 8,
                TextHorizontalAlignment = HorizontalAlignment.Left,
                TextVerticalAlignment = VerticalAlignment.Bottom
            };
        }

        public void NewX(double _X, int _point)
        {
            point = _point;
            LineSeries s1 = model.Series[0] as LineSeries;
            LineSeries s2 = model.Series[1] as LineSeries;
            LineSeries s;
            if (s1.Points.Count > s2.Points.Count) s = s1;
            else s = s2;

            model.Annotations.Clear();
            if (point < s.Points.Count)
            {
                MainLine.X = s.Points[point].X;
            }
            else
            {
                MainLine.X = _X;
            }
            X = MainLine.X;
            MainLine.Text = MainLine_name + ' ' + Math.Round(MainLine.X, 3);
            model.Annotations.Add(MainLine);

            if (point < s1.Points.Count)
            {
                TheoryLine.Y = s1.Points[point].Y;
                TheoryLine.Text = "Theory " + AddLine_name + ' ' + Math.Round(TheoryLine.Y, 3);
                model.Annotations.Add(TheoryLine);
            }

            if (point < s2.Points.Count)
            {
                RealLine.Y = s2.Points[point].Y;
                RealLine.Text = "Real " + AddLine_name + ' ' + Math.Round(RealLine.Y, 3);
                model.Annotations.Add(RealLine);
            }

            model.InvalidatePlot(true);
        }

        public void NewX(double _X)
        {
            LineSeries s1 = model.Series[0] as LineSeries;
            LineSeries s2 = model.Series[1] as LineSeries;

            if (s1.Points.Count > s2.Points.Count) point = getNearestPoint(_X, s1);
            else point = getNearestPoint(_X, s2);

            NewX(_X, point);
        }

        public int getNearestPoint(double x, LineSeries seria)
        {
            if (x > seria.Points[seria.Points.Count - 1].X) return seria.Points.Count;

            double different = Double.MaxValue;
            int point = 0;

            for (int i = 0; i < seria.Points.Count; i++)
            {
                if (Math.Abs(x - seria.Points[i].X) < different)
                {
                    different = Math.Abs(x - seria.Points[i].X);
                    point = i;
                }
                else break;
            }

            return point;
        }
    }
}