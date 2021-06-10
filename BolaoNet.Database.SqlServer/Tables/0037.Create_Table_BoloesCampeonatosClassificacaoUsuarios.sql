
CREATE TABLE [dbo].[BoloesCampeonatosClassificacaoUsuarios](
	[NomeCampeonato] [varchar](150) NOT NULL,
	[NomeFase] [varchar](50) NOT NULL,
	[NomeGrupo] [varchar](20) NOT NULL,
	[NomeTime] [varchar](150) NOT NULL,
	[NomeBolao] [varchar](100) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Posicao] [int] NULL,
	[TotalVitorias] [int] NULL,
	[TotalDerrotas] [int] NULL,
	[TotalEmpates] [int] NULL,
	[TotalGolsContra] [int] NULL,
	[TotalGolsPro] [int] NULL,
	[TotalPontos] [int] NULL,
	[CreatedBy] [varchar](25) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [varchar](25) NULL,
	[ModifiedDate] [datetime] NULL,
	[ActiveFlag] [smallint] NULL,
 CONSTRAINT [PK_dbo.BoloesCampeonatosClassificacaoUsuarios] PRIMARY KEY CLUSTERED 
(
	[NomeCampeonato] ASC,
	[NomeFase] ASC,
	[NomeGrupo] ASC,
	[NomeTime] ASC,
	[NomeBolao] ASC,
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


--ALTER TABLE [dbo].[BoloesCampeonatosClassificacaoUsuarios]  ADD FOREIGN KEY([CreatedBy])
--REFERENCES [dbo].[Users] ([UserName])
--GO

--ALTER TABLE [dbo].[BoloesCampeonatosClassificacaoUsuarios]  ADD FOREIGN KEY([ModifiedBy])
--REFERENCES [dbo].[Users] ([UserName])
----GO

--ALTER TABLE [dbo].[BoloesCampeonatosClassificacaoUsuarios]  ADD  CONSTRAINT FK_BoloesCampeonatosClassificacaoUsuarios_Boloes_Nome FOREIGN KEY([NomeBolao])
--REFERENCES [dbo].[Boloes] ([Nome])
--GO

--ALTER TABLE [dbo].[BoloesCampeonatosClassificacaoUsuarios]  ADD  CONSTRAINT FK_BoloesCampeonatosClassificacaoUsuarios_Campeonatos_Nome FOREIGN KEY([NomeCampeonato])
--REFERENCES [dbo].[Campeonatos] ([Nome])
--GO

--ALTER TABLE [dbo].[BoloesCampeonatosClassificacaoUsuarios]  ADD  CONSTRAINT FK_BoloesCampeonatosClassificacaoUsuarios_Times_Nome FOREIGN KEY([NomeTime])
--REFERENCES [dbo].[Times] ([Nome])
--GO

--ALTER TABLE [dbo].[BoloesCampeonatosClassificacaoUsuarios]  ADD  CONSTRAINT FK_BoloesCampeonatosClassificacaoUsuarios_Users_UserName FOREIGN KEY([UserName])
--REFERENCES [dbo].[Users] ([UserName])
--GO

--ALTER TABLE [dbo].[BoloesCampeonatosClassificacaoUsuarios]  ADD CONSTRAINT FK_BoloesCampeonatosClassificacaoUsuarios_CampeonatosGrupos_Nome_NomeCampeonato FOREIGN KEY([NomeGrupo], [NomeCampeonato])
--REFERENCES [dbo].[CampeonatosGrupos] ([Nome], [NomeCampeonato])
--GO

--ALTER TABLE [dbo].[BoloesCampeonatosClassificacaoUsuarios]  ADD CONSTRAINT FK_BoloesCampeonatosClassificacaoUsuarios_CampeonatosFases_NomeCampeonato_Nome FOREIGN KEY([NomeCampeonato], [NomeFase])
--REFERENCES [dbo].[CampeonatosFases] ([NomeCampeonato], [Nome])
--GO


ALTER TABLE [dbo].[BoloesCampeonatosClassificacaoUsuarios]   ADD  CONSTRAINT [FK_dbo.BoloesCampeonatosClassificacaoUsuarios_dbo.Boloes_NomeBolao] FOREIGN KEY([NomeBolao])
REFERENCES [dbo].[Boloes] ([Nome])
GO
ALTER TABLE [dbo].[BoloesCampeonatosClassificacaoUsuarios] CHECK CONSTRAINT [FK_dbo.BoloesCampeonatosClassificacaoUsuarios_dbo.Boloes_NomeBolao]
GO
ALTER TABLE [dbo].[BoloesCampeonatosClassificacaoUsuarios]   ADD  CONSTRAINT [FK_dbo.BoloesCampeonatosClassificacaoUsuarios_dbo.CampeonatosFases_NomeCampeonato_NomeFase] FOREIGN KEY([NomeCampeonato], [NomeFase])
REFERENCES [dbo].[CampeonatosFases] ([NomeCampeonato], [Nome])
GO
ALTER TABLE [dbo].[BoloesCampeonatosClassificacaoUsuarios] CHECK CONSTRAINT [FK_dbo.BoloesCampeonatosClassificacaoUsuarios_dbo.CampeonatosFases_NomeCampeonato_NomeFase]
GO
ALTER TABLE [dbo].[BoloesCampeonatosClassificacaoUsuarios]   ADD  CONSTRAINT [FK_dbo.BoloesCampeonatosClassificacaoUsuarios_dbo.CampeonatosGrupos_NomeCampeonato_NomeGrupo] FOREIGN KEY([NomeCampeonato], [NomeGrupo])
REFERENCES [dbo].[CampeonatosGrupos] ([NomeCampeonato], [Nome])
GO
ALTER TABLE [dbo].[BoloesCampeonatosClassificacaoUsuarios] CHECK CONSTRAINT [FK_dbo.BoloesCampeonatosClassificacaoUsuarios_dbo.CampeonatosGrupos_NomeCampeonato_NomeGrupo]
GO
ALTER TABLE [dbo].[BoloesCampeonatosClassificacaoUsuarios]   ADD  CONSTRAINT [FK_dbo.BoloesCampeonatosClassificacaoUsuarios_dbo.Times_NomeTime] FOREIGN KEY([NomeTime])
REFERENCES [dbo].[Times] ([Nome])
GO
ALTER TABLE [dbo].[BoloesCampeonatosClassificacaoUsuarios] CHECK CONSTRAINT [FK_dbo.BoloesCampeonatosClassificacaoUsuarios_dbo.Times_NomeTime]
GO
ALTER TABLE [dbo].[BoloesCampeonatosClassificacaoUsuarios]   ADD  CONSTRAINT [FK_dbo.BoloesCampeonatosClassificacaoUsuarios_dbo.Usuarios_UserName] FOREIGN KEY([UserName])
REFERENCES [dbo].[Usuarios] ([UserName])
GO
ALTER TABLE [dbo].[BoloesCampeonatosClassificacaoUsuarios] CHECK CONSTRAINT [FK_dbo.BoloesCampeonatosClassificacaoUsuarios_dbo.Usuarios_UserName]
GO
