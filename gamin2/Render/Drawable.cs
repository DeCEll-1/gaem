﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gamin2.Render
{
    public interface Drawable
    {
        void Draw(Graphics g,PointF Center);

    }
}
