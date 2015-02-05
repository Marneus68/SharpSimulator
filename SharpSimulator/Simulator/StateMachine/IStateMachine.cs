using System;
using System.Collections.Generic;

using Gtk;

namespace SharpSimulator
{
	public interface IStateMachine
	{
		void ChangeState(Type newState);
		void LoadMap(String jsonMapPath = "");
		void UnloadMap();
		void QuerryEntity();
		void NextStep();
		void PreviousStep();
		void Pause();
		void Play();
		void NewEntity();
		void BuildButtonBar(ButtonBox buttonsBox, List<Button> buttonsList);
	}
}
