
CREATE TABLE [dbo].[BoloesHistorico](
	[NomeBolao] [varchar](30) NOT NULL,
	[Ano] [int] NOT NULL,
	[Posicao] [int] NOT NULL,
	[UserName] varchar(50) NULL,
	[Pontos] [int] NULL,
	[TotalEmpates] [int] NULL,
	[TotalVDE] [int] NULL,
	[TotalGolsTime1] [int] NULL,
	[TotalGolsTime2] [int] NULL,
	[TotalCheio] [int] NULL,
	[TotalExtras] [int] NULL,
	[CreatedBy] [varchar](25) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [varchar](25) NULL,
	[ModifiedDate] [datetime] NULL,
	[ActiveFlag] [bit] NULL,
	
PRIMARY KEY CLUSTERED 
(
	[NomeBolao] ASC,
	[Ano] ASC,
	[Posicao] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

--SET ANSI_PADDING OFF
--GO

--ALTER TABLE [dbo].[BoloesHistorico]  ADD FOREIGN KEY([CreatedBy])
--REFERENCES [dbo].[Usuarios] ([UserName])
--GO

--ALTER TABLE [dbo].[BoloesHistorico]  ADD FOREIGN KEY([ModifiedBy])
--REFERENCES [dbo].[Usuarios] ([UserName])
--GO

ALTER TABLE [dbo].[BoloesHistorico]  ADD FOREIGN KEY([NomeBolao])
REFERENCES [dbo].[Boloes] ([Nome])
GO
