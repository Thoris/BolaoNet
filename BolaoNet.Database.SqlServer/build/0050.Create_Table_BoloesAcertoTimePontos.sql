CREATE TABLE [dbo].[BoloesAcertoTimePontos](
	[NomeCampeonato] [varchar](150) NOT NULL,
	[JogoId] [int] NOT NULL,
	[NomeBolao] [varchar](100) NOT NULL,
	[Pontos] [int] NOT NULL,
	[CreatedBy] [varchar](25) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [varchar](25) NULL,
	[ModifiedDate] [datetime] NULL,
	[ActiveFlag] [smallint] NULL,
 CONSTRAINT [PK_dbo.BoloesAcertoTimePontos] PRIMARY KEY CLUSTERED 
(
	[NomeCampeonato] ASC,
	[JogoId] ASC,
	[NomeBolao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[BoloesAcertoTimePontos]  WITH CHECK ADD  CONSTRAINT [FK_dbo.BoloesAcertoTimePontos_dbo.Jogos_NomeCampeonato_JogoId] FOREIGN KEY([NomeCampeonato], [JogoId])
REFERENCES [dbo].[Jogos] ([NomeCampeonato], [JogoId])
GO

ALTER TABLE [dbo].[BoloesAcertoTimePontos] CHECK CONSTRAINT [FK_dbo.BoloesAcertoTimePontos_dbo.Jogos_NomeCampeonato_JogoId]
GO

