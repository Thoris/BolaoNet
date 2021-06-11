
----|--------------------------------------------------------------------------------
----| [PagamentoTipo] - Backs up all the data from a table into a SQL script.
----|--------------------------------------------------------------------------------
--BEGIN TRANSACTION

IF (NOT EXISTS(SELECT * FROM PagamentosTipo WHERE TipoPagamento = '1'))
BEGIN
	INSERT INTO [PagamentosTipo]	([TipoPagamento], [Descricao])	VALUES	('1', 'Dinheiro');
END
IF (NOT EXISTS(SELECT * FROM PagamentosTipo WHERE TipoPagamento = '2'))
BEGIN
	INSERT INTO [PagamentosTipo]	([TipoPagamento], [Descricao])	VALUES	('2', 'Cheque');
END
IF (NOT EXISTS(SELECT * FROM PagamentosTipo WHERE TipoPagamento = '3'))
BEGIN
	INSERT INTO [PagamentosTipo]	([TipoPagamento], [Descricao])	VALUES	('3', 'Depósito');
END
--IF @@ERROR <> 0 ROLLBACK TRANSACTION;
--ELSE COMMIT TRANSACTION;
--GO
----|--------------------------------------------------------------------------------
