using gamin2.Render;
using SIMp.Render;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSSystemGenerator.Render
{
    public class RendererBaseClass
    {
        public RendererBaseClass() { }

        public List<Drawable> Drawables = new List<Drawable>();

        public float zoomValue = 1f;

        public PointF center = new PointF(0, 0);

        public bool zooming { get; set; }

        public MouseEventArgs mouseEventArgs { get; set; }

        public bool reDraw = false;

    }
}
