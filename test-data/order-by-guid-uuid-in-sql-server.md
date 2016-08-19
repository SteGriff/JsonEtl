# Order by GUID/UUID in SQL Server

We have some tables in MS SQL land where the ID fields are GUIDs (also known as UUIDs), and often you want to sort by ID when you run a query:

	select * from kiosk
	order by KioskId
	
...but it doesn't come out in the kind of "alphabetical" order you would expect. This happens to be because of the [precedence of bytes within GUID](http://blogs.msdn.com/b/sqlprogrammability/archive/2006/11/06/how-are-guids-compared-in-sql-server-2005.aspx), which is pretty wild.

If you want a sensible alphabetical output, you can cast the field in your `order by` clause to an `nvarchar`:

	select * from kiosk
	order by cast(KioskId as nvarchar(37))
	
That's all!

*Posted 2015-04-17*