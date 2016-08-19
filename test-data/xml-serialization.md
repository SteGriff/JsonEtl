# XML Serialization tricks in .Net

We had some fairly complicated XML to parse here at the office yesterday. I'm going to give some examples here, but the node names have been changed because they're part of a proprietary standard (I'm not really working with farmyard XML ;) ). This article is in C#.


## XmlArray annotation

Now, in `System.Xml.Serialization` there are already a few cool tricks for arrays of XML. If you have a simple, predictable array like this one:

	<Farm>
		<Barn>
			<Animal>Cow</Animal>
			<Animal>Pig</Animal>
		</Barn>
	<Farm>
	
Then in your code model, you can make use of these annotations:

    [XmlRoot("Farm")]
    public class Farm
    {
        [XmlArray("Barn")]
        [XmlArrayItem("Animal")]
        public List<string> Animals { get; set; }
    }

What we're basically doing here is creating a kind of "transparent" array holder in the name of *Barn*. When your XML is turned into objects, *Barn* won't actually appear, but will allow *Animals* to appear as a `List` directly within the *Farm*.

**So in this way, we can parse the XML successfully, but throw away irrelevant details of how it was stored as XML.**


## Refresher on deserializing

Deserializing is changing XML into objects (the main point of this article). Just in case we've forgotten (or never done it before) the code goes something like this:

	//Here's our XML as a string, but it could be loaded from a file or web service
	string myXml = "<Farm> <Barn> <Animal>Cow</Animal> <Animal>Pig</Animal> </Barn> <Farm>";
	
	//It requires a Stream type, so let's make a MemoryStream on top of the string
	MemoryStream memStream = new MemoryStream(Encoding.UTF8.GetBytes(myXml));
	
	//Make a serializer, and deserialize using our model
	XmlSerializer serializer = new XmlSerializer(typeof(Farm));
	var theFarm = (Farm)serializer.Deserialize(memStream);


## Capturing attributes and inner text

What if I have an array of nodes with attributes as well as inner text (or body content, or Xml Text or whatever you want to call it)

	<Farm>
		<Barn>
			<Animal Name="Horse">2</Animal>
			<Animal Name="Pig">15</Animal>
			...
			
Your model changes like this:

    [XmlRoot("Farm")]
    public class Farm
    {
        [XmlArray("Barn")]
        [XmlArrayItem("Animal")]
        public List<Animal> Animals { get; set; }
		
        public class Animal
        {
            [XmlAttribute("Name")]
            public string Name { get; set; }

            [XmlText]
            public string Quantity {get;set;}
        }
    }

I've declared a new class within *Farm*, called *Animal*, for decoding the new, more complex *Animal* type. Note that I could have defined it higher up, but it may help you to keep your namespace tidy (especially in a large, message-handling program) to have inner classes.

The list of Animals changes to be... well, a `List<Animal>` instead of a `List<string>`. The Name attribute is marked up with a little annotation, and we use the `[XmlText]` annotation to capture the inner text of the node as 'Quantity'. You can store it under any name you want, of course.


## Capturing multiple groups of arrays

	<Farm>
		<Pasture>
			<Animal Name="Cow">12</Animal>
			<Animal Name="Goat">4</Animal>
		</Pasture>
		<Barn>
			<Animal Name="Horse">2</Animal>
			<Animal Name="Pig">15</Animal>
			<SheepPen>
				<Animal Name="Sheep">3</Animal>
				<Animal Name="Lamb">12</Animal>
			</SheepPen>
		</Barn>
	</Farm>
	
Now, in our Barn, we don't have a pure array of Animals -- it's mixed in amongst another array type, the *SheepPen*. So how do we deserialize this? Barn is going to become a class of its own; it's not a trivial details any more and we need to capture all of its content, and instead of using XmlArray, we will capture Animals in arrays implicitly. Pasture takes on a simple container role like Barn had before.

	[XmlRoot("Farm")]
	public class Farm
	{
		[XmlArray("Pasture")]
		[XmlArrayItem("Animal")]
		public List<Animal> Animals { get; set; }

		[XmlElement("Barn")]
		public BarnNode Barn { get; set; }

		public class Animal
		{
			[XmlAttribute("Name")]
			public string Name { get; set; }

			[XmlText]
			public string Quantity { get; set; }
		}

		public class BarnNode
		{
			[XmlElement("Animal")]
			public Animal[] Animals { get; set; }

			[XmlElement("SheepPen")]
			public SheepPenNode SheepPen { get; set; }

			public class SheepPenNode
			{
				[XmlElement("Animal")]
				public Animal[] Animals { get; set; }
			}
		}
	}

I've had to tack 'Node' on the end of some of the class names because you can't have a `Barn Barn` and I didn't want to mess with inconsistent letter casings. Nevertheless, this is the structure that will deserialize our complex farm. Instead of marking `[XmlArrayItem]`, we use the simple `[XmlElement]` to tell the parser what the node names are, and then implement them as `List<Animal>` (or `Animal[]` if you prefer... that also works). It's smart enough to look for multiple entries and put them in the list/array.


## Download the project

You can get the code for the final level at [https://github.com/SteGriff/XmlFarm](https://github.com/SteGriff/XmlFarm).
Enjoy messing with XML and C#, email me if you want (ste, at this domain).
