
CREATE TABLE [dbo].[BoloesMembrosClassificacao](
	[NomeBolao] [varchar](100) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Posicao] [int] NULL,
	[LastPosicao] [int] NULL,
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
 CONSTRAINT [PK_dbo.BoloesMembrosClassificacao] PRIMARY KEY CLUSTERED 
(
	[NomeBolao] ASC,
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

----SET ANSI_PADDING OFF
----GO

----ALTER TABLE [dbo].[BoloesMembrosClassificacao]  ADD FOREIGN KEY([CreatedBy])
----REFERENCES [dbo].[Users] ([UserName])
----GO

----ALTER TABLE [dbo].[BoloesMembrosClassificacao]  ADD FOREIGN KEY([ModifiedBy])
----REFERENCES [dbo].[Users] ([UserName])
----GO


--ALTER TABLE [dbo].[BoloesMembrosClassificacao]  ADD  CONSTRAINT FK_BoloesMembrosClassificacao_BoloesMembros_Username_NomeBolao FOREIGN KEY([UserName], [NomeBolao])
--REFERENCES [dbo].[BoloesMembros] ([UserName], [NomeBolao])
--GO


ALTER TABLE [dbo].[BoloesMembrosClassificacao]   ADD  CONSTRAINT [FK_dbo.BoloesMembrosClassificacao_dbo.BoloesMembros_NomeBolao_UserName] FOREIGN KEY([NomeBolao], [UserName])
REFERENCES [dbo].[BoloesMembros] ([NomeBolao], [UserName])
GO
ALTER TABLE [dbo].[BoloesMembrosClassificacao] CHECK CONSTRAINT [FK_dbo.BoloesMembrosClassificacao_dbo.BoloesMembros_NomeBolao_UserName]
GO