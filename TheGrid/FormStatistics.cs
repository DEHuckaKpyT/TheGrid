using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheGrid
{
    public partial class FormStatistics : Form
    {
        List<Point> points;
        List<Line> lines;
        List<Triangle> triangles;
        public FormStatistics()
        {
            InitializeComponent();
        }
        public FormStatistics(List<Point> points, List<Line> lines, List<Triangle> triangles)
        {
            InitializeComponent();
            this.points = points;
            this.lines = lines;
            this.triangles = triangles;
        }

        private void FormStatistics_Load(object sender, EventArgs e)
        {
            UpdateOutput();
        }

        public void UpdateOutput()
        {
            labelCountPoints.Text = "Количество точек = " + points.Count;
            labelCountLines.Text = "Количество линий = " + lines.Count;
            labelCountTriangles.Text = "Количество треугольников = " + triangles.Count;
            labelCountInternalTriangles.Text = "Количество внутр треугольников = " + triangles.Count(x => !x.IsExternal);
            labelCountExternalTriangles.Text = "Количество внеш треугольников = " + triangles.Count(x => x.IsExternal);
            listBoxAllPoints.Items.Clear();
            int i = 0;
            foreach (Point point in points)
            {
                listBoxAllPoints.Items.Add($"{i, 3}.X = {point.X}, Y = {point.Y}");
                i++;
            }
        }

        private void FormStatistics_Resize(object sender, EventArgs e)
        {
            listBoxAllPoints.Width = this.ClientSize.Width - 24;
            listBoxAllPoints.Height = ClientSize.Height - 132;
        }
    }
}
