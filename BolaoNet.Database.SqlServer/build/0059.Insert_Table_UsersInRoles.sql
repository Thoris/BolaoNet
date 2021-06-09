
----|--------------------------------------------------------------------------------
----| [UsersInRoles] - Backs up all the data from a table into a SQL script.
----|--------------------------------------------------------------------------------
--BEGIN TRANSACTION

IF (NOT EXISTS (SELECT * FROM UsersInRoles WHERE RoleName = 'Administrador' AND UserName = 'Admin'))
BEGIN
	INSERT INTO [UsersInRoles]
	([RoleName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [ActiveFlag], [UserName])
	VALUES
	('Administrador', 'Admin', '04/08/2010 23:54:52', 'Admin', '04/08/2010 23:54:52', 0, 'Admin');
END
IF (NOT EXISTS (SELECT * FROM UsersInRoles WHERE RoleName = 'Administrador' AND UserName = 'thoris'))
BEGIN
	INSERT INTO [UsersInRoles]
	([RoleName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [ActiveFlag], [UserName])
	VALUES
	('Administrador', NULL, NULL, NULL, NULL, NULL, 'thoris');
END

--IF @@ERROR <> 0 ROLLBACK TRANSACTION;
--ELSE COMMIT TRANSACTION;
--GO
----|--------------------------------------------------------------------------------
