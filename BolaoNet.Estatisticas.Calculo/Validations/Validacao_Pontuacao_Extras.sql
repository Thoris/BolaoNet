SELECT * FROM
(
SELECT  Final.Username, 
		CASE WHEN Final.Campeao = extra.Posicao1 THEN '-' ELSE 'ERROR' END Time_1,
		CASE WHEN Final.Vice = extra.Posicao2 THEN '-' ELSE 'ERROR' END Time_2,
		CASE WHEN Terceiro.Terceiro = extra.Posicao3 THEN '-' ELSE 'ERROR' END Time_3,
		CASE WHEN Terceiro.Quarto = extra.Posicao4 THEN '-' ELSE 'ERROR' END Time_4,
		Final.Campeao, Final.Vice, Terceiro.Terceiro, Terceiro.Quarto,
		Extra.Posicao1, extra.Posicao2, extra.Posicao3, extra.Posicao4
		--Final.NomeTimeResult1, Final.ApostaTime1, Final.ApostaTime2, Final.NomeTimeResult2,
		--Terceiro.NomeTimeResult1, Terceiro.ApostaTime1, Terceiro.ApostaTime2, Terceiro.NomeTimeResult2 
  FROM 
	(
		SELECT jf.NomeTimeResult1, jf.NomeTimeResult2, jf.UserName, jf.ApostaTime1, jf.ApostaTime2,
			   CASE WHEN jf.ApostaTime1 > jf.ApostaTime2 THEN jf.NomeTimeResult1
					WHEN jf.ApostaTime1 < jf.ApostaTime2 THEN jf.NomeTimeResult2
					WHEN jf.ApostaTime1 = jf.ApostaTime2 AND jf.Ganhador = 1 THEN jf.NomeTimeResult1
					WHEN jf.ApostaTime1 = jf.ApostaTime2 AND jf.Ganhador = 2 THEN jf.NomeTimeResult2
			   END Campeao,
			   CASE WHEN jf.ApostaTime1 > jf.ApostaTime2 THEN jf.NomeTimeResult2
					WHEN jf.ApostaTime1 < jf.ApostaTime2 THEN jf.NomeTimeResult1
					WHEN jf.ApostaTime1 = jf.ApostaTime2 AND jf.Ganhador = 1 THEN jf.NomeTimeResult2
					WHEN jf.ApostaTime1 = jf.ApostaTime2 AND jf.Ganhador = 2 THEN jf.NomeTimeResult1
			   END Vice
		  FROM JogosUsuarios jf
		 WHERE jf.JogoId = 64
	) Final
 INNER JOIN 
	(
		SELECT jt.NomeTimeResult1, jt.NomeTimeResult2, jt.UserName, jt.ApostaTime1, jt.ApostaTime2,
			   CASE WHEN jt.ApostaTime1 > jt.ApostaTime2 THEN jt.NomeTimeResult1
					WHEN jt.ApostaTime1 < jt.ApostaTime2 THEN jt.NomeTimeResult2
					WHEN jt.ApostaTime1 = jt.ApostaTime2 AND jt.Ganhador = 1 THEN jt.NomeTimeResult1
					WHEN jt.ApostaTime1 = jt.ApostaTime2 AND jt.Ganhador = 2 THEN jt.NomeTimeResult2
			   END Terceiro,
			   CASE WHEN jt.ApostaTime1 > jt.ApostaTime2 THEN jt.NomeTimeResult2
					WHEN jt.ApostaTime1 < jt.ApostaTime2 THEN jt.NomeTimeResult1
					WHEN jt.ApostaTime1 = jt.ApostaTime2 AND jt.Ganhador = 1 THEN jt.NomeTimeResult2
					WHEN jt.ApostaTime1 = jt.ApostaTime2 AND jt.Ganhador = 2 THEN jt.NomeTimeResult1
			   END Quarto
		  FROM JogosUsuarios jt
		 WHERE jt.JogoId = 63
	) Terceiro
   ON Final.UserName = Terceiro.UserName
 INNER JOIN
	(
		SELECT UserName,
				(
					SELECT NomeTime 
					  FROM ApostasExtrasUsuarios aeu1
					 WHERE aeu1.Posicao = 1 
					   AND aeu1.UserName = bm.UserName
					   AND aeu1.NomeBolao = bm.NomeBolao
				) Posicao1,
				(
					SELECT NomeTime 
					  FROM ApostasExtrasUsuarios aeu2 
					 WHERE aeu2.Posicao = 2 
					   AND aeu2.UserName = bm.UserName
					   AND aeu2.NomeBolao = bm.NomeBolao
				) Posicao2,				
				(
					SELECT NomeTime 
					  FROM ApostasExtrasUsuarios aeu3 
					 WHERE aeu3.Posicao = 3 
					   AND aeu3.UserName = bm.UserName
					   AND aeu3.NomeBolao = bm.NomeBolao
				) Posicao3,			
				(
					SELECT NomeTime 
					  FROM ApostasExtrasUsuarios aeu4 
					 WHERE aeu4.Posicao = 4 
					   AND aeu4.UserName = bm.UserName
					   AND aeu4.NomeBolao = bm.NomeBolao
				) Posicao4
		  FROM BoloesMembros bm
	) Extra
   ON Extra.UserName = Final.UserName
) info
WHERE info.Time_1 <> '-' 
   OR info.Time_2 <> '-'
   OR info.Time_3 <> '-'
   OR info.Time_4 <> '-'