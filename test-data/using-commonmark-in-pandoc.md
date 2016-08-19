# Using CommonMark in Pandoc

If you're doing offline publishing of Markdown to any other format under the sun, you probably are (or should be) using [Pandoc](http://pandoc.org). And I'll come onto *how* to do that in a minute, if you don't know! But, as many web people now recognise, [Markdown is not sufficient](./commonmark-and-markdown) because it has inconsistencies and ambiguities as a language.

Cool news number #1 is that there is a solution called [CommonMark][1] &ndash; a strict specification which all the world's Markdown experts (that is, implementers from GitHub, Pandoc, Discourse, StackExchange, Reddit...) are working on, and standardising upon!

Cool news number #2 is that since a couple of months ago, [Pandoc supports CommonMark][2]... which makes a ton of sense, since (as I said) the Pandoc maintainer (JGM) is *on the CommonMark committee*. So if your pandoc version (`pandoc -v`) is greater than 1.14 then you're all set.

## How to use it

So now you can UNLEASH THE POWER of this neat workflow. Find the latest [release of Pandoc](https://github.com/jgm/pandoc/releases/) and install it for your system if you need to.

Open an admin command prompt (`Win+X`), go to wherever your CommonMark files are and run

	pandoc -r commonmark -w html -s -o MyDocs.htm MyCommonmark.md
	
...replacing options as appropriate. Here's a breakdown of those options in case they're new on you:

	-r <format to read> (-i also works)
	-w <format to write> (-o also works)
	-s Make a stand-alone file (essential if you choose to output docx)
	-o <output file>
	MyCommonmark.md (the last option is the input file)
	
## What I use it for

 * Writing documentation for our internal Google Sites wiki (I like to write in CommonMark and then convert to HTML)
 * University assignments `pandoc -r commonmark -w docx -s -o work.docx work.md`
 
...but I'm barely scratching the surface of all of the cool outputs I could be getting!

## Interactive mode

"I just want to know how this syntax will render as HTML..."

You can run

	pandoc -r commonmark -w html
	
...to open an interactive mode

	Does it -- convert n-dashes I wonder?
	#IsItAHashTag or is it a heading? (It's a hashtag)
	
Just press `Ctrl+C` when you're done, and the HTML will print to console.

## Conclusion

I hope this empowers you to do neat things with publishing formats! Life gets simpler when we prioritise document structure over document style!

*Written 2015-07-31*

[1]: http://commonmark.org
[2]: http://pandoc.org/releases.html#pandoc-1.14-27-may-2015