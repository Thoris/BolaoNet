

CREATE TABLE [dbo].[BoloesCriteriosPontos](
	[NomeBolao] [varchar](100) NOT NULL,
	[CriterioID] [int] NOT NULL,
	[Pontos] [int] NULL,
	[Descricao] [varchar](255) NULL,
	[CreatedBy] [varchar](25) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [varchar](25) NULL,
	[ModifiedDate] [datetime] NULL,
	[ActiveFlag] [smallint] NULL,
 CONSTRAINT [PK_dbo.BoloesCriteriosPontos] PRIMARY KEY CLUSTERED 
(
	[NomeBolao] ASC,
	[CriterioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

----SET ANSI_PADDING OFF
----GO

----ALTER TABLE [dbo].[BoloesCriteriosPontos]  ADD FOREIGN KEY([CreatedBy])
----REFERENCES [dbo].[Users] ([UserName])
----GO

--ALTER TABLE [dbo].[BoloesCriteriosPontos]  ADD  CONSTRAINT FK_BoloesCriteriosPontos_CriteriosFixos_CriterioId FOREIGN KEY([CriterioID])
--REFERENCES [dbo].[CriteriosFixos] ([CriterioID])
--GO

----ALTER TABLE [dbo].[BoloesCriteriosPontos]  ADD FOREIGN KEY([ModifiedBy])
----REFERENCES [dbo].[Users] ([UserName])
----GO

--ALTER TABLE [dbo].[BoloesCriteriosPontos]  ADD  CONSTRAINT FK_BoloesCriteriosPontos_Boloes_NomeBolao FOREIGN KEY([NomeBolao])
--REFERENCES [dbo].[Boloes] ([Nome])
--GO

ALTER TABLE [dbo].[BoloesCriteriosPontos]   ADD  CONSTRAINT [FK_dbo.BoloesCriteriosPontos_dbo.Boloes_NomeBolao] FOREIGN KEY([NomeBolao])
REFERENCES [dbo].[Boloes] ([Nome])
GO
ALTER TABLE [dbo].[BoloesCriteriosPontos] CHECK CONSTRAINT [FK_dbo.BoloesCriteriosPontos_dbo.Boloes_NomeBolao]
GO
ALTER TABLE [dbo].[BoloesCriteriosPontos]   ADD  CONSTRAINT [FK_dbo.BoloesCriteriosPontos_dbo.CriteriosFixos_CriterioID] FOREIGN KEY([CriterioID])
REFERENCES [dbo].[CriteriosFixos] ([CriterioId])
GO
ALTER TABLE [dbo].[BoloesCriteriosPontos] CHECK CONSTRAINT [FK_dbo.BoloesCriteriosPontos_dbo.CriteriosFixos_CriterioID]
GO