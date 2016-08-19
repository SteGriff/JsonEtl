# Get intellisense for VSTO add-in in VBA

If you're calling VSTO code from VBA, like in [this article][1], you may want to add a reference to your VSTO project so that you get Intellisense in the VBA Editor. If you can't find your add-in in the Tools/References list, and Browsing for it results in a "Can't add a reference to the specified file" message, then you need to build a `.tlb`.


## Building a `.tlb`

 * Go to the Properties of your VSTO project
 * Go to the Build tab
 * Tick 'Register for COM interop'
 * Build it
 
It will now build a `.tlb` alongside the `.dll`. Go back to VBA Editor's Tools/References and you can now Browse and add the `.tlb`.

Anytime you want to rebuild, you need to stop your VBA project from running using the Stop button.

### If your `.tlb` was not created, and your code uses Visual Basic features like `Collection`

Visual-Basic-specific features require you to be able to roll Microsoft.VisualBasic.dll as a tlb. This can fail silently in the background. The fix, as described [here][VB], is to run `regasm /tlb` against `C:\Windows\Microsoft.NET\Framework\v4.0.30319\microsoft.visualbasic.dll`. You should then be able to build and receive your tlb.


## Mark your classes as `ComVisible`

You need to mark the relevant classes with `[ComVisible(true)]` (C#) or `<ComVisible(True)> _` (VB)... this requires `using System.Runtime.InteropServices;`


## Mark your class as `ClassInterface(ClassInterfaceType.AutoDual)`

This provides early bindings to the reference. You just need to make sure that the versions of your tlb stay in sync with the built version of your code (vsto and dll), otherwise the Intellisense won't match the functionality.

    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDual)]
    public class BusinessLogic : StandardOleMarshalObject, IMyAddInInterface
    {
		...
	}


## End

Sponsored by [Village Software](http://villagesoftware.co.uk)


[1]: https://blogs.msdn.microsoft.com/andreww/2007/01/15/vsto-add-ins-comaddins-and-requestcomaddinautomationservice/
[VB]: https://support.microsoft.com/en-us/kb/316163