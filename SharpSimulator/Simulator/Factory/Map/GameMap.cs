﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpSimulator.Area;
using SharpSimulator.Access;
using SharpSimulator.Factory;

namespace SharpSimulator.Map
{
    class GameMap:AbstractMap
    {

        public GameMap(AbstractMapFactory factoryIn) {
            mapFactory = factoryIn;
        }

        public override AbstractMap generateMap(){
            AddArea();
            AddAccess();
            AddTexture();
            return this;
        }

        internal override void AddAccess()
        {
            accessList = mapFactory.GenerateAccess();
        }

        internal override void AddArea()
        {
            areaList = mapFactory.GenerateArea();
        }


        internal override void AddTexture(){
            textures = mapFactory.GenerateTextures();
        }
    }
}