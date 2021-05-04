using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGrid
{
    class Triangle
    {
        public Line[] lines { get; private set; }
        Pen p = new Pen(Color.Black, 1);
        public bool IsExternal { get; private set; }

        public Triangle(Line l1, Line l2, Line l3)
        {
            lines = new Line[3];
            lines[0] = l1;
            lines[1] = l2;
            lines[2] = l3;
            lines = lines.OrderBy(c => c.Lenght).ToArray();
            if (lines[0].IsExternal || lines[1].IsExternal || lines[2].IsExternal)
                IsExternal = true;
        }

        public void DrawTriangle(Graphics g, Color color)
        {
            g.DrawLine(p, lines[0].points[0].X, lines[0].points[0].Y, lines[0].points[1].X, lines[0].points[1].Y);
            g.DrawLine(p, lines[1].points[0].X, lines[1].points[0].Y, lines[1].points[1].X, lines[1].points[1].Y);
            g.DrawLine(p, lines[2].points[0].X, lines[2].points[0].Y, lines[2].points[1].X, lines[2].points[1].Y);
        }

        public void FillTriangle(Graphics g, Color color)
        {
            g.FillPolygon(new SolidBrush(color), GetPointsForFill());
        }

        public Triangle DivideTriangle(List<Triangle> newTriangles, List<Line> allLines, List<Point> allPoints)//деление треугольника на два
        {
            Line lineForCut = lines[2];
            Point middleNewPoint = new Point((lineForCut.points[0].X + lineForCut.points[1].X) / 2, (lineForCut.points[0].Y + lineForCut.points[1].Y) / 2);

            Line newCutLine1 = new Line(lineForCut.points[0], new Point(middleNewPoint.X, middleNewPoint.Y), lines[2].IsExternal);
            Line newCutLine2 = new Line(new Point(middleNewPoint.X, middleNewPoint.Y), lineForCut.points[1], lines[2].IsExternal);

            Point farPoint = lines[0].GetNotEqualsPoint(lines[2]);

            Line middleNewLine = new Line(farPoint, middleNewPoint);

            Triangle newTriangle1;
            Triangle newTriangle2;
            if (lines[0].ContainsGeneralPoint(newCutLine1))
            {
                newTriangle1 = new Triangle(lines[0], newCutLine1, middleNewLine);
                newTriangle2 = new Triangle(lines[1], newCutLine2, middleNewLine);
            }
            else
            {
                newTriangle1 = new Triangle(lines[1], newCutLine1, middleNewLine);
                newTriangle2 = new Triangle(lines[0], newCutLine2, middleNewLine);
            }

            newTriangles.Add(newTriangle1);
            newTriangles.Add(newTriangle2);
            allLines.Remove(lineForCut);
            allLines.Add(middleNewLine);
            allLines.Add(newCutLine1);
            allLines.Add(newCutLine2);
            allPoints.Add(middleNewPoint);

            return this;
        }

        System.Drawing.Point[] GetPointsForFill()//возвращает три точки, для закрашивания треугольника
        {
            var points = new System.Drawing.Point[3];
            points[0] = lines[0].GetGeneralPoint(lines[1]);
            points[1] = new System.Drawing.Point(lines[2].points[0].X, lines[2].points[0].Y);
            points[2] = new System.Drawing.Point(lines[2].points[1].X, lines[2].points[1].Y);
            return points;
        }
    }
}
