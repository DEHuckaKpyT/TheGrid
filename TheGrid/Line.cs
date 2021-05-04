using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGrid
{
    class Line
    {
        public Point[] points { get; private set; }
        public double Lenght { get; private set; }
        public bool IsExternal { get; set; }

        public Line(Point p1, Point p2, bool isExternal = false)
        {
            points = new Point[2];
            points[0] = p1;
            points[1] = p2;
            IsExternal = isExternal;
            Lenght = Math.Sqrt(Math.Abs(Math.Pow(points[1].Y - points[0].Y, 2) + Math.Pow(points[1].X - points[0].X, 2)));
        }

        public Point GetNotEqualsPoint(Line line)//возвращает точку, не равную заданной в этой линии
        {
            if (points[0].Equals(line.points[0])) return points[1];
            if (points[1].Equals(line.points[0])) return points[0];
            if (points[0].Equals(line.points[1])) return points[1];
            return points[0];
        }

        public System.Drawing.Point GetGeneralPoint(Line line)//возвращает общую точку у двух прямых
        {
            if (points[0].Equals(line.points[0]) || points[0].Equals(line.points[1])) 
                return new System.Drawing.Point(points[0].X, points[0].Y);
            else
                return new System.Drawing.Point(points[1].X, points[1].Y);
        }

        public bool ContainsGeneralPoint(Line line)//содержит ли общую точку
        {
            if (points[0].Equals(line.points[0])) return true;
            if (points[0].Equals(line.points[1])) return true;
            if (points[1].Equals(line.points[0])) return true;
            if (points[1].Equals(line.points[1])) return true;
            return false;
        }

        public override bool Equals(object obj)
        {
            Line line = obj as Line;
            return (line.points[0].Equals(points[0]) && line.points[1].Equals(points[1])) || 
                (line.points[1].Equals(points[0]) && line.points[0].Equals(points[1]));
        }
    }
}
