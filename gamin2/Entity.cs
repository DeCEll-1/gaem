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
            loc.X += x; loc.Y += y; return this;
        }
        public string GetID() { return ID; }


    }
}
