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
    public class ChartData
    {
        public double theory {get; set; }
        public double real { get; set; }
        private LineSeries theoryData, realData;
        private PlotModel model;

        public ChartData(string title, string x_name, string y_name)
        {
            theory = 0;
            theoryData = new LineSeries();
            theoryData.Smooth = true;
            theoryData.Title = "without air";

            real = 0;
            realData = new LineSeries();
            realData.Smooth = true;
            realData.Title = "with air";

            model = new PlotModel();
            model.LegendPlacement = LegendPlacement.Outside;
            model.LegendPosition = LegendPosition.TopCenter;
            model.LegendOrientation = LegendOrientation.Horizontal;
            model.Title = title;
            
            var la = new LineAnnotation { Type = LineAnnotationType.Vertical, X = 4 };
            la.MouseDown += (s, e) =>
            {
                if (e.ChangedButton != OxyMouseButton.Left)
                {
                    return;
                }

                la.StrokeThickness *= 5;
                model.InvalidatePlot(false);
                e.Handled = true;
            };

            // Handle mouse movements (note: this is only called when the mousedown event was handled)
            la.MouseMove += (s, e) =>
            {
                la.X = la.InverseTransform(e.Position).X;
                model.InvalidatePlot(false);
                e.Handled = true;
            };
            la.MouseUp += (s, e) =>
            {
                la.StrokeThickness /= 5;
                model.InvalidatePlot(false);
                e.Handled = true;
            };
            model.Annotations.Add(la);

            model.Axes.Add(new LinearAxis
            {
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot,
                Position = AxisPosition.Bottom,
                Title = x_name
            });
            model.Axes.Add(new LinearAxis
            {
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot,
                Position = AxisPosition.Left,
                Title = y_name
            });
        }

        public void Init()
        {
            theoryData.Points.Clear();
            realData.Points.Clear();
            model.Series.Clear();
        }

        public void TheoryUpdate(double newTheory, double t)
        {
            theory = newTheory;
            theoryData.Points.Add(new DataPoint(t, theory));
        }

        public void RealUpdate(double newReal, double t)
        {
            real = newReal;
            realData.Points.Add(new DataPoint(t, real));
        }

        public PlotModel GetModel()
        {
            model.Series.Clear();
            model.Series.Add(theoryData);
            model.Series.Add(realData);
            return model;
        }
    }
}
