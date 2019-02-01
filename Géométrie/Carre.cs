using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Géométrie
{
    public class Carre : Parallelogramme
    {
        public double cote { get; private set; }
        public Carre(Point[] points)
        {
            this.points = points;
            cote = points[0].Distance(points[1]);
        }
        public Carre()
        {
            points = new Point[4];
            Point A = new Point(new Random().Next(1, 10), new Random().Next(1, 10));
            this.points[0] = A;
            cote = A.x + new Random().Next(1, 10);
            points[1] = new Point(A.x + cote, A.y);
            points[2] = new Point(A.x + cote, A.y + cote);
            points[3] = new Point(A.x, A.y + cote);
        }
        public Carre(double coteE)
        {
            points = new Point[4];
            Point A = new Point(new Random().Next(1, 10), new Random().Next(1, 10));
            this.points[0] = A;
            this.cote = coteE;
            this.points[0] = A;
            points[1] = new Point(A.x + coteE, A.y);
            points[2] = new Point(A.x + coteE, A.y + coteE);
            points[3] = new Point(A.x, A.y + coteE);
        }
        public double Aire()
        {
            return cote * cote;
        }
        public double Perimetre()
        {
            return cote * 4;
        }
    }
}
