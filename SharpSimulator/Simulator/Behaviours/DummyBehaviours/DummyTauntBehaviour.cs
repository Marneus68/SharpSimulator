using System;

namespace SharpSimulator
{
	public class DummyTauntBehaviour : ITauntBehaviour {
		public void Taunt(AEntity entity) {
			Console.WriteLine("[Dummy taunt behaviour called]");
			Console.WriteLine(entity.ToString ());
		}
	}
}

