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

namespace Physics
{
    public partial class MainWindow : Form
    {
        struct Argument
        {
            public bool ok;
            public double value;
        };

        private Argument mass;     // mass of the body
        private Argument defaultH; // start height
        private Argument g;        // g
        private Argument angle;    // [0; pi/2]

        private Argument v0;
        private Argument v1;      // first Boundary value
        private Argument v2;      // second Boundary value

        private Argument k1;      // first interval value
        private Argument k2;      // second inteval value
        private Argument k3;      // third interval value

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

            var myModel = new PlotModel { Title = "Example 1" };
            myModel.Series.Add(new FunctionSeries(Math.Cos, 0, 10, 0.1, "cos(x)"));
            this.plotView1.Model = myModel;

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

        private void errorInput(ref TextBox input, ref Argument arg)
        {
            input.BackColor = Color.Red;
            arg.ok = false;
        }

        private void okInput(ref TextBox input, ref Argument arg)
        {
            input.BackColor = Color.White;
            arg.ok = true;
        }

        private void MassInput_TextChanged(object sender, EventArgs e)
        {
            if (!Double.TryParse(MassInput.Text, out mass.value))
            {
                errorInput(ref MassInput, ref mass);
                return;
            }

            if (mass.value > 0) okInput(ref MassInput, ref mass);
            else errorInput(ref MassInput, ref mass);

            Log();
        }

        private void HeightInput_TextChanged(object sender, EventArgs e)
        {
            if (!Double.TryParse(HeightInput.Text, out defaultH.value))
            {
                errorInput(ref HeightInput, ref defaultH);
                return;
            }
            if (defaultH.value >= 0) okInput(ref HeightInput, ref defaultH);
            else errorInput(ref HeightInput, ref defaultH);
            Log();
        }

        private void VelInput_TextChanged(object sender, EventArgs e)
        {
            if (!Double.TryParse(VelInput.Text, out v0.value))
            {
                errorInput(ref VelInput, ref v0);
                return;
            }
            if (v0.value > 0) okInput(ref VelInput, ref v0);
            else errorInput(ref VelInput, ref v0);
            Log();
        }

        private void AngInput_TextChanged(object sender, EventArgs e)
        {
            if (!Double.TryParse(AngInput.Text, out angle.value))
            {
                errorInput(ref AngInput, ref v0);
                return;
            }
            if (angle.value >= 0 && angle.value <= 90) okInput(ref AngInput, ref angle);
            else errorInput(ref AngInput, ref v0);
            Log();
        }
        private void VelK2Input_TextChanged(object sender, EventArgs e)
        {
            if (!Double.TryParse(VelK2Input.Text, out v2.value)) {
                errorInput(ref VelK2Input, ref v2);
                return;
            }
            if (v2.value >= v1.value) {
                okInput(ref VelK2Input, ref v2);
                okInput(ref VelK1Input, ref v1);
            }
            else {
                errorInput(ref VelK1Input, ref v1);
                errorInput(ref VelK2Input, ref v2);
            }
                Log();
         }
        private void VelK1Input_TextChanged(object sender, EventArgs e)
        {
            if (!Double.TryParse(VelK1Input.Text, out v1.value))
            {
                errorInput(ref VelK1Input , ref v1);
                return;
            }
            if (v1.value < 0)
            {
                errorInput(ref VelK1Input, ref v1);
                return;
            }
            if (v2.value >= v1.value) 
            {
                okInput(ref VelK2Input, ref v2);
                okInput(ref VelK1Input, ref v1);
            }
            else
            {
                errorInput(ref VelK1Input, ref v1);
                errorInput(ref VelK2Input, ref v2);
            }
            Log();
        }

        

        private void K1Input_TextChanged(object sender, EventArgs e)
        {
            if (!Double.TryParse(K1Input.Text, out k1.value))
            {
                errorInput(ref K1Input, ref k1);
                return;
            }
            if (k1.value >=0) okInput(ref K1Input, ref k1);
            else errorInput(ref K1Input, ref k1);

            Log();
        }

        private void K2Input_TextChanged(object sender, EventArgs e)
        {
            if (!Double.TryParse(K2Input.Text, out k2.value))
            {
                errorInput(ref K2Input, ref k2);
                return;
            }
            if (k2.value > 0) okInput(ref K2Input, ref k2);
            else errorInput(ref K2Input, ref k2);

            Log();
        }

        private void K3Input_TextChanged(object sender, EventArgs e)
        {
            if (!Double.TryParse(K3Input.Text, out k3.value))
            {
                errorInput(ref K3Input, ref k3);
                return;
            }
            if (k3.value > 0) okInput(ref K3Input, ref k3);
            else errorInput(ref K3Input, ref k3);

            Log();
        }

        private void gInput_TextChanged(object sender, EventArgs e)
        {
            if (!Double.TryParse(gInput.Text, out g.value))
            {
                errorInput(ref gInput, ref g);
                return;
            }
            if (g.value > 0) okInput(ref gInput, ref g);
            else errorInput(ref gInput, ref g);

            Log();
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
