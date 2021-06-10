CREATE TABLE [dbo].[CampeonatosPosicoes](
	[NomeCampeonato] [varchar](150) NOT NULL,
	[NomeFase] [varchar](50) NOT NULL,
	[NomeGrupo] [varchar](20) NOT NULL,
	[Posicao] [int] NOT NULL,
	[Titulo] [varchar](100) NULL,
	[ForeColorName] [varchar](50) NULL,
	[BackColorName] [varchar](50) NULL,
	[CreatedBy] [varchar](25) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [varchar](25) NULL,
	[ModifiedDate] [datetime] NULL,
	[ActiveFlag] [smallint] NULL,
 CONSTRAINT [PK_dbo.CampeonatosPosicoes] PRIMARY KEY CLUSTERED 
(
	[NomeCampeonato] ASC,
	[NomeFase] ASC,
	[NomeGrupo] ASC,
	[Posicao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

----SET ANSI_PADDING OFF
----GO

----ALTER TABLE [dbo].[CampeonatosPosicoes]  ADD FOREIGN KEY([CreatedBy])
----REFERENCES [dbo].[Users] ([UserName])
----GO

----ALTER TABLE [dbo].[CampeonatosPosicoes]  ADD FOREIGN KEY([ModifiedBy])
----REFERENCES [dbo].[Users] ([UserName])
----GO

--ALTER TABLE [dbo].[CampeonatosPosicoes]  ADD CONSTRAINT FK_CampeonatosPosicoes_CampeonatosGrupos_NomeCampeonato  FOREIGN KEY([NomeGrupo], [NomeCampeonato])
--REFERENCES [dbo].[CampeonatosGrupos] ([Nome], [NomeCampeonato])
--GO

--ALTER TABLE [dbo].[CampeonatosPosicoes]  ADD  CONSTRAINT FK_CampeonatosPosicoes_CampeonatosFases_NomeCampeonato_Nome FOREIGN KEY([NomeCampeonato], [NomeFase])
--REFERENCES [dbo].[CampeonatosFases] ([NomeCampeonato], [Nome])
--GO


ALTER TABLE [dbo].[CampeonatosPosicoes]   ADD  CONSTRAINT [FK_dbo.CampeonatosPosicoes_dbo.CampeonatosFases_NomeCampeonato_NomeFase] FOREIGN KEY([NomeCampeonato], [NomeFase])
REFERENCES [dbo].[CampeonatosFases] ([NomeCampeonato], [Nome])
GO
ALTER TABLE [dbo].[CampeonatosPosicoes] CHECK CONSTRAINT [FK_dbo.CampeonatosPosicoes_dbo.CampeonatosFases_NomeCampeonato_NomeFase]
GO
ALTER TABLE [dbo].[CampeonatosPosicoes]   ADD  CONSTRAINT [FK_dbo.CampeonatosPosicoes_dbo.CampeonatosGrupos_NomeCampeonato_NomeGrupo] FOREIGN KEY([NomeCampeonato], [NomeGrupo])
REFERENCES [dbo].[CampeonatosGrupos] ([NomeCampeonato], [Nome])
GO
ALTER TABLE [dbo].[CampeonatosPosicoes] CHECK CONSTRAINT [FK_dbo.CampeonatosPosicoes_dbo.CampeonatosGrupos_NomeCampeonato_NomeGrupo]
GO
