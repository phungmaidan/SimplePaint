namespace _19120466
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openglControl1 = new SharpGL.OpenGLControl();
            this.bt_BangMau = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.bt_Line = new System.Windows.Forms.Button();
            this.bt_Circle = new System.Windows.Forms.Button();
            this.Rectangular = new System.Windows.Forms.Button();
            this.Ellipse = new System.Windows.Forms.Button();
            this.EquilateralTriangle = new System.Windows.Forms.Button();
            this.Pentagon = new System.Windows.Forms.Button();
            this.Hexagon = new System.Windows.Forms.Button();
            this.increaseLineWidth = new System.Windows.Forms.Button();
            this.DecreaseLineWidth = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Filling_Color = new System.Windows.Forms.Button();
            this.colorDialog2 = new System.Windows.Forms.ColorDialog();
            this.count_time = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.openglControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // openglControl1
            // 
            this.openglControl1.DrawFPS = false;
            this.openglControl1.Location = new System.Drawing.Point(13, 97);
            this.openglControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.openglControl1.Name = "openglControl1";
            this.openglControl1.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.openglControl1.RenderContextType = SharpGL.RenderContextType.DIBSection;
            this.openglControl1.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            this.openglControl1.Size = new System.Drawing.Size(980, 450);
            this.openglControl1.TabIndex = 0;
            this.openglControl1.OpenGLInitialized += new System.EventHandler(this.openGLControl_OpenGLInitialized);
            this.openglControl1.OpenGLDraw += new SharpGL.RenderEventHandler(this.openglControl1_OpenGLDraw);
            this.openglControl1.Resized += new System.EventHandler(this.openGLControl_Resized);
            this.openglControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.form_SharpGLForm_MouseDown);
            this.openglControl1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.form_SharpGLForm_MouseUp);
            // 
            // bt_BangMau
            // 
            this.bt_BangMau.Location = new System.Drawing.Point(774, 58);
            this.bt_BangMau.Name = "bt_BangMau";
            this.bt_BangMau.Size = new System.Drawing.Size(97, 29);
            this.bt_BangMau.TabIndex = 1;
            this.bt_BangMau.Text = "Color";
            this.bt_BangMau.UseVisualStyleBackColor = true;
            this.bt_BangMau.Click += new System.EventHandler(this.bt_BangMau_Click);
            // 
            // bt_Line
            // 
            this.bt_Line.Location = new System.Drawing.Point(27, 12);
            this.bt_Line.Name = "bt_Line";
            this.bt_Line.Size = new System.Drawing.Size(105, 29);
            this.bt_Line.TabIndex = 2;
            this.bt_Line.Text = "Line";
            this.bt_Line.UseVisualStyleBackColor = true;
            this.bt_Line.Click += new System.EventHandler(this.bt_Line_Click);
            // 
            // bt_Circle
            // 
            this.bt_Circle.Location = new System.Drawing.Point(249, 12);
            this.bt_Circle.Name = "bt_Circle";
            this.bt_Circle.Size = new System.Drawing.Size(105, 29);
            this.bt_Circle.TabIndex = 3;
            this.bt_Circle.Text = "Circle";
            this.bt_Circle.UseVisualStyleBackColor = true;
            this.bt_Circle.Click += new System.EventHandler(this.bt_Circle_Click);
            // 
            // Rectangular
            // 
            this.Rectangular.Location = new System.Drawing.Point(138, 12);
            this.Rectangular.Name = "Rectangular";
            this.Rectangular.Size = new System.Drawing.Size(105, 29);
            this.Rectangular.TabIndex = 4;
            this.Rectangular.Text = "Rectangular";
            this.Rectangular.UseVisualStyleBackColor = true;
            this.Rectangular.Click += new System.EventHandler(this.bt_Rectangular_Click);
            // 
            // Ellipse
            // 
            this.Ellipse.Location = new System.Drawing.Point(138, 60);
            this.Ellipse.Name = "Ellipse";
            this.Ellipse.Size = new System.Drawing.Size(105, 29);
            this.Ellipse.TabIndex = 5;
            this.Ellipse.Text = "Ellipse";
            this.Ellipse.UseVisualStyleBackColor = true;
            this.Ellipse.Click += new System.EventHandler(this.bt_Ellipse_Click);
            // 
            // EquilateralTriangle
            // 
            this.EquilateralTriangle.Location = new System.Drawing.Point(360, 12);
            this.EquilateralTriangle.Name = "EquilateralTriangle";
            this.EquilateralTriangle.Size = new System.Drawing.Size(99, 77);
            this.EquilateralTriangle.TabIndex = 6;
            this.EquilateralTriangle.Text = "Equilateral Triangle";
            this.EquilateralTriangle.UseVisualStyleBackColor = true;
            this.EquilateralTriangle.Click += new System.EventHandler(this.bt_EquilateralTriangle_Click);
            // 
            // Pentagon
            // 
            this.Pentagon.Location = new System.Drawing.Point(27, 60);
            this.Pentagon.Name = "Pentagon";
            this.Pentagon.Size = new System.Drawing.Size(105, 29);
            this.Pentagon.TabIndex = 7;
            this.Pentagon.Text = "Pentagon";
            this.Pentagon.UseVisualStyleBackColor = true;
            this.Pentagon.Click += new System.EventHandler(this.bt_Pentagon_Click);
            // 
            // Hexagon
            // 
            this.Hexagon.Location = new System.Drawing.Point(249, 60);
            this.Hexagon.Name = "Hexagon";
            this.Hexagon.Size = new System.Drawing.Size(105, 29);
            this.Hexagon.TabIndex = 8;
            this.Hexagon.Text = "Hexagon";
            this.Hexagon.UseVisualStyleBackColor = true;
            this.Hexagon.Click += new System.EventHandler(this.bt_Hexagon_click);
            // 
            // increaseLineWidth
            // 
            this.increaseLineWidth.Location = new System.Drawing.Point(465, 12);
            this.increaseLineWidth.Name = "increaseLineWidth";
            this.increaseLineWidth.Size = new System.Drawing.Size(97, 77);
            this.increaseLineWidth.TabIndex = 9;
            this.increaseLineWidth.Text = "Increase Line Width";
            this.increaseLineWidth.UseVisualStyleBackColor = true;
            this.increaseLineWidth.Click += new System.EventHandler(this.bt_IncreaseLineWidth_Click);
            // 
            // DecreaseLineWidth
            // 
            this.DecreaseLineWidth.Location = new System.Drawing.Point(568, 12);
            this.DecreaseLineWidth.Name = "DecreaseLineWidth";
            this.DecreaseLineWidth.Size = new System.Drawing.Size(97, 77);
            this.DecreaseLineWidth.TabIndex = 10;
            this.DecreaseLineWidth.Text = "Decrease Line Width";
            this.DecreaseLineWidth.UseVisualStyleBackColor = true;
            this.DecreaseLineWidth.Click += new System.EventHandler(this.bt_DecreaseLineWidth_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(671, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 77);
            this.button1.TabIndex = 11;
            this.button1.Text = "Boundary Fill";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Filling_Color
            // 
            this.Filling_Color.Location = new System.Drawing.Point(774, 12);
            this.Filling_Color.Name = "Filling_Color";
            this.Filling_Color.Size = new System.Drawing.Size(97, 29);
            this.Filling_Color.TabIndex = 12;
            this.Filling_Color.Text = "Filling Color";
            this.Filling_Color.UseVisualStyleBackColor = true;
            this.Filling_Color.Click += new System.EventHandler(this.button2_Click);
            // 
            // count_time
            // 
            this.count_time.Location = new System.Drawing.Point(877, 58);
            this.count_time.Name = "count_time";
            this.count_time.ReadOnly = true;
            this.count_time.Size = new System.Drawing.Size(117, 27);
            this.count_time.TabIndex = 13;
            this.count_time.Text = "Draw Time";
            this.count_time.TextChanged += new System.EventHandler(this.count_time_TextChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(877, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(97, 29);
            this.button2.TabIndex = 14;
            this.button2.Text = "Select";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button_Select);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 561);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.count_time);
            this.Controls.Add(this.Filling_Color);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DecreaseLineWidth);
            this.Controls.Add(this.increaseLineWidth);
            this.Controls.Add(this.Hexagon);
            this.Controls.Add(this.Pentagon);
            this.Controls.Add(this.EquilateralTriangle);
            this.Controls.Add(this.Ellipse);
            this.Controls.Add(this.Rectangular);
            this.Controls.Add(this.bt_Circle);
            this.Controls.Add(this.bt_Line);
            this.Controls.Add(this.bt_BangMau);
            this.Controls.Add(this.openglControl1);
            this.Name = "Form1";
            this.Text = "19120466_Lab2";
            ((System.ComponentModel.ISupportInitialize)(this.openglControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SharpGL.OpenGLControl openglControl1;
        private System.Windows.Forms.Button bt_BangMau;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button bt_Line;
        private System.Windows.Forms.Button bt_Circle;
        private System.Windows.Forms.Button Rectangular;
        private System.Windows.Forms.Button Ellipse;
        private System.Windows.Forms.Button EquilateralTriangle;
        private System.Windows.Forms.Button Pentagon;
        private System.Windows.Forms.Button Hexagon;
        private System.Windows.Forms.Button increaseLineWidth;
        private System.Windows.Forms.Button DecreaseLineWidth;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Filling_Color;
        private System.Windows.Forms.ColorDialog colorDialog2;
        private System.Windows.Forms.TextBox count_time;
        private System.Windows.Forms.Button button2;
    }
}

