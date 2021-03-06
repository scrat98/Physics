﻿using System;
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
            charts.H.NewX(0, charts.RealHMax);

            SPlot.Model = charts.S.GetModel();
            SPlot.Model.InvalidatePlot(true);
            charts.S.NewX(0, charts.RealHMax);

            VPlot.Model = charts.V.GetModel();
            VPlot.Model.InvalidatePlot(true);
            charts.V.NewX(0, charts.RealHMax);

            VxPlot.Model = charts.Vx.GetModel();
            VxPlot.Model.InvalidatePlot(true);
            charts.Vx.NewX(0, charts.RealHMax);

            VyPlot.Model = charts.Vy.GetModel();
            VyPlot.Model.InvalidatePlot(true);
            charts.Vy.NewX(0, charts.RealHMax);

            APlot.Model = charts.A.GetModel();
            APlot.Model.InvalidatePlot(true);
            charts.A.NewX(0, charts.RealHMax);

            AxPlot.Model = charts.Ax.GetModel();
            AxPlot.Model.InvalidatePlot(true);
            charts.Ax.NewX(0, charts.RealHMax);

            AyPlot.Model = charts.Ay.GetModel();
            AyPlot.Model.InvalidatePlot(true);
            charts.Ay.NewX(0, charts.RealHMax);

            GlobalPlot.Model = charts.Global.GetModel();
            GlobalPlot.Model.InvalidatePlot(true);

            charts.GlobalPoint = charts.H.tracker.point;
            charts.GlobalX = charts.H.tracker.X;
            charts.minX = HeightPlot.Model.Axes[0].ActualMinimum;
            charts.maxX = HeightPlot.Model.Axes[0].ActualMaximum;
        }

        public void InformationUpdate()
        {
            HRealValue.Text = Math.Round(charts.H.realData.Points[charts.RealHMax].Y, 3) + " m";
            HTheoryValue.Text = Math.Round(charts.H.theoryData.Points[charts.TheoryHMax].Y, 3) + " m";

            RealRiseTimeValue.Text = Math.Round(charts.H.realData.Points[charts.RealHMax].X, 3) + " sec";
            TheoryRiseTimeValue.Text = Math.Round(charts.H.theoryData.Points[charts.TheoryHMax].X, 3) + " sec";

            SRealValue.Text = Math.Round(charts.S.realData.Points[charts.S.realData.Points.Count - 1].Y, 3) + " m";
            STheoryValue.Text = Math.Round(charts.S.theoryData.Points[charts.S.theoryData.Points.Count - 1].Y, 3) + " m";

            RealTravelTimeValue.Text = Math.Round(charts.S.realData.Points[charts.S.realData.Points.Count - 1].X, 3) + " sec";
            TheoryTravelTimeValue.Text = Math.Round(charts.S.theoryData.Points[charts.S.theoryData.Points.Count - 1].X, 3) + " sec";
        }

        private void PlotTabs_Selecting(object sender, TabControlCancelEventArgs e)
        {
            switch (curTabInd)
            {
                case 1:
                    charts.GlobalPoint = charts.H.tracker.point;
                    charts.GlobalX = charts.H.tracker.X;
                    charts.minX = HeightPlot.Model.Axes[0].ActualMinimum;
                    charts.maxX = HeightPlot.Model.Axes[0].ActualMaximum;
                    break;
                case 2:
                    charts.GlobalPoint = charts.S.tracker.point;
                    charts.GlobalX = charts.S.tracker.X;
                    charts.minX = SPlot.Model.Axes[0].ActualMinimum;
                    charts.maxX = SPlot.Model.Axes[0].ActualMaximum;
                    break;
                case 3:
                    charts.GlobalPoint = charts.V.tracker.point;
                    charts.GlobalX = charts.V.tracker.X;
                    charts.minX = VPlot.Model.Axes[0].ActualMinimum;
                    charts.maxX = VPlot.Model.Axes[0].ActualMaximum;
                    break;
                case 4:
                    charts.GlobalPoint = charts.Vx.tracker.point;
                    charts.GlobalX = charts.Vx.tracker.X;
                    charts.minX = VxPlot.Model.Axes[0].ActualMinimum;
                    charts.maxX = VxPlot.Model.Axes[0].ActualMaximum;
                    break;
                case 5:
                    charts.GlobalPoint = charts.Vy.tracker.point;
                    charts.GlobalX = charts.Vy.tracker.X;
                    charts.minX = VyPlot.Model.Axes[0].ActualMinimum;
                    charts.maxX = VyPlot.Model.Axes[0].ActualMaximum;
                    break;
                case 6:
                    charts.GlobalPoint = charts.A.tracker.point;
                    charts.GlobalX = charts.A.tracker.X;
                    charts.minX = APlot.Model.Axes[0].ActualMinimum;
                    charts.maxX = APlot.Model.Axes[0].ActualMaximum;
                    break;
                case 7:
                    charts.GlobalPoint = charts.Ax.tracker.point;
                    charts.GlobalX = charts.Ax.tracker.X;
                    charts.minX = AxPlot.Model.Axes[0].ActualMinimum;
                    charts.maxX = AxPlot.Model.Axes[0].ActualMaximum;
                    break;
                case 8:
                    charts.GlobalPoint = charts.Ay.tracker.point;
                    charts.GlobalX = charts.Ay.tracker.X;
                    charts.minX = AyPlot.Model.Axes[0].ActualMinimum;
                    charts.maxX = AyPlot.Model.Axes[0].ActualMaximum;
                    break;
            }

            switch (e.TabPageIndex)
            {
                case 1:
                    charts.H.NewX(charts.GlobalX, charts.GlobalPoint);
                    if(charts.minX != charts.maxX) HeightPlot.Model.Axes[0].Zoom(charts.minX, charts.maxX);
                    HeightPlot.Model.Axes[1].Reset();
                    break;
                case 2:
                    charts.S.NewX(charts.GlobalX, charts.GlobalPoint);
                    if (charts.minX != charts.maxX) SPlot.Model.Axes[0].Zoom(charts.minX, charts.maxX);
                    SPlot.Model.Axes[1].Reset();
                    break;
                case 3:
                    charts.V.NewX(charts.GlobalX, charts.GlobalPoint);
                    if (charts.minX != charts.maxX) VPlot.Model.Axes[0].Zoom(charts.minX, charts.maxX);
                    VPlot.Model.Axes[1].Reset();
                    break;
                case 4:
                    charts.Vx.NewX(charts.GlobalX, charts.GlobalPoint);
                    if (charts.minX != charts.maxX) VxPlot.Model.Axes[0].Zoom(charts.minX, charts.maxX);
                    VxPlot.Model.Axes[1].Reset();
                    break;
                case 5:
                    charts.Vy.NewX(charts.GlobalX, charts.GlobalPoint);
                    if (charts.minX != charts.maxX) VyPlot.Model.Axes[0].Zoom(charts.minX, charts.maxX);
                    VyPlot.Model.Axes[1].Reset();
                    break;
                case 6:
                    charts.A.NewX(charts.GlobalX, charts.GlobalPoint);
                    if (charts.minX != charts.maxX) APlot.Model.Axes[0].Zoom(charts.minX, charts.maxX);
                    APlot.Model.Axes[1].Reset();
                    break;
                case 7:
                    charts.Ax.NewX(charts.GlobalX, charts.GlobalPoint);
                    if (charts.minX != charts.maxX) AxPlot.Model.Axes[0].Zoom(charts.minX, charts.maxX);
                    AxPlot.Model.Axes[1].Reset();
                    break;
                case 8:
                    charts.Ay.NewX(charts.GlobalX, charts.GlobalPoint);
                    if (charts.minX != charts.maxX) AyPlot.Model.Axes[0].Zoom(charts.minX, charts.maxX);
                    AyPlot.Model.Axes[1].Reset();
                    break;
            }

            curTabInd = e.TabPageIndex;
        }

        public ChartData GetCurrentChartData()
        {
            switch (curTabInd)
            {
                case 0:
                    return charts.Global;
                case 1:
                    return charts.H;
                case 2:
                    return charts.S;
                case 3:
                    return charts.V;
                case 4:
                    return charts.Vx;
                case 5:
                    return charts.Vy;
                case 6:
                    return charts.A;
                case 7:
                    return charts.Ax;
                case 8:
                    return charts.Ay;
            }

            return null;
        }

        public void NewTrackerPosition(double x)
        {
            ChartData chart = GetCurrentChartData();
            if(chart != null && chart != charts.Global) chart.NewX(x);
        }

        public void NewTrackerPosition(double x, int point)
        {
            ChartData chart = GetCurrentChartData();
            if (chart != null && chart != charts.Global) chart.NewX(x, point);
        }

        public void Log()
        {
#if DEBUG
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
#endif
        }
    }
}
