using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MetroFramework.Controls;
namespace Physics
{
    public partial class MainWindow
    {
        private void errorInput(MetroTextBox input, Argument arg)
        {
            input.BackColor = Color.Red;
            arg.ok = false;
        }
        
        private void okInput(MetroTextBox input, Argument arg)
        {
            input.BackColor = Color.White;
            arg.ok = true;
        }

        private void MassInput_TextChanged(object sender, EventArgs e)
        {
            if (!Double.TryParse(MassInput.Text, out arguments.mass.value))
            {
                errorInput(MassInput, arguments.mass);
                Log();
                return;
            }

            if (arguments.mass.value > 0) okInput(MassInput, arguments.mass);
            else errorInput(MassInput, arguments.mass);

            Draw();
        }

        private void HeightInput_TextChanged(object sender, EventArgs e)
        {
            if (!Double.TryParse(HeightInput.Text, out arguments.defaultH.value))
            {
                errorInput(HeightInput, arguments.defaultH);
                Log();
                return;
            }
            if (arguments.defaultH.value >= 0) okInput(HeightInput, arguments.defaultH);
            else errorInput(HeightInput, arguments.defaultH);
            Draw();
        }

        private void VelInput_TextChanged(object sender, EventArgs e)
        {
            if (!Double.TryParse(VelInput.Text, out arguments.v0.value))
            {
                errorInput(VelInput, arguments.v0);
                Log();
                return;
            }
            if (arguments.v0.value > 0) okInput(VelInput, arguments.v0);
            else errorInput(VelInput, arguments.v0);
            Draw();
        }

        private void AngInput_TextChanged(object sender, EventArgs e)
        {
            if (!Double.TryParse(AngInput.Text, out arguments.angle.value))
            {
                errorInput(AngInput, arguments.angle);
                Log();
                return;
            }
            if (arguments.angle.value >= 0 && arguments.angle.value <= 90) okInput(AngInput, arguments.angle);
            else errorInput(AngInput, arguments.angle);
            Draw();
        }

        private void VelK2Input_TextChanged(object sender, EventArgs e)
        {
            if (!Double.TryParse(VelK2Input.Text, out arguments.v2.value))
            {
                errorInput(VelK2Input, arguments.v2);
                Log();
                return;
            }
            if (arguments.v2.value >= arguments.v1.value)
            {
                okInput(VelK2Input, arguments.v2);
                if(Double.TryParse(VelK1Input.Text, out arguments.v1.value))
                    okInput(VelK1Input, arguments.v1);
            }
            else
            {
                errorInput(VelK1Input, arguments.v1);
                errorInput(VelK2Input, arguments.v2);
            }

            Draw();
        }

        private void VelK1Input_TextChanged(object sender, EventArgs e)
        {
            if (!Double.TryParse(VelK1Input.Text, out arguments.v1.value))
            {
                errorInput(VelK1Input, arguments.v1);
                Log();
                return;
            }

            if (arguments.v1.value < 0)
            {
                errorInput(VelK1Input, arguments.v1);
                Log();
                return;
            }

            if (arguments.v2.value >= arguments.v1.value)
            {
                if(Double.TryParse(VelK2Input.Text, out arguments.v2.value))
                    okInput(VelK2Input, arguments.v2);
                okInput(VelK1Input, arguments.v1);
            }
            else
            {
                errorInput(VelK1Input, arguments.v1);
                errorInput(VelK2Input, arguments.v2);
            }

            Draw();
        }

        private void K1Input_TextChanged(object sender, EventArgs e)
        {
            if (!Double.TryParse(K1Input.Text, out arguments.k1.value))
            {
                errorInput(K1Input, arguments.k1);
                Log();
                return;
            }
            if (arguments.k1.value >= 0) okInput(K1Input, arguments.k1);
            else errorInput(K1Input, arguments.k1);

            Draw();
        }

        private void K2Input_TextChanged(object sender, EventArgs e)
        {
            if (!Double.TryParse(K2Input.Text, out arguments.k2.value))
            {
                errorInput(K2Input, arguments.k2);
                Log();
                return;
            }
            if (arguments.k2.value > 0) okInput(K2Input, arguments.k2);
            else errorInput(K2Input, arguments.k2);

            Draw();
        }

        private void K3Input_TextChanged(object sender, EventArgs e)
        {
            if (!Double.TryParse(K3Input.Text, out arguments.k3.value))
            {
                errorInput(K3Input, arguments.k3);
                Log();
                return;
            }
            if (arguments.k3.value > 0) okInput(K3Input, arguments.k3);
            else errorInput(K3Input, arguments.k3);

            Draw();
        }

        private void gInput_TextChanged(object sender, EventArgs e)
        {
            if (!Double.TryParse(gInput.Text, out arguments.g.value))
            {
                errorInput(gInput, arguments.g);
                Log();
                return;
            }
            if (arguments.g.value > 0) okInput(gInput, arguments.g);
            else errorInput(gInput, arguments.g);

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
