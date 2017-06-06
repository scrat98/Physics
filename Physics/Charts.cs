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
    public class Charts
    {
        public MainWindow window { get; set; }

        public ChartData Vx { get; }
        public ChartData Vy { get; }
        public ChartData V { get; }
        public ChartData H { get; }
        public ChartData S { get; }
        public ChartData Ax { get; }
        public ChartData Ay { get; }
        public ChartData A { get; }
        public ChartData Global { get; }

        public int GlobalPoint { get; set; }
        public double GlobalX { get; set; }

        public Charts(MainWindow _window)
        {
            window = _window;

            Vx = new ChartData("Vx(t)", "t, sec", "Velocity, m/s");
            Vy = new ChartData("Vy(t)", "t, sec", "Velocity, m/s");
            V = new ChartData("V(t)", "t, sec", "Velocity, m/s");
            H = new ChartData("H(t)", "t, sec", "Height, m");
            S = new ChartData("S(t)", "t, sec", "Distance, m");
            Ax = new ChartData("Ax(t)", "t, sec", "Accelerate, m/s\xB2");
            Ay = new ChartData("Ay(t)", "t, sec", "Accelerate, m/s\xB2");
            A = new ChartData("A(t)", "t, sec", "Accelerate, m/s\xB2");
            Global = new ChartData("H(S)", "Distance, m", "Height, m", false);
        }

        private void VelocityInit()
        {
            Vx.Init();
            Vx.TheoryUpdate(window.arguments.v0.value * Math.Cos(window.DegreeToRadian(window.arguments.angle.value)), 0);
            Vx.RealUpdate(window.arguments.v0.value * Math.Cos(window.DegreeToRadian(window.arguments.angle.value)), 0);

            Vy.Init();
            Vy.TheoryUpdate(window.arguments.v0.value * Math.Sin(window.DegreeToRadian(window.arguments.angle.value)), 0);
            Vy.RealUpdate(window.arguments.v0.value * Math.Sin(window.DegreeToRadian(window.arguments.angle.value)), 0);

            V.Init();
            V.TheoryUpdate(Math.Sqrt(Math.Pow(Vx.theory, 2) + Math.Pow(Vy.theory, 2)), 0);
            V.RealUpdate(Math.Sqrt(Math.Pow(Vx.real, 2) + Math.Pow(Vy.real, 2)), 0);
        }

        private void HeightInit()
        {
            H.Init();
            H.TheoryUpdate(window.arguments.defaultH.value, 0);
            H.RealUpdate(window.arguments.defaultH.value, 0);
        }

        private void SInit()
        {
            S.Init();
            S.TheoryUpdate(0, 0);
            S.RealUpdate(0, 0);
        }

        private void GlobalInit()
        {
            Global.Init();
            Global.TheoryUpdate(H.theory, S.theory);
            Global.RealUpdate(H.real, S.real);
        }

        private void AccelerationInit()
        {
            Ax.Init();
            Ay.Init();
            A.Init();

            Ax.TheoryUpdate(0, 0);
            Ay.TheoryUpdate(-window.arguments.g.value, 0);
            A.TheoryUpdate(Math.Sqrt(Math.Pow(Ax.theory, 2) + Math.Pow(Ay.theory, 2)), 0);

            Ax.RealUpdate(getFx() / window.arguments.mass.value, 0);
            Ay.RealUpdate(-window.arguments.g.value + getFy() / window.arguments.mass.value, 0);
            A.RealUpdate(Math.Sqrt(Math.Pow(Ax.real, 2) + Math.Pow(Ay.real, 2)), 0);
        }

        private double getFx()
        {
            // Fx calculate 
            return -window.arguments.p.value * window.arguments.k.value * Vx.real * Math.Abs(Vx.real) / 2;
        }

        private double getFy()
        {
            // Fy calculate 
            return -window.arguments.p.value * window.arguments.k.value * Vy.real * Math.Abs(Vy.real) / 2;
        }

        public void Draw()
        {
            window.Log();
            if (!window.arguments.Accepted()) return;

            HeightInit();
            SInit();
            GlobalInit();
            VelocityInit();
            AccelerationInit();

            double TheoryT = 0;
            double TheoryDt = 0;

            double RealT = 0;
            double RealDt = 0;

            while (true)
            {
                // theory update
                if(H.theory >= 0)
                {
                    // Dt calculate TODO
                    TheoryDt = window.delay;

                    TheoryT += TheoryDt;

                    H.TheoryUpdate(H.theory + Vy.theory * TheoryDt + Ay.theory * Math.Pow(TheoryDt, 2) / 2, TheoryT);
                    S.TheoryUpdate(S.theory + Vx.theory * TheoryDt + Ax.theory * Math.Pow(TheoryDt, 2) / 2, TheoryT);
                    Global.TheoryUpdate(H.theory, S.theory);

                    Vx.TheoryUpdate(Vx.theory, TheoryT);
                    Vy.TheoryUpdate(Vy.theory + Ay.theory * TheoryDt, TheoryT);
                    V.TheoryUpdate(Math.Sqrt(Math.Pow(Vx.theory, 2) + Math.Pow(Vy.theory, 2)), TheoryT);

                    Ax.TheoryUpdate(0, TheoryT);
                    Ay.TheoryUpdate(-window.arguments.g.value, TheoryT);
                    A.TheoryUpdate(Math.Sqrt(Math.Pow(Ax.theory, 2) + Math.Pow(Ay.theory, 2)), TheoryT);
                }

                // real update
                if (H.real >= 0)
                {
                    // Dt calculate TODO
                    RealDt = window.delay;

                    RealT += RealDt;

                    H.RealUpdate(H.real + Vy.real * RealDt + Ay.real * Math.Pow(RealDt, 2) / 2, RealT);
                    S.RealUpdate(S.real + Vx.real * RealDt + Ax.real * Math.Pow(RealDt, 2) / 2, RealT);
                    Global.RealUpdate(H.real, S.real);

                    Vx.RealUpdate(Vx.real + Ax.real * RealDt, RealT);
                    Vy.RealUpdate(Vy.real + Ay.real * RealDt, RealT);
                    V.RealUpdate(Math.Sqrt(Math.Pow(Vx.real, 2) + Math.Pow(Vy.real, 2)), RealT);

                    Ax.RealUpdate(getFx() / window.arguments.mass.value, RealT);
                    Ay.RealUpdate(-window.arguments.g.value + getFy() / window.arguments.mass.value, RealT);
                    A.RealUpdate(Math.Sqrt(Math.Pow(Ax.real, 2) + Math.Pow(Ay.real, 2)), RealT);
                }

                // exit if we are falled
                if (H.real <= 0 && H.theory <= 0) break;
            }

            window.PlotsUpdate();
        }
    }
}
