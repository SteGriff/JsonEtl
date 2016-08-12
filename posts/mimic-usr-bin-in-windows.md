# Mimic /usr/bin in Windows

In UNIX and Linux, you can create symlinks (shortcuts) in /usr/bin which let you run extra apps from the command line. I've made a few custom command line tools in Windows, and I want to be able to run them from the command prompt, using just their name. If you're similar, you'll like this guide. 

You need to be an Administrator for this.  

## Create a programs directory

Make a folder for your custom applications in Program Files. I called mine `C:\Program Files\sg`. It doesn't matter whether you're on 32 bit or 64 bit, you can make the folder in either of your `Program Files` directories.

## Make the directory runnable

To open the Environment Variables editor...

### On Windows 7

 * Hit `Win+R`
 * Put in `SystemPropertiesAdvanced` and press Enter
 * Click the Environment Variables button

### On Windows 8+ the above also works, but this is easier:

 * Hit `Win+W` for Settings search
 * Start typing 'path' or 'envir'
 * Click either of the options (like 'Edit the system environment variables')
 * Click the Environment Variables button

### Edit the Path and PATHEXT...

![Editing the Path variable](./posts/mimic-usr-bin-in-windows/edit-path.PNG)

In the bottom section (System variables), scroll down to Path and double-click it. At the end of the value, type `;C:\Program Files\sg`, that is, a semicolon followed by whatever directory you created earlier. Click OK.

Double click PATHEXT. At the end of the value, type `;.LNK` and click OK. This lets you execute Shortcuts from the command line just like Linux symlinks. 

Click OK, then OK on System Properties.

## Add some shortcuts

![Program shortcuts in situ](./posts/mimic-usr-bin-in-windows/sg-dir.PNG)

If you've already made a command line app which you want to make runnable, go to it's location, right-click the exe, and choose Send to -> Desktop (create shortcut). Rename the shortcut that's now on your desktop to whatever you want the command to be (you probably just want to pare it down to 'MyApp' instead of 'MyApp.exe - Shortcut'

Now, drag the shortcut to your new directory in Program Files.

## Restart your PC

![args program running from cmd](./posts/mimic-usr-bin-in-windows/test-args.PNG)

After your restart, you should be able to open a command prompt (`Win+R`, `cmd`, but you probably knew that if you read up to here...) and type the name of whatever you've added in your new directory to run it.

`args` is just a little program I wrote to test this functionality.

## End

Hope you like my Windows /usr/bin hack! Email me, ste (at this domain) if you want to chat or comment :)
