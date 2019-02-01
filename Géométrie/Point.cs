using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Géométrie
{
    public class Point
    {
        private double X, Y;
        public double x {
            set{ this.X = value;}
            get{ return this.X;}
        }
        public double y
        {
            set { this.Y = value; }
            get { return this.Y; }
        }
        public Point()
        {
            this.x = 0;
            this.y = 0;
        }
        public Point(double a, double b)
        {
            this.x = a;
            this.y = b;
        }
        public double Distance(Point p)
        {
            double dist = (this.x - p.x) * (this.x - p.x) + (this.y - p.y) * (this.y - p.y);
            return Math.Sqrt(Math.Abs(dist));
        }
    }
}
