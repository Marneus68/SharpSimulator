using System;

namespace SharpSimulator
{
	public class ErraticMoveBehaviour : IMoveBehaviour {
		protected static readonly Random Random;

		static ErraticMoveBehaviour() {
			Random = new Random();
		}

		public void Move(AEntity entity) {
			if (entity.StructurePoints <= 0)
				return;

			int tmpX = entity.x + Random.Next(-1, 2);
			int tmpY = entity.y + Random.Next(-1, 2);

			if (tmpX < 0 || tmpY < 0)
				return;

			entity.x = tmpX;
			entity.y = tmpY;
		}
	}
}
