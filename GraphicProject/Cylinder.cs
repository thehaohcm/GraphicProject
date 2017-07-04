using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicProject
{
    class Cylinder : Shape
    {
        List<Point3D> list = new List<Point3D>();
        List<Point> list2D = new List<Point>();
        Point point;
        int height, radius;
        Point3D point3d;

        public Cylinder() : base(TypeDraw.Cylinder)
        {
            setColor(Color.Black);
        }

        public void setPoint(Point point)
        {
            this.point = point;
            this.point3d = new Point3D(200, 200, 200);
            minusRemainingClick();

            //width = 50 * 2;
            height = 30 * 2;
            radius = 30;
            //depth = 20 * 2;

            point3d.X = 200;
            point3d.Y = 200;
            point3d.Z = 200;

            arrPoint3D(point3d.X, point3d.Y, point3d.Z);
        }

        //private List<Point3D> arrPoint3D(int x, int y, int z)
        private void arrPoint3D(int x, int y, int z)
        {
            Point3D p;
            // p1
            p = new Point3D(x + radius, y, z);
            list.Add(p);
            //p2
            p = new Point3D(x, y, z + radius);
            list.Add(p);
            //3
            p = new Point3D(x - radius, y, z);
            list.Add(p);
            //4
            p = new Point3D(x - radius, y - height, z);
            list.Add(p);
            //5
            p = new Point3D(x + radius, y - height, z);
            list.Add(p);
            //6
            p = new Point3D(x, y - height, z - radius);
            list.Add(p);
            //7
            p = new Point3D(x, y - height, z);
            list.Add(p);
            //p0
            p = new Point3D(x, y, z);
            list.Add(p);

            Point p2d;
            double can2 = (int)Math.Sqrt(2);
            foreach (Point3D _p in list)
            {
                p2d = new Point(200 + (int)(((double)_p.X - (double)((double)_p.Y / can2))), 200 + (int)(((double)_p.Z - (double)((double)_p.Y / can2))));
                list2D.Add(p2d);
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

        public List<Shape> getListLine()
        {
            List<Shape> listLine = new List<Shape>();
            Console.WriteLine("list2dElement: " + list2D.ElementAt(0).X + " - " + list2D.ElementAt(0).Y);
            listLine.Add(new Line(list2D.ElementAt(3), list2D.ElementAt(4)));
            listLine.Add(new Line(list2D.ElementAt(1), list2D.ElementAt(5)));
            listLine.Add(new Ellipse(list2D.ElementAt(0), list2D.ElementAt(1), list2D.ElementAt(2)));
            listLine.Add(new Ellipse(list2D.ElementAt(7), list2D.ElementAt(5), list2D.ElementAt(6)));


            return listLine;
        }

    }
}
