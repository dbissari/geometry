using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Géométrie
{
    public class Isocele : Triangle
    {
        public Isocele()
        {
            points = new Point[3];
            Point A = new Point(new Random().Next(1, 10), new Random().Next(1, 10));
            this.points[0] = A;
            double cote = new Random().Next(5, 10);
            cote1 = cote;
            cote2 = 6;
            cote3 = cote;
            points[0] = A;
            hauteur = Math.Sqrt(Math.Abs((cote * cote) - (cote2 / 2) * (cote2 / 2)));
            points[1] = new Point(A.x - (cote2 / 2), A.y - hauteur);
            points[2]=new Point(A.x + (cote2 / 2), A.y - hauteur);
        }
        public Isocele(double cote)
        {
            points = new Point[3];
            Point A = new Point(new Random().Next(1, 10), new Random().Next(1, 10));
            this.points[0] = A;
            cote1 = cote;
            cote2 = new Random().Next(4, 10);
            cote3 = cote;
            hauteur = Math.Sqrt(Math.Abs((cote * cote) - (cote2 / 2) * (cote2 / 2)));
            points[1] = new Point(A.x - (cote2 / 2), A.y - hauteur);
            points[2] = new Point(A.x + (cote2 / 2), A.y - hauteur);
        }
        public Isocele(Point[] points)
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
    }
}
