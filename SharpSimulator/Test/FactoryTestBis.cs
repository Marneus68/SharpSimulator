using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SharpSimulator.Test
{
	[TestFixture ()]
    class FactoryTestBis
    {
        [Test()]
		public void FactorySubwayTextures () {
			/*
            GameEnv env = new GameEnv();
            env.initGame("test");
			Assert.AreEqual ("black",env.gameMap.textures[2,3]);
        	*/
        }

        [Test()]
        public void FactorySubwayActions()
        {
			/*
            GameEnv env = new GameEnv();
            env.initGame("test");
            string testVal = null;
            env.gameMap.actions.TryGetValue("Play", out testVal);
            Assert.AreEqual("play", testVal);
            */
        }

        [Test()]
        public void FactorySubwayEntity()
        {
			/*
            GameEnv env = new GameEnv();
            env.initGame("test");
            string testVal = null;
            TestEntity tempEntity = env.gameMap.entityList.ElementAt(0) as TestEntity;
            Assert.AreEqual(typeof(TestEntity), tempEntity.GetType());
            */
        }
    }
}
