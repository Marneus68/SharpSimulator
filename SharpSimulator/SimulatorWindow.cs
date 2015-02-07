using System;
using System.Collections.Generic;

using Gtk;

namespace SharpSimulator
{
	public partial class SimulatorWindow : Gtk.Window, IStateMachine
	{
		public static SimulatorWindow Shared = null;

		protected GameContext context;
		protected AbstractState CurrentState;

		protected Fixed MainFixedLayout;

		protected int Offset = 12;

		List<Button> mainMenuButtonList;

		public SimulatorWindow () : base (Gtk.WindowType.Toplevel) {
			this.Build ();
			context = new GameContext ();

			SetIconFromFile ("./Resources/Icons/icon.ico");

			MainFixedLayout = new Fixed ();

			MainAlignement.Add (MainFixedLayout);

			Shared = this;
			CurrentState = new NoMapLoadedState(this);
			mainMenuButtonList = CurrentState.ButtonsForBar (this);
			CurrentState.BuildButtonBar (MainButtonBox, mainMenuButtonList);

			SimulationDebugLabelContainer.Add (GuiLogger.OutputWidget);

			//BuildMainView (CurrentState.BuildMainLayout());	

			this.ShowAll ();
		}

		public void ChangeState(Type newState) {
			if (newState==typeof(NoMapLoadedState)) {
				CurrentState = new NoMapLoadedState(this);
			} else if (newState == typeof(IdleState)) {
				CurrentState = new IdleState(this);
			} else if (newState == typeof(PlayState)) {
				CurrentState = new PlayState(this);
			}
			mainMenuButtonList = CurrentState.ButtonsForBar (this);
			CurrentState.BuildButtonBar (MainButtonBox, mainMenuButtonList);
			//BuildMainView (CurrentState.BuildMainLayout());
			this.ShowAll ();
		}

		public void Repaint() {
			foreach (var child in MainFixedLayout.Children) {
				MainFixedLayout.Remove (child);
			}
			RepaintBackground ();
			RepaintEntities ();
			ShowAll ();
		}

			public void RepaintBackground() {
				for (int row = 0; row < context.Textures.GetLength (0); row++) {
				for (int col = 0; col < context.Textures.GetLength (1); col++) {
					MainFixedLayout.Put (GtkWidgetExtensions.Extensions.Clone(TilesProvider.Tiles [context.Textures [row, col].Trim()]), row * TilesProvider.Size - Offset, col * TilesProvider.Size);
				}
			}
		}

		public void RepaintEntities() {
		
			MainFixedLayout.Put (GtkWidgetExtensions.Extensions.Clone(SpritesProvider.Tiles ["man_m"]), 2 * TilesProvider.Size - Offset, 0 * TilesProvider.Size);

			foreach (var ent in context.EntityList) {

			}
		}

		public void LoadMap(String jsonMapPath = "") {
			context.ChargeSimulation (new Factory.SubwayFactory(), "Subway.json");

			Logger.LogChain.Message ("Simulation loaded", Logger.Level.SIMULATION_NOTICE);

			SimulationOverviewLabel.Editable = false;
			SimulationOverviewLabel.Buffer.Text = "Simulation Name: " + context.Name + "\nSimulation Description: " + context.Description;

			CurrentState.LoadMap(jsonMapPath);

			Repaint ();
		}

		public void UnloadMap() {
			foreach (var child in MainFixedLayout.Children) {
				MainFixedLayout.Remove (child);
			}
			ShowAll ();
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

		public void BuildMainView(Widget widget) {
			foreach (var child in MainAlignement.Children) {
				MainAlignement.Remove (child);
			}
			if (widget != null) {
				MainAlignement.Add (widget);
			}
		}

		/* button events */

		public static void load_map_btn_event(object obj, EventArgs args) {
			Button tmp_btn = (Button)obj;
			Shared.LoadMap (tmp_btn.Label);
		}

		public static void stop_simulation(object obj, EventArgs args) {
			Shared.UnloadMap ();
		}

		public static void play(object obj, EventArgs args) {
			Shared.Play ();
		}

		public static void pause(object obj, EventArgs args) {
			Shared.Pause ();
		}

		public static void next_step(object obj, EventArgs args) {
			Shared.NextStep ();
		}

		public static void previous_step(object obj, EventArgs args) {
			Shared.PreviousStep ();
		}
	}
}
