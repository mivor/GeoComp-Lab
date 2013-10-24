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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Graphics formGraph = this.CreateGraphics();
            Point[] array;
            //formGraph.DrawRectangle(new Pen(Color.Blue), 20, 20, 200, 200);
            Point min = new Point(50,50);
            Point max = new Point(250, 250);
            PointGenerator pointMaker = new PointGenerator(min, max, 20, formGraph);
            pointMaker.DrawPoints();
            array = pointMaker.PointCollection;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {

        }
    }
}
