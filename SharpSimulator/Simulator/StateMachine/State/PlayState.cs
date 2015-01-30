using System;

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
	}
}

