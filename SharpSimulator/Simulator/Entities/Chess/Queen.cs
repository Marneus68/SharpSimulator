using System;

namespace SharpSimulator {
	public class Queen : ChessPiece {
		public Queen (String color) : base(null, "", "", "") {
			PieceType = "Queen";
			ConstructPiece (color);
		}
	}
}

