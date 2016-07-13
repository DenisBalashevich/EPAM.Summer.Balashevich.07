using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figure
{
    public class Polygon : IFigure
    {
        private readonly Point[] coordinates = { };

        public Polygon() { }

        public Polygon(int n)
        {
            coordinates = new Point[n];
        }

        public Polygon(Point[] coords)
        {
            if (ReferenceEquals(coords, null))
                throw new NullReferenceException();
            coordinates = new Point[coords.Length];
            coords.CopyTo(coordinates, 0);
        }

        public virtual double Perimeter()
        {
            double perimetr = 0;
            for (int i = 0; i < coordinates.Length; i++)
            {
                if (i == coordinates.Length - 1)
                    perimetr += Math.Sqrt(Math.Pow(coordinates[0].X - coordinates[i].X, 2)
                        + Math.Pow(coordinates[0].Y - coordinates[i].Y, 2));
                else
                    perimetr += Math.Sqrt(Math.Pow(coordinates[i + 1].X - coordinates[i].X, 2)
                        + Math.Pow(coordinates[i + 1].Y - coordinates[i].Y, 2));
            }
            return perimetr;
        }

        public virtual double Area()
        {
            double area = 0;
            for (int i = 0; i < coordinates.Length; i++)
            {
                if (i == coordinates.Length - 1)
                    area += (coordinates[i].X + coordinates[0].X)
                        * (coordinates[i].Y - coordinates[0].Y);
                else
                {
                    area += (coordinates[i].X + coordinates[i + 1].X)
                        * (coordinates[i].Y - coordinates[i + 1].Y);
                }
            }

            return (1.0 / 2) * Math.Abs(area);
        }
    }
}
