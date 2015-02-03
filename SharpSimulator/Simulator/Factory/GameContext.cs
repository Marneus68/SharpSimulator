	using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpSimulator.Map;
using SharpSimulator.Factory;

namespace SharpSimulator
{
    public class GameContext
    {
		// TODO add error checking

		protected AbstractMap map;
		public AbstractMap Map {
			get {return map;}
			protected set {map = value;}
		}
			
		public String Name {get {return map.name;}}
		public String Description {get {return map.description;}}
		public String MapWidth {get {return map.mapX.ToString();}}
		public String MapHeight {get {return map.mapY.ToString();}}
		public String MapSize {get {return map.mapSize.ToString();}}
		// TOTO
		// and so on...

		// TODO
		// Finish this method by creating the underlying options in the factories on the abstract level.
		public void ChargeSimulation(AbstractMapFactory factoryIn, String jsonFilename) {
			Map = CreateGameMap(factoryIn);
		}

		public static AbstractMap CreateGameMap(AbstractMapFactory factoryIn) {
            return (new GameMap(factoryIn)).generateMap();
        }
    }
}
