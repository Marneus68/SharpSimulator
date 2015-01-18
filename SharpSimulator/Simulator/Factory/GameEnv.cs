using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpSimulator.Map;
using SharpSimulator.Factory;

namespace SharpSimulator
{
    class GameEnv
    {
        internal AbstractMap gameMap;
        public GameEnv() { }
        public void initGame(String GameName){
            gameMap = this.CreateGameMap(new SubwayFactory());
        } 

        internal AbstractMap CreateGameMap(AbstractMapFactory factoryIn) {
            return (new GameMap(factoryIn)).generateMap();
        }
    }
}
