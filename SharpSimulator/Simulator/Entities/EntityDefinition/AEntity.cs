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

		public Strength		STR {get; protected set;} // Strength
		public Intelligence	INT {get; protected set;} // Intelligence
		public Dexterity	DEX {get; protected set;} // Dexterity
		public Defense		DEF {get; protected set;} // Defense
		public Charisma		CHA {get; protected set;} // Charisma
		public Perception	PER {get; protected set;} // Perception

		protected Faction faction;
		protected Faction.StatusEnum status = Faction.StatusEnum.INDIFERENCE;

		public AEntity (Faction _faction = null, string fname = "Random", string lname = "Peon", string nick = "") {
			FirstName			= fname;
			LastName			= lname;
			Nickname 			= nick;

			FightBehaviour		= null;
			MoveBehaviour		= null;
			TauntBehaviour		= null;
			DisplayBehaviour	= null;

			StructurePoints = 6;

			STR = 50;
			INT = 50;
			DEX = 50;
			DEF = 50;
			CHA = 50;
			PER = 50;

			faction = _faction;

			if (_faction != null) {
				_faction.Attach (this);
			}
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
				" Defense:" + DEF + " Charisma:" + CHA + " Perception:" + PER + ") Structure Points:" + StructurePoints;
			return ret;
		}
	}
}

