using System;

namespace SharpSimulator
{
	public class StrikerTalkBehaviour : ITalkBehaviour
	{
		protected static readonly Random Random;

		static StrikerTalkBehaviour() {
			Random = new Random();
		}

		public string Talk(AEntity entity) {
			if (1==Random.Next(0,10))
				Logger.LogChain.Message(entity.Nickname + " : More money!!!", Logger.Level.ALL);
			return "";
		}
	}
}

