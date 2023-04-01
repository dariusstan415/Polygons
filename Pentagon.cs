using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Polygons
{
    class Pentagon : PoligonR
    {
        public Pentagon()
        {
            _n = 5;
            _c = new Point(0, 0);
            for (int i = 0; i <= 4; i++)
                _points[i] = new Point(0, 0);
        }

        public Pentagon(PointF c, PointF p1) : base(5, c, p1)
        {

        }
    }
}
