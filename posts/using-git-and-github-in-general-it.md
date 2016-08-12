# Using Git and GitHub in general IT

If you need version control in the office and you're not all software developers, git can still be a good choice. If you want to keep your repositories online at GitHub you can also use the great GitHub Desktop client. This is a 'getting started' guide.

## What's a repository?

A repository ("repo") is like a folder. You generally have one repo for each project you work on. In general IT, it might be a good idea to have seperate repos for, for example, "Signs and templates" and "Client spreadsheets". If your business has one great big spreadsheet or database which is the absolute centre of the business, it would be good to give that a repository all to itself or with it's (hopefully few) supporting files.

Your repositories will belong to the organisation (not an individual), and you will be able to control employees' individual access to each repo.

-----

## Set up a GitHub account if you don't have one

Each person in your organisation will need to [join GitHub][joingh]. They should choose the Free plan when they sign up.

## Create an organisation

The head of IT or some other Highly Responsible Person, having set up their account, should log in and [create an organisation][createorg]. During this process you will choose how many private repositories you want.

### Open Sourcing 

You can pay nothing for GitHub, but under the free plan, anyone will be able to look at your repository contents. This is sometimes appropriate for things which are not business secret and not customer related (like handbooks, motivational posters, or files detailing your best practices). Lots of [UK government][ukgov] agencies and public groups like [DoES Liverpool][does] use GH for this kind of thing (as well as their code).

### Private repositories

If you are keeping any kind of customer, client, or otherwise secure data, you must use a private repository for that. Here we can bestow some private repos upon your organistion by choosing a pricing tier. If you're not sure how many you'll need, start off with the cheapest package and see how it goes.

### Invite members

On the final page of setting up the org, invite your colleagues to be **Members** of the organisation. You can make people to be **Owners**, but you shouldn't do this unless they are very technically competent and trustworthy. You may wish to designate your admin person as a Billing Manager. You can read more about [permission levels in an organisation][permission].

-----

## Download the software

 * Download and run the [GitHub Desktop][ghdesktop] installer. (When you're ready, every PC will need the software)
 * When it's installed, enter your log in details
 * Allow the changes to 'gitconfig'
 
-----

## Using GitHub for Windows

Next we will put your existing folders under version control, and onto GitHub. I am going to assume that you have already organised your work into a sensible family of folders.

### Create a repository in an existing folder

As an example, I'm using my folder for "M256", one of my university courses.

![Adding a folder](./posts/github-for-it/add-small.png)

 * Click the Plus icon in the top left of the GitHub Desktop window
 * Click `Add` if it is not already selected
 * Click `Browse` and locate the folder
 * A warning will pop up to say "The directory does not appear to be a git repository" - Click on `create a repository`
 * (There is now a field called Git ignore; this selects a list of files and filetypes to ignore. Leaving it set to `Windows` is a sensible default, as this will exclude pesky files like `thumbs.db`)
 * Click the tick, "Create Repository"
 
### Commit files

Some stuff will now happen. You will be taken to the `History` tab, which tells you the "commits" there have been so far. There has been one commit, which was configuration files getting set when you created the repo just now.

**None of your files are committed yet.** Switch to the `Changes` tab at the top and you will see the files which are earmarked to be added.

To commit them all, simply enter a `Summary` message and click the tick button, "Commit to master". On the first commit, I tend just to write "Init" or "Initial commit" in there.

Otherwise, you could un-tick some files to exclude them. There is a more permanent solution for ignoring files, which I have detailed in a separate article, ["Ignore certain files and types in GitHub Desktop"][gitignore].

#### Commit failed

If the commit fails, make sure all of the files are actually available to you right now. For example, if they are OneDrive/Dropbox files, make sure they are available offline before trying to commit again.


### Push files

After you commit, you will see a blank `Changes` window. Nice and clean!

 * Click `Publish` in the top right of the window
 * Add a short description
 * Click your profile icon and select your organisation
 * Tick `Private repository` if necessary
 * Click the big `Publish MyRepository` button

-----

## How to work together

You may be used to using a shared drive for company files. Well, GitHub is your shared drive now. Here's how it will work:

 * One person sets up the repository (as above)
 * Anyone who needs to read or work on those files, "clones" or "checks out" the repository from GitHub
 * They make their changes
 * They "push" their changes back to the master copy (online)
 
### Clone the repository

*From here onwards, this article is a work-in-progress*

Let's say a colleague, Abi, wants to check out your repo. She should:

 * Open GitHub Desktop
 * Click `Clone`
 * ... 

-----

Contact for feedback and private consultation: github at stegriff.co.uk


[ghdesktop]: https://desktop.github.com/
[joingh]: https://github.com/join
[createorg]: https://github.com/join
[ukgov]: https://government.github.com/community/#uk-central
[does]: https://github.com/DoESLiverpool
[permission]: https://help.github.com/articles/permission-levels-for-an-organization/
[gitignore]: ./ignore-certain-files-and-types-in-github-desktop