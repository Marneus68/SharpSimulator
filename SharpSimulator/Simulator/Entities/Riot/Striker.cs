using System;

namespace SharpSimulator {
	public class Striker : AEntity {
		public Striker () : base (null, "", "", "Striker") {
			Skin = "striker";
			FightBehaviour = (IFightBehaviour) new DummyFightBehaviour ();
			MoveBehaviour = (IMoveBehaviour) new ErraticMoveBehaviour ();
			TalkBehaviour = (ITalkBehaviour) new StrikerTalkBehaviour ();
			DisplayBehaviour = (IDisplayBehaviour) new DummyDisplayBehaviour ();
		}

		override public void Step() {
			Move ();
			Talk ();
		}
	}
}
