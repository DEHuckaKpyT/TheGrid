using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGrid
{
    public class Triangle
    {
        public int Number { get; private set; }
        public Line[] lines { get; private set; }
        public Point[] points { get; private set; }
        public bool IsExternal { get; private set; }

        Pen p = new Pen(Color.Black, 2);

        public Triangle(int numb, Line l1, Line l2, Line l3, Point[] points)
        {
            Number = numb;
            this.points = points;
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

        public Triangle DivideTriangle(List<Triangle> newTriangles, List<Line> allLines, List<Point> allPoints, int countTriangles)//деление треугольника на два
        {
            Line lineForCut = lines[2];
            Point middleNewPoint = new Point(allPoints.Count, (lineForCut.points[0].X + lineForCut.points[1].X) / 2, (lineForCut.points[0].Y + lineForCut.points[1].Y) / 2);

            Line newCutLine1 = new Line(lineForCut.points[0], middleNewPoint, lines[2].IsExternal);
            Line newCutLine2 = new Line(middleNewPoint, lineForCut.points[1], lines[2].IsExternal);

            Point farPoint = lines[0].GetNotEqualsPoint(lines[2]);

            Line middleNewLine = new Line(farPoint, middleNewPoint);

            Triangle newTriangle1;
            Triangle newTriangle2;
            if (lines[0].ContainsGeneralPoint(newCutLine1))
            {
                newTriangle1 = new Triangle(Number, lines[0], newCutLine1, middleNewLine,
                    new Point[] { newCutLine1.points[0], newCutLine1.points[1], farPoint });
                newTriangle2 = new Triangle(countTriangles, lines[1], newCutLine2, middleNewLine,
                    new Point[] { newCutLine2.points[0], newCutLine2.points[1], farPoint });
            }
            else
            {
                newTriangle1 = new Triangle(Number, lines[1], newCutLine1, middleNewLine,
                    new Point[] { newCutLine1.points[0], newCutLine1.points[1], farPoint });
                newTriangle2 = new Triangle(countTriangles, lines[0], newCutLine2, middleNewLine,
                    new Point[] { newCutLine2.points[0], newCutLine2.points[1], farPoint });
            }

            newTriangles.Add(newTriangle1);
            newTriangles.Add(newTriangle2);
            allLines.Add(middleNewLine);
            if (!allPoints.Contains(middleNewPoint))
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
