using System;
using SharpGL;
using System.Drawing;

namespace _19120466
{
    class Shape
    {
        protected Point pStart, pEnd;
        protected short lineWidth;
        protected Color colorLine;
        protected Point []controlPoint = new Point [7];
        public Shape()
        {
            pStart.X = 0;
            pStart.Y = 0;
            pEnd.X = 0;
            pEnd.Y = 0;
        }
        public Color ColorLine
        {
            get { return colorLine; }
            set { colorLine = value; }
        }
        public short LineWidth
        {
            get { return lineWidth; }
            set { lineWidth = value; }
        }
        public Point startPoint
        {
            get { return pStart; }
            set { pStart = value; }
        }
        public Point endPoint
        {
            get { return pEnd; }
            set { pEnd = value; }
        }
        //Xác định hình có được chọn không
        public virtual bool isInsideBox(int x, int y) { return false; }
        //Vẽ các điểm điều khiển
        public virtual void drawControlBox(OpenGL gl) { }
        public virtual void Draw(OpenGL gl) { }
        //Xác định điểm điều khiển nào đang được chọn
        public virtual int whichControlPointSelected(int x, int y) { return -1; }
    }
}
