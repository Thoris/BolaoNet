﻿CREATE TABLE [dbo].[Jogos](
	[NomeCampeonato] [varchar](50) NOT NULL,
	[IdJogo] [int] IDENTITY(1,1) NOT NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[Titulo] [varchar](100) NULL,
	[ActiveFlag] [bit] NULL,
	[CreatedBy] [varchar](25) NULL,
	[ModifiedBy] [varchar](25) NULL,
	[NomeTime1] [varchar](30) NULL,
	[DescricaoTime1] [varchar](255) NULL,
	[NomeTime2] [varchar](30) NULL,
	[NomeFase] [varchar](30) NULL,
	[NomeGrupo] [varchar](20) NULL,
	[Gols1] [smallint] NULL,
	[Gols2] [smallint] NULL,
	[DescricaoTime2] [varchar](255) NULL,
	[Penaltis1] [smallint] NULL,
	[Penaltis2] [smallint] NULL,
	[DataJogo] [datetime] NULL,
	[Rodada] [int] NULL,
	[IsValido] [bit] NULL,
	[DataValidacao] [datetime] NULL,
	[ValidadoBy] [varchar](25) NULL,
	[NomeEstadio] [varchar](30) NULL,
	[PendenteTime1NomeGrupo] [varchar](20) NULL,
	[PendenteTime1PosGrupo] [int] NULL,
	[PendenteTime1MelhorGrupos] [bit] NULL,
	[PendenteTime1JogoID] [int] NULL,
	[PendenteTime1Ganhador] [bit] NULL,
	[PendenteTime2NomeGrupo] [varchar](20) NULL,
	[PendenteTime2PosGrupo] [int] NULL,
	[PendenteTime2JogoID] [int] NULL,
	[PendenteTime2Ganhador] [bit] NULL,
	[PendenteTime2MelhorGrupos] [bit] NULL,
	[JogoLabel] [varchar](5) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdJogo] ASC,
	[NomeCampeonato] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

--SET ANSI_PADDING OFF
--GO

ALTER TABLE [dbo].[Jogos]  ADD  CONSTRAINT FK_Jogos_CampeonatosGrupos_PendenteTime2 FOREIGN KEY([PendenteTime2NomeGrupo], [NomeCampeonato])
REFERENCES [dbo].[CampeonatosGrupos] ([Nome], [NomeCampeonato])
GO

ALTER TABLE [dbo].[Jogos]  ADD  CONSTRAINT FK_Jogos_CampeonatosGrupos_PendenteTime1 FOREIGN KEY([PendenteTime1NomeGrupo], [NomeCampeonato])
REFERENCES [dbo].[CampeonatosGrupos] ([Nome], [NomeCampeonato])
GO

ALTER TABLE [dbo].[Jogos]  ADD  CONSTRAINT FK_Jogos_CampeonatosGrupos_NomeGrupo_NomeCampeonato FOREIGN KEY([NomeGrupo], [NomeCampeonato])
REFERENCES [dbo].[CampeonatosGrupos] ([Nome], [NomeCampeonato])
GO

ALTER TABLE [dbo].[Jogos]  ADD  CONSTRAINT FK_Jogos_CampeonatosFases_NomeCampeonato_NomeFase FOREIGN KEY([NomeCampeonato], [NomeFase])
REFERENCES [dbo].[CampeonatosFases] ([NomeCampeonato], [Nome])
GO

ALTER TABLE [dbo].[Jogos]  ADD  CONSTRAINT FK_Jogos_CampeonatosTimes_NomeCampeonato_NomeTime1 FOREIGN KEY([NomeCampeonato], [NomeTime1])
REFERENCES [dbo].[CampeonatosTimes] ([NomeCampeonato], [NomeTime])
GO

ALTER TABLE [dbo].[Jogos]  ADD  CONSTRAINT FK_Jogos_CampeonatosTimes_NomeCampeonato_NomeTIme2 FOREIGN KEY([NomeCampeonato], [NomeTime2])
REFERENCES [dbo].[CampeonatosTimes] ([NomeCampeonato], [NomeTime])
GO

--ALTER TABLE [dbo].[Jogos]  ADD FOREIGN KEY([CreatedBy])
--REFERENCES [dbo].[Users] ([UserName])
--GO

--ALTER TABLE [dbo].[Jogos]  ADD FOREIGN KEY([ModifiedBy])
--REFERENCES [dbo].[Users] ([UserName])
--GO

ALTER TABLE [dbo].[Jogos]  ADD  CONSTRAINT FK_Jogos_Campeonatos_NomeCampeonato FOREIGN KEY([NomeCampeonato])
REFERENCES [dbo].[Campeonatos] ([Nome])
GO

ALTER TABLE [dbo].[Jogos]  ADD  CONSTRAINT FK_Jogos_Estadios_NomeEstadio FOREIGN KEY([NomeEstadio])
REFERENCES [dbo].[Estadios] ([Nome])
GO

ALTER TABLE [dbo].[Jogos]  ADD  CONSTRAINT FK_Jogos_Users_ValidadoBy FOREIGN KEY([ValidadoBy])
REFERENCES [dbo].[Users] ([UserName])
GO
