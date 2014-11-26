using System;

namespace SharpSimulator
{
	public class DummyMoveBehaviour : IMoveBehaviour {
		public void Move() {
			Console.WriteLine("[Dummy move behaviour called]");
		}
	}
}

