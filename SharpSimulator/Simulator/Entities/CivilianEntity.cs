using System;

namespace SharpSimulator
{
	public class CivilianEntity : AEntity {
		public CivilianEntity (Faction _faction = null, string fname = "Random", string lname = "Peon", string nick = "") : base(_faction, fname, lname, nick) {
			FightBehaviour = (IFightBehaviour) new DummyFightBehaviour ();
			MoveBehaviour = (IMoveBehaviour) new DummyMoveBehaviour ();
			TauntBehaviour = (ITauntBehaviour) new DummyTauntBehaviour ();
			DisplayBehaviour = (IDisplayBehaviour) new DummyDisplayBehaviour ();
		}
	}
}

