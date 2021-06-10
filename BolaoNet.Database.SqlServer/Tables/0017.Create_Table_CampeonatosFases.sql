
 
CREATE TABLE [dbo].[CampeonatosFases](
	[NomeCampeonato] [varchar](150) NOT NULL,
	[Nome] [varchar](50) NOT NULL,
	[Descricao] [varchar](255) NULL,
	[Ordem] [int] NULL,
	[CreatedBy] [varchar](25) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [varchar](25) NULL,
	[ModifiedDate] [datetime] NULL,
	[ActiveFlag] [smallint] NULL,
 CONSTRAINT [PK_dbo.CampeonatosFases] PRIMARY KEY CLUSTERED 
(
	[NomeCampeonato] ASC,
	[Nome] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

----ALTER TABLE [dbo].[CampeonatosFases]  ADD FOREIGN KEY([CreatedBy])
----REFERENCES [dbo].[Users] ([UserName])
----GO

----ALTER TABLE [dbo].[CampeonatosFases]  ADD FOREIGN KEY([ModifiedBy])
----REFERENCES [dbo].[Users] ([UserName])
----GO

--ALTER TABLE [dbo].[CampeonatosFases]  ADD  CONSTRAINT FK_CampeonatoFases_Campeonatos_NomeCampeonato FOREIGN KEY([NomeCampeonato])
--REFERENCES [dbo].[Campeonatos] ([Nome])
--GO



ALTER TABLE [dbo].[CampeonatosFases]   ADD  CONSTRAINT [FK_dbo.CampeonatosFases_dbo.Campeonatos_NomeCampeonato] FOREIGN KEY([NomeCampeonato])
REFERENCES [dbo].[Campeonatos] ([Nome])
GO
ALTER TABLE [dbo].[CampeonatosFases] CHECK CONSTRAINT [FK_dbo.CampeonatosFases_dbo.Campeonatos_NomeCampeonato]
GO