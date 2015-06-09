![icon](https://raw.githubusercontent.com/Marneus68/SharpSimulator/gui/icon.png?token=AA1m4ZR07XkF5dJvIR_Q31DvCDr1pRQxks5U36oSwA%3D%3D "SharpSimulator Icon")

# SharpSimulator

SharpSimulator is an attempt at making a simulator able to emulate various scenarios involving multiple entities with various behaviours and interactions. The simulations are described by json files and feature nice 2D graphics. The whole project is made in C# and [Gtk#](http://www.mono-project.com/docs/gui/gtksharp/) using [MonoDevelop](http://www.monodevelop.com/).

This project is meant to showcase the use of design patterns in high level programming languages. It implements a [Strategy Pattern](https://en.wikipedia.org/wiki/Strategy_pattern), a [State Machine](https://en.wikipedia.org/wiki/State_pattern), a [Chain Of Responsability](https://en.wikipedia.org/wiki/Chain-of-responsibility_pattern ), an [Abstract Factory Pattern](https://en.wikipedia.org/wiki/Abstract_factory_pattern) and several others.

You can access this project on github [here](https://github.com/Marneus68/SharpSimulator).

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
- Json.net

Make sure you are using .the proper version of .NET.

#### Gtk#

In addition, you will need the [Gtk#](http://www.mono-project.com/docs/gui/gtksharp/) Library to run the project. The installation method depends on the platform.

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
