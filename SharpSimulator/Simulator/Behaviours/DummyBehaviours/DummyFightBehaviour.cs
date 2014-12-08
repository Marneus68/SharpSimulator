using System;

namespace SharpSimulator
{
	public class DummyFightBehaviour : IFightBehaviour {
		public void Fight() {
			Logger.LogChain.Message("[Dummy fight behaviour called]", Logger.Level.SIMULATION_DEBUG);
		}
	}
}

