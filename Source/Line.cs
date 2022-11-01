using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpGL;
using System.Drawing;

namespace _19120466
{
    class Line : Shape
    {
        public override bool isInsideBox(int x, int y)
        {
            if (Math.Abs(y - pStart.Y) <= 2.0 && Math.Abs(pEnd.Y - pStart.Y) <= 2.0)
                return (x >= pStart.X && x <= pEnd.X) || (x < pStart.X && x > pEnd.X);
            if (Math.Abs(x - pStart.X) <= 2.0 && Math.Abs(pEnd.X - pStart.X) <= 2.0)
                return (y >= pStart.Y && y <= pEnd.Y) || (y < pStart.Y && y > pEnd.Y);

            double a = (double)(x - pStart.X) / (y - pStart.Y), b = (double)(pEnd.X - pStart.X) / (pEnd.Y - pStart.Y);
            return (Math.Abs(a - b) < 0.5);
        }
        public override void drawControlBox(OpenGL gl)
        {
            gl.PointSize(5);
            gl.Color(0.5, 0.5, 0.5);
            gl.Begin(OpenGL.GL_POINTS);
            gl.Vertex(pStart.X, gl.RenderContextProvider.Height - pStart.Y);
            gl.Vertex(pEnd.X,gl.RenderContextProvider.Height - pEnd.Y);
            controlPoint[0].X = pStart.X;
            controlPoint[0].Y = pStart.Y;
            controlPoint[1].X = pEnd.X;
            controlPoint[1].Y = pEnd.Y;
            gl.End();
        }
        public override void Draw(OpenGL gl)
        {
            int x1 = pStart.X, y1 = pStart.Y;
            int x2 = pEnd.X, y2 = pEnd.Y;
            int dx = x2 - x1;
            int dy = y2 - y1;

            int stepX = 1, stepY = 1;
            if (dx < 0)
            {
                dx = -dx;
                stepX = -1;
            }

            if (dy < 0)
            {
                dy = -dy;
                stepY = -1;
            }
            gl.PointSize(lineWidth);
            gl.Color(colorLine.R / 255.0, colorLine.G / 255.0, colorLine.B / 255.0);
            gl.Begin(OpenGL.GL_POINTS);
            gl.Vertex(x1, gl.RenderContextProvider.Height - y1);
            if (dx == 0)
            {
                for (int i = 0; i < dy; i++)
                {
                    gl.Vertex(x1, gl.RenderContextProvider.Height - (y1 + i));
                }
            }
            else if (dx > dy)
            {
                int p = 2 * dy - dx;
                int x = x1, y = y1;
                while (x != x2)
                {
                    if (p >= 0)
                    {
                        y = y + stepY;
                        p = p + 2 * dy - 2 * dx;
                    }
                    else
                    {
                        p = p + 2 * dy;
                    }
                    gl.Vertex(x, gl.RenderContextProvider.Height - y);
                    x = x + stepX;
                }
            }
            else
            {
                int p = 2 * dx - dy;
                int x = x1, y = y1;
                while (y != y1)
                {
                    if (p >= 0)
                    {
                        x = x + stepX;
                        p = p + 2 * dx - 2 * dy;
                    }
                    else
                    {
                        p = p + 2 * dx;
                    }
                    gl.Vertex(x, gl.RenderContextProvider.Height - y);
                    y = y + stepY;
                }
            }
            gl.End();
        }
        public override int whichControlPointSelected(int x, int y)
        {
            for(int i = 0; i < 2; i++)
            {
                if (Math.Abs(x - controlPoint[i].X) < 5 && Math.Abs(y - controlPoint[i].Y) < 5)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
