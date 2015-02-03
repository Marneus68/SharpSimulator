using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpSimulator
{
    public class TestEntity:IFactionMember
    {        
        public int x { get; set; }
        public int y { get; set; }
        public TestEntity(string name = "toto")  {
		}

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
