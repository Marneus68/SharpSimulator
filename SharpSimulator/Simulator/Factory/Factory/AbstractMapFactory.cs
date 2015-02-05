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

        public string Description;
        public string Name;
        public int MapX;
        public int MapY;
        public string JsonPath;
        public dynamic MapFile;
        public int MapSize;
        abstract internal AbstractArea[,] GenerateArea();
        abstract public void init(string filePath);
        abstract internal List<AbstractAccess> GenerateAccess();
        abstract internal string[,] GenerateTextures();
        abstract internal Dictionary<string, string> GenerateActions();
        abstract internal List<IFactionMember> GenerateEntities();
    }
}
