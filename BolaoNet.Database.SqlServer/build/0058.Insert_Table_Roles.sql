
----|--------------------------------------------------------------------------------
----| [Roles] - Backs up all the data from a table into a SQL script.
----|--------------------------------------------------------------------------------
--BEGIN TRANSACTION

IF (NOT EXISTS (SELECT * FROM Roles WHERE RoleName = 'Administrador'))
BEGIN
	INSERT INTO [Roles]
	([RoleName], [Description], [CreatedDate], [ModifiedDate], [ActiveFlag], [CreatedBy], [ModifiedBy])
	VALUES
	('Administrador', NULL, '04/07/2010 21:55:56', '04/07/2010 21:55:56', 0, 'Admin', 'Admin');
END
IF (NOT EXISTS (SELECT * FROM Roles WHERE RoleName = 'Apostador'))
BEGIN
	INSERT INTO [Roles]
	([RoleName], [Description], [CreatedDate], [ModifiedDate], [ActiveFlag], [CreatedBy], [ModifiedBy])
	VALUES
	('Apostador', NULL, '04/07/2010 21:55:56', '04/07/2010 21:55:56', 0, 'Admin', 'Admin');
END
IF (NOT EXISTS (SELECT * FROM Roles WHERE RoleName = 'Convidado'))
BEGIN
	INSERT INTO [Roles]
	([RoleName], [Description], [CreatedDate], [ModifiedDate], [ActiveFlag], [CreatedBy], [ModifiedBy])
	VALUES
	('Convidado', NULL, '04/07/2010 21:55:56', '04/07/2010 21:55:56', 0, 'Admin', 'Admin');
END
IF (NOT EXISTS (SELECT * FROM Roles WHERE RoleName = 'Gerenciador de Avisos'))
BEGIN
	INSERT INTO [Roles]
	([RoleName], [Description], [CreatedDate], [ModifiedDate], [ActiveFlag], [CreatedBy], [ModifiedBy])
	VALUES
	('Gerenciador de Avisos', NULL, '04/07/2010 21:55:56', '04/07/2010 21:55:56', 0, 'Admin', 'Admin');
END
IF (NOT EXISTS (SELECT * FROM Roles WHERE RoleName = 'Gerenciador de Bolão'))
BEGIN
	INSERT INTO [Roles]
	([RoleName], [Description], [CreatedDate], [ModifiedDate], [ActiveFlag], [CreatedBy], [ModifiedBy])
	VALUES
	('Gerenciador de Bolão', NULL, '04/07/2010 21:55:56', '04/07/2010 21:55:56', 0, 'Admin', 'Admin');
END
IF (NOT EXISTS (SELECT * FROM Roles WHERE RoleName = 'Gerenciador de Campeonatos'))
BEGIN
	INSERT INTO [Roles]
	([RoleName], [Description], [CreatedDate], [ModifiedDate], [ActiveFlag], [CreatedBy], [ModifiedBy])
	VALUES
	('Gerenciador de Campeonatos', NULL, '04/07/2010 21:55:56', '04/07/2010 21:55:56', 0, 'Admin', 'Admin');
END
IF (NOT EXISTS (SELECT * FROM Roles WHERE RoleName = 'Gerenciador de Critérios'))
BEGIN
	INSERT INTO [Roles]
	([RoleName], [Description], [CreatedDate], [ModifiedDate], [ActiveFlag], [CreatedBy], [ModifiedBy])
	VALUES
	('Gerenciador de Critérios', NULL, '04/07/2010 21:55:56', '04/07/2010 21:55:56', 0, 'Admin', 'Admin');
END
IF (NOT EXISTS (SELECT * FROM Roles WHERE RoleName = 'Gerenciador de Dados Básicos'))
BEGIN
	INSERT INTO [Roles]
	([RoleName], [Description], [CreatedDate], [ModifiedDate], [ActiveFlag], [CreatedBy], [ModifiedBy])
	VALUES
	('Gerenciador de Dados Básicos', NULL, '04/07/2010 21:55:56', '04/07/2010 21:55:56', 0, 'Admin', 'Admin');
END
IF (NOT EXISTS (SELECT * FROM Roles WHERE RoleName = 'Gerenciador de Enquetes'))
BEGIN
	INSERT INTO [Roles]
	([RoleName], [Description], [CreatedDate], [ModifiedDate], [ActiveFlag], [CreatedBy], [ModifiedBy])
	VALUES
	('Gerenciador de Enquetes', NULL, '04/07/2010 21:55:56', '04/07/2010 21:55:56', 0, 'Admin', 'Admin');
END
IF (NOT EXISTS (SELECT * FROM Roles WHERE RoleName = 'Gerenciador de Mensagens'))
BEGIN
	INSERT INTO [Roles]
	([RoleName], [Description], [CreatedDate], [ModifiedDate], [ActiveFlag], [CreatedBy], [ModifiedBy])
	VALUES
	('Gerenciador de Mensagens', NULL, '04/07/2010 21:55:56', '04/07/2010 21:55:56', 0, 'Admin', 'Admin');
END
IF (NOT EXISTS (SELECT * FROM Roles WHERE RoleName = 'Gerenciador de Pagamentos'))
BEGIN
	INSERT INTO [Roles]
	([RoleName], [Description], [CreatedDate], [ModifiedDate], [ActiveFlag], [CreatedBy], [ModifiedBy])
	VALUES
	('Gerenciador de Pagamentos', NULL, '04/07/2010 21:55:56', '04/07/2010 21:55:56', 0, 'Admin', 'Admin');
END
IF (NOT EXISTS (SELECT * FROM Roles WHERE RoleName = 'Gerenciador de Pontuação'))
BEGIN
	INSERT INTO [Roles]
	([RoleName], [Description], [CreatedDate], [ModifiedDate], [ActiveFlag], [CreatedBy], [ModifiedBy])
	VALUES
	('Gerenciador de Pontuação', NULL, '04/07/2010 21:55:56', '04/07/2010 21:55:56', 0, 'Admin', 'Admin');
END
IF (NOT EXISTS (SELECT * FROM Roles WHERE RoleName = 'Gerenciador de Publicidade'))
BEGIN
	INSERT INTO [Roles]
	([RoleName], [Description], [CreatedDate], [ModifiedDate], [ActiveFlag], [CreatedBy], [ModifiedBy])
	VALUES
	('Gerenciador de Publicidade', NULL, '04/07/2010 21:55:56', '04/07/2010 21:55:56', 0, 'Admin', 'Admin');
END
IF (NOT EXISTS (SELECT * FROM Roles WHERE RoleName = 'Gerenciador de Resultados'))
BEGIN
	INSERT INTO [Roles]
	([RoleName], [Description], [CreatedDate], [ModifiedDate], [ActiveFlag], [CreatedBy], [ModifiedBy])
	VALUES
	('Gerenciador de Resultados', NULL, '04/07/2010 21:55:56', '04/07/2010 21:55:56', 0, 'Admin', 'Admin');
END
IF (NOT EXISTS (SELECT * FROM Roles WHERE RoleName = 'Visitante de Bolão'))
BEGIN
	INSERT INTO [Roles]
	([RoleName], [Description], [CreatedDate], [ModifiedDate], [ActiveFlag], [CreatedBy], [ModifiedBy])
	VALUES
	('Visitante de Bolão', NULL, '04/07/2010 21:55:56', '04/07/2010 21:55:56', 0, 'Admin', 'Admin');
END
IF (NOT EXISTS (SELECT * FROM Roles WHERE RoleName = 'Visitante de Campeonato'))
BEGIN
	INSERT INTO [Roles]
	([RoleName], [Description], [CreatedDate], [ModifiedDate], [ActiveFlag], [CreatedBy], [ModifiedBy])
	VALUES
	('Visitante de Campeonato', NULL, '04/07/2010 21:55:56', '04/07/2010 21:55:56', 0, 'Admin', 'Admin');
END  
--IF @@ERROR <> 0 ROLLBACK TRANSACTION;
--ELSE COMMIT TRANSACTION;
--GO
----|--------------------------------------------------------------------------------
