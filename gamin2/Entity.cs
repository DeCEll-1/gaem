using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gamin2
{
    public class Entity : Tile
    {

        public Entity(string ID) { this.ID = ID; }
        private string ID { get; set; }

        public Entity Move(int x, int y)
        {
            Loc.X += x; Loc.Y += y; return this;
        }
        public string GetID() { return ID; }


    }
}
