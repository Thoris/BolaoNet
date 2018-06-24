DECLARE @ErrorNumber int
DECLARE @ErrorDescription VARCHAR(4000)
DECLARE @NomeCampeonato VARCHAR(100)
DECLARE @ValidadoBy VARCHAR(50)

SET @NomeCampeonato = 'Copa do Mundo 2018'
SET @ValidadoBy = 'thoris'

EXEC	sp_Jogos_ResultInsert 
		@CurrentLogin = @ValidadoBy,
		@CurrentDateTime = NULL,
		@IdJogo = 1,
		@NomeCampeonato = @NomeCampeonato,
		@Gols1 = 5,
		@Penaltis1 = NULL,
		@Gols2 = 0,
		@Penaltis2 = NULL,
		@SetCurrentData = 1,
		@ValidadoBy = @ValidadoBy,
		@ErrorNumber = @ErrorNumber OUTPUT,
		@ErrorDescription = @ErrorDescription OUTPUT
		
EXEC	sp_Jogos_ResultInsert 
		@CurrentLogin = @ValidadoBy,
		@CurrentDateTime = NULL,
		@IdJogo = 2,
		@NomeCampeonato = @NomeCampeonato,
		@Gols1 = 0,
		@Penaltis1 = NULL,
		@Gols2 = 1,
		@Penaltis2 = NULL,
		@SetCurrentData = 1,
		@ValidadoBy = @ValidadoBy,
		@ErrorNumber = @ErrorNumber OUTPUT,
		@ErrorDescription = @ErrorDescription OUTPUT

EXEC	sp_Jogos_ResultInsert 
		@CurrentLogin = @ValidadoBy,
		@CurrentDateTime = NULL,
		@IdJogo = 3,
		@NomeCampeonato = @NomeCampeonato,
		@Gols1 = 3,
		@Penaltis1 = NULL,
		@Gols2 = 3,
		@Penaltis2 = NULL,
		@SetCurrentData = 1,
		@ValidadoBy = @ValidadoBy,
		@ErrorNumber = @ErrorNumber OUTPUT,
		@ErrorDescription = @ErrorDescription OUTPUT

EXEC	sp_Jogos_ResultInsert 
		@CurrentLogin = @ValidadoBy,
		@CurrentDateTime = NULL,
		@IdJogo = 4,
		@NomeCampeonato = @NomeCampeonato,
		@Gols1 = 0,
		@Penaltis1 = NULL,
		@Gols2 = 1,
		@Penaltis2 = NULL,
		@SetCurrentData = 1,
		@ValidadoBy = @ValidadoBy,
		@ErrorNumber = @ErrorNumber OUTPUT,
		@ErrorDescription = @ErrorDescription OUTPUT
		
EXEC	sp_Jogos_ResultInsert 
		@CurrentLogin = @ValidadoBy,
		@CurrentDateTime = NULL,
		@IdJogo = 5,
		@NomeCampeonato = @NomeCampeonato,
		@Gols1 = 2,
		@Penaltis1 = NULL,
		@Gols2 = 1,
		@Penaltis2 = NULL,
		@SetCurrentData = 1,
		@ValidadoBy = @ValidadoBy,
		@ErrorNumber = @ErrorNumber OUTPUT,
		@ErrorDescription = @ErrorDescription OUTPUT

EXEC	sp_Jogos_ResultInsert 
		@CurrentLogin = @ValidadoBy,
		@CurrentDateTime = NULL,
		@IdJogo = 6,
		@NomeCampeonato = @NomeCampeonato,
		@Gols1 = 0,
		@Penaltis1 = NULL,
		@Gols2 = 1,
		@Penaltis2 = NULL,
		@SetCurrentData = 1,
		@ValidadoBy = @ValidadoBy,
		@ErrorNumber = @ErrorNumber OUTPUT,
		@ErrorDescription = @ErrorDescription OUTPUT

EXEC	sp_Jogos_ResultInsert 
		@CurrentLogin = @ValidadoBy,
		@CurrentDateTime = NULL,
		@IdJogo = 7,
		@NomeCampeonato = @NomeCampeonato,
		@Gols1 = 1,
		@Penaltis1 = NULL,
		@Gols2 = 1,
		@Penaltis2 = NULL,
		@SetCurrentData = 1,
		@ValidadoBy = @ValidadoBy,
		@ErrorNumber = @ErrorNumber OUTPUT,
		@ErrorDescription = @ErrorDescription OUTPUT

EXEC	sp_Jogos_ResultInsert 
		@CurrentLogin = @ValidadoBy,
		@CurrentDateTime = NULL,
		@IdJogo = 8,
		@NomeCampeonato = @NomeCampeonato,
		@Gols1 = 2,
		@Penaltis1 = NULL,
		@Gols2 = 0,
		@Penaltis2 = NULL,
		@SetCurrentData = 1,
		@ValidadoBy = @ValidadoBy,
		@ErrorNumber = @ErrorNumber OUTPUT,
		@ErrorDescription = @ErrorDescription OUTPUT

EXEC	sp_Jogos_ResultInsert 
		@CurrentLogin = @ValidadoBy,
		@CurrentDateTime = NULL,
		@IdJogo = 9,
		@NomeCampeonato = @NomeCampeonato,
		@Gols1 = 1,
		@Penaltis1 = NULL,
		@Gols2 = 1,
		@Penaltis2 = NULL,
		@SetCurrentData = 1,
		@ValidadoBy = @ValidadoBy,
		@ErrorNumber = @ErrorNumber OUTPUT,
		@ErrorDescription = @ErrorDescription OUTPUT

EXEC	sp_Jogos_ResultInsert 
		@CurrentLogin = @ValidadoBy,
		@CurrentDateTime = NULL,
		@IdJogo = 10,
		@NomeCampeonato = @NomeCampeonato,
		@Gols1 = 0,
		@Penaltis1 = NULL,
		@Gols2 = 1,
		@Penaltis2 = NULL,
		@SetCurrentData = 1,
		@ValidadoBy = @ValidadoBy,
		@ErrorNumber = @ErrorNumber OUTPUT,
		@ErrorDescription = @ErrorDescription OUTPUT

EXEC	sp_Jogos_ResultInsert 
		@CurrentLogin = @ValidadoBy,
		@CurrentDateTime = NULL,
		@IdJogo = 11,
		@NomeCampeonato = @NomeCampeonato,
		@Gols1 = 0,
		@Penaltis1 = NULL,
		@Gols2 = 1,
		@Penaltis2 = NULL,
		@SetCurrentData = 1,
		@ValidadoBy = @ValidadoBy,
		@ErrorNumber = @ErrorNumber OUTPUT,
		@ErrorDescription = @ErrorDescription OUTPUT

EXEC	sp_Jogos_ResultInsert 
		@CurrentLogin = @ValidadoBy,
		@CurrentDateTime = NULL,
		@IdJogo = 12,
		@NomeCampeonato = @NomeCampeonato,
		@Gols1 = 1,
		@Penaltis1 = NULL,
		@Gols2 = 0,
		@Penaltis2 = NULL,
		@SetCurrentData = 1,
		@ValidadoBy = @ValidadoBy,
		@ErrorNumber = @ErrorNumber OUTPUT,
		@ErrorDescription = @ErrorDescription OUTPUT

EXEC	sp_Jogos_ResultInsert 
		@CurrentLogin = @ValidadoBy,
		@CurrentDateTime = NULL,
		@IdJogo = 13,
		@NomeCampeonato = @NomeCampeonato,
		@Gols1 = 3,
		@Penaltis1 = NULL,
		@Gols2 = 0,
		@Penaltis2 = NULL,
		@SetCurrentData = 1,
		@ValidadoBy = @ValidadoBy,
		@ErrorNumber = @ErrorNumber OUTPUT,
		@ErrorDescription = @ErrorDescription OUTPUT

EXEC	sp_Jogos_ResultInsert 
		@CurrentLogin = @ValidadoBy,
		@CurrentDateTime = NULL,
		@IdJogo = 14,
		@NomeCampeonato = @NomeCampeonato,
		@Gols1 = 1,
		@Penaltis1 = NULL,
		@Gols2 = 2,
		@Penaltis2 = NULL,
		@SetCurrentData = 1,
		@ValidadoBy = @ValidadoBy,
		@ErrorNumber = @ErrorNumber OUTPUT,
		@ErrorDescription = @ErrorDescription OUTPUT

EXEC	sp_Jogos_ResultInsert 
		@CurrentLogin = @ValidadoBy,
		@CurrentDateTime = NULL,
		@IdJogo = 15,
		@NomeCampeonato = @NomeCampeonato,
		@Gols1 = 1,
		@Penaltis1 = NULL,
		@Gols2 = 2,
		@Penaltis2 = NULL,
		@SetCurrentData = 1,
		@ValidadoBy = @ValidadoBy,
		@ErrorNumber = @ErrorNumber OUTPUT,
		@ErrorDescription = @ErrorDescription OUTPUT

EXEC	sp_Jogos_ResultInsert 
		@CurrentLogin = @ValidadoBy,
		@CurrentDateTime = NULL,
		@IdJogo = 16,
		@NomeCampeonato = @NomeCampeonato,
		@Gols1 = 1,
		@Penaltis1 = NULL,
		@Gols2 = 2,
		@Penaltis2 = NULL,
		@SetCurrentData = 1,
		@ValidadoBy = @ValidadoBy,
		@ErrorNumber = @ErrorNumber OUTPUT,
		@ErrorDescription = @ErrorDescription OUTPUT
		
EXEC	sp_Jogos_ResultInsert 
		@CurrentLogin = @ValidadoBy,
		@CurrentDateTime = NULL,
		@IdJogo = 17,
		@NomeCampeonato = @NomeCampeonato,
		@Gols1 = 3,
		@Penaltis1 = NULL,
		@Gols2 = 1,
		@Penaltis2 = NULL,
		@SetCurrentData = 1,
		@ValidadoBy = @ValidadoBy,
		@ErrorNumber = @ErrorNumber OUTPUT,
		@ErrorDescription = @ErrorDescription OUTPUT
		
EXEC	sp_Jogos_ResultInsert 
		@CurrentLogin = @ValidadoBy,
		@CurrentDateTime = NULL,
		@IdJogo = 18,
		@NomeCampeonato = @NomeCampeonato,
		@Gols1 = 1,
		@Penaltis1 = NULL,
		@Gols2 = 0,
		@Penaltis2 = NULL,
		@SetCurrentData = 1,
		@ValidadoBy = @ValidadoBy,
		@ErrorNumber = @ErrorNumber OUTPUT,
		@ErrorDescription = @ErrorDescription OUTPUT
		
EXEC	sp_Jogos_ResultInsert 
		@CurrentLogin = @ValidadoBy,
		@CurrentDateTime = NULL,
		@IdJogo = 19,
		@NomeCampeonato = @NomeCampeonato,
		@Gols1 = 1,
		@Penaltis1 = NULL,
		@Gols2 = 0,
		@Penaltis2 = NULL,
		@SetCurrentData = 1,
		@ValidadoBy = @ValidadoBy,
		@ErrorNumber = @ErrorNumber OUTPUT,
		@ErrorDescription = @ErrorDescription OUTPUT
		
EXEC	sp_Jogos_ResultInsert 
		@CurrentLogin = @ValidadoBy,
		@CurrentDateTime = NULL,
		@IdJogo = 20,
		@NomeCampeonato = @NomeCampeonato,
		@Gols1 = 0,
		@Penaltis1 = NULL,
		@Gols2 = 1,
		@Penaltis2 = NULL,
		@SetCurrentData = 1,
		@ValidadoBy = @ValidadoBy,
		@ErrorNumber = @ErrorNumber OUTPUT,
		@ErrorDescription = @ErrorDescription OUTPUT

EXEC	sp_Jogos_ResultInsert 
		@CurrentLogin = @ValidadoBy,
		@CurrentDateTime = NULL,
		@IdJogo = 21,
		@NomeCampeonato = @NomeCampeonato,
		@Gols1 = 1,
		@Penaltis1 = NULL,
		@Gols2 = 0,
		@Penaltis2 = NULL,
		@SetCurrentData = 1,
		@ValidadoBy = @ValidadoBy,
		@ErrorNumber = @ErrorNumber OUTPUT,
		@ErrorDescription = @ErrorDescription OUTPUT

EXEC	sp_Jogos_ResultInsert 
		@CurrentLogin = @ValidadoBy,
		@CurrentDateTime = NULL,
		@IdJogo = 22,
		@NomeCampeonato = @NomeCampeonato,
		@Gols1 = 1,
		@Penaltis1 = NULL,
		@Gols2 = 1,
		@Penaltis2 = NULL,
		@SetCurrentData = 1,
		@ValidadoBy = @ValidadoBy,
		@ErrorNumber = @ErrorNumber OUTPUT,
		@ErrorDescription = @ErrorDescription OUTPUT
	
EXEC	sp_Jogos_ResultInsert 
		@CurrentLogin = @ValidadoBy,
		@CurrentDateTime = NULL,
		@IdJogo = 23,
		@NomeCampeonato = @NomeCampeonato,
		@Gols1 = 0,
		@Penaltis1 = NULL,
		@Gols2 = 3,
		@Penaltis2 = NULL,
		@SetCurrentData = 1,
		@ValidadoBy = @ValidadoBy,
		@ErrorNumber = @ErrorNumber OUTPUT,
		@ErrorDescription = @ErrorDescription OUTPUT
	
EXEC	sp_Jogos_ResultInsert 
		@CurrentLogin = @ValidadoBy,
		@CurrentDateTime = NULL,
		@IdJogo = 24,
		@NomeCampeonato = @NomeCampeonato,
		@Gols1 = 2,
		@Penaltis1 = NULL,
		@Gols2 = 0,
		@Penaltis2 = NULL,
		@SetCurrentData = 1,
		@ValidadoBy = @ValidadoBy,
		@ErrorNumber = @ErrorNumber OUTPUT,
		@ErrorDescription = @ErrorDescription OUTPUT
			
EXEC	sp_Jogos_ResultInsert 
		@CurrentLogin = @ValidadoBy,
		@CurrentDateTime = NULL,
		@IdJogo = 25,
		@NomeCampeonato = @NomeCampeonato,
		@Gols1 = 2,
		@Penaltis1 = NULL,
		@Gols2 = 0,
		@Penaltis2 = NULL,
		@SetCurrentData = 1,
		@ValidadoBy = @ValidadoBy,
		@ErrorNumber = @ErrorNumber OUTPUT,
		@ErrorDescription = @ErrorDescription OUTPUT
	
EXEC	sp_Jogos_ResultInsert 
		@CurrentLogin = @ValidadoBy,
		@CurrentDateTime = NULL,
		@IdJogo = 26,
		@NomeCampeonato = @NomeCampeonato,
		@Gols1 = 1,
		@Penaltis1 = NULL,
		@Gols2 = 2,
		@Penaltis2 = NULL,
		@SetCurrentData = 1,
		@ValidadoBy = @ValidadoBy,
		@ErrorNumber = @ErrorNumber OUTPUT,
		@ErrorDescription = @ErrorDescription OUTPUT
		
		
EXEC	sp_Jogos_ResultInsert 
		@CurrentLogin = @ValidadoBy,
		@CurrentDateTime = NULL,
		@IdJogo = 27,
		@NomeCampeonato = @NomeCampeonato,
		@Gols1 = 2,
		@Penaltis1 = NULL,
		@Gols2 = 1,
		@Penaltis2 = NULL,
		@SetCurrentData = 1,
		@ValidadoBy = @ValidadoBy,
		@ErrorNumber = @ErrorNumber OUTPUT,
		@ErrorDescription = @ErrorDescription OUTPUT

EXEC	sp_Jogos_ResultInsert 
		@CurrentLogin = @ValidadoBy,
		@CurrentDateTime = NULL,
		@IdJogo = 28,
		@NomeCampeonato = @NomeCampeonato,
		@Gols1 = 1,
		@Penaltis1 = NULL,
		@Gols2 = 2,
		@Penaltis2 = NULL,
		@SetCurrentData = 1,
		@ValidadoBy = @ValidadoBy,
		@ErrorNumber = @ErrorNumber OUTPUT,
		@ErrorDescription = @ErrorDescription OUTPUT
		
EXEC	sp_Jogos_ResultInsert 
		@CurrentLogin = @ValidadoBy,
		@CurrentDateTime = NULL,
		@IdJogo = 29,
		@NomeCampeonato = @NomeCampeonato,
		@Gols1 = 5,
		@Penaltis1 = NULL,
		@Gols2 = 2,
		@Penaltis2 = NULL,
		@SetCurrentData = 1,
		@ValidadoBy = @ValidadoBy,
		@ErrorNumber = @ErrorNumber OUTPUT,
		@ErrorDescription = @ErrorDescription OUTPUT

		
EXEC	sp_Jogos_ResultInsert 
		@CurrentLogin = @ValidadoBy,
		@CurrentDateTime = NULL,
		@IdJogo = 30,
		@NomeCampeonato = @NomeCampeonato,
		@Gols1 = 6,
		@Penaltis1 = NULL,
		@Gols2 = 1,
		@Penaltis2 = NULL,
		@SetCurrentData = 1,
		@ValidadoBy = @ValidadoBy,
		@ErrorNumber = @ErrorNumber OUTPUT,
		@ErrorDescription = @ErrorDescription OUTPUT


		 
EXEC	sp_Jogos_ResultInsert 
		@CurrentLogin = @ValidadoBy,
		@CurrentDateTime = NULL,
		@IdJogo = 31,
		@NomeCampeonato = @NomeCampeonato,
		@Gols1 = 0,
		@Penaltis1 = NULL,
		@Gols2 = 3,
		@Penaltis2 = NULL,
		@SetCurrentData = 1,
		@ValidadoBy = @ValidadoBy,
		@ErrorNumber = @ErrorNumber OUTPUT,
		@ErrorDescription = @ErrorDescription OUTPUT

		
EXEC	sp_Jogos_ResultInsert 
		@CurrentLogin = @ValidadoBy,
		@CurrentDateTime = NULL,
		@IdJogo = 32,
		@NomeCampeonato = @NomeCampeonato,
		@Gols1 = 2,
		@Penaltis1 = NULL,
		@Gols2 = 2,
		@Penaltis2 = NULL,
		@SetCurrentData = 1,
		@ValidadoBy = @ValidadoBy,
		@ErrorNumber = @ErrorNumber OUTPUT,
		@ErrorDescription = @ErrorDescription OUTPUT
