  
CREATE TABLE [dbo].[BoloesPontosRodadas](
	[NomeCampeonato] [varchar](150) NOT NULL,
	[NomeFase] [varchar](50) NOT NULL,
	[NomeGrupo] [varchar](20) NOT NULL,
	[NomeBolao] [varchar](100) NOT NULL,
	[Posicao] [int] NOT NULL,
	[Titulo] [varchar](150) NULL,
	[Pontos] [int] NOT NULL,
	[DataValidacao] [datetime] NOT NULL,
	[CreatedBy] [varchar](25) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [varchar](25) NULL,
	[ModifiedDate] [datetime] NULL,
	[ActiveFlag] [smallint] NULL,
 CONSTRAINT [PK_dbo.BoloesPontosRodadas] PRIMARY KEY CLUSTERED 
(
	[NomeCampeonato] ASC,
	[NomeFase] ASC,
	[NomeGrupo] ASC,
	[NomeBolao] ASC,
	[Posicao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


----ALTER TABLE [dbo].[BoloesPontosRodadas]  ADD FOREIGN KEY([CreatedBy])
----REFERENCES [dbo].[Users] ([UserName])
----GO

----ALTER TABLE [dbo].[BoloesPontosRodadas]  ADD FOREIGN KEY([ModifiedBy])
----REFERENCES [dbo].[Users] ([UserName])
----GO

--ALTER TABLE [dbo].[BoloesPontosRodadas]  ADD CONSTRAINT FK_BoloesPontosRodadas_Boloes_NomeBolao  FOREIGN KEY([NomeBolao])
--REFERENCES [dbo].[Boloes] ([Nome])
--GO

--ALTER TABLE [dbo].[BoloesPontosRodadas]  ADD  CONSTRAINT FK_BoloesPontosRodadas_CampeonatosFases_NomeCampeonato_Nome FOREIGN KEY([NomeCampeonato], [NomeFase])
--REFERENCES [dbo].[CampeonatosFases] ([NomeCampeonato], [Nome])
--GO

--ALTER TABLE [dbo].[BoloesPontosRodadas]  ADD  CONSTRAINT FK_BoloesPontosRodadas_CampeonatosGrupos_Nome_NomeCampeonato FOREIGN KEY([NomeGrupo], [NomeCampeonato])
--REFERENCES [dbo].[CampeonatosGrupos] ([Nome], [NomeCampeonato])
--GO


ALTER TABLE [dbo].[BoloesPontosRodadas]   ADD  CONSTRAINT [FK_dbo.BoloesPontosRodadas_dbo.Boloes_NomeBolao] FOREIGN KEY([NomeBolao])
REFERENCES [dbo].[Boloes] ([Nome])
GO
ALTER TABLE [dbo].[BoloesPontosRodadas] CHECK CONSTRAINT [FK_dbo.BoloesPontosRodadas_dbo.Boloes_NomeBolao]
GO
ALTER TABLE [dbo].[BoloesPontosRodadas]   ADD  CONSTRAINT [FK_dbo.BoloesPontosRodadas_dbo.CampeonatosFases_NomeCampeonato_NomeFase] FOREIGN KEY([NomeCampeonato], [NomeFase])
REFERENCES [dbo].[CampeonatosFases] ([NomeCampeonato], [Nome])
GO
ALTER TABLE [dbo].[BoloesPontosRodadas] CHECK CONSTRAINT [FK_dbo.BoloesPontosRodadas_dbo.CampeonatosFases_NomeCampeonato_NomeFase]
GO
ALTER TABLE [dbo].[BoloesPontosRodadas]   ADD  CONSTRAINT [FK_dbo.BoloesPontosRodadas_dbo.CampeonatosGrupos_NomeCampeonato_NomeGrupo] FOREIGN KEY([NomeCampeonato], [NomeGrupo])
REFERENCES [dbo].[CampeonatosGrupos] ([NomeCampeonato], [Nome])
GO
ALTER TABLE [dbo].[BoloesPontosRodadas] CHECK CONSTRAINT [FK_dbo.BoloesPontosRodadas_dbo.CampeonatosGrupos_NomeCampeonato_NomeGrupo]
GO