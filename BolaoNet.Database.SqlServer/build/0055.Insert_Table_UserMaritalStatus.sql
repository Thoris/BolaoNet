
----|--------------------------------------------------------------------------------
----| [UserMaritalStatus] - Backs up all the data from a table into a SQL script.
----|--------------------------------------------------------------------------------
--BEGIN TRANSACTION

IF (NOT EXISTS (SELECT * FROM UserMaritalStatus WHERE IdMaritalStatus = 0))
BEGIN
	INSERT INTO [UserMaritalStatus]	([IdMaritalStatus], [Description])	VALUES	(0, 'Não definido');
END
IF (NOT EXISTS (SELECT * FROM UserMaritalStatus WHERE IdMaritalStatus = 1))
BEGIN
	INSERT INTO [UserMaritalStatus]	([IdMaritalStatus], [Description])	VALUES	(1, 'Casado');
END
IF (NOT EXISTS (SELECT * FROM UserMaritalStatus WHERE IdMaritalStatus = 2))
BEGIN
	INSERT INTO [UserMaritalStatus]	([IdMaritalStatus], [Description])	VALUES	(2, 'Solteiro');
END
IF (NOT EXISTS (SELECT * FROM UserMaritalStatus WHERE IdMaritalStatus = 3))
BEGIN
	INSERT INTO [UserMaritalStatus]	([IdMaritalStatus], [Description])	VALUES	(3, 'Em um relacionamento');
END
--IF @@ERROR <> 0 ROLLBACK TRANSACTION;
--ELSE COMMIT TRANSACTION;
--GO
----|--------------------------------------------------------------------------------
