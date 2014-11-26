using System;

namespace SharpSimulator {
	public abstract class AEntity : IFactionMember {
		public IFightBehaviour		FightBehaviour {get; set;}
		public IMoveBehaviour		MoveBehaviour {get; set;}
		public ITauntBehaviour		TauntBehaviour {get; set;}
		public IDisplayBehaviour	DisplayBehaviour {get; set;}

		public string 	FirstName {get; protected set;}
		public string 	LastName {get; protected set;}

		public string 	Nickname {get; protected set;}

		public uint 	StructurePoints {get; protected set;}

		public uint		STR {get; protected set;} // Strength
		public uint		INT {get; protected set;} // Intelligence
		public uint		DEX {get; protected set;} // Dexterity
		public uint		DEF {get; protected set;} // Defense
		public uint		CHA {get; protected set;} // Charisma
		public uint		PER {get; protected set;} // Perception

		protected Faction faction;
		protected Faction.StatusEnum status = Faction.StatusEnum.INDIFERENCE;

		public AEntity (string fname = "Random", string lname = "Peon", string nick = "") {
			FirstName			= fname;
			LastName			= lname;
			Nickname 			= nick;

			FightBehaviour		= null;
			MoveBehaviour		= null;
			TauntBehaviour		= null;
			DisplayBehaviour	= null;

			STR = 0;
			INT = 0;
			DEX = 0;
			DEF = 0;
			CHA = 0;
			PER = 0;
		}

		public void Fight () {
			if (FightBehaviour != null) {
				FightBehaviour.Fight ();
			}
		}

		public void Move () {
			if (MoveBehaviour != null) {
				MoveBehaviour.Move ();
			}
		}

		public void Taunt () {
			if (TauntBehaviour != null) {
				TauntBehaviour.Taunt (this);
			}
		}

		public void Display () {
			if (DisplayBehaviour != null) {
				DisplayBehaviour.Display ();
			}
		}

		public void Update () {
			status = faction.Status;
			Taunt ();
			Console.WriteLine("Current status:" + status.ToString().ToLower() + "\nCurrent faction: " + faction.Name);
		}

		override public string ToString() {
			string ret = "";
			if (Nickname != "")
				ret = FirstName + " \"" + Nickname + "\" " + LastName;
			else
				ret = FirstName + " " + LastName;

			ret = ret + " (Strenght:" + STR + " Intelligence:" + INT + " Dexterity:" + DEX +
			" Defense:" + DEF + " Charisma:" + CHA + " Perception:" + PER + ")";

			return ret;
		}
	}
}

