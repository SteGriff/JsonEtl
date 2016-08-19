# Umbraco can't publish due to MySql.Web.v20

Twice in two weeks, I've had the problem of not being able to Save and publish a content node in Umbraco. It saves, and appears to publish, but an ASP.Net error pops up complaining about MySql.Web. Even the status is set to published; the content just fails to make it into the cache. So here's how to fix it!

### The Error

	System.Configuration.ConfigurationErrorsException: Could not load file or assembly 'MySql.Web.v20, Version=6.9.4.0, Culture=neutral, PublicKeyToken=c5687fc88969c44d' or one of its dependencies. The system cannot find the file specified. (C:\Windows\Microsoft.NET\Framework\v4.0.30319\Config\machine.config line 286)
	
### The Fix

While you might muck around trying to add and remove different MySQL NuGet packages, the real easy fix is simply to remove the errant line from your machine.config! I think it's put there when a certain extension installs, and can then mess things up.

Open a text editor **as administrator** and then open the file shown in your error message (like `C:\Windows\Microsoft.NET\Framework\v4.0.30319\Config\machine.config`). Go to the relevant line. For me this was a `<sitemap></sitemap>` node, which I removed completely. Save the file, and restart or refresh any websites you were testing. Hopefully you can now *Save and publish* your Umbraco content!

I work for [Village Software](http://villagesoftware.co.uk) and get to write cool new Umbraco solutions most weeks! Check us out if you need professional support