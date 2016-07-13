using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figure
{
    public struct Point
    {
        public double X { get; }
        public double Y { get; }
        public Point(double x, double y)
        {
            if (Double.IsNaN(x) || Double.IsNaN(y))
                throw new ArgumentException();
            X = x;
            Y = y;
        }
    }
}
