IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_Boloes_Aguardar')
BEGIN
	DROP  Procedure  sp_Boloes_Aguardar
END
GO
CREATE PROCEDURE [dbo].[sp_Boloes_Aguardar]
(
    @CurrentLogin						varchar(25),
	@CurrentDateTime					DateTime = null,
	@NomeBolao							varchar(30),
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	IF (@CurrentDateTime IS NULL)
		SET @CurrentDateTime = GetDate()

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL
	
	
	UPDATE Boloes
	   SET	ModifiedBy		= @CurrentLogin,
			ModifiedDate	= @CurrentDateTime,
			IsIniciado		= 0
	 WHERE Nome				= @NomeBolao
			

		
	RETURN @@RowCount	  	
	
	
END



GO
