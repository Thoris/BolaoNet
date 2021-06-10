IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_CampeonatosClassificacao_LoadClassificacao')
BEGIN
	DROP  Procedure  sp_CampeonatosClassificacao_LoadClassificacao
END
GO

CREATE PROCEDURE [dbo].[sp_CampeonatosClassificacao_LoadClassificacao]
(
    @CurrentLogin						varchar(25),
	@CurrentDateTime					DateTime = null,
	@NomeCampeonato						varchar(50),
	@NomeFase							varchar(30),
	@NomeGrupo							varchar(20) = NULL,
	@Rodada								int = 0,
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN


	DECLARE @MaxRodada			int


	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL


	IF (@Rodada = 0)
	BEGIN
		SELECT @Rodada = Max(Rodada)
		  FROM CampeonatosClassificacao l
		 WHERE l.NomeCampeonato		= @NomeCampeonato
		   AND l.NomeGrupo			= @NomeGrupo
		   AND l.NomeFase			= @NomeFase		   
	END

	PRINT 'Buscando dados da rodada ' + CONVERT(VARCHAR, @Rodada)


	SELECT t.NomeCampeonato, c.NomeFase, t.NomeGrupo, t.NomeTime,
		0 as 'Rodada', 	
	    (
			SELECT Posicao 
			  FROM CampeonatosClassificacao l
			 WHERE l.NomeCampeonato		= @NomeCampeonato
			   AND l.NomeGrupo			= @NomeGrupo
			   AND l.NomeFase			= @NomeFase
			   AND l.NomeTime			= t.NomeTime
			   AND l.Rodada				= @Rodada					   
		) as 'Posicao',
		(
			SELECT LastPosicao 
			  FROM CampeonatosClassificacao l
			 WHERE l.NomeCampeonato		= @NomeCampeonato
			   AND l.NomeGrupo			= @NomeGrupo
			   AND l.NomeFase			= @NomeFase
			   AND l.NomeTime			= t.NomeTime
			   AND l.Rodada				= @Rodada					   
		) as 'LastPosicao',
		SUM(c.TotalVitorias) as 'TotalVitorias', SUM(c.TotalDerrotas) as 'TotalDerrotas', SUM(c.TotalEmpates) as 'TotalEmpates', 
		SUM(c.TotalGolsContra) as 'TotalGolsContra', SUM(c.TotalGolsPro) as 'TotalGolsPro', SUM(c.TotalPontos) as 'TotalPontos',
		SUM(c.TotalVitorias) + SUM(c.Totalempates) + SUM(c.TotalDerrotas) as 'Jogos',
		SUM(c.TotalGolsPro) - SUM(c.TotalGolsContra) as 'Saldo',
		null as 'CreatedBy', 
		null as 'CreatedDate',
		null as 'ModifiedBy', 
		null as 'ModifiedDate',
		null as 'ActiveFlag'
		
	  FROM CampeonatosGruposTimes t
	 LEfT JOIN CampeonatosClassificacao c
		ON c.Nomecampeonato			= t.NomeCampeonato
	   AND c.NomeTime				= t.NomeTime
	   AND c.NomeGrupo				= t.Nomegrupo
	   AND c.NomeFase				= @NomeFase
	 WHERE t.NomeCampeonato			= @NomeCampeonato
	   AND t.NomeGrupo				= @NomeGrupo
	   
	 GROUP BY t.NomeCampeonato, c.NomeFase, t.NomeGrupo, t.NomeTime
	 ORDER BY t.NomeCampeonato, c.NomeFase, t.NomeGrupo,
				(
 				SELECT Posicao 
				  FROM CampeonatosClassificacao l
				 WHERE l.NomeCampeonato		= @NomeCampeonato
				   AND l.NomeGrupo			= @NomeGrupo
				   AND l.NomeFase			= @NomeFase
				   AND l.NomeTime			= t.NomeTime
				   AND l.Rodada				= @Rodada					  		
				)
				, SUM(c.TotalPontos) DESC
		
	RETURN @@RowCount	  	
	
		
	
	
END
GO 



