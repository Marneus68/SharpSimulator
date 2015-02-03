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
     public abstract class AbstractMap
     {
         public string description;
         public string name;
         public int mapX;
         public int mapY;
         public int mapSize;
         public AbstractArea[,] areaList;
         public List<AbstractAccess> accessList;
         public List<IFactionMember> entityList;
         public Dictionary<string, string> actions;
         public string[,] textures;
         public AbstractMapFactory mapFactory;
         public abstract AbstractMap generateMap();
         internal abstract void AddArea();
         internal abstract void AddAccess();
         internal abstract void AddTexture();
         internal abstract void AddActions();
         internal abstract void AddEntities();
     }
}
