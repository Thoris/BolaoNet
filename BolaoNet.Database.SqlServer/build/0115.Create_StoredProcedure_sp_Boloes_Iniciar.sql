IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_Boloes_Iniciar')
BEGIN
	DROP  Procedure  sp_Boloes_Iniciar
END
GO
CREATE PROCEDURE [dbo].[sp_Boloes_Iniciar]
(
    @CurrentLogin						varchar(25),
	@CurrentDateTime					Datetime = null,
	@IniciadoBy							varchar(25),
	@NomeBolao							varchar(30),
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	
	DECLARE @NomeCampeonato VARCHAR(50)
	SELECT @NomeCampeonato = NomeCampeonato
	  FROM Boloes 
	 WHERE Nome = @NomeBolao
	
	IF (@CurrentDateTime = NULL)
		SET @CurrentDateTime = GetDate()

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL
	
	UPDATE Boloes
	   SET	IniciadoBy		= @IniciadoBy,
			IsIniciado		= 1,
			DataIniciado	= @CurrentDateTime,
			ModifiedBy		= @CurrentLogin,
			ModifiedDate	= @CurrentDateTime
	 WHERE Nome				= @NomeBolao
			
			
	DECLARE @UserName		varchar(25)
			
	DECLARE curMembros CURSOR FOR
	SELECT	UserName
	  FROM BoloesMembros
	 WHERE NomeBolao		= @NomeBolao
		
	OPEN curmembros
			
	FETCH NEXT FROM curMembros INTO @UserName

	WHILE (@@FETCH_STATUS = 0)
	BEGIN
			
		INSERT INTO JogosUsuarios
			(JogoID, NomeCampeonato, UserName, NomeBolao, DataAposta, Automatico, 
			 ApostaTime1, ApostaTime2, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate)
		SELECT Jogos.JogoID, Jogos.NomeCampeonato, @UserName, @NomeBolao, @CurrentDateTime, 1,
			 0, 0, @CurrentLogin, @CurrentDateTime, @CurrentLogin, @CurrentDateTime 
		  FROM Jogos
		 WHERE NOT EXISTS 
			(
				SELECT * 
				  FROM JogosUsuarios
				 WHERE UserName					= @UserName
				   AND NomeBolao				= @NomeBolao
				   AND Jogos.JogoID				= JogosUsuarios.JogoID 
				   AND Jogos.NomeCampeonato		= JogosUsuarios.NomeCampeonato
			
			)			
		  AND NomeCampeonato = @NomeCampeonato
					
		FETCH NEXT FROM curMembros INTO @UserName
				
	END				
			
				
	RETURN @@RowCount		
	
	
END


GO
