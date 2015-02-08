using System;

namespace SharpSimulator
{
	public class BreakerTalkBehaviour : ITalkBehaviour
	{
		protected static readonly Random Random;

		static BreakerTalkBehaviour() {
			Random = new Random();
		}

		public string Talk(AEntity entity) {
			if (1==Random.Next(0,10))
				Logger.LogChain.Message(entity.Nickname + " : Anarchy!", Logger.Level.ALL);
			return "";
		}
	}
}

