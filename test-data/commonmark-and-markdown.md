# CommonMark and Markdown

Markdown is the web publishing format which has exploded over the last few years. This blog engine and *many, many* others are powered by it. That means that we write posts that look like [this](./posts/commonmark-and-markdown.md) and they come out looking like shiny webpages.

There are a load of ways of doing that conversion; [Upblog](./about-upblog), the software I wrote to power this blog, uses a PHP library to convert to HTML before the content is delivered to you, the reader. Other software like [Pandoc](./using-commonmark-in-pandoc) lets you do it offline, perhaps even using a WYSIWYG Word-like editor.

## Why [CommonMark][1]

Markdown is a poorly-specified language, so people implemented conversion software with differing behaviours. So a person's understanding of Markdown ends up being based on whichever converter they use. This lead the [CommonMark][1] people to come up with a "standard, unambiguous syntax specification for Markdown, along with a suite of comprehensive tests to validate implementations". 

## What next

There are a growing number of libraries which pass the CommonMark tests, including [CommonMark.NET](https://github.com/Knagis/CommonMark.NET/) and PHP league's [PHP commonmark](https://github.com/thephpleague/commonmark)

Lastly, the powerful offline formatter Pandoc now works with CommonMark, and I've written a whole post about [using CommonMark in Pandoc](./using-commonmark-in-pandoc).

Let's all try to implement this cool standard!  
Happy publishing!

*Written 2015-07-31*

[1]: http://commonmark.org
