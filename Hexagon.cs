using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Polygons
{
    class Hexagon : PoligonR
    {
        public Hexagon()
        {
            _n = 6;
            _c = new Point(0, 0);
            for (int i = 0; i <= 5; i++)
                _points[i] = new Point(0, 0);
        }

        public Hexagon(PointF c, PointF p1) : base(6, c, p1)
        {

        }
    }
}
