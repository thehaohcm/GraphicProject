using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicProject
{
    class Square:Shape
    {
        private Point startPoint,endPoint;

        //Add the rest
        //...
        private int edge;

        public Square(Point startPoint,Point endPoint,int edge,Color color):this(startPoint,endPoint,edge)
        {
            setColor(color);
        }
        public Square(Point startPoint,Point endPoint,int edge):base(TypeDraw.Square)
        {
            this.startPoint = startPoint;
            this.endPoint = endPoint;
            this.edge = edge;
        }

        public Square():this(new Point(0, 0), new Point(0, 0), 0)
        {
        }

        public void setStartPoint(Point startPoint)
        {
            this.startPoint = startPoint;
        }

        public void setEndPoint(Point endPoint)
        {
            this.endPoint = endPoint;
        }

        public void setEdge(int edge)
        {
            this.edge = edge;
        }

        public Point getStartPoint()
        {
            return startPoint;
        }

        public Point getEndPoint()
        {
            return endPoint;
        }

        public int getEdge()
        {
            return edge;
        }

    }
}
