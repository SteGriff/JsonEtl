# IIS Error 500.19 when web.config is fine

This article affects you if IIS is showing an HTTP 500.19 error with Error Code `0x8007000d`, but your web.config file looks well formed. A special indicator is that the 'Config source' section just says: `-1: 0:`.

## Solution

This is probably happening because your `web.config` makes use of an extension which is not installed. Commonly this is [URL Rewrite](https://www.iis.net/downloads/microsoft/url-rewrite). You can either delete the config values for each extension until your site is accessible, or install the extensions. 

	<system.webServer>
		...
		<rewrite>
			<!-- I am the offending config section! -->
			<rules>
				...
			</rules>
		</rewrite>


Full error text:

	The requested page cannot be accessed because the related configuration data for the page is invalid.
	Detailed Error Information:
	Module	   IIS Web Core
	Notification	   Unknown
	Handler	   Not yet determined
	Error Code	   0x8007000d
	Config Error	   
	Config File	   \\?\C:\...\web.config
	Requested URL	   <snip>
	Physical Path	   
	Logon Method	   Not yet determined
	Logon User	   Not yet determined
	Config Source:

	   -1: 
		0: 

	More Information:
	This error occurs when there is a problem reading the configuration file for the Web server or Web application. In some cases, the event logs may contain more information about what caused this error.

	View more information »

## Related errors

If you have a different Error Code, check out [kb 942055](https://support.microsoft.com/en-gb/kb/942055) for a table of codes and causes.
