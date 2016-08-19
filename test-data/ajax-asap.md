# AJAX ASAP

This was just a passing tweet but I want to give it another look...

<blockquote class="twitter-tweet" lang="en"><p lang="en" dir="ltr">AJAX is sometime not Async, not JavaScript, and not XML. So I say we call it &quot;ASAP&quot;: Async/Awaitable Scripts and Partials&#10;Whaddya think</p>&mdash; Ste Griffiths (@SteGriff) <a href="https://twitter.com/SteGriff/status/618119609049288704">July 6, 2015</a></blockquote>
<script async src="//platform.twitter.com/widgets.js" charset="utf-8"></script>

What I'm saying about AJAX is true as far as I know. This is the loose term for the system used any time you're on a web page and it updates itself without you having to refresh. When you're on Twitter or Facebook and it says more posts are available, or anything with a live stream of news, that's AJAX.

AJAX means "Asynchronous JavaScript and XML" but that's looking a bit old hat now, because we mostly use a newer format called JSON instead of XML, but sometimes we use HTML, and in fact you can transfer any kind of data you want... it's complicated! Regardless of the format, the developer is generally trying to load a "**partial view**" - refreshing a section of the page, not the whole thing.

My next point is that this isn't always Asynchronous. Async means that other things can continue to happen in the background while you wait for this data. Then when it comes back, a piece of code known as a "callback" handles the message and applies it to the page. But sometimes you want to make absolutely sure that some request gets fielded before you carry on. That's synchronous (N.b. [synchronous requests considered harmful][1]). In .NET, we have a term for this which is `awaitable`, which handily begins with an 'A'. If something is **Awaitable** you can either let it run asynchronously, or you can *await* the return (synchronously).

Lastly (and most tenuously), scripting doesn't *just* mean JavaScript. Currently, there are some higher-level scripting languages, but all of them compile down to JavaScript because that's what browsers support. It's possible in the future that browsers will be able to run other script languages. In the past, VBScript used to be supported in browsers, for example.

Therefore, I propose that a fresh new name for AJAX would be:  
**ASAP - Awaitable Scripts and Partials**

Tweet [@SteGriff](https://twitter.com/SteGriff/status/618119609049288704) if you want to discuss/argue :)

*Written 2015-08-04*

[1]: https://developer.mozilla.org/en-US/docs/Web/API/XMLHttpRequest#open%28%29
