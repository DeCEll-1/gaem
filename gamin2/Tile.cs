using System;
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
            this.Loc = loc;
            return this;
        }

        public Tile SetBackgroundColor(Color backgroundColor)
        {
            this.BackgroundColor = backgroundColor;
            return this;
        }

        public Tile SetForegroundColor(Color foregroundColor)
        {
            this.ForegroundColor = foregroundColor;
            return this;
        }

        public Tile SetCharacter(char character)
        {
            this.Character = character;
            return this;
        }

        public PointF Loc = new PointF(-1, -1);
        public Color BackgroundColor = Color.Black;
        public Color ForegroundColor = Color.White;
        public char Character = 'X';
        public int CharacterSize = 64;

    }
}
