using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicProject
{
    class Ellipse:Shape
    {
        Point startPoint, endWidthPoint, endHightPoint;
        int width, height;
		public Ellipse(Point startPoint,Point endWidthPoint,Point endHightPoint,Color color):this(startPoint,endWidthPoint,endHightPoint)
        {
            setColor(color);
        }

		public Ellipse(Point startPoint,Point endWidthPoint, Point endHightPoint): base(TypeDraw.Ellipse)
        {
            this.startPoint = startPoint;
            this.endWidthPoint = endWidthPoint;
            this.endHightPoint = endHightPoint;

            //calculate width,heigth
            //handle...
        }

        public Ellipse():this(new Point(0,0),new Point(0,0),new Point(0, 0))
        {

        }

        public void setStartPoint(Point startPoint)
        {
            this.startPoint = startPoint;
        }

        public Point getStartPoint()
        {
            return startPoint;
        }

        public void setEndWidthPoint(Point endWidthPoint)
        {
            this.endWidthPoint = endWidthPoint;
        }

        public Point getEndWidthPoint()
        {
            return endWidthPoint;
        }

        public void setEndHightPoint(Point endHightPoint)
        {
            this.endHightPoint = endHightPoint;
        }

        public Point getEndHightPoint()
        {
            return endHightPoint;
        }

        public int getWidth() {
            return width;
        }

        public int getHeight()
        {
            return height;
        }
    }
}
