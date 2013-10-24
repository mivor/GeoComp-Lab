using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeomComp_Lab1
{
    public partial class Form1 : Form
    {
        PointGenerator pointMaker;
        Point min = new Point(50, 50);
        Point max = new Point(250, 250);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Graphics formGraph = this.CreateGraphics();
            pointMaker = new PointGenerator(min, max, 20, formGraph);
            pointMaker.DrawPoints(@"../../test.txt");
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Point[] pointArray = pointMaker.PointCollection;
        }
    }
}
