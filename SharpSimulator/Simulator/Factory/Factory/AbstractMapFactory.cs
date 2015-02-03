using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpSimulator.Area;
using SharpSimulator.Access;

namespace SharpSimulator.Factory
{
    public abstract class AbstractMapFactory:AbstractFactory
    {

        public string description;
        public string name;
        public int mapX;
        public int mapY;
        internal string jsonPath;
        internal dynamic mapFile;
        internal int mapSize;
        abstract internal AbstractArea[,] GenerateArea();
        abstract internal List<AbstractAccess> GenerateAccess();
        abstract internal string[,] GenerateTextures();
        abstract internal Dictionary<string, string> GenerateActions();
        abstract internal List<IFactionMember> GenerateEntities();
    }
}
