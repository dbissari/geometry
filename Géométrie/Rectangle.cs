using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Géométrie
{
    public class Rectangle : Parallelogramme
    {
        public double longueur { get; private set; }
        public double largeur { get; private set; }
        public Rectangle()
        {
            points = new Point[4];
            Point A = new Point(new Random().Next(1, 10), new Random().Next(1, 10));
            largeur = new Random().Next(1, 5);
            longueur = new Random().Next(6, 10);
            points[0] = A;
            points[1] = new Point(A.x + longueur, A.y);
            points[2] = new Point(A.x + longueur, A.y - largeur);
            points[3] = new Point(A.x, A.y - largeur);
        }
        public Rectangle(double lg, double lrg)
        {
            points = new Point[4];
            Point A = new Point(new Random().Next(1, 10), new Random().Next(1, 10));
            points[0] = A;
            largeur = lrg;
            longueur = lg;
            points[1] = new Point(A.x + lg, A.y);
            points[2] = new Point(A.x + lg, A.y - lrg);
            points[3] = new Point(A.x, A.y - lrg);
        }
        public Rectangle(Point[] points)
        {
            this.points = points;
            if (points[0].Distance(points[1]) < points[1].Distance(points[2]))
            {
                longueur = points[1].Distance(points[2]);
                largeur = points[0].Distance(points[1]);
            }
            else
            {
                largeur = points[1].Distance(points[2]);
                longueur = points[0].Distance(points[1]);
            }
        }
        public double Aire()
        {
            return longueur * largeur;
        }
        public double Perimetre()
        {
            return (longueur + largeur) * 2;
        }
    }
}
