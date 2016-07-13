using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figure
{
    public class Square : Polygon
    {
        private Point[] points;
        public Square() : base(4)
        {
        }

        public Square(Point[] coords)
            : base(coords)
        {
            if (coords.Length != 2 || ReferenceEquals(coords, null))
                throw new ArgumentException();
            if (Math.Abs(Math.Abs(coords[0].X - coords[1].X) - Math.Abs(coords[0].Y - coords[1].Y)) != 0)
                throw new ArgumentException();
            points = coords;
        }

        public override double Perimeter()
        {
            double perimetr = 0;
            if (points.Length == 4)
                return base.Perimeter();

            if (points.Length == 2)
            {
                perimetr = 4 * (Math.Abs(points[0].X - points[1].X));
            }
            return perimetr;
        }

        public override double Area()
        {
            if (points.Length == 4)
                return base.Area();
            double area = 0;
            if (points.Length == 2)
            {
                area = Math.Pow(Math.Abs(points[0].X - points[1].X), 2);
            }
            return area;
        }
    }
}
