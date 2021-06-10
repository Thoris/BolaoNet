 
CREATE TABLE [dbo].[BoloesCriteriosPontosTimes](
	[NomeBolao] [varchar](100) NOT NULL,
	[NomeTime] [varchar](150) NOT NULL,
	[MultiploTime] [int] NOT NULL,
	[CreatedBy] [varchar](25) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [varchar](25) NULL,
	[ModifiedDate] [datetime] NULL,
	[ActiveFlag] [smallint] NULL,
 CONSTRAINT [PK_dbo.BoloesCriteriosPontosTimes] PRIMARY KEY CLUSTERED 
(
	[NomeBolao] ASC,
	[NomeTime] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

----SET ANSI_PADDING OFF
----GO

----ALTER TABLE [dbo].[BoloesCriteriosPontosTimes]  ADD FOREIGN KEY([CreatedBy])
----REFERENCES [dbo].[Users] ([UserName])
----GO

----ALTER TABLE [dbo].[BoloesCriteriosPontosTimes]  ADD FOREIGN KEY([ModifiedBy])
----REFERENCES [dbo].[Users] ([UserName])
----GO

--ALTER TABLE [dbo].[BoloesCriteriosPontosTimes]   ADD CONSTRAINT FK_BoloesCriteriosPontosTimes_Boloes_NomeBolao  FOREIGN KEY([NomeBolao])
--REFERENCES [dbo].[Boloes] ([Nome])
--GO

--ALTER TABLE [dbo].[BoloesCriteriosPontosTimes]  ADD CONSTRAINT FK_BoloesCriteriosPontosTimes_Times_NomeTime FOREIGN KEY([NomeTime])
--REFERENCES [dbo].[Times] ([Nome])
--GO


ALTER TABLE [dbo].[BoloesCriteriosPontosTimes]   ADD  CONSTRAINT [FK_dbo.BoloesCriteriosPontosTimes_dbo.Boloes_NomeBolao] FOREIGN KEY([NomeBolao])
REFERENCES [dbo].[Boloes] ([Nome])
GO
ALTER TABLE [dbo].[BoloesCriteriosPontosTimes] CHECK CONSTRAINT [FK_dbo.BoloesCriteriosPontosTimes_dbo.Boloes_NomeBolao]
GO
ALTER TABLE [dbo].[BoloesCriteriosPontosTimes]   ADD  CONSTRAINT [FK_dbo.BoloesCriteriosPontosTimes_dbo.Times_NomeTime] FOREIGN KEY([NomeTime])
REFERENCES [dbo].[Times] ([Nome])
GO
ALTER TABLE [dbo].[BoloesCriteriosPontosTimes] CHECK CONSTRAINT [FK_dbo.BoloesCriteriosPontosTimes_dbo.Times_NomeTime]
GO