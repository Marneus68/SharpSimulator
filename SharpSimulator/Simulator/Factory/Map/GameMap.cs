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
    public class GameMap:AbstractMap
    {

        public GameMap(AbstractMapFactory factoryIn) {
            MapFactory = factoryIn;
        }

        public override AbstractMap GenerateMap(){
            AddArea();
            AddAccess();
            AddTexture();
            AddActions();
            AddEntities();
            MapSize = MapFactory.MapSize;
            MapX = MapFactory.MapX;
            MapY = MapFactory.MapY;
            Name = MapFactory.Name;
            Description = MapFactory.Description;
            return this;
        }

        public override void AddAccess()
        {
            AccessList = MapFactory.GenerateAccess();
        }

        public override void AddArea()
        {
            AreaList = MapFactory.GenerateArea();
        }


        public override void AddTexture(){
            Textures = MapFactory.GenerateTextures();
        }

        public override void AddActions()
        {
            Actions = MapFactory.GenerateActions();
        }

        public override void AddEntities ()
        {
            EntityList = MapFactory.GenerateEntities();
        }
    }
}
