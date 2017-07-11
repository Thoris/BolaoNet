IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_JogosUsuarios_Load_Acertos_Dificeis')
BEGIN
	DROP  Procedure  sp_JogosUsuarios_Load_Acertos_Dificeis
END
GO
CREATE PROCEDURE [dbo].[sp_JogosUsuarios_Load_Acertos_Dificeis]
(
    @CurrentLogin						varchar(25) = null,
	@CurrentDateTime					Datetime = null,
	@NomeBolao							varchar(30),
	@TotalAcertos						int,
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	
	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL	


	DECLARE @JOGOS AS TABLE
	(
		IdJogo			int, 
		NomeBolao		varchar(30),
		NomeCampeonato	varchar(50)
	)

	INSERT @JOGOS
	SELECT JogoId, NomeBolao, NomeCampeonato
	  FROM JogosUsuarios
	 WHERE NomeBolao = @NomeBolao
	   AND IsPlacarCheio = 1
	 GROUP BY JogoId, NomeBolao, NomeCampeonato
	HAVING COUNT(*) <= @TotalAcertos


	SELECT	jog.NomeCampeonato, 
			jog.JogoId,
			jog.NomeTime1, 
			jog.GolsTime1,
			jog.PenaltisTime1,
			jog.NomeTime2, 
			jog.GolsTime2,
			jog.PenaltisTime2,
			jog.NomeEstadio,
			jog.DataJogo,
			jog.Rodada,
			jog.PartidaValida,
			jog.DataValidacao,
			jog.NomeFase,
			jog.NomeGrupo,
			jog.IsValido,
			jog.ValidadoBy,

			usu.UserName,
			usu.DataAposta,
			usu.Automatico,
			usu.ApostaTime1,
			usu.ApostaTime2,
			usu.ApostaPenaltis1,
			usu.ApostaPenaltis2,
			usu.Valido,
			usu.NomeTimeResult1,
			usu.NomeTimeResult2,
			usu.Pontos,
			usu.IsEmpate,
			usu.IsDerrota,
			usu.IsVitoria,
			usu.IsGolsGanhador,
			usu.IsGolsPerdedor,
			usu.IsResultTime1,
			usu.IsResultTime2,
			usu.IsVDE,
			usu.IsErro,
			usu.IsGolsGanhadorFora,
			usu.IsGolsGanhadorDentro,
			usu.IsGolsPerdedorFora,
			usu.IsGolsPerdedorDentro,
			usu.IsGolsEmpate,
			usu.IsGolsTime1,
			usu.IsGolsTime2,
			usu.IsPlacarCheio,
			usu.IsMultiploTime,
			usu.MultiploTime,
			usu.Ganhador,
			jog.DescricaoTime1,
			jog.DescricaoTime2
	  FROM @JOGOS aux
	 INNER JOIN JogosUsuarios usu
		ON usu.NomeBolao		= aux.NomeBolao
	   AND usu.NomeCampeonato	= aux.NomeCampeonato
	   AND usu.JogoID			= aux.IdJogo
	   AND usu.IsPlacarCheio	= 1
	 INNER JOIN Jogos jog
		ON usu.NomeCampeonato	= jog.NomeCampeonato
	   AND usu.JogoID			= jog.JogoId
	 ORDER BY jog.Rodada, jog.JogoId


	 

	RETURN @@RowCount

END



GO
