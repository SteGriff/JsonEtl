# My CSS in 2016

## 1. What should CSS be?

 *	Maintainable  
	No specificity hell. No `!important`. Must have rules and class names that are easy to read.
 *	Flexible  
	CSS be reusable like code is reusable
 *	Semantic  
	HTML tags have a meaning, a role: `<header>`
	So should classes describe a role: `<aside class="bio">` (Note for later, this is **Problem 1**)
 *	Strictly beneficial  
	[HTML is (almost) responsive by default][fluidity]. CSS should not break any of the accessibility and responsive features that HTML has out-of-the-box.
 *	Minimal  
	CSS should be small and it should stay out of the way. An unused rule should never be downloaded to the client's browser. Frameworks should be small and unopinionated (Note for later, this is **Problem 2**)


## 2. Bespoke CSS is the best quality CSS for every occassion

It's not the cheapest or quickest way to do it. But the great CSS designers I see online and at work, like [n33][n33] of [HTML5Up!][html5up] fame, [Mu-an][muan], and Mark Allen* (who is behind the HTML+CSS for the [Merseyside Innovation Awards][mia] 2015 onwards), all write stunning, accessible, responsive solutions with little-to-no framework.

Check out the source for the recent HTML5Up theme, [Future Imperfect][fi]. Despite being the developer of the Skel framework, n33 instead writes an artisanal, completely bespoke CSS solution. It satisfies all of the criteria in section 1. It is pretty much perfect.

*Portfolio site pending


## 3. There are no shortcuts

I used to think that a great shortcut to a good-looking design was to never use black (use `#111`) and never use white (use `#fcfcfc`). But recently I've seen some brilliant, tasteful designs using plain old black-on-white, which also provides a contrast and readability boost. And that's because a real designer made those. An alternative name for point number 3 could be "I am not a designer".


## 4. There are people doing good work on frameworks

These guys are featured here for championing all or some of the goals in section 1. They make very minimal frameworks, which kick the pants off Bootstrap and the like, in general. 

 * [Adam Morse][mrmrs] - Tachyons
 * [Brent Jackson][jxnblk] - BassCSS
 * [John Otander][johno] - Furtive

 
## 5. There are compromises

Earlier I referred to **Problem 1** and **Problem 2**
	
 1. Have semantic classes and rules
 2. Have small frameworks
	
The problem here is that minimal frameworks make you write HTML like this:

	<div class="phm phl-ns pvm">
		<p class="measure f3 lh-copy">
			Tachyons was built for designing highly readable...
		</p>
		<p class="measure f4 lh-copy">
			Modules can be altered, extended, or changed...
		</p>
	</div>
	
...where you have a lot of style information in the HTML, and you have to remember to repeat it every time you make an element which you want to be styled in the same way. It would be better like this:

	<div class="intro">
		<p class="main">
			Tachyons was built for designing highly readable...
		</p>
		<p>
			Modules can be altered, extended, or changed...
		</p>
	</div>
	

Now, if you're using a pre-processor, you could have some semantic class `.intro` which inherits `.phm .phl-ns .pvm` as mix-ins. That's a good compromise for source code, but the compiled CSS might be a bit fat.

The bottom line here is that **I'm not yet sure which principal is the greater good**.

## 6. What am I doing with SteGriff CSS?

The CSS for this blog is bespoke, and it is not perfect. CSS is just a means to my ambition of creating a typographically wonderful blog.

[This blog][sgblog], is supposed to be readable, accessible, responsive and sensible. It has a leaning towards "proper" typography methods like [hanging bullets][bullets]. I make liberal use of negative space to let the content breathe. I frequently research readability, and have tweaked the text alignment multiple times as a result. I am reconsidering line lengths because despite my strong desire to use the whole page, there are too many words on a line. I am reconsidering the use of capitalisation for various headings and links.

## Conclusion

This mostly covers the breadth of my opinions on how CSS should be used in 2016. It is a living post and may be updated! Thank you for reading, please email me (ste at this domain) or tweet [@SteGriff][twitter] for discourse. :)

*Written 2016-02-26*
 
[n33]: http://n33.co
[html5up]: http://html5up.net
[muan]: http://muan.co
[mia]: http://miaward.co.uk
[fluidity]: https://github.com/mrmrs/fluidity
[fi]: http://html5up.net/future-imperfect
[mrmrs]: http://mrmrs.cc
[jxnblk]: http://jxnblk.com
[johno]: http://johnotander.com
[sgblog]: http://stegriff.co.uk/upblog
[bullets]: http://www.markboulton.co.uk/journal/five-simple-steps-to-better-typography-part-2
[twitter]: http://twitter.com/stegriff