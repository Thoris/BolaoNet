IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_Jogos_Calcule_Grupo_Melhores')
BEGIN
	DROP  Procedure  sp_Jogos_Calcule_Grupo_Melhores
END
GO
CREATE PROCEDURE [dbo].[sp_Jogos_Calcule_Grupo_Melhores]
(
    @CurrentLogin						varchar(25),
	@CurrentDateTime					datetime,
	@NomeCampeonato						varchar(50),
	@NomeFase							varchar(30),
	@NomeGrupo							varchar(30),
	@Rodada								int,
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


	DECLARE @IdJogoCursor					int
	DECLARE @PendenteTimeNomeGrupoCursor	varchar(30)
	DECLARE @PendenteTimePosGrupoCursor		int

	DECLARE @count							int
	DECLARE @NomeGrupoCorrente				varchar(30)
	DECLARE @TotalPendencia					int
	DECLARE @SomaGrupos						int
	DECLARE @NomeGrupoIn					varchar(50)
	DECLARE @NomeTime						varchar(150)
	DECLARE @NomeGrupoMelhor				varchar(30)
	DECLARE @sql							nvarchar(4000)


	-------------------------------------------------------------------------
	-- VERIFICACAO DO TIME 1
	-------------------------------------------------------------------------

	-- Declarando o cursor do grupo
	DECLARE curClassificacao1 CURSOR FOR
	SELECT JogoId, LTRIM(RTRIM(PendenteTime1NomeGrupo)), PendenteTime1PosGrupo
	  FROM Jogos
	 WHERE NomeCampeonato				= @NomeCampeonato
	   AND PendenteTime1NomeGrupo		LIKE '%' + @NomeGrupo + '%'
	   AND PendenteTime1MelhorGrupos	= 1
	   
	   
	-- Abrindo o cursor
	OPEN curClassificacao1
	FETCH NEXT FROM curClassificacao1 INTO @IdJogoCursor, @PendenteTimeNomeGrupoCursor, @PendenteTimePosGrupoCursor

	-- Entrando no laço para analisar a posição do time
	WHILE @@FETCH_STATUS = 0
	BEGIN

		PRINT '----------------------------------------------------------------'
		PRINT 'JogoID: ' + CONVERT(VARCHAR, @IdJogoCursor) + ' - Grupo: ' + @PendenteTimeNomeGrupoCursor + ' - Posição: '
			 + CONVERT(VARCHAR, @PendenteTimePosGrupoCursor)

		SET @count = 1
		SET @SomaGrupos = 0
		SET @NomeGrupoIn = ''
		
		-- Buscando se todos os jogos do grupo foram concluídos
		WHILE (@count <= LEN(@PendenteTimeNomeGrupoCursor))
		BEGIN
			SET @NomeGrupoCorrente = SUBSTRING(@PendenteTimeNomeGrupoCursor, @count, 1)
			PRINT 'Verificação do grupo: ' + @NomeGrupoCorrente

			SELECT @TotalPendencia = IsNull(Count(*), 0)
				  FROM Jogos
				 WHERE IsValido				= 0
				   AND NomeCampeonato		= @NomeCampeonato
				   AND NomeGrupo			= @NomeGrupoCorrente
				   AND NomeFase				= @NomeFase

			-- Se não houver nenhuma pendência no grupo
			IF (@TotalPendencia = 0)
			BEGIN
				SET @SomaGrupos = @SomaGrupos + 1

				IF (LEN(@NomegrupoIn) > 0)
				BEGIN
					SET @NomeGrupoIn = @NomeGrupoIn + ','
				END
				SET @NomeGrupoIn = @NomeGrupoIn + '''' + @NomeGrupoCorrente + ''''
			END

			SET @count = @count + 1
		END
			

		-- Se conseguiu completar todos os jogos dos grupos
		IF (@SomaGrupos = LEN(@PendenteTimeNomeGrupoCursor))
		BEGIN
			PRINT 'Todos os jogos concluídos: ' + @NomeGrupoIn
			
			SET @sql = 'SELECT TOP 1 @NomeTime = NomeTime, @NomeGrupoMelhor = NomeGrupo
			  FROM CampeonatosClassificacao
			 WHERE NomeCampeonato	= ''' + @NomeCampeonato + '''
			   AND NomeFase			= ''' + @NomeFase + '''
			   AND Rodada			= ' + CONVERT(VARCHAR, @Rodada) + '
			   AND Posicao			= ' + CONVERT(VARCHAR, @PendenteTimePosGrupoCursor) + '
			   AND NomeGrupo IN (' + @NomeGrupoIn + ')
			 ORDER BY TotalPontos DESC, TotalGolsPro-TotalGolsContra DESC, TotalGolsPro DESC '

			EXECUTE sp_executesql @sql, 
								@Params = N'@NomeTime varchar(150) OUTPUT, @NomeGrupoMelhor varchar(30) OUTPUT', 
								@NomeTime = @NomeTime OUTPUT, @NomeGrupoMelhor = @NomeGrupoMelhor OUTPUT
					
			 PRINT 'Melhor ' + CONVERT(VARCHAR, @PendenteTimePosGrupoCursor) + ' : ' + @NomeTime + ' . Grupo: ' + @NomeGrupoMelhor 
					+ ' Jogo: ' + CONVERT(VARCHAR, @IdJogoCursor) + ' Para o time 1'

			 	
			UPDATE Jogos
			   SET NomeTime1			= @NomeTime				   
			 WHERE NomeCampeonato		= @NomeCampeonato
			   AND JogoID				= @IdJogoCursor

		END
		-- Passando para o próximo registro da dependência do grupo fechado
		FETCH NEXT FROM curClassificacao1 INTO @IdJogoCursor, @PendenteTimeNomeGrupoCursor, @PendenteTimePosGrupoCursor
	END

	-- Fechando o cursor
	CLOSE curClassificacao1
	DEALLOCATE curClassificacao1
	 
	-------------------------------------------------------------------------
	-- VERIFICACAO DO TIME 2
	-------------------------------------------------------------------------
	 
	-- Declarando o cursor do grupo
	DECLARE curClassificacao2 CURSOR FOR
	SELECT JogoId, LTRIM(RTRIM(PendenteTime2NomeGrupo)), PendenteTime2PosGrupo
	  FROM Jogos
	 WHERE NomeCampeonato				= @NomeCampeonato
	   AND PendenteTime2NomeGrupo		LIKE '%' + @NomeGrupo + '%'
	   AND PendenteTime2MelhorGrupos	= 1
	   
	   
	-- Abrindo o cursor
	OPEN curClassificacao2
	FETCH NEXT FROM curClassificacao2 INTO @IdJogoCursor, @PendenteTimeNomeGrupoCursor, @PendenteTimePosGrupoCursor

	-- Entrando no laço para analisar a posição do time
	WHILE @@FETCH_STATUS = 0
	BEGIN

		PRINT '----------------------------------------------------------------'
		PRINT 'JogoID: ' + CONVERT(VARCHAR, @IdJogoCursor) + ' - Grupo: ' + @PendenteTimeNomeGrupoCursor + ' - Posição: '
			 + CONVERT(VARCHAR, @PendenteTimePosGrupoCursor)

		SET @count = 1
		SET @SomaGrupos = 0
		SET @NomeGrupoIn = ''
		
		-- Buscando se todos os jogos do grupo foram concluídos
		WHILE (@count <= LEN(@PendenteTimeNomeGrupoCursor))
		BEGIN
			SET @NomeGrupoCorrente = SUBSTRING(@PendenteTimeNomeGrupoCursor, @count, 1)
			PRINT 'Verificação do grupo: ' + @NomeGrupoCorrente

			SELECT @TotalPendencia = IsNull(Count(*), 0)
				  FROM Jogos
				 WHERE IsValido				= 0
				   AND NomeCampeonato		= @NomeCampeonato
				   AND NomeGrupo			= @NomeGrupoCorrente
				   AND NomeFase				= @NomeFase

			-- Se não houver nenhuma pendência no grupo
			IF (@TotalPendencia = 0)
			BEGIN
				SET @SomaGrupos = @SomaGrupos + 1

				IF (LEN(@NomegrupoIn) > 0)
				BEGIN
					SET @NomeGrupoIn = @NomeGrupoIn + ','
				END
				SET @NomeGrupoIn = @NomeGrupoIn + '''' + @NomeGrupoCorrente + ''''
			END

			SET @count = @count + 1
		END
			

		-- Se conseguiu completar todos os jogos dos grupos
		IF (@SomaGrupos = LEN(@PendenteTimeNomeGrupoCursor))
		BEGIN
			PRINT 'Todos os jogos concluídos: ' + @NomeGrupoIn
			
			SET @sql = 'SELECT TOP 1 @NomeTime = NomeTime, @NomeGrupoMelhor = NomeGrupo
			  FROM CampeonatosClassificacao
			 WHERE NomeCampeonato	= ''' + @NomeCampeonato + '''
			   AND NomeFase			= ''' + @NomeFase + '''
			   AND Rodada			= ' + CONVERT(VARCHAR, @Rodada) + '
			   AND Posicao			= ' + CONVERT(VARCHAR, @PendenteTimePosGrupoCursor) + '
			   AND NomeGrupo IN (' + @NomeGrupoIn + ')
			 ORDER BY TotalPontos DESC, TotalGolsPro-TotalGolsContra DESC, TotalGolsPro DESC '

			EXECUTE sp_executesql @sql, 
								@Params = N'@NomeTime varchar(150) OUTPUT, @NomeGrupoMelhor varchar(30) OUTPUT', 
								@NomeTime = @NomeTime OUTPUT, @NomeGrupoMelhor = @NomeGrupoMelhor OUTPUT
					
			 PRINT 'Melhor ' + CONVERT(VARCHAR, @PendenteTimePosGrupoCursor) + ' : ' + @NomeTime + ' . Grupo: ' + @NomeGrupoMelhor 
					+ ' Jogo: ' + CONVERT(VARCHAR, @IdJogoCursor) + ' Para o time 2'

			 	
			UPDATE Jogos
			   SET NomeTime2			= @NomeTime				   
			 WHERE NomeCampeonato		= @NomeCampeonato
			   AND JogoID				= @IdJogoCursor

		END
		-- Passando para o próximo registro da dependência do grupo fechado
		FETCH NEXT FROM curClassificacao2 INTO @IdJogoCursor, @PendenteTimeNomeGrupoCursor, @PendenteTimePosGrupoCursor
	END

	-- Fechando o cursor
	CLOSE curClassificacao2
	DEALLOCATE curClassificacao2
	 



	 
	
	PRINT 'Termino da verificação dos melhores do grupo ' + @NomeGrupo


END



