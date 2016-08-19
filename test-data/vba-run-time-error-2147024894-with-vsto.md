# VBA run-time Error '-2147024894 (80070002)' with VSTO 

I was developing a VSTO Add-In for Excel. One day it was working and the next day it was not, and I had the following error:

 > Run-time error -2147024894 (80070002)
 > Automation error
 > The system cannot find the file specified
 
This was because the registered assembly no longer matched the bitness of my Add-In. So Visual Studio was probably (for some reason) running the 32-bit regasm, meaning that my 64-bit Office could not locate the assembly at run-time.

## Resolution

I fixed this problem by changing the project properties of my VSTO. On the Build tab of properties, I changed Platform target to `x64`. I closed Excel and Rebuilt All in my VSTO solution. This fixed the problem.
