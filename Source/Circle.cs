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
    class Circle : Shape
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
            double xCenter = (pStart.X + pEnd.X) / 2.0, yCenter = (pStart.Y + pEnd.Y) / 2.0;
            double radius = Math.Abs(pEnd.Y - pStart.Y) / 2.0;
            double P = 5.0 / 4 - radius;
            double y = radius;
            int x = 0;
            //Vẽ đường tròn
            gl.PointSize(lineWidth);
            gl.Color(colorLine.R / 255.0, colorLine.G / 255.0, colorLine.B / 255.0);
            gl.Begin(OpenGL.GL_POINTS);
            gl.Vertex(xCenter + x, gl.RenderContextProvider.Height - (yCenter + y));
            gl.Vertex(xCenter + y, gl.RenderContextProvider.Height - (yCenter + x));
            gl.Vertex(xCenter + y, gl.RenderContextProvider.Height - (yCenter - x));
            gl.Vertex(xCenter + x, gl.RenderContextProvider.Height - (yCenter - y));
            gl.Vertex(xCenter - x, gl.RenderContextProvider.Height - (yCenter - y));
            gl.Vertex(xCenter - y, gl.RenderContextProvider.Height - (yCenter - x));
            gl.Vertex(xCenter - y, gl.RenderContextProvider.Height - (yCenter + x));
            gl.Vertex(xCenter - x, gl.RenderContextProvider.Height - (yCenter + y));
            while (x < y)
            {
                if (P < 0)
                {
                    P += 2 * x + 3;

                }
                else
                {
                    P += 2 * (x - y) + 5;
                    y--;
                }

                x++;
                gl.Vertex(xCenter + x, gl.RenderContextProvider.Height - (yCenter + y));
                gl.Vertex(xCenter + y, gl.RenderContextProvider.Height - (yCenter + x));
                gl.Vertex(xCenter + y, gl.RenderContextProvider.Height - (yCenter - x));
                gl.Vertex(xCenter + x, gl.RenderContextProvider.Height - (yCenter - y));
                gl.Vertex(xCenter - x, gl.RenderContextProvider.Height - (yCenter - y));
                gl.Vertex(xCenter - y, gl.RenderContextProvider.Height - (yCenter - x));
                gl.Vertex(xCenter - y, gl.RenderContextProvider.Height - (yCenter + x));
                gl.Vertex(xCenter - x, gl.RenderContextProvider.Height - (yCenter + y));
            }
            gl.End();
        }
    }
}
