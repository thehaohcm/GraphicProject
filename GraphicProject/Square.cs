﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicProject
{
    class Square:Shape
    {
        private static decimal currentNumber = 0;
        private Point startPoint,endPoint;

        //Add the rest
        //...
        private double edge;

        public Square(Point startPoint,Point endPoint,int edge,Color color):this(startPoint,endPoint)
        {
            setColor(color);
        }
        public Square(Point startPoint,Point endPoint):base(TypeDraw.Square)
        {
            //this.startPoint = startPoint;
            //this.endPoint = endPoint;

            setStartPoint(startPoint);
            setEndPoint(endPoint);
            currentNumber++;
            setName("Square_" + currentNumber);
            //this.edge = edge;
        }

        public Square():this(new Point(0, 0), new Point(0, 0))
        {
            resetRemaningClick();
        }

        public void setStartPoint(Point startPoint)
        {
            this.startPoint = startPoint;
            minusRemainingClick();
            calculateEdge();
        }

        public void setEndPoint(Point endPoint)
        {
            this.endPoint = endPoint;
            minusRemainingClick();
            calculateEdge();
        }

        //public void setEdge(int edge)
        //{
        //    this.edge = edge;
        //}

        public Point getStartPoint()
        {
            return startPoint;
        }

        public Point getEndPoint()
        {
            return endPoint;
        }

        public double getEdge()
        {
            return edge;
        }

        private void calculateEdge()
        {
            if (startPoint != null && endPoint != null)
            {
                if (startPoint.X == endPoint.X)
                {
                    this.edge = Math.Abs(startPoint.Y - endPoint.Y);
                }else if (endPoint.Y == endPoint.Y)
                {
                    this.edge = Math.Abs(startPoint.X - endPoint.X);
                }
            }
        }
    }
}
