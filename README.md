# DayZVersionToggle
A tool for keeping Experimental and Stable branches installed at the same time

[Download Latest Version](https://github.com/KieranMcCool/DayZVersionToggle/raw/master/Versions/VersionLatest.zip)

# What this program does

This program allows you to keep both an Experimental and Stable installation of DayZ Standalone at the same time. 

# How this works

Once you've followed the setup instructions listed below, the program will make separate copies of the game directory and depending on which is being played, will switch them around so that Steam has access to the desired version. 

It's actually a little bit more complicated than that using [Symbolic Links](https://en.wikipedia.org/wiki/Symbolic_link) but that's the gist of how it works.

# Installation

The setup is relatively simple and you'll be guided through it using dialog boxes. During the initial copying of the Directory, the program may appear unresponsive, it's not. Just be patient and everything will finish and return to a functional state. 

When the installer refers to your DayZ game directory, it means the folder which your DayZ.exe is located, generally Steam puts this in "C:\Program Files (x86)\Steam\steamapps\DayZ" but if you set it to a different place then you'll need to set this before carrying out the installation.

You'll also have to choose which version you currently have installed (Experimental or Stable).

After you've confirmed your choices, the program will be largely automated, it will copy your current installation to a backup and then you'll be prompted to go to Steam and set it to download whichever version you don't currently have. I.e if you have Stable, you'll install Experimental vice versa.

Once Steam has completely finished downloading these files you can click OK on the Dialog box and you'll be pretty much all setup.

# Updating the Installations

Obviously, you'll want to be on the latest version of whichever branch you want to play. Unfortunately, Steam doesn't give me any easy way to detect when an installation is out of date, as such you'll have to manage this yourself for the most part. 

When you know an update is available for a particular branch, should use the "Active Installation" section of the window to activate the branch you want to update then go to Steam and force the update by matching the Steam beta options to the version you have currently active. This typically forces Steam to update immediately and is also how you fix the problem of accidentally installing Stable on your Experimental installation. (or vice versa)

# Things to Note

As I this program (at the time of writing) is less than an hour old in it's completion and the sole tester has been me, I have no idea how aggressive Steam is when it sees that a game installation is out of sync with how it should be. As such, it is very important that you keep the active version in the program and the beta options in Steam the same. 

I don't imagine Steam would be so bold as to validate files while the game is running so when you play the opposite version from what Steam thinks you have by launching it through this program, it quickly switches the files then switches them back when DayZ exits. This should hopefully keep Steam from overwriting your branches.

If for whatever reason your computer crashes/the program crashes/you have a power cut/natural disaster/some other issue that means your computer cuts out before DayZ exits, I would definitely recommend launching this program and setting the active profile to the version Steam thinks is installed BEFORE launching Steam again. 

I haven't really had any issues in my testing so far, so hopefully this wont be a big issue but I have no say in how Steam manages its games so this is a problem that I unfortunately cannot get around.

If you're confident that you can manually keep up-to-date on the updates and don't mind managing that side of things yourself, you can disable the automatic updates by going to Properties -> Updates and disabling them. 


