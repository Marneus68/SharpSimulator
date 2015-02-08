using System;

namespace SharpSimulator {
	public class Policeman : AEntity {
		public Policeman () : base (null, "", "", "Policeman") {
			Skin = "policeman";
			FightBehaviour = (IFightBehaviour) new DummyFightBehaviour ();
			MoveBehaviour = (IMoveBehaviour) new DummyMoveBehaviour ();
			TalkBehaviour = (ITalkBehaviour) new DummyTalkBehaviour ();
			DisplayBehaviour = (IDisplayBehaviour) new DummyDisplayBehaviour ();
		}
	}
}
