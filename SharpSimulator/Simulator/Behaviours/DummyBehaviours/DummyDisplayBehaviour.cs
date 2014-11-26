using System;

namespace SharpSimulator
{
	public class DummyDisplayBehaviour : IDisplayBehaviour {
		public void Display() {
			Console.WriteLine("[Dummy display behaviour called]");
		}
	}
}

