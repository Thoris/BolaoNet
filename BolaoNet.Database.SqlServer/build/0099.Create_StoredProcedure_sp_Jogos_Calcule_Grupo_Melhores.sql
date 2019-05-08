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


	-- Se estiver no campeonato de copa américa
	IF (@NomeCampeonato LIKE 'Copa América %')
	BEGIN	
		DECLARE @MaxRodada         				int 

		-- Se todos os jogos foram realizados dos grupos
		IF ((SELECT IsNull(Count(*), 0)
			  FROM Jogos
			 WHERE IsValido				= 0
			   AND NomeCampeonato		= @NomeCampeonato
			   AND NomeFase				= 'Classificatória') = 0)	
		BEGIN	
		
			DECLARE @JogosPendentes		int
			DECLARE @NomeGrupoOld		varchar(20)
			DECLARE @TotalPontos		int
			DECLARE @Saldo				int
			DECLARE @TotalGolsPro		int 
			DECLARE @Posicao			int 
			DECLARE @NomeTime1			varchar(150)
			DECLARE @NomeTime2			varchar(150)
			DECLARE @NomeGrupo1			varchar(20)
			DECLARE @NomeGrupo2			varchar(20)
			DECLARE @NomeTimeAB			varchar(150)
			DECLARE @NomeTimeBC			varchar(150)
			DECLARE @JogoAtualizacao	int
			DECLARE @TotalJogos 		int 		
		
			SET @Posicao = 3
			
			-- Buscando o maior valor da rodada para cálculo de posição
			SELECT @MaxRodada = ISNULL(MAX(Rodada), 0)
			  FROM CampeonatosClassificacao
			 WHERE NomeCampeonato =  @NomeCampeonato 
			 
			 
			PRINT 'Max Rodada: ' + CONVERT(VARCHAR, @MaxRodada)
			DECLARE curClassificacao CURSOR FOR							
			SELECT TOP 2 a.NomeTime, a.NomeGrupo, SUM(TotalPontos), SUM(TotalGolsPro-TotalGolsContra) Saldo, SUM(TotalGolsPro)
			  FROM 
				(
						SELECT NomeTime, NomeGrupo
						  FROM CampeonatosClassificacao
						 WHERE NomeCampeonato	= @NomeCampeonato 
						   AND NomeFase			= 'Classificatória'
						   AND Posicao			= @Posicao   
						   AND Rodada           = @MaxRodada
				) as A
			 INNER JOIN CampeonatosClassificacao b
				ON a.NomeTime = b.NomeTime
			   AND a.NomeGrupo = b.NomeGrupo
			 GROUP BY a.NomeTime, a.NomeGrupo
			 ORDER BY SUM(TotalPontos) DESC, SUM(TotalGolsPro-TotalGolsContra) DESC, SUM(TotalGolsPro) DESC 				 
		 
		 
			-- Abrindo o cursor
			 OPEN curClassificacao
			 FETCH NEXT FROM curClassificacao INTO @NomeTime, @NomeGrupo, @TotalPontos, @Saldo, @TotalGolsPro

			 SET @Count = 1
			 -- Entrando no laço para analisar a posição do time
			 WHILE @@FETCH_STATUS = 0
			 BEGIN
				PRINT '' + @NomeTime + ' - Grupo: ' + @NomeGrupo + ' - Pontos: ' + CONVERT(VARCHAR, @TotalPontos) + ' - Saldo: ' + CONVERT(VARCHAR, @Saldo)

				IF @Count = 1
				BEGIN
					SET @NomeTime1 = @NomeTime
					SET @NomeGrupo1 = @NomeGrupo
				END
				ELSE IF @Count = 2
				BEGIN
					SET @NomeTime2 = @NomeTime
					SET @NomeGrupo2 = @NomeGrupo
				END

				SET @Count = @Count + 1
				FETCH NEXT FROM curClassificacao INTO @NomeTime, @NomeGrupo, @TotalPontos, @Saldo, @TotalGolsPro
			 END

			 -- Fechando o cursor
			 CLOSE curClassificacao
			 DEALLOCATE curClassificacao

			 PRINT '--------------------------------------------------'
			 PRINT 'NomeTime1: ' + @NomeTime1 + ' - Grupo1: ' + @NomeGrupo1
			 PRINT 'NomeTime2: ' + @NomeTime2 + ' - Grupo2: ' + @NomeGrupo2	 

			 IF (@NomeGrupo1 = 'A' OR (@NomeGrupo1 = 'B' AND @NomeGrupo2 = 'C'))
			 BEGIN
				SET @NomeTimeAB = @NomeTime1
				SET @NomeTimeBC = @NomeTime2
			 END
			 ELSE IF (@NomeGrupo1 = 'C' OR (@NomeGrupo1 = 'B'  AND @NomeGrupo2 = 'A'))
			 BEGIN
				SET @NomeTimeBC = @NomeTime1
				SET @NomeTimeAB = @NomeTime2		
			 END
	 
			 PRINT '3AB: ' + @NomeTimeAB + ' - 3BC: ' + @NomeTimeBC
			 PRINT '--------------------------------------------------'

			 -------------------------------------
			 --- VERIFICACAO DO TIME 3AB - TIME 1
			 -------------------------------------
			 SELECT @JogoAtualizacao = JogoId 
			   FROM Jogos j
			  WHERE j.NomeCampeonato			= @NomeCampeonato
				AND (j.PendenteTime1NomeGrupo	= 'AB'	AND j.PendenteTime1PosGrupo	= 3)
	 
			IF (@JogoAtualizacao IS NOT NULL)
			BEGIN			
				PRINT 'Atualizando registro da aposta: ' + CONVERT(VARCHAR, @JogoAtualizacao) + ' Para o time 3AB - Time 1'
				
				UPDATE Jogos
				   SET NomeTime1			= @NomeTimeAB
				 WHERE NomeCampeonato		= @NomeCampeonato
				   AND JogoID				= @JogoAtualizacao
			END			
			-------------------------------------
			--- VERIFICACAO DO TIME 3BC - TIME 1
			-------------------------------------
			 SELECT @JogoAtualizacao = JogoId 
			   FROM Jogos j
			  WHERE j.NomeCampeonato			= @NomeCampeonato
				AND (j.PendenteTime1NomeGrupo	= 'BC'	AND j.PendenteTime1PosGrupo	= 3)
			
			IF (@JogoAtualizacao IS NOT NULL)
			BEGIN			
				PRINT 'Atualizando registro da aposta: ' + CONVERT(VARCHAR, @JogoAtualizacao) + ' Para o time 3BC - Time 1'
				
				UPDATE Jogos
				   SET NomeTime1			= @NomeTimeBC
				 WHERE NomeCampeonato		= @NomeCampeonato
				   AND JogoID				= @JogoAtualizacao
			END		
			-------------------------------------
			 --- VERIFICACAO DO TIME 3AB - TIME 2
			 -------------------------------------
			 SELECT @JogoAtualizacao = JogoId 
			   FROM Jogos j
			  WHERE j.NomeCampeonato			= @NomeCampeonato
				AND (j.PendenteTime2NomeGrupo	= 'AB'	AND j.PendenteTime2PosGrupo	= 3)
	 
			IF (@JogoAtualizacao IS NOT NULL)
			BEGIN			
				PRINT 'Atualizando registro da aposta: ' + CONVERT(VARCHAR, @JogoAtualizacao) + ' Para o time 3AB - Time 2'
				
				UPDATE Jogos
				   SET NomeTime2			= @NomeTimeAB
				 WHERE NomeCampeonato		= @NomeCampeonato
				   AND JogoID				= @JogoAtualizacao
			END			
			-------------------------------------
			--- VERIFICACAO DO TIME 3BC - TIME 1
			-------------------------------------
			 SELECT @JogoAtualizacao = JogoId 
			   FROM Jogos j
			  WHERE j.NomeCampeonato			= @NomeCampeonato
				AND (j.PendenteTime2NomeGrupo	= 'BC'	AND j.PendenteTime2PosGrupo	= 3)
			
			IF (@JogoAtualizacao IS NOT NULL)
			BEGIN			
				PRINT 'Atualizando registro da aposta: ' + CONVERT(VARCHAR, @JogoAtualizacao) + ' Para o time 3BC - Time 2'
				
				UPDATE Jogos
				   SET NomeTime2			= @NomeTimeBC
				 WHERE NomeCampeonato		= @NomeCampeonato
				   AND JogoID				= @JogoAtualizacao
			END		
		END --Jogos da fase classificatória concluídas
	END
	ELSE
	BEGIN
		
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
END



