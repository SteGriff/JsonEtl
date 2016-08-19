# Using email addresses as LOGIN usernames on Azure SQL

> If your SQL Database server is called `myazureserver` and your login is `user@example.com`, then you must supply your login as `user@example.com@myazureserver`.

This is a modified quote from the documentation for [CREATE LOGIN][1] (section titled 'Windows Azure SQL Database Logins').

`user@example.com@myazureserver` is obviously a very clumsy username. If you maintain some software which defers authentication to the SQL Server, and are migrating your data to Azure SQL V12 (as I am) then you probably don't want to require that your users get accustomed to adding an extra `@server` to the end of their username.

## Prospective solutions

Currently this doesn't have a good fix. A workaround is to rename your users' accounts during migration to remove the `@` sign, for example to `user.example.com`

I also have a **[uservoice request for better support for email address logins][2]** to which you could add some votes :)

I'll leave you with more from that documentation page:

> In some methods of connecting to SQL Database, such as sqlcmd, you must append the SQL Database server name to the login name in the connection string by using the `<login>@<server>` notation. For example, if your login is login1 and the fully qualified name of the SQL Database server is servername.database.windows.net, the username parameter of the connection string should be login1@servername. Because the total length of the username parameter is 128 characters, `login_name` is limited to 127 characters minus the length of the server name. In the example, `login_name` can only be 117 characters long because servername is 10 characters.

> SQL Server rules allow you create a SQL Server authentication login in the format `<loginname>@<servername>`. If your SQL Database server is myazureserver and your login is myemail@live.com, then you must supply your login as myemail@live.com@myazureserver.

*Written 2015-09-09*	

[1]: https://msdn.microsoft.com/en-us/library/ms189751.aspx
[2]: http://feedback.azure.com/forums/217321-sql-database/suggestions/9684924-better-support-for-email-address-logins