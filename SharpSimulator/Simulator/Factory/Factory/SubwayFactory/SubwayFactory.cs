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

namespace SharpSimulator.Factory {
    public class SubwayFactory : AbstractMapFactory {
        public SubwayFactory() {

            Console.WriteLine("intest");
            FileInfo fileInfo = new FileInfo(Directory.GetCurrentDirectory());
            jsonPath = fileInfo.FullName + @"\..\..\Resources\Simulations\Subway.json";
            try
            {
            mapFile = JObject.Parse(File.ReadAllText(jsonPath));
            }
            catch (Exception e) {
                Console.WriteLine("FIle exception !!!  where is the Json Not in the kitchen");
                Console.WriteLine("your current directory is {0}", fileInfo.FullName);
            };
            mapSize = mapFile.Map.size.x * mapFile.Map.size.y;
            mapX = mapFile.Map.size.x;
            mapY = mapFile.Map.size.y;
            description = mapFile.Map.description;
            name = mapFile.Map.name;
        }
        internal override List<AbstractAccess> GenerateAccess()
        {
            List<AbstractAccess> accesses = new List<AbstractAccess>();
            int acccessArrayLength = ((JArray)mapFile.Map.access).Count;
            for (int i = 0; i < acccessArrayLength; i++) {
                var tmpAccess = mapFile.Map.access[i];
                accesses.Add(new ConcretAccess((int)tmpAccess.from.x, (int) tmpAccess.from.y, (int)tmpAccess.to.x, (int) tmpAccess.to.y));
            }
            return accesses;
        }

        internal override AbstractArea[,] GenerateArea()
        {
            AbstractArea[,] areas = new AbstractArea[mapFile.Map.size.x, mapFile.Map.size.x];

            int framesArrayLength = ((JArray)mapFile.Map.frames).Count;
            for (int i = 0; i < framesArrayLength; i++)
            {
                var tmpFrame = mapFile.Map.frames[i];
                areas[tmpFrame.x, tmpFrame.y] = new Frame((int)tmpFrame.x, (int)tmpFrame.y, (bool) tmpFrame.blocked);
            }

            // check if all frames buf are filled
            for (int x = 0; x < mapX; x++)
            {
                for (int y = 0; y < mapY; y++)
                {
                    try{
                     var tmpFrame = areas[x, y];
                    }catch(Exception e){
                        // block the default frame because decor
                        areas[x, y] = new Frame(x, y, true);
                    }
                }
            }

            return areas;
        }

        internal override string[,] GenerateTextures()
        {
            String[,] textures = new String[mapFile.Map.size.x, mapFile.Map.size.x];

            int texturesArrayLength = ((JArray)mapFile.Map.textures).Count;
            for (int i = 0; i < texturesArrayLength; i++)
            {
                var tmpTexture = mapFile.Map.textures[i];
                textures[tmpTexture.x, tmpTexture.y] = tmpTexture.value ;
            }
            // check if all textures buf are filled
            for (int x = 0; x < mapX; x++)
            {
                for (int y = 0; y < mapY; y++)
                {
                    try{
                     var tmpFrame = textures[x, y];
                    }catch(Exception e){
                        // fill missing textures with the deafault setting
                        textures[x, y] = mapFile.Map.default_texture;
                    }
                }
            }

            return textures;
        }

        internal override Dictionary<string,string> GenerateActions()
        {
            Dictionary<string,string> actions = new Dictionary<string,string>();
            int actionLength = ((JArray)mapFile.Map.actions).Count;

            for (int i = 0; i < actionLength; i++)
            {
                JObject curObject =  mapFile.Map.actions[i];
                 foreach (var property in curObject)
                 {
                     Console.WriteLine("action Length" + property.Key.ToString());
                     actions.Add(property.Key.ToString(), property.Value.ToString());
                 }
            }
            return actions;
        }
        internal override List<IFactionMember> GenerateEntities()
        {
            List<IFactionMember> entities = new List<IFactionMember>();
            int entitiesLength = ((JArray)mapFile.Map.entities).Count;
            for (int i = 0; i < entitiesLength; i++)
            {
                string entityClassName = mapFile.Map.entities[i].name;
                int x = mapFile.Map.entities[i].coords.x;
                int y = mapFile.Map.entities[i].coords.y; 
                IFactionMember entityInstance = (IFactionMember)Activator.CreateInstance(Type.GetType(entityClassName), "test");
                TestEntity tmptrueType = entityInstance as TestEntity;
                tmptrueType.x = x;
                tmptrueType.y = y;
                entities.Add(entityInstance);
            }
            return entities;
        }

    }
}
