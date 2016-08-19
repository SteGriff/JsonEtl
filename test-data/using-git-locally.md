# Using git with local folders

'Git' and 'GitHub' are so synonymous nowadays that you'd be forgiven for thinking you can't have one without the other. I just realised that I personally don't know how to use git its online counterpart, as I've only ever experienced using `clone`, `push` and the like with GitHub URLs. So today, we learn how to do local git together.


## Make a local repo

*This demo is on Windows.*

Make a new folder for your git experiments somewhere, and open a Git Shell in there (mine is `/c/gitexp`). We're going to make a folder with a single file, `file.txt` containing 'Hello World'. You can do all of the following in Windows GUI if you prefer:
 
	$ mkdir NewRepo
	$ cd NewRepo
	$ echo Hello World > file.txt

Let's set up git in here:
 
	$ git init
	$ git add -A
	$ git commit -m 'init NewRepo'
	

## Clone your local repo

Right away, that repository is something we can clone to anywhere else on the PC. We can find out from running `$ git help clone` in the section **Git URLs** that to refer to local repos, you can use one of these syntaxes:

	/c/gitexp/NewRepo
	or
	file:///c/gitexp/NewRepo
	
...simple enough!

So, pop back out to your git experiments folder and clone that repo into a repo with a new name:

	$ cd ..
	$ git clone /c/gitexp/NewRepo NewRepoClone
	
If you `cd` into your cloned directory and check for remotes, you'll see that the `origin` is already set up:

	$ cd NewRepoClone
	$ git remote -v
	origin  C:/gitexp/NewRepo (fetch)
	origin  C:/gitexp/NewRepo (push)
	
...I think it's neat that it already knows this!


## Make changes and try to push them

First, let's make changes in `NewRepoClone` and commit them:

	$ echo Hello World Wide Web > file.txt
	$ git add -A
	$ git commit -m 'Expanded on the Hello message'
	$ git status
	On branch master
	Your branch is ahead of 'origin/master' by 1 commit.
	  (use "git push" to publish your local commits)
	nothing to commit, working directory clean
	
We are going to come across a fun thing here. If you try to `push` your changes to origin, `git` will refuse. Then I will explain why.

	$ git push origin master
	Counting objects: 3, done.
	Writing objects: 100% (3/3), 284 bytes | 0 bytes/s, done.
	Total 3 (delta 0), reused 0 (delta 0)
	remote: error: refusing to update checked out branch: refs/heads/master
	remote: error: By default, updating the current branch in a non-bare repository
	remote: error: is denied, because it will make the index and work tree inconsistent
	...<Snip>...
	To C:/gitexp/NewRepo
	 ! [remote rejected] master -> master (branch is currently checked out)
	error: failed to push some refs to 'C:/gitexp/NewRepo'

The most informative part of this long error message is near the end: **"branch is currently checked out"**.

The crux of the problem is that git knows that the currently-checked-out branch in the origin (`/c/gitexp/NewRepo`) is `master`. A good analogy is that you're 'logged in' to `master` there. It fears that by pushing changes to a branch that someone else (you) might be working on, things will get messed up.


## How to fix the problem and push your changes for real

Really, your origin should be a 'bare repository', and I'll explain what that means later. But to make the push *just work* in our instance, there is a pretty good solution. We can check out a different branch in the origin, like this:

	$ cd ../NewRepo
	$ git branch idle
	$ git checkout idle
	
Now we can go to the clone and actually push our changes:

	$ cd ../NewRepoClone
	$ git push origin master
	Counting objects: 3, done.
	Writing objects: 100% (3/3), 284 bytes | 0 bytes/s, done.
	Total 3 (delta 0), reused 0 (delta 0)
	To C:/gitexp/NewRepo
	   506def7..e2cdc5c  master -> master

Done!


## About bare repos

![Contents of a bare repo](./posts/using-git-locally/bare-repo.png)

When you push to GitHub, the receiving `origin` repo is really a 'bare repo'. This means that it doesn't contain all the working files, it just contains the stuf you'd normally find in the `.git` folder. So it's kind of a server-only repo, more like SVN. Here is a [great article about bare repositories][jonsaints].

You can clone as a bare repository and use that as the dedicated origin to avoid the problems above. By convention, a bare repo directory has a `.git` extension (like in a GitHub URL).

	$ cd /c/gitexp
	$ git clone --bare /c/gitexp/NewRepo NewRepo.git
	
Now you can use your `NewRepo.git` as the origin and have no problems pushing/pulling from it. The only downside is that you can't do work in the origin, but you could always just clone another copy to somewhere else instead :)


[jonsaints]: http://www.saintsjd.com/2011/01/what-is-a-bare-git-repository/
