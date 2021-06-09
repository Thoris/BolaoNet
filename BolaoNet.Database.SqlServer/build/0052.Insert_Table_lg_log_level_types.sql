
----|--------------------------------------------------------------------------------
----| [lg_log_level_types] - Backs up all the data from a table into a SQL script.
----|--------------------------------------------------------------------------------
--BEGIN TRANSACTION

IF (NOT EXISTS (SELECT * FROM lg_log_level_types WHERE Id = 1))
BEGIN
	INSERT INTO [lg_log_level_types] ([ID], [Description])	VALUES	(1, 'Debug');
END
	
IF (NOT EXISTS (SELECT * FROM lg_log_level_types WHERE Id = 2))
BEGIN
	INSERT INTO [lg_log_level_types] ([ID], [Description])	VALUES	(2, 'Information');
END
	
IF (NOT EXISTS (SELECT * FROM lg_log_level_types WHERE Id = 3))
BEGIN
	INSERT INTO [lg_log_level_types] ([ID], [Description])	VALUES	(3, 'Warning');
END
	
IF (NOT EXISTS (SELECT * FROM lg_log_level_types WHERE Id = 4))
BEGIN
	INSERT INTO [lg_log_level_types] ([ID], [Description])	VALUES	(4, 'Error');
END
	
IF (NOT EXISTS (SELECT * FROM lg_log_level_types WHERE Id = 5))
BEGIN
	INSERT INTO [lg_log_level_types] ([ID], [Description])	VALUES	(5, 'Trace');
END
	
IF (NOT EXISTS (SELECT * FROM lg_log_level_types WHERE Id = 6))
BEGIN
	INSERT INTO [lg_log_level_types] ([ID], [Description])	VALUES	(6, 'SucessAudit');
END
	
IF (NOT EXISTS (SELECT * FROM lg_log_level_types WHERE Id = 7))
BEGIN
	INSERT INTO [lg_log_level_types] ([ID], [Description])	VALUES	(7, 'FailureAudit');
END
--IF @@ERROR <> 0 ROLLBACK TRANSACTION;
--ELSE COMMIT TRANSACTION;
--GO
----|--------------------------------------------------------------------------------
