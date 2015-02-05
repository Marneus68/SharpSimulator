using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpSimulator.Access
{
    public class ConcretAccess:AbstractAccess
    {
        public int CoordX1;
        public int CoordY1;
        public int CoordX2;
        public int CoordY2;
        public string Name;
        public ConcretAccess(int x1 = 0, int y1 = 0, int x2 = 0, int y2 = 0, string nameIn = "basic access"){
            Name = nameIn;
            CoordX1 = x1;
            CoordY1 = y1;
            CoordX2 = x2;
            CoordY2 = y2;
        }

        string AbstractAccess.Name
        {
            get
            {
                return Name;
            }
            set
            {

                Name = value;
            }
        }
    }
}
