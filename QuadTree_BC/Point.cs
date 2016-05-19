using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadTree_BC
{
    public class Point
    {
        private double _x;
        private double _y;
        private int _depth;

        public Point(double x, double y)
        {
            _x = x;
            _y = y;
            _depth = 0;
        }

        public double X()
        {
            return _x;
        }
        public double Y()
        {
            return _y;
        }
        public int Depth()
        {
            return _depth;
        }
        public void IncrementDepth()
        {
            _depth += 1;
        }

        override
        public string ToString()
        {
            return "Point x : " + X().ToString() + " y: " + Y().ToString();
        }

    }
}
