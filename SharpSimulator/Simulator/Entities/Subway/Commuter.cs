using System;

namespace SharpSimulator {
	public class Commuter : CivilianEntity {
		protected static readonly Random random = new Random();

		String Sex;

		public Commuter () : base (null, "", "", "Commuter") {
			Sex = (random.Next (0, 2) == 0) ? "m" : "f";
			Skin = "man_" + Sex + "_" + random.Next (1, 5);
		}
	}
}

