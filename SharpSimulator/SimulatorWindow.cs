using System;
using System.Collections.Generic;

using Gtk;

namespace SharpSimulator
{
	public partial class SimulatorWindow : Gtk.Window, IStateMachine
	{
		protected AbstractState CurrentState;

		List<Button> mainMenuButtonList;

		public SimulatorWindow () : base (Gtk.WindowType.Toplevel) {
			this.Build ();
			CurrentState = new NoMapLoadedState(this);
			mainMenuButtonList = CurrentState.ButtonsForBar (this);
			CurrentState.BuildButtonBar (MainButtonBox, mainMenuButtonList);
		}

		public void ChangeState(Type newState) {
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

		public void LoadMap(String jsonMapPath = "") {
			CurrentState.LoadMap(jsonMapPath);
		}

		public void UnloadMap() {
			CurrentState.UnloadMap();
		}

		public void QuerryEntity() {
			CurrentState.QuerryEntity();
		}

		public void NextStep() {
			CurrentState.NextStep();
		}

		public void PreviousStep() {
			CurrentState.PreviousStep();
		}

		public void Pause() {
			CurrentState.Pause();
		}

		public void Play() {
			CurrentState.Play();
		}

		public void NewEntity() {
			CurrentState.NewEntity();
		}

		public void BuildButtonBar(ButtonBox buttonsBox, List<Button> buttonsList) {
			CurrentState.BuildButtonBar (buttonsBox, buttonsList);
		}
	}
}
