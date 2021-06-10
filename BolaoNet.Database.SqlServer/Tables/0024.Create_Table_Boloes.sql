
CREATE TABLE [dbo].[Boloes](
	[Nome] [varchar](100) NOT NULL,
	[NomeCampeonato] [varchar](150) NULL,
	[Descricao] [varchar](250) NULL,
	[TaxaParticipacao] [decimal](18, 2) NULL,
	[Publico] [bit] NULL,
	[ForumAtivado] [bit] NULL,
	[PermitirMsgAnonimos] [bit] NULL,
	[DataInicio] [datetime] NULL,
	[Pais] [varchar](30) NULL,
	[Estado] [varchar](50) NULL,
	[Cidade] [varchar](150) NULL,
	[ApostasApenasAntes] [bit] NULL,
	[HorasLimiteAposta] [int] NOT NULL,
	[IsIniciado] [bit] NULL,
	[IniciadoBy] [varchar](250) NULL,
	[DataIniciado] [datetime] NULL,
	[CreatedBy] [varchar](25) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [varchar](25) NULL,
	[ModifiedDate] [datetime] NULL,
	[ActiveFlag] [smallint] NULL,
 CONSTRAINT [PK_dbo.Boloes] PRIMARY KEY CLUSTERED 
(
	[Nome] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

--SET ANSI_PADDING OFF
--GO

--ALTER TABLE [dbo].[Boloes]  ADD FOREIGN KEY([CreatedBy])
--REFERENCES [dbo].[Users] ([UserName])
--GO

--ALTER TABLE [dbo].[Boloes]  ADD  CONSTRAINT FK_Boloes_Users_IniciadoBy FOREIGN KEY([IniciadoBy])
--REFERENCES [dbo].[Users] ([UserName])
--GO

----ALTER TABLE [dbo].[Boloes]  ADD FOREIGN KEY([ModifiedBy])
----REFERENCES [dbo].[Users] ([UserName])
----GO

--ALTER TABLE [dbo].[Boloes]  ADD CONSTRAINT FK_Boloes_Campeonatos_NomeCampeonato  FOREIGN KEY([NomeCampeonato])
--REFERENCES [dbo].[Campeonatos] ([Nome])
--GO





ALTER TABLE [dbo].[Boloes]   ADD  CONSTRAINT [FK_dbo.Boloes_dbo.Campeonatos_NomeCampeonato] FOREIGN KEY([NomeCampeonato])
REFERENCES [dbo].[Campeonatos] ([Nome])
GO
ALTER TABLE [dbo].[Boloes] CHECK CONSTRAINT [FK_dbo.Boloes_dbo.Campeonatos_NomeCampeonato]
GO