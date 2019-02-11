IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_JogosUsuarios_Calcule_Time')
BEGIN
	DROP  Procedure  sp_JogosUsuarios_Calcule_Time
END
GO
CREATE PROCEDURE [dbo].[sp_JogosUsuarios_Calcule_Time]
(
    @CurrentLogin						varchar(25),
	@CurrentDateTime					datetime = null,
	@NomeCampeonato						varchar(50),
	@NomeBolao							varchar(30),	
	@UserName							varchar(25),			
	@NomeTime							varchar(30),
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
	


	-- Apagando registro inserido previamente
	DELETE 
	  FROM BoloesCampeonatosClassificacaoUsuarios
	 WHERE NomeCampeonato	= @NomeCampeonato
	   AND NomeFase			= @NomeFase
	   AND NomeGrupo		= @NomeGrupo
	   AND UserName			= @UserName
	   AND NomeTime			= @NomeTime
	   



	-- Inserindo os dados do time 1
	INSERT INTO BoloesCampeonatosClassificacaoUsuarios 
		(
		 NomeCampeonato, NomeFase, NomeGrupo, NomeTime, UserName, NomeBolao, 
		 TotalVitorias, TotalDerrotas, TotalEmpates, TotalGolsPro, TotalGolsContra, TotalPontos, 
		 CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag
		 )
	SELECT Jogos.NomeCampeonato, Jogos.NomeFase, Jogos.NomeGrupo, @NomeTime, JogosUsuarios.UserName, JogosUsuarios.NomeBolao,
		  		   SUM(CASE 
					WHEN ((Jogos.NomeTime1 = @NomeTime AND JogosUsuarios.ApostaTime1 > JogosUsuarios.ApostaTime2)
					  OR  (Jogos.NomeTime2 = @NomeTime AND JogosUsuarios.ApostaTime1 < JogosUsuarios.ApostaTime2))
					THEN 1 
					ELSE 0
				END) as TotalVitorias,
		        	   
		   SUM(CASE 
					WHEN ((Jogos.NomeTime1 = @NomeTime AND JogosUsuarios.ApostaTime1 < JogosUsuarios.ApostaTime2)
					  OR  (Jogos.NomeTime2 = @NomeTime AND JogosUsuarios.ApostaTime1 > JogosUsuarios.ApostaTime2))
					THEN 1
					ELSE 0 
				END) as TotalDerrotas,
		   	   
		   SUM(CASE WHEN (JogosUsuarios.ApostaTime1 = JogosUsuarios.ApostaTime2) THEN 1 ELSE 0 END) as TotalEmpates,

		   SUM(CASE WHEN (Jogos.NomeTime1 = @NomeTime) THEN JogosUsuarios.ApostaTime1 ELSE 0 END) + 
			SUM(CASE WHEN (Jogos.NomeTime2 = @NomeTime) THEN JogosUsuarios.ApostaTime2 ELSE 0 END) as TotalGolsContra, 
		   
		   SUM(CASE WHEN (Jogos.NomeTime1 = @NomeTime) THEN JogosUsuarios.ApostaTime2 ELSE 0 END) + 
			SUM(CASE WHEN (Jogos.NomeTime2 = @NomeTime) THEN JogosUsuarios.ApostaTime1 ELSE 0 END) as TotalGolsPro, 

			SUM(CASE 
					WHEN ((Jogos.NomeTime1 = @NomeTime AND JogosUsuarios.ApostaTime1 > JogosUsuarios.ApostaTime2)
					  OR  (Jogos.NomeTime2 = @NomeTime AND JogosUsuarios.ApostaTime1 < JogosUsuarios.ApostaTime2))
					THEN 3
				ELSE 0
				END
				) 
				+
			SUM(CASE WHEN (JogosUsuarios.ApostaTime1 = JogosUsuarios.ApostaTime2) THEN 1 ELSE 0 END) as Pontos,				
		   @CurrentLogin, @CurrentDateTime, @CurrentLogin, @CurrentDateTime, 1
	  FROM Jogos
	 INNER JOIN JogosUsuarios
		ON Jogos.JogoID			= JogosUsuarios.JogoID
	   AND Jogos.NomeCampeonato = JogosUsuarios.NomeCampeonato 
	 WHERE JogosUsuarios.NomeBolao	= @NomeBolao
	   AND JogosUsuarios.UserName	= @UserName
	   AND Jogos.NomeCampeonato		= @NomeCampeonato
	   AND Jogos.NomeGrupo			= @NomeGrupo
	   AND Jogos.NomeFase			= @NomeFase
	   AND 
		 (
			Jogos.NomeTime1			= @NomeTime
			OR
			Jogos.NomeTime2			= @NomeTime
		 )
	GROUP BY JogosUsuarios.NomeBolao, Jogos.NomeCampeonato, Jogos.NomeFase, Jogos.NomeGrupo, JogosUsuarios.UserName


	
	
	
	
	
	
	-- TODO: Verificar a inclusão de dados na tabela 	BoloesCampeonatosClassificacaoUsuarios
	-- Atualizando as posições das apostas dos usuários no grupo do time especificado
	UPDATE a
	   SET Posicao = newPos
	  FROM ( 
		select ROW_NUMBER() OVER(
			ORDER BY TotalPontos DESC, TotalGolsPro-TotalGolsContra DESC, TotalGolsPro DESC) as newPos,
			* 
	     from BoloesCampeonatosClassificacaoUsuarios 
	    where NomeCampeonato = @NomeCampeonato
		  AND NomeFase = @NomeFase
		  AND NomeGrupo = @NomeGrupo
		  AND NomeBolao = @NomeBolao
		  AND UserName = @UserName
		) a
	
	
	
	
	
	
	


	-- Verificando se terminou os jogos do grupo
	DECLARE @TotalJogos			int
	DECLARE @TotalRestante		int
	
	SELECT @TOtalJogos = COUNT(*), @TotalRestante = COUNT(JogosUsuarios.ApostaTime1)
	  FROM Jogos
	  LEFT JOIN JogosUsuarios
		ON Jogos.JogoID				= JogosUsuarios.JogoID
	   AND Jogos.NomeCampeonato		= JogosUsuarios.NomeCampeonato
	   AND JogosUsuarios.UserName	= @UserName
	   AND JogosUsuarios.ApostaTime1 IS NOT NULL
	   AND JogosUsuarios.ApostaTime2 IS NOT NULL
	 WHERE Jogos.NomeCampeonato		= @NomeCampeonato
	   AND Jogos.NomeFase			= @NomeFase
	   AND Jogos.NomeGrupo			= @NomeGrupo
	 GROUP BY Jogos.NomeCampeonato, Jogos.NomeFase, Jogos.NomeGrupo	


	-- Se terminou os jogos do grupo
	IF (@TotalJogos = @TotalRestante)
	BEGIN
	
		PRINT 'Terminou os jogos do grupo ' + @NomeGrupo
		
		EXEC sp_JogosUsuarios_Calcule_Grupo		@CurrentLogin,
												@CurrentDateTime,
												@NomeCampeonato,
												@NomeBolao,
												@UserName,
												@NomeFase,
												@NomeGrupo,
												@ErrorNumber,
												@ErrorDescription								
					
		SELECT 1
	END
	ELSE
	BEGIN
		SELECT 0	
	END --endif terminou os jogos do grupo




	RETURN @@RowCount	
END



GO
