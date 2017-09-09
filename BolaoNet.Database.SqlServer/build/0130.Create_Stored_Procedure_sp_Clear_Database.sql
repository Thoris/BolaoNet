IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_Clear_Database')
BEGIN
	DROP  Procedure  sp_Clear_Database
END
GO
CREATE PROCEDURE [dbo].[sp_Clear_Database]
AS
BEGIN

	DELETE FROM BoloesHistorico

	DELETE FROM ApostasExtrasUsuarios
	DELETE FROM ApostasExtras

	DELETE FROM BoloesCampeonatosClassificacaoUsuarios
	DELETE FROM BoloesCriteriosPontos
	DELETE FROM BoloesCriteriosPontosTimes

	DELETE FROM BoloesPontosRodadasUsuarios
	DELETE FROM BoloesPontosRodadas
	DELETE FROM BoloesMembrosPontos
	DELETE FROM BoloesPontuacao
	DELETE FROM BoloesPremios
	DELETE FROM BoloesRegras
	DELETE FROM BoloesRequests
	DELETE FROM BoloesRequestsStatus
	DELETE FROM BoloesMembrosClassificacao
	DELETE FROM BoloesMembrosGrupos


	DELETE FROM Pagamentos
	DELETE FROM PagamentosTipo	
	DBCC CHECKIDENT ('PagamentosTipo', RESEED, 0);

	DELETE FROM BoloesMembros

	DELETE FROM JogosUsuarios


	DELETE FROM Boloes

	DELETE FROM Jogos


	DELETE FROM CampeonatosClassificacao

	DELETE FROM CampeonatosPosicoes

	DELETE FROM CampeonatosGruposTimes
	DELETE FROM CampeonatosGrupos
	DELETE FROM CampeonatosFases
	DELETE FROM CampeonatosHistorico
	DELETE FROM CampeonatosPosicoes
	DELETE FROM CampeonatosTimes
	DELETE FROM CriteriosFixos
	--TRUNCATE TABLE CriteriosFixos
	DBCC CHECKIDENT ('CriteriosFixos', RESEED, 0);

	DELETE FROM Estadios

	DELETE FROM Campeonatos

	DELETE FROM Mensagens

	DELETE FROM Times
	DELETE FROM UserInRole
	DELETE FROM Usuarios

	DELETE FROM Roles



END