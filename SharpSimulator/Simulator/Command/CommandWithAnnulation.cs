using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpSimulator
{
	class CommandWithAnnulation
	{
		AbstractCommand [] commandExecute;
		AbstractCommand [] commandUndo;
		Stack<AbstractCommand> stackExecute= new Stack<AbstractCommand>();
		Stack<AbstractCommand> stackUndo= new Stack<AbstractCommand>();
		Stack<AbstractCommand> stackRedo= new Stack<AbstractCommand>();

		public CommandWithAnnulation()
		{
			commandExecute=new AbstractCommand[2];
			commandUndo =new AbstractCommand[2];
			CommandNull noCommand=new CommandNull();
			commandExecute[0]=noCommand;
			commandUndo[0]=noCommand;
			commandExecute[1] = noCommand;
			commandUndo[1] = noCommand;
		}
		public void addCommand(int number,AbstractCommand move, AbstractCommand back)
		{
			commandExecute[number] =move;
			commandUndo[number]=back;
		}
		public void presseButtonAnnulation(int number)
		{
			commandUndo[number].execute();
			stackExecute.Pop();
			stackUndo.Push(commandUndo[number]);
			stackRedo.Push(commandUndo[number]);
		}
		public void presseButtonMove(int number)
		{
			commandExecute[number].execute();
			stackExecute.Push(commandExecute[number]);
			stackRedo.Push(commandExecute[number]);
		}
		public void presseButtonRedo(int number)
		{   
			var command = stackUndo.Peek();
			stackRedo.Pop();
			if (command.GetType().Name == "CommandMove")
			{
				stackExecute.Pop();
				command.execute(); 
				stackUndo.Push(command);
			}
			else
			{
				stackUndo.Pop();
				command.execute();
				stackExecute.Push(command);
			}

		}

		public String ToString()
		{
			StringBuilder result = new StringBuilder();
			PrintValues(stackExecute, '\n');
			PrintValues(stackRedo, '\n');
			PrintValues(stackUndo, '\n');
			return result.ToString();
		}
		public static void PrintValues(IEnumerable<AbstractCommand> myCollection, char mySeparator)
		{
			foreach (Object obj in myCollection)
				Console.Write("{0}{1}", mySeparator, obj.GetType().Name);
			Console.WriteLine("************************");
		}


	}


}

