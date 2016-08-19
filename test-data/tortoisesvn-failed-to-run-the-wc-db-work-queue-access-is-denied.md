# TortoiseSVN failed to run the WC DB work queue... access is denied.

This could happen when you attempt to 'Upgrade Working Copy' on a repository.
I got this error while resolving problems with a Jenkins job which had just moved to a new build server. It seemed that Jenkins couldn't update the repository, so I went to investigate, hoping to revert and update it manually. But when I tried to use 'Upgrade Working Copy', this error appeared:

	Failed to run the WC DB work queue associated with 'C:\...\workspace', work item 2 (postupgrade)
	Can't set file 'C:\...\workspace\.svn\entries' read-write: Access is denied.
	
## Steps to resolution:

 * Open a new admin command prompt (Win+X on Windows 8+);
 * `cd` to the workspace directory named in the error message;
 * `svn cleanup`
 * When the prompt reappears, go to the directory in Windows Explorer;
 * Right click and go to, TortoiseSVN, Clean up...
 * If you're on a build server, tick **every box** (N.b. this will wipe all unversioned items, such as un-committed code) and click OK;
 * Now do right click, SVN Update to make everything shiny and new
 
Your repo should be back in a pristine state now, and upgraded to the latest SVN version. This will hopefully resolve any problems that your build server is having when it tries to update the workspace!

*Written 2015-06-19*
