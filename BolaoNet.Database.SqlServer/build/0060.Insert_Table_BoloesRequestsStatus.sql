
IF (NOT EXISTS (SELECT * FROM BoloesRequestsStatus WHERE StatusRequestID = 1))
BEGIN
	INSERT INTO [BoloesRequestsStatus] ([StatusRequestID],[Descricao]) VALUES (1, 'Participar')
END
IF (NOT EXISTS (SELECT * FROM BoloesRequestsStatus WHERE StatusRequestID = 2))
BEGIN
	INSERT INTO [BoloesRequestsStatus] ([StatusRequestID],[Descricao]) VALUES (2, 'Retirar')
END
IF (NOT EXISTS (SELECT * FROM BoloesRequestsStatus WHERE StatusRequestID = 3))
BEGIN
	INSERT INTO [BoloesRequestsStatus] ([StatusRequestID],[Descricao]) VALUES (3, 'Aprovado')
END
IF (NOT EXISTS (SELECT * FROM BoloesRequestsStatus WHERE StatusRequestID = 4))
BEGIN
	INSERT INTO [BoloesRequestsStatus] ([StatusRequestID],[Descricao]) VALUES (4, 'Rejeitado')
END
IF (NOT EXISTS (SELECT * FROM BoloesRequestsStatus WHERE StatusRequestID = 5))
BEGIN
	INSERT INTO [BoloesRequestsStatus] ([StatusRequestID],[Descricao]) VALUES (5, 'Removido')
END
IF (NOT EXISTS (SELECT * FROM BoloesRequestsStatus WHERE StatusRequestID = 6))
BEGIN
	INSERT INTO [BoloesRequestsStatus] ([StatusRequestID],[Descricao]) VALUES (6, 'Mantido')
END
IF (NOT EXISTS (SELECT * FROM BoloesRequestsStatus WHERE StatusRequestID = 7))
BEGIN
	INSERT INTO [BoloesRequestsStatus] ([StatusRequestID],[Descricao]) VALUES (7, 'Convidado')
END

GO