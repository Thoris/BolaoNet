 
CREATE TABLE [dbo].[CampeonatosTimes](
	[NomeCampeonato] [varchar](150) NOT NULL,
	[NomeTime] [varchar](150) NOT NULL,
	[CreatedBy] [varchar](25) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [varchar](25) NULL,
	[ModifiedDate] [datetime] NULL,
	[ActiveFlag] [smallint] NULL,
 CONSTRAINT [PK_dbo.CampeonatosTimes] PRIMARY KEY CLUSTERED 
(
	[NomeCampeonato] ASC,
	[NomeTime] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

----SET ANSI_PADDING OFF
----GO

----ALTER TABLE [dbo].[CampeonatosTimes]  ADD FOREIGN KEY([CreatedBy])
----REFERENCES [dbo].[Users] ([UserName])
----GO

----ALTER TABLE [dbo].[CampeonatosTimes]  ADD FOREIGN KEY([ModifiedBy])
----REFERENCES [dbo].[Users] ([UserName])
----GO

--ALTER TABLE [dbo].[CampeonatosTimes]  ADD  CONSTRAINT FK_CampeonatosTimes_Campeonato_NomeCampeonato FOREIGN KEY([NomeCampeonato])
--REFERENCES [dbo].[Campeonatos] ([Nome])
--GO

--ALTER TABLE [dbo].[CampeonatosTimes]  ADD CONSTRAINT FK_CampeonatoTimes_Times_NomeTime  FOREIGN KEY([NomeTime])
--REFERENCES [dbo].[Times] ([Nome])
--GO


ALTER TABLE [dbo].[CampeonatosTimes]   ADD  CONSTRAINT [FK_dbo.CampeonatosTimes_dbo.Campeonatos_NomeCampeonato] FOREIGN KEY([NomeCampeonato])
REFERENCES [dbo].[Campeonatos] ([Nome])
GO
ALTER TABLE [dbo].[CampeonatosTimes] CHECK CONSTRAINT [FK_dbo.CampeonatosTimes_dbo.Campeonatos_NomeCampeonato]
GO
ALTER TABLE [dbo].[CampeonatosTimes]   ADD  CONSTRAINT [FK_dbo.CampeonatosTimes_dbo.Times_NomeTime] FOREIGN KEY([NomeTime])
REFERENCES [dbo].[Times] ([Nome])
GO
ALTER TABLE [dbo].[CampeonatosTimes] CHECK CONSTRAINT [FK_dbo.CampeonatosTimes_dbo.Times_NomeTime]
GO
