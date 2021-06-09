
----|--------------------------------------------------------------------------------
----| [CriteriosFixos] - Backs up all the data from a table into a SQL script.
----|--------------------------------------------------------------------------------
--BEGIN TRANSACTION

IF (NOT EXISTS (SELECT * FROM CriteriosFixos WHERE CriterioID = 1))
BEGIN
	INSERT INTO [CriteriosFixos]	([CriterioID], [Descricao]) VALUES	(1, 'Empate');
END

IF (NOT EXISTS (SELECT * FROM CriteriosFixos WHERE CriterioID = 2))
BEGIN
	INSERT INTO [CriteriosFixos]	([CriterioID], [Descricao])	VALUES	(2, 'Vitória');
END

IF (NOT EXISTS (SELECT * FROM CriteriosFixos WHERE CriterioID = 3))
BEGIN
	INSERT INTO [CriteriosFixos]	([CriterioID], [Descricao])	VALUES	(3, 'Derrota');
END

IF (NOT EXISTS (SELECT * FROM CriteriosFixos WHERE CriterioID = 4))
BEGIN
	INSERT INTO [CriteriosFixos]	([CriterioID], [Descricao])	VALUES	(4, 'Ganhador');
END

IF (NOT EXISTS (SELECT * FROM CriteriosFixos WHERE CriterioID = 5))
BEGIN
	INSERT INTO [CriteriosFixos]	([CriterioID], [Descricao])	VALUES	(5, 'Perdedor');
END

IF (NOT EXISTS (SELECT * FROM CriteriosFixos WHERE CriterioID = 6))
BEGIN
	INSERT INTO [CriteriosFixos]	([CriterioID], [Descricao])	VALUES	(6, 'Time 1');
END

IF (NOT EXISTS (SELECT * FROM CriteriosFixos WHERE CriterioID = 7))
BEGIN
	INSERT INTO [CriteriosFixos]	([CriterioID], [Descricao])	VALUES	(7, 'Time 2');
END

IF (NOT EXISTS (SELECT * FROM CriteriosFixos WHERE CriterioID = 8))
BEGIN
	INSERT INTO [CriteriosFixos]	([CriterioID], [Descricao])	VALUES	(8, 'Vitória/Empate/Derrota');
END

IF (NOT EXISTS (SELECT * FROM CriteriosFixos WHERE CriterioID = 9))
BEGIN
	INSERT INTO [CriteriosFixos]	([CriterioID], [Descricao])	VALUES	(9, 'Erro');
END

IF (NOT EXISTS (SELECT * FROM CriteriosFixos WHERE CriterioID = 10))
BEGIN
	INSERT INTO [CriteriosFixos]	([CriterioID], [Descricao])	VALUES	(10, 'Ganhador Fora');
END

IF (NOT EXISTS (SELECT * FROM CriteriosFixos WHERE CriterioID = 11))
BEGIN
	INSERT INTO [CriteriosFixos]	([CriterioID], [Descricao])	VALUES	(11, 'Ganhador Dentro');
END

IF (NOT EXISTS (SELECT * FROM CriteriosFixos WHERE CriterioID = 12))
BEGIN
	INSERT INTO [CriteriosFixos]	([CriterioID], [Descricao])	VALUES	(12, 'Perdedor Fora');
END
IF (NOT EXISTS (SELECT * FROM CriteriosFixos WHERE CriterioID = 13))
BEGIN
	INSERT INTO [CriteriosFixos]	([CriterioID], [Descricao])	VALUES	(13, 'Perdedor Dentro');
END

IF (NOT EXISTS (SELECT * FROM CriteriosFixos WHERE CriterioID = 14))
BEGIN
	INSERT INTO [CriteriosFixos]	([CriterioID], [Descricao])	VALUES	(14, 'Empate Gols');
END

IF (NOT EXISTS (SELECT * FROM CriteriosFixos WHERE CriterioID = 15))
BEGIN
	INSERT INTO [CriteriosFixos]	([CriterioID], [Descricao])	VALUES	(15, 'Gols Time 1');
END
IF (NOT EXISTS (SELECT * FROM CriteriosFixos WHERE CriterioID = 16))
BEGIN
	INSERT INTO [CriteriosFixos]	([CriterioID], [Descricao])	VALUES	(16, 'Gols Time 2');
END

IF (NOT EXISTS (SELECT * FROM CriteriosFixos WHERE CriterioID = 17))
BEGIN
	INSERT INTO [CriteriosFixos]	([CriterioID], [Descricao])	VALUES	(17, 'Cheio');
END

--IF @@ERROR <> 0 ROLLBACK TRANSACTION;
--ELSE COMMIT TRANSACTION;
--GO
----|--------------------------------------------------------------------------------
