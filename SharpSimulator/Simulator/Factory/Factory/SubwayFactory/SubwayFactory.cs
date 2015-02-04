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
        }
        public override void init(string filePath)
        {
            Logger.LogChain.Message("intest", Logger.Level.SIMULATION_DEBUG);
            FileInfo fileInfo = new FileInfo(Directory.GetCurrentDirectory());
            JsonPath = fileInfo.FullName + @"\..\..\Resources\Simulations\"+filePath;
            try
            {
                MapFile = JObject.Parse(File.ReadAllText(JsonPath));
            }
            catch (Exception e)
            {
                Logger.LogChain.Message("FIle exception !!!  where is the Json Not in the kitchen", Logger.Level.SIMULATION_DEBUG);
                Logger.LogChain.Message("your current directory is" + fileInfo.FullName, Logger.Level.SIMULATION_DEBUG);
            };
            MapSize = MapFile.Map.size.x * MapFile.Map.size.y;
            MapX = MapFile.Map.size.x;
            MapY = MapFile.Map.size.y;
            Description = MapFile.Map.description;
            Name = MapFile.Map.name;
        }
        internal override List<AbstractAccess> GenerateAccess()
        {
            List<AbstractAccess> accesses = new List<AbstractAccess>();
            int acccessArrayLength = ((JArray)MapFile.Map.access).Count;
            for (int i = 0; i < acccessArrayLength; i++) {
                var tmpAccess = MapFile.Map.access[i];
                accesses.Add(new ConcretAccess((int)tmpAccess.from.x, (int) tmpAccess.from.y, (int)tmpAccess.to.x, (int) tmpAccess.to.y));
            }
            return accesses;
        }

        internal override AbstractArea[,] GenerateArea()
        {
            AbstractArea[,] areas = new AbstractArea[MapFile.Map.size.x, MapFile.Map.size.x];

            int framesArrayLength = ((JArray)MapFile.Map.frames).Count;
            for (int i = 0; i < framesArrayLength; i++)
            {
                var tmpFrame = MapFile.Map.frames[i];
                areas[tmpFrame.x, tmpFrame.y] = new Frame((int)tmpFrame.x, (int)tmpFrame.y, (bool) tmpFrame.blocked);
            }

            // check if all frames buf are filled
            for (int x = 0; x < MapX; x++)
            {
                for (int y = 0; y < MapY; y++)
                {
                    try{
                     if( areas[x, y] == null){
                        areas[x, y] = new Frame(x, y, true);
                     }

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
            String[,] textures = new String[MapFile.Map.size.x, MapFile.Map.size.x];

            int texturesArrayLength = ((JArray)MapFile.Map.textures).Count;
            for (int i = 0; i < texturesArrayLength; i++)
            {
                var tmpTexture = MapFile.Map.textures[i];
                textures[tmpTexture.x, tmpTexture.y] = tmpTexture.value ;
            }
            // check if all textures buf are filled
            for (int x = 0; x < MapX; x++)
            {
                for (int y = 0; y < MapY; y++)
                {
                    try{
                     if (textures[x, y] == null)
                     {
                        textures[x, y] = MapFile.Map.default_texture;
                     }
                    }catch(Exception e){
                        // fill missing textures with the deafault setting
                        textures[x, y] = MapFile.Map.default_texture;
                    }
                }
            }

            return textures;
        }

        internal override Dictionary<string,string> GenerateActions()
        {
            Dictionary<string,string> actions = new Dictionary<string,string>();
            int actionLength = ((JArray)MapFile.Map.actions).Count;

            for (int i = 0; i < actionLength; i++)
            {
                JObject curObject =  MapFile.Map.actions[i];
                 foreach (var property in curObject)
                 {
					Logger.LogChain.Message ("action Length" + property.Key.ToString(), Logger.Level.SIMULATION_DEBUG);
                     actions.Add(property.Key.ToString(), property.Value.ToString());
                 }
            }
            return actions;
        }
        internal override List<IFactionMember> GenerateEntities()
        {
            List<IFactionMember> entities = new List<IFactionMember>();
            int entitiesLength = ((JArray)MapFile.Map.entities).Count;
            for (int i = 0; i < entitiesLength; i++)
            {
                string entityClassName = MapFile.Map.entities[i].name;
                int x = MapFile.Map.entities[i].coords.x;
                int y = MapFile.Map.entities[i].coords.y; 
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
