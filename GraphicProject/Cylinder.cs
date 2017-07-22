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
        //Point point;
        int height, radius;
        Point3D point3d;

        //public Cylinder() : base(TypeDraw.Cylinder)
        //{
        //    setColor(Color.Black);
        //}

        public Cylinder(Point3D point3d,int height,int radius,Color color):base(TypeDraw.Cylinder)
        {
            setPoint3D(point3d);
            setHeight(height);
            setRadius(radius);
            setColor(color);
        }

        public Cylinder(Point3D point3d, int height, int radius) : this(point3d, height, radius, Color.Black)
        {

        }

        public Cylinder():this(new Point3D(0, 0, 0), 0, 0)
        {

        }

        //public void setPoint(Point point)
        //{
        //    //this.point = point;
        //    //this.point3d = new Point3D(200, 200, 200);
        //    //minusRemainingClick();

        //    //radius = 40 * 2;
        //    //height = 80 * 2;


        //    //point3d.X = 200;
        //    //point3d.Y = 200;
        //    //point3d.Z = 200;

        //    //arrPoint3D(point3d.X, point3d.Y, point3d.Z);
        //}

        public void setPoint3D(Point3D point3d)
        {
            this.point3d = point3d;
            calculate();
        }

        public Point3D getPoint3D()
        {
            return point3d;
        }
        public void setRadius(int radius)
        {
            this.radius = radius;
            calculate();
        }

        public int getRadius()
        {
            return radius;
        }

        public void setHeight(int height)
        {
            this.height = height;
            calculate();
        }

        public int getHeight()
        {
            return height;
        }

        private void calculate()
        {
            if(point3d!=new Point3D(0, 0, 0) && height != 0 && radius != 0)
            {
                radius *= 2;
                height *= 2;
                arrPoint3D(point3d.X, point3d.Y, point3d.Z);
            }
        }

        //private List<Point3D> arrPoint3D(int x, int y, int z)
        private void arrPoint3D(int x, int y, int z)
        {
            Point3D p;
            // p1 true
            p = new Point3D(x + radius, y, z);
            list.Add(p);
            //p2 true
            p = new Point3D(x, y, (int)((z - radius) * 1.5));
            list.Add(p);
            //3 true
            p = new Point3D(x - radius, y, z);
            list.Add(p);
            //4 
            p = new Point3D(x - 3 * radius, y - height, z);
            list.Add(p);
            //5
            p = new Point3D(x - radius, y - height, z);
            list.Add(p);
           
            //p = new Point3D(x, y - height, (int)((z - radius) * 1.5));
            p = new Point3D(x,y,(int)((z*1.5)));
            list.Add(p);
            //7
            p = new Point3D(x - 2 * radius, y - height, z);
            list.Add(p);
            //p0 true
            p = new Point3D(x, y, z);
            list.Add(p);


            Point p2d;
            double can2 = (int)Math.Sqrt(2);
            foreach (Point3D _p in list)
            {
                p2d = new Point(200 + (int)(((double)_p.X - (double)((double)_p.Y / can2))), 200 + (int)(((double)_p.Z - (double)((double)_p.Y / can2))));
                Console.WriteLine("X: " + p2d.X + " - Y: " + p2d.Y);
                list2D.Add(p2d);
            }
        }

        public List<Shape> getListShape()
        {
            List<Shape> listLine = new List<Shape>();

            listLine.Add(new Line(list2D.ElementAt(2), list2D.ElementAt(3),getColor()));
            listLine.Add(new Line(list2D.ElementAt(0), list2D.ElementAt(4), getColor()));
            listLine.Add(new Ellipse(list2D.ElementAt(7), list2D.ElementAt(0), list2D.ElementAt(1), getColor()));
            listLine.Add(new Ellipse(list2D.ElementAt(6), list2D.ElementAt(3), list2D.ElementAt(5), getColor()));
            return listLine;
        }

        public List<Point3D> getList3D()
        {
            return this.list;
        }

    }
}
