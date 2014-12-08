using System;
using Gtk;

public partial class MainWindow: Gtk.Window
{
	private static SharpSimulator.EntityManager manager;
	private static SharpSimulator.Faction faction;  

	public MainWindow () : base (Gtk.WindowType.Toplevel) {

		SetDefaultSize(800, 600);

		manager = new SharpSimulator.EntityManager ();
		faction = new SharpSimulator.Faction ("Faction");

		HBox box = new HBox(false, 0);

		VPaned p = new VPaned();

		Notebook nb = new Notebook();
		HBox debug_log = new HBox();
		Label debug_log_label = new Label("Debug Log");
		HBox entity_log = new HBox();
		Label entity_log_label = new Label("Entity Log");


		Gdk.Size sh = new Gdk.Size();
		sh.Height = 100;
		debug_log.SizeAllocate(new Gdk.Rectangle(Gdk.Point.Zero, sh));


		nb.AppendPage(debug_log, debug_log_label);
		nb.AppendPage(entity_log, entity_log_label);

		Button add_civ_btn = new Button("Add a Civilian");
		Button add_fig_btn = new Button("Add a Fighter");
		Button state_war = new Button ("State of war !");
		Button state_peace = new Button ("State of peace !");
		Button mv_btn = new Button("Move !");
		Button talk_btn = new Button("Taunt !");
		Button fight_btn = new Button("Fight !");

		add_civ_btn.Clicked += new EventHandler (add_civilian);
		add_fig_btn.Clicked += new EventHandler (add_fighter);
		state_war.Clicked += new EventHandler (state_of_war);
		state_peace.Clicked += new EventHandler (state_of_peace);
		mv_btn.Clicked += new EventHandler (move_entities);
		talk_btn.Clicked += new EventHandler (taunt_entities);
		fight_btn.Clicked += new EventHandler (fight_entities);

		box.Add (add_civ_btn);
		box.Add (add_fig_btn);
		box.Add (state_war);
		box.Add (state_peace);
		box.Add (mv_btn);
		box.Add (talk_btn);	
		box.Add (fight_btn);

		//this.Add (box);

		p.Pack1(box, true, false);
		p.Pack2(nb, true, true);

		this.Add(p);

		ShowAll ();
	}

	static void add_civilian(object obj, EventArgs args) {
		manager.Add (new SharpSimulator.CivilianEntity ());
	}

	static void add_fighter(object obj, EventArgs args) {
		manager.Add (new SharpSimulator.FighterEntity (faction));
	}

	static void move_entities(object obj, EventArgs args) {
		manager.Move ();
	}

	static void taunt_entities(object obj, EventArgs args) {
		manager.Talk ();
	}

	static void fight_entities(object obj, EventArgs args) {
		manager.Fight ();
	}

	static void state_of_war(object obj, EventArgs args) {
		//faction.Relation = SharpSimulator.Faction.Relation.WAR;
		//faction.Update ();
	}

	static void state_of_peace(object obj, EventArgs args) {
		//faction.Relation = SharpSimulator.Faction.Relation.PEACE;
		//faction.Update ();
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a) {
		Application.Quit ();
		a.RetVal = true;
	}
}
