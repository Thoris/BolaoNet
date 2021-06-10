
CREATE TABLE [dbo].[BoloesPontosRodadasUsuarios](
	[NomeCampeonato] [varchar](150) NOT NULL,
	[NomeFase] [varchar](50) NOT NULL,
	[NomeGrupo] [varchar](20) NOT NULL,
	[NomeBolao] [varchar](100) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Posicao] [int] NOT NULL,
	[Rodada] [int] NOT NULL,
	[CreatedBy] [varchar](25) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [varchar](25) NULL,
	[ModifiedDate] [datetime] NULL,
	[ActiveFlag] [smallint] NULL,
 CONSTRAINT [PK_dbo.BoloesPontosRodadasUsuarios] PRIMARY KEY CLUSTERED 
(
	[NomeCampeonato] ASC,
	[NomeFase] ASC,
	[NomeGrupo] ASC,
	[NomeBolao] ASC,
	[UserName] ASC,
	[Posicao] ASC,
	[Rodada] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

----SET ANSI_PADDING OFF
----GO

----ALTER TABLE [dbo].[BoloesPontosRodadasUsuarios]  ADD FOREIGN KEY([CreatedBy])
----REFERENCES [dbo].[Users] ([UserName])
----GO

----ALTER TABLE [dbo].[BoloesPontosRodadasUsuarios]  ADD FOREIGN KEY([ModifiedBy])
----REFERENCES [dbo].[Users] ([UserName])
----GO

--ALTER TABLE [dbo].[BoloesPontosRodadasUsuarios]  ADD  CONSTRAINT FK_BoloesPontosRodadasUsuarios_BoloesMembros_UserName_NomeBolao FOREIGN KEY([UserName], [NomeBolao])
--REFERENCES [dbo].[BoloesMembros] ([UserName], [NomeBolao])
--GO

--ALTER TABLE [dbo].[BoloesPontosRodadasUsuarios]  ADD  CONSTRAINT FK_BoloesPontosRodadasUsuarios_BoloesPontosRodadas FOREIGN KEY([NomeGrupo], [NomeCampeonato], [NomeFase], [NomeBolao], [Posicao])
--REFERENCES [dbo].[BoloesPontosRodadas] ([NomeGrupo], [NomeCampeonato], [NomeFase], [NomeBolao], [Posicao])
--GO



ALTER TABLE [dbo].[BoloesPontosRodadasUsuarios]   ADD  CONSTRAINT [FK_dbo.BoloesPontosRodadasUsuarios_dbo.BoloesPontosRodadas_NomeCampeonato_NomeFase_NomeGrupo_NomeBolao_Posicao] FOREIGN KEY([NomeCampeonato], [NomeFase], [NomeGrupo], [NomeBolao], [Posicao])
REFERENCES [dbo].[BoloesPontosRodadas] ([NomeCampeonato], [NomeFase], [NomeGrupo], [NomeBolao], [Posicao])
GO
ALTER TABLE [dbo].[BoloesPontosRodadasUsuarios] CHECK CONSTRAINT [FK_dbo.BoloesPontosRodadasUsuarios_dbo.BoloesPontosRodadas_NomeCampeonato_NomeFase_NomeGrupo_NomeBolao_Posicao]
GO
ALTER TABLE [dbo].[BoloesPontosRodadasUsuarios]   ADD  CONSTRAINT [FK_dbo.BoloesPontosRodadasUsuarios_dbo.Usuarios_UserName] FOREIGN KEY([UserName])
REFERENCES [dbo].[Usuarios] ([UserName])
GO
ALTER TABLE [dbo].[BoloesPontosRodadasUsuarios] CHECK CONSTRAINT [FK_dbo.BoloesPontosRodadasUsuarios_dbo.Usuarios_UserName]
GO
