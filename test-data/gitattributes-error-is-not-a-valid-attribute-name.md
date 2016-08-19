# gitattributes error ' is not a valid attribute name'

You're setting an attribute value, but you've put spaces around the equals sign. Just remove the spaces!

Instead of:

	.htaccess merge = ours

Consider:

	.htaccess merge=ours
	

## Symptom

You add a new gitattributes file or line and run `git status`, and receive this error or similar:

	 is not a valid attribute name: .gitattributes:1

## Cause

Now, I copied and pasted my gitattributes from [the book][book] where the example has spaces around the equals, but it turns out this is just plain wrong. As given in [gitattributes(5) man page][man]:

 > Each line in gitattributes file is ... a pattern followed by an attributes list, separated by whitespaces. 

It's now been fixed in the GitHub version of the book, but I don't know when that'll be published to git-scm.

*Written 2015-09-29*
 
[man]: http://git-scm.com/docs/gitattributes#_description
[book]: http://git-scm.com/book/en/v2/Customizing-Git-Git-Attributes#Merge-Strategies