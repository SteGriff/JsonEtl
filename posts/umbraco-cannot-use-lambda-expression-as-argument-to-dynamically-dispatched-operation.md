# Umbraco: Cannot use lambda expression as argument to dynamically dispatched operation

You're probably doing something like this:

	var pages = Umbraco
		.ContentAtRoot()
        .Children
		.OrderBy(p => p.SortOrder);
	
But the result of `ContentAtRoot()` is a dynamic, and you can't sort a dynamic because the compiler doesn't know any of its properties until its too late.

Really easy solution: use the `Typed` version of whatever [Umbraco Helper](http://our.umbraco.org/documentation/reference/querying/UmbracoHelper/) call you were going to use! For example, here's the above, fixed:

	var pages = Umbraco
		.TypedContentAtRoot()
        .Children
		.OrderBy(p => p.SortOrder);

Likewise, you can use `TypedContentAtXPath` instead of `ContentAtXPath` and so on.

Have a great day :)

*I write Umbraco solutions for [Village Software](http://villagesoftware.co.uk)*