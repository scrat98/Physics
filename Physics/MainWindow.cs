using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using System.Windows.Forms;
using LiveCharts;               //Core of the library
using LiveCharts.Wpf;           //The WPF controls
using LiveCharts.WinForms;      //the WinForm wrappers
using LiveCharts.Defaults;

namespace Physics
{
    public partial class MainWindow : Form
    {
        bool OK = false;         // if all values are correct

        private double mass;     // mass of the body
        private double defaultH; // start height
        private double g;        // g
        private double angle;    // [0; pi/2]

        private double v1;      // first Boundary value
        private double v2;      // second Boundary value

        private double k1;      // first interval value
        private double k2;      // second inteval value
        private double k3;      // third interval value

        public MainWindow()
        {
            InitializeComponent();

            cartesianChart1.Series.Add(new LineSeries
            {
                Title = "y = x^2",
                Values = new ChartValues<ObservablePoint>(),
                StrokeThickness = 4,
                StrokeDashArray = new System.Windows.Media.DoubleCollection(20),
                Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(107, 185, 69)),
                Fill = System.Windows.Media.Brushes.Transparent,
                LineSmoothness = 0
            });
            for (int i = -10; i <= 10; i++)
                cartesianChart1.Series[0].Values.Add(new ObservablePoint(i, i * i));

            cartesianChart1.Series.Add(new LineSeries
            {
                Title = "y = x^(3/2)",
                Values = new ChartValues<ObservablePoint>(),
                StrokeThickness = 2,
                Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(28, 142, 196)),
                Fill = System.Windows.Media.Brushes.Transparent,
                LineSmoothness = 1,
                PointGeometrySize = 15,
                PointForeground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(34, 46, 49))
            });
            for (int i = -10; i <= 10; i++)
                cartesianChart1.Series[1].Values.Add(new ObservablePoint(i, Math.Pow(i, 3/2)));

            cartesianChart1.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(34, 46, 49));
            cartesianChart1.LegendLocation = LegendLocation.Top;
            cartesianChart1.Zoom = ZoomingOptions.Xy;

            cartesianChart1.AxisX.Add(new Axis
            {
                IsMerged = true,
                Separator = new Separator
                {
                    StrokeThickness = 1,
                    StrokeDashArray = new System.Windows.Media.DoubleCollection(2),
                    Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(64, 79, 86))
                }
            });
            cartesianChart1.AxisY.Add(new Axis
            {
                IsMerged = true,
                Separator = new Separator
                {
                    StrokeThickness = 1.5,
                    StrokeDashArray = new System.Windows.Media.DoubleCollection(4),
                    Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(64, 79, 86))
                }
            });
        }
    }
}
