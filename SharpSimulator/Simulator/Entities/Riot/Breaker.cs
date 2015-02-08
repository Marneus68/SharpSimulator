using System;

namespace SharpSimulator {
	public class Breaker : AEntity {
		public Breaker () : base (null, "", "", "Breaker") {
			Skin = "breaker";
			FightBehaviour = (IFightBehaviour) new DummyFightBehaviour ();
			MoveBehaviour = (IMoveBehaviour) new DummyMoveBehaviour ();
			TalkBehaviour = (ITalkBehaviour) new DummyTalkBehaviour ();
			DisplayBehaviour = (IDisplayBehaviour) new DummyDisplayBehaviour ();
		}
	}
}
