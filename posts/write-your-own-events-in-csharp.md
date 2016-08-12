# Write your own C# events 

Every other guide is too long! So this one is as much for my own reference as anyone else's. Let's go!  

We have:

 - A class which owns (and fires) the event, say, "Owner";
 - Some class which handles the event, say, "App".
 
## 1. Write an EventArgs class

`Shift+Alt+C` to add a new class to the project, and make something like this:

	public class SomeEventArgs : EventArgs
    {
		// Add fields if you need them
        public string Text { get; set; }
		
		// Add an initialiser if you need one
        public SomeEventArgs(string text)
        {
            Text = text;
        }
    }


## 2. Write a delegate in `Owner`

Just before your class declaration of `Owner` in `Owner.cs`:

	public delegate void SomeEventHandler(object sender, SomeEventArgs e);
	
## 3. Declare the event in `Owner`

	public class Owner
	{
		// I'm the class that owns and fires the event, hi!
		public event SomeEventHandler SomeEvent;
		
		// The rest of the class code
		// ...
	}

## 4. Create a `void` which fires the event in `Owner`

You don't have to do this, but it makes your events more portable; you can extract them to a base class later and preserve the ability to call them from inheriting classes. Set the protection level (public/protected/...) appropriately.

	public virtual void OnSomeEvent(SomeEventArgs e)
	{
		// This fires the event with the passed args,
		// and a reference to this Owner instance which fired it
		SomeEvent(this, e);
	}
	
## 5. Fire your event somewhere in `Owner`

You made the event for a reason, you probably know where you want to fire it. Just call `OnSomeEvent(new SomeEventArgs())` or add data to your args using a longer constructor if needed.

## 6. Write a handler in `App`

	private void EventOwner_EventHappened(Object sender, SomeEventArgs e)
	{
		// Handle the event
	}
	
## 7. Attach the handler in `App`

	var EventOwner = new Owner();
	EventOwner.SomeEvent += new SomeEventHandler(EventOwner_EventHappened);
	
It's quite a long process but that's everything.  
I hope it helps you out! 

*Written 2015-04-21*