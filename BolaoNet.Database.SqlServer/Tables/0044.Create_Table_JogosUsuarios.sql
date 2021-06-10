

CREATE TABLE [dbo].[JogosUsuarios](
	[NomeCampeonato] [varchar](150) NOT NULL,
	[JogoId] [int] NOT NULL,
	[NomeBolao] [varchar](100) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[DataAposta] [datetime] NULL,
	[Automatico] [int] NULL,
	[ApostaTime1] [int] NULL,
	[ApostaTime2] [int] NULL,
	[ApostaPenaltis1] [int] NULL,
	[ApostaPenaltis2] [int] NULL,
	[Valido] [bit] NULL,
	[NomeTimeResult1] [varchar](150) NULL,
	[NomeTimeResult2] [varchar](150) NULL,
	[Pontos] [int] NULL,
	[IsEmpate] [bit] NULL,
	[IsDerrota] [bit] NULL,
	[IsVitoria] [bit] NULL,
	[IsGolsGanhador] [bit] NULL,
	[IsGolsPerdedor] [bit] NULL,
	[IsResultTime1] [bit] NULL,
	[IsResultTime2] [bit] NULL,
	[IsVDE] [bit] NULL,
	[IsErro] [bit] NULL,
	[IsGolsGanhadorFora] [bit] NULL,
	[IsGolsGanhadorDentro] [bit] NULL,
	[IsGolsPerdedorFora] [bit] NULL,
	[IsGolsPerdedorDentro] [bit] NULL,
	[IsGolsEmpate] [bit] NULL,
	[IsGolsTime1] [bit] NULL,
	[IsGolsTime2] [bit] NULL,
	[IsPlacarCheio] [bit] NULL,
	[IsMultiploTime] [bit] NULL,
	[MultiploTime] [int] NULL,
	[Ganhador] [int] NULL,
	[DataFacebook] [datetime] NULL,
	[PontosAcertoTime] [int] NULL,
	[CreatedBy] [varchar](25) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [varchar](25) NULL,
	[ModifiedDate] [datetime] NULL,
	[ActiveFlag] [smallint] NULL,
 CONSTRAINT [PK_dbo.JogosUsuarios] PRIMARY KEY CLUSTERED 
(
	[NomeCampeonato] ASC,
	[JogoId] ASC,
	[NomeBolao] ASC,
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

----SET ANSI_PADDING OFF
----GO

----ALTER TABLE [dbo].[JogosUsuarios]  ADD FOREIGN KEY([CreatedBy])
----REFERENCES [dbo].[Users] ([UserName])
----GO

----ALTER TABLE [dbo].[JogosUsuarios]  ADD FOREIGN KEY([ModifiedBy])
----REFERENCES [dbo].[Users] ([UserName])
----GO

--ALTER TABLE [dbo].[JogosUsuarios]  ADD CONSTRAINT FK_JogosUsuarios_Times_NomeTimeResult2 FOREIGN KEY([NomeTimeResult2])
--REFERENCES [dbo].[Times] ([Nome])
--GO

--ALTER TABLE [dbo].[JogosUsuarios]  ADD CONSTRAINT FK_JogosUsuarios_Times_NomeTimeResult1 FOREIGN KEY([NomeTimeResult1])
--REFERENCES [dbo].[Times] ([Nome])
--GO

--ALTER TABLE [dbo].[JogosUsuarios]  ADD CONSTRAINT FK_JogosUsuarios_BoloesMembros_UserName_NomeBolao FOREIGN KEY([UserName], [NomeBolao])
--REFERENCES [dbo].[BoloesMembros] ([UserName], [NomeBolao])
--GO

--ALTER TABLE [dbo].[JogosUsuarios]  ADD CONSTRAINT FK_JogosUsuarios_Jogos_IdJogo_NomeCampeonato FOREIGN KEY([IdJogo], [NomeCampeonato])
--REFERENCES [dbo].[Jogos] ([IdJogo], [NomeCampeonato])
--GO


ALTER TABLE [dbo].[JogosUsuarios]   ADD  CONSTRAINT [FK_dbo.JogosUsuarios_dbo.CampeonatosTimes_NomeCampeonato_NomeTimeResult1] FOREIGN KEY([NomeCampeonato], [NomeTimeResult1])
REFERENCES [dbo].[CampeonatosTimes] ([NomeCampeonato], [NomeTime])
GO
ALTER TABLE [dbo].[JogosUsuarios] CHECK CONSTRAINT [FK_dbo.JogosUsuarios_dbo.CampeonatosTimes_NomeCampeonato_NomeTimeResult1]
GO
ALTER TABLE [dbo].[JogosUsuarios]   ADD  CONSTRAINT [FK_dbo.JogosUsuarios_dbo.CampeonatosTimes_NomeCampeonato_NomeTimeResult2] FOREIGN KEY([NomeCampeonato], [NomeTimeResult2])
REFERENCES [dbo].[CampeonatosTimes] ([NomeCampeonato], [NomeTime])
GO
ALTER TABLE [dbo].[JogosUsuarios] CHECK CONSTRAINT [FK_dbo.JogosUsuarios_dbo.CampeonatosTimes_NomeCampeonato_NomeTimeResult2]
GO
ALTER TABLE [dbo].[JogosUsuarios]   ADD  CONSTRAINT [FK_dbo.JogosUsuarios_dbo.Jogos_NomeCampeonato_JogoId] FOREIGN KEY([NomeCampeonato], [JogoId])
REFERENCES [dbo].[Jogos] ([NomeCampeonato], [JogoId])
GO
ALTER TABLE [dbo].[JogosUsuarios] CHECK CONSTRAINT [FK_dbo.JogosUsuarios_dbo.Jogos_NomeCampeonato_JogoId]
GO
ALTER TABLE [dbo].[JogosUsuarios]   ADD  CONSTRAINT [FK_dbo.JogosUsuarios_dbo.Usuarios_UserName] FOREIGN KEY([UserName])
REFERENCES [dbo].[Usuarios] ([UserName])
GO
ALTER TABLE [dbo].[JogosUsuarios] CHECK CONSTRAINT [FK_dbo.JogosUsuarios_dbo.Usuarios_UserName]
GO
