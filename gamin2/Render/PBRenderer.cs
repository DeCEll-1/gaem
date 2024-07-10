using gamin2.Render;
using SIMp.Render;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSSystemGenerator.Render
{
    public class PBRenderer
    {

        #region variables

        private PictureBox PB { get; set; }

        private int Height { get; set; }

        private int Width { get; set; }

        private Point Center { get; set; }

        #region locations

        private Point topLeft { get; set; }
        private Point topRight { get; set; }
        private Point bottomLeft { get; set; }
        private Point bottomRight { get; set; }

        #endregion

        public Color BackgroundColor { get; set; } = Color.White;

        private PaintEventArgs PaintEventArgs { get; set; }

        public RendererBaseClass rendererValues { get; set; } = new RendererBaseClass();

        #endregion

        public PBRenderer(PictureBox panel, PaintEventArgs paintEventArgs)
        {
            panel.Paint += new PaintEventHandler(Render);

            this.PB = panel;
            this.Height = panel.Height;
            this.Width = panel.Width;

            this.Center = new Point(Width / 2, Height / 2);

            this.PaintEventArgs = paintEventArgs;


            topLeft = new Point(0, Height);
            topRight = new Point(Width, Height);
            bottomLeft = new Point(0, 0);
            bottomRight = new Point(Width, 0);


        }

        public void Render() { Render(PB, PaintEventArgs); }


        public void Render(object sender, PaintEventArgs e)
        {
            //using (Graphics g = e.Graphics)
            //{

            Graphics g = e.Graphics;

            try
            {
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
                //g values crashes with System.ArgumentException for god knows why
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Low;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighSpeed;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
                //g.RenderingOrigin = new Point(-500, -500);
            }
            catch (Exception ex)
            {
                return;
            }

            Matrix transform = new Matrix();

            try
            {


                transform.Translate(rendererValues.center.X, rendererValues.center.Y);

                transform.Scale(rendererValues.zoomValue, rendererValues.zoomValue);
                //oh wow when its 0 it gives argument exception beacuse its dumb enough to not check if it can / things by 0 wonderfull
                //or something like that

                //transform.RotateAt(90, new Point(500, 500));

                g.Transform = transform.Clone();

                //g.Transform = transform;



            }
            catch (Exception ex)
            {
            }

            //Panel.Scale(new SizeF(rendererValues.zoomValue, rendererValues.zoomValue));

            //if (!rendererValues.reDraw) return;

            g.Clear(BackgroundColor);

            foreach (Drawable item in rendererValues.Drawables)
            {
                item.Draw(g, Center);
            }
        }

        //}

        public Point GetCenter()
        {
            return Center;
        }

        public int GetHeight() { return Height; }

        public int GetWidth() { return Width; }

    }
}
