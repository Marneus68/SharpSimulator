using System;

namespace SharpSimulator
{
	public class DummyDisplayBehaviour : IDisplayBehaviour {
		public void Display() {
			Logger.LogChain.Message("[Dummy display behaviour called]", Logger.Level.SIMULATION_DEBUG);
		}
	}
}

