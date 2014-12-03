using System;

namespace SharpSimulator
{
	public class Intelligence : Characteristic
	{
		private void init() {
			Name = "Intelligence";
			Description = "xxx";
		}

		public Intelligence () : base() {init();}
		public Intelligence (System.Object obj = null) : base (obj) {init();}

		public static string Name { get; set; }
		public static string Description { get; set; }

		public static implicit operator Intelligence(int i) { return new Intelligence (i); }
		public static implicit operator Intelligence(uint i) { return new Intelligence (i); }
	}
}

