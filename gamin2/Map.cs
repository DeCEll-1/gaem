using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gamin2
{
    public class Map
    {

        private static List<List<Tile>> World = new List<List<Tile>>();// https://www.tutorialsteacher.com/csharp/csharp-jagged-array
        public static List<List<Tile>> GetMap()
        {
            return World;
        }

    }
}
