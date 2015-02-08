using System;

namespace SharpSimulator {
	public class FighterEntity : AEntity {
		public FighterEntity () : this (null, "Random", "Peon", "") {

		}

		public FighterEntity (Faction _faction = null, string fname = "Random", string lname = "Peon", string nick = "") : base(_faction, fname, lname, nick) {
			FightBehaviour = (IFightBehaviour) new DummyFightBehaviour ();
			MoveBehaviour = (IMoveBehaviour) new DummyMoveBehaviour ();
			TalkBehaviour = (ITalkBehaviour) new DummyTalkBehaviour ();
			DisplayBehaviour = (IDisplayBehaviour) new DummyDisplayBehaviour ();

			StructurePoints = 8;
		}

		override public void Step() {

		}
	}
}

