using System;

namespace SharpSimulator {
	public class King : ChessPiece {
		public King (String color) : base(null, "", "", "") {
			PieceType = "King";
			ConstructPiece (color);
		}

		override public void Step() {

		}
	}
}

