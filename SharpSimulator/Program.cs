using System;
using Gtk;

namespace SharpSimulator
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Application.Init ();
			SimulatorWindow win = new SimulatorWindow ();
			win.Show ();
			Application.Run ();
        }
	}
}
