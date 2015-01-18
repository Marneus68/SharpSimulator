using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpSimulator.Area;
using SharpSimulator.Access;
using SharpSimulator.Factory;

namespace SharpSimulator.Map
{
     abstract class AbstractMap
    {
        internal AbstractArea[,] areaList;
        internal AbstractAccess [,] accessList;
        internal string [,] textures;
        internal AbstractMapFactory mapFactory;
        public abstract AbstractMap generateMap();
        internal abstract void AddArea();
        internal abstract void AddAccess();
        internal abstract void AddTexture();
    }
}
