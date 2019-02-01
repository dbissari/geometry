using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Géométrie
{
    public class Losange : Parallelogramme
    {
        public double cote { get; private set; }
        public Losange()
        {
            points = new Point[4];
            Point A = new Point(new Random().Next(1, 10), new Random().Next(1, 10));
            points[0] = A;
            int varx = new Random().Next(1, 5), vary = new Random().Next(1, 10);
            points[1] = new Point(A.x + varx, A.y - vary);
            points[2] = new Point(A.x, A.y - (2 * vary));
            points[3] = new Point(A.x - varx, A.y - vary);
            cote = points[0].Distance(points[1]);
        }
        public Losange(double coteE)
        {
            points = new Point[4];
            Point A = new Point(new Random().Next(1, 10), new Random().Next(1, 10));
            points[0] = A;
            cote = coteE;
            double varx = new Random().Next(1, (int)coteE), vary = Math.Sqrt(Math.Abs((coteE*coteE)-(varx*varx)));
            points[1] = new Point(A.x + varx, A.y - vary);
            points[2] = new Point(A.x, A.y - (2 * vary));
            points[3] = new Point(A.x - varx, A.y - vary);
        }
        public Losange(Point[] points)
        {
            this.points = points;
            cote = points[0].Distance(points[1]);
        }
        public double Aire()
        { 
            return points[0].Distance(points[2])*points[1].Distance(points[3])/2;
        }
        public double Perimetre()
        {
            return cote * 4;
        }
    }
}
