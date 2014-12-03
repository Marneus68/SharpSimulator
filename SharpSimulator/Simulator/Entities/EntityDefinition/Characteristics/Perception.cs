using System;

namespace SharpSimulator
{
	public class Perception : Characteristic
	{
		static Perception() {
			Name = "Perception";
			Description = "xxx";
		}

		public Perception () : base() {}
		public Perception (System.Object obj = null) : base (obj) {}

		public static string Name { get; set; }
		public static string Description { get; set; }

		public static implicit operator Perception(int i) { return new Perception (i); }
		public static implicit operator Perception(uint i) { return new Perception (i); }
	}
}

