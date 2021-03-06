﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace GeomComp_Lab1
{
    class PointGenerator
    {
        private List<Point> pointCollection;
        private Point min; // top right corner
        private Point max; // bottom left corner
        private int number;
        private Graphics canvas;
        private Random rnd = new Random();

        public List<Point> PointCollection
        {
            get { return pointCollection; }
        }

        //Initializer with int coordinates
        public PointGenerator(int upperX, int upperY, int lowerX, int lowerY, int number, Graphics canvas)
        {
            min = new Point(upperX, upperY);
            max = new Point(lowerX, lowerY);
            this.number = number;
            this.canvas = canvas;
            pointCollection = new List<Point>();
        }

        //Initializer with point coordinates
        public PointGenerator(Point upper, Point lower, int number, Graphics canvas)
        {
            min = upper;
            max = lower;
            this.number = number;
            this.canvas = canvas;
            pointCollection = new List<Point>();
        }

        //Initializer with number and graph - Coordinates later
        public PointGenerator(int number, Graphics canvas)
        {
            this.number = number;
            this.canvas = canvas;
            pointCollection = new List<Point>();
        }

        //Populate area with points
        public void DrawPoints()
        {
            DrawPoints(this.min, this.max);
        }

        //Populate given coordianates with points
        public void DrawPoints(Point min, Point max)
        {
            using (Pen redPen = new Pen(Color.Red), blackPen = new Pen(Color.Black))
            {
                for (int i = 0; i < number; i++)
                {
                    int xCoord = rnd.Next(min.X, max.X + 1);
                    int yCoord = rnd.Next(min.Y, max.Y + 1);
                    pointCollection.Add( new Point(xCoord, yCoord) );
                    drawPoint(pointCollection[i], blackPen, redPen);
                }
            }
        }

        public void DrawPoints(string path)
        {
            pointCollection = new List<Point>();
            using (Pen redPen = new Pen(Color.Red), blackPen = new Pen(Color.Black))
            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while( ( line = reader.ReadLine() ) != null )
                {
                    string[] coords = line.Split(' ');
                    Point p = new Point(int.Parse(coords[0]), int.Parse(coords[1]));
                    pointCollection.Add(p);
                    drawPoint(p, blackPen, redPen);
                }
            }
        }

        //draw point from coord, with pen
        private void drawPoint(Point coord, Pen innerPen, Pen outerPen)
        {
            this.canvas.DrawEllipse(innerPen, coord.X, coord.Y, 1, 1);
            this.canvas.DrawEllipse(outerPen, coord.X - 1, coord.Y - 1, 2, 2);
        }

    }
}
