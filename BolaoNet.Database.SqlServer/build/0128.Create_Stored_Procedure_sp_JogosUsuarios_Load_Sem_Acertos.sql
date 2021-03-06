﻿IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_JogosUsuarios_Load_Sem_Acertos')
BEGIN
	DROP  Procedure  sp_JogosUsuarios_Load_Sem_Acertos
END
GO
CREATE PROCEDURE [dbo].[sp_JogosUsuarios_Load_Sem_Acertos]
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

	SELECT *
  FROM Jogos j
	 INNER JOIN CampeonatosFases fas
	    ON j.NomeFase			= fas.Nome
	 INNER JOIN CampeonatosGrupos grp
	    ON j.NomeGrupo		= grp.Nome

 WHERE j.IsValido		= 1
   AND 0 = (
			SELECT ISNULL(Count(*), 0) 
			  FROM JogosUsuarios u
			 WHERE u.NomeCampeonato		= j.NomeCampeonato
			   AND u.JogoId				= j.JogoId
			   AND u.IsPlacarCheio		= 1
			   AND u.NomeBolao			= @NomeBolao
			)
			
	ORDER BY fas.Ordem, grp.ordem, Rodada, DataJogo



	RETURN @@RowCount

END



GO
