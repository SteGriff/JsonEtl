# Ignore certain files and types in GitHub Desktop

Git has a config file called `.gitignore` which you can use to specify files and types which should be ignored for the life of the repository. Be aware that if such files have previously been committed then you will need to explicitly remove them for the ignore to take hold.

 * In the top right, click the Cog icon
 * Click `Repository settings...`
 
You should see a text file on the right detailing the ignored files. Let's notice a few things:

	# Windows image file caches
	Thumbs.db

	# Windows Installer files
	*.cab

We can specify an exact file name which is to be ignored always ("Thumbs.db") or use the wildcard, `*` to specify a range. In my repo, if I wanted to ignore all `.class` files, I could simply add the following to the bottom of the file:

	# Ignore all class files (SG)
	*.class
	
The part with the hash is just a descriptive comment and is optional.

If I wanted to ignore everything in the sub-folder called 'secret' I could do this:

	# Ignore everything in secret folder
	secret/*.*
