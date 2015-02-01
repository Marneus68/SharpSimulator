using System;
using System.Collections.Generic;

using Gtk;

namespace SharpSimulator
{
	class PlayState:AbstractState
	{
		public PlayState(IStateMachine machine)
			: base(machine)
		{

		}
		public override void Pause()
		{
			Logger.LogChain.Message("Pause",Logger.Level.SIMULATION_DEBUG);

			machine.ChangeState(typeof(IdleState));
		}

		public override Widget BuildMainLayout() {
			var fi = new Fixed ();
			return fi;
		}

		public override List<Button> ButtonsForBar (SimulatorWindow window) {
			List<Button> ret = new List<Button> ();

			Dictionary<string, string> arr = new Dictionary<string, string>(){ {"Pause","pause"} };
			foreach (var s in arr) {
				var tmp_btn = new Button (s.Key);

				switch (s.Value) {
				case "pause":
					tmp_btn.Clicked += new EventHandler (SimulatorWindow.pause);
					break;
				default:
					break;
				}

				ret.Add(tmp_btn);
			}
			return ret;
		}
	}
}

