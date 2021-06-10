    
CREATE TABLE [dbo].[Jogos](
	[NomeCampeonato] [varchar](150) NOT NULL,
	[JogoId] [int] NOT NULL,
	[NomeTime1] [varchar](150) NULL,
	[DescricaoTime1] [varchar](100) NULL,
	[GolsTime1] [int] NOT NULL,
	[PenaltisTime1] [int] NULL,
	[NomeTime2] [varchar](150) NULL,
	[DescricaoTime2] [varchar](100) NULL,
	[GolsTime2] [int] NOT NULL,
	[PenaltisTime2] [int] NULL,
	[NomeEstadio] [varchar](50) NULL,
	[DataJogo] [datetime] NOT NULL,
	[Rodada] [int] NOT NULL,
	[PartidaValida] [bit] NOT NULL,
	[DataValidacao] [datetime] NULL,
	[NomeFase] [varchar](50) NULL,
	[NomeGrupo] [varchar](20) NULL,
	[IsValido] [bit] NOT NULL,
	[ValidadoBy] [varchar](250) NULL,
	[Titulo] [varchar](100) NULL,
	[PendenteIdTime1] [int] NOT NULL,
	[PendenteIdTime2] [int] NOT NULL,
	[PendenteTime1Ganhador] [bit] NOT NULL,
	[PendenteTime2Ganhador] [bit] NOT NULL,
	[PendenteTime1NomeGrupo] [varchar](20) NULL,
	[PendenteTime2NomeGrupo] [varchar](20) NULL,
	[PendenteTime1PosGrupo] [int] NOT NULL,
	[PendenteTime2PosGrupo] [int] NOT NULL,
	[PendenteTime1MelhorGrupos] [bit] NULL,
	[PendenteTime2MelhorGrupos] [bit] NULL,
	[IsDesempate] [bit] NULL,
	[CreatedBy] [varchar](25) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [varchar](25) NULL,
	[ModifiedDate] [datetime] NULL,
	[ActiveFlag] [smallint] NULL,
 CONSTRAINT [PK_dbo.Jogos] PRIMARY KEY CLUSTERED 
(
	[NomeCampeonato] ASC,
	[JogoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

----SET ANSI_PADDING OFF
----GO

--ALTER TABLE [dbo].[Jogos]  ADD  CONSTRAINT FK_Jogos_CampeonatosGrupos_PendenteTime2 FOREIGN KEY([PendenteTime2NomeGrupo], [NomeCampeonato])
--REFERENCES [dbo].[CampeonatosGrupos] ([Nome], [NomeCampeonato])
--GO

--ALTER TABLE [dbo].[Jogos]  ADD  CONSTRAINT FK_Jogos_CampeonatosGrupos_PendenteTime1 FOREIGN KEY([PendenteTime1NomeGrupo], [NomeCampeonato])
--REFERENCES [dbo].[CampeonatosGrupos] ([Nome], [NomeCampeonato])
--GO

--ALTER TABLE [dbo].[Jogos]  ADD  CONSTRAINT FK_Jogos_CampeonatosGrupos_NomeGrupo_NomeCampeonato FOREIGN KEY([NomeGrupo], [NomeCampeonato])
--REFERENCES [dbo].[CampeonatosGrupos] ([Nome], [NomeCampeonato])
--GO

--ALTER TABLE [dbo].[Jogos]  ADD  CONSTRAINT FK_Jogos_CampeonatosFases_NomeCampeonato_NomeFase FOREIGN KEY([NomeCampeonato], [NomeFase])
--REFERENCES [dbo].[CampeonatosFases] ([NomeCampeonato], [Nome])
--GO

--ALTER TABLE [dbo].[Jogos]  ADD  CONSTRAINT FK_Jogos_CampeonatosTimes_NomeCampeonato_NomeTime1 FOREIGN KEY([NomeCampeonato], [NomeTime1])
--REFERENCES [dbo].[CampeonatosTimes] ([NomeCampeonato], [NomeTime])
--GO

--ALTER TABLE [dbo].[Jogos]  ADD  CONSTRAINT FK_Jogos_CampeonatosTimes_NomeCampeonato_NomeTIme2 FOREIGN KEY([NomeCampeonato], [NomeTime2])
--REFERENCES [dbo].[CampeonatosTimes] ([NomeCampeonato], [NomeTime])
--GO

----ALTER TABLE [dbo].[Jogos]  ADD FOREIGN KEY([CreatedBy])
----REFERENCES [dbo].[Users] ([UserName])
----GO

----ALTER TABLE [dbo].[Jogos]  ADD FOREIGN KEY([ModifiedBy])
----REFERENCES [dbo].[Users] ([UserName])
----GO

--ALTER TABLE [dbo].[Jogos]  ADD  CONSTRAINT FK_Jogos_Campeonatos_NomeCampeonato FOREIGN KEY([NomeCampeonato])
--REFERENCES [dbo].[Campeonatos] ([Nome])
--GO

--ALTER TABLE [dbo].[Jogos]  ADD  CONSTRAINT FK_Jogos_Estadios_NomeEstadio FOREIGN KEY([NomeEstadio])
--REFERENCES [dbo].[Estadios] ([Nome])
--GO

--ALTER TABLE [dbo].[Jogos]  ADD  CONSTRAINT FK_Jogos_Users_ValidadoBy FOREIGN KEY([ValidadoBy])
--REFERENCES [dbo].[Users] ([UserName])
--GO


ALTER TABLE [dbo].[Jogos]   ADD  CONSTRAINT [FK_dbo.Jogos_dbo.Campeonatos_NomeCampeonato] FOREIGN KEY([NomeCampeonato])
REFERENCES [dbo].[Campeonatos] ([Nome])
GO
ALTER TABLE [dbo].[Jogos] CHECK CONSTRAINT [FK_dbo.Jogos_dbo.Campeonatos_NomeCampeonato]
GO
ALTER TABLE [dbo].[Jogos]   ADD  CONSTRAINT [FK_dbo.Jogos_dbo.CampeonatosFases_NomeCampeonato_NomeFase] FOREIGN KEY([NomeCampeonato], [NomeFase])
REFERENCES [dbo].[CampeonatosFases] ([NomeCampeonato], [Nome])
GO
ALTER TABLE [dbo].[Jogos] CHECK CONSTRAINT [FK_dbo.Jogos_dbo.CampeonatosFases_NomeCampeonato_NomeFase]
GO
ALTER TABLE [dbo].[Jogos]   ADD  CONSTRAINT [FK_dbo.Jogos_dbo.CampeonatosGrupos_NomeCampeonato_NomeGrupo] FOREIGN KEY([NomeCampeonato], [NomeGrupo])
REFERENCES [dbo].[CampeonatosGrupos] ([NomeCampeonato], [Nome])
GO
ALTER TABLE [dbo].[Jogos] CHECK CONSTRAINT [FK_dbo.Jogos_dbo.CampeonatosGrupos_NomeCampeonato_NomeGrupo]
GO
ALTER TABLE [dbo].[Jogos]   ADD  CONSTRAINT [FK_dbo.Jogos_dbo.Estadios_NomeEstadio] FOREIGN KEY([NomeEstadio])
REFERENCES [dbo].[Estadios] ([Nome])
GO
ALTER TABLE [dbo].[Jogos] CHECK CONSTRAINT [FK_dbo.Jogos_dbo.Estadios_NomeEstadio]
GO
ALTER TABLE [dbo].[Jogos]   ADD  CONSTRAINT [FK_dbo.Jogos_dbo.Times_NomeTime1] FOREIGN KEY([NomeTime1])
REFERENCES [dbo].[Times] ([Nome])
GO
ALTER TABLE [dbo].[Jogos] CHECK CONSTRAINT [FK_dbo.Jogos_dbo.Times_NomeTime1]
GO
ALTER TABLE [dbo].[Jogos]   ADD  CONSTRAINT [FK_dbo.Jogos_dbo.Times_NomeTime2] FOREIGN KEY([NomeTime2])
REFERENCES [dbo].[Times] ([Nome])
GO
ALTER TABLE [dbo].[Jogos] CHECK CONSTRAINT [FK_dbo.Jogos_dbo.Times_NomeTime2]
GO
