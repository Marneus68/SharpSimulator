using System;

namespace SharpSimulator
{
	internal class CommandMove:AbstractCommand
	{
		Command command;
		public CommandMove(Command command)
		{
			this.command=command;
		}
		public override void execute()
		{
			command.move();
		}
		public override void undo()
		{
			command.back();
		}
	}
}

