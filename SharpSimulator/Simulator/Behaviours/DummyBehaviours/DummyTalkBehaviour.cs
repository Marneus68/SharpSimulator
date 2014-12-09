using System;

namespace SharpSimulator
{
	public class DummyTalkBehaviour : ITalkBehaviour {
		public string Talk(AEntity entity) {
			Logger.LogChain.Message("[Dummy talk behaviour called] : " + entity.ToString(), Logger.Level.SIMULATION_DEBUG);
			return "Dummy talk behviour";
		}
	}
}
