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

            charts.Draw();
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
            charts.Draw();
        }

        private void VelInput_TextChanged(object sender, EventArgs e)
        {
            if (!Double.TryParse(VelInput.Text, out arguments.v0.value))
            {
                errorInput(VelInput, arguments.v0);
                Log();
                return;
            }
            if (arguments.v0.value >= 0) okInput(VelInput, arguments.v0);
            else errorInput(VelInput, arguments.v0);
            charts.Draw();
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
            charts.Draw();
        }

        private void KInput_TextChanged(object sender, EventArgs e)
        {
            if (!Double.TryParse(KInput.Text, out arguments.k.value))
            {
                errorInput(KInput, arguments.k);
                Log();
                return;
            }
            if (arguments.k.value >= 0) okInput(KInput, arguments.k);
            else errorInput(KInput, arguments.k);

            charts.Draw();
        }

        private void PInput_TextChanged(object sender, EventArgs e)
        {
            if (!Double.TryParse(PInput.Text, out arguments.p.value))
            {
                errorInput(PInput, arguments.p);
                Log();
                return;
            }
            if (arguments.p.value >= 0) okInput(PInput, arguments.p);
            else errorInput(PInput, arguments.p);

            charts.Draw();
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

            charts.Draw();
        }

        private void MercuryG_Click(object sender, EventArgs e)
        {
            gInput.Text = "3,72";
            PInput.Text = "0";
        }

        private void VenusG_Click(object sender, EventArgs e)
        {
            gInput.Text = "8,87";
            PInput.Text = "67";
        }

        private void EarthG_Click(object sender, EventArgs e)
        {
            gInput.Text = "9,77";
            PInput.Text = "1,247";
        }

        private void MarsG_Click(object sender, EventArgs e)
        {
            gInput.Text = "3,69";
            PInput.Text = "0,002";
        }

        private void JupiterG_Click(object sender, EventArgs e)
        {
            gInput.Text = "20,87";
            PInput.Text = "5,2";
        }

        private void SaturnG_Click(object sender, EventArgs e)
        {
            gInput.Text = "7,21";
            PInput.Text = "0,07";
        }

        private void UranusG_Click(object sender, EventArgs e)
        {
            gInput.Text = "8,43";
            PInput.Text = "296,55";
        }

        private void NeptuneG_Click(object sender, EventArgs e)
        {
            gInput.Text = "10,71";
            PInput.Text = "0,06";
        }

        private void PlutoG_Click(object sender, EventArgs e)
        {
            gInput.Text = "0,81";
            PInput.Text = "0";
        }
    }
}
