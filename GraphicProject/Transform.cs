using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicProject
{
    class Transform
    {
        public static void transformTranslation(Shape shape)
        {
            int dxStart, dyStart,dxEnd,dyEnd;
            Point newPosition = shape.getTransformPoint();
            switch (shape.getTypeDraw())
            {
                case TypeDraw.Line:
                    Line line = (Line)shape;
                    dxStart = newPosition.X - line.getStartPoint().X;
                    dyStart = newPosition.Y - line.getStartPoint().Y;
                    dxEnd = newPosition.X - line.getEndPoint().X;
                    dyEnd = newPosition.Y - line.getEndPoint().Y;
                    line.setStartPoint(multiMatrix2D(dxStart, dyStart, new double[3] { line.getStartPoint().X, line.getStartPoint().Y, 1 }));
                    line.setEndPoint(multiMatrix2D(dxEnd, dyEnd, new double[3] { line.getEndPoint().Y, line.getEndPoint().Y, 1 }));
                    break;
                case TypeDraw.Circle:
                    Circle circle = (Circle)shape;
                    dxStart = newPosition.X - circle.getCenterPoint().X;
                    dyStart = newPosition.Y - circle.getCenterPoint().Y;
                    circle.setCenterPoint(multiMatrix2D(dxStart, dyStart, new double[3] { circle.getCenterPoint().X, circle.getCenterPoint().Y, 1 }));
                    circle.setEndPoint(multiMatrix2D(dxStart, dyStart, new double[3] { circle.getEndPoint().X, circle.getEndPoint().Y, 1 }));
                    break;
            }
            shape.setTransformFlag(false);
        }

        private static Point multiMatrix2D(double dx, double dy, double[] array)
        {
            double[,] matrix = new double[3, 3];
            matrix[0, 0] = 1; matrix[0, 1] = 0; matrix[0, 2] = 0;
            matrix[1, 0] = 0; matrix[1, 1] = 1; matrix[1, 2] = 0;
            matrix[2, 0] = dx; matrix[2, 1] = dy; matrix[2, 2] = 1;
            double[] temparr = new double[3];

            int count = 0;
            for (int i = 0; i < 3; i++)
            {
                temparr[i] = array[0] * matrix[0, count] + array[1] * matrix[1, count] + array[2] * matrix[2, count];
                count++;
            }

            Point pt = new Point(Convert.ToInt16(temparr[0]), Convert.ToInt16(temparr[1]));
            return pt;
        }
    }
}
