using System;
using System.Collections.Generic;

namespace SharpSimulator {
	public class Faction {
		public enum StatusEnum {
			INDIFERENCE,
			PEACE,
			SUSPICION,
			WAR
		};

		public StatusEnum Status {get;set;}
		public string Name {get;set;}

		private List<IFactionMember> members;

		public Faction (string name = "Default Faction Name"){
			Name = name;
			members = new List<IFactionMember> ();
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
	}
}

