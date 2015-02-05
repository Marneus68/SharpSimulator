using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SharpSimulator.Factory;

namespace SharpSimulator.Test
{
	[TestFixture ()]
    class FactoryTestBis
    {
        [Test()]
		public void FactorySubwayTextures () {
            GameContext env = new GameContext();
            env.ChargeSimulation(new SubwayFactory(),"Subway.json");
			Assert.AreEqual ("black",env.Textures[1,3]);
        }

        [Test()]
        public void FactorySubwayActions()
        {
            GameContext env = new GameContext();
            env.ChargeSimulation(new SubwayFactory(),"Subway.json");
            string testVal = null;
            env.Actions.TryGetValue("Play", out testVal);
            Assert.AreEqual("play", testVal);
        }

        [Test()]
        public void FactorySubwayEntity()
        {
            GameContext env = new GameContext();
            env.ChargeSimulation(new SubwayFactory(),"Subway.json");
            TestEntity tempEntity = env.EntityList.ElementAt(0) as TestEntity;
            Assert.AreEqual(typeof(TestEntity), tempEntity.GetType());
        }
    }
}
