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
namespace _19120466
{
    class Ellipse : Shape
    {
        public override bool isInsideBox(int x, int y)
        {
            int cx = (pStart.X + pEnd.X) / 2, cy = (pStart.Y + pEnd.Y) / 2;
            x -= cx;
            y -= cy;
            return !(x < pStart.X - cx || x > pEnd.X - cx || y < pStart.Y - cy || y > pEnd.Y - cy);
        }
        public override void drawControlBox(OpenGL gl)
        {
            gl.PointSize(5);
            gl.Color(0.5, 0.5, 0.5);
            gl.Begin(OpenGL.GL_POINTS);
            gl.Vertex(pStart.X, gl.RenderContextProvider.Height - pStart.Y);
            gl.Vertex(pEnd.X, gl.RenderContextProvider.Height - pEnd.Y);
            gl.Vertex(((int)(pStart.X + pEnd.X) / 2), gl.RenderContextProvider.Height - pStart.Y);
            gl.Vertex(pEnd.X, gl.RenderContextProvider.Height - pStart.Y);
            gl.Vertex(pStart.X, gl.RenderContextProvider.Height - pEnd.Y);
            gl.Vertex(((int)(pStart.X + pEnd.X) / 2), gl.RenderContextProvider.Height - pEnd.Y);
            gl.Color(0.9, 0.9, 0);
            gl.Vertex(((int)(pStart.X + pEnd.X) / 2), gl.RenderContextProvider.Height - (pStart.Y - 40));
            gl.End();
        }
        public override void Draw(OpenGL gl)
        {
            //Từ 2 điểm thuộc đường chéo suy ra:
            //Tính chiều dài bán trục lớn, bán trục nhỏ
            int rx = Math.Abs(Math.Abs(pEnd.X) - Math.Abs(pStart.X)) / 2;
            int ry = Math.Abs(Math.Abs(pEnd.Y) - Math.Abs(pStart.Y)) / 2;
            //Tọa độ tâm hình elipse
            double xCenter = (pStart.X + pEnd.X) / 2.0;
            double yCenter = (pStart.Y + pEnd.Y) / 2.0;
            //Vẽ ellipse sử dụng thuật toán MidPoint
            gl.PointSize(lineWidth);
            gl.Color(colorLine.R / 255.0, colorLine.G / 255.0, colorLine.B / 255.0);
            gl.Begin(OpenGL.GL_POINTS);
            int x = 0;
            int y = ry;
            double x0 = rx * rx / Math.Sqrt(rx * rx + ry * ry);
            double P = rx * rx * (1 - 2 * ry) + ry * ry;
            while (x <= x0)
            {
                if (P < 0)
                    P += (2 * ry * ry) * (2 * x + 3);

                else
                {

                    P += (2 * ry * ry) * (2 * x + 3) + 4 * rx * rx * (1 - y);
                    y--;
                }
                x++;
                gl.Vertex(xCenter + x, gl.RenderContextProvider.Height - (yCenter + y));
                gl.Vertex(xCenter + x, gl.RenderContextProvider.Height - (yCenter - y));
                gl.Vertex(xCenter - x, gl.RenderContextProvider.Height - (yCenter - y));
                gl.Vertex(xCenter - x, gl.RenderContextProvider.Height - (yCenter + y));
            }

            x = rx;
            y = 0;

            P = ry * ry * (1 - 2 * rx) + rx * rx;
            gl.Vertex(xCenter + x, gl.RenderContextProvider.Height - (yCenter + y));
            gl.Vertex(xCenter + x, gl.RenderContextProvider.Height - (yCenter - y));
            gl.Vertex(xCenter - x, gl.RenderContextProvider.Height - (yCenter - y));
            gl.Vertex(xCenter - x, gl.RenderContextProvider.Height - (yCenter + y));
            while (x > x0)
            {
                if (P < 0)
                    P += (2 * rx * rx) * (2 * y + 3);
                else
                {
                    P += (2 * rx * rx) * (2 * y + 3) + 4 * ry * ry * (1 - x);

                    x--;
                }
                y++;
                gl.Vertex(xCenter + x, gl.RenderContextProvider.Height - (yCenter + y));
                gl.Vertex(xCenter + x, gl.RenderContextProvider.Height - (yCenter - y));
                gl.Vertex(xCenter - x, gl.RenderContextProvider.Height - (yCenter - y));
                gl.Vertex(xCenter - x, gl.RenderContextProvider.Height - (yCenter + y));
            }
            gl.End();
        }
    }
}
