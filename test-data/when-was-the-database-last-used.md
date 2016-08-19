# When was the database last used?

Keep having to [Duck][] this so I thought I'd make a post. In SQL Server, to check when a database was last in use, you can query the `sys.dm_db_index_usage_stats` system table like this:

	select
	DB_NAME(us.[database_id]) as [db],
	OBJECT_NAME(us.[object_id], us.[database_id]) as [object], 
	MAX(us.[last_user_lookup]) as [last_user_lookup],
	MAX(us.[last_user_scan]) as [last_user_scan],
	MAX(us.[last_user_seek]) as [last_user_seek] 
	from sys.dm_db_index_usage_stats as us 
	where us.[database_id] = DB_ID()
	group by us.[database_id], us.[object_id]; 

Using `DB_NAME` and `OBJECT_NAME` affords us better readability than would the internal DB and object IDs.

## Credit

This query was [written by user Russel Hart on Stack Overflow][1] and lacking any other license, is reproduced under [cc-by-sa 3.0][2]

[Duck]: https://duckduckgo.com
[1]: http://stackoverflow.com/a/10255183
[2]: http://creativecommons.org/licenses/by-sa/3.0