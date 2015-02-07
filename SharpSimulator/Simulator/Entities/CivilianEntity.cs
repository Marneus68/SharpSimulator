using System;

namespace SharpSimulator
{
	public class CivilianEntity : AEntity {
		public CivilianEntity() : this(null, "Random", "Peon", "") {

		}

		public CivilianEntity (Faction _faction = null, string fname = "Random", string lname = "Peon", string nick = "") : base(_faction, fname, lname, nick) {
			FightBehaviour = (IFightBehaviour) new DummyFightBehaviour ();
			MoveBehaviour = (IMoveBehaviour) new DummyMoveBehaviour ();
			TalkBehaviour = (ITalkBehaviour) new DummyTalkBehaviour ();
			DisplayBehaviour = (IDisplayBehaviour) new DummyDisplayBehaviour ();
		}
	}
}

