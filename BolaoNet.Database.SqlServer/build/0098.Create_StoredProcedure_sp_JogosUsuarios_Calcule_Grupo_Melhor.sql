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
