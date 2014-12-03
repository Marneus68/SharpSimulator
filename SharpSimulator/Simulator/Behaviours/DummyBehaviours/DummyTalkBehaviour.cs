using System;

namespace SharpSimulator
{
	public class DummyTalkBehaviour : ITalkBehaviour {
		public string Talk(AEntity entity) {
			Console.WriteLine("[Dummy talk behaviour called]");
			Console.WriteLine(entity.ToString ());
			return "Dummy talk behviour";
		}
	}
}
