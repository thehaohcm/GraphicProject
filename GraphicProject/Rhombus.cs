using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicProject
{
    class Rhombus:Shape
    {
        Point point1, point2, point3, point4, pointCenter;
        public Rhombus(Point pointCenter,Point point1,Point point2,Color color):this(pointCenter,point1,point2)
        {
            setColor(color);
        }

        public Rhombus(Point pointCenter,Point point1,Point point2):base(TypeDraw.Rhombus)
        {
            setPointCenter(pointCenter);
            setPoint1(point1);
            setPoint2(point2);
        }

        public Rhombus():this(new Point(0,0),new Point(0,0),new Point(0, 0))
        {
            resetRemaningClick();
        }

        public void setPointCenter(Point pointCenter)
        {
            this.pointCenter = pointCenter;
            minusRemainingClick();
        }

        public void setPoint1(Point point1)
        {
            this.point1 = point1;
            minusRemainingClick();
        }

        public void setPoint2(Point point2)
        {
            this.point2 = point2;
            minusRemainingClick();
        }

        public Point getPointCenter()
        {
            return pointCenter;
        }

        public Point getPoint1()
        {
            return point1;
        }

        public Point getPoint2()
        {
            return point2;
        }

        public List<Line> getAllLines()
        {
            if (pointCenter == null || point1 == null || point2 == null)
                return null;
            List<Line> listLines = new List<Line>();

            return listLines;
        }
    }
}
