using System;
using Gtk;

namespace SharpSimulator
{
	public class Logger {

		[Flags]
		public enum Level {
			NONE = 0,
			SIMULATOR_INFO = 1,
			SIMULATOR_DEBUG = 2,
			SIMULATION_INFO = 4,
			SIMULATION_NOTICE = 8,
			SIMULATION_DEBUG = 16,
			ERROR = 32,
			ALL = 63
		}	

		protected Level Mask;
		protected Logger Next;

		private static Logger logChain = null;
		public static Logger LogChain {
			get { 
				if (logChain == null) {
					Logger logger = new FileLogger (Level.ALL);
					logger.Next = new GuiLogger (Level.SIMULATOR_INFO | Level.SIMULATION_INFO | Level.SIMULATION_NOTICE | Level.ERROR);
					logger.Next.Next = new StdLogger (Level.SIMULATOR_INFO | Level.SIMULATION_INFO | Level.SIMULATION_NOTICE | Level.SIMULATOR_DEBUG | Level.SIMULATION_DEBUG);
					logger.Next.Next.Next = new StdErrLogger (Level.ERROR);

					logChain = logger;
				}
				return logChain;
			}
		}

		public void Message(string message, Level priority ) {
			if ((priority & Mask) != 0) {
				OutputMessage(message);
			}
			if (Next != null) {
				Next.Message(message, priority);
			}
		}

		public Logger (Level mask = Level.NONE) {
			Mask = mask;
		}

		virtual protected void OutputMessage(String message) {}
	}

	public class StdLogger : Logger {
		public StdLogger(Logger.Level mask = Logger.Level.NONE) : base(mask) {}

		override protected void OutputMessage(String message) {
			Console.WriteLine (message);
		}
	}

	public class StdErrLogger : Logger {
		public StdErrLogger(Logger.Level mask = Logger.Level.NONE) : base(mask) {}

		override protected void OutputMessage(String message) {
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine (message);
			Console.ForegroundColor = ConsoleColor.White;
		}
	}

	public class GuiLogger : Logger {

		private static TextView tv = null;
		public static TextView OutputWidget {
			get { 
				if (tv == null) {
					tv = new TextView ();
					tv.Editable = false;
				}
				return tv;
			}
		}

		public GuiLogger(Logger.Level mask = Logger.Level.NONE) : base(mask) {}

		override protected void OutputMessage(String message) {
			tv.Buffer.Text += message + "\n";
		}
	}

	// TODO: class that creates a new log each time the application is run
	public class FileLogger : Logger {
		public FileLogger(Logger.Level mask = Logger.Level.NONE) : base(mask) {}

		override protected void OutputMessage(string message) {

		}
	}
}

