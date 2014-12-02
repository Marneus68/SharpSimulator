using NUnit.Framework;
using System;

namespace SharpSimulator
{
	[TestFixture ()]
	public class FactionTest {
		[Test ()]
		public void FactionInstance () {
			Faction f = new Faction ("Foo");
			Assert.AreEqual ("Foo", f.Name);
			Faction.FactionsList.Clear ();
		}
		[Test ()]
		public void FactionsList () {
			Faction ff = new Faction ("Foo");
			Faction fb = new Faction ("Bar");
			Faction ft = new Faction ("Too");
			Assert.AreEqual (3, Faction.FactionsList.Count);
			Faction.FactionsList.Clear ();
		}
		[Test ()]
		public void FactionsRelationships () {
			Faction ff = new Faction ("Foo");
			Faction fb = new Faction ("Bar");
			Faction ft = new Faction ("Too");
			Assert.AreEqual (3, ff.Relationships.Count);
			Faction.FactionsList.Clear ();
		}
		[Test ()]
		public void FactionsDefaultRelationshipsCheck () {
			Faction ff = new Faction ("Foo");
			Faction ft = new Faction ("Too");
			Assert.AreEqual (Faction.Relation.IGNORANCE, ff.GetRelashionship(ft.Name));
			Faction.FactionsList.Clear ();
		}
		[Test ()]
		public void FactionsRelationshipsCheck () {
			Faction ff = new Faction ("Foo");
			Faction ft = new Faction ("Too");
			ff.SetRelashionship (ft.Name, Faction.Relation.WAR);
			Assert.AreEqual (Faction.Relation.WAR, ff.GetRelashionship(ft.Name));
			Faction.FactionsList.Clear ();
		}
	}
}

