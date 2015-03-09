using System;

namespace SharpSimulator {
	public class Pawn : ChessPiece {
		public Pawn (String color) : base(null, "", "", "") {
			PieceType = "Pawn";
			ConstructPiece (color);
		}

		override public void Step() {
			Move ();
		}
	}
}

