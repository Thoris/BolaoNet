 
CREATE TABLE [dbo].[CampeonatosHistorico](
	[NomeCampeonato] [varchar](150) NOT NULL,
	[Ano] [int] NOT NULL,
	[Sede] [varchar](100) NULL,
	[NomeTimeCampeao] [varchar](150) NULL,
	[NomeTimeVice] [varchar](150) NULL,
	[NomeTimeTerceiro] [varchar](150) NULL,
	[FinalTime1] [smallint] NULL,
	[FinalPenaltis1] [smallint] NULL,
	[FinalTime2] [smallint] NULL,
	[FinalPenaltis2] [int] NULL,
	[CreatedBy] [varchar](25) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [varchar](25) NULL,
	[ModifiedDate] [datetime] NULL,
	[ActiveFlag] [smallint] NULL,
 CONSTRAINT [PK_dbo.CampeonatosHistorico] PRIMARY KEY CLUSTERED 
(
	[NomeCampeonato] ASC,
	[Ano] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

----SET ANSI_PADDING OFF
----GO

----ALTER TABLE [dbo].[CampeonatosHistorico]  ADD FOREIGN KEY([CreatedBy])
----REFERENCES [dbo].[Users] ([UserName])
----GO

----ALTER TABLE [dbo].[CampeonatosHistorico]  ADD FOREIGN KEY([ModifiedBy])
----REFERENCES [dbo].[Users] ([UserName])
----GO

--ALTER TABLE [dbo].[CampeonatosHistorico]  ADD  CONSTRAINT FK_CampeonatosHistorico_Campeonatos_Nome FOREIGN KEY([Nome])
--REFERENCES [dbo].[Campeonatos] ([Nome])
--GO


ALTER TABLE [dbo].[CampeonatosHistorico]   ADD  CONSTRAINT [FK_dbo.CampeonatosHistorico_dbo.Campeonatos_NomeCampeonato] FOREIGN KEY([NomeCampeonato])
REFERENCES [dbo].[Campeonatos] ([Nome])
GO
ALTER TABLE [dbo].[CampeonatosHistorico] CHECK CONSTRAINT [FK_dbo.CampeonatosHistorico_dbo.Campeonatos_NomeCampeonato]
GO