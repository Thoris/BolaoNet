IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_Campeonatos_Reiniciar')
BEGIN
	DROP  Procedure  sp_Campeonatos_Reiniciar
END
GO
CREATE PROCEDURE [dbo].[sp_Campeonatos_Reiniciar]
(
    @CurrentLogin						varchar(25) = null,
	@CurrentDateTime					DateTime = null,
	@NomeCampeonato						varchar(30),
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	


	UPDATE a
	   SET a.IsValido = 0,
		   a.DataValidacao = null, 
		   a.NomeTimeValidado = null
	  FROM ApostasExtras a
	 INNER JOIN Boloes b
	    ON a.NomeBolao = b.Nome
     WHERE b.NomeCampeonato = @NomeCampeonato

	--SELECT * FROM ApostasExtras
	
	UPDATE a
	   SET a.IsApostaValida = 0,
		   a.Pontos = 0 
	  FROM ApostasExtrasUsuarios a
	 INNER JOIN Boloes b
	    ON a.NomeBolao = b.Nome
     WHERE b.NomeCampeonato = @NomeCampeonato

	--SELECT * FROM ApostasExtrasUsuarios

	DELETE a	  
	  FROM BoloesCampeonatosClassificacaoUsuarios a
	 INNER JOIN Boloes b
	    ON a.NomeBolao = b.Nome
     WHERE b.NomeCampeonato = @NomeCampeonato

	--SELECT * FROM BoloesCampeonatosClassificacaoUsuarios

	-- ?? UPDATE ???
	DELETE a	  
	  FROM BoloesMembrosClassificacao a
	 INNER JOIN Boloes b
	    ON a.NomeBolao = b.Nome
     WHERE b.NomeCampeonato = @NomeCampeonato

	--SELECT * FROM BoloesMembrosClassificacao

	DELETE a	  
	  FROM BoloesMembrosPontos a
	 INNER JOIN Boloes b
	    ON a.NomeBolao = b.Nome
     WHERE b.NomeCampeonato = @NomeCampeonato

	--SELECT * FROM BoloesMembrosPontos


	--SELECT * FROM BoloesPontosRodadas
	--SELECT * FROM BoloesPontosRodadasUsuarios
	
	 DELETE a	  
	  FROM CampeonatosClassificacao a
     WHERE a.NomeCampeonato = @NomeCampeonato
		
	--SELECT * FROM CampeonatosClassificacao

     UPDATE a
	   SET a.PenaltisTime1 = null,
		   a.PenaltisTime2 = null,
		   a.PartidaValida = 0,
		   a.DataValidacao = null,
		   a.IsValido = 0,
		   a.ValidadoBy = null,
		   a.NomeTime1 = CASE WHEN a.DescricaoTime1 IS NULL THEN a.NomeTime1 ELSE NULL  END,
		   a.NomeTime2 = CASE WHEN a.DescricaoTime2 IS NULL THEN a.NomeTime2 ELSE NULL  END
	  FROM Jogos a
     WHERE a.NomeCampeonato = @NomeCampeonato

	--SELECT * FROM Jogos


	 UPDATE a
	   SET a.Valido = 0,
		   a.Pontos = 0,
		   a.IsEmpate = 0,
		   a.IsDerrota = 0,
		   a.IsVitoria = 0,
		   a.IsGolsGanhador = 0,
		   a.IsGolsPerdedor = 0,
		   a.IsResultTime1 = 0,
		   a.IsResultTime2 = 0,
		   a.IsVDE = 0, 
		   a.IsErro = 0,
		   a.IsGolsGanhadorFora = 0,
		   a.IsGolsGanhadorDentro = 0,
		   a.IsGolsPerdedorFora = 0,
		   a.IsGolsPerdedorDentro = 0,
		   a.IsGolsEmpate = 0,
		   a.IsGolsTime1 = 0,
		   a.isgolstime2 = 0,
		   a.IsPlacarCheio = 0,
		   a.IsMultiploTime = 0,
		   a.MultiploTime = 0,
		   a.Ganhador = 0
	  FROM JogosUsuarios a
	 INNER JOIN Boloes b
	    ON a.NomeBolao = b.Nome
     WHERE b.NomeCampeonato = @NomeCampeonato
	 
	--	SELECT * FROM JogosUsuarios



	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL	


END

GO