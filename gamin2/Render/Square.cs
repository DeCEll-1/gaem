using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gamin2.Render
{
    public class Square : Drawable
    {

        public Square(PointF from, PointF to, float Thickness, Color Color)
        {
            this.TopLeft = from;
            this.BottomRight = to;
            this.Thickness = Thickness;
            this.Color = Color;
        }
        public Square SetInteriorColor(Color InteriorColor)
        {
            this.InteriorColor = InteriorColor;
            this.Filled = true;
            return this;
        }

        public void Draw(Graphics g, PointF Center)
        {
            if (
            TopLeft.X + Center.X < 0 || TopLeft.Y + Center.Y < 0
            && BottomRight.X + Center.X < 0 || BottomRight.Y + Center.Y < 0
            ) return;

            SolidBrush brush = new SolidBrush(
                InteriorColor
            );

            Pen pen = new Pen(Color, Thickness);

            //https://learn.microsoft.com/en-us/dotnet/api/system.drawing.rectanglef.-ctor?view=net-8.0
            Rectangle rect = new Rectangle(
                (int)TopLeft.X,                                      //The x-coordinate of the upper-left corner of the rectangle.
                (int)TopLeft.Y,                                      //The y-coordinate of the upper-left corner of the rectangle.
                Convert.ToInt32(-(TopLeft.X - BottomRight.X)),       //The width of the rectangle.
                Convert.ToInt32(-(TopLeft.X - BottomRight.X))        //The height of the rectangle.
                );

            if (Filled) g.FillRectangle(brush, rect);
            g.DrawRectangle(pen, rect);

        }

        public PointF TopLeft { get; }
        public PointF BottomRight { get; }
        public float Thickness { get; }
        public Color Color { get; }
        public Color InteriorColor { get; set; }
        public bool Filled { get; set; }

    }
}
