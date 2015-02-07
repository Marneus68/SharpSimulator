using System;
using System.Collections.Generic;

namespace SharpSimulator {
	public abstract class AEntity : IFactionMember {
		public IFightBehaviour		FightBehaviour {get; set;}
		public IMoveBehaviour		MoveBehaviour {get; set;}
		public ITalkBehaviour		TalkBehaviour {get; set;}
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

		public int x; 
		public int y;

		protected Faction faction = null;
		public Faction Faction { 
			get { return faction; } 
			set{ faction = value; Update (); }
		}
		public Dictionary<string, Faction.Relation> Relationships;

		public AEntity() : this(null, "Random", "Peon", "") {

		}

		public AEntity (Faction faction = null, string fname = "Random", string lname = "Peon", string nick = "") {
			FirstName			= fname;
			LastName			= lname;
			Nickname 			= nick;

			FightBehaviour		= null;
			MoveBehaviour		= null;
			TalkBehaviour		= null;
			DisplayBehaviour	= null;

			StructurePoints = 6;

			STR = 50;
			INT = 50;
			DEX = 50;
			DEF = 50;
			CHA = 50;
			PER = 50;

			if (faction != null) {
				Faction = faction;
				Faction.Attach (this);
				Relationships = Faction.Relationships;
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

		public string Talk () {
			if (TalkBehaviour != null) {
				return TalkBehaviour.Talk (this);
			}
			return "";
		}

		public void Display () {
			if (DisplayBehaviour != null) {
				DisplayBehaviour.Display ();
			}
		}

		public void Update () {
			if (Faction != null)
				Relationships = Faction.Relationships;
			/*
			List<string> war = new List<string> ();
			List<string> peace = new List<string> ();
			List<string> distrust = new List<string> ();
			List<string> appreciation = new List<string> ();
			//List<string> ignorance = 

			foreach (var kp in Relationships) {
				if (kp.Key.Equals( Faction.Relation.WAR )) {
					war.Add (kp.Key);
				} else if (kp.Key.Equals( Faction.Relation.PEACE)) {
					peace.Add (kp.Key);
				} else if (kp.Key.Equals( Faction.Relation.APPRECIATION)) {
					appreciation.Add (kp.Key);
				} else if (kp.Key.Equals( Faction.Relation.SUSPICION)) {
					distrust.Add (kp.Key);
				}
			}

			Console.WriteLine ("We are at war with {0}", TextUtils.StringListToString(war));
			Console.WriteLine ("We are in peace with {0}", TextUtils.StringListToString(peace));
			Console.WriteLine ("We shouldn't trust {0}", TextUtils.StringListToString(distrust));
			Console.WriteLine ("{0}", TextUtils.StringListToString(appreciation));
			*/
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
