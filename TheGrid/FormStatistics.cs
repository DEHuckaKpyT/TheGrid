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
            UpdateLabels();
        }

        public void UpdateLabels()
        {
            labelCountPoints.Text = points.Count.ToString();
            labelCountLines.Text = lines.Count.ToString();
            labelCountTriangles.Text = triangles.Count.ToString();
            labelCountInternalTriangles.Text = triangles.Count(triangle => !triangle.IsExternal).ToString();
            labelCountExternalTriangles.Text = triangles.Count(triangle => triangle.IsExternal).ToString();
        }
    }
}
