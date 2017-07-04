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
            //this.point1 = point1;
            //this.point2 = point2;
            //this.point3 = point3;

            setPoint1(point1);
            setPoint2(point2);
            setPoint3(point3);
            setName();
        }

        public Triangle() : this(new Point(0, 0), new Point(0, 0), new Point(0, 0))
        {
            resetRemaningClick();
        }

        public void setPoint1(Point point1)
        {
            this.point1 = point1;
            minusRemainingClick();
        }

        public Point getPoint1()
        {
            return point1;
        }

        public void setPoint2(Point point2)
        {
            this.point2 = point2;
            minusRemainingClick();
        }

        public Point getPoint2()
        {
            return point2;
        }

        public void setPoint3(Point point3)
        {
            this.point3 = point3;
            minusRemainingClick();
        }

        public Point getPoint3()
        {
            return point3;
        }

        public List<Line> getAllLines()
        {
            if (point1 == null || point2 == null || point3 == null)
                return null;
            List<Line> listLines = new List<Line>();
            Line l1 = new Line(point1, point2);
            l1.setColor(this.getColor());
            Line l2 = new Line(point2, point3);
            l2.setColor(this.getColor());
            Line l3 = new Line(point3, point1);
            l3.setColor(this.getColor());
            listLines.Add(l1);
            listLines.Add(l2);
            listLines.Add(l3);
            return listLines;
        }
    }
}
