﻿CREATE TABLE [dbo].[BoloesCriteriosPontosTimes](
	[CreatedBy] [varchar](25) NULL,
	[CreatedDate] [datetime] NULL,
	[Multiplo] [int] NULL,
	[ModifiedBy] [varchar](25) NULL,
	[ModifiedDate] [datetime] NULL,
	[ActiveFlag] [bit] NULL,
	[NomeBolao] [varchar](30) NOT NULL,
	[NomeTime] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[NomeBolao] ASC,
	[NomeTime] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

--SET ANSI_PADDING OFF
--GO

--ALTER TABLE [dbo].[BoloesCriteriosPontosTimes]  ADD FOREIGN KEY([CreatedBy])
--REFERENCES [dbo].[Users] ([UserName])
--GO

--ALTER TABLE [dbo].[BoloesCriteriosPontosTimes]  ADD FOREIGN KEY([ModifiedBy])
--REFERENCES [dbo].[Users] ([UserName])
--GO

ALTER TABLE [dbo].[BoloesCriteriosPontosTimes]   ADD CONSTRAINT FK_BoloesCriteriosPontosTimes_Boloes_NomeBolao  FOREIGN KEY([NomeBolao])
REFERENCES [dbo].[Boloes] ([Nome])
GO

ALTER TABLE [dbo].[BoloesCriteriosPontosTimes]  ADD CONSTRAINT FK_BoloesCriteriosPontosTimes_Times_NomeTime FOREIGN KEY([NomeTime])
REFERENCES [dbo].[Times] ([Nome])
GO

