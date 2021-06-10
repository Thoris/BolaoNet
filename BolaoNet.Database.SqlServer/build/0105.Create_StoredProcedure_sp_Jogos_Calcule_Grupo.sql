IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_Jogos_Calcule_Grupo')
BEGIN
	DROP  Procedure  sp_Jogos_Calcule_Grupo
END
GO
CREATE PROCEDURE [dbo].[sp_Jogos_Calcule_Grupo]
(
    @CurrentLogin						varchar(25),
	@CurrentDateTime					datetime,
	@NomeCampeonato						varchar(50),
	@NomeFase							varchar(30),
	@NomeGrupo							varchar(30),
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN
	
			
	IF (@CurrentDateTime IS NULL)
		SET @CurrentDateTime = GetDate()

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL
	
	SET NOCOUNT ON



	DECLARE @NomeTime			VARCHAR(30)			-- Time do grupo
	DECLARE @Posicao			int					-- Posicao do time
	DECLARE @Pontos				int					-- Pontos do time

	DECLARE @IDJogo1			int					-- Identificação do jogo que existe dependencia
	DECLARE @IDJogo2			int					-- Identificação do jogo que existe dependencia


	DECLARE @Rodada int -- Ultima rodada do grupo

	-- Buscando o último valor da rodada
	SELECT @Rodada = ISNULL(MAX(Rodada), 0)
	  FROM CampeonatosClassificacao 
	 WHERE NomeCampeonato = @NomeCampeonato
	   AND NomeGrupo = @NomeGrupo
	   AND NomeFase = @NomeFase
 
	PRINT 'Última rodada a ser verificada: ' + CONVERT(VARCHAR, @Rodada)


	-- Declarando o cursor do grupo
	DECLARE curClassificacao CURSOR FOR
	SELECT NomeTime, Posicao, TotalPontos
	  FROM CampeonatosClassificacao
	 WHERE NomeCampeonato				= @NomeCampeonato
	   AND NomeGrupo					= @NomeGrupo
	   AND NomeFase						= @NomeFase
       AND Rodada = @Rodada
	 ORDER BY Posicao
	   

	-- Abrindo o cursor
	OPEN curClassificacao
	FETCH NEXT FROM curClassificacao INTO @NomeTime, @Posicao, @Pontos

	-- Entrando no laço para analisar a posição do time
	WHILE @@FETCH_STATUS = 0
	BEGIN

		
		SET @IDJogo1 = NULL
		SET @IDJogo2 = NULL

		PRINT '----------------------------------------------------------------'
		PRINT 'Posição: ' + CONVERT(VARCHAR, @Posicao) + ' - Time: ' + @NomeTime + ' - Pontos: ' + CONVERT(VARCHAR, @Pontos)


		------------------------------------------------------
		--- TIME 1
		------------------------------------------------------
		-- Buscando o jogo que possui dependencia do time 1
	   SELECT @IDJogo1 = JogoID
		 FROM Jogos
		WHERE NomeCampeonato			= @NomeCampeonato
		  AND PendenteTime1NomeGrupo	= @NomeGrupo
		  AND PendenteTime1PosGrupo		= @Posicao
	   

		-- Se encontrou algum registro
		IF (@IDJOGO1 IS NOT NULL )
		BEGIN					
			
			PRINT 'Atualizando registro da aposta: ' + CONVERT(VARCHAR, @IDJogo1) + ' Para o time 1'
				
			UPDATE Jogos
			   SET NomeTime1			= @NomeTime				   
			 WHERE NomeCampeonato		= @NomeCampeonato
			   AND JogoID				= @IDJogo1
			
		
		END -- endif dependencia
					

		------------------------------------------------------
		--- TIME 2
		------------------------------------------------------
		-- Buscando o jogo que possui dependencia do time 2
	   SELECT @IDJogo2 = JogoID
		 FROM Jogos
		WHERE NomeCampeonato			= @NomeCampeonato
		  AND PendenteTime2NomeGrupo	= @NomeGrupo
		  AND PendenteTime2PosGrupo		= @Posicao
	   

		-- Se encontrou algum registro
		IF (@IDJogo2 IS NOT NULL)
		BEGIN
			
			PRINT 'Atualizando registro da aposta: ' + CONVERT(VARCHAR, @IDJogo2) + ' Para o time 2'
			
			UPDATE Jogos
			   SET NomeTime2 = @NomeTime
			 WHERE NomeCampeonato		= @NomeCampeonato
			   AND JogoID				= @IDJogo2
			
			
			
		
		END -- endif dependencia


		FETCH NEXT FROM curClassificacao INTO @NomeTime, @Posicao, @Pontos
	END

	CLOSE curClassificacao
	DEALLOCATE curClassificacao
	
	
	PRINT 'Termino da verificação do grupo ' + @NomeGrupo

	
	
	-- TODO: Verificar a execução do processo
	EXECUTE  [sp_Jogos_Calcule_Grupo_Melhores] 
	   @CurrentLogin
	  ,@CurrentDateTime
	  ,@NomeCampeonato
	  ,@NomeFase
	  ,@NomeGrupo
	  ,@Rodada
	  ,@ErrorNumber OUTPUT
	  ,@ErrorDescription OUTPUT

END


GO
