using System;

namespace SharpSimulator {
	public class Commuter : AEntity {
		protected static readonly Random Random;

		String Sex;

		static Commuter() {
			Random = new Random();
		}

		public Commuter () : base (null, "", "", "Commuter") {
			Sex = (Random.Next (0, 2) == 0) ? "m" : "f";
			Skin = "man_" + Sex + "_" + Random.Next (1, 5);

			FightBehaviour = (IFightBehaviour) new DummyFightBehaviour ();
			MoveBehaviour = (IMoveBehaviour) new ErraticMoveBehaviour ();
			TalkBehaviour = (ITalkBehaviour) new DummyTalkBehaviour ();
			DisplayBehaviour = (IDisplayBehaviour) new DummyDisplayBehaviour ();
		}

		override public void Step() {
			Move ();
		}
	}
}

