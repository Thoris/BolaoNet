
----|--------------------------------------------------------------------------------
----| [Users] - Backs up all the data from a table into a SQL script.
----|--------------------------------------------------------------------------------
--BEGIN TRANSACTION

IF (NOT EXISTS(SELECT * FROM Usuarios WHERE UserName = 'Admin'))
BEGIN
	INSERT INTO Usuarios
	(UserName, FullName, IsApproved, IsLockedOut, PasswordFormat, ReceiveEmails, IsOnline, IsAdmin, Password)
	VALUES 
	('Admin', 'Administrador', 1, 0, 0, 0, 0, 1, 'admin01')
END 
--IF @@ERROR <> 0 ROLLBACK TRANSACTION;
--ELSE COMMIT TRANSACTION;
--GO
----|--------------------------------------------------------------------------------
