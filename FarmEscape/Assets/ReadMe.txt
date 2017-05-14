Solution for the Mobile Test (i guess you want it in English :) ):

I guess most of the features are covered, including nice-to-haves (at least from what was understood from the task). 

The way the assets and the level set up works: 
- Levels contains the ... well...levels. And the main menu
- Resources/LevelAssets contains:
	- Level specific auto loading assets(should be called LevelX). Could be used to create new levels
	- The must have GameObjects used to create a new level
	- Some templates for the UI which shouldn't be here. Must have dragged them by mistake...
	- Other assets that can be used for creating levels
- The MainMenu Resources are the textures used in the main menu... Wanted to separate things but then there would have been 1-2 files per folder...maybe too much overengineering
- Some materials and some physics materials can be found in the Resources. We needed a more bouncy material for obstacles. Maybe should have used it for the checkpoint bars. Dunno, i got too good at driving that THING :|
- Used two Asset packs for some wheel geometry and a starting point and obstacles (they also have some materials that are of use). Didn't assimilate them completely. 
- Shamelessly copied the scripts for rendering the skidmarks 
- Some scripts

In case a new level should be created (worked for creating Levels 2 and 3 at least :-?...you know : "works on my computer"):
- We need the level specific textures to add a button in the loading menu
- We need a scene.
- Scripts should not need changing, tags and FindObjects should take care of stuff. Well, unless you want to adjust thing that are too crap :). 

I hope the control doesn't piss you off completely. I can run this fine on the PC but i have to admit i've struggeled at start on Android but that could also be because racing games are not my thing :-?