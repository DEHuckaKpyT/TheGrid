
namespace TheGrid
{
    partial class FormStatistics
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelCountPoints = new System.Windows.Forms.Label();
            this.labelCountLines = new System.Windows.Forms.Label();
            this.labelCountTriangles = new System.Windows.Forms.Label();
            this.labelCountInternalTriangles = new System.Windows.Forms.Label();
            this.labelCountExternalTriangles = new System.Windows.Forms.Label();
            this.listBoxAllPoints = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // labelCountPoints
            // 
            this.labelCountPoints.AutoSize = true;
            this.labelCountPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCountPoints.Location = new System.Drawing.Point(11, 9);
            this.labelCountPoints.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCountPoints.Name = "labelCountPoints";
            this.labelCountPoints.Size = new System.Drawing.Size(60, 24);
            this.labelCountPoints.TabIndex = 0;
            this.labelCountPoints.Text = "label1";
            // 
            // labelCountLines
            // 
            this.labelCountLines.AutoSize = true;
            this.labelCountLines.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCountLines.Location = new System.Drawing.Point(11, 33);
            this.labelCountLines.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCountLines.Name = "labelCountLines";
            this.labelCountLines.Size = new System.Drawing.Size(60, 24);
            this.labelCountLines.TabIndex = 1;
            this.labelCountLines.Text = "label2";
            // 
            // labelCountTriangles
            // 
            this.labelCountTriangles.AutoSize = true;
            this.labelCountTriangles.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCountTriangles.Location = new System.Drawing.Point(11, 57);
            this.labelCountTriangles.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCountTriangles.Name = "labelCountTriangles";
            this.labelCountTriangles.Size = new System.Drawing.Size(60, 24);
            this.labelCountTriangles.TabIndex = 2;
            this.labelCountTriangles.Text = "label3";
            // 
            // labelCountInternalTriangles
            // 
            this.labelCountInternalTriangles.AutoSize = true;
            this.labelCountInternalTriangles.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCountInternalTriangles.Location = new System.Drawing.Point(11, 81);
            this.labelCountInternalTriangles.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCountInternalTriangles.Name = "labelCountInternalTriangles";
            this.labelCountInternalTriangles.Size = new System.Drawing.Size(60, 24);
            this.labelCountInternalTriangles.TabIndex = 3;
            this.labelCountInternalTriangles.Text = "label4";
            // 
            // labelCountExternalTriangles
            // 
            this.labelCountExternalTriangles.AutoSize = true;
            this.labelCountExternalTriangles.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCountExternalTriangles.Location = new System.Drawing.Point(11, 105);
            this.labelCountExternalTriangles.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCountExternalTriangles.Name = "labelCountExternalTriangles";
            this.labelCountExternalTriangles.Size = new System.Drawing.Size(60, 24);
            this.labelCountExternalTriangles.TabIndex = 4;
            this.labelCountExternalTriangles.Text = "label5";
            // 
            // listBoxAllPoints
            // 
            this.listBoxAllPoints.Font = new System.Drawing.Font("Consolas", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBoxAllPoints.FormattingEnabled = true;
            this.listBoxAllPoints.ItemHeight = 22;
            this.listBoxAllPoints.Location = new System.Drawing.Point(12, 132);
            this.listBoxAllPoints.Name = "listBoxAllPoints";
            this.listBoxAllPoints.Size = new System.Drawing.Size(395, 312);
            this.listBoxAllPoints.TabIndex = 5;
            // 
            // FormStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 580);
            this.Controls.Add(this.listBoxAllPoints);
            this.Controls.Add(this.labelCountExternalTriangles);
            this.Controls.Add(this.labelCountInternalTriangles);
            this.Controls.Add(this.labelCountTriangles);
            this.Controls.Add(this.labelCountLines);
            this.Controls.Add(this.labelCountPoints);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormStatistics";
            this.Text = "FormStatistics";
            this.Load += new System.EventHandler(this.FormStatistics_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCountPoints;
        private System.Windows.Forms.Label labelCountLines;
        private System.Windows.Forms.Label labelCountTriangles;
        private System.Windows.Forms.Label labelCountInternalTriangles;
        private System.Windows.Forms.Label labelCountExternalTriangles;
        private System.Windows.Forms.ListBox listBoxAllPoints;
    }
}