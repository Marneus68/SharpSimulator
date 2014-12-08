using System;

namespace SharpSimulator
{
	public class DummyMoveBehaviour : IMoveBehaviour {
		public void Move() {
			Logger.LogChain.Message("[Dummy move behaviour called]", Logger.Level.SIMULATION_DEBUG);
		}
	}
}

