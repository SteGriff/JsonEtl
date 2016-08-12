# Bugzilla Permission Denied in IIS on Windows

![IIS CGI Button](./posts/iis-cgi/iis-cgi.png)

You're setting up Buzilla on Windows with IIS and get a permissions error like this whenever you try to save config values:

	Error in tempfile() using template data\params.XXXXX: Could not create temp file     data\params.I19Ig: Permission denied at Bugzilla/Config.pm line 270.
	For help, please send mail to this site's webmaster, giving this error message and the time and date of the error. 
	[Wed Sep 17 13:14:16 2014] editparams.cgi: Error in tempfile() using template data\params.XXXXX: Could not create temp file data\params.I19Ig: Permission denied at Bugzilla/Config.pm line 270.

You've probably already tried setting the Application Pool to use a different user account and set all the file permissions on `%bugzilla%/data` but it still doesn't work.

This is because the CGI settings are being used, rather than the App Pool.	

## How to fix it

 + Open IIS
 + Navigate to your Buzilla site/application
 + Go to Features View if it's not by default (use the tabs at the bottom of the window)
 + Double-click on CGI
 + Change `Impersonate User` to **False**
 + Restart the site or the whole IIS instance

![IIS CGI Settings](./posts/iis-cgi/iis-cgi-impersonate-user.png)

Try to submit your Bugzilla config again from `/editconfig.cgi` and hopefully everything should now be working!

Hope this helps!

*Written 2015-06-03*