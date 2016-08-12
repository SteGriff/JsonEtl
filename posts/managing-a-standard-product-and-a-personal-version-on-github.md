# Managing a standard product and a personal version on GitHub

This blog platform, [Upblog](./posts/about-upblog) is on GitHub; I want anyone to be able to download and install it. But I also have a version that I want to use for myself. I soon realised I didn't want to be copying-and-pasting code changes across from the standard to my personal, so there had to be a proper way to do this with git.

## How to do it

### GitHub

The Upblog software is hosted at `github.com/stegriff/upblog`
My personal installation is `github.com/stegriff/sg-upblog`

### My PC

I have a folder for developing Upblog, which is isolated from my website folder. This has a git repo in it, which only has one remote:

	$ cd ~/projects/upblog
	$ git remote -v
	origin  https://github.com/stegriff/upblog (fetch)
	origin  https://github.com/stegriff/upblog (push)
	
Then there is my website folder, which has two remotes:

	$ cd ~/stegriff/upblog
	$ git remote -v
	origin  https://github.com/stegriff/sg-upblog (fetch)
	origin  https://github.com/stegriff/sg-upblog (push)
	product https://github.com/stegriff/upblog (fetch)
	product https://github.com/stegriff/upblog (push)
	
So the origin for my website is it's own GitHub repo, but I've also added the `product` remote (in the usual way):

	$ git remote add product https://github.com/stegriff/upblog


### Developing the standard product

I write code to add features to the standard product. Be disciplined! Don't add features to your live site! When a feature is tested and ready, I check everything is committed and then I push to the SP's origin. Now my changes are in the GitHub version at `github.com/stegriff/upblog`.


### Check your site is clean

If I've added new posts, templates, or other sitely things, I make sure they're all committed to the website's origin (`sg-upblog`).


### Ignore some files during pull and merge

We basically want to pull `product` remote changes into my personal now. This has a few caveats. I want to ignore certain files because I don't want to overwrite instance-related config or templates specific to my website. This can be done!

I have added a `.gitattributes` file in the website directory as so:

	/templates/*.* merge=ours
	config.php merge=ours
	.htaccess merge=ours
	README.md merge=ours
	
I'm not totally sure that the templates line actually works yet, but it's a WIP. The merge strategy above needs to be configured at the prompt, like this:

	$ git config --global merge.ours.driver true

I got both of those steps from the [progit book][book].


### Pull and merge

In my website directory:

	$ git pull --no-commit --edit product master
	
Using `--no-commit` and `--edit` gives you peace of mind that you can sort everything out before committing. Since I got my gitattributes file straight, I don't actually use these flags any more, but they might be helpful to you on your first few merges.
	
If there are any problems, I resolve these using my default merging tool (TortoiseMerge) by running

	$ git mergetool -y

If you don't have a nice GUI merge tool, you should install one.

During this process, throw in lots of `git status` for good measure. You might be left with a `.orig` file for any files you used the tool on, so just delete those in your file browser or by using `rm file.orig`.

`git add` everything that you want to commit. I like to get my staged/unstaged into exactly the right state so that I can then `git add -A`

When you're ready, commit the result and push back to origin

	$ git commit -m 'Merged new product features'
	$ git push origin master
	

## Backing out

If you're completely unhappy with how a merge is going and you want to put everything back the way it was:

	$ git merge --abort
	$ git status
	
If the merge has overwritten one or two key files, and you wanted to keep your site's version, this can be fixed (using example of `config.php`):

	$ git reset HEAD config.php
	$ git checkout -- config.php
	$ git status
	
`git reset` is the opposite of `git add`; it unstages a change. `git checkout` reverts changes on a file to the last commit.

## Conclusion

Don't maintain multiple codebases when you don't have to! :)

*Written 2015-09-29*

[book]: https://github.com/progit/progit2/blob/master/book/08-customizing-git/sections/attributes.asc#merge-strategies
