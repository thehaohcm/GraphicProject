using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicProject
{
    class Triangle:Shape
    {
        Point point1, point2, point3;
        public Triangle(Point point1,Point point2,Point point3,Color color):this(point1,point2,point3)
        {
            setColor(color);
        }

        public Triangle(Point point1,Point point2,Point point3):base(TypeDraw.Triangle)
        {
            this.point1 = point1;
            this.point2 = point2;
            this.point3 = point3;
        }

        public Triangle():this(new Point(0, 0), new Point(0, 0), new Point(0, 0))
        {
        }

        public void setPoint1(Point point1)
        {
            this.point1 = point1;
        }

        public Point getPoint1()
        {
            return point1;
        }

        public void setPoint2(Point point2)
        {
            this.point2 = point2;
        }

        public Point getPoint2()
        {
            return point2;
        }

        public void setPoint3(Point point3)
        {
            this.point3 = point3;
        }

        public Point getPoint3()
        {
            return point3;
        }

    }
}
