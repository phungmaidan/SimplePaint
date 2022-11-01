using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpGL;
using System.Drawing;

namespace _19120466
{
    class EquilateralTriangle:Shape
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
            double[] x = new double[3];
            double[] y = new double[3];
            //Nhập tọa độ tam giác đều từ 2 điểm đầu mút của 1 đường chéo
            //Tính tọa độ trung điểm cạnh đáy tam giác đều
            double xMid = (pStart.X + pEnd.X) / 2.0, yMid = pEnd.Y;
            //Tính độ dài đường trung tuyến tam giác đều
            double temp = Math.Abs(pEnd.Y - pStart.Y);
            //Tính cạnh tam giác đều
            double edge = (2.0 / Math.Sqrt(3)) * temp;
            //Từ cạnh và trung điểm cạnh đáy ta suy ra được tọa độ các điểm thuộc tam giác
            x[0] = xMid - (edge / 2.0);
            y[0] = pEnd.Y;
            x[1] = xMid + (edge / 2.0);
            y[1] = pEnd.Y;
            x[2] = xMid;
            y[2] = yMid - temp;
            //Vẽ tam giác đều 
            gl.LineWidth(lineWidth);
            gl.Color(colorLine.R / 255.0, colorLine.G / 255.0, colorLine.B / 255.0);
            gl.Begin(OpenGL.GL_LINES);

            gl.Vertex(x[0], gl.RenderContextProvider.Height - y[0]);
            gl.Vertex(x[1], gl.RenderContextProvider.Height - y[1]);

            gl.Vertex(x[0], gl.RenderContextProvider.Height - y[0]);
            gl.Vertex(x[2], gl.RenderContextProvider.Height - y[2]);

            gl.Vertex(x[1], gl.RenderContextProvider.Height - y[1]);
            gl.Vertex(x[2], gl.RenderContextProvider.Height - y[2]);

            gl.End();
        }
    }
}
