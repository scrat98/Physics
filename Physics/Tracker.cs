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
                TextVerticalAlignment = VerticalAlignment.Middle,
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
                TextPadding = 8,
                TextHorizontalAlignment = HorizontalAlignment.Right,
                TextVerticalAlignment = VerticalAlignment.Bottom,
            };
        }

        private void TheoryLineInit()
        {
            TheoryLine = new LineAnnotation
            {
                Type = LineAnnotationType.Horizontal,
                TextOrientation = AnnotationTextOrientation.Horizontal,
                Color = OxyColors.Gold,
                TextPadding = 8,
                TextHorizontalAlignment = HorizontalAlignment.Right,
                TextVerticalAlignment = VerticalAlignment.Top
            };
        }

        public void NewX(double _X)
        {
            LineSeries s1 = model.Series[0] as LineSeries;
            LineSeries s2 = model.Series[1] as LineSeries;
            int point;
            if (s1.Points.Count > s2.Points.Count) point = getNearestPoint(_X, s1);
            else point = getNearestPoint(_X, s2);

            model.Annotations.Clear();

            if (point < s1.Points.Count)
            {
                MainLine.X = s1.Points[point].X;
            }
            else
            {
                MainLine.X = _X;
            }
            MainLine.Text = MainLine_name + ' ' + MainLine.X;
            model.Annotations.Add(MainLine);

            if (point < s1.Points.Count)
            {
                TheoryLine.Y = s1.Points[point].Y;
                TheoryLine.Text = "Theory " + AddLine_name + ' ' + TheoryLine.Y;
                model.Annotations.Add(TheoryLine);
            }

            if (point < s2.Points.Count)
            {
                RealLine.Y = s2.Points[point].Y;
                RealLine.Text = "Real " + AddLine_name + ' ' + RealLine.Y;
                model.Annotations.Add(RealLine);
            }

            model.InvalidatePlot(true);
        }

        public int getNearestPoint(double x, LineSeries seria)
        {
            if (x > seria.Points[seria.Points.Count - 1].X) return seria.Points.Count;

            double different = Double.MaxValue;
            int best = 0;

            for (int i = 0; i < seria.Points.Count; i++)
            {
                if (x - seria.Points[i].X < different && seria.Points[i].X <= x)
                {
                    different = x - seria.Points[i].X;
                    best = i;
                }
                else break;
            }

            return best;
        }
    }
}