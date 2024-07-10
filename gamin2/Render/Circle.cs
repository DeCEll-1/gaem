using gamin2.Render;
using SIMp.Render;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SSSystemGenerator.Render
{
    public class Circle : Drawable
    {
        public Circle() { }

        public Circle(PointF center, int radius, List<CircleBorders> borders, Color fillColor, bool filled)
        {
            Center = center;
            Radius = radius;
            Borders = borders;
            this.Borders = borders;
            InteriorColor = fillColor;
            Filled = filled;

            topLeft = new PointF(center.X - radius, center.Y - radius);

            topRight = new PointF(center.X + radius, center.Y + radius);

            bottomLeft = new PointF(center.X - radius, center.Y - radius);

            bottomRight = new PointF(center.X + radius, center.Y - radius);

        }

        public PointF Center { get; }

        public PointF topLeft { get; set; }
        public PointF topRight { get; set; }
        public PointF bottomLeft { get; set; }
        public PointF bottomRight { get; set; }

        public float Radius { get; }

        public List<CircleBorders> Borders { get; set; }

        public Color InteriorColor { get; }
        public bool Filled { get; }

        public void Draw(Graphics g, PointF Center)
        {
            if (Center.X + Center.X < 0 || Center.Y + Center.Y < 0) return;


            SolidBrush brush = new SolidBrush(
                InteriorColor
                );

            //https://learn.microsoft.com/en-us/dotnet/api/system.drawing.rectanglef.-ctor?view=net-8.0
            RectangleF ect = new RectangleF(
                topLeft.X,                       //The x-coordinate of the upper-left corner of the rectangle.
                topLeft.Y,                       //The y-coordinate of the upper-left corner of the rectangle.
                Convert.ToInt32(Radius * 2),     //The width of the rectangle.
                Convert.ToInt32(Radius * 2)      //The height of the rectangle.
                );

            if (Filled)
            {
                g.FillEllipse(brush, ect);//draw a filled }

                Borders.ForEach(border =>
                {


                    //https://learn.microsoft.com/en-us/dotnet/api/system.drawing.rectanglef.-ctor?view=net-8.0
                    RectangleF ectForBorder = new RectangleF(
                        Center.X - border.radius,        //The x-coordinate of the upper-left corner of the rectangle.
                        Center.Y - border.radius,        //The y-coordinate of the upper-left corner of the rectangle.
                        Convert.ToInt32(border.radius * 2),     //The width of the rectangle.
                        Convert.ToInt32(border.radius * 2)      //The height of the rectangle.
                        );


                    Pen pen = new Pen(border.color, border.thickness);


                    g.DrawEllipse(pen, ectForBorder);//draw the outline regardless if its filled or not

                });
            }
        }
    }
}
