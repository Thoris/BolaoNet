IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_JogosUsuarios_Calcule_Grupo_Melhor')
BEGIN
	DROP  Procedure  sp_JogosUsuarios_Calcule_Grupo_Melhor
END
GO
CREATE PROCEDURE [dbo].[sp_JogosUsuarios_Calcule_Grupo_Melhor]
(
    @CurrentLogin						varchar(25),
	@CurrentDateTime					datetime = null,
	@NomeCampeonato						varchar(50),
	@NomeBolao							varchar(30),	
	@UserName							varchar(25),			
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


       DECLARE @IdJogoCursor                   int
       DECLARE @PendenteTimeNomeGrupoCursor    varchar(30)
       DECLARE @PendenteTimePosGrupoCursor     int

       DECLARE @Total                          int
       DECLARE @count                          int
       DECLARE @NomeGrupoCorrente              varchar(30)
       DECLARE @TotalPendencia                 int
       DECLARE @SomaGrupos                     int
       DECLARE @NomeGrupoIn                    varchar(50)
       DECLARE @NomeTime                       varchar(150)
       DECLARE @NomeGrupoMelhor                varchar(30)
       DECLARE @sql                            nvarchar(4000)

	   IF (@NomeCampeonato LIKE 'Copa América %')
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

			-- Verificação de quantidade de jogos que ainda não foram efetuadas apostas
			--SELECT @JogosPendentes = ISNULL(COUNT(*) , 0)
			--  FROM Jogos j
			--  LEFT JOIN JogosUsuarios u
			--	ON j.JogoId = u.JogoId
			-- WHERE j.NomeFase = 'Classificatória'
			--   AND u.UserName = @UserName
			--   AND (j.IsValido IS NULL OR j.IsValido = 0)
			   
			  
			SELECT @TotalJogos = COUNT(*), @JogosPendentes = COUNT(JogosUsuarios.ApostaTime1)
			  FROM Jogos
			  LEFT JOIN JogosUsuarios
				ON Jogos.JogoID				= JogosUsuarios.JogoID
			   AND Jogos.NomeCampeonato		= JogosUsuarios.NomeCampeonato
			   AND JogosUsuarios.UserName	= @UserName
			   AND JogosUsuarios.ApostaTime1 IS NOT NULL
			   AND JogosUsuarios.ApostaTime2 IS NOT NULL
			 WHERE Jogos.NomeCampeonato		= @NomeCampeonato
			   AND Jogos.NomeFase			= 'Classificatória'		   
			  			
			-- Verifica se não existem mais jogos pendentes e está incluindo o último da fase classificatória    
			--IF @JogosPendentes = 0  --AND @NomeFase = 'Classificatória'
			IF (@TotalJogos = @JogosPendentes)
			BEGIN
				 DECLARE curClassificacao CURSOR FOR
					SELECT TOP 2 NomeTime, NomeGrupo, TotalPontos, TotalGolsPro-TotalGolsContra Saldo, TotalGolsPro
						  FROM BoloesCampeonatosClassificacaoUsuarios
						WHERE NomeCampeonato      = @NomeCampeonato
							AND NomeFase          = 'Classificatória'
							AND UserName          = @UserName
							AND Posicao           = @Posicao
							AND NomeBolao         = @NomeBolao
							AND NomeGrupo         IN ('A','B','C')
						ORDER BY TotalPontos DESC, TotalGolsPro-TotalGolsContra DESC, TotalGolsPro DESC 
    
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
					IF (NOT EXISTS (SELECT * 
								  FROM JogosUsuarios
								 WHERE NomeCampeonato     = @NomeCampeonato
								   AND JogoID             = @JogoAtualizacao
								   AND NomeBolao          = @NomeBolao
								   AND UserName           = @UserName
										)
							)
					BEGIN
						-- Inserindo o registro automático
						PRINT 'Inserindo o registro automático: ' + CONVERT(VARCHAR, @JogoAtualizacao) + ' Para o time 3AB'
							   
						INSERT JogosUsuarios 
								(JogoID, NomeCampeonato, UserName, NomeBolao, NomeTimeResult1, NomeTimeResult2, Automatico, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate) 
						VALUES
								(@JogoAtualizacao, @NomeCampeonato, @UserName, @NomeBolao, @NomeTimeAB, NULL, 1, @CurrentLogin, @CurrentDateTime, @CurrentLogin, @CurrentDateTime)
														  
					END
					-- Se já existe o registro        
					ELSE
					BEGIN
						
						PRINT 'Atualizando registro da aposta: ' + CONVERT(VARCHAR, @JogoAtualizacao) + ' Para o time 3AB'
							   
						UPDATE JogosUsuarios
							SET NomeTimeResult1     = @NomeTimeAB                          
						WHERE NomeCampeonato        = @NomeCampeonato
							AND JogoID              = @JogoAtualizacao
							AND UserName            = @UserName
							AND NomeBolao           = @NomeBolao
												   
					END -- endif jogos dos usuários
				END -- id jogo nao existe

				-------------------------------------
				--- VERIFICACAO DO TIME 3BC - TIME 1
				-------------------------------------
				 SELECT @JogoAtualizacao = JogoId 
				   FROM Jogos j
				  WHERE j.NomeCampeonato			= @NomeCampeonato
					AND (j.PendenteTime1NomeGrupo	= 'BC'	AND j.PendenteTime1PosGrupo	= 3)
	
				IF (@JogoAtualizacao IS NOT NULL)
				BEGIN
					IF(NOT EXISTS (SELECT * 
									  FROM JogosUsuarios
									 WHERE NomeCampeonato     = @NomeCampeonato
									   AND JogoID             = @JogoAtualizacao
									   AND NomeBolao          = @NomeBolao
									   AND UserName           = @UserName
											)
								)
					BEGIN
						-- Inserindo o registro automático
						PRINT 'Inserindo o registro automático: ' + CONVERT(VARCHAR, @JogoAtualizacao) + ' Para o time 3BC'
							   
						INSERT JogosUsuarios 
								(JogoID, NomeCampeonato, UserName, NomeBolao, NomeTimeResult1, NomeTimeResult2, Automatico, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate) 
						VALUES
								(@JogoAtualizacao, @NomeCampeonato, @UserName, @NomeBolao, @NomeTimeBC, NULL, 1, @CurrentLogin, @CurrentDateTime, @CurrentLogin, @CurrentDateTime)
														  
					END
					-- Se já existe o registro        
					ELSE
					BEGIN
						
						PRINT 'Atualizando registro da aposta: ' + CONVERT(VARCHAR, @JogoAtualizacao) + ' Para o time 3BC'
							   
						UPDATE JogosUsuarios
							SET NomeTimeResult1     = @NomeTimeBC                          
						WHERE NomeCampeonato        = @NomeCampeonato
							AND JogoID              = @JogoAtualizacao
							AND UserName            = @UserName
							AND NomeBolao           = @NomeBolao
												   
					END -- endif jogos dos usuários
				END -- Endif id do jogo existe
				
				
				
				 -------------------------------------
				 --- VERIFICACAO DO TIME 3AB - TIME 2
				 -------------------------------------
				 SELECT @JogoAtualizacao = JogoId 
				   FROM Jogos j
				  WHERE j.NomeCampeonato			= @NomeCampeonato
					AND (j.PendenteTime2NomeGrupo	= 'AB'	AND j.PendenteTime2PosGrupo	= 3)

				IF (@JogoAtualizacao IS NOT NULL)
				BEGIN
					IF (NOT EXISTS (SELECT * 
								  FROM JogosUsuarios
								 WHERE NomeCampeonato     = @NomeCampeonato
								   AND JogoID             = @JogoAtualizacao
								   AND NomeBolao          = @NomeBolao
								   AND UserName           = @UserName
										)
							)
					BEGIN
						-- Inserindo o registro automático
						PRINT 'Inserindo o registro automático: ' + CONVERT(VARCHAR, @JogoAtualizacao) + ' Para o time 3AB'
							   
						INSERT JogosUsuarios 
								(JogoID, NomeCampeonato, UserName, NomeBolao, NomeTimeResult1, NomeTimeResult2, Automatico, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate) 
						VALUES
								(@JogoAtualizacao, @NomeCampeonato, @UserName, @NomeBolao, NULL, @NomeTimeAB, 1, @CurrentLogin, @CurrentDateTime, @CurrentLogin, @CurrentDateTime)
														  
					END
					-- Se já existe o registro        
					ELSE
					BEGIN
						
						PRINT 'Atualizando registro da aposta: ' + CONVERT(VARCHAR, @JogoAtualizacao) + ' Para o time 3AB'
							   
						UPDATE JogosUsuarios
							SET NomeTimeResult2     = @NomeTimeAB                          
						WHERE NomeCampeonato        = @NomeCampeonato
							AND JogoID              = @JogoAtualizacao
							AND UserName            = @UserName
							AND NomeBolao           = @NomeBolao
												   
					END -- endif jogos dos usuários
				END -- id jogo nao existe

				-------------------------------------
				--- VERIFICACAO DO TIME 3BC - TIME 2
				-------------------------------------
				 SELECT @JogoAtualizacao = JogoId 
				   FROM Jogos j
				  WHERE j.NomeCampeonato			= @NomeCampeonato
					AND (j.PendenteTime2NomeGrupo	= 'BC'	AND j.PendenteTime2PosGrupo	= 3)
	
				IF (@JogoAtualizacao IS NOT NULL)
				BEGIN
					IF(NOT EXISTS (SELECT * 
									  FROM JogosUsuarios
									 WHERE NomeCampeonato     = @NomeCampeonato
									   AND JogoID             = @JogoAtualizacao
									   AND NomeBolao          = @NomeBolao
									   AND UserName           = @UserName
											)
								)
					BEGIN
						-- Inserindo o registro automático
						PRINT 'Inserindo o registro automático: ' + CONVERT(VARCHAR, @JogoAtualizacao) + ' Para o time 3BC'
							   
						INSERT JogosUsuarios 
								(JogoID, NomeCampeonato, UserName, NomeBolao, NomeTimeResult1, NomeTimeResult2, Automatico, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate) 
						VALUES
								(@JogoAtualizacao, @NomeCampeonato, @UserName, @NomeBolao, NULL, @NomeTimeBC, 1, @CurrentLogin, @CurrentDateTime, @CurrentLogin, @CurrentDateTime)
														  
					END
					-- Se já existe o registro        
					ELSE
					BEGIN
						
						PRINT 'Atualizando registro da aposta: ' + CONVERT(VARCHAR, @JogoAtualizacao) + ' Para o time 3BC'
							   
						UPDATE JogosUsuarios
							SET NomeTimeResult2     = @NomeTimeBC                          
						WHERE NomeCampeonato        = @NomeCampeonato
							AND JogoID              = @JogoAtualizacao
							AND UserName            = @UserName
							AND NomeBolao           = @NomeBolao
												   
					END -- endif jogos dos usuários
				END -- Endif id do jogo existe
			END  -- Endif nao existem jogos pendentes
	   END
	   IF (@NomeCampeonato LIKE 'Copa do Mundo %')
	   BEGIN 

			 PRINT 'INICIO - Campeonato: ' + @NomeCampeonato + ' - Fase: ' + @NomeFase + ' - Grupo: ' + @NomeGrupo



			 
			--1. GERAR GRUPOS A-L
			IF OBJECT_ID('tempdb..#Grupos') IS NOT NULL DROP TABLE #Grupos

			CREATE TABLE #Grupos (Grupo CHAR(1))

			INSERT INTO #Grupos
			SELECT Nome
			FROM CampeonatosGrupos
			WHERE NomeCampeonato = @NomeCampeonato
			  AND Nome IS NOT NULL
			  AND Nome <> ' '

			-- 2. GERAR AS 495 COMBINAÇÕES
			IF OBJECT_ID('tempdb..#Combinacoes') IS NOT NULL DROP TABLE #Combinacoes

			;WITH CTE AS (
				SELECT 
					CAST(Grupo AS VARCHAR(20)) AS Combinacao,
					Grupo,
					1 AS Nivel
				FROM #Grupos

				UNION ALL

				SELECT 
					CAST(C.Combinacao + G.Grupo AS VARCHAR(20)),
					G.Grupo,
					C.Nivel + 1
				FROM CTE C
				JOIN #Grupos G
					ON G.Grupo > C.Grupo
				WHERE C.Nivel < 8
			)
			SELECT Combinacao
			INTO #Combinacoes
			FROM CTE
			WHERE LEN(Combinacao) = 8
			OPTION (MAXRECURSION 0)

			-- Resultado: 495 linhas

			-- 3. SLOTS FIXOS FIFA

			--INSERT INTO #SlotsFifa VALUES
			--(1,74,2),
			--(2,77,2),
			--(3,79,2),
			--(4,80,2),
			--(5,81,2),
			--(6,82,2),
			--(7,85,2),
			--(8,87,2)

			 IF OBJECT_ID('tempdb..#SlotsFifa') IS NOT NULL DROP TABLE #SlotsFifa

			;WITH Slots AS (
				SELECT 
					JogoId,
					1 AS Lado,
					DataJogo
				FROM Jogos
				WHERE NomeCampeonato = @NomeCampeonato
				  AND PendenteTime1PosGrupo = 3

				UNION ALL

				SELECT 
					JogoId,
					2,
					DataJogo
				FROM Jogos
				WHERE NomeCampeonato = @NomeCampeonato
				  AND PendenteTime2PosGrupo = 3
			)
			SELECT *,
				   ROW_NUMBER() OVER (ORDER BY DataJogo, JogoId, Lado) AS SlotOrdem
			INTO #SlotsFifa
			FROM Slots



			-- 4. GERAR TABELA COMPLETA #FifaOficial

			--vamos criar uma distribuição determinística e sem duplicação

			IF OBJECT_ID('tempdb..#FifaOficial') IS NOT NULL DROP TABLE #FifaOficial

			CREATE TABLE #FifaOficial
			(
				Combinacao VARCHAR(20),
				SlotOrdem INT,
				Grupo CHAR(1)
			)

			;WITH GruposExplodidos AS (
				SELECT 
					C.Combinacao,
					SUBSTRING(C.Combinacao, N.Number, 1) AS Grupo,
					ROW_NUMBER() OVER (
						PARTITION BY C.Combinacao
						ORDER BY SUBSTRING(C.Combinacao, N.Number, 1)
					) AS OrdemGrupo
				FROM #Combinacoes C
				JOIN master..spt_values N
					ON N.Type = 'P'
				   AND N.Number BETWEEN 1 AND LEN(C.Combinacao)
			)
			INSERT INTO #FifaOficial
			SELECT 
				G.Combinacao,
				G.OrdemGrupo AS SlotOrdem,
				G.Grupo
			FROM GruposExplodidos G

			--5. RANKING + TOP 8

			IF OBJECT_ID('tempdb..#Ranking') IS NOT NULL DROP TABLE #Ranking

			SELECT 
				NomeTime,
				NomeGrupo,
				TotalPontos,
				(TotalGolsPro - TotalGolsContra) AS Saldo,
				TotalGolsPro,
				ROW_NUMBER() OVER (
					ORDER BY 
						TotalPontos DESC,
						(TotalGolsPro - TotalGolsContra) DESC,
						TotalGolsPro DESC
				) AS RankTerceiro
			INTO #Ranking
			FROM BoloesCampeonatosClassificacaoUsuarios
			WHERE NomeCampeonato = @NomeCampeonato
			  AND NomeFase = 'Classificatória'
			  AND UserName = @UserName
			  AND NomeBolao = @NomeBolao
			  AND Posicao = 3

			IF OBJECT_ID('tempdb..#Top8') IS NOT NULL DROP TABLE #Top8

			SELECT TOP 8 *
			INTO #Top8
			FROM #Ranking
			ORDER BY RankTerceiro

			-- 6. COMBINAÇÃO ATUAL
			DECLARE @Combinacao VARCHAR(20)

			SELECT @Combinacao =
				STRING_AGG(NomeGrupo, '') WITHIN GROUP (ORDER BY NomeGrupo)
			FROM #Top8

			PRINT 'COMBINACAO FIFA: ' + @Combinacao

			-- 7. DISTRIBUIÇÃO FINAL
			IF OBJECT_ID('tempdb..#Preenchimento') IS NOT NULL DROP TABLE #Preenchimento

			SELECT 
				S.JogoId,
				S.Lado,
				T.NomeTime
			INTO #Preenchimento
			FROM #FifaOficial F
			JOIN #SlotsFifa S
				ON S.SlotOrdem = F.SlotOrdem
			JOIN #Top8 T
				ON T.NomeGrupo = F.Grupo
			WHERE F.Combinacao = @Combinacao

			------------------------------------------------------------
			-- 8. UPSERT FINAL EM JogosUsuarios
			------------------------------------------------------------

			-- 8.1. GARANTIR 1 LINHA POR JOGO (pivot dos lados)
			IF OBJECT_ID('tempdb..#FinalJogos') IS NOT NULL DROP TABLE #FinalJogos

			SELECT 
				P.JogoId,
				MAX(CASE WHEN P.Lado = 1 THEN P.NomeTime END) AS NomeTime1,
				MAX(CASE WHEN P.Lado = 2 THEN P.NomeTime END) AS NomeTime2
			INTO #FinalJogos
			FROM #Preenchimento P
			GROUP BY P.JogoId

			------------------------------------------------------------
			-- 8.2. INSERT (somente se não existir)
			------------------------------------------------------------
			INSERT INTO JogosUsuarios
			(
				JogoID,
				NomeCampeonato,
				UserName,
				NomeBolao,
				NomeTimeResult1,
				NomeTimeResult2,
				Automatico,
				CreatedBy,
				CreatedDate,
				ModifiedBy,
				ModifiedDate
			)
			SELECT 
				F.JogoId,
				@NomeCampeonato,
				@UserName,
				@NomeBolao,
				F.NomeTime1,
				F.NomeTime2,
				1,
				@UserName,
				GETDATE(),
				@UserName,
				GETDATE()
			FROM #FinalJogos F
			WHERE NOT EXISTS (
				SELECT 1
				FROM JogosUsuarios JU
				WHERE JU.JogoID = F.JogoId
				  AND JU.NomeCampeonato = @NomeCampeonato
				  AND JU.UserName = @UserName
				  AND JU.NomeBolao = @NomeBolao
			)


			------------------------------------------------------------
			-- 8.3. UPDATE (quando já existir)
			------------------------------------------------------------
			UPDATE JU
			SET 
				JU.NomeTimeResult1 = CASE WHEN F.NomeTime1 IS NOT NULL THEN F.NomeTime1 ELSE JU.NomeTimeResult1 END,
				JU.NomeTimeResult2 = CASE WHEN F.NomeTime2 IS NOT NULL THEN F.NomeTime2 ELSE JU.NomeTimeResult2 END,
				JU.ModifiedBy = @UserName,
				JU.ModifiedDate = GETDATE()
			FROM JogosUsuarios JU
			JOIN #FinalJogos F
				ON JU.JogoID = F.JogoId
			WHERE JU.NomeCampeonato = @NomeCampeonato
			  AND JU.UserName = @UserName
			  AND JU.NomeBolao = @NomeBolao


			------------------------------------------------------------
			-- DEBUG FINAL
			------------------------------------------------------------
			PRINT '--- UPSERT CONCLUIDO ---'

			--SELECT *
			--FROM JogosUsuarios
			--WHERE NomeCampeonato = @NomeCampeonato
			--  AND UserName = @UserName
			--  AND NomeBolao = @NomeBolao

			 PRINT 'FIM - Campeonato: ' + @NomeCampeonato + ' - Fase: ' + @NomeFase + ' - Grupo: ' + @NomeGrupo
			 
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
		   WHERE NomeCampeonato                          = @NomeCampeonato
			  AND PendenteTime1NomeGrupo           LIKE '%' + @NomeGrupo + '%'
			  AND PendenteTime1MelhorGrupos  = 1
     
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
                                        
						IF (LEN(@NomegrupoIn) > 0)
						BEGIN
							   SET @NomeGrupoIn = @NomeGrupoIn + ','
						END
						SET @NomeGrupoIn = @NomeGrupoIn + '''' + @NomeGrupoCorrente + ''''

						SET @count = @count + 1
				 END

				 -- Verificando se todos os jogos dos grupos foram concluídos
				 SET @sql = 'SELECT @total =ISNULL(COUNT(*), 0) 
						FROM BoloesCampeonatosClassificacaoUsuarios
						WHERE NomeCampeonato = ''' + @NomeCampeonato + '''
						AND NomeFase               = ''' + @NomeFase + '''
						AND UserName               = ''' + @UserName + '''
						AND Posicao                       = ' + CONVERT(VARCHAR, @PendenteTimePosGrupoCursor) + '
						AND NomeBolao              = ''' + @NomeBolao + '''
						AND NomeGrupo              IN (' + @NomeGrupoIn + ')'


				 EXECUTE sp_executesql      @sql, 
														  @Params = N'@Total int OUTPUT', 
														  @Total = @Total OUTPUT

				 -- Se conseguiu completar todos os jogos dos grupos
				 IF (@Total = LEN(@PendenteTimeNomeGrupoCursor))
				 BEGIN
						PRINT 'Todos os jogos concluídos: ' + @NomeGrupoIn
                    
						SET @sql = 'SELECT TOP 1 @NomeTime = NomeTime, @NomeGrupoMelhor = NomeGrupo
						  FROM BoloesCampeonatosClassificacaoUsuarios
						WHERE NomeCampeonato      = ''' + @NomeCampeonato + '''
						   AND NomeFase                   = ''' + @NomeFase + '''
						   AND UserName                   = ''' + @UserName + '''
						   AND Posicao                    = ' + CONVERT(VARCHAR, @PendenteTimePosGrupoCursor) + '
						   AND NomeBolao           = ''' + @NomeBolao + '''
						   AND NomeGrupo           IN (' + @NomeGrupoIn + ')
						ORDER BY TotalPontos DESC, TotalGolsPro-TotalGolsContra DESC, TotalGolsPro DESC '

						EXECUTE sp_executesql @sql, 
														  @Params = N'@NomeTime varchar(150) OUTPUT, @NomeGrupoMelhor varchar(30) OUTPUT', 
														  @NomeTime = @NomeTime OUTPUT, @NomeGrupoMelhor = @NomeGrupoMelhor OUTPUT
                                  
						PRINT 'Melhor ' + CONVERT(VARCHAR, @PendenteTimePosGrupoCursor) + ' : ' + @NomeTime + ' . Grupo: ' + @NomeGrupoMelhor 
									  + ' Jogo: ' + CONVERT(VARCHAR, @IdJogoCursor) + ' Para o time 1'
                          
						IF (NOT EXISTS (SELECT * 
											  FROM JogosUsuarios
											WHERE NomeCampeonato             = @NomeCampeonato
											   AND JogoID                     = @IdJogoCursor
											   AND NomeBolao                  = @NomeBolao
											   AND UserName                         = @UserName
											)
							   )
						BEGIN
							   -- Inserindo o registro automático
							   PRINT 'Inserindo o registro automático: ' + CONVERT(VARCHAR, @IdJogoCursor) + ' Para o time 1'
                           
							   INSERT JogosUsuarios 
										(JogoID, NomeCampeonato, UserName, NomeBolao, NomeTimeResult1, NomeTimeResult2, Automatico, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate) 
							   VALUES
										(@IdJogoCursor, @NomeCampeonato, @UserName, @NomeBolao, @NomeTime, NULL, 1, @CurrentLogin, @CurrentDateTime, @CurrentLogin, @CurrentDateTime)
                                                      
						END
						-- Se já existe o registro        
						ELSE
						BEGIN
                    
							   PRINT 'Atualizando registro da aposta: ' + CONVERT(VARCHAR, @IdJogoCursor) + ' Para o time 1'
                           
							   UPDATE JogosUsuarios
								  SET NomeTimeResult1     = @NomeTime                          
								WHERE NomeCampeonato             = @NomeCampeonato
								  AND JogoID                     = @IdJogoCursor
								  AND UserName                         = @UserName
								  AND NomeBolao                  = @NomeBolao
                                               
						END -- endif jogos dos usuários
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
		   WHERE NomeCampeonato                          = @NomeCampeonato
			  AND PendenteTime2NomeGrupo           LIKE '%' + @NomeGrupo + '%'
			  AND PendenteTime2MelhorGrupos  = 1
          
          
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
                                        
						IF (LEN(@NomegrupoIn) > 0)
						BEGIN
							   SET @NomeGrupoIn = @NomeGrupoIn + ','
						END
						SET @NomeGrupoIn = @NomeGrupoIn + '''' + @NomeGrupoCorrente + ''''

						SET @count = @count + 1
				 END

				 -- Verificando se todos os jogos dos grupos foram concluídos
				 SET @sql = 'SELECT @total =ISNULL(COUNT(*), 0) 
						FROM BoloesCampeonatosClassificacaoUsuarios
						WHERE NomeCampeonato = ''' + @NomeCampeonato + '''
						AND NomeFase               = ''' + @NomeFase + '''
						AND UserName               = ''' + @UserName + '''
						AND Posicao                       = ' + CONVERT(VARCHAR, @PendenteTimePosGrupoCursor) + '
						AND NomeBolao              = ''' + @NomeBolao + '''
						AND NomeGrupo              IN (' + @NomeGrupoIn + ')'


				 EXECUTE sp_executesql      @sql, 
														  @Params = N'@Total int OUTPUT', 
														  @Total = @Total OUTPUT

				 -- Se conseguiu completar todos os jogos dos grupos
				 IF (@Total = LEN(@PendenteTimeNomeGrupoCursor))
				 BEGIN
						PRINT 'Todos os jogos concluídos: ' + @NomeGrupoIn
                    
						SET @sql = 'SELECT TOP 1 @NomeTime = NomeTime, @NomeGrupoMelhor = NomeGrupo
						  FROM BoloesCampeonatosClassificacaoUsuarios
						WHERE NomeCampeonato      = ''' + @NomeCampeonato + '''
						   AND NomeFase                   = ''' + @NomeFase + '''
						   AND UserName                   = ''' + @UserName + '''
						   AND Posicao                    = ' + CONVERT(VARCHAR, @PendenteTimePosGrupoCursor) + '
						   AND NomeBolao           = ''' + @NomeBolao + '''
						   AND NomeGrupo IN (' + @NomeGrupoIn + ')
						ORDER BY TotalPontos DESC, TotalGolsPro-TotalGolsContra DESC, TotalGolsPro DESC '

						EXECUTE sp_executesql @sql, 
														  @Params = N'@NomeTime varchar(150) OUTPUT, @NomeGrupoMelhor varchar(30) OUTPUT', 
														  @NomeTime = @NomeTime OUTPUT, @NomeGrupoMelhor = @NomeGrupoMelhor OUTPUT
                                  
						PRINT 'Melhor ' + CONVERT(VARCHAR, @PendenteTimePosGrupoCursor) + ' : ' + @NomeTime + ' . Grupo: ' + @NomeGrupoMelhor 
									  + ' Jogo: ' + CONVERT(VARCHAR, @IdJogoCursor) + ' Para o time 2'
                          
						IF (NOT EXISTS (SELECT * 
											  FROM JogosUsuarios
											WHERE NomeCampeonato             = @NomeCampeonato
											   AND JogoID                     = @IdJogoCursor
											   AND NomeBolao                  = @NomeBolao
											   AND UserName                         = @UserName
											)
							   )
						BEGIN
							   -- Inserindo o registro automático
							   PRINT 'Inserindo o registro automático: ' + CONVERT(VARCHAR, @IdJogoCursor) + ' Para o time 2'
                           
							   INSERT JogosUsuarios 
										(JogoID, NomeCampeonato, UserName, NomeBolao, NomeTimeResult2, NomeTimeResult1, Automatico, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate) 
							   VALUES
										(@IdJogoCursor, @NomeCampeonato, @UserName, @NomeBolao, @NomeTime, NULL, 1, @CurrentLogin, @CurrentDateTime, @CurrentLogin, @CurrentDateTime)
                                                      
						END
						-- Se já existe o registro        
						ELSE
						BEGIN
                    
							   PRINT 'Atualizando registro da aposta: ' + CONVERT(VARCHAR, @IdJogoCursor) + ' Para o time 2'
                           
							   UPDATE JogosUsuarios
								  SET NomeTimeResult2            = @NomeTime                          
								WHERE NomeCampeonato             = @NomeCampeonato
								  AND JogoID                     = @IdJogoCursor
								  AND UserName                         = @UserName
								  AND NomeBolao                  = @NomeBolao
                                               
						END -- endif jogos dos usuários
				 END
                                        
				 -- Passando para o próximo registro da dependência do grupo fechado
				 FETCH NEXT FROM curClassificacao2 INTO @IdJogoCursor, @PendenteTimeNomeGrupoCursor, @PendenteTimePosGrupoCursor
		   END

		   -- Fechando o cursor
		   CLOSE curClassificacao2
		   DEALLOCATE curClassificacao2


	END
END

GO
