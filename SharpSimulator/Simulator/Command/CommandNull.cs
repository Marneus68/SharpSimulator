using System;

namespace SharpSimulator
{
	internal class CommandNull:AbstractCommand
	{
		public override void execute()
		{
			throw new NotImplementedException();
		}
		public override void undo()
		{
			throw new NotImplementedException();
		}
	}

}

