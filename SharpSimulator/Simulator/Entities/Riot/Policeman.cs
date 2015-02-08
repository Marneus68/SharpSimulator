using System;

namespace SharpSimulator {
	public class Policeman : AEntity {
		public Policeman () : base (null, "", "", "Policeman") {
			Skin = "policeman";
			FightBehaviour = (IFightBehaviour) new DummyFightBehaviour ();
			MoveBehaviour = (IMoveBehaviour) new ErraticMoveFightBehaviour ();
			TalkBehaviour = (ITalkBehaviour) new DummyTalkBehaviour ();
			DisplayBehaviour = (IDisplayBehaviour) new DummyDisplayBehaviour ();
		}

		override public void Step() {
			Move ();
		}
	}
}
