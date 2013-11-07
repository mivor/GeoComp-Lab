using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace GeomComp_Lab1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public static void MinimumAreaRectangleSimple(Graphics formGraph, List<Point> points)
        {
            Point min = new Point(500, 500);
            Point max = new Point();

            foreach (Point point in points)
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
