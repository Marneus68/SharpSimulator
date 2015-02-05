using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpSimulator.Area
{
    public class Wall:Frame
    {
        public Wall(int x = 0, int y = 0, string nameIn = "mur") : base(x, y, true, nameIn) {
        }
    }
}
