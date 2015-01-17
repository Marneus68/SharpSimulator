using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpSimulator.Area;
using SharpSimulator.Access;

namespace SharpSimulator.Factory
{
    abstract class AbstractMapFactory:AbstractFactory
    {
        internal string jsonPath;
        internal dynamic mapFile;
        internal int mapSize;
        abstract internal AbstractArea[,] GenerateArea();
        abstract internal AbstractAccess[,] GenerateAccess();
        abstract internal string[,] GenerateTextures();
    }
}
