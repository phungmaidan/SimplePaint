using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpGL;
using System.Drawing;
namespace _19120466
{
    class Hexagon : Shape
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

            double[] x = new double[6];
            double[] y = new double[6];
            //Đặt các đỉnh lục giác lần lượt theo chiều kim đồng hồ là x1-x6
            //Tính tọa độ tâm lục giác đều
            double xCenter = (pStart.X + pEnd.X) / 2.0, yCenter = (pStart.Y + pEnd.Y) / 2.0;
            //Tính bán kính hình tròn ngoại tiếp lục giác đều
            double radius = Math.Abs(pEnd.Y - pStart.Y) / 2.0;
            //Tính tọa độ x3, x6
            x[2] = xCenter + radius;
            y[2] = yCenter;
            x[5] = xCenter - radius;
            y[5] = yCenter;
            //Tính khoảng cách từ tâm đến cạnh x1x2 và x4x5
            double distance = radius * Math.Sqrt(3) / 2.0;
            //Tính tọa độ x1, x2:
            x[0] = xCenter - radius / 2.0;
            y[0] = yCenter - distance;
            x[1] = xCenter + radius / 2.0;
            y[1] = yCenter - distance;
            //Tính tọa độ x4, x5:
            x[3] = xCenter + radius / 2.0;
            y[3] = yCenter + distance;
            x[4] = xCenter - radius / 2.0;
            y[4] = yCenter + distance;
            //Vẽ lục giác đều 
            gl.LineWidth(lineWidth);
            gl.Color(colorLine.R / 255.0, colorLine.G / 255.0, colorLine.B / 255.0);
            gl.Begin(OpenGL.GL_LINES);
            gl.Vertex(x[0], gl.RenderContextProvider.Height - y[0]);
            gl.Vertex(x[1], gl.RenderContextProvider.Height - y[1]);

            gl.Vertex(x[1], gl.RenderContextProvider.Height - y[1]);
            gl.Vertex(x[2], gl.RenderContextProvider.Height - y[2]);

            gl.Vertex(x[3], gl.RenderContextProvider.Height - y[3]);
            gl.Vertex(x[2], gl.RenderContextProvider.Height - y[2]);

            gl.Vertex(x[4], gl.RenderContextProvider.Height - y[4]);
            gl.Vertex(x[3], gl.RenderContextProvider.Height - y[3]);

            gl.Vertex(x[5], gl.RenderContextProvider.Height - y[5]);
            gl.Vertex(x[4], gl.RenderContextProvider.Height - y[4]);

            gl.Vertex(x[5], gl.RenderContextProvider.Height - y[5]);
            gl.Vertex(x[0], gl.RenderContextProvider.Height - y[0]);
            gl.End();
        }
    }
}
