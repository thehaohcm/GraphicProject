using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicProject
{
    class Parallelogram:Shape
    {
        Point point1, point2, point3;

        Point point4;
        public Parallelogram(Point point1,Point point2,Point point3,Color color):this(point1,point2,point3)
        {
            setColor(color);
        }

        public Parallelogram(Point point1,Point point2,Point point3): base(TypeDraw.Parallelogram)
        {
            //this.point1 = point1;
            //this.point2 = point2;
            //this.point3 = point3;

            setPoint1(point1);
            setPoint2(point2);
            setPoint3(point3);
            //handle => point 4
            //...
        }

        public Parallelogram():this(new Point(0, 0), new Point(0, 0), new Point(0, 0))
        {
            resetRemaningClick();
        }

        public void setPoint1(Point point)
        {
            this.point1 = point;
            minusRemainingClick();
        }

        public Point getPoint1()
        {
            return point1;
        }

        public void setPoint2(Point point)
        {
            this.point2 = point;
            minusRemainingClick();
        }

        public Point getPoint2()
        {
            return point2;
        }

        public void setPoint3(Point point)
        {
            this.point3 = point;
            minusRemainingClick();
        }

        public Point getPoint3()
        {
            return point3;
        }

        public Point getPoint4()
        {
            return point4;
        }


    }
}
