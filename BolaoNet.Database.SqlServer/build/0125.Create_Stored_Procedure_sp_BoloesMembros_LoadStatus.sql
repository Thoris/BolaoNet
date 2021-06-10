IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_BoloesMembros_LoadStatus')
BEGIN
	DROP  Procedure  sp_BoloesMembros_LoadStatus
END
GO
CREATE PROCEDURE [dbo].[sp_BoloesMembros_LoadStatus]
(
    @CurrentLogin						varchar(25) = null,
	@CurrentDateTime					DateTime = null,
	@NomeBolao							varchar(30),
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL
	
	DECLARE @Nomecampeonato			varchar(50)
	DECLARE @TotalJogos				int
	DECLARE @TaxaParticipacao		decimal

	
	
	--Buscando o nome do campeonato
	SELECT	@Nomecampeonato		= Nomecampeonato,
			@TaxaParticipacao	= ISNULL(TaxaParticipacao, 0)
	  FROM Boloes
	 WHERE Nome = @NomeBolao
	
	-- Buscando a quantidade de jogos do campeonato
	SELECT @TotalJogos = ISNULL(Count(*),0) 
	  FROM Jogos
	 WHERE NomeCampeonato = @NomeCampeonato
	
	
	PRINT 'Taxa: ' + CONVERT(VARCHAR, @TaxaParticipacao)
	
	SELECT BoloesMembros.NomeBolao, BoloesMembros.UserName, Usuarios.FullName, Usuarios.Email,
		(
			SELECT @TotalJogos - ISNULL(COUNT(*),0) 
			  FROM JogosUsuarios
			 WHERE JogosUsuarios.NomeBolao		= @NomeBolao
			   AND JogosUsuarios.Nomecampeonato	= @NomeCampeonato
			   AND JogosUsuarios.UserName		= Usuarios.UserName
		) as 'Restantes',
		
		ISNULL(
			(
			SELECT @TaxaParticipacao - ISNULL(SUM(Pagamentos.Valor), 0)
			  FROM Pagamentos
			 WHERE Pagamentos.NomeBolao			= @NomeBolao
			   AND Pagamentos.UserName			= Usuarios.UserName
			 GROUP BY Pagamentos.NomeBolao, Pagamentos.UserName
			)
		, @TaxaParticipacao) as 'Pago'
		
		
	  FROM BoloesMembros
	 INNER JOIN Usuarios
	    ON BoloesMembros.UserName		= Usuarios.UserName
	 WHERE BoloesMembros.NomeBolao		= @NomeBolao
	 ORDER BY BoloesMembros.UserName
		
	
	
		
	RETURN @@RowCount	  	
	
	
END




GO
