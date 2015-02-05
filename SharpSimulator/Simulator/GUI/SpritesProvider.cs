using System;
using System.Collections.Generic;

namespace SharpSimulator
{
	public class SpritesProvider : TilesProvider {
		static SpritesProvider () {
			provider_name = "SpritesProvider";
			subfolder = "Sprites";
			tiles = new Dictionary<string, Gtk.Image>();
			PopulateTilesDict ();
		}
	}
}
