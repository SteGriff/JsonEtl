# Defined

![Defined Icon](./posts/defined/defined-large.png)

This is a web app I made on 18th November 2014 and I forgot to talk about it until now! It's just a dictionary, powered by the [Wordnik][] API. In this season of life, I was particularly into making minimal web services, and rapid prototypes.

The address is currently just [stegriff.co.uk/defined](http://stegriff.co.uk/defined) because it doesn't deserve it's own domain! 

## What I planned to do

The plan was to make a clever worker-process-style backend where the client could initiate a data request and then check back in on it regularly to see if more data was available. With Wordnik, calls for definitions, etymologies and other data are separate, so this would make sense to give the user a satisfying [async](./ajax-asap) experience.

## What I actually did

Instead I just [made the minimum viable product](./make-the-mvp) which consisted of a basic fetch from Wordnik, formatted as HTML. It's not even cached anywhere. Pretty poor really.

## The icon

Making the icon was really enjoyable! It's based on an open book, a bookstand, and the letter 'D'.

Thanks for reading about Defined! For another rapid prototype, see [SIGN](./sign).

*Written 2015-05-11*

[Wordnik]: https://wordnik.com/
