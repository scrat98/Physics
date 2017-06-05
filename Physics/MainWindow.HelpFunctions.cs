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
    public partial class MainWindow
    {
        public double DegreeToRadian(double angle)
        {
            return Math.PI * angle / 180.0;
        }

        private void InitArgs()
        {
            MassInput.Text = "80";
            gInput.Text = "9,77";
            HeightInput.Text = "50";
            AngInput.Text = "50";
            VelInput.Text = "50";
            VelInput.Text = "50";
            KInput.Text = "0,1";
            PInput.Text = "1,247";
        }

        private void InitController()
        {
            var controller = new PlotController();
            controller.BindMouseEnter(PlotCommands.HoverPointsOnlyTrack);
            controller.BindMouseDown(OxyMouseButton.Left, PlotCommands.PanAt);
            controller.UnbindMouseDown(OxyMouseButton.Right);

            HeightPlot.Controller = controller;
            SPlot.Controller = controller;
            VPlot.Controller = controller;
            VxPlot.Controller = controller;
            VyPlot.Controller = controller;
            APlot.Controller = controller;
            AxPlot.Controller = controller;
            AyPlot.Controller = controller;
            GlobalPlot.Controller = controller;
        }

        public void PlotsUpdate()
        {
            HeightPlot.Model = charts.H.GetModel();
            HeightPlot.Model.InvalidatePlot(true);

            SPlot.Model = charts.S.GetModel();
            SPlot.Model.InvalidatePlot(true);

            VPlot.Model = charts.V.GetModel();
            VPlot.Model.InvalidatePlot(true);

            VxPlot.Model = charts.Vx.GetModel();
            VxPlot.Model.InvalidatePlot(true);

            VyPlot.Model = charts.Vy.GetModel();
            VyPlot.Model.InvalidatePlot(true);

            APlot.Model = charts.A.GetModel();
            APlot.Model.InvalidatePlot(true);

            AxPlot.Model = charts.Ax.GetModel();
            AxPlot.Model.InvalidatePlot(true);

            AyPlot.Model = charts.Ay.GetModel();
            AyPlot.Model.InvalidatePlot(true);

            GlobalPlot.Model = charts.Global.GetModel();
            GlobalPlot.Model.InvalidatePlot(true);
        }

        public void Log()
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

            if (arguments.k.ok)
                Console.WriteLine("k: " + arguments.k.value);
            else
                Console.WriteLine("k: ERROR");

            if (arguments.p.ok)
                Console.WriteLine("p: " + arguments.p.value);
            else
                Console.WriteLine("p: ERROR");

            if (arguments.g.ok)
                Console.WriteLine("g: " + arguments.g.value);
            else
                Console.WriteLine("g: ERROR ");
            Console.WriteLine();
        }
    }
}
