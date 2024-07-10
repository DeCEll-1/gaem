using gamin2.Render;
using System.Drawing;

namespace SSSystemGenerator.Render
{
    public class Line : Drawable
    {

        public Line()
        {
        }

        public Line(PointF from, PointF to, float Thickness, Color Color)
        {
            this.From = from;
            this.To = to;
            this.Thickness = Thickness;
            this.Color = Color;
        }

        public PointF From { get; }
        public PointF To { get; }
        public float Thickness { get; }
        public Color Color { get; }

        public void Draw(Graphics g, PointF Center)
        {
            if (
                From.X + Center.X < 0 || From.Y + Center.Y < 0
                && To.X + Center.X < 0 || To.Y + Center.Y < 0
                ) return;

            Pen pen = new Pen(Color, Thickness);

            g.DrawLine(pen, From, To);
        }
    }
}