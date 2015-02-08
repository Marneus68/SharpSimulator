using System;

namespace SharpSimulator
{
	public abstract class ChessPiece : AEntity
	{
		[Flags]
		public enum Side {
			UNDEFINED	= 0,
			BLACK		= 1,
			WHITE		= 2
		}
				
		protected Side color;
		public Side Color {
			get {
				return color;
			}
			set { 
				switch (value) {
					case Side.BLACK:
						ColorName = "Black";
						break;
					case Side.WHITE:
						ColorName = "White";
						break;
					default:
						ColorName = "Uncolored";
						break;
				}
				color = value;
			}
		}

		protected Side ColorToSide(String col) {
			if (col.ToLower () == "black")
				return Side.BLACK;
			if (col.ToLower () == "white")
				return Side.WHITE;
			return Side.UNDEFINED;
		}

		protected String PieceType;
		protected String ColorName;

		public ChessPiece() : this(null, "Chess", "Piece", "") {}

		public ChessPiece (Faction _faction = null, string fname = "Chess", string lname = "Piece", string nick = "") : base(_faction, fname, lname, nick) {
			FightBehaviour = (IFightBehaviour) new DummyFightBehaviour ();
			MoveBehaviour = (IMoveBehaviour) new DummyMoveBehaviour ();
			TalkBehaviour = (ITalkBehaviour) new DummyTalkBehaviour ();
			DisplayBehaviour = (IDisplayBehaviour) new DummyDisplayBehaviour ();

			Color = Side.UNDEFINED;
		}

		public void ConstructPiece(String color) {
			Color = ColorToSide (color);

			LastName = PieceType;
			FirstName = ColorName;

			Skin = ColorName.ToLower () + "_" + PieceType.ToLower ();
		}
	}
}

