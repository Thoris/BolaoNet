﻿IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_Jogos_LoadNextJogos')
BEGIN
	DROP  Procedure  sp_Jogos_LoadNextJogos
END
GO
CREATE PROCEDURE [dbo].[sp_Jogos_LoadNextJogos]
(
    @CurrentLogin						varchar(25),
	@CurrentDateTime					DateTime = null,
	@NomeCampeonato						varchar(50),
	@TotalJogos							int,
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL

	
	DECLARE @Query	varchar(4000)
	
	SET @Query = '
		SELECT TOP ' + CONVERT(VARCHAR, @TotalJogos) + ' *
		  FROM Jogos 
		 WHERE NomeCampeonato = ''' + @NomeCampeonato + '''
		   AND IsValido <> 1
		 ORDER BY DataJogo'
		  
	EXEC (@Query)
	
		
			  	
	RETURN @@RowCount	
	
END


GO
