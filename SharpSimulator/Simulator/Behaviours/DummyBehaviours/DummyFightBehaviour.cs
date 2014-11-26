using System;

namespace SharpSimulator
{
	public class DummyFightBehaviour : IFightBehaviour {
		public void Fight() {
			Console.WriteLine("[Dummy fight behaviour called]");
		}
	}
}

