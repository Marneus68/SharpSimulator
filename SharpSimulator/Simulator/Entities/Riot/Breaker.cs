using System;

namespace SharpSimulator {
	public class Breaker : AEntity {
		public Breaker () : base (null, "", "", "Breaker") {
			Skin = "breaker";
			FightBehaviour = (IFightBehaviour) new DummyFightBehaviour ();
			MoveBehaviour = (IMoveBehaviour) new ErraticMoveFightBehaviour ();
			TalkBehaviour = (ITalkBehaviour) new BreakerTalkBehaviour ();
			DisplayBehaviour = (IDisplayBehaviour) new DummyDisplayBehaviour ();
		}

		override public void Step() {
			Move ();
			Talk ();
		}
	}
}
