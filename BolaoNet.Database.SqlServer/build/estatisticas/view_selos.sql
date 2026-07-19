USE [bolaonet]
GO

/****** Object:  View [dbo].[vw_Selo_001_Placar_Exato]    Script Date: 19/07/2026 12:29:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE   VIEW [dbo].[vw_Selo_001_Placar_Exato]
AS

WITH Ranking AS
(
    SELECT

        NomeBolao,

        UserName,

        COUNT(*) AS Quantidade,


        DENSE_RANK() OVER
        (
            PARTITION BY NomeBolao
            ORDER BY COUNT(*) DESC
        ) AS Posicao


    FROM JogosUsuarios

    WHERE IsPlacarCheio = 1

    GROUP BY

        NomeBolao,

        UserName
)

SELECT

    NomeBolao,

    UserName,

    '🎯 REI/RAINHA DOS PLACARES EXATOS' AS Selo,

    'Maior quantidade de placares acertados exatamente' AS Descricao,

    Quantidade AS Valor

FROM Ranking

WHERE Posicao = 1;
GO

/****** Object:  View [dbo].[vw_Selo_002_Mestre_Resultado]    Script Date: 19/07/2026 12:29:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE   VIEW [dbo].[vw_Selo_002_Mestre_Resultado]
AS

WITH Ranking AS
(
    SELECT

        NomeBolao,

        UserName,

        COUNT(*) AS Quantidade,


        DENSE_RANK() OVER
        (
            PARTITION BY NomeBolao
            ORDER BY COUNT(*) DESC
        ) AS Posicao


    FROM JogosUsuarios

    WHERE IsVDE = 1

    GROUP BY

        NomeBolao,

        UserName
)

SELECT

    NomeBolao,

    UserName,

    '🧱 MESTRE DO RESULTADO' AS Selo,

    'Mais acertos de vencedor ou empate' AS Descricao,

    Quantidade AS Valor

FROM Ranking

WHERE Posicao = 1;
GO

/****** Object:  View [dbo].[vw_Selo_003_Especialista_Brasil]    Script Date: 19/07/2026 12:29:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE   VIEW [dbo].[vw_Selo_003_Especialista_Brasil]
AS

WITH Ranking AS
(
    SELECT

        JU.NomeBolao,

        JU.UserName,

        SUM(JU.Pontos) AS PontosBrasil,


        DENSE_RANK() OVER
        (
            PARTITION BY JU.NomeBolao
            ORDER BY SUM(JU.Pontos) DESC
        ) AS Posicao


    FROM JogosUsuarios JU

    INNER JOIN Jogos J

        ON J.NomeCampeonato = JU.NomeCampeonato
        AND J.JogoId = JU.JogoId


    WHERE

        J.NomeTime1 = 'Brasil'
        OR
        J.NomeTime2 = 'Brasil'


    GROUP BY

        JU.NomeBolao,

        JU.UserName
)

SELECT

    NomeBolao,

    UserName,

    '🇧🇷 ESPECIALISTA NO BRASIL' AS Selo,

    'Maior pontuação conquistada nos jogos do Brasil' AS Descricao,

    PontosBrasil AS Valor

FROM Ranking

WHERE Posicao = 1;
GO

/****** Object:  View [dbo].[vw_Selo_004_Empates]    Script Date: 19/07/2026 12:29:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE   VIEW [dbo].[vw_Selo_004_Empates]
AS

WITH Ranking AS
(
    SELECT

        NomeBolao,

        UserName,

        COUNT(*) AS Quantidade,


        DENSE_RANK() OVER
        (
            PARTITION BY NomeBolao
            ORDER BY COUNT(*) DESC
        ) AS Posicao


    FROM JogosUsuarios

    WHERE

        IsVDE = 1
        AND
        IsEmpate = 1


    GROUP BY

        NomeBolao,

        UserName
)

SELECT

    NomeBolao,

    UserName,

    '🤝 REI/RAINHA DOS EMPATES' AS Selo,

    'Especialista em jogos equilibrados' AS Descricao,

    Quantidade AS Valor

FROM Ranking

WHERE Posicao = 1;
GO

/****** Object:  View [dbo].[vw_Selo_005_1x0]    Script Date: 19/07/2026 12:29:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE   VIEW [dbo].[vw_Selo_005_1x0]
AS

WITH Ranking AS
(
    SELECT

        NomeBolao,

        UserName,

        COUNT(*) AS Quantidade,


        DENSE_RANK() OVER
        (
            PARTITION BY NomeBolao
            ORDER BY COUNT(*) DESC
        ) AS Posicao


    FROM JogosUsuarios


    WHERE

    IsPlacarCheio = 1

    AND

    (
        (ApostaTime1 = 1 AND ApostaTime2 = 0)

        OR

        (ApostaTime1 = 0 AND ApostaTime2 = 1)
    )


    GROUP BY

        NomeBolao,

        UserName
)

SELECT

    NomeBolao,

    UserName,

    '⚽ REI/RAINHA DO 1x0' AS Selo,

    'Especialista em placares econômicos' AS Descricao,

    Quantidade AS Valor

FROM Ranking

WHERE Posicao = 1;
GO

/****** Object:  View [dbo].[vw_Selo_006_Goleadas]    Script Date: 19/07/2026 12:29:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE   VIEW [dbo].[vw_Selo_006_Goleadas]
AS

WITH Ranking AS
(
    SELECT

        JU.NomeBolao,

        JU.UserName,

        COUNT(*) AS Quantidade,


        DENSE_RANK() OVER
        (
            PARTITION BY JU.NomeBolao
            ORDER BY COUNT(*) DESC
        ) AS Posicao


    FROM JogosUsuarios JU


    INNER JOIN Jogos J

        ON J.NomeCampeonato = JU.NomeCampeonato
        AND J.JogoId = JU.JogoId


    WHERE

        JU.IsPlacarCheio = 1

        AND

        ABS(J.GolsTime1 - J.GolsTime2) >= 4


    GROUP BY

        JU.NomeBolao,

        JU.UserName
)

SELECT

    NomeBolao,

    UserName,

    '🔥 ESPECIALISTA EM GOLEADAS' AS Selo,

    'Acertou placares de grandes goleadas' AS Descricao,

    Quantidade AS Valor

FROM Ranking

WHERE Posicao = 1;
GO

/****** Object:  View [dbo].[vw_Selo_007_Maior_Pontuacao_Rodada]    Script Date: 19/07/2026 12:29:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE   VIEW [dbo].[vw_Selo_007_Maior_Pontuacao_Rodada]
AS

WITH Ranking AS
(
    SELECT

        JU.NomeBolao,

        JU.UserName,

        J.Rodada,

        SUM(JU.Pontos) AS PontosRodada,


        DENSE_RANK() OVER
        (
            PARTITION BY JU.NomeBolao
            ORDER BY SUM(JU.Pontos) DESC
        ) AS Posicao


    FROM JogosUsuarios JU


    INNER JOIN Jogos J

        ON J.NomeCampeonato = JU.NomeCampeonato
        AND J.JogoId = JU.JogoId


    GROUP BY

        JU.NomeBolao,

        JU.UserName,

        J.Rodada
)

SELECT

    NomeBolao,

    UserName,

    '📈 MAIOR PONTUAÇÃO EM UMA RODADA' AS Selo,

    CONCAT(
        'Rodada ',
        Rodada,
        ' foi histórica'
    ) AS Descricao,

    PontosRodada AS Valor


FROM Ranking

WHERE Posicao = 1;
GO

/****** Object:  View [dbo].[vw_Selo_008_Apostas_Extras]    Script Date: 19/07/2026 12:29:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE   VIEW [dbo].[vw_Selo_008_Apostas_Extras]
AS

WITH Ranking AS
(
    SELECT

        NomeBolao,

        UserName,

        SUM(ISNULL(Pontos,0)) AS PontosExtras,


        DENSE_RANK() OVER
        (
            PARTITION BY NomeBolao
            ORDER BY SUM(ISNULL(Pontos,0)) DESC
        ) AS Posicao


    FROM ApostasExtrasUsuarios


    GROUP BY

        NomeBolao,

        UserName
)

SELECT

    NomeBolao,

    UserName,

    '🏆 MESTRE DAS APOSTAS EXTRAS' AS Selo,

    'Maior pontuação nas previsões especiais da Copa' AS Descricao,

    PontosExtras AS Valor


FROM Ranking

WHERE Posicao = 1;
GO

/****** Object:  View [dbo].[vw_Selo_009_Aposta_Extra_Dificil]    Script Date: 19/07/2026 12:29:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE   VIEW [dbo].[vw_Selo_009_Aposta_Extra_Dificil]
AS

WITH Ranking AS
(
    SELECT

        AU.NomeBolao,

        AU.UserName,

        AU.Posicao,

        COUNT(*) AS Acertos,


        DENSE_RANK() OVER
        (
            PARTITION BY AU.NomeBolao
            ORDER BY COUNT(*) ASC
        ) AS PosicaoRank


    FROM ApostasExtrasUsuarios AU


    WHERE AU.Pontos > 0


    GROUP BY

        AU.NomeBolao,

        AU.UserName,

        AU.Posicao
)

SELECT

    NomeBolao,

    UserName,

    '🎲 MESTRE DA APOSTA IMPOSSÍVEL' AS Selo,

    'Acertou uma das previsões extras mais difíceis' AS Descricao,

    Acertos AS Valor


FROM Ranking

WHERE PosicaoRank = 1;
GO

/****** Object:  View [dbo].[vw_Selo_010_Colecionador_10_Pontos]    Script Date: 19/07/2026 12:29:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE   VIEW [dbo].[vw_Selo_010_Colecionador_10_Pontos]
AS

WITH Ranking AS
(
    SELECT

        NomeBolao,

        UserName,

        COUNT(*) AS Quantidade,


        DENSE_RANK() OVER
        (
            PARTITION BY NomeBolao
            ORDER BY COUNT(*) DESC
        ) AS Posicao


    FROM JogosUsuarios


    WHERE Pontos IN (10,20)


    GROUP BY

        NomeBolao,

        UserName
)

SELECT

    NomeBolao,

    UserName,

    '💎 COLECIONADOR DE ACERTOS PERFEITOS' AS Selo,

    'Maior quantidade de placares perfeitos' AS Descricao,

    Quantidade AS Valor


FROM Ranking

WHERE Posicao = 1;
GO

/****** Object:  View [dbo].[vw_Selo_011_Pe_Quente_Brasil]    Script Date: 19/07/2026 12:29:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE   VIEW [dbo].[vw_Selo_011_Pe_Quente_Brasil]
AS

WITH Ranking AS
(
    SELECT

        JU.NomeBolao,

        JU.UserName,

        COUNT(*) AS AcertosBrasil,


        DENSE_RANK() OVER
        (
            PARTITION BY JU.NomeBolao
            ORDER BY COUNT(*) DESC
        ) AS Posicao


    FROM JogosUsuarios JU


    INNER JOIN Jogos J

        ON J.NomeCampeonato = JU.NomeCampeonato
        AND J.JogoId = JU.JogoId


    WHERE

        (J.NomeTime1='Brasil'
        OR
        J.NomeTime2='Brasil')

        AND

        JU.Pontos > 0


    GROUP BY

        JU.NomeBolao,

        JU.UserName
)

SELECT

    NomeBolao,

    UserName,

    '🇧🇷 PÉ QUENTE DO BRASIL' AS Selo,

    'Mais jogos da seleção acertados' AS Descricao,

    AcertosBrasil AS Valor


FROM Ranking

WHERE Posicao = 1;
GO

/****** Object:  View [dbo].[vw_Selo_012_Rei_Zebras]    Script Date: 19/07/2026 12:29:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE   VIEW [dbo].[vw_Selo_012_Rei_Zebras]
AS

WITH Ranking AS
(
    SELECT

        NomeBolao,

        UserName,

        COUNT(*) AS Quantidade,


        DENSE_RANK() OVER
        (
            PARTITION BY NomeBolao
            ORDER BY COUNT(*) DESC
        ) AS Posicao


    FROM JogosUsuarios


    WHERE

        IsVDE = 1

        AND

        IsPlacarCheio = 0


    GROUP BY

        NomeBolao,

        UserName
)

SELECT

    NomeBolao,

    UserName,

    '🦓 REI/RAINHA DAS ZEBRAS' AS Selo,

    'Especialista em resultados inesperados' AS Descricao,

    Quantidade AS Valor


FROM Ranking

WHERE Posicao = 1;
GO

/****** Object:  View [dbo].[vw_Selo_013_Arrancada_Final]    Script Date: 19/07/2026 12:29:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE   VIEW [dbo].[vw_Selo_013_Arrancada_Final]
AS

WITH UltimasRodadas AS
(
    SELECT

        MAX(Rodada) AS UltimaRodada

    FROM Jogos
),

Ranking AS
(
    SELECT

        JU.NomeBolao,

        JU.UserName,

        SUM(JU.Pontos) AS PontosFinais,


        DENSE_RANK() OVER
        (
            PARTITION BY JU.NomeBolao
            ORDER BY SUM(JU.Pontos) DESC
        ) AS Posicao


    FROM JogosUsuarios JU


    INNER JOIN Jogos J

        ON J.NomeCampeonato = JU.NomeCampeonato
        AND J.JogoId = JU.JogoId


    CROSS JOIN UltimasRodadas U


    WHERE J.Rodada >= U.UltimaRodada-2


    GROUP BY

        JU.NomeBolao,

        JU.UserName
)

SELECT

    NomeBolao,

    UserName,

    '🚀 ARRANCADA FINAL' AS Selo,

    'Melhor desempenho nas últimas rodadas' AS Descricao,

    PontosFinais AS Valor


FROM Ranking

WHERE Posicao = 1;
GO

/****** Object:  View [dbo].[vw_Selo_014_Lider_Quantidade]    Script Date: 19/07/2026 12:29:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE   VIEW [dbo].[vw_Selo_014_Lider_Quantidade]
AS

WITH RankingRodada AS
(
    SELECT

        JU.NomeBolao,

        JU.UserName,

        J.Rodada,

        SUM(JU.Pontos) AS PontosRodada,


        DENSE_RANK() OVER
        (
            PARTITION BY 
                JU.NomeBolao,
                J.Rodada

            ORDER BY 
                SUM(JU.Pontos) DESC

        ) AS PosicaoRodada


    FROM JogosUsuarios JU


    INNER JOIN Jogos J

        ON J.NomeCampeonato = JU.NomeCampeonato
        AND J.JogoId = JU.JogoId


    GROUP BY

        JU.NomeBolao,

        JU.UserName,

        J.Rodada
),


Liderancas AS
(
    SELECT

        NomeBolao,

        UserName,

        COUNT(*) AS QuantidadeLiderancas


    FROM RankingRodada


    WHERE PosicaoRodada = 1


    GROUP BY

        NomeBolao,

        UserName
),


RankingFinal AS
(
    SELECT

        NomeBolao,

        UserName,

        QuantidadeLiderancas,


        DENSE_RANK() OVER
        (
            PARTITION BY NomeBolao

            ORDER BY QuantidadeLiderancas DESC

        ) AS Posicao


    FROM Liderancas
)


SELECT

    NomeBolao,

    UserName,

    '👑 LÍDER DO CAMPEONATO' AS Selo,

    'Participante que terminou mais rodadas na liderança' AS Descricao,

    QuantidadeLiderancas AS Valor


FROM RankingFinal


WHERE Posicao = 1;

GO

/****** Object:  View [dbo].[vw_Selo_015_Ultimo_Lendario]    Script Date: 19/07/2026 12:29:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE   VIEW [dbo].[vw_Selo_015_Ultimo_Lendario]
AS

WITH Ranking AS
(
    SELECT

        NomeBolao,

        UserName,

        SUM(ISNULL(Pontos,0)) AS PontosTotal,


        DENSE_RANK() OVER
        (
            PARTITION BY NomeBolao
            ORDER BY SUM(ISNULL(Pontos,0)) ASC
        ) AS Posicao


    FROM JogosUsuarios


    GROUP BY

        NomeBolao,

        UserName
)

SELECT

    NomeBolao,

    UserName,

    '😂 ÚLTIMO COLOCADO LENDÁRIO' AS Selo,

    'Terminou a Copa, mas entrou para a história' AS Descricao,

    PontosTotal AS Valor


FROM Ranking

WHERE Posicao = 1;
GO

/****** Object:  View [dbo].[vw_Selo_017_Matematico]    Script Date: 19/07/2026 12:29:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE   VIEW [dbo].[vw_Selo_017_Matematico]
AS

WITH Ranking AS
(
SELECT

NomeBolao,

UserName,

COUNT(*) AS Quantidade,


DENSE_RANK() OVER
(
PARTITION BY NomeBolao
ORDER BY COUNT(*) DESC
) Posicao


FROM JogosUsuarios


WHERE Pontos IN (1,3,4,5)


GROUP BY

NomeBolao,

UserName
)

SELECT

NomeBolao,

UserName,

'🧮 MATEMÁTICO DO BOLÃO' AS Selo,

'Especialista em pontuar mesmo sem cravar placares' AS Descricao,

Quantidade AS Valor


FROM Ranking

WHERE Posicao=1;
GO

/****** Object:  View [dbo].[vw_Selo_020_Rei_Gols]    Script Date: 19/07/2026 12:29:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE   VIEW [dbo].[vw_Selo_020_Rei_Gols]
AS

WITH Ranking AS
(
SELECT

JU.NomeBolao,

JU.UserName,


COUNT(*) AS Quantidade,


DENSE_RANK() OVER
(
PARTITION BY JU.NomeBolao
ORDER BY COUNT(*) DESC
) Posicao


FROM JogosUsuarios JU


WHERE

JU.IsGolsTime1=1
OR

JU.IsGolsTime2=1


GROUP BY

JU.NomeBolao,

JU.UserName
)


SELECT

NomeBolao,

UserName,

'⚽ REI DOS GOLS' AS Selo,

'Especialista em prever quem balançaria as redes' AS Descricao,

Quantidade AS Valor


FROM Ranking

WHERE Posicao=1;
GO

/****** Object:  View [dbo].[vw_Selo_021_Mestre_Artilheiros]    Script Date: 19/07/2026 12:29:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE   VIEW [dbo].[vw_Selo_021_Mestre_Artilheiros]
AS

WITH Ranking AS
(
SELECT

JU.NomeBolao,

JU.UserName,


SUM(J.GolsTime1+J.GolsTime2) AS GolsJogosAcertados,


DENSE_RANK() OVER
(
PARTITION BY JU.NomeBolao
ORDER BY SUM(J.GolsTime1+J.GolsTime2) DESC
) Posicao


FROM JogosUsuarios JU


INNER JOIN Jogos J

ON J.NomeCampeonato=JU.NomeCampeonato
AND J.JogoId=JU.JogoId


WHERE JU.IsPlacarCheio=1


GROUP BY

JU.NomeBolao,

JU.UserName
)


SELECT

NomeBolao,

UserName,

'🥅 MESTRE DOS ARTILHEIROS' AS Selo,

'Acertou os jogos mais cheios de gols' AS Descricao,

GolsJogosAcertados AS Valor


FROM Ranking

WHERE Posicao=1;
GO

/****** Object:  View [dbo].[vw_Selo_022_Mestre_MataMata]    Script Date: 19/07/2026 12:29:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE   VIEW [dbo].[vw_Selo_022_Mestre_MataMata]
AS

WITH Ranking AS
(
SELECT

JU.NomeBolao,

JU.UserName,


SUM(JU.Pontos) AS Pontos,


DENSE_RANK() OVER
(
PARTITION BY JU.NomeBolao
ORDER BY SUM(JU.Pontos) DESC
) Posicao


FROM JogosUsuarios JU


INNER JOIN Jogos J

ON J.NomeCampeonato=JU.NomeCampeonato
AND J.JogoId=JU.JogoId


WHERE

J.NomeFase NOT IN ('Grupos')


GROUP BY

JU.NomeBolao,

JU.UserName
)


SELECT

NomeBolao,

UserName,

'🏟️ MESTRE DO MATA-MATA' AS Selo,

'Melhor desempenho nos jogos decisivos' AS Descricao,

Pontos AS Valor


FROM Ranking

WHERE Posicao=1;
GO

/****** Object:  View [dbo].[vw_Selo_023_Fase_Grupos]    Script Date: 19/07/2026 12:29:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE   VIEW [dbo].[vw_Selo_023_Fase_Grupos]
AS

WITH Ranking AS
(
SELECT

JU.NomeBolao,

JU.UserName,

SUM(JU.Pontos) Pontos,


DENSE_RANK() OVER
(
PARTITION BY JU.NomeBolao
ORDER BY SUM(JU.Pontos) DESC
) Posicao


FROM JogosUsuarios JU

INNER JOIN Jogos J

ON J.NomeCampeonato=JU.NomeCampeonato
AND J.JogoId=JU.JogoId


WHERE J.NomeFase='Classificatória'


GROUP BY

JU.NomeBolao,

JU.UserName
)


SELECT

NomeBolao,

UserName,

'🌎 SENHOR DA FASE DE GRUPOS' AS Selo,

'Dominou a primeira fase da Copa' AS Descricao,

Pontos AS Valor


FROM Ranking

WHERE Posicao=1;
GO

/****** Object:  View [dbo].[vw_Selo_024_Campeao_Moral]    Script Date: 19/07/2026 12:29:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE   VIEW [dbo].[vw_Selo_024_Campeao_Moral]
AS

WITH Ranking AS
(
SELECT

NomeBolao,

UserName,

SUM(Pontos) AS PontosJogos,


DENSE_RANK() OVER
(
PARTITION BY NomeBolao
ORDER BY SUM(Pontos) DESC
) Posicao


FROM JogosUsuarios


GROUP BY

NomeBolao,

UserName
)


SELECT

NomeBolao,

UserName,

'🏆 CAMPEÃO MORAL' AS Selo,

'Foi o melhor apenas nos jogos em campo' AS Descricao,

PontosJogos AS Valor


FROM Ranking

WHERE Posicao=1;
GO

/****** Object:  View [dbo].[vw_Selo_025_Apostador_Ousado]    Script Date: 19/07/2026 12:29:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE   VIEW [dbo].[vw_Selo_025_Apostador_Ousado]
AS

WITH Ranking AS
(
SELECT

NomeBolao,

UserName,

COUNT(*) AS Quantidade,


DENSE_RANK() OVER
(
PARTITION BY NomeBolao
ORDER BY COUNT(*) DESC
) Posicao


FROM JogosUsuarios


WHERE

(ApostaTime1+ApostaTime2)>=4


GROUP BY

NomeBolao,

UserName
)


SELECT

NomeBolao,

UserName,

'🎰 APOSTADOR MAIS OUSADO' AS Selo,

'Não teve medo de apostar alto' AS Descricao,

Quantidade AS Valor


FROM Ranking

WHERE Posicao=1;
GO

/****** Object:  View [dbo].[vw_Selos_Email_Final]    Script Date: 19/07/2026 12:29:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE   VIEW [dbo].[vw_Selos_Email_Final]
AS

SELECT 
    1 AS Ordem,
    '001' AS CodigoSelo,
    NomeBolao,
    UserName,
    Selo,
    Descricao,
    Valor

FROM vw_Selo_001_Placar_Exato


UNION ALL


SELECT
    2,
    '002',
    NomeBolao,
    UserName,
    Selo,
    Descricao,
    Valor

FROM vw_Selo_002_Mestre_Resultado


UNION ALL


SELECT
    3,
    '003',
    NomeBolao,
    UserName,
    Selo,
    Descricao,
    Valor

FROM vw_Selo_003_Especialista_Brasil


UNION ALL


SELECT
    4,
    '004',
    NomeBolao,
    UserName,
    Selo,
    Descricao,
    Valor

FROM vw_Selo_004_Empates


UNION ALL


SELECT
    5,
    '005',
    NomeBolao,
    UserName,
    Selo,
    Descricao,
    Valor

FROM vw_Selo_005_1x0


UNION ALL


SELECT
    6,
    '006',
    NomeBolao,
    UserName,
    Selo,
    Descricao,
    Valor

FROM vw_Selo_006_Goleadas


UNION ALL


SELECT
    7,
    '007',
    NomeBolao,
    UserName,
    Selo,
    Descricao,
    Valor

FROM vw_Selo_007_Maior_Pontuacao_Rodada


UNION ALL


SELECT
    8,
    '008',
    NomeBolao,
    UserName,
    Selo,
    Descricao,
    Valor

FROM vw_Selo_008_Apostas_Extras


UNION ALL


SELECT
    9,
    '009',
    NomeBolao,
    UserName,
    Selo,
    Descricao,
    Valor

FROM vw_Selo_009_Aposta_Extra_Dificil


UNION ALL


SELECT
    10,
    '010',
    NomeBolao,
    UserName,
    Selo,
    Descricao,
    Valor

FROM vw_Selo_010_Colecionador_10_Pontos


UNION ALL


SELECT
    11,
    '011',
    NomeBolao,
    UserName,
    Selo,
    Descricao,
    Valor

FROM vw_Selo_011_Pe_Quente_Brasil


UNION ALL


SELECT
    12,
    '012',
    NomeBolao,
    UserName,
    Selo,
    Descricao,
    Valor

FROM vw_Selo_012_Rei_Zebras


UNION ALL


SELECT
    13,
    '013',
    NomeBolao,
    UserName,
    Selo,
    Descricao,
    Valor

FROM vw_Selo_013_Arrancada_Final


UNION ALL


SELECT
    14,
    '014',
    NomeBolao,
    UserName,
    Selo,
    Descricao,
    Valor

FROM vw_Selo_014_Lider_Quantidade


UNION ALL


SELECT
    15,
    '015',
    NomeBolao,
    UserName,
    Selo,
    Descricao,
    Valor

FROM vw_Selo_015_Ultimo_Lendario


--UNION ALL


--SELECT
--    16,
--    '016',
--    NomeBolao,
--    UserName,
--    Selo,
--    Descricao,
--    Valor

--FROM vw_Selo_016_Recuperacao


UNION ALL


SELECT
    17,
    '017',
    NomeBolao,
    UserName,
    Selo,
    Descricao,
    Valor

FROM vw_Selo_017_Matematico


--UNION ALL


--SELECT
--    18,
--    '018',
--    NomeBolao,
--    UserName,
--    Selo,
--    Descricao,
--    Valor

--FROM vw_Selo_018_Apostador_Pontual


--UNION ALL


--SELECT
--    19,
--    '019',
--    NomeBolao,
--    UserName,
--    Selo,
--    Descricao,
--    Valor

--FROM vw_Selo_019_Comentarista


UNION ALL


SELECT
    20,
    '020',
    NomeBolao,
    UserName,
    Selo,
    Descricao,
    Valor

FROM vw_Selo_020_Rei_Gols


UNION ALL


SELECT
    21,
    '021',
    NomeBolao,
    UserName,
    Selo,
    Descricao,
    Valor

FROM vw_Selo_021_Mestre_Artilheiros


UNION ALL


SELECT
    22,
    '022',
    NomeBolao,
    UserName,
    Selo,
    Descricao,
    Valor

FROM vw_Selo_022_Mestre_MataMata


UNION ALL


SELECT
    23,
    '023',
    NomeBolao,
    UserName,
    Selo,
    Descricao,
    Valor

FROM vw_Selo_023_Fase_Grupos


UNION ALL


SELECT
    24,
    '024',
    NomeBolao,
    UserName,
    Selo,
    Descricao,
    Valor

FROM vw_Selo_024_Campeao_Moral


UNION ALL


SELECT
    25,
    '025',
    NomeBolao,
    UserName,
    Selo,
    Descricao,
    Valor

FROM vw_Selo_025_Apostador_Ousado;

GO

/****** Object:  View [dbo].[vw_Email_Selos_Por_Apostador]    Script Date: 19/07/2026 12:29:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE   VIEW [dbo].[vw_Email_Selos_Por_Apostador]
AS

SELECT

    NomeBolao,

    UserName,

    STRING_AGG
    (
        Selo + ' - ' + Descricao,
        ' | '
    ) AS Selos


FROM vw_Selos_Email_Final


GROUP BY

    NomeBolao,

    UserName;

GO

/****** Object:  View [dbo].[vw_Bolao_Ranking_Final]    Script Date: 19/07/2026 12:29:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE   VIEW [dbo].[vw_Bolao_Ranking_Final]
AS

WITH PontosJogos AS
(
    SELECT

        NomeBolao,

        UserName,

        SUM(ISNULL(Pontos,0)) AS PontosJogos


    FROM JogosUsuarios


    GROUP BY

        NomeBolao,

        UserName
),


PontosExtras AS
(
    SELECT

        NomeBolao,

        UserName,

        SUM(ISNULL(Pontos,0)) AS PontosExtras


    FROM ApostasExtrasUsuarios


    GROUP BY

        NomeBolao,

        UserName
),


Ranking AS
(
    SELECT

        M.NomeBolao,

        M.UserName,

        M.FullName,

        ISNULL(PJ.PontosJogos,0) AS PontosJogos,

        ISNULL(PE.PontosExtras,0) AS PontosExtras,


        ISNULL(PJ.PontosJogos,0)
        +
        ISNULL(PE.PontosExtras,0) AS PontosTotal,


        DENSE_RANK() OVER
        (
            PARTITION BY M.NomeBolao

            ORDER BY

            (
                ISNULL(PJ.PontosJogos,0)
                +
                ISNULL(PE.PontosExtras,0)
            )
            DESC

        ) AS Posicao


    FROM BoloesMembros M


    LEFT JOIN PontosJogos PJ

        ON PJ.NomeBolao=M.NomeBolao
        AND PJ.UserName=M.UserName


    LEFT JOIN PontosExtras PE

        ON PE.NomeBolao=M.NomeBolao
        AND PE.UserName=M.UserName
)


SELECT

    NomeBolao,

    UserName,

    FullName,

    Posicao,

    PontosJogos,

    PontosExtras,

    PontosTotal


FROM Ranking;

GO

/****** Object:  View [dbo].[vw_Bolao_Premiacao_Final]    Script Date: 19/07/2026 12:29:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE   VIEW [dbo].[vw_Bolao_Premiacao_Final]
AS

WITH Ranking AS
(
    SELECT

        *,

        MAX(Posicao) OVER
        (
            PARTITION BY NomeBolao
        ) AS UltimaPosicao


    FROM vw_Bolao_Ranking_Final
)

SELECT

    NomeBolao,

    UserName,

    FullName,

    Posicao,

    PontosTotal,


    CASE

        WHEN Posicao = 1 THEN '🥇 70%'

        WHEN Posicao = 2 THEN '🥈 20%'

        WHEN Posicao = 3 THEN '🥉 9%'

        WHEN Posicao = UltimaPosicao THEN '😂 1%'

        ELSE ''

    END AS Premio


FROM Ranking;

GO

/****** Object:  View [dbo].[vw_Bolao_Selos_Final]    Script Date: 19/07/2026 12:29:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE   VIEW [dbo].[vw_Bolao_Selos_Final]
AS

SELECT

    NomeBolao,

    UserName,

    STRING_AGG
    (
        Selo,
        ' | '
    ) AS Selos,


    COUNT(*) AS QuantidadeSelos


FROM vw_Selos_Email_Final


GROUP BY

    NomeBolao,

    UserName;

GO

/****** Object:  View [dbo].[vw_Bolao_Estatisticas_Final]    Script Date: 19/07/2026 12:29:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE   VIEW [dbo].[vw_Bolao_Estatisticas_Final]
AS

SELECT

    NomeBolao,

    UserName,

    COUNT(*) AS JogosApostados,

    SUM
    (
        CASE 
            WHEN IsPlacarCheio=1 THEN 1 
            ELSE 0 
        END
    ) AS PlacaresExatos,


    SUM
    (
        CASE 
            WHEN Pontos>0 THEN 1 
            ELSE 0 
        END
    ) AS JogosPontuados,


    SUM(ISNULL(Pontos,0)) AS PontosJogos


FROM JogosUsuarios


GROUP BY

    NomeBolao,

    UserName;

GO

/****** Object:  View [dbo].[vw_Email_Encerramento_Bolao]    Script Date: 19/07/2026 12:29:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE   VIEW [dbo].[vw_Email_Encerramento_Bolao]
AS

SELECT

R.NomeBolao,

R.UserName,

R.FullName,


R.Posicao,


CASE

WHEN R.Posicao=1
THEN '🏆 GRANDE CAMPEÃO DO BOLÃO'

WHEN R.Posicao=2
THEN '🥈 VICE-CAMPEÃO DO BOLÃO'

WHEN R.Posicao=3
THEN '🥉 TERCEIRO COLOCADO'

ELSE ''

END AS Titulo,


R.PontosTotal,


ISNULL(S.Selos,'') AS Selos,


ISNULL(E.JogosApostados,0)
AS JogosApostados,


ISNULL(E.PlacaresExatos,0)
AS PlacaresExatos,


ISNULL(E.JogosPontuados,0)
AS JogosPontuados,


CASE

WHEN R.Posicao=1

THEN

'Parabéns! Você dominou a Copa e levou o título! 🏆'


WHEN R.Posicao<=3

THEN

'Excelente campanha! Você ficou entre os maiores da Copa! 🎉'


ELSE

'Obrigado por participar desta grande tradição! ⚽'


END AS Mensagem


FROM vw_Bolao_Ranking_Final R


LEFT JOIN vw_Bolao_Selos_Final S

ON S.NomeBolao=R.NomeBolao
AND S.UserName=R.UserName


LEFT JOIN vw_Bolao_Estatisticas_Final E

ON E.NomeBolao=R.NomeBolao
AND E.UserName=R.UserName;


GO

/****** Object:  View [dbo].[vw_Ultimo_Gol_Ate_90]    Script Date: 19/07/2026 12:29:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE   VIEW [dbo].[vw_Ultimo_Gol_Ate_90]
AS

WITH UltimoGol AS
(
    SELECT

        J.NomeCampeonato,

        J.JogoId,

        J.ExternalId,

        E.Id AS EventoId,

        E.Minute,

        E.IsHomeTeam,


        ROW_NUMBER() OVER
        (
            PARTITION BY 
                J.NomeCampeonato,
                J.JogoId

            ORDER BY

                E.Minute DESC,

                E.Id DESC

        ) AS RN


    FROM Jogos J


    INNER JOIN ApiMatchEvents E

        ON E.MatchKeyId = J.ExternalId


    WHERE

        E.EventType = 'Goal'

        AND E.Minute <= 90
)


SELECT

    NomeCampeonato,

    JogoId,

    ExternalId,

    EventoId,

    Minute,

    IsHomeTeam


FROM UltimoGol

WHERE RN = 1;

GO

/****** Object:  View [dbo].[vw_Selo_027_Mais_Azarado]    Script Date: 19/07/2026 12:29:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE   VIEW [dbo].[vw_Selo_027_Mais_Azarado]
AS

WITH Ranking AS
(
    SELECT

        JU.NomeBolao,

        JU.UserName,

        COUNT(*) AS Quantidade


    FROM JogosUsuarios JU


    INNER JOIN Jogos J

        ON J.NomeCampeonato = JU.NomeCampeonato

        AND J.JogoId = JU.JogoId


    INNER JOIN vw_Ultimo_Gol_Ate_90 UG

        ON UG.NomeCampeonato = J.NomeCampeonato

        AND UG.JogoId = J.JogoId


    WHERE


        UG.Minute BETWEEN 85 AND 90


        AND


        -- perdeu o placar cheio

        JU.IsPlacarCheio = 0


        AND


        -- pelo menos acertou vencedor/empate

        JU.IsVDE = 1


    GROUP BY

        JU.NomeBolao,

        JU.UserName
),


Classificacao AS
(
    SELECT

        NomeBolao,

        UserName,

        Quantidade,


        DENSE_RANK() OVER
        (
            PARTITION BY NomeBolao

            ORDER BY Quantidade DESC

        ) AS Posicao


    FROM Ranking
)


SELECT

    NomeBolao,

    UserName,

    '😭 MAIS AZARADO DA COPA' AS Selo,

    'Perdeu placares exatos por gols sofridos nos minutos finais do tempo normal' AS Descricao,

    Quantidade AS Valor


FROM Classificacao


WHERE Posicao = 1;

GO

/****** Object:  View [dbo].[vw_Selo_026_Mais_Sortudo]    Script Date: 19/07/2026 12:29:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE   VIEW [dbo].[vw_Selo_026_Mais_Sortudo]
AS

WITH Ranking AS
(
    SELECT

        JU.NomeBolao,

        JU.UserName,

        COUNT(*) AS Quantidade


    FROM JogosUsuarios JU


    INNER JOIN Jogos J

        ON J.NomeCampeonato = JU.NomeCampeonato

        AND J.JogoId = JU.JogoId


    INNER JOIN vw_Ultimo_Gol_Ate_90 UG

        ON UG.NomeCampeonato = J.NomeCampeonato

        AND UG.JogoId = J.JogoId


    WHERE


        -- gol entre 85 e 90

        UG.Minute BETWEEN 85 AND 90


        AND


        -- acertou placar cheio

        JU.IsPlacarCheio = 1


    GROUP BY

        JU.NomeBolao,

        JU.UserName
),


Classificacao AS
(
    SELECT

        NomeBolao,

        UserName,

        Quantidade,


        DENSE_RANK() OVER
        (
            PARTITION BY NomeBolao

            ORDER BY Quantidade DESC

        ) AS Posicao


    FROM Ranking
)


SELECT

    NomeBolao,

    UserName,

    '🍀 MAIS SORTUDO DA COPA' AS Selo,

    'Acertou placares confirmados nos minutos finais do tempo normal' AS Descricao,

    Quantidade AS Valor


FROM Classificacao


WHERE Posicao = 1;

GO

/****** Object:  View [dbo].[vw_Email_Todos_Selos]    Script Date: 19/07/2026 12:29:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE     VIEW [dbo].[vw_Email_Todos_Selos]
AS

SELECT 
    NomeBolao,
    UserName,
    '001' CodigoSelo,
    '🥇 Rei/Rainha dos Placares Exatos' Selo,
    'Maior quantidade de placares exatos' Descricao,
    Valor
FROM dbo.vw_Selo_001_Placar_Exato

UNION ALL

SELECT 
    NomeBolao,
    UserName,
    '002',
    '🧱 Mestre do Resultado',
    'Maior quantidade de vencedor ou empate acertado',
    Valor
FROM dbo.vw_Selo_002_Mestre_Resultado

UNION ALL

SELECT 
    NomeBolao,
    UserName,
    '003',
    '🇧🇷 Especialista no Brasil',
    'Maior pontuação nos jogos do Brasil',
    Valor
FROM dbo.vw_Selo_003_Especialista_Brasil

UNION ALL

SELECT 
    NomeBolao,
    UserName,
    '004',
    '🤝 Rei/Rainha dos Empates',
    'Maior quantidade de empates acertados',
    Valor
FROM dbo.vw_Selo_004_Empates

UNION ALL

SELECT 
    NomeBolao,
    UserName,
    '005',
    '⚽ Rei/Rainha do 1x0',
    'Maior quantidade de placares 1x0',
    Valor
FROM dbo.vw_Selo_005_1x0

UNION ALL

SELECT 
    NomeBolao,
    UserName,
    '006',
    '🔥 Especialista em Goleadas',
    'Mais goleadas acertadas',
    Valor
FROM dbo.vw_Selo_006_Goleadas

UNION ALL

SELECT 
    NomeBolao,
    UserName,
    '007',
    '📈 Maior Pontuação em Rodada',
    'Maior pontuação conquistada em uma rodada',
    Valor
FROM dbo.vw_Selo_007_Maior_Pontuacao_Rodada

UNION ALL

SELECT 
    NomeBolao,
    UserName,
    '008',
    '🏆 Mestre das Apostas Extras',
    'Maior pontuação nas apostas extras',
    Valor
FROM dbo.vw_Selo_008_Apostas_Extras

UNION ALL

SELECT 
    NomeBolao,
    UserName,
    '009',
    '🎯 Aposta Extra Mais Difícil',
    'Acertou uma das apostas extras mais improváveis',
    Valor
FROM dbo.vw_Selo_009_Aposta_Extra_Dificil

--UNION ALL

--SELECT 
--    NomeBolao,
--    UserName,
--    '010',
--    '💯 Colecionador dos 10 Pontos',
--    'Maior quantidade de acertos máximos',
--    Valor
--FROM dbo.vw_Selo_010_Colecionador_10_Pontos

--UNION ALL

--SELECT 
--    NomeBolao,
--    UserName,
--    '011',
--    '🔥 Pé Quente do Brasil',
--    'Melhor desempenho nos jogos do Brasil',
--    Valor
--FROM dbo.vw_Selo_011_Pe_Quente_Brasil

UNION ALL

SELECT 
    NomeBolao,
    UserName,
    '012',
    '🦓 Rei das Zebras',
    'Maior quantidade de resultados improváveis',
    Valor
FROM dbo.vw_Selo_012_Rei_Zebras

UNION ALL

SELECT 
    NomeBolao,
    UserName,
    '013',
    '🚀 Arrancada Final',
    'Melhor recuperação na competição',
    Valor
FROM dbo.vw_Selo_013_Arrancada_Final

UNION ALL

SELECT 
    NomeBolao,
    UserName,
    '014',
    '👑 Líder de Quantidade',
    'Maior quantidade de jogos pontuados',
    Valor
FROM dbo.vw_Selo_014_Lider_Quantidade

--UNION ALL

--SELECT 
--    NomeBolao,
--    UserName,
--    '015',
--    '🏆 Último Lendário',
--    'Destaque nos jogos finais',
--    Valor
--FROM dbo.vw_Selo_015_Ultimo_Lendario

UNION ALL

SELECT 
    NomeBolao,
    UserName,
    '017',
    '🧮 Matemático do Bolão',
    'Melhores previsões estatísticas',
    Valor
FROM dbo.vw_Selo_017_Matematico

UNION ALL

SELECT 
    NomeBolao,
    UserName,
    '020',
    '⚽ Rei dos Gols',
    'Maior quantidade de gols previstos',
    Valor
FROM dbo.vw_Selo_020_Rei_Gols

UNION ALL

SELECT 
    NomeBolao,
    UserName,
    '021',
    '🥅 Mestre dos Artilheiros',
    'Melhores palpites envolvendo artilheiros',
    Valor
FROM dbo.vw_Selo_021_Mestre_Artilheiros

UNION ALL

SELECT 
    NomeBolao,
    UserName,
    '022',
    '🏟️ Mestre do Mata-Mata',
    'Melhor desempenho nas fases eliminatórias',
    Valor
FROM dbo.vw_Selo_022_Mestre_MataMata

UNION ALL

SELECT 
    NomeBolao,
    UserName,
    '023',
    '🌎 Rei da Fase de Grupos',
    'Melhor desempenho na fase de grupos',
    Valor
FROM dbo.vw_Selo_023_Fase_Grupos

UNION ALL

SELECT 
    NomeBolao,
    UserName,
    '024',
    '🏅 Campeão Moral',
    'Maior destaque sem levar o título',
    Valor
FROM dbo.vw_Selo_024_Campeao_Moral

UNION ALL

SELECT 
    NomeBolao,
    UserName,
    '025',
    '🎲 Apostador Ousado',
    'Melhores apostas de risco',
    Valor
FROM dbo.vw_Selo_025_Apostador_Ousado

UNION ALL

SELECT 
    NomeBolao,
    UserName,
    '026',
    '🍀 Mais Sortudo',
    'Virou acerto nos minutos finais',
    Valor
FROM dbo.vw_Selo_026_Mais_Sortudo

UNION ALL

SELECT 
    NomeBolao,
    UserName,
    '027',
    '😭 Mais Azarado',
    'Perdeu acerto nos minutos finais',
    Valor
FROM dbo.vw_Selo_027_Mais_Azarado

--UNION ALL

--SELECT 
--    NomeBolao,
--    UserName,
--    '028',
--    '🎭 Drama Final',
--    'Jogo decidido no último momento',
--    Valor
--FROM dbo.vw_Selo_028_Drama_Final;

GO

/****** Object:  View [dbo].[vw_Email_Resumo_Selos_Participante]    Script Date: 19/07/2026 12:29:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE   VIEW [dbo].[vw_Email_Resumo_Selos_Participante]
AS

SELECT

    NomeBolao,

    UserName,

    COUNT(*) AS TotalSelos,


    STRING_AGG
    (
        Selo + ' - ' + Descricao,
        ' | '
    ) AS Selos


FROM vw_Email_Todos_Selos


GROUP BY

    NomeBolao,

    UserName;

GO

/****** Object:  View [dbo].[vw_Evolucao_Placar_Jogo]    Script Date: 19/07/2026 12:29:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE   VIEW [dbo].[vw_Evolucao_Placar_Jogo]
AS

WITH EventosGol AS
(
    SELECT

        J.NomeCampeonato,

        J.JogoId,

        J.ExternalId,

        E.Id AS EventoId,

        E.Minute,

        ISNULL(E.ExtraMinute,0) AS ExtraMinute,

        E.TeamName,

        E.IsHomeTeam,


        ROW_NUMBER() OVER
        (
            PARTITION BY 
                J.NomeCampeonato,
                J.JogoId

            ORDER BY

                ISNULL(E.Minute,0),

                ISNULL(E.ExtraMinute,0),

                E.Id

        ) AS OrdemEvento


    FROM Jogos J


    INNER JOIN ApiMatchEvents E

        ON E.MatchKeyId = J.ExternalId


    WHERE

        E.EventType = 'Goal'
),


PlacarCalculado AS
(
    SELECT

        NomeCampeonato,

        JogoId,

        ExternalId,

        EventoId,

        Minute,

        ExtraMinute,

        TeamName,


        SUM
        (
            CASE
                WHEN IsHomeTeam = 1
                THEN 1
                ELSE 0
            END
        )
        OVER
        (
            PARTITION BY 
                NomeCampeonato,
                JogoId

            ORDER BY OrdemEvento

            ROWS BETWEEN UNBOUNDED PRECEDING 
            AND CURRENT ROW

        ) AS GolsTime1,


        SUM
        (
            CASE
                WHEN IsHomeTeam = 0
                THEN 1
                ELSE 0
            END
        )
        OVER
        (
            PARTITION BY 
                NomeCampeonato,
                JogoId

            ORDER BY OrdemEvento

            ROWS BETWEEN UNBOUNDED PRECEDING 
            AND CURRENT ROW

        ) AS GolsTime2


    FROM EventosGol
)


SELECT

    NomeCampeonato,

    JogoId,

    ExternalId,

    EventoId,

    Minute,

    ExtraMinute,

    TeamName,

    GolsTime1,

    GolsTime2


FROM PlacarCalculado;

GO

/****** Object:  View [dbo].[vw_Selo_028_Drama_Final]    Script Date: 19/07/2026 12:29:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE   VIEW [dbo].[vw_Selo_028_Drama_Final]
AS

WITH Ranking AS
(
SELECT

JU.NomeBolao,

JU.UserName,

COUNT(*) Quantidade,


DENSE_RANK() OVER
(
PARTITION BY JU.NomeBolao

ORDER BY COUNT(*) DESC

) Posicao


FROM JogosUsuarios JU


INNER JOIN Jogos J

ON J.NomeCampeonato=JU.NomeCampeonato
AND J.JogoId=JU.JogoId


INNER JOIN ApiMatchEvents E

ON E.MatchKeyId=J.ExternalId


WHERE

E.Minute>=90


GROUP BY

JU.NomeBolao,

JU.UserName
)


SELECT

NomeBolao,

UserName,

'🎰 REI DO DRAMA FINAL' AS Selo,

'Mais jogos decididos depois dos 90 minutos' AS Descricao,

Quantidade AS Valor


FROM Ranking

WHERE Posicao=1;

GO

/****** Object:  View [dbo].[vw_Selo_Placar_Exato]    Script Date: 19/07/2026 12:29:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE   VIEW [dbo].[vw_Selo_Placar_Exato]
AS

WITH Ranking AS
(
    SELECT

        NomeBolao,
        UserName,

        COUNT(*) AS Quantidade,


        DENSE_RANK() OVER
        (
            PARTITION BY NomeBolao
            ORDER BY COUNT(*) DESC
        ) AS Posicao


    FROM JogosUsuarios

    WHERE IsPlacarCheio=1

    GROUP BY
        NomeBolao,
        UserName
)

SELECT

    NomeBolao,
    UserName,

    '🎯 REI/RAINHA DOS PLACARES EXATOS' AS Selo,

    'Maior quantidade de placares cravados' AS Descricao,

    Quantidade AS Valor

FROM Ranking

WHERE Posicao=1;
GO

/****** Object:  View [dbo].[vw_Ultimo_Gol_Jogo]    Script Date: 19/07/2026 12:29:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE   VIEW [dbo].[vw_Ultimo_Gol_Jogo]
AS

WITH UltimoGol AS
(
    SELECT

        J.NomeCampeonato,

        J.JogoId,

        J.ExternalId,

        E.Id AS EventoId,

        E.Minute,

        ISNULL(E.ExtraMinute,0) AS ExtraMinute,

        E.IsHomeTeam,


        ROW_NUMBER() OVER
        (
            PARTITION BY 
                J.NomeCampeonato,
                J.JogoId

            ORDER BY

                ISNULL(E.Minute,0) DESC,

                ISNULL(E.ExtraMinute,0) DESC,

                E.Id DESC

        ) AS RN


    FROM Jogos J

    INNER JOIN ApiMatchEvents E

        ON E.MatchKeyId = J.ExternalId


    WHERE

        E.EventType = 'Goal'
)


SELECT

    NomeCampeonato,

    JogoId,

    ExternalId,

    EventoId,

    Minute,

    ExtraMinute,

    IsHomeTeam


FROM UltimoGol

WHERE RN = 1;

GO

