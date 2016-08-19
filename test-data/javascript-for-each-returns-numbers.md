# Javascript for each returns numbers instead of objects

You've made an ajax request or something and now you have some data. You want to for-each over it, but instead of objects with accessible properties, your code is just outputting numbers. That's because those are the indexes, not the objects!

## Two choices

Instead of:

	for(var i in items)
	{
		//Do something with it
		console.log(i);
	}
	
You can do this:

	for(var i in items)
	{
		//Access the object using the key in the array
		var actualItem = items[i];
		
		//Do something with it
		console.log(i);
	}
	
Or you could use the newfangled `for...of` from ECMAScript 6:

	for(var i of items)
	{
		//Now you have the object instead of the index :)
		//Do something with it
		console.log(i);
	}