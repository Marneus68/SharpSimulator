using System;

namespace SharpSimulator
{
	public class Command
	{
		String name;
		public Command(String name)
		{
			this.name=name;
		}
		// Move 
		public void move ()
		{
			Logger.LogChain.Message(name+"Command move",Logger.Level.SIMULATION_DEBUG);
		}
		public void back ()
		{
			Logger.LogChain.Message(name+"Command back",Logger.Level.SIMULATION_DEBUG);
		}
	}
}

