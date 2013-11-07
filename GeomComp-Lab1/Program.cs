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
        public enum Algorithms
        { 
            MinAreaRectSimple,
            MinAreaRect,
            ClosestPoint,
            MaxAreaCircle,
            PointsInArea,
            MinAreaTriangle,
            MinDistancePoint,
            MinAreaCircle
        }

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

        public static void MinimumAreaRectangleSimple(Graphics canvas)
        {
            //setup
            Point minCanvas = new Point(0, 0);
            Point maxCanvas = new Point(250, 250);
            PointGenerator pointMaker = new PointGenerator(minCanvas, maxCanvas, 20, canvas);
            pointMaker.DrawPoints();

            Point min = new Point(500, 500);
            Point max = new Point();

            foreach (Point point in pointMaker.PointCollection)
            {
                min.X = (point.X < min.X) ? point.X : min.X;
                min.Y = (point.Y < min.Y) ? point.Y : min.Y;
                max.X = (point.X > max.X) ? point.X : max.X;
                max.Y = (point.Y > max.Y) ? point.Y : max.Y;
            }
            canvas.DrawRectangle(new Pen(Color.Blue), min.X, min.Y, max.X - min.X, max.Y - min.Y);
        }
    }
}
