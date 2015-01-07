using System;

namespace SharpSimulator
{
	class IdleState:AbstractState
	{
		public IdleState(StateMachine machine)
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
	}
}

