using System;

namespace SharpSimulator {
	public class Rook : ChessPiece {
		public Rook (String color) : base(null, "", "", "") {
			PieceType = "Rook";
			ConstructPiece (color);
		}

		override public void Step() {

		}
	}
}

