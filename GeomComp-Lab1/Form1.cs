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
        Graphics formGraph;
        Point min = new Point(50, 50);
        Point max = new Point(250, 250);

        public Form1()
        {
            InitializeComponent();
            CenterToScreen();
            formGraph = this.CreateGraphics();
            pointMaker = new PointGenerator(min, max, 20, formGraph);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Program.MinimumAreaRectangleSimple(formGraph, pointMaker);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            pointMaker.DrawPoints();
        }
    }
}
