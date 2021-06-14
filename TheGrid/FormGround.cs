using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheGrid
{
    public partial class FormGround : Form
    {
        List<Point> points;
        List<Line> lines;
        List<Triangle> triangles;
        Graphics g;
        Bitmap bitmap;
        bool activeDrawingPoints = false;
        Color internalColor = Color.Blue;
        Color externalColor = Color.Red;
        FormStatistics formStatistics;
        public FormGround()
        {
            InitializeComponent();
        }

        void ReadFigures(string path)
        {
            List<int[]> stringsTriangles = new List<int[]>();

            using (StreamReader reader = new StreamReader(path))
                while (!reader.EndOfStream)
                {
                    string[] pointOrPoints = reader.ReadLine().Split(' ');
                    if (pointOrPoints.Length == 2)
                        points.Add(new Point(points.Count, int.Parse(pointOrPoints[0]), int.Parse(pointOrPoints[1])));
                    else
                        stringsTriangles.Add(new int[3] { int.Parse(pointOrPoints[0]), int.Parse(pointOrPoints[1]), int.Parse(pointOrPoints[2]) });
                }

            foreach (int[] numbers in stringsTriangles)
            {
                Point p1 = points[numbers[0]];
                Point p2 = points[numbers[1]];
                Point p3 = points[numbers[2]];

                triangles.Add(new Triangle(triangles.Count,
                    new Line(p1, p2, true), new Line(p2, p3, true), new Line(p3, p1, true),
                    new Point[] { p1, p2, p3 }));
            }

            foreach (Triangle triangle1 in triangles)
                foreach (Triangle triangle2 in triangles)
                    if (triangle1 != triangle2)
                        foreach (Line line1 in triangle1.lines)
                            foreach (Line line2 in triangle2.lines)
                                if (line1.Equals(line2))
                                {
                                    line1.IsExternal = false;
                                    line2.IsExternal = false;
                                }
        }

        private void FormGround_Load(object sender, EventArgs e)
        {
            LoadSave();
            points = new List<Point>();
            lines = new List<Line>();
            triangles = new List<Triangle>();
            bitmap = new Bitmap(pictureBoxFigure.Width, pictureBoxFigure.Height);
            g = Graphics.FromImage(bitmap);
            pictureBoxFigure.Image = bitmap;
            formStatistics = new FormStatistics(points, lines, triangles);
        }

        void CreateStartTriangles()
        {
            lines.Clear();
            triangles.Clear();
            if (points.Count < 3)
            {
                points.Clear();
                return;
            }
            Line previousLine = new Line(points[0], points[1], true);
            lines.Add(previousLine);
            Point firstPoint = points[0];
            Point previousPoint = points[1];

            Line internalLine = null;
            foreach (Point currentPoint in points.Skip(2))
            {
                Line externalLine = new Line(previousPoint, currentPoint, true);
                internalLine = new Line(currentPoint, firstPoint);
                lines.Add(externalLine);
                lines.Add(internalLine);
                Triangle currentTriangle = new Triangle(triangles.Count,
                    previousLine, externalLine, internalLine,
                    new Point[] {firstPoint, previousPoint, currentPoint });
                triangles.Add(currentTriangle);

                previousLine = internalLine;
                previousPoint = currentPoint;
            }
            internalLine.IsExternal = true;
        }

        private void pictureBoxFigure_MouseClick(object sender, MouseEventArgs e)
        {
            if (activeDrawingPoints)
            {
                points.Add(new Point(points.Count, e.X, e.Y));
                g.FillEllipse(new SolidBrush(Color.Black), e.X - 3, e.Y - 3, 6, 6);
            }
            pictureBoxFigure.Image = bitmap;
        }

        private void buttonDevideTriangles_Click(object sender, EventArgs e)
        {
            if (triangles == null) return;

            List<Triangle> forRemove = new List<Triangle>();
            List<Triangle> newTriangles = new List<Triangle>();

            foreach (Triangle triangle in triangles)
            {
                forRemove.Add(triangle.DivideTriangle(newTriangles, lines, points,
                    (triangles.Count + forRemove.Count)));
            }
            foreach(Triangle triangle in forRemove)
            {
                triangles.Remove(triangle);
            }
            forRemove.Clear();
            triangles.Clear();
            triangles.AddRange(newTriangles);

            DrawTriangles();
            pictureBoxFigure.Image = bitmap;
        }

        private void buttonbuttonShowConcreteTriangle_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            int number = int.Parse(textBoxNumber.Text);
            if (number >= 0 && number < triangles.Count)
            {
                Triangle triangle = triangles[int.Parse(textBoxNumber.Text)];
                if (triangle.IsExternal)
                    triangle.FillTriangle(g, externalColor);
                else
                    triangle.FillTriangle(g, internalColor);
            }
            else
                DrawTriangles();
            pictureBoxFigure.Image = bitmap;
        }

        private void buttonFigureFromFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files(*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            points.Clear();
            ReadFigures(openFileDialog.FileName);
            //CreateStartTriangles();
            DrawTriangles();
        }

        void DrawTriangles()
        {
            if (triangles == null) return;
            g.Clear(Color.White);
            foreach (Triangle triange in triangles)
            {
                triange.DrawTriangle(g, Color.Black);
                if (triange.IsExternal)
                    triange.FillTriangle(g, externalColor);
                else
                    triange.FillTriangle(g, internalColor);
            }
            foreach(Point point in points)
            {
                point.DrawPointNumber(g);
            }
            pictureBoxFigure.Image = bitmap;
            formStatistics.UpdateOutput();
        }

        private void buttonDrawTrianleByPoints_Click(object sender, EventArgs e)
        {
            if (activeDrawingPoints)
            {
                buttonDrawTrianleByPoints.Text = "Нарисовать фигуру по точкам";
                EnabledControls(true);
                CreateStartTriangles();
                DrawTriangles();
                activeDrawingPoints = false;
            }
            else
            {
                buttonDrawTrianleByPoints.Text = "Нарисовать";
                EnabledControls(false);
                g.Clear(Color.White);
                points.Clear();
                activeDrawingPoints = true;
            }
            pictureBoxFigure.Image = bitmap;
        }

        void EnabledControls(bool enabled)
        {
            buttonFigureFromFile.Enabled = enabled;
            buttonShowConcreteTriangle.Enabled = enabled;
            buttonDevideTriangles.Enabled = enabled;
            buttonSavePicture.Enabled = enabled;
            textBoxNumber.Enabled = enabled;
            buttonRefresh.Enabled = enabled;
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            DrawTriangles();
        }

        private void buttonSavePicture_Click(object sender, EventArgs e)
        {
            SaveFileDialog savedialog = new SaveFileDialog();
            savedialog.Title = "Сохранить картинку как...";
            savedialog.OverwritePrompt = true;
            savedialog.CheckPathExists = true;
            savedialog.Filter = "Image Files(*.JPG)|*.JPG|Image Files(*.BMP)|*.BMP|Image Files(*.GIF)|*.GIF|Image Files(*.PNG)|*.PNG|All files (*.*)|*.*";
            savedialog.ShowHelp = true;
            if (savedialog.ShowDialog() == DialogResult.OK) //если в диалоговом окне нажата кнопка "ОК"
            {
                bitmap.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }

        private void buttonChangeExternalColor_Click(object sender, EventArgs e)
        {
            ChangeColor(ref externalColor);
            DrawTriangles();
        }

        private void buttonChangeInternalColor_Click(object sender, EventArgs e)
        {
            ChangeColor(ref internalColor);
            DrawTriangles();
        }

        void ChangeColor(ref Color color)
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.AllowFullOpen = false;
            MyDialog.ShowHelp = true;

            if (MyDialog.ShowDialog() == DialogResult.OK)
                color = MyDialog.Color;
        }

        private void buttonOpenFormStatistics_Click(object sender, EventArgs e)
        {
            if (formStatistics.IsDisposed)
                formStatistics = new FormStatistics(points, lines, triangles);
            formStatistics.Show();
        }

        private void FormGround_FormClosing(object sender, FormClosingEventArgs e)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fileStream = new FileStream("Save.txt", FileMode.OpenOrCreate))
            {
                object[] colors = new object[2] { internalColor, externalColor };
                formatter.Serialize(fileStream, colors);
            }
        }

        void LoadSave()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fileStream = new FileStream("Save.txt", FileMode.OpenOrCreate))
            {
                if (fileStream.Length != 0)
                {
                    object[] colors = (object[])formatter.Deserialize(fileStream);
                    internalColor = (Color)colors[0];
                    externalColor = (Color)colors[1];
                }
            }
        }
    }
}
