# Serialize .Net objects to file and back again

When writing some progams, especially games, you might want an easy way to serialize an object with all of its properites into binary so that it can be saved to a file. Here's a good way!

**Full example source code** is at [github.com/SteGriff/SerializerExample](https://github.com/SteGriff/SerializerExample)

## 1. Mark your game or data class as [Serializable]

This tells the system that the object can be folded down to binary. There are some restrictions on what can and can't be serialized, but you can figure them out as they come up, right? :) All the base types are serializable.

In the example code, we serialize a [`GameObject`](https://github.com/SteGriff/SerializerExample/blob/master/SerializerExample/GameObject.cs) for a SimCity kind of thing.

	using System;
	using System.Collections.Generic;

	namespace SerializerExample
	{
		[Serializable]
		public class GameObject
		{
			public string PlayerName { get; set; }
			...
		}
	}
	
## 2. Use a helper class to handle serializing

Or use the one I've [provided](https://github.com/SteGriff/SerializerExample/blob/master/SerializerExample/Serializer.cs). This has a couple of simple calls:

	public static void ObjectToBinary(object Object, out byte[] Output)
	public static void BinaryToObject<T>(byte[] Binary, out T Object)

They basically do their work using a `BinaryFormatter` and a `MemoryStream`. If you want more detail, dig into the file linked above.

## 3. Use the exposed methods to read/write your data

	//Set up byte array for the data
	byte[] gameData;

	//Serialize your game object into the byte array
	Serializer.ObjectToBinary(game, out gameData);

	//You can then save it to file or perhaps transmit it over the network
	
	//(Optional) marshall the binary into a base64 string if you're going to put it in a JSON object
	string gameData64 = Convert.ToBase64String(gameData);

## Conclusion

Using the `[Serializable]` attribute allows you to export objects really easily if you write wrappers around `BinaryFormatter`!

**Sponsored by** [Village Software](http://villagesoftware.co.uk/) - we write enterprise-grade applications which integrate your hardware with your business processes. Come to us for a quote on improving or replacing your large systems!