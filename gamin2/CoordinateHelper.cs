using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Xsl;

namespace gamin2
{
    public class CoordinateHelper
    {




        public static PointF ReturnRenderLocation(PointF loc, PictureBox Screen)
        {

            int screenHeight = Screen.Height;
            int screenWidth = Screen.Width;
            int tileSize = (int)screenHeight / 10;

            double sqrt3 = Math.Sqrt(3);

            float hexWidth = 3f / 2f * tileSize;
            float hexHeight = (float)(sqrt3 * tileSize);

            PointF xTransform = new PointF(hexWidth, hexHeight / 2f);
            PointF yTransform = new PointF(1f, hexHeight);

            PointF renderLoc = new PointF(
                        loc.X * xTransform.X,
                        loc.Y * yTransform.Y
            );

            renderLoc.Y += xTransform.Y * loc.X;

            renderLoc.X += hexWidth / 2f;
            renderLoc.Y += hexHeight / 2f;

            return renderLoc;
        }

    }
}
