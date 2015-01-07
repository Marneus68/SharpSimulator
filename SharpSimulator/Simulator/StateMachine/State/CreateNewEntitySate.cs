using System;

namespace SharpSimulator
{
	class CreateNewEntitySate:AbstractState
	{
		public CreateNewEntitySate(StateMachine machine)
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

