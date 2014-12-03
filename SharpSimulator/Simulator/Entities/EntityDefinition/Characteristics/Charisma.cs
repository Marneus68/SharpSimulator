using System;

namespace SharpSimulator
{
	public class Charisma : Characteristic
	{
		private void init() {
			Name = "Charisma";
			Description = "xxx";
		}

		public Charisma () : base() {init();}
		public Charisma (System.Object obj = null) : base (obj) {init();}

		public static string Name { get; set; }
		public static string Description { get; set; }

		public static implicit operator Charisma(int i) { return new Charisma (i); }
		public static implicit operator Charisma(uint i) { return new Charisma (i); }
	}
}
