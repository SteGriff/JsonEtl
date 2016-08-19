# Emoji Studio

Released to Windows Phone Store on 21st April 2015, [Emoji Studio](http://www.windowsphone.com/en-gb/store/app/emoji-studio/1505dd01-1403-46d2-9ec5-1b226a60cef6)
is an art app that lets you place, resize, and arrange any of the characters you can type on the Windows Phone keyboard, including Emoji!

<div id="metrics" class="clearfix">
</div>

*(Emoji Studio gathers anonymous metrics, based on users opening the app and exporting images. I collect phone model and image resolution only.)*

## Story

![Emoji studio screenshot](./posts/emoji-studio/screenshot1s.jpg)

I made it initially as a tech demo to see what would happen to the built-in emoji if you could resize them to larger than they appear in text messages. The results were fun, so I restructured it into an drag-drop app, and then added pinch to resize. The project went on the backburner for a few months while I figured out what I needed to polish to make it worthy of the store.

## Design changes

I had a test version on my phone for a long time to help me focus on making the right interface decisions.
Some things changed from early versions:

 * 	In touch-screen apps, sometimes you accidentally drag the wrong object. To avoid this, I enforced a strict selection system where you had to *tap* an emoji first to outline it, and *then* you could drag it around. People playing with the app didn't anticipate this, and even though some thought it was a good idea, I decided it was best for the app to work like... every other app ;)
 * 	The app-bar at the bottom of the screen used to feature text size controls (increase and decrease), for when emoji were too small to be pinch targets. I decided to scrap this, limiting the smallest size for emoji, and replacing the buttons with Bring-to-Front and Send-to-Back.
 * 	Version 1 of the app was *supposed* to include the ability to select an emoji and edit it to change content or colour.  There's no point; adding an Emoji is such a quick process, you may as well delete and recreate the thing!
 
## Try it

It is available on the Windows Phone store now. You can follow this [Emoji Studio on Windows Phone Store](http://www.windowsphone.com/en-gb/store/app/emoji-studio/1505dd01-1403-46d2-9ec5-1b226a60cef6) link, or search for Emoji Studio, but beware that it's about the 10th app on the list! If you want to help with that situation, please leave a good rating! :)

Making apps for Windows Phone is fun (and easy if you know the .Net stack), and watching the downloads number go up is pretty exciting! Keep your eyes out for my next one... 

*Written 2015-05-11*