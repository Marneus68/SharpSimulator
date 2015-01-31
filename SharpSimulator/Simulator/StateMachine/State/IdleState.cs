using System;
using System.Collections.Generic;

using Gtk;

namespace SharpSimulator
{
	class IdleState:AbstractState
	{
		public IdleState(IStateMachine machine)
			: base(machine)
		{
		}
		public override void NewEntity()
		{
			Logger.LogChain.Message("new Entity",Logger.Level.SIMULATION_DEBUG);

			machine.ChangeState(typeof(CreateNewEntitySate));
		}
		public override void UnloadMap()
		{
			Logger.LogChain.Message("unloadMap",Logger.Level.SIMULATION_DEBUG);

			machine.ChangeState(typeof(NoMapLoadedState));

		}
		public override void QuerryEntity()
		{
			Logger.LogChain.Message("QuerryEntity",Logger.Level.SIMULATION_DEBUG);

		}
		public override void NextStep()
		{
			Logger.LogChain.Message("next Step",Logger.Level.SIMULATION_DEBUG);

		}
		public override void PreviousStep()
		{
			Logger.LogChain.Message("PreviousStep",Logger.Level.SIMULATION_DEBUG);

		}
		public override void Play()
		{
			Logger.LogChain.Message("Play",Logger.Level.SIMULATION_DEBUG);

			machine.ChangeState(typeof(PlayState));

		}

		public override List<Button> ButtonsForBar (Window window) {
			List<Button> ret = new List<Button> ();

			Dictionary<string, string> arr = new Dictionary<string, string>(){ {"Previous Step","previous_step"}, {"Play","play"}, {"Next Step", "next_step"}, {"Stop Simulation", "stop_simulation"} };
			foreach (var s in arr) {
				var tmp_btn = new Button (s.Key);

				switch (s.Value) {
				case "previous_step":
						tmp_btn.Clicked += new EventHandler (SimulatorWindow.previous_step);
						break;
					case "play":
						tmp_btn.Clicked += new EventHandler (SimulatorWindow.play);
						break;
					case "next_stop":
						tmp_btn.Clicked += new EventHandler (SimulatorWindow.next_step);
						break;
					case "stop_simulation":
						tmp_btn.Clicked += new EventHandler (SimulatorWindow.stop_simulation);
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

