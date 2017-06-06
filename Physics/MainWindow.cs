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

using MetroFramework;
using MetroFramework.Forms;
using MetroFramework.Controls;
using MetroFramework.Components;

namespace Physics
{
    public partial class MainWindow : MetroForm
    {
        public readonly double delay = 0.01;

        public Arguments arguments { get; set; }
        public Charts charts { get; set; }

        private int curTabInd = 0;

        public MainWindow()
        {
            InitializeComponent();
            InitController();
            arguments = new Arguments();
            charts = new Charts(this);
            InitArgs();
        }
    }
}
