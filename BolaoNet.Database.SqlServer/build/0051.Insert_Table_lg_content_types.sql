
------|--------------------------------------------------------------------------------
------| [lg_content_types] - Backs up all the data from a table into a SQL script.
------|--------------------------------------------------------------------------------
----BEGIN TRANSACTION

--IF (NOT EXISTS (SELECT * FROM lg_content_types WHERE Id = 1))
--BEGIN
--	INSERT INTO [lg_content_types] ([Id], [Description])
--	VALUES	(1, 'TextPlain');
--END
	
--IF (NOT EXISTS (SELECT * FROM lg_content_types WHERE Id = 2))
--BEGIN
--	INSERT INTO [lg_content_types] ([Id], [Description])
--	VALUES (2, 'XML');
--END
	
--IF (NOT EXISTS (SELECT * FROM lg_content_types WHERE Id = 3))
--BEGIN
--	INSERT INTO [lg_content_types] 	([Id], [Description])
--	VALUES (3, 'Exception');
--END
	
----IF @@ERROR <> 0 ROLLBACK TRANSACTION;
----ELSE COMMIT TRANSACTION;
----GO
------|--------------------------------------------------------------------------------
