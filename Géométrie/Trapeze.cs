using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Géométrie
{
    public class Trapeze : Parallelogramme
    {
        public double longCP { get; private set; }
        public double petitCP { get; private set; }
        public double hauteur { get; private set; }
        public Trapeze(double val)
        {
            points = new Point[4];
            Point A = new Point(new Random().Next(1, 10), new Random().Next(1, 10));
            this.points[0] = A;
            points[0] = A;
            petitCP = val;
            points[1] = new Point(A.x + val, A.y);
            points[2] = new Point(A.x + val + new Random().Next(1, 10), A.y - new Random().Next(1, 10));
            points[3] = new Point(A.x - new Random().Next(1, 10), points[2].y);
            longCP = points[2].x - points[3].x;
            hauteur = points[1].y - points[2].y;
        }
        public Trapeze ()
        {
            points = new Point[4];
            Point A = new Point(new Random().Next(1, 10), new Random().Next(1, 10));
            this.points[0] = A;
            int val = new Random().Next(5, 15);
            petitCP = val;
            points[1] = new Point(A.x + val, A.y);
            points[2] = new Point(A.x + val + new Random().Next(1, 10), A.y - new Random().Next(1, 10));
            points[3] = new Point(A.x - new Random().Next(1, 10), points[2].y);
            longCP = points[2].x - points[3].x;
            hauteur = points[1].y - points[2].y;
        }
        public Trapeze(Point[] points)
        {
            this.points = points;
            double[] coefdir = new double[4];
            int[] para = new int[2];
            bool perp = false;
            for (int i = 0; i < 4; i++)
            {
                int s = i + 1;
                if (s > 3)
                    s -= 4;
                coefdir[i] = (points[s].y - points[i].y) / (points[s].x - points[i].x);
            }
            for (int i = 0; i < 2; i++)
            {
                int si = i + 1;
                if (si > 3)
                    si -= 4;
                if (coefdir[i] ==coefdir[i + 2])
                {
                    if (points[i].x == points[i + 1].x)
                        perp = true;
                    int sii = i + 3;
                    if (sii > 3)
                        sii -= 4;
                    if (points[i].Distance(points[si]) < points[i + 2].Distance(points[sii]))
                    {
                        longCP = points[i + 2].Distance(points[sii]);
                        petitCP = points[i].Distance(points[si]);
                        para[0] = i + 2;
                        para[1] = i;
                    }
                    else
                    {
                        petitCP = points[i + 2].Distance(points[sii]);
                        longCP = points[i].Distance(points[si]);
                        para[0] = i;
                        para[1] = i + 2;
                    }
                }
            }
            if (coefdir[para[0]] == 0)
                this.hauteur = Math.Abs(points[para[1]].y - points[para[0]].y);
            else if (perp)
                this.hauteur = Math.Abs(points[para[1]].x - points[para[0]].x);
            else
            {
                double coefper = -1 / coefdir[para[0]], bper = points[para[1]].y - coefper * points[para[1]].x, bdir = points[para[0]].y - coefdir[para[0]] * points[para[0]].x;
                Point h = new Point((bdir - bper) / (coefper - coefdir[para[0]]), (coefper * ((bdir - bper) / (coefper - coefdir[para[0]]))) + bper);
                this.hauteur = h.Distance(points[para[1]]);
            }
        }
        public double Perimetre()
        {
            return points[0].Distance(points[1]) + points[1].Distance(points[2]) + points[2].Distance(points[3]) + points[3].Distance(points[0]);
        }
        public double Aire()
        {
            return (longCP + petitCP) * hauteur / 2;
        }
    }
}


