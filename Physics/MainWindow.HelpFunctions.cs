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
            charts.H.NewX(0);

            SPlot.Model = charts.S.GetModel();
            SPlot.Model.InvalidatePlot(true);
            charts.S.NewX(0);

            VPlot.Model = charts.V.GetModel();
            VPlot.Model.InvalidatePlot(true);
            charts.V.NewX(0);

            VxPlot.Model = charts.Vx.GetModel();
            VxPlot.Model.InvalidatePlot(true);
            charts.Vx.NewX(0);

            VyPlot.Model = charts.Vy.GetModel();
            VyPlot.Model.InvalidatePlot(true);
            charts.Vy.NewX(0);

            APlot.Model = charts.A.GetModel();
            APlot.Model.InvalidatePlot(true);
            charts.A.NewX(0);

            AxPlot.Model = charts.Ax.GetModel();
            AxPlot.Model.InvalidatePlot(true);
            charts.Ax.NewX(0);

            AyPlot.Model = charts.Ay.GetModel();
            AyPlot.Model.InvalidatePlot(true);
            charts.Ay.NewX(0);

            GlobalPlot.Model = charts.Global.GetModel();
            GlobalPlot.Model.InvalidatePlot(true);
        }

        private void PlotTabs_Selecting(object sender, TabControlCancelEventArgs e)
        {
            switch (curTabInd)
            {
                case 1:
                    charts.GlobalPoint = charts.H.tracker.point;
                    charts.GlobalX = charts.H.tracker.X;
                    break;
                case 2:
                    charts.GlobalPoint = charts.S.tracker.point;
                    charts.GlobalX = charts.S.tracker.X;
                    break;
                case 3:
                    charts.GlobalPoint = charts.V.tracker.point;
                    charts.GlobalX = charts.V.tracker.X;
                    break;
                case 4:
                    charts.GlobalPoint = charts.Vx.tracker.point;
                    charts.GlobalX = charts.Vx.tracker.X;
                    break;
                case 5:
                    charts.GlobalPoint = charts.Vy.tracker.point;
                    charts.GlobalX = charts.Vy.tracker.X;
                    break;
                case 6:
                    charts.GlobalPoint = charts.A.tracker.point;
                    charts.GlobalX = charts.A.tracker.X;
                    break;
                case 7:
                    charts.GlobalPoint = charts.Ax.tracker.point;
                    charts.GlobalX = charts.Ax.tracker.X;
                    break;
                case 8:
                    charts.GlobalPoint = charts.Ay.tracker.point;
                    charts.GlobalX = charts.Ay.tracker.X;
                    break;
            }

            switch (e.TabPageIndex)
            {
                case 1:
                    charts.H.NewX(charts.GlobalX, charts.GlobalPoint);
                    break;
                case 2:
                    charts.S.NewX(charts.GlobalX, charts.GlobalPoint);
                    break;
                case 3:
                    charts.V.NewX(charts.GlobalX, charts.GlobalPoint);
                    break;
                case 4:
                    charts.Vx.NewX(charts.GlobalX, charts.GlobalPoint);
                    break;
                case 5:
                    charts.Vy.NewX(charts.GlobalX, charts.GlobalPoint);
                    break;
                case 6:
                    charts.A.NewX(charts.GlobalX, charts.GlobalPoint);
                    break;
                case 7:
                    charts.Ax.NewX(charts.GlobalX, charts.GlobalPoint);
                    break;
                case 8:
                    charts.Ay.NewX(charts.GlobalX, charts.GlobalPoint);
                    break;
            }

            curTabInd = e.TabPageIndex;
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
