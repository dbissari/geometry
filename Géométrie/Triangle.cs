using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Géométrie
{
    public class Triangle
    {
        public Point[] points;
        public double cote1 { get; protected set; }
        public double cote2 { get; protected set; }
        public double cote3 { get; protected set; }
        public double hauteur { get; protected set; }
        public  Triangle()
        {
            points = new Point[3];
            points[0] = new Point(new Random().Next(1, 5),new Random().Next(1, 5));
            points[1] = new Point(new Random().Next(1, 10), -new Random().Next(1, 10));
            points[2] = new Point(-new Random().Next(1, 10), new Random().Next(1, 10));
            cote1 = points[0].Distance(points[1]);
            cote2 = points[1].Distance(points[2]);
            cote3 = points[2].Distance(points[0]);
            if (points[1].x == points[2].x)
                this.hauteur = Math.Abs(points[0].x - points[1].x);
            else
            {
                double coefdir = (points[1].y - points[2].y) / (points[1].x - points[2].x);
                if (coefdir == 0)
                    this.hauteur = Math.Abs(points[0].y - points[1].y);
                else
                {
                    double coefper = -1 / coefdir, bper = points[0].y - coefper * points[0].x, bdir = points[1].y - coefdir * points[1].x;
                    Point h = new Point((bdir - bper) / (coefper - coefdir), (coefper * ((bdir - bper) / (coefper - coefdir))) + bper);
                    this.hauteur = h.Distance(points[0]);
                }
            }
        }
        public  Triangle (Point A)
        {
            points = new Point[3];
            points[0] = A;
            points[1] = new Point(A.x - new Random().Next(10, 20), A.y - new Random().Next(1, 10));
            points[2] = new Point(A.x + new Random().Next(1, 10), A.y - new Random().Next(10, 20));
            cote1 = points[0].Distance(points[1]);
            cote2 = points[1].Distance(points[2]);
            cote3 = points[2].Distance(points[0]);
            if (points[1].x == points[2].x)
                this.hauteur = Math.Abs(points[0].x - points[1].x);
            else
            {
                double coefdir = (points[1].y - points[2].y) / (points[1].x - points[2].x);
                if (coefdir == 0)
                    this.hauteur = Math.Abs(points[0].y - points[1].y);
                else
                {
                    double coefper = -1 / coefdir, bper = points[0].y - coefper * points[0].x, bdir = points[1].y - coefdir * points[1].x;
                    Point h = new Point((bdir - bper) / (coefper - coefdir), (coefper * ((bdir - bper) / (coefper - coefdir))) + bper);
                    this.hauteur = h.Distance(points[0]);
                }
            }
        }
        public Triangle(Point A, Point B)
        {
            points = new Point[3];
            points[0] = A;
            points[1] = B;
            points[2] = new Point(A.x + new Random().Next(1, 20), B.y + new Random().Next(1, 20));
            cote1 = points[0].Distance(points[1]);
            cote2 = points[1].Distance(points[2]);
            cote3 = points[2].Distance(points[0]);
            if (points[1].x == points[2].x)
                this.hauteur = Math.Abs(points[0].x - points[1].x);
            else
            {
                double coefdir = (points[1].y - points[2].y) / (points[1].x - points[2].x);
                if (coefdir == 0)
                    this.hauteur = Math.Abs(points[0].y - points[1].y);
                else
                {
                    double coefper = -1 / coefdir, bper = points[0].y - coefper * points[0].x, bdir = points[1].y - coefdir * points[1].x;
                    Point h = new Point((bdir - bper) / (coefper - coefdir), (coefper * ((bdir - bper) / (coefper - coefdir))) + bper);
                    this.hauteur = h.Distance(points[0]);
                }
            }
        }
        public Triangle(Point[] points)
        {
            this.points=points;
            cote1 = points[0].Distance(points[1]);
            cote2 = points[1].Distance(points[2]);
            cote3 = points[2].Distance(points[0]);
            if (points[1].x == points[2].x)
                this.hauteur = Math.Abs(points[0].x - points[1].x);
            else
            {
                double coefdir = (points[1].y - points[2].y) / (points[1].x - points[2].x);
                if (coefdir == 0)
                    this.hauteur = Math.Abs(points[0].y - points[1].y);
                else
                {
                    double coefper = -1 / coefdir, bper = points[0].y - coefper * points[0].x, bdir = points[1].y - coefdir * points[1].x;
                    Point h = new Point((bdir - bper) / (coefper - coefdir), (coefper * ((bdir - bper) / (coefper - coefdir))) + bper);
                    this.hauteur = h.Distance(points[0]);
                }
            }
        }
        public double Aire()
        {
            return cote2 * hauteur / 2;
        }
        public double Perimetre()
        {
            return cote1 + cote2 + cote3;
        }
    }
}
