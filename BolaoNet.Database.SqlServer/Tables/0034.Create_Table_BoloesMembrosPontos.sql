
CREATE TABLE [dbo].[BoloesMembrosPontos](
	[NomeCampeonato] [varchar](150) NOT NULL,
	[NomeFase] [varchar](50) NOT NULL,
	[NomeGrupo] [varchar](20) NOT NULL,
	[NomeBolao] [varchar](100) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Rodada] [int] NOT NULL,
	[Posicao] [int] NULL,
	[LastPosicao] [int] NULL,
	[IsMultiploTime] [bit] NOT NULL,
	[TotalApostaExtra] [int] NULL,
	[TotalPontos] [int] NULL,
	[TotalEmpate] [int] NULL,
	[TotalVitoria] [int] NULL,
	[TotalDerrota] [int] NULL,
	[TotalGolsGanhador] [int] NULL,
	[TotalGolsPerdedor] [int] NULL,
	[TotalResultTime1] [int] NULL,
	[TotalResultTime2] [int] NULL,
	[TotalVDE] [int] NULL,
	[TotalErro] [int] NULL,
	[TotalGolsGanhadorFora] [int] NULL,
	[TotalGolsGanhadorDentro] [int] NULL,
	[TotalPerdedorFora] [int] NULL,
	[TotalPerdedorDentro] [int] NULL,
	[TotalGolsEmpate] [int] NULL,
	[TotalGolsTime1] [int] NULL,
	[TotalGolsTime2] [int] NULL,
	[TotalPlacarCheio] [int] NULL,
	[TotalPontosAcertoTime] [int] NULL,
	[CreatedBy] [varchar](25) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [varchar](25) NULL,
	[ModifiedDate] [datetime] NULL,
	[ActiveFlag] [smallint] NULL,
 CONSTRAINT [PK_dbo.BoloesMembrosPontos] PRIMARY KEY CLUSTERED 
(
	[NomeCampeonato] ASC,
	[NomeFase] ASC,
	[NomeGrupo] ASC,
	[NomeBolao] ASC,
	[UserName] ASC,
	[Rodada] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


--ALTER TABLE [dbo].[BoloesMembrosPontos]  ADD FOREIGN KEY([CreatedBy])
--REFERENCES [dbo].[Users] ([UserName])
--GO


--ALTER TABLE [dbo].[BoloesMembrosPontos]  ADD FOREIGN KEY([ModifiedBy])
--REFERENCES [dbo].[Users] ([UserName])
--GO


--ALTER TABLE [dbo].[BoloesMembrosPontos]  ADD  CONSTRAINT FK_BoloesMembrosPontos_CampeonatosGrupos_Nome_NomeCampeoanto FOREIGN KEY([NomeGrupo], [NomeCampeonato])
--REFERENCES [dbo].[CampeonatosGrupos] ([Nome], [NomeCampeonato])
--GO

--ALTER TABLE [dbo].[BoloesMembrosPontos]  ADD  CONSTRAINT FK_BoloesMembrosPontos_CampeonatosFases_NomeCampeonato_Nome FOREIGN KEY([NomeCampeonato], [NomeFase])
--REFERENCES [dbo].[CampeonatosFases] ([NomeCampeonato], [Nome])
--GO

--ALTER TABLE [dbo].[BoloesMembrosPontos]  ADD  CONSTRAINT FK_BoloesMembrosPontos_BoloesMembros_UserName_NomeBolao FOREIGN KEY([UserName], [NomeBolao])
--REFERENCES [dbo].[BoloesMembros] ([UserName], [NomeBolao])
--GO

