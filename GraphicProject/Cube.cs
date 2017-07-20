﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicProject
{
    class Cube:Shape
    {
        List<Point3D> list = new List<Point3D>();
        List<Point> list2D = new List<Point>();
        Point startPoint;
        int width, height, depth;
        Point3D point3d;

        public Cube(Point startPoint, int width,int height,int depth,Color color):base(TypeDraw.Cube)
        {
            setStartPoint(startPoint);
            setWidth(width);
            setHeight(height);
            setDepth(depth);
            setColor(color);
        }

        public Cube(Point startPoint,int width,int height,int depth):this(startPoint,width,height,depth,Color.Black)
        {

        }

        public Cube():this(new Point(0,0),0,0,0)
        {

        }

        public void setStartPoint(Point startPoint)
        {
            this.startPoint = startPoint;
            this.point3d = new Point3D(0,0,0);// (200, 200,200);

            //width = this.width * 2;//50*2;
            //height = this.height * 2;//30*2;
            //depth = this.depth * 2;//20*2;

            point3d.X = startPoint.X;//200;
            point3d.Y = startPoint.Y;//200;
            point3d.Z = 0;

            
            calculate();
            minusRemainingClick();
        }

        private void calculate()
        {
            if (startPoint != new Point(0, 0) && width != 0 && height != 0 && depth != 0)
            {
                width = this.width * 2;//50*2;
                height = this.height * 2;//30*2;
                depth = this.depth * 2;//20*2;
                arrPoint3D(point3d.X, point3d.Y, point3d.Z);
            }
        }

        public Point getStartPoint()
        {
            return this.startPoint;
        }

        //private List<Point3D> arrPoint3D(int x, int y, int z)
        private void arrPoint3D(int x, int y, int z)
        {
            Point3D p;
            // p1
            p = new Point3D(x, y - height, z);
            list.Add(p);
            //p2
            p = new Point3D(x - depth, y - height, z);
            list.Add(p);
            //3
            p = new Point3D(x - depth, y - height, z - width);
            list.Add(p);
            //4
            p = new Point3D(x, y - height, z - width);
            list.Add(p);
            //5
            p = new Point3D(x, y, z - width);
            list.Add(p);
            //6
            p = new Point3D(x - depth, y, z - width);
            list.Add(p);
            //7
            p = new Point3D(x - depth, y, z);
            list.Add(p);
            //p0
            p = new Point3D(x, y, z);
            list.Add(p);
            foreach (Point3D p1 in list)
            {
                Console.WriteLine("ajbkav " + p1.X + " ," + p1.Y + "," + p1.Z);

            }

            Point p2d;
            double can2 = (int)Math.Sqrt(2);
            foreach (Point3D _p in list)
            {
                p2d = new Point(200+(int)(((double)_p.X - (double)((double)_p.Y / can2))),200+(int)(((double)_p.Z - (double)((double)_p.Y / can2))));
                Console.WriteLine("2d: " + p2d.X + " - " + p2d.Y);
                list2D.Add(p2d);
            }
            foreach(Point _p in list2D)
            {
                Console.WriteLine("List2d: " + _p.X + " - " + _p.Y);
            }
            //return list;
        }
        //public List<Point> arrpoint2D()
        //{
        //    Point p2d;
        //    double can2 = (int)Math.Sqrt(2);
        //    foreach (Point3D p in list)
        //    {
        //        p2d = new Point((int)(((double)p.X - (double)((double)p.Y / can2))), (int)(((double)p.Z - (double)((double)p.Y / can2))));
        //        list2D.Add(p2d);
        //    }

        //    return list2D;
        //}

        public void setWidth(int width)
        {
            this.width = width;
            calculate();
        }

        public int getWidth()
        {
            return width;
        }

        public void setHeight(int height)
        {
            this.height = height;
            calculate();
        }

        public int getHeigth()
        {
            return height;
        }

        public void setDepth(int depth)
        {
            this.depth = depth;
            calculate();
        }

        public int getDepth()
        {
            return depth;
        }

        public List<Line> getListLine()
        {
           
            List<Line> listLine = new List<Line>();
            if (list2D != null&&list2D.Count>0)
            {
                Console.WriteLine("list2dElement: " + list2D.ElementAt(0).X + " - " + list2D.ElementAt(0).Y);
                //listLine.Add(new Line(list2D.ElementAt(1), list2D.ElementAt(0)));
                listLine.Add(new Line(list2D.ElementAt(2), list2D.ElementAt(1)));
                listLine.Add(new Line(list2D.ElementAt(2), list2D.ElementAt(3)));
                listLine.Add(new Line(list2D.ElementAt(3), list2D.ElementAt(0)));
                listLine.Add(new Line(list2D.ElementAt(4), list2D.ElementAt(3)));
                listLine.Add(new Line(list2D.ElementAt(5), list2D.ElementAt(4)));
                listLine.Add(new Line(list2D.ElementAt(5), list2D.ElementAt(6)));
                listLine.Add(new Line(list2D.ElementAt(6), list2D.ElementAt(7), true));
                listLine.Add(new Line(list2D.ElementAt(4), list2D.ElementAt(7), true));
                listLine.Add(new Line(list2D.ElementAt(7), list2D.ElementAt(0), true));
                listLine.Add(new Line(list2D.ElementAt(6), list2D.ElementAt(1)));
                listLine.Add(new Line(list2D.ElementAt(5), list2D.ElementAt(2)));
            }
            return listLine;
        }

    }

}
