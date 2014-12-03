using System;

namespace SharpSimulator
{
	public class Dexterity : Characteristic
	{
		static Dexterity() {
			Name = "Dexterity";
			Description = "xxx";
		}

		public Dexterity () : base() {}
		public Dexterity (System.Object obj = null) : base (obj) {}

		public static string Name { get; set; }
		public static string Description { get; set; }

		public static implicit operator Dexterity(int i) { return new Dexterity (i); }
		public static implicit operator Dexterity(uint i) { return new Dexterity (i); }
	}
}

