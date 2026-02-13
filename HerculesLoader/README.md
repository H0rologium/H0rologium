# Hercules Loader

## A desktop loader for utilities

*What is this project?* : This is a rewrite of an older project of mine. I essentially had various scripts and programs floating around my pc that did various things. This program tries to centralize most of the (.NET) ones
The base program itself is just a system tray icon. Actual utilities are loaded in at runtime using reflection.

Adding utilities/plugins just requires making a new folder for that specific utility under the 'plugins' folder next to the executable (either made manually or when running for the first time). The only naming convention needed is adding `_plugin` to the end of the file name of the **main** dll. The program will load that DLL as a plugin. Each plugin should inherit from the `PluginContext` class to help the program determine how to handle the file.
Last tested on windows 10 using .NET 10. Compiles as a ``windows application``.

Named after [something else that is one of a kind](https://en.wikipedia.org/wiki/Hercules_(dwarf_galaxy))