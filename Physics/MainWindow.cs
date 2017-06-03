using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using System.Windows.Forms;

using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;
using OxyPlot.Annotations;

using MetroFramework;
using MetroFramework.Forms;
using MetroFramework.Controls;
using MetroFramework.Components;

namespace Physics
{
    public partial class MainWindow : MetroForm
    {
        private static readonly double delay = 0.01;

        class Data
        {
            private double theory, real;
            private LineSeries theoryData, realData;
            private PlotModel model;

            public Data(string title)
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
                    //AbsoluteMinimum = 0
                });
                model.Axes.Add(new LinearAxis
                {
                    MajorGridlineStyle = LineStyle.Solid,
                    MinorGridlineStyle = LineStyle.Dot,
                    Position = AxisPosition.Left,
                    //AbsoluteMinimum = 0
                });
            }

            public void Init(double val)
            {
                theoryData.Points.Clear();
                realData.Points.Clear();
                model.Series.Clear();

                theory = real = val;
                theoryData.Points.Add(new DataPoint(0, theory));
                realData.Points.Add(new DataPoint(0, real));
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

            public double getReal()
            {
                return real;
            }

            public double getTheory()
            {
                return theory;
            }
        };

        Data Vx, Vy, V;
        Data H, S;
        Data Ax, Ay, A;

        Arguments arguments;

        public MainWindow()
        {
            InitializeComponent();
            arguments = new Arguments();
            
            Vx = new Data("Vx(t)");
            Vy = new Data("Vy(t)");
            V = new Data("V(t)");
            H = new Data("H(t)");
            S = new Data("S(t)");
            Ax = new Data("Ax(t)");
            Ay = new Data("Ay(t)");
            A = new Data("A(t)");

            InitArgs();
        }

        private void Draw()
        {
            // print log
            Log();

            // check for OK
            if (!arguments.Accepted()) return;

            /*double curT = 0;
            double Fx = 0;
            double Fy = 0;

            Ax.Init(0);
            Ay.Init(0);
            A.Init(0);

            V.Init(v0.value);
            Vx.Init(v0.value * Math.Cos(DegreeToRadian(angle.value)));
            Vy.Init(v0.value * Math.Sin(DegreeToRadian(angle.value)));

            H.Init(defaultH.value);
            S.Init(0);
            
            while (true)
            {
                curT += delay;

                // theory update
                if(H.getTheory() > 0)
                {
                    Ax.TheoryUpdate(0, curT);
                    Ay.TheoryUpdate(-g.value, curT);
                    A.TheoryUpdate(Math.Sqrt(Math.Pow(Ax.getTheory(),2) + Math.Pow(Ay.getTheory(), 2)), curT);

                    Vx.TheoryUpdate(Vx.getTheory() + Ax.getTheory() * delay, curT);
                    Vy.TheoryUpdate(Vy.getTheory() + Ay.getTheory() * delay, curT);
                    V.TheoryUpdate(Math.Sqrt(Math.Pow(Vx.getTheory(), 2) + Math.Pow(Vy.getTheory(), 2)), curT);

                    H.TheoryUpdate(H.getTheory() + Vy.getTheory() * delay + Ay.getTheory() * delay * delay / 2, curT);
                    S.TheoryUpdate(S.getTheory() + Vx.getTheory() * delay + Ax.getTheory() * delay * delay / 2, curT);
                }

                // real update
                if (H.getReal() > 0)
                {
                    // Fx calculate 
                    if (Vx.getReal() < v1.value) Fx = -Math.Sign(Vx.getReal()) * k1.value;
                    if (Vx.getReal() >= v1.value && Vx.getReal() < v2.value) Fx = -k2.value * Vx.getReal();
                    if (Vx.getReal() >= v2.value) Fx = -k3.value * Math.Abs(Vx.getReal()) * Vx.getReal();

                    // Fy calculate 
                    if (Vy.getReal() < v1.value) Fy = -Math.Sign(Vy.getReal()) * k1.value;
                    if (Vy.getReal() >= v1.value && Vy.getReal() < v2.value) Fy = -k2.value * Vy.getReal();
                    if (Vy.getReal() >= v2.value) Fy = -k3.value * Math.Abs(Vy.getReal()) * Vy.getReal();

                    Ax.RealUpdate(Fx / mass.value, curT);
                    Ay.RealUpdate(-g.value + Fy / mass.value, curT);
                    A.RealUpdate(Math.Sqrt(Math.Pow(Ax.getReal(), 2) + Math.Pow(Ay.getReal(), 2)), curT);

                    Vx.RealUpdate(Vx.getReal() + Ax.getReal() * delay, curT);
                    Vy.RealUpdate(Vy.getReal() + Ay.getReal() * delay, curT);
                    V.RealUpdate(Math.Sqrt(Math.Pow(Vx.getReal(), 2) + Math.Pow(Vy.getReal(), 2)), curT);

                    H.RealUpdate(H.getReal() + Vy.getReal() * delay + Ay.getReal() * delay * delay / 2, curT);
                    S.RealUpdate(S.getReal() + Vx.getReal() * delay + Ax.getReal() * delay * delay / 2, curT);
                }

                // exit if we are falled
                if (H.getReal() <= 0 && H.getTheory() <= 0) break;
            }*/

            HeightPlot.Model = H.GetModel();
            HeightPlot.Model.InvalidatePlot(true);

            SPlot.Model = S.GetModel();
            SPlot.Model.InvalidatePlot(true);

            VPlot.Model = V.GetModel();
            VPlot.Model.InvalidatePlot(true);

            VxPlot.Model = Vx.GetModel();
            VxPlot.Model.InvalidatePlot(true);

            VyPlot.Model = Vy.GetModel();
            VyPlot.Model.InvalidatePlot(true);

            APlot.Model = A.GetModel();
            APlot.Model.InvalidatePlot(true);

            AxPlot.Model = Ax.GetModel();
            AxPlot.Model.InvalidatePlot(true);

            AyPlot.Model = Ay.GetModel();
            AyPlot.Model.InvalidatePlot(true);
        }
    }
}
