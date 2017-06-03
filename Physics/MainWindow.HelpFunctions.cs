using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physics
{
    public partial class MainWindow
    {
        private double DegreeToRadian(double angle)
        {
            return Math.PI * angle / 180.0;
        }

        private void InitArgs()
        {
            MassInput.Text = "50";
            gInput.Text = "9,77";
            HeightInput.Text = "50";
            AngInput.Text = "50";
            VelInput.Text = "50";
            VelInput.Text = "50";
            VelK1Input.Text = "5";
            VelK2Input.Text = "15";
            K1Input.Text = "0,05";
            K2Input.Text = "0,34";
            K3Input.Text = "0,47";
        }

        private void Log()
        {
            Console.Clear();
            if (arguments.mass.ok)
                Console.WriteLine("mass: " + arguments.mass.value);
            else
                Console.WriteLine("mass: ERROR");

            if (arguments.defaultH.ok)
                Console.WriteLine("defaultH: " + arguments.defaultH.value);
            else
                Console.WriteLine("defaultH: ERROR");

            if (arguments.angle.ok)
                Console.WriteLine("angle: " + arguments.angle.value);
            else
                Console.WriteLine("angle: ERROR ");

            if (arguments.v0.ok)
                Console.WriteLine("v0: " + arguments.v0.value);
            else
                Console.WriteLine("v0: ERROR ");

            if (arguments.v1.ok)
                Console.WriteLine("v1: " + arguments.v1.value);
            else
                Console.WriteLine("v1: ERROR");

            if (arguments.v2.ok)
                Console.WriteLine("v2: " + arguments.v2.value);
            else
                Console.WriteLine("v2: ERROR");

            if (arguments.k1.ok)
                Console.WriteLine("k1: " + arguments.k1.value);
            else
                Console.WriteLine("k1: ERROR");

            if (arguments.k2.ok)
                Console.WriteLine("k2: " + arguments.k2.value);
            else
                Console.WriteLine("k2: ERROR ");

            if (arguments.k3.ok)
                Console.WriteLine("k3: " + arguments.k3.value);
            else
                Console.WriteLine("k3: ERROR ");

            if (arguments.g.ok)
                Console.WriteLine("g: " + arguments.g.value);
            else
                Console.WriteLine("g: ERROR ");
            Console.WriteLine();
        }
    }
}
