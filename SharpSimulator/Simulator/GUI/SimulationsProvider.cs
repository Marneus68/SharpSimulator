using System;
using System.IO;
using System.Collections.Generic;

namespace SharpSimulator {
	public class SimulationsProvider {
		protected static string provider_name = "SimulationsProvider";

		protected static string file_extention = @".json";
		protected static string resource_folder = @"Resources";
		protected static string subfolder = @"Simulations";
		protected static string path = "";

		protected static List<string> simulationFiles = null;

		public List<string> SimulationFiles {
			get {
				if (simulationFiles == null)
					simulationFiles = new List<string> ();
				return simulationFiles;
			}
			protected set {simulationFiles = value;}
		}

		static SimulationsProvider () {
			simulationFiles = new List<string> ();
			PopulateList ();
		}

		protected static void PopulateList() {
			path = "./" + resource_folder + "/" + subfolder;

			Logger.LogChain.Message ("[" + provider_name + "] Populating the provider with the content of \"" + path + "\"", Logger.Level.SIMULATION_DEBUG);

			string[] dirContent;

			try {
				dirContent = Directory.GetFiles (path, "*.json");
			} catch (Exception e) {
				Logger.LogChain.Message ("[" + provider_name + "] Cannot find \"" + path + "\" or the folder is empty. [" + e.Message + "]", Logger.Level.SIMULATION_DEBUG);
				return;
			}

			foreach(var line in dirContent) {
				var key = line.Replace (path, "").Replace ("\\", "");
				Logger.LogChain.Message ("[" + provider_name + "] " + key + " (" + line.Replace ("\\", "/") + ")", Logger.Level.SIMULATION_DEBUG);
				simulationFiles.Add (key);
			}

			Logger.LogChain.Message ("[" + provider_name + "] Exiting the provider population function, " + dirContent.Length.ToString() + " objects found. in \"" + path + "\"", Logger.Level.SIMULATION_DEBUG);
		}
	}
}

