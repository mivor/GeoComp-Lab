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
            formGraph = this.CreateGraphics();
            pointMaker = new PointGenerator(min, max, 20, formGraph);
            
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            pointMaker.DrawPoints(@"testProb1.txt");
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Point min = new Point(500,500);
            Point max = new Point();

            foreach (Point point in pointMaker.PointCollection)
            {
                min.X = (point.X < min.X) ? point.X : min.X;
                min.Y = (point.Y < min.Y) ? point.Y : min.Y;
                max.X = (point.X > max.X) ? point.X : max.X;
                max.Y = (point.Y > max.Y) ? point.Y : max.Y;
            }
            formGraph.DrawRectangle(new Pen(Color.Blue), min.X, min.Y, max.X - min.X, max.Y - min.Y);
        }
    }
}
