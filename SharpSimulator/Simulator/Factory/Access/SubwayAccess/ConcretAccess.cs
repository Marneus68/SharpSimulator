using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpSimulator.Access
{
    public class ConcretAccess:AbstractAccess
    {
        internal int coordX1;
        internal int coordY1;
        internal int coordX2;
        internal int coordY2;
        internal string name;
        public ConcretAccess(int x1 = 0, int y1 = 0, int x2 = 0, int y2 = 0, string nameIn = "basic access"){
            name = nameIn;
            coordX1 = x1;
            coordY1 = y1;
            coordX2 = x2;
            coordY2 = y2;
        }

        string AbstractAccess.Name
        {
            get
            {
                return name;
            }
            set
            {

                name = value;
            }
        }
    }
}
