# SharpSimulator

## Builing

You can build the solution using Xamarin Studio, MonoDevelop or Visual Studio.

Or, from the command line from inside the SharpSimulator directory:

	xbuild

or

	msbuild

depending on if you have the appropriated command line tools in your path.

### Build dependencies 

#### NUnit

To build the project, you may need to redownload the NUnit NuGet packages 

- NUnit
- NUnit Runner

#### Gtk#

In addition, you will need the Gtk# Library to run the project. The installation method depends on the platform.

##### Windows

To install Gtk# on windows you can [download and run this installer](http://download.xamarin.com/GTKforWindows/Windows/gtk-sharp-2.12.25.msi).

Alternativelly, install [Xamarin Studio](http://xamarin.com/download) and everything should work out of the box.

##### Mac OS X

* With macports

	sudo port install gtk-sharp

* Without macports

You should find what you're looking for [here](http://www.mono-project.com/download/#download-mac).

Alternativelly, install [Xamarin Studio](http://xamarin.com/download) and everything should work out of the box.

##### Linux

I'm pretty sure you know what you're doing so I shouldn't have to tell you what to do here.

## Entities

The Entities are the base classes of the simulator.
The two main super-classes that you can derive from are CivilianEntity and FighterEntity.

The StructurePoints of an Entity can be interpreted as life points. When they reach 0, the Entity is destroyed.

## Logging (debug or otherwise)

If you must display textual outputs for debugging or other purposes, you are encouraged to use the Logger class.
You cas use it according to the the following exeample.

	Logger.LogChain.Message ("Hello World !", Logger.Level.ERROR);

The Logger class will handle the display according to the message Level.

Possible Levels of include :

* NONE
* SIMULATOR_INFO
* SIMULATOR_DEBUG
* SIMULATION_INFO
* SIMULATION_NOTICE
* SIMULATION_DEBUG
* ERROR
* ALL

Direct use of System.ConsoleWriteLine and similar methods is **discouraged**.
