﻿DECLARE @ErrorNumber int
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

		
EXEC	sp_Jogos_ResultInsert 
		@CurrentLogin = @ValidadoBy,
		@CurrentDateTime = NULL,
		@IdJogo = 33,
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
		@IdJogo = 34,
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
		@IdJogo = 35,
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
		@IdJogo = 36,
		@NomeCampeonato = @NomeCampeonato,
		@Gols1 = 2,
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
		@IdJogo = 37,
		@NomeCampeonato = @NomeCampeonato,
		@Gols1 = 0,
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
		@IdJogo = 38,
		@NomeCampeonato = @NomeCampeonato,
		@Gols1 = 0,
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
		@IdJogo = 39,
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
		@IdJogo = 40,
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
		@IdJogo = 41,
		@NomeCampeonato = @NomeCampeonato,
		@Gols1 = 0,
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
		@IdJogo = 42,
		@NomeCampeonato = @NomeCampeonato,
		@Gols1 = 2,
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
		@IdJogo = 43,
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
		@IdJogo = 47,
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
		@IdJogo = 48,
		@NomeCampeonato = @NomeCampeonato,
		@Gols1 = 0,
		@Penaltis1 = NULL,
		@Gols2 = 1,
		@Penaltis2 = NULL,
		@SetCurrentData = 1,
		@ValidadoBy = @ValidadoBy,
		@ErrorNumber = @ErrorNumber OUTPUT,
		@ErrorDescription = @ErrorDescription OUTPUT
		
update jogos set nometime2 = 'Japão' where jogoid = 54
		
EXEC	sp_Jogos_ResultInsert 
		@CurrentLogin = @ValidadoBy,
		@CurrentDateTime = NULL,
		@IdJogo = 49,
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
		@IdJogo = 50,
		@NomeCampeonato = @NomeCampeonato,
		@Gols1 = 4,
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
		@IdJogo = 51,
		@NomeCampeonato = @NomeCampeonato,
		@Gols1 = 1,
		@Penaltis1 = 2,
		@Gols2 = 1,
		@Penaltis2 = 3,
		@SetCurrentData = 1,
		@ValidadoBy = @ValidadoBy,
		@ErrorNumber = @ErrorNumber OUTPUT,
		@ErrorDescription = @ErrorDescription OUTPUT

		
EXEC	sp_Jogos_ResultInsert 
		@CurrentLogin = @ValidadoBy,
		@CurrentDateTime = NULL,
		@IdJogo = 52,
		@NomeCampeonato = @NomeCampeonato,
		@Gols1 = 1,
		@Penaltis1 = 3,
		@Gols2 = 1,
		@Penaltis2 = 2,
		@SetCurrentData = 1,
		@ValidadoBy = @ValidadoBy,
		@ErrorNumber = @ErrorNumber OUTPUT,
		@ErrorDescription = @ErrorDescription OUTPUT
		
EXEC	sp_Jogos_ResultInsert 
		@CurrentLogin = @ValidadoBy,
		@CurrentDateTime = NULL,
		@IdJogo = 53,
		@NomeCampeonato = @NomeCampeonato,
		@Gols1 = 2,
		@Penaltis1 = null,
		@Gols2 = 0,
		@Penaltis2 = null,
		@SetCurrentData = 1,
		@ValidadoBy = @ValidadoBy,
		@ErrorNumber = @ErrorNumber OUTPUT,
		@ErrorDescription = @ErrorDescription OUTPUT
		
EXEC	sp_Jogos_ResultInsert 
		@CurrentLogin = @ValidadoBy,
		@CurrentDateTime = NULL,
		@IdJogo = 54,
		@NomeCampeonato = @NomeCampeonato,
		@Gols1 = 3,
		@Penaltis1 = null,
		@Gols2 = 2,
		@Penaltis2 = null,
		@SetCurrentData = 1,
		@ValidadoBy = @ValidadoBy,
		@ErrorNumber = @ErrorNumber OUTPUT,
		@ErrorDescription = @ErrorDescription OUTPUT

		
EXEC	sp_Jogos_ResultInsert 
		@CurrentLogin = @ValidadoBy,
		@CurrentDateTime = NULL,
		@IdJogo = 55,
		@NomeCampeonato = @NomeCampeonato,
		@Gols1 = 1,
		@Penaltis1 = null,
		@Gols2 = 0,
		@Penaltis2 = null,
		@SetCurrentData = 1,
		@ValidadoBy = @ValidadoBy,
		@ErrorNumber = @ErrorNumber OUTPUT,
		@ErrorDescription = @ErrorDescription OUTPUT

		
EXEC	sp_Jogos_ResultInsert 
		@CurrentLogin = @ValidadoBy,
		@CurrentDateTime = NULL,
		@IdJogo = 53,
		@NomeCampeonato = @NomeCampeonato,
		@Gols1 = 1,
		@Penaltis1 = 2,
		@Gols2 = 1,
		@Penaltis2 = 3,
		@SetCurrentData = 1,
		@ValidadoBy = @ValidadoBy,
		@ErrorNumber = @ErrorNumber OUTPUT,
		@ErrorDescription = @ErrorDescription OUTPUT

		
EXEC	sp_Jogos_ResultInsert 
		@CurrentLogin = @ValidadoBy,
		@CurrentDateTime = NULL,
		@IdJogo = 54,
		@NomeCampeonato = @NomeCampeonato,
		@Gols1 = 3,
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
		@IdJogo = 55,
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
		@IdJogo = 56,
		@NomeCampeonato = @NomeCampeonato,
		@Gols1 = 1,
		@Penaltis1 = 2,
		@Gols2 = 1,
		@Penaltis2 = 3,
		@SetCurrentData = 1,
		@ValidadoBy = @ValidadoBy,
		@ErrorNumber = @ErrorNumber OUTPUT,
		@ErrorDescription = @ErrorDescription OUTPUT

EXEC	sp_Jogos_ResultInsert 
		@CurrentLogin = @ValidadoBy,
		@CurrentDateTime = NULL,
		@IdJogo = 57,
		@NomeCampeonato = @NomeCampeonato,
		@Gols1 = 0,
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
		@IdJogo = 58,
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
		@IdJogo = 59,
		@NomeCampeonato = @NomeCampeonato,
		@Gols1 = 1,
		@Penaltis1 = 2,
		@Gols2 = 1,
		@Penaltis2 = 3,
		@SetCurrentData = 1,
		@ValidadoBy = @ValidadoBy,
		@ErrorNumber = @ErrorNumber OUTPUT,
		@ErrorDescription = @ErrorDescription OUTPUT

		
EXEC	sp_Jogos_ResultInsert 
		@CurrentLogin = @ValidadoBy,
		@CurrentDateTime = NULL,
		@IdJogo = 60,
		@NomeCampeonato = @NomeCampeonato,
		@Gols1 = 0,
		@Penaltis1 = NULL,
		@Gols2 = 2,
		@Penaltis2 = NULL,
		@SetCurrentData = 1,
		@ValidadoBy = @ValidadoBy,
		@ErrorNumber = @ErrorNumber OUTPUT,
		@ErrorDescription = @ErrorDescription OUTPUT
