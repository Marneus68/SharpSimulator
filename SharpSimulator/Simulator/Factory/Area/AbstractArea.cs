using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpSimulator.Area
{
    public abstract class AbstractArea
    {
        public int CoordX;
		public int CoordY;
        public string name;
        public bool Blocked;
         string Name{set; get;}
    }
}
