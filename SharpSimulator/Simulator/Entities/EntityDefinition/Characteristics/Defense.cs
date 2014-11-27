using System;

namespace SharpSimulator
{
	public class Defense : Characteristic
	{
		public Defense () : base() {}
		public Defense (System.Object obj = null) : base (obj) {}

		public static string Name { get; set; } = "Defense";

		public static string Description { get; set; } = "xxx";

		public static implicit operator Defense(int i) { return new Defense (i); }
		public static implicit operator Defense(uint i) { return new Defense (i); }
	}
}

