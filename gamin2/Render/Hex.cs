using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gamin2.Render
{
    public class Hex : Drawable
    {
        public Hex(PointF loc, float size, float Thickness, Color Color)
        {
            this.Loc = loc;
            this.Size = size;
            this.Thickness = Thickness;
            this.Color = Color;
        }

        public Hex SetInteriorColor(Color InteriorColor)
        {
            this.InteriorColor = InteriorColor;
            this.Filled = true;
            return this;
        }

        public static PointF[] GetHexShape(PointF loc, float size)
        {
            var shape = new PointF[6];

            for (int a = 0; a < 6; a++)
            {
                shape[a] = new PointF(
                    loc.X + size * (float)Math.Cos(a * 60 * Math.PI / 180f),
                    loc.Y + size * (float)Math.Sin(a * 60 * Math.PI / 180f));
            }

            return shape;
        }

        public void Draw(Graphics g, PointF Center)
        {
            // https://stackoverflow.com/a/37236667/21149029

            if (Loc.X + Center.X < 0 || Loc.Y + Center.Y < 0) return;

            SolidBrush brush = new SolidBrush(
                InteriorColor
            );

            Pen pen = new Pen(Color, Thickness);

            PointF[] shape = GetHexShape(Loc, Size);

            if (Filled) g.FillPolygon(brush, shape);
            g.DrawPolygon(pen, shape);

        }

        public PointF Loc = new PointF(-1, -1);
        public float Size = -1;

        public float Thickness { get; }
        public Color Color { get; }
        public Color InteriorColor { get; set; }
        public bool Filled { get; set; }


    }
}
