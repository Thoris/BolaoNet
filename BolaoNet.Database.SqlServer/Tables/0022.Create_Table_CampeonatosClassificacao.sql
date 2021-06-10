
CREATE TABLE [dbo].[CampeonatosClassificacao](
	[NomeCampeonato] [varchar](150) NOT NULL,
	[NomeFase] [varchar](50) NOT NULL,
	[NomeGrupo] [varchar](20) NOT NULL,
	[NomeTime] [varchar](150) NOT NULL,
	[Rodada] [int] NOT NULL,
	[Posicao] [int] NULL,
	[LastPosicao] [int] NULL,
	[TotalVitorias] [int] NULL,
	[TotalDerrotas] [int] NULL,
	[TotalEmpates] [int] NULL,
	[TotalGolsContra] [int] NULL,
	[TotalGolsPro] [int] NULL,
	[TotalPontos] [int] NULL,
	[Jogos] [int] NULL,
	[Saldo] [int] NULL,
	[CreatedBy] [varchar](25) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [varchar](25) NULL,
	[ModifiedDate] [datetime] NULL,
	[ActiveFlag] [smallint] NULL,
 CONSTRAINT [PK_dbo.CampeonatosClassificacao] PRIMARY KEY CLUSTERED 
(
	[NomeCampeonato] ASC,
	[NomeFase] ASC,
	[NomeGrupo] ASC,
	[NomeTime] ASC,
	[Rodada] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

----SET ANSI_PADDING OFF
----GO

----ALTER TABLE [dbo].[CampeonatosClassificacao]  ADD FOREIGN KEY([CreatedBy])
----REFERENCES [dbo].[Users] ([UserName])
----GO

----ALTER TABLE [dbo].[CampeonatosClassificacao]  ADD FOREIGN KEY([ModifiedBy])
----REFERENCES [dbo].[Users] ([UserName])
----GO

--ALTER TABLE [dbo].[CampeonatosClassificacao]  ADD  CONSTRAINT FK_CampeonatosClassificacoes_CampeonatosFases_NomeCampeonato_Nome FOREIGN KEY([NomeCampeonato], [NomeFase])
--REFERENCES [dbo].[CampeonatosFases] ([NomeCampeonato], [Nome])
--GO

--ALTER TABLE [dbo].[CampeonatosClassificacao]  ADD  CONSTRAINT FK_CampeonatosClassificacoes_CampeonatosGruposTimes_NomeTime_NomeGrupo_NomeCampeonato FOREIGN KEY([NomeTime], [NomeGrupo], [NomeCampeonato])
--REFERENCES [dbo].[CampeonatosGruposTimes] ([NomeTime], [NomeGrupo], [NomeCampeonato])
--GO


ALTER TABLE [dbo].[CampeonatosClassificacao]   ADD  CONSTRAINT [FK_dbo.CampeonatosClassificacao_dbo.CampeonatosFases_NomeCampeonato_NomeFase] FOREIGN KEY([NomeCampeonato], [NomeFase])
REFERENCES [dbo].[CampeonatosFases] ([NomeCampeonato], [Nome])
GO
ALTER TABLE [dbo].[CampeonatosClassificacao] CHECK CONSTRAINT [FK_dbo.CampeonatosClassificacao_dbo.CampeonatosFases_NomeCampeonato_NomeFase]
GO
ALTER TABLE [dbo].[CampeonatosClassificacao]   ADD  CONSTRAINT [FK_dbo.CampeonatosClassificacao_dbo.CampeonatosGruposTimes_NomeCampeonato_NomeGrupo_NomeTime] FOREIGN KEY([NomeCampeonato], [NomeGrupo], [NomeTime])
REFERENCES [dbo].[CampeonatosGruposTimes] ([NomeCampeonato], [NomeGrupo], [NomeTime])
GO
ALTER TABLE [dbo].[CampeonatosClassificacao] CHECK CONSTRAINT [FK_dbo.CampeonatosClassificacao_dbo.CampeonatosGruposTimes_NomeCampeonato_NomeGrupo_NomeTime]
GO
ALTER TABLE [dbo].[CampeonatosClassificacao]   ADD  CONSTRAINT [FK_dbo.CampeonatosClassificacao_dbo.Times_NomeTime] FOREIGN KEY([NomeTime])
REFERENCES [dbo].[Times] ([Nome])
GO
ALTER TABLE [dbo].[CampeonatosClassificacao] CHECK CONSTRAINT [FK_dbo.CampeonatosClassificacao_dbo.Times_NomeTime]
GO
