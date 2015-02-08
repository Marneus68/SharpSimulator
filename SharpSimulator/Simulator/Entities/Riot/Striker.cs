using System;

namespace SharpSimulator {
	public class Striker : AEntity {
		public Striker () : base (null, "", "", "Striker") {
			Skin = "striker";
			FightBehaviour = (IFightBehaviour) new DummyFightBehaviour ();
			MoveBehaviour = (IMoveBehaviour) new DummyMoveBehaviour ();
			TalkBehaviour = (ITalkBehaviour) new DummyTalkBehaviour ();
			DisplayBehaviour = (IDisplayBehaviour) new DummyDisplayBehaviour ();
		}
	}
}
