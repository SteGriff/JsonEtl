# Bugzilla cannot determine local time zone on Windows

If you get this error in a new Bugzilla installation on Windows: "bugzilla undef error - Cannot determine local time zone", it could be because you don't have the Win32-specific part of the Perl `DateTime::TimeZone` library.

You can check by going to your Perl directory, like `C:\Perl64\site\lib\DateTime\TimeZone\Local` (for ActiveState Perl). **Is `Win32.pm` there?**

## How to install DateTime-TimeZone-Local-Win32

 + Open an admin command prompt
 + `cd` to your Bugzilla directory, e.g. `C:\inetpub\wwwroot\bugzilla\bugzilla-4.4.9` 
 + Run `ppm install DateTime-TimeZone-Local-Win32`
 + Restart IIS for good measure
 
That should fix it; try refreshing your broken Bugzilla page. Good luck!

*Written 2015-06-03*