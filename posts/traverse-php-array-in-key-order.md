#Traverse PHP array in key order

Say you've got an array with numerical keys (which aren't continuous), such as file information keyed by *file modified* time:

	//Make an array of all files in the directory './stuff'
	$fileArray = [];
	foreach(glob('stuff/*') as $file) 
	{
		//Get the time it was last updated (int)
		$modified = filemtime($file);

		//Make a file info object
		$fileInfo = [
			"name" => $file,
			"modified" => $modified
		];
		
		//Store it using the 'file modified time' as the key
		$fileArray[$modified] = $fileInfo;
	}
	
If you try to `foreach` over these, they come out in the order they went into the array, regardless of keys.

## To sort the output by key

My way to fix this problem is to get the array of keys, sort that, and then use it to iterate:

	//Get the keys and sort them
	$keys = array_keys($fileArray);
	sort($keys);

	//Iterate over the keys, which are now sorted:
	foreach($keys as $key)
	{
		$thisFile = $fileArray[$key];
		echo $thisFile["modified"] + " - " + $thisFile["name"];
	}
		
