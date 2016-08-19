# Quickstart a Cordova application

This guide uses the Cordova CLI, and is a condensed version of the [Apache Cordova Documentation](http://cordova.apache.org/docs/en/5.0.0//guide_cli_index.md.html).

* Install any development kits you'll need to compile for your target platforms;
* Install Node and Git if you haven't already;
* Install Cordova if you haven't already, using `npm install -g cordova` (`-g` makes it global).

## Start an app

**Run the command prompt as admin on Windows** (File, Open command prompt, Open command prompt as administrator)

Run the following commands using the directory you want to create, a unique namespace you own, and a new app name:

	cordova create AppDirectory uk.co.mywebsite.myapp AppName
	cd AppDirectory
	cordova platform add wp8
	cordova platform add android
	
...adding a line for any other platforms you want to target. The opposite of `add` is `rm`.

This generated a skeleton directory with some default files. The docs say,

> Any initialization should be specified as part of the deviceready event handler, referenced by default from www/js/index.js.

...but I feel like it doesn't matter. You can wipe out basically all of the HTML, JS, and CSS installed by `cordova create` and it still works, but you should preserve the useful directory structure.

Add plugins if you want, specifying a cordova-registered name or a git url:

	cordova plugin add phonegap-plugin-barcodescanner
	cordova plugin add https://github.com/apache/cordova-plugin-console.git
	
Use `rm` to remove

## Build and deploy

To build and deploy your current code onto attached USB devices, just type

	cordova run

### A breakdown of what this does

This does cordova `prepare` and `compile` as pre-requisites, then runs the build on available devices.

* `prepare` copies the latest files across to each platform folder, ready to compile;
* `compile` gets the appropriate compiler (MSBuild, JDK, etc.) to build it into a native app;
* `build` is an alias command which does both of the above but does not run the project;
* `run` does everything.

If you want to run the *existing* build without recompiling, use `cordova run --nobuild`. For info, try `cordova help run`.

Have fun and check out the documentation from the start of this document if you get stuck! :)
Ste

*Written 2015-07-17*