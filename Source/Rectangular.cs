using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpGL;
using System.Drawing;

namespace _19120466
{
    class Rectangular : Shape
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
            Point topLeft = new Point();
            Point topRight = new Point();
            Point bottomLeft = new Point();
            Point bottomRight = new Point();
            //pStart là topLeft, pEnd là bottomRight
            topLeft = pStart;
            bottomRight = pEnd;
            //Điều kiện (x,y) topLeft phải luôn bé hơn bottomRight
            //Nếu ngược lại cần hoán vị
            if (topLeft.X > bottomRight.X && topLeft.Y > bottomRight.Y)
            {
                Point temp = topLeft;
                topLeft = bottomRight;
                bottomRight = temp;
            }
            else if (topLeft.Y > bottomRight.Y)
            {
                int temp = topLeft.Y;
                topLeft.Y = bottomRight.Y;
                bottomRight.Y = temp;
            }
            //Từ topLeft, bottomRight suy ra 2 điểm còn lại
            //topRight
            topRight.X = bottomRight.X;
            topRight.Y = topLeft.Y;
            //bottomLeft
            bottomLeft.X = topLeft.X;
            bottomLeft.Y = bottomRight.Y;
            //Vẽ hình chữ nhật bằng cách vẽ 4 đoạn thẳng
            //từ tọa độ topLeft, topRight, bottomLeft, bottomRight
            gl.LineWidth(lineWidth);
            gl.Color(colorLine.R / 255.0, colorLine.G / 255.0, colorLine.B / 255.0);
            gl.Begin(OpenGL.GL_LINE_LOOP);
            gl.Vertex(topLeft.X, gl.RenderContextProvider.Height - topLeft.Y);
            gl.Vertex(topRight.X, gl.RenderContextProvider.Height - topRight.Y);
            gl.Vertex(bottomRight.X, gl.RenderContextProvider.Height - bottomRight.Y);
            gl.Vertex(bottomLeft.X, gl.RenderContextProvider.Height - bottomLeft.Y);
            gl.End();
        }
    }
}
