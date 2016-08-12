# Exposing a WebForms usercontrol as a Partial View

If you're like me, you work with ASP.Net MVC and are used to all these new parts and the cool things they offer, but the truth of commercial web development is that sometimes we have to work with and maintain older ASP.Net solutions using WebForms (the predecessor to Razor and MVC).

WebForms doesn't have the concept of a partial view and isn't built for hand-made AJAX; it does a lot of automagical AJAX for you in the background where a page posts back to itself on a regular basis. Anyway, you can still hack in partials in this scenario.

## Add an `asmx` Web Service

Make a special directory in your web solution for services (if you don't already have one). Go on Add Item, and choose Web Service; it should have the file extension asmx. Make one specific to the part of the site you are working with, like you would for a Controller in MVC. For this example I will assume you create it at `/Services/WidgetService.asmx`

## Add a method in your web service to expose your usercontrol

Assuming your usercontrol is called `MyWidget`, and its type is `MyWidget` (which inherits `System.Web.UI.UserControl` at some point in its inheritance tree), and it is stored in your site at `/UserControls/MyWidget.ascx`, then you would add code like this within your newly created `WidgetService.asmx`:

	[WebMethod]
	[ScriptMethod(UseHttpGet=true)]
	public string GetMyWidget()
	{
		//Boilerplate for writing to the response stream
		StringBuilder myStringBuilder = new StringBuilder();
		TextWriter myTextWriter = new StringWriter(myStringBuilder);
		HtmlTextWriter myWriter = new HtmlTextWriter(myTextWriter);

		//Make an anonymous usercontrol just to let us load the one we care about
		UserControl uc = new UserControl();
		MyWidget widget = (MyWidget)uc.LoadControl("~/UserControls/MyWidget.ascx");

		//If you need to set any properties, do it here
		//widget.Data = SomeService.GetWidgetData(State.LoggedInMember);

		//If you have set any data in your usercontrol, you need to manually DataBind it now
		widget.DataBind();
		
		//Render it to a HTML string and return
		widget.RenderControl(myWriter);
		string html = myTextWriter.ToString();
		return html;
	}
	
It's important to set the `[ScriptMethod(UseHttpGet=true)]` so that you can call it from JavaScript, and retrieve it via GET, respectively. The web service will return your HTML, albeit:

 * XML encoded (i.e. with `>` replaced with `&gt;`)
 * Wrapped in a `<string>` XML node.
	 
For example:

	<?xml version="1.0" encoding="utf-8"?>
	<string xmlns="http://tempuri.org/">

	&lt;div class="widget"&gt;
		...

	</string>
	
This is easily parsed in the JS side though:-

## Get the content in JavaScript

I have used a few extra lines of JS than strictly necessary just to illustrate the process. Pay close attention to how the URL is constructed and don't cut corners, notice it is `/path-to-service/service.asmx/FunctionName`.

Our service above returns an entire `<div class='widget'>` node, so we will completely replace the existing one in the DOM with our new node and whatever it contains.

	//Call me when you want to refresh the partial
	function updateHtml() {
		$.ajax({
			type: "GET",
			url: location.protocol + "//" + location.host + "/Services/WidgetService.asmx/GetMyWidget",
			complete: function (data) {
				var xmlDoc = $.parseXML(data.responseText);
				var innerHtml = $(xmlDoc).children('string').text()
				$('.widget').replaceWith(innerHtml);
			}
		});
	}
	
## Conclusion

This worked out really well for us in a scenario where we needed to refresh a small part of the page based containing a data-driven usercontrol component. I hope it helps you as well :)
