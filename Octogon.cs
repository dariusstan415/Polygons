using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Polygons
{
    class Octogon : PoligonR
    {
        public Octogon()
        {
            _n = 8;
            _c = new Point(0, 0);
            for (int i = 0; i <= 7; i++)
                _points[i] = new Point(0, 0);
        }
        public Octogon(PointF c, PointF p1) : base(8, c, p1)
        {

        }
    }
}
