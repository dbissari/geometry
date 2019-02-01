using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Géométrie
{
    public class Cercle
    {
        public Point centre { get; private set; }
        public double rayon { get; private set; }
        public Cercle(Point C, double r)
        {
            this.centre = C;
            this.rayon = r;
        }
        public Cercle(double r)
        {
            Point C = new Point(new Random().Next(1, 10), new Random().Next(1, 10));
            this.centre = C;
            this.rayon = r;
        }
        public Cercle()
        {
            Point C = new Point(new Random().Next(1, 10), new Random().Next(1, 10));
            this.centre = C;
            this.rayon = new Random().Next(5, 10);
        }
        public Cercle(Point C)
        {
            this.centre = C;
            this.rayon = new Random().Next(5, 10);
        }
        public double Aire()
        {
            return 2 * rayon * rayon * 22 / 7;
        }
        public double Perimetre()
        {
            return 2 * rayon * 22 / 7;
        }
    }
}
