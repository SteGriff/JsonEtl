# Publish or Web Deploy an Azure Web App with MSBuild

It's taken me a day and half to get this working. We have a Web App project which needs to be pushed to Azure from Jenkins. I was following this guide, [Publish an Azure Web Site from the Command Line][1] but it wasn't doing the publish/deploy part at all.

At one point I thought it was because I was trying to build the solution rather than the key project, but trying to build the project with MSBuild led to a lot of mess due to its dependencies.

I messed with loads of things, but **the kicker was putting `VisualStudioVersion=12.0` in the properties of the MSBuild call**. The  version number you put in here corresponds to a tools directory such as `C:\Program Files (x86)\MSBuild\Microsoft\VisualStudio\v12.0`. Mine was defaulting to v11.0 but I didn't have `/Web` or `/WebApplication` tooling directories in the v11.0 folder. So check you have those directories in whichever version folder you choose!

Here's my build command (which I run from the solution directory)

	C:\Windows\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe /p:DeployOnBuild=true;Configuration=Test;PublishProfile=azure-lcws-test;VisualStudioVersion=12.0 MySolution.sln
	
This uses my custom `PublishProfile` and `Configuration`. It's just here for reference.

OK, that's all. If you have a slightly different twist on the problem and manage to fix it, post it online somewhere! :)

*Written 2015-09-03*

[1]: http://blog.greatrexpectations.com/2013/02/02/publish-an-azure-web-site-from-the-command-line/