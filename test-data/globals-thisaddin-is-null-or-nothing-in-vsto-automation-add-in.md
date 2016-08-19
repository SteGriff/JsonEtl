# Globals.ThisAddIn is null or Nothing in VSTO Automation Add-In

## Scenario

You've created a VSTO Add-In and you want to call some of the code from VBA, so you've followed the procedure to expose `RequestComAddInAutomationService`. But when you create an instance of that exposed object and try to call one of its properties or methods, you get an error because `Globals.ThisAddIn == null` or `Nothing`.

You may be making the same mistake I made, which is to ask for a `New AddInUtilities` instead of using the existing instance.

## Example VSTO code in ThisAddIn.vb

Your exposed class could be called anything, but for these examples, I'm going to use `AddInUtilities`.

	Private utilities As AddInUtilities

	Protected Overrides Function RequestComAddInAutomationService() As Object
		If utilities Is Nothing Then
			utilities = New AddInUtilities()
		End If
		Return utilities
	End Function
	
## Your bad VBA code

If you've set up your projects like I do, so that you [get Intellisense in VBA][sg1], then you may have been tempted to write your code like the sample below:

	Dim utils = New AddInUtilities
	utils.DoSomething
	
The problem with this is that you've created a new instance of your Automation object (`AddInUtilities`), therefore it doesn't have access to `Globals.ThisAddIn`. Check out the [VBA-VSTO Walkthrough on MSDN][msdn], and you'll see that they get the automation object like this:

	Sub CallVSTOMethod()
		Dim addIn As COMAddIn
		Dim automationObject As Object
		Set addIn = Application.COMAddIns("ExcelImportData")
		Set automationObject = addIn.Object
		automationObject.ImportData
	End Sub

I've previously looked at this snippet and gone "Bah! That's stupid, because they treat their automationObject as an `Object` and don't get any early binding or Intellisense." and thereby I led myself into failure.

## Fixing your VBA

Your easy fix for one-offs is to use the `CallVSTOMethod` snippet from above, but change `Object` to `AddInUtilities` so that you get Intellisense and early binding.

The (slightly) more sophisticated approach, to get properly nice global access to your class(with Intellisense) is to add something like this in a VBA Module (all modules are global):

	Private pAi As Core

	'Get the AddIn Automation Object
	Public Property Get Ai()
		If pAi Is Nothing Then
			Dim MyAddIn As COMAddIn
			'Set the right name here instead of "MyAddIn"
			Set MyAddIn = Application.COMAddIns("MyAddIn") 
			Set pAi = WtsrAddIn.Object
		End If
		Set Ai = pAi
	End Property

And then anywhere you want to make use of a VSTO method, call it like so:

	Ai.DoSomething
	
## Conclusion

Hopefully this will help you with your Globals.ThisAddIn object being null! If you are really stuck with VBA-VSTO interoperability, follow the [MSDN tutorial][msdn] and then customise it as necessary.

I have found that with Office solutions, writing basic test projects and spreadsheets is really helpful for proving something works before moving the principles into my main project.

[sg1]: ./add-a-reference-to-vsto-project-from-vba-editor
[msdn]: https://msdn.microsoft.com/en-us/library/bb608614.aspx