using System;

namespace SharpSimulator
{
	internal abstract class AbstractCommand
	{
		public AbstractCommand()
		{
		}
		public abstract void execute();
		public abstract void undo();
	}
}

