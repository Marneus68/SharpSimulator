using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpSimulator.Access;
using SharpSimulator.Area;
//using Newtonsoft.Json.Linq;
using System.IO;

using Newtonsoft.Json.Linq;

namespace SharpSimulator.Factory
{
    class SubwayFactory: AbstractMapFactory
    {

       
        public SubwayFactory() {

            FileInfo fileInfo = new FileInfo(Directory.GetCurrentDirectory());
            jsonPath = fileInfo.FullName + @"\..\..\Resources\subway.json";
            try
            {
            mapFile = JObject.Parse(File.ReadAllText(jsonPath));
            }
            catch (Exception e) {
                Console.WriteLine("FIle exception !!!  where is the Json Not in the kitchen");
                Console.WriteLine("your current directory is {0}", fileInfo.FullName);
            };
            mapSize = mapFile.Map.size.x * mapFile.Map.size.y;
        }
        internal override AbstractAccess[,] GenerateAccess()
        {
            AbstractAccess[,] accesses = new AbstractAccess[mapFile.Map.size.x, mapFile.Map.size.x];
            for (int i = 0; i < mapSize; i++) {
                var tmpAccess = mapFile.Map.frames[i];
                accesses[tmpAccess.x, tmpAccess.y] = new ConcretAccess((int)tmpAccess.x, (int) tmpAccess.y);
            }
            return accesses;
        }

        internal override AbstractArea[,] GenerateArea()
        {
            AbstractArea[,] areas = new AbstractArea[mapFile.Map.size.x, mapFile.Map.size.x];

            for (int i = 0; i < mapSize; i++)
            {
                var tmpFrame = mapFile.Map.frames[i];
                areas[tmpFrame.x, tmpFrame.y] = new Frame((int)tmpFrame.x, (int)tmpFrame.y, (bool) tmpFrame.blocked);
            }
            return areas;
        }

        internal override string[,] GenerateTextures()
        {
            String[,] textures = new String[mapFile.Map.size.x, mapFile.Map.size.x];

            for (int i = 0; i < mapSize; i++)
            {
                var tmpTexture = mapFile.Map.textures[i];
                textures[tmpTexture.x, tmpTexture.y] = tmpTexture.value ;
            }
            return textures;
        }
    }
}
