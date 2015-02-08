using System;

namespace SharpSimulator {
	public class Knight : ChessPiece {
		public Knight (String color) : base(null, "", "", "") {
			PieceType = "Knight";
			ConstructPiece (color);
		}

		override public void Step() {

		}
	}
}

