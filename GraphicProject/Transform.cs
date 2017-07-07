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
        public static void translationTransform(Shape shape)
        {
            int dx, dy;
            Point newPosition = shape.getTransformPoint();
            switch (shape.getTypeDraw())
            {
                case TypeDraw.Line:
                    Line line = (Line)shape;
                    dx = newPosition.X - line.getStartPoint().X;
                    dy = newPosition.Y - line.getStartPoint().Y;
                    line.setStartPoint(multiMatrix(TypeTransform.Translation,dx, dy, new double[3] { line.getStartPoint().X, line.getStartPoint().Y, 1 }));
                    line.setEndPoint(multiMatrix(TypeTransform.Translation, dx, dy, new double[3] { line.getEndPoint().X, line.getEndPoint().Y, 1 }));
                    break;
                case TypeDraw.Circle:
                    Circle circle = (Circle)shape;
                    dx = newPosition.X - circle.getCenterPoint().X;
                    dy = newPosition.Y - circle.getCenterPoint().Y;
                    circle.setCenterPoint(multiMatrix(TypeTransform.Translation, dx, dy, new double[3] { circle.getCenterPoint().X, circle.getCenterPoint().Y, 1 }));
                    circle.setEndPoint(multiMatrix(TypeTransform.Translation, dx, dy, new double[3] { circle.getEndPoint().X, circle.getEndPoint().Y, 1 }));
                    break;
                case TypeDraw.Ellipse:
                    Ellipse ellipse = (Ellipse)shape;
                    dx = newPosition.X - ellipse.getStartPoint().X;
                    dy = newPosition.Y - ellipse.getStartPoint().Y;
                    ellipse.setStartPoint(multiMatrix(TypeTransform.Translation, dx, dy, new double[3] { ellipse.getStartPoint().X, ellipse.getStartPoint().Y, 1 }));
                    ellipse.setEndHightPoint(multiMatrix(TypeTransform.Translation, dx, dy, new double[3] { ellipse.getEndHightPoint().X, ellipse.getEndHightPoint().Y, 1 }));
                    ellipse.setEndWidthPoint(multiMatrix(TypeTransform.Translation, dx, dy, new double[3] { ellipse.getEndWidthPoint().X, ellipse.getEndWidthPoint().Y, 1 }));
                    break;
                case TypeDraw.Parallelogram:
                    Parallelogram parallelogram = (Parallelogram)shape;
                    dx = newPosition.X - parallelogram.getPoint1().X;
                    dy = newPosition.Y - parallelogram.getPoint1().Y;
                    parallelogram.setPoint1(multiMatrix(TypeTransform.Translation, dx, dy, new double[3] { parallelogram.getPoint1().X, parallelogram.getPoint1().Y, 1 }));
                    parallelogram.setPoint2(multiMatrix(TypeTransform.Translation, dx, dy, new double[3] { parallelogram.getPoint2().X, parallelogram.getPoint2().Y, 1 }));
                    parallelogram.setPoint3(multiMatrix(TypeTransform.Translation, dx, dy, new double[3] { parallelogram.getPoint3().X, parallelogram.getPoint3().Y, 1 }));
                    //parallelogram.setPoint4(multiMatrix(dx, dy, new double[3] { parallelogram.getPoint1().X, parallelogram.getPoint1().Y, 1 }));
                    break;
                case TypeDraw.Rectangle:
                    Rectangle rectangle = (Rectangle)shape;
                    dx = newPosition.X-rectangle.getStartPoint().X;
                    dy = newPosition.Y - rectangle.getStartPoint().Y;
                    rectangle.setStartPoint(multiMatrix(TypeTransform.Translation, dx, dy, new double[3] { rectangle.getStartPoint().X, rectangle.getStartPoint().Y, 1 }));
                    rectangle.setEndPoint(multiMatrix(TypeTransform.Translation, dx, dy, new double[3] { rectangle.getEndPoint().X, rectangle.getEndPoint().Y, 1 }));
                    break;
                case TypeDraw.Triangle:
                    Triangle triangle = (Triangle)shape;
                    dx = newPosition.X - triangle.getPoint1().X;
                    dy = newPosition.Y - triangle.getPoint1().Y;
                    triangle.setPoint1(multiMatrix(TypeTransform.Translation, dx, dy, new double[3] { triangle.getPoint1().X, triangle.getPoint1().Y, 1 }));
                    triangle.setPoint2(multiMatrix(TypeTransform.Translation, dx, dy, new double[3] { triangle.getPoint2().X, triangle.getPoint2().Y, 1 }));
                    triangle.setPoint3(multiMatrix(TypeTransform.Translation, dx, dy, new double[3] { triangle.getPoint3().X, triangle.getPoint3().Y, 1 }));
                    break;
                case TypeDraw.Square:
                    Square square = (Square)shape;
                    dx = newPosition.X - square.getPoint1().X;
                    dy = newPosition.Y - square.getPoint1().Y;
                    square.setPoint1(multiMatrix(TypeTransform.Translation, dx, dy, new double[3] { square.getPoint1().X, square.getPoint1().Y, 1 }));
                    square.setPoint2(multiMatrix(TypeTransform.Translation, dx, dy, new double[3] { square.getPoint2().X, square.getPoint2().Y, 1 }));
                    break;
            }
            shape.setTransformFlag(false);
        }

        public static void scalingTransform(Shape shape,int scalingX,int scalingY)
        {
            scalingX--;
            scalingY--;
            switch (shape.getTypeDraw())
            {
                case TypeDraw.Line:
                    Line line = (Line)shape;
                    //line.setStartPoint(multiMatrix(TypeTransform.Scaling,scalingX, scalingY, new double[3] { line.getStartPoint().X, line.getStartPoint().Y, 1 }));
                    if (line.getStartPoint().X < line.getEndPoint().X && line.getStartPoint().Y < line.getEndPoint().Y)
                    {
                        if (line.getStartPoint().X > line.getEndPoint().X)
                            scalingX = -scalingX;
                        if (line.getStartPoint().Y > line.getEndPoint().Y)
                            scalingY = -scalingY;
                    }
                    else if (line.getStartPoint().X < line.getEndPoint().X && line.getStartPoint().Y > line.getEndPoint().Y)
                    {
                        if (line.getStartPoint().X > line.getEndPoint().X)
                            scalingX = -scalingX;
                        if (line.getStartPoint().Y < line.getEndPoint().Y)
                            scalingY = -scalingY;
                    }
                    //line.setEndPoint(multiMatrix(TypeTransform.Scaling, scalingX, scalingY, new double[3] { line.getEndPoint().X, line.getEndPoint().Y, 1 }));
                    line.setEndPoint(new Point(line.getEndPoint().X + scalingX * (line.getEndPoint().X-line.getStartPoint().X), line.getEndPoint().Y + scalingY * (line.getEndPoint().Y - line.getStartPoint().Y)));
                    break;
                case TypeDraw.Circle:
                    Circle circle = (Circle)shape;
                    //circle.setCenterPoint(multiMatrix(TypeTransform.Scaling, scalingX, scalingY, new double[3] { circle.getCenterPoint().X, circle.getCenterPoint().Y, 1 }));
                    if (circle.getCenterPoint().X < circle.getEndPoint().X)
                        scalingX = -scalingX;
                    if (circle.getCenterPoint().Y < circle.getEndPoint().Y)
                        scalingY = -scalingY;
                    circle.setEndPoint(new Point(circle.getEndPoint().X + scalingX * (circle.getEndPoint().X - circle.getCenterPoint().X),circle.getEndPoint().Y + scalingY * (circle.getEndPoint().Y - circle.getCenterPoint().Y)));
                    break;
                case TypeDraw.Ellipse:
                    Ellipse ellipse = (Ellipse)shape;
                    //ellipse.setStartPoint(multiMatrix(TypeTransform.Scaling, scalingX, scalingY, new double[3] { ellipse.getStartPoint().X, ellipse.getStartPoint().Y, 1 }));
                    ellipse.setEndHightPoint(multiMatrix(TypeTransform.Scaling, scalingX, scalingY, new double[3] { ellipse.getEndHightPoint().X, ellipse.getEndHightPoint().Y, 1 }));
                    ellipse.setEndWidthPoint(multiMatrix(TypeTransform.Scaling, scalingX, scalingY, new double[3] { ellipse.getEndWidthPoint().X, ellipse.getEndWidthPoint().Y, 1 }));
                    break;
                case TypeDraw.Parallelogram:
                    Parallelogram parallelogram = (Parallelogram)shape;
                    //parallelogram.setPoint1(multiMatrix(TypeTransform.Scaling, scalingX, scalingY, new double[3] { parallelogram.getPoint1().X, parallelogram.getPoint1().Y, 1 }));
                    parallelogram.setPoint2(multiMatrix(TypeTransform.Scaling, scalingX, scalingY, new double[3] { parallelogram.getPoint2().X, parallelogram.getPoint2().Y, 1 }));
                    parallelogram.setPoint3(multiMatrix(TypeTransform.Translation, scalingX, scalingY, new double[3] { parallelogram.getPoint3().X, parallelogram.getPoint3().Y, 1 }));
                    //parallelogram.setPoint4(multiMatrix(dx, dy, new double[3] { parallelogram.getPoint1().X, parallelogram.getPoint1().Y, 1 }));
                    break;
                case TypeDraw.Rectangle:
                    Rectangle rectangle = (Rectangle)shape;
                    //rectangle.setStartPoint(multiMatrix(TypeTransform.Scaling, scalingX, scalingY, new double[3] { rectangle.getStartPoint().X, rectangle.getStartPoint().Y, 1 }));
                    rectangle.setEndPoint(multiMatrix(TypeTransform.Scaling, scalingX, scalingY, new double[3] { rectangle.getEndPoint().X, rectangle.getEndPoint().Y, 1 }));
                    break;
                case TypeDraw.Triangle:
                    Triangle triangle = (Triangle)shape;
                    //triangle.setPoint1(multiMatrix(TypeTransform.Scaling, scalingX, scalingY, new double[3] { triangle.getPoint1().X, triangle.getPoint1().Y, 1 }));
                    triangle.setPoint2(multiMatrix(TypeTransform.Scaling, scalingX, scalingY, new double[3] { triangle.getPoint2().X, triangle.getPoint2().Y, 1 }));
                    triangle.setPoint3(multiMatrix(TypeTransform.Scaling, scalingX, scalingY, new double[3] { triangle.getPoint3().X, triangle.getPoint3().Y, 1 }));
                    break;
                case TypeDraw.Square:
                    Square square = (Square)shape;
                    square.setPoint2(multiMatrix(TypeTransform.Scaling, scalingX, scalingY, new double[3] { square.getPoint2().X, square.getPoint2().Y, 1 }));
                    break;
            }
            shape.setTransformFlag(false);
        }

        public static void reflectionTransform(Shape shape, TypeReflectionTransform type)
        {
            Line Ox=new Line(new Point(0,200),new Point(400,200));
            Ox.setTransformPoint(new Point(0, 0));
            translationTransform(Ox);
            Line Oy = new Line(new Point(200, 200), new Point(400, 400));
            Oy.setTransformPoint(new Point(0, 0));
            translationTransform(Oy);

            switch (shape.getTypeDraw())
            {
                case TypeDraw.Line:
                    Line line = (Line)shape;
                    line.setStartPoint(reflect(line.getStartPoint(),type));
                    line.setEndPoint(reflect(line.getEndPoint(), type));
                    break;
                case TypeDraw.Circle:
                    Circle circle = (Circle)shape;
                    circle.setCenterPoint(reflect(circle.getCenterPoint(), type));
                    circle.setEndPoint(reflect(circle.getEndPoint(), type));
                    break;
                case TypeDraw.Ellipse:
                    Ellipse ellipse = (Ellipse)shape;
                    ellipse.setStartPoint(reflect(ellipse.getStartPoint(), type));
                    ellipse.setEndHightPoint(reflect(ellipse.getEndHightPoint(), type));
                    ellipse.setEndWidthPoint(reflect(ellipse.getEndWidthPoint(), type));
                    break;
                case TypeDraw.Parallelogram:
                    Parallelogram parallelogram = (Parallelogram)shape;
                    parallelogram.setPoint1(reflect(parallelogram.getPoint1(), type));
                    parallelogram.setPoint2(reflect(parallelogram.getPoint2(), type));
                    parallelogram.setPoint3(reflect(parallelogram.getPoint3(), type));
                    break;
                case TypeDraw.Rectangle:
                    Rectangle rectangle = (Rectangle)shape;
                    rectangle.setStartPoint(reflect(rectangle.getStartPoint(), type));
                    rectangle.setEndPoint(reflect(rectangle.getEndPoint(), type));
                    break;
                case TypeDraw.Triangle:
                    Triangle triangle = (Triangle)shape;
                    triangle.setPoint1(reflect(triangle.getPoint1(), type));
                    triangle.setPoint2(reflect(triangle.getPoint2(), type));
                    triangle.setPoint3(reflect(triangle.getPoint3(), type));
                    break;
                case TypeDraw.Square:
                    Square square = (Square)shape;
                    square.setPoint1(reflect(square.getPoint1(), type));
                    square.setPoint2(reflect(square.getPoint2(), type));
                    break;
            }
            shape.setTransformFlag(false);
        }

        private static Point reflect(Point startPoint,TypeReflectionTransform type)
        {
            int y = startPoint.Y;
            int x = startPoint.X;
            switch (type)
            {
                case TypeReflectionTransform.Horizontal:
                    if (y < 200)
                        startPoint.Y= y + ((200 - y) * 2);
                    else if (y > 200)
                        startPoint.Y= y - ((y - 200) * 2);
                    break;
                case TypeReflectionTransform.Vertical:
                    if (x < 200)
                        startPoint.X = x + ((200 - x) * 2);
                    else if (x > 200)
                        startPoint.X = x - ((x - 200) * 2);
                    break;
                case TypeReflectionTransform.Origin:
                    if (y < 200)
                        startPoint.Y = y + ((200 - y) * 2);
                    else if (y > 200)
                        startPoint.Y = y - ((y - 200) * 2);
                    if (x < 200)
                        startPoint.X = x + ((200 - x) * 2);
                    else if (x > 200)
                        startPoint.X = x - ((x - 200) * 2);
                    break;
            }
            return startPoint;
        }

        public static void rotationTransform(Shape shape,float rotation)
        {
            Point oldPositionShape = new Point(0, 0);
            switch (shape.getTypeDraw())
            {
                case TypeDraw.Circle:
                    Circle circle = (Circle)shape;
                    oldPositionShape = circle.getCenterPoint();
                    break;
                case TypeDraw.Ellipse:
                    Ellipse ellipse = (Ellipse)shape;
                    oldPositionShape = ellipse.getStartPoint();
                    break;
                case TypeDraw.Line:
                    Line line = (Line)shape;
                    oldPositionShape = line.getStartPoint();
                    break;
                case TypeDraw.Parallelogram:
                    Parallelogram parallelogram = (Parallelogram)shape;
                    oldPositionShape = parallelogram.getPoint1();
                    break;
                case TypeDraw.Rectangle:
                    Rectangle rectangle = (Rectangle)shape;
                    oldPositionShape = rectangle.getStartPoint();
                    break;
                case TypeDraw.Rhombus:
                    Rhombus rhombus = (Rhombus)shape;
                    oldPositionShape = rhombus.getPoint1();
                    break;
                case TypeDraw.Square:
                    Square square = (Square)shape;
                    oldPositionShape = square.getPoint1();
                    break;
                case TypeDraw.Triangle:
                    Triangle triangle = (Triangle)shape;
                    oldPositionShape = triangle.getPoint1();
                    break;
            }
            shape.setTransformPoint(new Point(0, 0));
            translationTransform(shape);

            double sin = Math.Sin((Math.PI*rotation) / 180);
            double cos = Math.Cos((Math.PI*rotation) / 180);
            switch (shape.getTypeDraw())
            {
                case TypeDraw.Circle:
                    Circle circle = (Circle)shape;
                    circle.setCenterPoint(multiMatrix(TypeTransform.Rotation, sin, cos, new double[3] { circle.getCenterPoint().X, circle.getCenterPoint().Y, 1 }));
                    circle.setEndPoint(multiMatrix(TypeTransform.Rotation, sin, cos, new double[3] { circle.getEndPoint().X, circle.getEndPoint().Y, 1 }));
                    break;
                case TypeDraw.Ellipse:
                    Ellipse ellipse = (Ellipse)shape;
                    ellipse.setStartPoint(multiMatrix(TypeTransform.Rotation, sin, cos, new double[3] { ellipse.getStartPoint().X, ellipse.getStartPoint().Y, 1 }));
                    ellipse.setEndHightPoint(multiMatrix(TypeTransform.Rotation, sin, cos, new double[3] { ellipse.getEndHightPoint().X, ellipse.getEndHightPoint().Y, 1 }));
                    ellipse.setEndWidthPoint(multiMatrix(TypeTransform.Rotation, sin, cos, new double[3] { ellipse.getEndWidthPoint().X, ellipse.getEndWidthPoint().Y, 1 }));
                    break;
                case TypeDraw.Line:
                    Line line = (Line)shape;
                    line.setStartPoint(multiMatrix(TypeTransform.Rotation, sin, cos, new double[3] { line.getStartPoint().X, line.getStartPoint().Y, 1 }));
                    line.setEndPoint(multiMatrix(TypeTransform.Rotation, sin, cos, new double[3] { line.getEndPoint().X, line.getEndPoint().Y,1 }));
                    break;
                case TypeDraw.Parallelogram:
                    Parallelogram parallelogram = (Parallelogram)shape;
                    parallelogram.setPoint1(multiMatrix(TypeTransform.Rotation, sin, cos, new double[3] { parallelogram.getPoint1().X, parallelogram.getPoint1().Y, 1 }));
                    parallelogram.setPoint2(multiMatrix(TypeTransform.Rotation, sin, cos, new double[3] { parallelogram.getPoint2().X, parallelogram.getPoint2().Y, 1 }));
                    parallelogram.setPoint3(multiMatrix(TypeTransform.Rotation, sin, cos, new double[3] { parallelogram.getPoint3().X, parallelogram.getPoint3().Y, 1 }));
                    break;
                case TypeDraw.Rectangle:
                    Rectangle rectangle = (Rectangle)shape;
                    rectangle.setStartPoint(multiMatrix(TypeTransform.Rotation, sin, cos, new double[3] { rectangle.getStartPoint().X, rectangle.getStartPoint().Y, 1 }));
                    rectangle.setEndPoint(multiMatrix(TypeTransform.Rotation, sin, cos, new double[3] { rectangle.getEndPoint().X, rectangle.getEndPoint().Y, 1 }));
                    break;
                case TypeDraw.Rhombus:
                    Rhombus rhombus = (Rhombus)shape;
                    //not yet completed
                    break;
                case TypeDraw.Square:
                    Square square = (Square)shape;
                    square.setPoint1(multiMatrix(TypeTransform.Rotation, sin, cos, new double[3] { square.getPoint1().X,square.getPoint1().Y,1}));
                    square.setPoint2(multiMatrix(TypeTransform.Rotation, sin, cos, new double[3] { square.getPoint2().X, square.getPoint2().Y, 1 }));
                    break;
                case TypeDraw.Triangle:
                    Triangle triangle = (Triangle)shape;
                    triangle.setPoint1(multiMatrix(TypeTransform.Rotation, sin, cos, new double[3] { triangle.getPoint1().X, triangle.getPoint1().Y, 1 }));
                    triangle.setPoint2(multiMatrix(TypeTransform.Rotation, sin,cos, new double[3] { triangle.getPoint2().X, triangle.getPoint2().Y, 1 }));
                    triangle.setPoint3(multiMatrix(TypeTransform.Rotation, sin,cos, new double[3] { triangle.getPoint3().X, triangle.getPoint3().Y, 1 }));
                    break;
            }
            shape.setTransformPoint(oldPositionShape);
            translationTransform(shape);
        }

        private static Point multiMatrix(TypeTransform type, double dx, double dy, double[] array)
        {
            Console.WriteLine("ma tran dau: " + array[0] + " - " + array[1] + " - " + array[2]);
            double[,] matrix = new double[3, 3];
            switch (type) {
                case TypeTransform.Translation:
                    matrix[0, 0] = 1; matrix[0, 1] = 0; matrix[0, 2] = 0;
                    matrix[1, 0] = 0; matrix[1, 1] = 1; matrix[1, 2] = 0;
                    matrix[2, 0] = dx; matrix[2, 1] = dy; matrix[2, 2] = 1;
                    break;
                case TypeTransform.Scaling:
                    matrix[0, 0] = dx+1; matrix[0, 1] = 0; matrix[0, 2] = 0;
                    matrix[1, 0] = 0; matrix[1, 1] = dy+1; matrix[1, 2] = 0;
                    matrix[2, 0] = 0; matrix[2, 1] = 0; matrix[2, 2] = 1;
                    break;
                case TypeTransform.Rotation:
                    //double sin = Math.Sin((Math.PI * dx) / 180); //dx
                    //double cos = Math.Cos((Math.PI * dx) / 180); //dy
                    matrix[0, 0] = dy;      matrix[0, 1] = dx; matrix[0, 2] = 0;
                    matrix[1, 0] = -1 * dx; matrix[1, 1] = dy; matrix[1, 2] = 0;
                    matrix[2, 0] = 0;       matrix[2, 1] = 0;  matrix[2, 2] = 1;
                    //mang[0] = pt.X; mang[1] = pt.Y; mang[2] = 1;
                    break;
            }
            double[] temparr = new double[3];

            int count = 0;
            for (int i = 0; i < 3; i++)
            {
                temparr[i] = array[0] * matrix[0, count] + array[1] * matrix[1, count] + array[2] * matrix[2, count];
                count++;
            }
            Console.WriteLine("Ma trận kq: " + temparr[0] + " - " + temparr[1] + " - " + temparr[2]);

            Point pt = new Point(Convert.ToInt16(temparr[0]), Convert.ToInt16(temparr[1]));
            return pt;
        }
    }
}
