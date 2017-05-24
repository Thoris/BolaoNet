IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_JogosUsuarios_ProcessAposta')
BEGIN
	DROP  Procedure  sp_JogosUsuarios_ProcessAposta
END
GO
CREATE PROCEDURE [dbo].[sp_JogosUsuarios_ProcessAposta]
(
    @CurrentLogin						varchar(25),
	@CurrentDateTime					datetime = null,
	@NomeCampeonato						varchar(50),
	@IDJogo								bigint,
	@NomeBolao							varchar(30),	
	@UserName							varchar(25),			
	@Automatico							smallint,
	@ApostaTime1						smallint,
	@ApostaTime2						smallint,	
	@Penaltis1							smallint = NULL,
	@Penaltis2							smallint = NULL,
	@Ganhador							int = null,
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	DECLARE @RowCount			int
	
	
	IF (@CurrentDateTime = NULL)
		SET @CurrentDateTime = GetDate()

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL
	

	IF ((@Ganhador IS NULL OR @Ganhador = 0) AND @ApostaTime1 = @ApostaTime2)
	BEGIN
		SET @Ganhador = 2
	END


	-- Se encontrou um registro com esta chave
	IF (NOT EXISTS(SELECT * 
				 FROM JogosUsuarios
				WHERE	NomeCampeonato				= @NomeCampeonato
				  AND	JogoID						= @IdJogo
				  AND	NomeBolao					= @NomeBolao
				  AND	UserName					= @UserName))
	BEGIN
	
		INSERT INTO JogosUsuarios
			(
			JogoID,
			NomeCampeonato,
			UserName, 
			NomeBolao,
			DataAposta,
			Automatico,
			ApostaTime1,
			ApostaTime2,
			ApostaPenaltis1,
			ApostaPenaltis2,
			Ganhador,
			CreatedBy,
			CreatedDate,
			ModifiedBy,
			ModifiedDate,
			ActiveFlag
			)
			VALUES
			(
			@IdJogo,
			@NomeCampeonato,
			@UserName,
			@NomeBolao,
			@CurrentDateTime,
			@Automatico,
			@ApostaTime1,
			@ApostaTime2,
			@Penaltis1,
			@Penaltis2,
			@Ganhador,
			@CurrentLogin,
			@CurrentDateTime,
			@CurrentLogin,
			@CurrentDateTime,
			0
			)
	
	END
	-- Se não existe nenhum registro com esta chave
	ELSE
	BEGIN
	
		UPDATE JogosUsuarios
		   SET	DataAposta			= @CurrentDateTime,
				Automatico			= @Automatico,
				ApostaTime1			= @ApostaTime1,
				ApostaTime2			= @ApostaTime2,
				ApostaPenaltis1		= @Penaltis1,
				ApostaPenaltis2		= @Penaltis2,
				Ganhador			= @Ganhador,
				ModifiedBy			= @CurrentLogin,
				ModifiedDate		= @CurrentDateTime
		 WHERE	
				JogoID				= @IdJogo
		   AND	NomeCampeonato		= @NomeCampeonato
		   AND	UserName			= @UserName
		   AND	NomeBolao			= @NomeBolao
				
	END
	
	SET @RowCount =  @@RowCount  	
	

	-- Declarando as variaveis para buscar os dados
	DECLARE @NomeFase			varchar(30)
	DECLARE @NomeGrupo			varchar(20)
	DECLARE @NomeTime1			varchar(30)
	DECLARE @NomeTime2			varchar(30)
	
	
	
	-- Buscando detalhes do jogo apostado
	SELECT	@NomeFase = NomeFase, @NomeGrupo = NomeGrupo, 
			@NomeTime1 = NomeTime1, @NomeTime2 = NomeTime2
	  FROM Jogos 
	 WHERE NomeCampeonato	= @NomeCampeonato
	   AND JogoID			= @IDJogo 
	
	
	IF (@NomeGrupo IS NOT NULL)
	BEGIN
		
		PRINT 'calculando dados do time ' + @NomeTime1 + ' que joga em casa atribuído'
		
		-- Calculando os dados do time
		EXEC sp_JogosUsuarios_Calcule_Time 
			@CurrentLogin,
			@CurrentDateTime,
			@NomeCampeonato,
			@NomeBolao,
			@UserName,
			@NomeTime1,
			@NomeFase,
			@NomeGrupo,
			@ErrorNumber,
			@ErrorDescription
		
		PRINT 'calculando dados do time ' + @NomeTime2 + ' que joga em fora atribuído'
		

		-- Calculando os dados do time
		EXEC sp_JogosUsuarios_Calcule_Time 
			@CurrentLogin,
			@CurrentDateTime,
			@NomeCampeonato,
			@NomeBolao,
			@UserName,
			@NomeTime2,
			@NomeFase,
			@NomeGrupo,
			@ErrorNumber,
			@ErrorDescription
		
	END -- Grupo is not null
	
	
	PRINT 'Calculando pendencias do jogo '
		
	
	DECLARE @NomeTimeResult1	varchar(30)
	DECLARE @NomeTimeResult2	varchar(30)
	
	-- Buscando o time que gerou a dependência
	SELECT @NomeTimeResult1 = NomeTimeResult1, @NomeTimeResult2 = NomeTimeResult2
	  FROM JogosUsuarios
	 WHERE NomeCampeonato	= @NomeCampeonato
	   AND JogoID			= @IDJogo
	   AND UserName			= @UserName
	   
	
	-- Se não encontrou valor para a dependencia
	IF (@NomeTimeResult1 IS NULL)
		SET @NomeTimeResult1 = @NomeTime1
		
	-- Se não encontrou valor para a dependencia	
	IF (@NomeTimeResult2 IS NULL)
		SET @NomeTimeResult2 = @NomeTime2
		
		
	-- Calculando a dependencia do jogo
	EXEC sp_JogosUsuarios_Calcule_Dependencia		@CurrentLogin,
													@CurrentDateTime,
													@NomeCampeonato,
													@IDJogo,
													@NomeBolao,
													@UserName,
													@Nomefase,
													@NomeGrupo,
													@NomeTimeResult1,
													@NomeTimeResult2,
													@ApostaTime1,
													@ApostaTime2,
													@Ganhador,
													@ErrorNumber,
													@ErrorDescription



	EXEC sp_JogosUsuarios_Calcule_Final				@CurrentLogin,
													@CurrentDateTime,
													@NomeCampeonato,
													@IDJogo,
													@NomeBolao,
													@UserName,
													@Nomefase,
													@NomeGrupo,
													@NomeTimeResult1,
													@NomeTimeResult2,
													@ApostaTime1,
													@ApostaTime2,
													@Ganhador,
													@ErrorNumber,
													@ErrorDescription

	RETURN @RowCount	
END



GO
