/****** Object:  Table [dbo].[Estadios]    Script Date: 10/31/2012 09:32:46 ******/
--SET ANSI_NULLS ON
--GO

--SET QUOTED_IDENTIFIER ON
--GO

--SET ANSI_PADDING ON
--GO

CREATE TABLE [dbo].[Estadios](
	[Nome] [varchar](50) NOT NULL,
	[Pais] [varchar](60) NULL,
	[Estado] [varchar](30) NULL,
	[Cidade] [varchar](50) NULL,
	[Capacidade] [bigint] NOT NULL,
	[Descricao] [varchar](255) NULL,
	[NomeTime] [varchar](150) NULL,
	[CreatedBy] [varchar](25) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [varchar](25) NULL,
	[ModifiedDate] [datetime] NULL,
	[ActiveFlag] [smallint] NULL,
 CONSTRAINT [PK_dbo.Estadios] PRIMARY KEY CLUSTERED 
(
	[Nome] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

----ALTER TABLE [dbo].[Estadios]  ADD FOREIGN KEY([CreatedBy])
----REFERENCES [dbo].[Users] ([UserName])
----GO

----ALTER TABLE [dbo].[Estadios]  ADD FOREIGN KEY([ModifiedBy])
----REFERENCES [dbo].[Users] ([UserName])
----GO

--ALTER TABLE [dbo].[Estadios]  ADD  CONSTRAINT FK_Estadios_Times_NomeTime FOREIGN KEY([NomeTime])
--REFERENCES [dbo].[Times] ([Nome])
--GO


ALTER TABLE [dbo].[Estadios]   ADD  CONSTRAINT [FK_dbo.Estadios_dbo.Times_NomeTime] FOREIGN KEY([NomeTime])
REFERENCES [dbo].[Times] ([Nome])
GO
ALTER TABLE [dbo].[Estadios] CHECK CONSTRAINT [FK_dbo.Estadios_dbo.Times_NomeTime]
GO
