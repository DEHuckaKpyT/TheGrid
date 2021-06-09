using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGrid
{
    public class Point
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public override bool Equals(object obj)
        {
            Point point = obj as Point;
            return (X == point.X && Y == point.Y);
        }
        public override string ToString()
        {
            return $"X = {X}, Y = {Y}";
        }
    }
}
