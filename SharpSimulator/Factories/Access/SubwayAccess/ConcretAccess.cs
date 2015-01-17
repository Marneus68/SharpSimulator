using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpSimulator.Access
{
    class ConcretAccess:AbstractAccess
    {
        internal int coordX;
        internal int coordY;
        internal string name;
        public ConcretAccess(int x = 0, int y = 0, string nameIn = "basic access") {
            name = nameIn;
            coordX = x;
            coordY = y;
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
