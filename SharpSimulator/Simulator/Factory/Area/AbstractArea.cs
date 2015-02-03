using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpSimulator.Area
{
    public abstract class AbstractArea
    {
        internal int coordX;
        internal int coordY;
        internal string name;
        internal bool blocked;
         string Name{set; get;}
    }
}
