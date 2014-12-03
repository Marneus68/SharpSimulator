using System;

namespace SharpSimulator
{
	public class Perception : Characteristic
	{
		private void init() {
			Name = "Perception";
			Description = "xxx";
		}

		public Perception () : base() {init();}
		public Perception (System.Object obj = null) : base (obj) {init();}

		public static string Name { get; set; }
		public static string Description { get; set; }

		public static implicit operator Perception(int i) { return new Perception (i); }
		public static implicit operator Perception(uint i) { return new Perception (i); }
	}
}

