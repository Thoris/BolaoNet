
CREATE TABLE [dbo].[BoloesPremios](
	[NomeBolao] [varchar](100) NOT NULL,
	[Posicao] [int] NOT NULL,
	[Titulo] [varchar](150) NULL,
	[ForeColorName] [varchar](30) NULL,
	[BackColorName] [varchar](30) NULL,
	[CreatedBy] [varchar](25) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [varchar](25) NULL,
	[ModifiedDate] [datetime] NULL,
	[ActiveFlag] [smallint] NULL,
 CONSTRAINT [PK_dbo.BoloesPremios] PRIMARY KEY CLUSTERED 
(
	[NomeBolao] ASC,
	[Posicao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

----SET ANSI_PADDING OFF
----GO

----ALTER TABLE [dbo].[BoloesPremios]  ADD FOREIGN KEY([CreatedBy])
----REFERENCES [dbo].[Users] ([UserName])
----GO


----ALTER TABLE [dbo].[BoloesPremios]  ADD FOREIGN KEY([ModifiedBy])
----REFERENCES [dbo].[Users] ([UserName])
----GO


--ALTER TABLE [dbo].[BoloesPremios]  ADD  CONSTRAINT FK_BoloesPremios_Boloes_NomeBolao FOREIGN KEY([NomeBolao])
--REFERENCES [dbo].[Boloes] ([Nome])
--GO

ALTER TABLE [dbo].[BoloesPremios]   ADD  CONSTRAINT [FK_dbo.BoloesPremios_dbo.Boloes_NomeBolao] FOREIGN KEY([NomeBolao])
REFERENCES [dbo].[Boloes] ([Nome])
GO
ALTER TABLE [dbo].[BoloesPremios] CHECK CONSTRAINT [FK_dbo.BoloesPremios_dbo.Boloes_NomeBolao]
GO