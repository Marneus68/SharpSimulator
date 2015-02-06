using System;
using System.IO;
using System.Collections.Generic;

using Gtk;

namespace SharpSimulator {
	public class TilesProvider {

		public static readonly int Size = 16;

		protected static string provider_name = "TilesProvider";

		protected static string file_extention = @".png";
		protected static string resource_folder = @"Resources";
		protected static string subfolder = @"Tiles";
		protected static string path = "";

		protected static Dictionary<string, Gtk.Image> tiles = null;

		public static Dictionary<string, Gtk.Image> Tiles {
			get {
				if (tiles == null)
					tiles = new Dictionary<string, Gtk.Image> ();
				return tiles;
			}
			protected set {tiles = value;}
		}

		static TilesProvider () {
			tiles = new Dictionary<string, Gtk.Image>();
			PopulateTilesDict ();
		}

		protected static void PopulateTilesDict() {
			path = "./" + resource_folder + "/" + subfolder;

			Logger.LogChain.Message ("[" + provider_name + "] Populating the provider with the content of \"" + path + "\"", Logger.Level.SIMULATION_DEBUG);

			string[] dirContent;

			try {
				dirContent = Directory.GetFiles (path, "*.png");
			} catch (Exception e) {
				Logger.LogChain.Message ("[" + provider_name + "] Cannot find \"" + path + "\" or the folder is empty. [\"" + e.Message + "\"]\"", Logger.Level.SIMULATION_DEBUG);
				return;
			}

			foreach(var line in dirContent) {
				var key = line.Replace (path, "").Replace ("\\", "").Replace (file_extention, "");
				Logger.LogChain.Message ("[" + provider_name + "] " + key + " (" + line.Replace ("\\", "/") + ")", Logger.Level.SIMULATION_DEBUG);
				tiles.Add (key, new Image (line.Replace ("\\", "/")));
			}

			Logger.LogChain.Message ("[" + provider_name + "] Exiting the provider population function, " + dirContent.Length.ToString() + " objects found. in \"" + path + "\"", Logger.Level.SIMULATION_DEBUG);
		}
	}
}
