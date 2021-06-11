
----|--------------------------------------------------------------------------------
----| [UsersInRoles] - Backs up all the data from a table into a SQL script.
----|--------------------------------------------------------------------------------
--BEGIN TRANSACTION

IF (NOT EXISTS (SELECT * FROM UserInRole WHERE RoleName = 'Administrador' AND UserName = 'Admin'))
BEGIN
	INSERT INTO UserInRole
	([RoleName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [ActiveFlag], [UserName])
	VALUES
	('Administrador', 'Admin', '04/08/2010 23:54:52', 'Admin', '04/08/2010 23:54:52', 0, 'Admin');
END 

--IF @@ERROR <> 0 ROLLBACK TRANSACTION;
--ELSE COMMIT TRANSACTION;
--GO
----|--------------------------------------------------------------------------------
