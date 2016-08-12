#Convert a MySQL Script for MS SQL 

MySQL and Microsoft's SQL server (sometimes called TSQL) format their scripts slightly differently. Today I have a DB backup from MySQL which I need to import into MS, so here's how!

## Remove backticks

 1.		Hit `Ctrl+H` and Find backtick (\`), Replace with nothing. Click Replace All.  
 2. 	In my script, an apostrophe in a string field was escaped as `\\\'`. This needs to be replaced with `''` for MSSQL.
 3. 	Find and replace all `UNLOCK TABLES;` with nothing.
 4.		Find and replace all `AUTO_INCREMENT` with `IDENTITY(1,1)`
 10.	Now, expand the 'Find options', Tick 'Use' and set it to 'Regular expressions'. 
		Find: `ENGINE[A-Za-z 0-9_=]+;` and replace all of them with nothing.
 11.	I don't want to translate all of the `DROP TABLE IF EXISTS` statements, so I will remove them all like so (with Regular expressions still on):
		Find: `DROP TABLE[A-Za-z 0-9_=]+;`, replace all with nothing.
 12.	Remove the `ON DELETE` bits from constraints:
		Find: `ON DELETE[A-Za-z 0-9_=]+,` replace all with a comma: `,` 
 13.	Find: `LOCK TABLES[A-Za-z 0-9_=]+;` replace all with nothing.