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

        public ChartData(string title)
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

            model.Title = title;
            model.Axes.Add(new LinearAxis
            {
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot,
                Position = AxisPosition.Bottom,
            });
            model.Axes.Add(new LinearAxis
            {
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot,
                Position = AxisPosition.Left,
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
