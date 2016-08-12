# ISO 8601 in PHP

## The one that ends in 'Z'

To get the zoneless ISO-8601 formatted date, use this format string:

	date("o-m-d\Th:i:s\Z");

To get this:

	2016-02-18T07:56:04Z
	

## The one with the timezone

To get it with timezone, you can use the short formatting code:

	date("c");
	
To get this:

	2016-02-18T07:56:04+00:00