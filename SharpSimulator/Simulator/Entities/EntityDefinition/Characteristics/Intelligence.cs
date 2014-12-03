using System;

namespace SharpSimulator
{
	public class Intelligence : Characteristic
	{
		static Intelligence() {
			Name = "Intelligence";
			Description = "xxx";
		}

		public Intelligence () : base() {}
		public Intelligence (System.Object obj = null) : base (obj) {}

		public static string Name { get; set; }
		public static string Description { get; set; }

		public static implicit operator Intelligence(int i) { return new Intelligence (i); }
		public static implicit operator Intelligence(uint i) { return new Intelligence (i); }
	}
}

