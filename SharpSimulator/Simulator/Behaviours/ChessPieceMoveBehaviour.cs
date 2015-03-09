using System;

namespace SharpSimulator
{
	public class ChessPieceMoveBehaviour : IMoveBehaviour
	{
		protected static readonly Random Random;

		static ChessPieceMoveBehaviour() {
			Random = new Random();
		}

		public void Move(AEntity entity) {
			if (entity.StructurePoints <= 0)
				return;

			int tmpX = entity.x + Random.Next(-1, 2);
			int tmpY = entity.y + Random.Next(-1, 2);

			if (tmpX < 0 || tmpY < 0)
				return;
			if (tmpX > 7 || tmpY > 7)
				return;

			entity.x = tmpX;
			entity.y = tmpY;
		}
	}
}

