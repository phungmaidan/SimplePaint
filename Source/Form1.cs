using SharpGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
namespace _19120466
{
    public partial class Form1 : Form
    {
        OpenGL gl;
        //Biến kiểm tra hình vẽ
        bool check;
        //Biến lưu màu người dùng chọn
        Color userColor;

        //Đo thời gian
        Stopwatch drawTime;
        bool checkDrawTime;

        //Biến lưu màu tô
        Color fillColor;

        //Biến lưu hình dạng người dùng cần vẽ
        short shShape;

        //Biến lưu độ dày nét vẽ
        short lineWidth = 1;

        //2 điểm lưu tọa dộ vị trị chuột bấm - thả
        Point pStart;
        Point pEnd;

        //Bật chế độ select
        bool select;
        Point pSelect;
        //Danh sách hình vẽ
        List<Shape> ArrShape;
        Shape shape;
        public Form1()
        {
            InitializeComponent();
            ArrShape = new List<Shape>();
            check = false;
            drawTime = new Stopwatch();
            checkDrawTime = false;
        }
  


        private void openGLControl_OpenGLInitialized(object sender, EventArgs e)
        {
            // Get the OpenGL object.
            gl = openglControl1.OpenGL;
            // Set the clear color.
            gl.ClearColor(1f, 1f, 1f, 0);
            // Set the projection matrix.
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            // Load the identity.
            gl.LoadIdentity();
        }
        private void openGLControl_Resized(object sender, EventArgs e)
        {
            //  Get the OpenGL object.
            OpenGL gl = openglControl1.OpenGL;
            //  Create a perspective transformation.
            gl.Viewport(0, 0, openglControl1.Width, openglControl1.Height);

            //  Set the projection matrix.
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            //  Load the identity.
            gl.LoadIdentity();
            gl.Ortho2D(0, openglControl1.Width, 0, openglControl1.Height);
        }
        private void openglControl1_OpenGLDraw(object sender, RenderEventArgs args)
        {
            OpenGL gl = openglControl1.OpenGL;
            //  Clear the color and depth buffer.
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            // vẽ các hình trong mảng hình vẽ
            for (int i = 0; i < ArrShape.Count(); i++)
            {
                if(checkDrawTime)
                {
                    drawTime.Start();
                }
                ArrShape[i].Draw(gl);
                if(checkDrawTime)
                {
                    count_time.Text = drawTime.Elapsed.ToString();
                    drawTime.Reset();
                    checkDrawTime = false;
                }
            }
            if(select == true)
            {
                for (int i = 0; i < ArrShape.Count(); i++)
                {
                   Point selectPoint = pSelect;
                   if(ArrShape[i].isInsideBox(selectPoint.X, selectPoint.Y) == true)
                   {
                        ArrShape[i].drawControlBox(gl);
                        if(ArrShape[i].whichControlPointSelected(pSelect.X,pSelect.Y) == 0)
                        {
                            ArrShape[i].startPoint = pEnd;
                        }
                        break;
                   }
                }
            }
            gl.Flush();
        }

        private void bt_BangMau_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                userColor = colorDialog1.Color;
            }
        }

        private void form_SharpGLForm_MouseDown(object sender, MouseEventArgs e)
        {
            pStart = e.Location;
            if (select == false)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    switch (shShape)
                    {
                        case 0:
                            {
                                shape = new Line();
                                check = true;
                                break;
                            }
                        case 1:
                            {
                                shape = new Circle();
                                check = true;
                                break;
                            }
                        case 2:
                            {
                                shape = new Rectangular();
                                check = true;
                                break;
                            }
                        case 3:
                            {
                                shape = new Ellipse();
                                check = true;
                                break;
                            }
                        case 4:
                            {
                                shape = new EquilateralTriangle();
                                check = true;
                                break;
                            }
                        case 5:
                            {
                                shape = new Pentagon();
                                check = true;
                                break;
                            }
                        case 6:
                            {
                                shape = new Hexagon();
                                check = true;
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }
                    if (check)
                    {
                        shape.endPoint = e.Location;
                        shape.startPoint = e.Location;
                        shape.LineWidth = lineWidth;
                        shape.ColorLine = userColor;
                        ArrShape.Add(shape);
                        check = false;
                    }
                }
            }
            else 
            {
                pSelect = e.Location;
            }
        }
        private void form_SharpGLForm_MouseUp(object sender, MouseEventArgs e)
        {
            if(select == false)
            {
                if (shShape > -1 && shShape < 7)
                {
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        shape.endPoint = e.Location;
                        checkDrawTime = true;
                    }
                }
            }
        }

        private void bt_Circle_Click(object sender, EventArgs e)
        {
            shShape = 1;
        }

        private void bt_Line_Click(object sender, EventArgs e)
        {
            shShape = 0;
        }

        private void bt_Rectangular_Click(object sender, EventArgs e)
        {
            shShape = 2;
        }

        private void bt_Ellipse_Click(object sender, EventArgs e)
        {
            shShape = 3;
        }

        private void bt_EquilateralTriangle_Click(object sender, EventArgs e)
        {
            shShape = 4;
        }

        private void bt_Pentagon_Click(object sender, EventArgs e)
        {
            shShape = 5;
        }

        private void bt_Hexagon_click(object sender, EventArgs e)
        {
            shShape = 6;
        }

        private void bt_IncreaseLineWidth_Click(object sender, EventArgs e)
        {
            if (lineWidth < 20)
                lineWidth++;
            else MessageBox.Show("Không thể tiếp tục tăng độ dày nét vẽ!\n");
        }

        private void bt_DecreaseLineWidth_Click(object sender, EventArgs e)
        {
            if (lineWidth > 2)
                lineWidth--;
            else MessageBox.Show("Không thể tiếp tục giảm độ dày nét vẽ!\n");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (colorDialog2.ShowDialog() == DialogResult.OK)
            {
                fillColor = colorDialog2.Color;
            }
        }
        void putPixel(int x, int y, Color color)
        {
            byte[] pixel = new byte[3];
            pixel[0] = color.R;
            pixel[1] = color.G;
            pixel[2] = color.B;

            gl.RasterPos(x, y);
            gl.DrawPixels(openglControl1.Width, openglControl1.Height, OpenGL.GL_RGB, pixel);
            gl.Flush();
        }
        Color getPixel(int x, int y)
        {
            byte[] pixelData;
            gl.ReadPixels(x, y, openglControl1.Width, openglControl1.Height, 
                OpenGL.GL_RGB, OpenGL.GL_BYTE, pixelData = new byte[3]);
            Color color = Color.FromArgb(pixelData[0], pixelData[1], pixelData[2]);
            return color;
        }
        bool isSameColor(Color a, Color b)
        {
            if (a.R == b.R && a.G == b.G && a.B == b.B)
                return true;
            return false;
        }
        void BoundaryFill(int x, int y, Color FillColor, Color LineColor)
        {
            Color currentColor;
            currentColor = getPixel(x, y);

            if(!isSameColor(currentColor, LineColor) && !isSameColor(currentColor, FillColor))
            {
                putPixel(x, y, FillColor);
                BoundaryFill(x - 1, y, FillColor, LineColor);
                BoundaryFill(x, y + 1, FillColor, LineColor);
                BoundaryFill(x + 1, y, FillColor, LineColor);
                BoundaryFill(x, y - 1, FillColor, LineColor);
            }
        }


        private void count_time_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_Select(object sender, EventArgs e)
        {
            if (select == false) select = true;
            else select = false;
        }
    }
}
