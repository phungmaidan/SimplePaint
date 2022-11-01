using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpGL;
using System.Drawing;
namespace _19120466
{
    class Pentagon : Shape
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
            if(pStart.Y > pEnd.Y && pStart.X > pEnd.X)
            {
                Point temp = pStart;
                pStart = pEnd;
                pEnd = temp;
            }
            else if(pStart.Y > pEnd.Y)
            {
                int temp = pStart.Y;
                pStart.Y = pEnd.Y;
                pEnd.Y = temp;
            }
            double[] x = new double[5];
            double[] y = new double[5];
            //Đặt các đỉnh ngũ giác lần lượt theo chiều kim đồng hồ là x1-x5
            //Tính tọa độ tâm ngũ giác đều
            double xCenter = (pStart.X + pEnd.X) / 2.0, yCenter = (pEnd.Y + pStart.Y) / 2.0;
            //Tính bán kính hình tròn ngoại tiếp ngũ giác đều
            double radius = Math.Abs(pEnd.Y - pStart.Y) / 2.0;
            //Tính tọa độ đỉnh x2 của ngũ giác đều
            x[1] = (pStart.X + pEnd.X) / 2.0;
            y[1] = pStart.Y;
            //Tính bán kính hình tròn nội tiếp ngũ giác đều
            double radius_small = radius * Math.Cos(36 * 3.14 / 180);
            //Từ bán kính đường tròn nội tiếp và tâm đường tròn suy ra trung điểm cạnh đáy ngũ giác
            double xMid = xCenter, yMid = yCenter + radius_small;
            //Tính cạnh ngũ giác đều
            double edge = Math.Sqrt(radius * radius - radius_small * radius_small) * 2;
            //Từ trung điểm cạnh đáy suy ra được 2 điểm x4, x5
            x[3] = xMid + edge / 2.0;
            y[3] = yMid;
            x[4] = xMid - edge / 2.0;
            y[4] = yMid;
            //Tính điểm x1, x3
            double edge_temp = edge * Math.Cos(54 * 3.14 / 180);
            double edge_temp2 = radius - edge_temp;
            double edge_temp3 = edge * Math.Sin(54 * 3.14 / 180);
            x[0] = xCenter - edge_temp3;
            y[0] = yCenter - edge_temp2;
            x[2] = xCenter + edge_temp3;
            y[2] = yCenter - edge_temp2;
            //Vẽ ngũ giác đều 
            gl.LineWidth(lineWidth);
            gl.Color(colorLine.R / 255.0, colorLine.G / 255.0, colorLine.B / 255.0);
            gl.Begin(OpenGL.GL_LINES);
            gl.Vertex(x[0], gl.RenderContextProvider.Height - y[0]);
            gl.Vertex(x[1], gl.RenderContextProvider.Height - y[1]);

            gl.Vertex(x[1], gl.RenderContextProvider.Height - y[1]);
            gl.Vertex(x[2], gl.RenderContextProvider.Height - y[2]);

            gl.Vertex(x[2], gl.RenderContextProvider.Height - y[2]);
            gl.Vertex(x[3], gl.RenderContextProvider.Height - y[3]);

            gl.Vertex(x[4], gl.RenderContextProvider.Height - y[4]);
            gl.Vertex(x[3], gl.RenderContextProvider.Height - y[3]);

            gl.Vertex(x[0], gl.RenderContextProvider.Height - y[0]);
            gl.Vertex(x[4], gl.RenderContextProvider.Height - y[4]);
            gl.End();
        }
    }
}
