using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpSimulator.Area
{
    class Frame: AbstractArea
    {

        public Frame(int x = 0, int y = 0, bool blockedIn = true, string nameIn = "simple case") {
            coordX = x;
            coordY = y;
            blocked = blockedIn;
            name = nameIn;
        }

    }
}
