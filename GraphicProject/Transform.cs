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
            int dx, dy;
            Point newPosition = shape.getTransformPoint();
            switch (shape.getTypeDraw())
            {
                case TypeDraw.Line:
                    Line line = (Line)shape;
                    dx = newPosition.X - line.getStartPoint().X;
                    dy = newPosition.Y - line.getStartPoint().Y;
                    line.setStartPoint(multiMatrix2D(TypeTransform.Translation,dx, dy, new double[3] { line.getStartPoint().X, line.getStartPoint().Y, 1 }));
                    line.setEndPoint(multiMatrix2D(TypeTransform.Translation, dx, dy, new double[3] { line.getEndPoint().X, line.getEndPoint().Y, 1 }));
                    break;
                case TypeDraw.Circle:
                    Circle circle = (Circle)shape;
                    dx = newPosition.X - circle.getCenterPoint().X;
                    dy = newPosition.Y - circle.getCenterPoint().Y;
                    circle.setCenterPoint(multiMatrix2D(TypeTransform.Translation, dx, dy, new double[3] { circle.getCenterPoint().X, circle.getCenterPoint().Y, 1 }));
                    circle.setEndPoint(multiMatrix2D(TypeTransform.Translation, dx, dy, new double[3] { circle.getEndPoint().X, circle.getEndPoint().Y, 1 }));
                    break;
                case TypeDraw.Ellipse:
                    Ellipse ellipse = (Ellipse)shape;
                    dx = newPosition.X - ellipse.getStartPoint().X;
                    dy = newPosition.Y - ellipse.getStartPoint().Y;
                    ellipse.setStartPoint(multiMatrix2D(TypeTransform.Translation, dx, dy, new double[3] { ellipse.getStartPoint().X, ellipse.getStartPoint().Y, 1 }));
                    ellipse.setEndHightPoint(multiMatrix2D(TypeTransform.Translation, dx, dy, new double[3] { ellipse.getEndHightPoint().X, ellipse.getEndHightPoint().Y, 1 }));
                    ellipse.setEndWidthPoint(multiMatrix2D(TypeTransform.Translation, dx, dy, new double[3] { ellipse.getEndWidthPoint().X, ellipse.getEndWidthPoint().Y, 1 }));
                    break;
                case TypeDraw.Parallelogram:
                    Parallelogram parallelogram = (Parallelogram)shape;
                    dx = newPosition.X - parallelogram.getPoint1().X;
                    dy = newPosition.Y - parallelogram.getPoint1().Y;
                    parallelogram.setPoint1(multiMatrix2D(TypeTransform.Translation, dx, dy, new double[3] { parallelogram.getPoint1().X, parallelogram.getPoint1().Y, 1 }));
                    parallelogram.setPoint2(multiMatrix2D(TypeTransform.Translation, dx, dy, new double[3] { parallelogram.getPoint2().X, parallelogram.getPoint2().Y, 1 }));
                    parallelogram.setPoint3(multiMatrix2D(TypeTransform.Translation, dx, dy, new double[3] { parallelogram.getPoint3().X, parallelogram.getPoint3().Y, 1 }));
                    //parallelogram.setPoint4(multiMatrix2D(dx, dy, new double[3] { parallelogram.getPoint1().X, parallelogram.getPoint1().Y, 1 }));
                    break;
                case TypeDraw.Rectangle:
                    Rectangle rectangle = (Rectangle)shape;
                    dx = newPosition.X-rectangle.getStartPoint().X;
                    dy = newPosition.Y - rectangle.getStartPoint().Y;
                    rectangle.setStartPoint(multiMatrix2D(TypeTransform.Translation, dx, dy, new double[3] { rectangle.getStartPoint().X, rectangle.getStartPoint().Y, 1 }));
                    rectangle.setEndPoint(multiMatrix2D(TypeTransform.Translation, dx, dy, new double[3] { rectangle.getEndPoint().X, rectangle.getEndPoint().Y, 1 }));
                    break;
                case TypeDraw.Triangle:
                    Triangle triangle = (Triangle)shape;
                    dx = newPosition.X - triangle.getPoint1().X;
                    dy = newPosition.Y - triangle.getPoint1().Y;
                    triangle.setPoint1(multiMatrix2D(TypeTransform.Translation, dx, dy, new double[3] { triangle.getPoint1().X, triangle.getPoint1().Y, 1 }));
                    triangle.setPoint2(multiMatrix2D(TypeTransform.Translation, dx, dy, new double[3] { triangle.getPoint2().X, triangle.getPoint2().Y, 1 }));
                    triangle.setPoint3(multiMatrix2D(TypeTransform.Translation, dx, dy, new double[3] { triangle.getPoint3().X, triangle.getPoint3().Y, 1 }));
                    break;
            }
            shape.setTransformFlag(false);
        }

        public static void transformScaling(Shape shape,int scalingX=2,int scalingY=2)
        {
            switch (shape.getTypeDraw())
            {
                case TypeDraw.Line:
                    Line line = (Line)shape;
                    line.setStartPoint(multiMatrix2D(TypeTransform.Scaling,scalingX, scalingY, new double[3] { line.getStartPoint().X, line.getStartPoint().Y, 1 }));
                    line.setEndPoint(multiMatrix2D(TypeTransform.Scaling, scalingX, scalingY, new double[3] { line.getEndPoint().X, line.getEndPoint().Y, 1 }));
                    break;
                case TypeDraw.Circle:
                    Circle circle = (Circle)shape;
                    circle.setCenterPoint(multiMatrix2D(TypeTransform.Scaling, scalingX, scalingY, new double[3] { circle.getCenterPoint().X, circle.getCenterPoint().Y, 1 }));
                    circle.setEndPoint(multiMatrix2D(TypeTransform.Scaling, scalingX, scalingY, new double[3] { circle.getEndPoint().X, circle.getEndPoint().Y, 1 }));
                    break;
                case TypeDraw.Ellipse:
                    Ellipse ellipse = (Ellipse)shape;
                    ellipse.setStartPoint(multiMatrix2D(TypeTransform.Scaling, scalingX, scalingY, new double[3] { ellipse.getStartPoint().X, ellipse.getStartPoint().Y, 1 }));
                    ellipse.setEndHightPoint(multiMatrix2D(TypeTransform.Scaling, scalingX, scalingY, new double[3] { ellipse.getEndHightPoint().X, ellipse.getEndHightPoint().Y, 1 }));
                    ellipse.setEndWidthPoint(multiMatrix2D(TypeTransform.Scaling, scalingX, scalingY, new double[3] { ellipse.getEndWidthPoint().X, ellipse.getEndWidthPoint().Y, 1 }));
                    break;
                case TypeDraw.Parallelogram:
                    Parallelogram parallelogram = (Parallelogram)shape;
                    parallelogram.setPoint1(multiMatrix2D(TypeTransform.Scaling, scalingX, scalingY, new double[3] { parallelogram.getPoint1().X, parallelogram.getPoint1().Y, 1 }));
                    parallelogram.setPoint2(multiMatrix2D(TypeTransform.Scaling, scalingX, scalingY, new double[3] { parallelogram.getPoint2().X, parallelogram.getPoint2().Y, 1 }));
                    parallelogram.setPoint3(multiMatrix2D(TypeTransform.Translation, scalingX, scalingY, new double[3] { parallelogram.getPoint3().X, parallelogram.getPoint3().Y, 1 }));
                    //parallelogram.setPoint4(multiMatrix2D(dx, dy, new double[3] { parallelogram.getPoint1().X, parallelogram.getPoint1().Y, 1 }));
                    break;
                case TypeDraw.Rectangle:
                    Rectangle rectangle = (Rectangle)shape;
                    rectangle.setStartPoint(multiMatrix2D(TypeTransform.Scaling, scalingX, scalingY, new double[3] { rectangle.getStartPoint().X, rectangle.getStartPoint().Y, 1 }));
                    rectangle.setEndPoint(multiMatrix2D(TypeTransform.Scaling, scalingX, scalingY, new double[3] { rectangle.getEndPoint().X, rectangle.getEndPoint().Y, 1 }));
                    break;
                case TypeDraw.Triangle:
                    Triangle triangle = (Triangle)shape;
                    triangle.setPoint1(multiMatrix2D(TypeTransform.Scaling, scalingX, scalingY, new double[3] { triangle.getPoint1().X, triangle.getPoint1().Y, 1 }));
                    triangle.setPoint2(multiMatrix2D(TypeTransform.Scaling, scalingX, scalingY, new double[3] { triangle.getPoint2().X, triangle.getPoint2().Y, 1 }));
                    triangle.setPoint3(multiMatrix2D(TypeTransform.Scaling, scalingX, scalingY, new double[3] { triangle.getPoint3().X, triangle.getPoint3().Y, 1 }));
                    break;
            }
            shape.setTransformFlag(false);
        }

        private static Point multiMatrix2D(TypeTransform type, double dx, double dy, double[] array)
        {
            double[,] matrix = new double[3, 3];
            switch (type) {
                case TypeTransform.Translation:
                    matrix[0, 0] = 1; matrix[0, 1] = 0; matrix[0, 2] = 0;
                    matrix[1, 0] = 0; matrix[1, 1] = 1; matrix[1, 2] = 0;
                    matrix[2, 0] = dx; matrix[2, 1] = dy; matrix[2, 2] = 1;
                    break;
                case TypeTransform.Scaling:
                    matrix[0, 0] = dx; matrix[0, 1] = 0; matrix[0, 2] = 0;
                    matrix[1, 0] = 0; matrix[1, 1] = dy; matrix[1, 2] = 0;
                    matrix[2, 0] = 0; matrix[2, 1] = 0; matrix[2, 2] = 1;
                    break;
            }
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
