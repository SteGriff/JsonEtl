# Save a generated value from one SQL query to use in the next query

Say you want to insert a value into `Dog` and then reuse some aspect of it -- such as an automatically generated ID -- to use in the next query where you add a `DogHouse` mapping. The ID might be an identity column, or a GUID which you populated with `NEWID()` or something.

## Overview of the pattern

We can use this in MSSQL/T-SQL:

 - Create a temporary table (denoted by hash sign) which has only the field you want to preserve;
 - Do your `insert` statement with an added `output` clause as below;
 - Then (for tidiness points) move the value from your temp table into a variable. You can use this until your next `GO` statement;
 - Make use of the variable in future `insert` statements.

## Example 1

The tables in the example are defined like this:
	
	create table Dog (
		ID bigint primary key identity(1,1) not null,
		Name nvarchar(20),
		Age tinyint
	)

	create table DogHouse
	(
		DogHouseId bigint primary key identity(1,1) not null,
		DogId bigint,
		HouseId bigint
	)

Here's the code for the insert statements:

	-- Create temp table
	create table #Inserted (DogId bigint)

	-- Do the insert, outputting the inserted.ID into the temp table
	-- The ID is generated because it is Identity(1,1)
	insert into Dog (Name, Age)
	output inserted.ID into #Inserted
	values
		('Gordon', 2)
		-- Gordon is a great name for a dog, IMO.

	-- Move value to a variable and drop the temp.
	declare @InsertedDogId bigint = (select * from #Inserted);
	drop table #Inserted
	
	-- Use the value in some other tables!
	insert into DogHouse (DogId, HouseId)
	values (@InsertedDogId, 1)

## Example 2

Here's an example using GUIDs/UUIDs/UniqueIdentifiers instead of an Identity column. Tables as follows:

	create table Wolf (
		ID uniqueIdentifier primary key not null,
		Name nvarchar(20),
		Age tinyint
	)
		
	create table WolfPack
	(
		WolfPackID uniqueIdentifier primary key not null,
		WolfId uniqueIdentifier,
		PackId uniqueIdentifier
	)
		
Insert a Wolf using a new GUID for its ID, saving that ID to map him into a WolfPack at a later stage:

	create table #Inserted (WolfId uniqueIdentifier)

	insert into Wolf (ID, Name, Age)
	output inserted.ID into #Inserted
	values
		-- Here's where the Wolf's ID is first generated
		(NEWID(), 'Scary', 8)

	declare @InsertedWolfId uniqueIdentifier = (select * from #Inserted);
	drop table #Inserted

	-- Here we pass the @InsertedWolfId into the WolfId field:
	insert into WolfPack(WolfPackId, WolfId, PackId)
	values (NEWID(), @InsertedWolfId, '5DDBD03B-B9B9-4F10-92A7-CB5C6F19309F')


Hope this helps someone!

*Written 2015-04-22*
