﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gamin2
{
    public class Tile
    {

        public Tile() { }
        public Tile SetLoc(PointF loc)
        {
            this.loc = loc;
            return this;
        }

        public Tile SetBackgroundColor(Color backgroundColor)
        {
            this.backgroundColor = backgroundColor;
            return this;
        }

        public Tile SetForegroundColor(Color foregroundColor)
        {
            this.foregroundColor = foregroundColor;
            return this;
        }

        public Tile SetCharacter(char character)
        {
            this.Character = character;
            return this;
        }

        public PointF loc = new PointF(-1, -1);
        public Color backgroundColor = Color.Black;
        public Color foregroundColor = Color.White;
        public char Character = 'X';

    }
}
