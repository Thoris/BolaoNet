﻿CREATE TABLE [dbo].[BoloesHistorico](
	[NomeBolao] [varchar](100) NOT NULL,
	[Ano] [int] NOT NULL,
	[Posicao] [int] NOT NULL,
	[UserName] [varchar](50) NULL,
	[Pontos] [int] NOT NULL,
	[TotalEmpates] [int] NOT NULL,
	[TotalVDE] [int] NOT NULL,
	[TotalGolsTime1] [int] NOT NULL,
	[TotalGolsTime2] [int] NOT NULL,
	[TotalCheio] [int] NOT NULL,
	[TotalExtras] [int] NOT NULL,
	[CreatedBy] [varchar](25) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [varchar](25) NULL,
	[ModifiedDate] [datetime] NULL,
	[ActiveFlag] [smallint] NULL,
 CONSTRAINT [PK_dbo.BoloesHistorico] PRIMARY KEY CLUSTERED 
(
	[NomeBolao] ASC,
	[Ano] ASC,
	[Posicao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

----SET ANSI_PADDING OFF
----GO

----ALTER TABLE [dbo].[BoloesHistorico]  ADD FOREIGN KEY([CreatedBy])
----REFERENCES [dbo].[Usuarios] ([UserName])
----GO

----ALTER TABLE [dbo].[BoloesHistorico]  ADD FOREIGN KEY([ModifiedBy])
----REFERENCES [dbo].[Usuarios] ([UserName])
----GO

--ALTER TABLE [dbo].[BoloesHistorico]  ADD CONSTRAINT FK_BoloesHistorico_Boloes_NomeBolao FOREIGN KEY([NomeBolao])
--REFERENCES [dbo].[Boloes] ([Nome])
--GO

ALTER TABLE [dbo].[BoloesHistorico]   ADD  CONSTRAINT [FK_dbo.BoloesHistorico_dbo.Boloes_NomeBolao] FOREIGN KEY([NomeBolao])
REFERENCES [dbo].[Boloes] ([Nome])
GO
ALTER TABLE [dbo].[BoloesHistorico] CHECK CONSTRAINT [FK_dbo.BoloesHistorico_dbo.Boloes_NomeBolao]
GO