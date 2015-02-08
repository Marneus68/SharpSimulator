using System;

namespace SharpSimulator {
	public class Bishop : ChessPiece {
		public Bishop (String color) {
			PieceType = "Bishop";
			ConstructPiece (color);
		}
	}
}

