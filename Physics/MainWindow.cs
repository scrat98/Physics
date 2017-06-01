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

namespace Physics
{
    public partial class MainWindow : Form
    {
        class Argument
        {
            public bool ok;
            public double value;
        };

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
                    AbsoluteMinimum = 0
                });
                model.Axes.Add(new LinearAxis
                {
                    MajorGridlineStyle = LineStyle.Solid,
                    MinorGridlineStyle = LineStyle.Dot,
                    Position = AxisPosition.Left,
                    AbsoluteMinimum = 0
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

        private Argument mass;     // mass of the body
        private Argument defaultH; // start height
        private Argument g;        // g
        private Argument angle;    // [0; 90]

        private Argument v0;
        private Argument v1;      // first Boundary value
        private Argument v2;      // second Boundary value

        private Argument k1;      // first interval value
        private Argument k2;      // second inteval value
        private Argument k3;      // third interval value

        Data Vx, Vy, V;
        Data H, S;
        Data Ax, Ay, A;

        private void Log()
        {
            Console.Clear();
            if(mass.ok)
                Console.WriteLine("mass: " + mass.value);
            else
                Console.WriteLine("mass: ERROR");

            if (defaultH.ok)
                Console.WriteLine("defaultH: " + defaultH.value);
            else
                Console.WriteLine("defaultH: ERROR");

            if (angle.ok)
                Console.WriteLine("angle: " + angle.value);
            else
                Console.WriteLine("angle: ERROR ");

            if (v0.ok)
                Console.WriteLine("v0: " + v0.value);
            else
                Console.WriteLine("v0: ERROR ");

            if (v1.ok)
                Console.WriteLine("v1: " + v1.value);
            else
                Console.WriteLine("v1: ERROR");

            if (v2.ok)
                Console.WriteLine("v2: " + v2.value);
            else
                Console.WriteLine("v2: ERROR" );

            if (k1.ok)
                Console.WriteLine("k1: " + k1.value);
            else
                Console.WriteLine("k1: ERROR");

            if (k2.ok)
                Console.WriteLine("k2: " + k2.value);
            else
                Console.WriteLine("k2: ERROR ");

            if (k3.ok)
                Console.WriteLine("k3: " + k3.value);
            else
                Console.WriteLine("k3: ERROR ");

            if (g.ok)
                Console.WriteLine("g: " + g.value);
            else
                Console.WriteLine("g: ERROR ");
            Console.WriteLine();
        }

        public MainWindow()
        {
            InitializeComponent();
            Vx = new Data("Vx(t)");
            Vy = new Data("Vy(t)");
            V = new Data("V(t)");
            H = new Data("H(t)");
            S = new Data("S(t)");
            Ax = new Data("Ax(t)");
            Ay = new Data("Ay(t)");
            A = new Data("A(t)");

            mass = new Argument();
            defaultH = new Argument();
            g = new Argument();
            angle = new Argument();

            v0 = new Argument();
            v1 = new Argument();
            v2 = new Argument();

            k1 = new Argument();
            k2 = new Argument();
            k3 = new Argument();

            InitArgs();
        }

        private void InitArgs()
        {
            MassInput.Text = "50";
            gInput.Text = "9,77";
            AngInput.Text = "50";
            HeightInput.Text = "50";
            VelInput.Text = "50";
            VelK1Input.Text = "50";
            VelK2Input.Text = "150";
            K1Input.Text = "0,05";
            K2Input.Text = "0,34";
            K3Input.Text = "0,47";
        }

        private double DegreeToRadian(double angle)
        {
            return Math.PI * angle / 180.0;
        }

        private void Draw()
        {
            Log();

            // check for OK
            // TODO

            double curT = 0;
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

                    H.TheoryUpdate(H.getTheory() + Vy.getTheory() * delay + Ay.getTheory() * curT * curT / 2, curT);
                    S.TheoryUpdate(S.getTheory() + Vx.getTheory() * delay + Ax.getTheory() * curT * curT / 2, curT);
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

                    H.RealUpdate(H.getReal() + Vy.getReal() * delay + Ay.getReal() * curT * curT / 2, curT);
                    S.RealUpdate(S.getReal() + Vx.getReal() * delay + Ax.getReal() * curT * curT / 2, curT);
                }

                // exit if we are falled
                if (H.getReal() <= 0 && H.getTheory() <= 0) break;
            }

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

           


        }

        private void errorInput(TextBox input, Argument arg)
        {
            input.BackColor = Color.Red;
            arg.ok = false;
        }

        private void okInput(TextBox input, Argument arg)
        {
            input.BackColor = Color.White;
            arg.ok = true;
        }

        private void MassInput_TextChanged(object sender, EventArgs e)
        {
            if (!Double.TryParse(MassInput.Text, out mass.value))
            {
                errorInput(MassInput, mass);
                return;
            }

            if (mass.value > 0) okInput( MassInput, mass);
            else errorInput(MassInput, mass);

            Draw();
        }

        private void HeightInput_TextChanged(object sender, EventArgs e)
        {
            if (!Double.TryParse(HeightInput.Text, out defaultH.value))
            {
                errorInput( HeightInput,  defaultH);
                return;
            }
            if (defaultH.value >= 0) okInput( HeightInput,  defaultH);
            else errorInput( HeightInput,  defaultH);
            Draw();
        }

        private void VelInput_TextChanged(object sender, EventArgs e)
        {
            if (!Double.TryParse(VelInput.Text, out v0.value))
            {
                errorInput( VelInput,  v0);
                return;
            }
            if (v0.value > 0) okInput( VelInput,  v0);
            else errorInput( VelInput,  v0);
            Draw();
        }

        private void AngInput_TextChanged(object sender, EventArgs e)
        {
            if (!Double.TryParse(AngInput.Text, out angle.value))
            {
                errorInput( AngInput,  v0);
                return;
            }
            if (angle.value >= 0 && angle.value <= 90) okInput( AngInput,  angle);
            else errorInput( AngInput,  v0);
            Draw();
        }

        private void VelK2Input_TextChanged(object sender, EventArgs e)
        {
            if (!Double.TryParse(VelK2Input.Text, out v2.value))
            {
                errorInput( VelK2Input,  v2);
                return;
            }
            if (v2.value >= v1.value)
            {
                okInput( VelK2Input,  v2);
                okInput( VelK1Input,  v1);
            }
            else
            {
                errorInput( VelK1Input,  v1);
                errorInput( VelK2Input,  v2);
            }

            Draw();
        }

        private void VelK1Input_TextChanged(object sender, EventArgs e)
        {
            if (!Double.TryParse(VelK1Input.Text, out v1.value))
            {
                errorInput( VelK1Input ,  v1);
                return;
            }

            if (v1.value < 0)
            {
                errorInput( VelK1Input,  v1);
                return;
            }

            if (v2.value >= v1.value)
            {
                okInput( VelK2Input,  v2);
                okInput( VelK1Input,  v1);
            }
            else
            {
                errorInput( VelK1Input,  v1);
                errorInput( VelK2Input,  v2);
            }

            Draw();
        }

        private void K1Input_TextChanged(object sender, EventArgs e)
        {
            if (!Double.TryParse(K1Input.Text, out k1.value))
            {
                errorInput( K1Input,  k1);
                return;
            }
            if (k1.value >=0) okInput( K1Input,  k1);
            else errorInput( K1Input,  k1);

            Draw();
        }

        private void K2Input_TextChanged(object sender, EventArgs e)
        {
            if (!Double.TryParse(K2Input.Text, out k2.value))
            {
                errorInput( K2Input,  k2);
                return;
            }
            if (k2.value > 0) okInput( K2Input,  k2);
            else errorInput( K2Input,  k2);

            Draw();
        }

        private void K3Input_TextChanged(object sender, EventArgs e)
        {
            if (!Double.TryParse(K3Input.Text, out k3.value))
            {
                errorInput( K3Input,  k3);
                return;
            }
            if (k3.value > 0) okInput( K3Input,  k3);
            else errorInput( K3Input,  k3);

            Draw();
        }

        private void gInput_TextChanged(object sender, EventArgs e)
        {
            if (!Double.TryParse(gInput.Text, out g.value))
            {
                errorInput( gInput,  g);
                return;
            }
            if (g.value > 0) okInput( gInput,  g);
            else errorInput( gInput,  g);

            Draw();
        }

        private void MercuryG_Click(object sender, EventArgs e)
        {
            gInput.Text = "3,72";
        }

        private void VenusG_Click(object sender, EventArgs e)
        {
            gInput.Text = "8,87";   
        }

        private void EarthG_Click(object sender, EventArgs e)
        {
            gInput.Text = "9,77";
        }

        private void MarsG_Click(object sender, EventArgs e)
        {
            gInput.Text = "3,69";
        }

        private void JupiterG_Click(object sender, EventArgs e)
        {
            gInput.Text = "20,87";
        }

        private void SaturnG_Click(object sender, EventArgs e)
        {
            gInput.Text = "7,21";
        }

        private void UranusG_Click(object sender, EventArgs e)
        {
            gInput.Text = "8,43";
        }

        private void NeptuneG_Click(object sender, EventArgs e)
        {
            gInput.Text = "10,71";
        }

        private void PlutoG_Click(object sender, EventArgs e)
        {
            gInput.Text = "0,81";
        }
    
    }
}
