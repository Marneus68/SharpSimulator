using System;

namespace SharpSimulator
{
	public class Dexterity : Characteristic
	{
		public Dexterity () : base() {}
		public Dexterity (System.Object obj = null) : base (obj) {}

		public static string Name { get; set; } = "Dexterity";

		public static string Description { get; set; } = "xxx";

		public static implicit operator Dexterity(int i) { return new Dexterity (i); }
		public static implicit operator Dexterity(uint i) { return new Dexterity (i); }
	}
}

