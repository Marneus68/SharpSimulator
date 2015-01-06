using System;

namespace SharpSimulator
{
	internal class CommandBack : AbstractCommand
	{
		Command command;
		public CommandBack(Command command)
		{
			this.command = command;
		}
		public override void execute()
		{
			command.back();
		}
		public override void undo()
		{
			command.move();
		}
	}
}

