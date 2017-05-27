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
        }
    }
}
