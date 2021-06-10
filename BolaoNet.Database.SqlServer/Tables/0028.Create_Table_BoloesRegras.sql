
CREATE TABLE [dbo].[BoloesRegras](
	[NomeBolao] [varchar](100) NOT NULL,
	[RegraID] [int] NOT NULL,
	[Descricao] [varchar](255) NULL,
	[CreatedBy] [varchar](25) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [varchar](25) NULL,
	[ModifiedDate] [datetime] NULL,
	[ActiveFlag] [smallint] NULL,
 CONSTRAINT [PK_dbo.BoloesRegras] PRIMARY KEY CLUSTERED 
(
	[NomeBolao] ASC,
	[RegraID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

----SET ANSI_PADDING OFF
----GO

----ALTER TABLE [dbo].[BoloesRegras]  ADD FOREIGN KEY([CreatedBy])
----REFERENCES [dbo].[Users] ([UserName])
----GO

----ALTER TABLE [dbo].[BoloesRegras]  ADD FOREIGN KEY([ModifiedBy])
----REFERENCES [dbo].[Users] ([UserName])
----GO

--ALTER TABLE [dbo].[BoloesRegras]  ADD  CONSTRAINT FK_BoloesRegras_Boloes_NomeBolao FOREIGN KEY([NomeBolao])
--REFERENCES [dbo].[Boloes] ([Nome])
--GO

ALTER TABLE [dbo].[BoloesRegras]   ADD  CONSTRAINT [FK_dbo.BoloesRegras_dbo.Boloes_NomeBolao] FOREIGN KEY([NomeBolao])
REFERENCES [dbo].[Boloes] ([Nome])
GO
ALTER TABLE [dbo].[BoloesRegras] CHECK CONSTRAINT [FK_dbo.BoloesRegras_dbo.Boloes_NomeBolao]
GO