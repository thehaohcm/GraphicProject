using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicProject
{
    class Point3D
    {
        int x, y, z;
        public Point3D(int x,int y,int z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public int X
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }

            set
            {
                y = value;
            }
        }

        public int Z
        {
            get
            {
                return z;
            }

            set
            {
                z = value;
            }
        }
    }
}
