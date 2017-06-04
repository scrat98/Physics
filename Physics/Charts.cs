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

        public Charts(MainWindow _window)
        {
            window = _window;

            Vx = new ChartData("Vx(t)");
            Vy = new ChartData("Vy(t)");
            V = new ChartData("V(t)");
            H = new ChartData("H(t)");
            S = new ChartData("S(t)");
            Ax = new ChartData("Ax(t)");
            Ay = new ChartData("Ay(t)");
            A = new ChartData("A(t)");
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

        private void AccelerationInit()
        {
            Ax.Init();
            Ay.Init();
            A.Init();

            Ax.TheoryUpdate(0, 0);
            Ay.TheoryUpdate(-window.arguments.g.value, 0);
            A.TheoryUpdate(Math.Sqrt(Math.Pow(Ax.theory, 2) + Math.Pow(Ay.theory, 2)), 0);

            double Fx = getFx();
            double Fy = getFy();

            Ax.RealUpdate(Fx / window.arguments.mass.value, 0);
            Ay.RealUpdate(-window.arguments.g.value + Fy / window.arguments.mass.value, 0);
            A.RealUpdate(Math.Sqrt(Math.Pow(Ax.real, 2) + Math.Pow(Ay.real, 2)), 0);
        }

        private double getFx()
        {
            double Fx = 0;
            // Fx calculate 
            if (Vx.real < window.arguments.v1.value) Fx = -Math.Sign(Vx.real) * window.arguments.k1.value;
            if (Vx.real >= window.arguments.v1.value && Vx.real < window.arguments.v2.value) Fx = -window.arguments.k2.value * Vx.real;
            if (Vx.real >= window.arguments.v2.value) Fx = -window.arguments.k3.value * Math.Abs(Vx.real) * Vx.real;

            return Fx;
        }

        private double getFy()
        {
            double Fy = 0;
            // Fy calculate 
            if (Vy.real < window.arguments.v1.value) Fy = -Math.Sign(Vy.real) * window.arguments.k1.value;
            if (Vy.real >= window.arguments.v1.value && Vy.real < window.arguments.v2.value) Fy = -window.arguments.k2.value * Vy.real;
            if (Vy.real >= window.arguments.v2.value) Fy = -window.arguments.k3.value * Math.Abs(Vy.real) * Vy.real;

            return Fy;
        }

        public void Draw()
        {
            window.Log();
            if (!window.arguments.Accepted()) return;

            HeightInit();
            SInit();
            VelocityInit();
            AccelerationInit();

            double TheoryT = 0;
            double TheoryDt = 0;

            double RealT = 0;
            double RealDt = 0;

            while (true)
            {
                // theory update
                if(H.theory > 0)
                {
                    TheoryDt = window.delay;

                    TheoryT += TheoryDt;

                    H.TheoryUpdate(H.theory + Vy.theory * TheoryDt + Ay.theory * Math.Pow(TheoryDt, 2) / 2, TheoryT);
                    S.TheoryUpdate(S.theory + Vx.theory * TheoryDt + Ax.theory * Math.Pow(TheoryDt, 2) / 2, TheoryT);

                    Vx.TheoryUpdate(Vx.theory, TheoryT);
                    Vy.TheoryUpdate(Vy.theory + Ay.theory * TheoryDt, TheoryT);
                    V.TheoryUpdate(Math.Sqrt(Math.Pow(Vx.theory, 2) + Math.Pow(Vy.theory, 2)), TheoryT);

                    Ax.TheoryUpdate(0, TheoryT);
                    Ay.TheoryUpdate(-window.arguments.g.value, TheoryT);
                    A.TheoryUpdate(Math.Sqrt(Math.Pow(Ax.theory, 2) + Math.Pow(Ay.theory, 2)), TheoryT);
                }

                // real update
                if (H.real > 0)
                {
                    RealDt = window.delay;

                    RealT += RealDt;

                    H.RealUpdate(H.real + Vy.real * RealDt + Ay.real * Math.Pow(RealDt, 2) / 2, RealT);
                    S.RealUpdate(S.real + Vx.real * RealDt + Ax.real * Math.Pow(RealDt, 2) / 2, RealT);

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
