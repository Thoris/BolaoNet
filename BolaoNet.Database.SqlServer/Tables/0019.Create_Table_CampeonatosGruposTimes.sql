   
CREATE TABLE [dbo].[CampeonatosGruposTimes](
	[NomeCampeonato] [varchar](150) NOT NULL,
	[NomeGrupo] [varchar](20) NOT NULL,
	[NomeTime] [varchar](150) NOT NULL,
	[CreatedBy] [varchar](25) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [varchar](25) NULL,
	[ModifiedDate] [datetime] NULL,
	[ActiveFlag] [smallint] NULL,
 CONSTRAINT [PK_dbo.CampeonatosGruposTimes] PRIMARY KEY CLUSTERED 
(
	[NomeCampeonato] ASC,
	[NomeGrupo] ASC,
	[NomeTime] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

----SET ANSI_PADDING OFF
----GO

----ALTER TABLE [dbo].[CampeonatosGruposTimes]  ADD FOREIGN KEY([CreatedBy])
----REFERENCES [dbo].[Users] ([UserName])
----GO

----ALTER TABLE [dbo].[CampeonatosGruposTimes]  ADD FOREIGN KEY([ModifiedBy])
----REFERENCES [dbo].[Users] ([UserName])
----GO

--ALTER TABLE [dbo].[CampeonatosGruposTimes]  ADD CONSTRAINT FK_CampeonatosGruposTimes_Times_NomeTime  FOREIGN KEY([NomeTime])
--REFERENCES [dbo].[Times] ([Nome])
--GO

--ALTER TABLE [dbo].[CampeonatosGruposTimes]  ADD  CONSTRAINT FK_CampeonatosGruposTimes_CampeonatosGrupos_NomeCampeonato FOREIGN KEY([NomeGrupo], [NomeCampeonato])
--REFERENCES [dbo].[CampeonatosGrupos] ([Nome], [NomeCampeonato])
--GO


ALTER TABLE [dbo].[CampeonatosGruposTimes]   ADD  CONSTRAINT [FK_dbo.CampeonatosGruposTimes_dbo.CampeonatosGrupos_NomeCampeonato_NomeGrupo] FOREIGN KEY([NomeCampeonato], [NomeGrupo])
REFERENCES [dbo].[CampeonatosGrupos] ([NomeCampeonato], [Nome])
GO
ALTER TABLE [dbo].[CampeonatosGruposTimes] CHECK CONSTRAINT [FK_dbo.CampeonatosGruposTimes_dbo.CampeonatosGrupos_NomeCampeonato_NomeGrupo]
GO
ALTER TABLE [dbo].[CampeonatosGruposTimes]   ADD  CONSTRAINT [FK_dbo.CampeonatosGruposTimes_dbo.CampeonatosTimes_NomeCampeonato_NomeTime] FOREIGN KEY([NomeCampeonato], [NomeTime])
REFERENCES [dbo].[CampeonatosTimes] ([NomeCampeonato], [NomeTime])
GO
ALTER TABLE [dbo].[CampeonatosGruposTimes] CHECK CONSTRAINT [FK_dbo.CampeonatosGruposTimes_dbo.CampeonatosTimes_NomeCampeonato_NomeTime]
GO