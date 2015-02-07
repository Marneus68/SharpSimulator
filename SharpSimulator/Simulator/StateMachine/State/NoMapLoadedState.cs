using System;
using System.Collections.Generic;

using Gtk;

namespace SharpSimulator
{
	class NoMapLoadedState : AbstractState
	{
		public NoMapLoadedState(IStateMachine machine) : base(machine) {}

		public override void LoadMap(String jsonMapPath = "") {
			Logger.LogChain.Message("loadMap",Logger.Level.SIMULATION_DEBUG);
			machine.ChangeState(typeof(IdleState));
		}

		public override List<Button> ButtonsForBar(SimulatorWindow window) {
			var ret = new List<Button> ();
			SimulationsProvider sp = new SimulationsProvider ();
		
			foreach(var sim in sp.SimulationFiles ) {
				ret.Add(new Button(sim.Replace(".json", "")));
			}
			return ret;
		}

		public override void BuildButtonBar (ButtonBox buttonsBox, List<Button> buttonsList) {
			base.BuildButtonBar (buttonsBox, buttonsList);
			foreach (var btn in buttonsList) {
				btn.Clicked += new EventHandler (SimulatorWindow.load_map_btn_event);
			}
		}
	}
}

