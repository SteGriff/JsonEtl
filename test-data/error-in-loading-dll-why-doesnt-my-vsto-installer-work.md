# Error in loading DLL - Why doesn't my VSTO installer work?

## My problem and solution

I have a workbook with a significant amount of [VBA code, most of which calls methods of a VSTO add-in][1] containing lots of business logic which has been ported from VBA into VB.Net. This works fine on developer machines, but when we create an installer and deploy the add-in, it doesn't work right. When I load the spreadsheet, a VBA sub, "OnOpen" is called, and throws up an error (on a line where it calls my .Net code), "Error in loading DLL".

**The solution** in my case was to run the same [command line to register the dependent DLLs][2] that we always do as part of developer machine setup. I added a setup step to the vdproj installer project which runs a batch file to execute these steps.

## Other solutions

This post is mainly here to collate helpful resources for debugging VSTO Add-In installations.

### Pragmateek Troubleshooting Guide

This is a great run-down of errors and their causes:  
[Error in loading DLL when referencing a TLB](http://pragmateek.com/excel-addins-troubleshooting-guide/#8220Error_in_loading_DLL8221_when_referencing_a_TLB)

### Add-In Spy

 * [Download](https://github.com/VillageSoftware/AddInSpy/releases/tag/v1.0.1)
 * [Original source](https://github.com/NetOfficeFw/AddInSpy)
 * [Article](https://blogs.msdn.microsoft.com/andreww/2008/10/01/addinspy-diagnosingtroubleshooting-office-add-ins/)

### Registry Entries for VSTO Add-ins (MSDN)

[This MSDN article](https://msdn.microsoft.com/en-us/library/bb386106.aspx) specifies values for `LoadBehaviour` and how to specify the correct `.vsto` path in the Manifest field.  


### Deploying an Office Solution by Using Windows Installer (MSDN)

This MSDN article refers to [creating an InstallShield LE installer project] for your add-in(https://msdn.microsoft.com/en-us/library/cc442767.aspx).

[1]: http://stegriff.co.uk/upblog/globals-thisaddin-is-null-or-nothing-in-vsto-automation-add-in
[2]: http://www.stegriff.co.uk/upblog/add-a-reference-to-vsto-project-from-vba-editor