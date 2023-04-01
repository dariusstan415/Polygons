using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Polygons
{
    class Heptagon : PoligonR
    {
        public Heptagon()
        {
            _n = 7;
            _c = new Point(0, 0);
            for (int i = 0; i <= 6; i++)
                _points[i] = new Point(0, 0);
        }
        public Heptagon(PointF c, PointF p1) : base(7, c, p1)
        {

        }
    }
}
