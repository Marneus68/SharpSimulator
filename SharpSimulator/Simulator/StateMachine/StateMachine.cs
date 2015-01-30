using System;
using System.Collections.Generic;

using Gtk;

namespace SharpSimulator
{
	public class StateMachine : IStateMachine
	{
		protected AbstractState CurrentState;

		public StateMachine()
		{
			CurrentState = new NoMapLoadedState(this);
		}

		public void ChangeState(Type newState)
		{
			if (newState==typeof(NoMapLoadedState))
			{
				CurrentState=new NoMapLoadedState(this);
			}
			else if (newState == typeof(IdleState))
			{
				CurrentState = new IdleState(this);
			}
			else if (newState == typeof(PlayState))
			{
				CurrentState = new PlayState(this);
			}
		}

		public virtual void LoadMap(String jsonMapPath = "")
		{
			CurrentState.LoadMap(jsonMapPath);
		}

		public virtual void UnloadMap()
		{
			CurrentState.UnloadMap();
		}

		public virtual void QuerryEntity()
		{
			CurrentState.QuerryEntity();
		}

		public virtual void NextStep()
		{
			CurrentState.NextStep();
		}

		public virtual void PreviousStep()
		{
			CurrentState.PreviousStep();
		}

		public virtual void Pause()
		{
			CurrentState.Pause();
		}

		public virtual void Play()
		{
			CurrentState.Play();
		}

		public virtual void NewEntity()
		{
			CurrentState.NewEntity();
		}

		public virtual void BuildButtonBar(ButtonBox buttonsBox, List<Button> buttonsList) {
			CurrentState.BuildButtonBar (buttonsBox, buttonsList);
		}
	}
}

