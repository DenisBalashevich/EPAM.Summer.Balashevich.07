using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figure
{
    public class Rectangle : Polygon
    {
        private Point[] points;

        public Rectangle() : base(4) { }

        public Rectangle(Point[] coords) : base(coords)
        {
            if (coords.Length > 4 || coords.Length < 2 || coords.Length == 3)
                throw new ArgumentException();
            if (ReferenceEquals(coords, null))
                throw new ArgumentNullException();
            points = coords;

            if (coords.Length == 4)
                if ((Math.Abs(points[0].X - points[1].X) - Math.Abs(points[2].X - points[3].X)) > 0 ||
                    (Math.Abs(points[0].Y - points[1].Y) - Math.Abs(points[2].Y - points[3].Y)) > 0)
                    throw new ArgumentException();
        }

        public override double Perimeter()
        {
            double perimetr = 0;
            if (points.Length == 4)
                return base.Perimeter();

            if (points.Length == 2)
            {
                perimetr = 2 * (Math.Abs(points[0].X - points[1].X) + Math.Abs(points[0].Y - points[1].Y));
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
                area = Math.Abs(points[0].X - points[1].X) * Math.Abs(points[0].Y - points[1].Y);
            }
            return area;
        }
    }
}
