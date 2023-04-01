using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Polygons
{
    class Patrat : PoligonR
    {
        public Patrat()
        {
            _n = 4;
            _r = 0;
            for (int i = 0; i <= 3; i++)
                _points[i] = new PointF(0, 0);
            _c = new PointF(0, 0);
        }
        public Patrat(PointF c, PointF p1) : base(4, c, p1)
        {

        }
    }
}
