using System;

namespace SharpSimulator
{
	public class Strength : Characteristic
	{
		private void init() {
			Name = "Strength";
			Description = "xxx";
		}

		public Strength () : base() {init();}
		public Strength (System.Object obj = null) : base (obj) {init();}

		public static string Name { get; set; }
		public static string Description { get; set; }

		public static implicit operator Strength(int i) { return new Strength (i); }
		public static implicit operator Strength(uint i) { return new Strength (i); }
	}
}

