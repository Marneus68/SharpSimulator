using System;

namespace SharpSimulator
{
	class NoMapLoadedState:AbstractState
	{
		public NoMapLoadedState(StateMachine machine)
			: base(machine)
		{
		}
		public override void LoadMap()
		{


			Logger.LogChain.Message("loadMap",Logger.Level.SIMULATION_DEBUG);

			machine.ChangeState(typeof(IdleState));
		}
	}
}

