using System;
using System.Collections.Generic;

using Gtk;

namespace SharpSimulator
{
	class NoMapLoadedState : AbstractState
	{
		public NoMapLoadedState(IStateMachine machine) : base(machine) {
		}

		public override void LoadMap(String jsonMapPath = "")
		{
			Logger.LogChain.Message("loadMap",Logger.Level.SIMULATION_DEBUG);
			machine.ChangeState(typeof(IdleState));
		}

		public override List<Button> ButtonsForBar(Window window) {
			TilesProvider tp = new TilesProvider ();


			var ret = new List<Button> ();
			SimulationsProvider sp = new SimulationsProvider ();
		
			foreach(var sim in sp.SimulationFiles ) {
				ret.Add(new Button(sim.Replace(".json", "")));
			}
			return ret;
		}
	}
}

