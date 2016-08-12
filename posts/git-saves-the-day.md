# Git saves the day

I'm working on a game for a bit of fun at the moment, called [Space Fleet][]. I've set aside my train commute to Liverpool, and code in Visual Studio on my trusty 2011 HP laptop.  

The other day I had a sub-moment of horror when I opened the project and the main file couldn't be opened - it had turned entirely to NULs! This is a common type of file corruption where file length stays the same but all the data is lost, and can be related to problems in the sleep/resume cycle, and interrupted disk access.

Anyway, thankfully I had just checked the code into git before I closed my laptop, so restoring the file was as simple as

	git checkout SpaceFleet.vb
	
and all was well!

Git saves the day once more. Without it, I would have had to rely on OneDrive having an older version backed up. This really motivates me to put as many projects in Git (and GitHub) as possible!

*Written 2015-08-04*

[Space Fleet]: https://github.com/stegriff/spacefleet