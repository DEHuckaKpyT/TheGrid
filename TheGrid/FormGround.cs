using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
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
        public FormGround()
        {
            InitializeComponent();
        }

        void ReadFigures(string path)
        {
            using (StreamReader reader = new StreamReader(path))
                while (!reader.EndOfStream)
                {
                    string[] pairXY = reader.ReadLine().Split(' ');
                    points.Add(new Point(int.Parse(pairXY[0]), int.Parse(pairXY[1])));
                }
        }

        private void FormGround_Load(object sender, EventArgs e)
        {
            points = new List<Point>();
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bitmap);
            pictureBox1.Image = bitmap;
        }

        void CreateStartTriangles()
        {
            if (points.Count < 3)
                return;
            lines = new List<Line>();
            triangles = new List<Triangle>();
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
                Triangle currentTriangle = new Triangle(previousLine, externalLine, internalLine);
                triangles.Add(currentTriangle);

                previousLine = internalLine;
                previousPoint = currentPoint;
            }
            internalLine.IsExternal = true;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (activeDrawingPoints)
            {
                points.Add(new Point(e.X, e.Y));
                g.FillEllipse(new SolidBrush(Color.Black), e.X - 3, e.Y - 3, 6, 6);
            }
            pictureBox1.Image = bitmap;
        }

        private void buttonDevideTriangles_Click(object sender, EventArgs e)
        {
            if (triangles == null) return;

            List<Triangle> forRemove = new List<Triangle>();
            List<Triangle> newTriangles = new List<Triangle>();

            foreach (Triangle triangle in triangles)
            {
                forRemove.Add(triangle.DivideTriangle(newTriangles, lines, points));
            }

            triangles = new List<Triangle>(newTriangles);

            g.Clear(Color.White);
            foreach (Triangle triange in triangles)
            {
                triange.DrawTriangle(g, Color.Black);
                if (triange.IsExternal)
                    triange.FillTriangle(g, Color.Red);
            }
            pictureBox1.Image = bitmap;
        }

        private void buttonbuttonShowConcreteTriangle_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            int number = int.Parse(textBoxNumber.Text);
            if (number >= 0 && number < triangles.Count)
            {
                Triangle triangle = triangles[int.Parse(textBoxNumber.Text)];
                if (triangle.IsExternal)
                    triangle.FillTriangle(g, Color.Red);
                else
                    triangle.DrawTriangle(g, Color.Black);
            }
            else
                DrawTriangles();
            pictureBox1.Image = bitmap;
        }

        private void buttonFigureFromFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files(*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            points.Clear();
            ReadFigures(openFileDialog.FileName);
            CreateStartTriangles();
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
                    triange.FillTriangle(g, Color.Red);
            }
            pictureBox1.Image = bitmap;
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
            pictureBox1.Image = bitmap;
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
    }
}
