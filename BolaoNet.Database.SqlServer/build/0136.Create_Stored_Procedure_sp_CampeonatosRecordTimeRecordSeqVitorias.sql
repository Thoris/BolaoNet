﻿IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_CampeonatosRecordTimeRecordSeqVitorias')
BEGIN
	DROP  Procedure  sp_CampeonatosRecordTimeRecordSeqVitorias
END
GO
CREATE PROCEDURE [dbo].[sp_CampeonatosRecordTimeRecordSeqVitorias]
(
    @CurrentLogin						varchar(25) = null,
	@CurrentDateTime					Datetime = null,
	@NomeCampeonato						varchar(50),
	@NomeTime							varchar(30),
	@GetRecord							bit = true,
	@Vitorias							int OUTPUT,
	@Empates							int OUTPUT,
	@Derrotas							int OUTPUT,
	@VitoriasCasa						int OUTPUT,
	@EmpatesCasa						int OUTPUT,
	@DerrotasCasa						int OUTPUT,
	@VitoriasFora						int OUTPUT,
	@EmpatesFora						int OUTPUT,
	@DerrotasFora						int OUTPUT,
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN
	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL	


	PRINT 'Time: ' + @NomeTime

	DECLARE @DataJogo		datetime
	DECLARE @NomeTime1		varchar(30)
	DECLARE @NomeTime2		varchar(30)
	DECLARE @Gols1			smallint
	DECLARE @Gols2			smallint


	DECLARE @MaxEmpate				int
	DECLARE @MaxVitoria				int
	DECLARE @MaxDerrota				int
	DECLARE @CurrentEmpate			int
	DECLARE @CurrentVitoria			int
	DECLARE @CurrentDerrota			int


	DECLARE @MaxEmpateFora			int
	DECLARE @MaxVitoriaFora			int
	DECLARE @MaxDerrotaFora			int
	DECLARE @CurrentEmpateFora		int
	DECLARE @CurrentVitoriaFora		int
	DECLARE @CurrentDerrotaFora		int


	DECLARE @MaxEmpateDentro		int
	DECLARE @MaxVitoriaDentro		int
	DECLARE @MaxDerrotaDentro		int
	DECLARE @CurrentEmpateDentro	int
	DECLARE @CurrentVitoriaDentro	int
	DECLARE @CurrentDerrotaDentro	int




	SET @CurrentEmpate				= 0
	SET @CurrentVitoria				= 0
	SET @CurrentDerrota				= 0
	SET @MaxEmpate					= 0
	SET @MaxVitoria					= 0
	SET @MaxDerrota					= 0

	SET @CurrentEmpateFora			= 0
	SET @CurrentVitoriaFora			= 0
	SET @CurrentDerrotaFora			= 0
	SET @MaxEmpateFora				= 0
	SET @MaxVitoriaFora				= 0
	SET @MaxDerrotaFora				= 0


	SET @CurrentEmpateDentro		= 0
	SET @CurrentVitoriaDentro		= 0
	SET @CurrentDerrotaDentro		= 0
	SET @MaxEmpateDentro			= 0
	SET @MaxVitoriaDentro			= 0
	SET @MaxDerrotaDentro			= 0






	DECLARE curJogo CURSOR FOR
	 SELECT DataJogo, NomeTime1, GolsTime1, GolsTime2, NomeTime2
	  FROM Jogos
	 WHERE NomeCampeonato	= @NomeCampeonato
	   AND 
		  (
				NomeTime1		= @NomeTime
				OR
				NomeTime2		= @NomeTime
		  )
	   AND IsValido = 1
	   
	 ORDER BY DataJogo 


	 
	OPEN curJogo


	FETCH NEXT FROM curJogo INTO @DataJogo, @NomeTime1, @Gols1, @Gols2, @NomeTime2


	WHILE (@@FETCH_STATUS = 0)
	BEGIN

		--PRINT	'DataJogo: ' + Convert(VARCHAR, @DataJogo) + 
		--		' < ' + @NomeTime1 + ' > [' + CONVERT(VARCHAR, @Gols1) + '] x ' +
		--		'[' + CONVERT(VARCHAR, @Gols2) + ']' + ' < ' + @NomeTime2 + ' >'


		-- Time de casa ganhador
		IF (@Gols1 > @Gols2)
		BEGIN
		
			-- Time especificado ganhou dentro de casa
			IF (@NomeTime1 = @NomeTime)
			BEGIN
			
				SET @CurrentVitoria = @CurrentVitoria + 1
				
				IF (@CurrentVitoria > @MaxVitoria )
					SET @MaxVitoria = @CurrentVitoria
				

				
				SET @CurrentVitoriaDentro = @CurrentVitoriaDentro + 1
								
				IF (@CurrentVitoriaDentro > @MaxVitoriaDentro )
					SET @MaxVitoriaDentro = @CurrentVitoriaDentro

			
				PRINT '[ 1* x  0 ] V: [' + CONVERT(VARCHAR, @CurrentVitoria) + '] E: ['+ CONVERT(VARCHAR, @CurrentEmpate) + '] D: [' + CONVERT(VARCHAR, @CurrentDerrota ) + ']' +
					' VFora: [' + CONVERT(VARCHAR, @CurrentVitoriaFora) + '] EFora: [' + CONVERT(VARCHAR, @CurrentEmpateFora) + '] DFora: [' + CONVERT(VARCHAR, @CurrentDerrotaFora )+ ']' + 
					' VDentro: [' + CONVERT(VARCHAR, @CurrentVitoriaDentro) + '] EDentro: [' + CONVERT(VARCHAR, @CurrentEmpateDentro) + '] DDentro: [' + CONVERT(VARCHAR, @CurrentDerrotaDentro) + ']' 
					
			END
			
			-- O time especificado perdeu fora de casa
			ELSE
			BEGIN
					
				SET @CurrentVitoria = 0				
				SET @CurrentVitoriaFora = 0
				
				PRINT '[ 1  x *0 ] V: [' + CONVERT(VARCHAR, @CurrentVitoria) + '] E: ['+ CONVERT(VARCHAR, @CurrentEmpate) + '] D: [' + CONVERT(VARCHAR, @CurrentDerrota ) + ']' +
					' VFora: [' + CONVERT(VARCHAR, @CurrentVitoriaFora) + '] EFora: [' + CONVERT(VARCHAR, @CurrentEmpateFora) + '] DFora: [' + CONVERT(VARCHAR, @CurrentDerrotaFora )+ ']' + 
					' VDentro: [' + CONVERT(VARCHAR, @CurrentVitoriaDentro) + '] EDentro: [' + CONVERT(VARCHAR, @CurrentEmpateDentro) + '] DDentro: [' + CONVERT(VARCHAR, @CurrentDerrotaDentro) + ']' 
					
			END
		END
		
		-- Time que está jogando fora ganhou o jogo
		ELSE IF (@Gols1 < @Gols2)
		BEGIN
		
			-- O time especificado ganhou fora de casa
			IF (@NomeTime2 = @NomeTime)
			BEGIN
			
				SET @CurrentVitoria = @CurrentVitoria + 1
				
				IF (@CurrentVitoria > @MaxVitoria )
					SET @MaxVitoria = @CurrentVitoria
				
				
				

				SET @CurrentVitoriaFora = @CurrentVitoriaFora + 1
				
				IF (@CurrentVitoriaFora > @MaxVitoriaFora )
					SET @MaxVitoriaFora = @CurrentVitoriaFora

				

				PRINT '[ 0  x *1 ] V: [' + CONVERT(VARCHAR, @CurrentVitoria) + '] E: ['+ CONVERT(VARCHAR, @CurrentEmpate) + '] D: [' + CONVERT(VARCHAR, @CurrentDerrota ) + ']' +
					' VFora: [' + CONVERT(VARCHAR, @CurrentVitoriaFora) + '] EFora: [' + CONVERT(VARCHAR, @CurrentEmpateFora) + '] DFora: [' + CONVERT(VARCHAR, @CurrentDerrotaFora )+ ']' + 
					' VDentro: [' + CONVERT(VARCHAR, @CurrentVitoriaDentro) + '] EDentro: [' + CONVERT(VARCHAR, @CurrentEmpateDentro) + '] DDentro: [' + CONVERT(VARCHAR, @CurrentDerrotaDentro) + ']' 
					
			END
			-- O time especificado perdeu dentro de casa
			ELSE
			BEGIN
			
			
				SET @CurrentVitoria = 0				
				SET @CurrentVitoriaDentro = 0


				PRINT '[ 0* x  1 ] V: [' + CONVERT(VARCHAR, @CurrentVitoria) + '] E: ['+ CONVERT(VARCHAR, @CurrentEmpate) + '] D: [' + CONVERT(VARCHAR, @CurrentDerrota ) + ']' +
					' VFora: [' + CONVERT(VARCHAR, @CurrentVitoriaFora) + '] EFora: [' + CONVERT(VARCHAR, @CurrentEmpateFora) + '] DFora: [' + CONVERT(VARCHAR, @CurrentDerrotaFora )+ ']' + 
					' VDentro: [' + CONVERT(VARCHAR, @CurrentVitoriaDentro) + '] EDentro: [' + CONVERT(VARCHAR, @CurrentEmpateDentro) + '] DDentro: [' + CONVERT(VARCHAR, @CurrentDerrotaDentro) + ']' 
					
			END
		END
		-- Ocorreu empate no jogo
		If (@Gols1 = @Gols2)
		BEGIN		

			SET @CurrentVitoria = 0
			
			
			-- Se o time de casa empatou
			if (@NomeTime1 = @NomeTime)
			BEGIN
			
				SET @CurrentVitoriaDentro = 0

				PRINT '[ 1* x  1 ] V: [' + CONVERT(VARCHAR, @CurrentVitoria) + '] E: ['+ CONVERT(VARCHAR, @CurrentEmpate) + '] D: [' + CONVERT(VARCHAR, @CurrentDerrota ) + ']' +
					' VFora: [' + CONVERT(VARCHAR, @CurrentVitoriaFora) + '] EFora: [' + CONVERT(VARCHAR, @CurrentEmpateFora) + '] DFora: [' + CONVERT(VARCHAR, @CurrentDerrotaFora )+ ']' + 
					' VDentro: [' + CONVERT(VARCHAR, @CurrentVitoriaDentro) + '] EDentro: [' + CONVERT(VARCHAR, @CurrentEmpateDentro) + '] DDentro: [' + CONVERT(VARCHAR, @CurrentDerrotaDentro) + ']' 
					

			END


			-- Se o time fora de casa empatou
			if (@NomeTime2 = @NomeTime)
			BEGIN

				SET @CurrentVitoriaFora = 0

				PRINT '[ 1  x *1 ] V: [' + CONVERT(VARCHAR, @CurrentVitoria) + '] E: ['+ CONVERT(VARCHAR, @CurrentEmpate) + '] D: [' + CONVERT(VARCHAR, @CurrentDerrota ) + ']' +
					' VFora: [' + CONVERT(VARCHAR, @CurrentVitoriaFora) + '] EFora: [' + CONVERT(VARCHAR, @CurrentEmpateFora) + '] DFora: [' + CONVERT(VARCHAR, @CurrentDerrotaFora )+ ']' + 
					' VDentro: [' + CONVERT(VARCHAR, @CurrentVitoriaDentro) + '] EDentro: [' + CONVERT(VARCHAR, @CurrentEmpateDentro) + '] DDentro: [' + CONVERT(VARCHAR, @CurrentDerrotaDentro) + ']' 
					
			END
			
			
			
		END	
		
		
		--PRINT 'CurrentVitoria: [' + CONVERT(VARCHAR, @CurrentVitoria) + '] CurrentEmpate: ['+ CONVERT(VARCHAR, @CurrentEmpate) + '] CurrentDerrota: [' + CONVERT(VARCHAR, @CurrentDerrota ) + ']'
		
		--PRINT 'MaxVitoria: [' + CONVERT(VARCHAR, @MaxVitoria) + '] MaxEmpate: ['+ CONVERT(VARCHAR, @MaxEmpate) + '] MaxDerrota: [' + CONVERT(VARCHAR, @MaxDerrota) + ']'
		
		
		FETCH NEXT FROM curJogo INTO @DataJogo, @NomeTime1, @Gols1, @Gols2, @NomeTime2
	END


	 
	CLOSE curJogo
	DEALLOCATE curJogo


	PRINT '--------------------------------'
	PRINT 'Empates: ' + CONVERT(VARCHAR, @Maxempate)
	PRINT 'Derrotas: ' + CONVERT(VARCHAR, @MaxDerrota)
	PRINT 'Vitórias: ' + CONVERT(VARCHAR, @MaxVitoria)
	PRINT '--------------------------------'
	PRINT 'Empates Dentro: ' + CONVERT(VARCHAR, @MaxempateDentro)
	PRINT 'Derrotas Dentro: ' + CONVERT(VARCHAR, @MaxDerrotaDentro)
	PRINT 'Vitórias Dentro: ' + CONVERT(VARCHAR, @MaxVitoriaDentro)
	PRINT '--------------------------------'
	PRINT 'Empates Fora: ' + CONVERT(VARCHAR, @MaxempateFora)
	PRINT 'Derrotas Fora: ' + CONVERT(VARCHAR, @MaxDerrotaFora)
	PRINT 'Vitórias Fora: ' + CONVERT(VARCHAR, @MaxVitoriaFora)


	if (@GetRecord = 1)
	BEGIN
		SET @Vitorias			= @MaxVitoria
		SET @Empates			= @MaxEmpate
		SET @Derrotas			= @MaxDerrota


		SET @VitoriasCasa		= @MaxVitoriaDentro
		SET @EmpatesCasa		= @MaxEmpateDentro
		SET @DerrotasCasa		= @MaxDerrotaDentro
		
		
		SET @VitoriasFora		= @MaxVitoriaFora
		SET @EmpatesFora		= @MaxEmpateFora
		SET @DerrotasFora		= @MaxDerrotaFora
	END
	ELSE
	BEGIN
		SET @Vitorias			= @CurrentVitoria
		SET @Empates			= @CurrentEmpate
		SET @Derrotas			= @CurrentDerrota


		SET @VitoriasCasa		= @CurrentVitoriaDentro
		SET @EmpatesCasa		= @CurrentEmpateDentro
		SET @DerrotasCasa		= @CurrentDerrotaDentro
		
		
		SET @VitoriasFora		= @CurrentVitoriaFora
		SET @EmpatesFora		= @CurrentEmpateFora
		SET @DerrotasFora		= @CurrentDerrotaFora
	
	
	END

END

GO
