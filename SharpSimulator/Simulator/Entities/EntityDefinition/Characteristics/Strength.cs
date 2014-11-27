using System;

namespace SharpSimulator
{
	public class Strength : Characteristic
	{
		public Strength () : base() {}
		public Strength (System.Object obj = null) : base (obj) {}

		public static string Name { get; set; } = "Strength";
		 
		public static string Description { get; set; } = "xxx";

		public static implicit operator Strength(int i) { return new Strength (i); }
		public static implicit operator Strength(uint i) { return new Strength (i); }
	}
}

