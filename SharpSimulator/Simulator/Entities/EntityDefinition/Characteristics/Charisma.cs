using System;

namespace SharpSimulator
{
	public class Charisma : Characteristic
	{
		static Charisma() {
			Name = "Charisma";
			Description = "xxx";
		}

		public Charisma () : base() {
		}
		public Charisma (System.Object obj = null) : base (obj) {}

		public static string Name { get; set; }
		public static string Description { get; set; }

		public static implicit operator Charisma(int i) { return new Charisma (i); }
		public static implicit operator Charisma(uint i) { return new Charisma (i); }
	}
}
