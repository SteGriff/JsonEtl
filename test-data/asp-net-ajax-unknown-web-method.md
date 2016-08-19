# ASP.Net AJAX "Unknown web method, Parameter name: methodName"

## Scenario

You have some backend code in an `.asmx` or `.aspx` file to handle AJAX requests. When you call them from the frontend with a perfectly formed jQuery request, you get the error:

	Unknown web method _____.
	Parameter name: methodName

	Exception Details: System.ArgumentException: Unknown web method _____.

## Causes
If you search for this one, most results will tell you to make it a `public static` class. However, that wasn't necessary in my case and wasn't the problem.

## My Solution
I made my `.asmx` service by copying+pasting an existing one. This screwed me up, because the `.asmx` file still contained a reference to the `.asmx.cs` file from the original, not the copy.

 * Browse the directory with your service files in it. Open the `.asmx` file in a simple editor like Notepad++

 * Verify that the CodeBehind and Class properties reference the correct file
 
Once I fixed the Class property, my code worked.
