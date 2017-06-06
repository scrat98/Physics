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
        public LineSeries theoryData { get; private set; }
        public LineSeries realData { get; private set; }
        private PlotModel model;
        public Tracker tracker { get; private set; }

        public ChartData(string title, string x_name, string y_name, bool tracked = true)
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

            if(tracked) tracker = new Tracker(model, x_name, y_name);

            model.Axes.Add(new LinearAxis
            {
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot,
                Position = AxisPosition.Bottom,
                Title = x_name,
                AbsoluteMinimum = 0
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

        public void NewX(double new_x)
        {
            tracker.NewX(new_x);
        }

        public void NewX(double new_x, int _point)
        {
            tracker.NewX(new_x, _point);
        }
    }
}
