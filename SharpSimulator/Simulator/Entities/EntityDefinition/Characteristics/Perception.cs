using System;

namespace SharpSimulator
{
	public class Perception : Characteristic
	{
		public Perception () : base() {}
		public Perception (System.Object obj = null) : base (obj) {}

		public static string Name { get; set; } = "Perception";

		public static string Description { get; set; } = "xxx";

		public static implicit operator Perception(int i) { return new Perception (i); }
		public static implicit operator Perception(uint i) { return new Perception (i); }
	}
}

