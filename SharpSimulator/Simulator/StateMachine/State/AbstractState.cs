using System;
using System.Collections.Generic;

using Gtk;

namespace SharpSimulator
{
	public abstract class AbstractState
	{
		public IStateMachine machine;
		public AbstractState(IStateMachine machineState)
		{
			machine = machineState;
		}
		public virtual void LoadMap(String jsonMapPath = "")
		{
			Logger.LogChain.Message(" you can not loadMap",Logger.Level.SIMULATION_DEBUG);
		}
		public virtual void UnloadMap()
		{
			Logger.LogChain.Message("you can not unload map",Logger.Level.SIMULATION_DEBUG);
		}
		public virtual void QuerryEntity()
		{
			Logger.LogChain.Message("you can not QuerryEntity",Logger.Level.SIMULATION_DEBUG);
		}
		public virtual void NextStep()
		{
			Logger.LogChain.Message("you can not access to next step",Logger.Level.SIMULATION_DEBUG);
		}
		public virtual void PreviousStep()
		{
			Logger.LogChain.Message("you can not access to PreviousStep",Logger.Level.SIMULATION_DEBUG);
		}
		public virtual void Pause()
		{
			Logger.LogChain.Message("you can't pause",Logger.Level.SIMULATION_DEBUG);
		}
		public virtual void Play()
		{
			Logger.LogChain.Message("you can't play",Logger.Level.SIMULATION_DEBUG);
		}
		public virtual void NewEntity()	
		{
			Logger.LogChain.Message("you can not create new Entity",Logger.Level.SIMULATION_DEBUG);
		}
		public virtual void BuildButtonBar(ButtonBox buttonsBox, List<Button> buttonsList) {
			foreach (var child in buttonsBox.Children) {
				buttonsBox.Remove (child);
			}
			if (buttonsList != null) {
				foreach (var button in buttonsList) {
					buttonsBox.Add (button);
				}
				buttonsBox.ShowAll ();
			}
		}
		public virtual void BuildMainLayout(Layout layout, Widget widget) {

		}
		public virtual List<Button> ButtonsForBar(Window window) {
			return new List<Button> ();
		}
	}
}

