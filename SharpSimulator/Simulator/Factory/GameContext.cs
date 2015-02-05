using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpSimulator.Map;
using SharpSimulator.Factory;

namespace SharpSimulator {
    public class GameContext {
		protected AbstractMap map = null;
			
		public String						Name 		{get {return map.Name;}}
		public String 						Description {get {return map.Description;}}
		public String 						MapWidth 	{get {return map.MapX.ToString();}}
		public String 						MapHeight 	{get {return map.MapY.ToString();}}
		public String 						MapSize 	{get {return map.MapSize.ToString();}}
		public Area.AbstractArea[,] 		AreaList 	{get {return map.AreaList;}}
		public List<Access.AbstractAccess> 	AccessList 	{get {return map.AccessList;}}
		public List<IFactionMember> 		EntityList 	{get {return map.EntityList;}}
		public Dictionary<string, string> 	Actions 	{get {return map.Actions;}}
		public string[,] 					Textures 	{get {return map.Textures;}}

		public void ChargeSimulation(AbstractMapFactory factoryIn, String jsonFilename) {
            factoryIn.init(jsonFilename);
			map = CreateGameMap(factoryIn);
		}

		public static AbstractMap CreateGameMap(AbstractMapFactory factoryIn) {
            return (new GameMap(factoryIn)).GenerateMap();
        }
    }
}
