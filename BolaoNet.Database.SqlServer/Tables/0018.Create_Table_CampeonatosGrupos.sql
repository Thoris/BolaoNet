  
CREATE TABLE [dbo].[CampeonatosGrupos](
	[NomeCampeonato] [varchar](150) NOT NULL,
	[Nome] [varchar](20) NOT NULL,
	[Descricao] [varchar](255) NULL,
	[Ordem] [int] NULL,
	[CreatedBy] [varchar](25) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [varchar](25) NULL,
	[ModifiedDate] [datetime] NULL,
	[ActiveFlag] [smallint] NULL,
 CONSTRAINT [PK_dbo.CampeonatosGrupos] PRIMARY KEY CLUSTERED 
(
	[NomeCampeonato] ASC,
	[Nome] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

----SET ANSI_PADDING OFF
----GO

----ALTER TABLE [dbo].[CampeonatosGrupos]  ADD FOREIGN KEY([CreatedBy])
----REFERENCES [dbo].[Users] ([UserName])
----GO

----ALTER TABLE [dbo].[CampeonatosGrupos]  ADD FOREIGN KEY([ModifiedBy])
----REFERENCES [dbo].[Users] ([UserName])
----GO

--ALTER TABLE [dbo].[CampeonatosGrupos]  ADD CONSTRAINT FK_CampeonatoGrupos_Campeonatos_NomeCampeonato  FOREIGN KEY([NomeCampeonato])
--REFERENCES [dbo].[Campeonatos] ([Nome])
--GO



ALTER TABLE [dbo].[CampeonatosGrupos]   ADD  CONSTRAINT [FK_dbo.CampeonatosGrupos_dbo.Campeonatos_NomeCampeonato] FOREIGN KEY([NomeCampeonato])
REFERENCES [dbo].[Campeonatos] ([Nome])
GO
ALTER TABLE [dbo].[CampeonatosGrupos] CHECK CONSTRAINT [FK_dbo.CampeonatosGrupos_dbo.Campeonatos_NomeCampeonato]
GO
