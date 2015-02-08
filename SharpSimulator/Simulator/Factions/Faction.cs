using System;
using System.Collections.Generic;

namespace SharpSimulator {
	public class Faction : IFactionMember {

		public enum Relation {
			NONE,
			IGNORANCE,
			APPRECIATION,
			INDIFERENCE,
			SUSPICION,
			PEACE,
			WAR
		};

		public static List<Faction> FactionsList = null;

		public string Name {get;set;}
		public Dictionary<string, Relation> Relationships = null;

		private List<IFactionMember> members;

		public Faction (string name = "Default Faction Name") {
			Console.WriteLine ("Faction constructor called");
			Name = name;
			members = new List<IFactionMember> ();

			//AddToFactionsList ();
		}

		~Faction() {
			Console.WriteLine ("Destructor called for Faction {0}", this.Name);
			/*
			if (FactionsList != null) {
				foreach (var f in FactionsList) {
					if (f.Name == Name) {
						FactionsList.Remove (f);
					}
				}
			}
			*/
		}

		/*
		protected void AddToFactionsList() {
			if (FactionsList == null)
				FactionsList = new List<Faction> ();
			FactionsList.Add (this);

			UpdateAllFactionsRelationships ();
		}
		*/

		public void SetRelashionship(string faction_name, Relation relation) {
			if (faction_name == this.Name)
				return;
			if (Relationships == null)
				Relationships = new Dictionary<string, Relation> ();
			Relationships [faction_name] = relation;
			UpdateRelationships ();
		}

		public Relation GetRelashionship(string faction_name) {
			if (Relationships.ContainsKey (faction_name))
				return(Relationships [faction_name]);
			else
				return Relation.NONE;
		}

		public void UpdateRelationships() {
			if (Relationships == null)
				Relationships = new Dictionary<string, Relation> ();
			Update ();
		}

		//public static void UpdateAllFactionsRelationships() {
		public void UpdateAllFactionsRelationships() {

		}

		public void Attach(IFactionMember member) {
			members.Add (member);
		}

		public void Detach(IFactionMember member) {
			members.Remove (member);
		}

		public void Update() {
			foreach (var member in members) {
				member.Update ();
			}
		}

		public void Step() {
			foreach (var member in members) {
				member.Step ();
			}
		}

		public bool CheckForEntityCollision(int x, int y) {
			foreach (var member in members) {
				if (member is AEntity) {
					if (((AEntity)member).x == x && ((AEntity)member).y == y)
						return true;
				}
			}
			return false;
		}
	}
}
