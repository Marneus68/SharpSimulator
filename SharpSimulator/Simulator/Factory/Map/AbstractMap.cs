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
         public string Description;
         public string Name;
         public int MapX;
         public int MapY;
         public int MapSize;
         public AbstractArea[,] AreaList;
         public List<AbstractAccess> AccessList;
		public List<AEntity> EntityList;
         public Dictionary<string, string> Actions;
         public string[,] Textures;
         public AbstractMapFactory MapFactory;
         public abstract AbstractMap GenerateMap();
         public abstract void AddArea();
         public abstract void AddAccess();
         public abstract void AddTexture();
         public abstract void AddActions();
         public abstract void AddEntities();
     }
}
