using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGrid
{
    public class Point
    {
        public int Number { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }

        public Point(int numb, int x, int y)
        {
            Number = numb;
            X = x;
            Y = y;
        }
        public void DrawPointNumber(Graphics g)
        {
            g.DrawString($"({Number}){X}; {Y}", new Font("Times New Roman", 12, FontStyle.Bold), new SolidBrush(Color.Black), X, Y);
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
