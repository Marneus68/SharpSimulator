using System;

namespace SharpSimulator
{
	public  class StateMachine
	{
		public AbstractState courantState;

		public StateMachine()
		{
			courantState = new NoMapLoadedState(this);

		}
		internal void ChangeState(Type newState)
		{
			if (newState==typeof(NoMapLoadedState))
			{
				courantState=new NoMapLoadedState(this);
			}
			else if (newState == typeof(IdleState))
			{
				courantState = new IdleState(this);
			}
			else if (newState == typeof(PlayState))
			{
				courantState = new PlayState(this);
			}
		}
		public virtual void LoadMap()
		{
			courantState.LoadMap();
		}
		public virtual void UnloadMap()
		{
			courantState.UnloadMap();
		}
		public virtual void QuerryEntity()
		{
			courantState.QuerryEntity();
		}
		public virtual void NextStep()
		{
			courantState.NextStep();
		}
		public virtual void PreviousStep()
		{
			courantState.PreviousStep();
		}
		public virtual void Pause()
		{
			courantState.Pause();
		}
		public virtual void Play()
		{
			courantState.Play();
		}
		public virtual void NewEntity()
		{
			courantState.NewEntity();
		}
	}
}

