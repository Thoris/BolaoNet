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


       DECLARE @IdJogoCursor                                 int
       DECLARE @PendenteTimeNomeGrupoCursor    varchar(30)
       DECLARE @PendenteTimePosGrupoCursor            int

       DECLARE @Total                                              int
       DECLARE @count                                              int
       DECLARE @NomeGrupoCorrente                     varchar(30)
       DECLARE @TotalPendencia                               int
       DECLARE @SomaGrupos                                   int
       DECLARE @NomeGrupoIn                           varchar(50)
       DECLARE @NomeTime                                     varchar(150)
       DECLARE @NomeGrupoMelhor                       varchar(30)
       DECLARE @sql                                          nvarchar(4000)


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



GO
