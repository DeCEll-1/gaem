using gamin2.Render;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMp.Render
{
    public class Text : Drawable
    {

        public Text(string text, Font font, Brush brush, PointF loc)
        {
            this.String = text;
            this.Font = font;
            this.Brush = brush;
            this.Loc = loc;

        }

        public string String { get; set; }

        public Font Font { get; set; }

        public Brush Brush { get; set; }

        public PointF Loc { get; set; }

        public void Draw(Graphics g, PointF Center)
        {
            if (Loc.X + Center.X < 0 || Loc.Y + Center.Y < 0) return;

            SizeF stringSize = g.MeasureString(String, Font);

            PointF locToUse = new PointF(Loc.X - (stringSize.Width / 2f), Loc.Y - (stringSize.Height / 2f));

            g.DrawString(String, Font, Brush, locToUse);
        }
    }
}
