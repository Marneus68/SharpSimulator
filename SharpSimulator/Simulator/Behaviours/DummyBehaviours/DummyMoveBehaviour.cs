using System;

namespace SharpSimulator
{
	public class DummyMoveBehaviour : IMoveBehaviour {
		public void Move(AEntity entity) {
			Logger.LogChain.Message("[Dummy move behaviour called]", Logger.Level.SIMULATION_DEBUG);
		}
	}
}

