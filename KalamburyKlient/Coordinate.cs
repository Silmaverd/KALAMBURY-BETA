using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalamburyKlient
{
    public class Coordinate
    {
        public int X { set; get; }
        public int Y { set; get; }
        public bool toRemove { set; get; }

        public Coordinate()
        {
            this.toRemove = false;
        }
    }
}
