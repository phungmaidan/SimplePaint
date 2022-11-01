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
    class Affine
    {
        private float[] matrix = {1, 0, 0,
                                  0, 1, 0,
                                  0, 0, 1};
        public void nhanMatrix(float[] matrix_temp)
        {
            float[] temp = new float[9];
            temp[0] = matrix[0] * matrix_temp[0] + matrix[1] * matrix_temp[3] + matrix[2] * matrix_temp[6];
            temp[1] = matrix[0] * matrix_temp[1] + matrix[1] * matrix_temp[4] + matrix[2] * matrix_temp[7];
            temp[2] = matrix[0] * matrix_temp[2] + matrix[1] * matrix_temp[5] + matrix[2] * matrix_temp[8];

            temp[3] = matrix[3] * matrix_temp[0] + matrix[4] * matrix_temp[3] + matrix[5] * matrix_temp[6];
            temp[4] = matrix[3] * matrix_temp[1] + matrix[4] * matrix_temp[4] + matrix[5] * matrix_temp[7];
            temp[5] = matrix[3] * matrix_temp[2] + matrix[4] * matrix_temp[5] + matrix[5] * matrix_temp[8];

            temp[6] = matrix[6] * matrix_temp[0] + matrix[7] * matrix_temp[3] + matrix[8] * matrix_temp[6];
            temp[7] = matrix[6] * matrix_temp[1] + matrix[7] * matrix_temp[4] + matrix[8] * matrix_temp[7];
            temp[8] = matrix[6] * matrix_temp[2] + matrix[7] * matrix_temp[5] + matrix[8] * matrix_temp[8];
            matrix = temp;
        }
        //Ma trận tịnh tiến
        public void tinhTienMatrix(float dx, float dy)
        {
            ///Ma trận tịnh tiến có dạng:  1    0	dx
            //                             0	1	dy
            //                             0	0   1
            float[] tinhTienMatrix = {1, 0, dx,
                                      0, 1, dy,
                                      0, 0, 1};
            //Nhân ma trận affine với ma trận tịnh tiến:
            nhanMatrix(tinhTienMatrix);
        }
        //Ma trận co dãn
        public void Scale(float sx, float sy)
        {
            //Ma trận co dãn có dạng:      sx   0	0
            //                             0	sy	0
            //                             0	0   1
            float[] scaleMatrix = {sx, 0, 0,
                                   0, sy, 0,
                                   0, 0, 1};
            //Nhân ma trận affine với ma trận scale:
            nhanMatrix(scaleMatrix);
        }
        // Ma trận quay
        public void Rotate(float angle)
        {
            //Ma trận quay có dạng: cos(angle)     -sin(angle)	0
            //                      sin(angle)      cos(angle)	0
            //                          0	            0       1
            float[] rotateMatrix = {(float)Math.Cos(angle), -(float)Math.Sin(angle),    0,
                                    (float)Math.Sin(angle), (float)Math.Cos(angle),     0,
                                                0,                  0,                  1};
            //Nhân ma trận affine với ma trận quay:
            nhanMatrix(rotateMatrix);
        }
        // Biến đổi điểm cần thực hiện các thao tác trên
        public Point TransformPoint(Point point)
        {
            //Nhân điểm cần tính với ma trận affine đã biến đổi bên trên
            //Với điểm cần tính là xem như là một ma trận 3 dòng 1 cột
            //Ví dụ: x
            //       y
            //       0
            Point temp = new();
            temp.X = (int)Math.Round(matrix[0] * point.X + matrix[1] * point.Y + matrix[2]);
            temp.X = (int)Math.Round(matrix[3] * point.X + matrix[4] * point.Y + matrix[5]);
            return temp;
        }
    }
}
