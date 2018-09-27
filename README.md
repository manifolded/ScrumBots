# ScrumBots

## Required Installations

To configure this project you will need to install IronPython (IP).  This has been tested with IP version 2.7.8 in Unity 2018.2.10f1.

  1. With 2018.2.10f1 you no longer need to use the "Experimental" scripting runtime version.  It appears that the default is now `.NET 4.x Equivalent` which works well with IP.  If for some reason you find that you do need to change the setting you can do this by going to `Edit`->`Project Settings`->`Player`.  This will open up the "PlayerSettings" in the Inspector Window.  Scroll down until you find `Other Settings`->`Configuration`->`Scripting Runtime Version`.  From the menu select `.NET 4.x Equivalent`.  

  2. To install, first open the ScrumBots in Unity and create a directory `Assets/Plugins/Resources`.  This directory is where all the IP .dll and .xml files will go.
  
  3. Download and unpack IronPython from [here](http://ironpython.net/).
  
  4. From the `IronPython.2.7.8/net45` directory copy `IronPython.*` and `Microsoft.*` into `Assets/Plugins/Resources`.  This can be most easily accomplished by drag-and-dropping the files to the Unity project window.  Unity will then import them.  The `.gitignore` file is set to ignore anything in this directory so you don't have to worry about this getting checked in to the repo.
  
  5. Also copy the `IronPython.2.7.8/Lib` directory to `Assets/Plugins/Resources`.  This contains the Python standard libraries which we will need.

  6. You will also need `Json.NET`.  You can install a suitable version from the Unity Asset Store.  Search for "json.net", the first hit should be by Parentelement, LLC.  That's the one you want; go ahead and import it.  By default it will be placed in `Assets`.  You'll need to move it to `Assets/Plugins`.
  
