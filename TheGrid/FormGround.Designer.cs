namespace TheGrid
{
    partial class FormGround
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBoxFigure = new System.Windows.Forms.PictureBox();
            this.buttonDevideTriangles = new System.Windows.Forms.Button();
            this.textBoxNumber = new System.Windows.Forms.TextBox();
            this.buttonShowConcreteTriangle = new System.Windows.Forms.Button();
            this.buttonFigureFromFile = new System.Windows.Forms.Button();
            this.buttonDrawTrianleByPoints = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.buttonSavePicture = new System.Windows.Forms.Button();
            this.buttonChangeExternalColor = new System.Windows.Forms.Button();
            this.buttonChangeInternalColor = new System.Windows.Forms.Button();
            this.buttonOpenFormStatistics = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFigure)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxFigure
            // 
            this.pictureBoxFigure.BackColor = System.Drawing.Color.White;
            this.pictureBoxFigure.Location = new System.Drawing.Point(-2, -1);
            this.pictureBoxFigure.Name = "pictureBoxFigure";
            this.pictureBoxFigure.Size = new System.Drawing.Size(825, 580);
            this.pictureBoxFigure.TabIndex = 1;
            this.pictureBoxFigure.TabStop = false;
            this.pictureBoxFigure.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxFigure_MouseClick);
            // 
            // buttonDevideTriangles
            // 
            this.buttonDevideTriangles.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDevideTriangles.Location = new System.Drawing.Point(829, 189);
            this.buttonDevideTriangles.Name = "buttonDevideTriangles";
            this.buttonDevideTriangles.Size = new System.Drawing.Size(180, 59);
            this.buttonDevideTriangles.TabIndex = 2;
            this.buttonDevideTriangles.Text = "Разделить треугольники";
            this.buttonDevideTriangles.UseVisualStyleBackColor = true;
            this.buttonDevideTriangles.Click += new System.EventHandler(this.buttonDevideTriangles_Click);
            // 
            // textBoxNumber
            // 
            this.textBoxNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxNumber.Location = new System.Drawing.Point(1065, 76);
            this.textBoxNumber.Name = "textBoxNumber";
            this.textBoxNumber.Size = new System.Drawing.Size(63, 29);
            this.textBoxNumber.TabIndex = 3;
            this.textBoxNumber.Text = "0";
            // 
            // buttonShowConcreteTriangle
            // 
            this.buttonShowConcreteTriangle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonShowConcreteTriangle.Location = new System.Drawing.Point(829, 65);
            this.buttonShowConcreteTriangle.Name = "buttonShowConcreteTriangle";
            this.buttonShowConcreteTriangle.Size = new System.Drawing.Size(230, 56);
            this.buttonShowConcreteTriangle.TabIndex = 4;
            this.buttonShowConcreteTriangle.Text = "Показать треугольник с номером";
            this.buttonShowConcreteTriangle.UseVisualStyleBackColor = true;
            this.buttonShowConcreteTriangle.Click += new System.EventHandler(this.buttonbuttonShowConcreteTriangle_Click);
            // 
            // buttonFigureFromFile
            // 
            this.buttonFigureFromFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonFigureFromFile.Location = new System.Drawing.Point(829, 12);
            this.buttonFigureFromFile.Name = "buttonFigureFromFile";
            this.buttonFigureFromFile.Size = new System.Drawing.Size(230, 47);
            this.buttonFigureFromFile.TabIndex = 5;
            this.buttonFigureFromFile.Text = "Взять фигуру из файла";
            this.buttonFigureFromFile.UseVisualStyleBackColor = true;
            this.buttonFigureFromFile.Click += new System.EventHandler(this.buttonFigureFromFile_Click);
            // 
            // buttonDrawTrianleByPoints
            // 
            this.buttonDrawTrianleByPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDrawTrianleByPoints.Location = new System.Drawing.Point(829, 127);
            this.buttonDrawTrianleByPoints.Name = "buttonDrawTrianleByPoints";
            this.buttonDrawTrianleByPoints.Size = new System.Drawing.Size(180, 56);
            this.buttonDrawTrianleByPoints.TabIndex = 6;
            this.buttonDrawTrianleByPoints.Text = "Нарисовать фигуру по точкам";
            this.buttonDrawTrianleByPoints.UseVisualStyleBackColor = true;
            this.buttonDrawTrianleByPoints.Click += new System.EventHandler(this.buttonDrawTrianleByPoints_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonRefresh.Location = new System.Drawing.Point(1141, 12);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(32, 217);
            this.buttonRefresh.TabIndex = 7;
            this.buttonRefresh.Text = "Обновить";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // buttonSavePicture
            // 
            this.buttonSavePicture.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSavePicture.Location = new System.Drawing.Point(829, 254);
            this.buttonSavePicture.Name = "buttonSavePicture";
            this.buttonSavePicture.Size = new System.Drawing.Size(180, 58);
            this.buttonSavePicture.TabIndex = 8;
            this.buttonSavePicture.Text = "Сохранить картинку";
            this.buttonSavePicture.UseVisualStyleBackColor = true;
            this.buttonSavePicture.Click += new System.EventHandler(this.buttonSavePicture_Click);
            // 
            // buttonChangeExternalColor
            // 
            this.buttonChangeExternalColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonChangeExternalColor.Location = new System.Drawing.Point(829, 318);
            this.buttonChangeExternalColor.Name = "buttonChangeExternalColor";
            this.buttonChangeExternalColor.Size = new System.Drawing.Size(154, 58);
            this.buttonChangeExternalColor.TabIndex = 9;
            this.buttonChangeExternalColor.Text = "Изменить цвет внешних";
            this.buttonChangeExternalColor.UseVisualStyleBackColor = true;
            this.buttonChangeExternalColor.Click += new System.EventHandler(this.buttonChangeExternalColor_Click);
            // 
            // buttonChangeInternalColor
            // 
            this.buttonChangeInternalColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonChangeInternalColor.Location = new System.Drawing.Point(989, 318);
            this.buttonChangeInternalColor.Name = "buttonChangeInternalColor";
            this.buttonChangeInternalColor.Size = new System.Drawing.Size(157, 58);
            this.buttonChangeInternalColor.TabIndex = 10;
            this.buttonChangeInternalColor.Text = "Изменить цвет внутренних";
            this.buttonChangeInternalColor.UseVisualStyleBackColor = true;
            this.buttonChangeInternalColor.Click += new System.EventHandler(this.buttonChangeInternalColor_Click);
            // 
            // buttonOpenFormStatistics
            // 
            this.buttonOpenFormStatistics.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonOpenFormStatistics.Location = new System.Drawing.Point(829, 383);
            this.buttonOpenFormStatistics.Name = "buttonOpenFormStatistics";
            this.buttonOpenFormStatistics.Size = new System.Drawing.Size(180, 58);
            this.buttonOpenFormStatistics.TabIndex = 11;
            this.buttonOpenFormStatistics.Text = "Открыть форму статистики";
            this.buttonOpenFormStatistics.UseVisualStyleBackColor = true;
            this.buttonOpenFormStatistics.Click += new System.EventHandler(this.buttonOpenFormStatistics_Click);
            // 
            // FormGround
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1185, 579);
            this.Controls.Add(this.buttonOpenFormStatistics);
            this.Controls.Add(this.buttonChangeInternalColor);
            this.Controls.Add(this.buttonChangeExternalColor);
            this.Controls.Add(this.buttonSavePicture);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.buttonDrawTrianleByPoints);
            this.Controls.Add(this.buttonFigureFromFile);
            this.Controls.Add(this.buttonShowConcreteTriangle);
            this.Controls.Add(this.textBoxNumber);
            this.Controls.Add(this.buttonDevideTriangles);
            this.Controls.Add(this.pictureBoxFigure);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1201, 617);
            this.MinimumSize = new System.Drawing.Size(1201, 617);
            this.Name = "FormGround";
            this.Text = "TheGrid";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormGround_FormClosing);
            this.Load += new System.EventHandler(this.FormGround_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFigure)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBoxFigure;
        private System.Windows.Forms.Button buttonDevideTriangles;
        private System.Windows.Forms.TextBox textBoxNumber;
        private System.Windows.Forms.Button buttonShowConcreteTriangle;
        private System.Windows.Forms.Button buttonFigureFromFile;
        private System.Windows.Forms.Button buttonDrawTrianleByPoints;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Button buttonSavePicture;
        private System.Windows.Forms.Button buttonChangeExternalColor;
        private System.Windows.Forms.Button buttonChangeInternalColor;
        private System.Windows.Forms.Button buttonOpenFormStatistics;
    }
}

