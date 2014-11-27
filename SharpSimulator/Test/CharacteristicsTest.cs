using System;
using NUnit.Framework;

namespace SharpSimulator
{
	[TestFixture]
	public class CharacteristicsTest {
		[Test]
		public void Strength_new () {
			Strength bc = new Strength ();
			Assert.AreEqual (0, bc);
		}
		[Test]
		public void Strength_new_from_int () {
			Strength bc = new Strength (50);
			Assert.AreEqual (50, bc);
		}
		[Test]
		public void Strength_new_from_int_overflow () {
			Strength bc = new Strength (150);
			Assert.AreEqual (100, bc);
		}
		[Test]
		public void Strength_new_from_int_underflow () {
			Strength bc = new Strength (-30);
			Assert.AreEqual (0, bc);
		}
		[Test]
		public void Strength_not_name () {
			Assert.AreNotEqual ("", Strength.Name);
		}
		[Test]
		public void Strength_name () {
			Assert.AreEqual ("Strength", Strength.Name);
		}
		[Test]
		public void Charisma_name () {
			Assert.AreEqual ("Charisma", Charisma.Name);
		}
		[Test]
		public void Defense_name () {
			Assert.AreEqual ("Defense", Defense.Name);
		}
		[Test]
		public void Dexterity_name () {
			Assert.AreEqual ("Dexterity", Dexterity.Name);
		}
		[Test]
		public void Intelligence_name () {
			Assert.AreEqual ("Intelligence", Intelligence.Name);
		}
		[Test]
		public void Perception_name () {
			Assert.AreEqual ("Perception", Perception.Name);
		}
	}
}

