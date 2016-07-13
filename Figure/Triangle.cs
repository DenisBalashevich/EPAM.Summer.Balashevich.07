using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figure
{
    public class Triangle : Polygon
    {
        public Triangle() : base(3) { }

        public Triangle(Point[] coords)
            : base(coords)
        {
            if (ReferenceEquals(coords, null))
                throw new ArgumentNullException();
            if (coords.Length != 3)
                throw new ArgumentException();
        }
    }
}
