 
CREATE TABLE [dbo].[Mensagens](
	[NomeBolao] [varchar](100) NOT NULL,
	[MessageID] [bigint] IDENTITY(1,1) NOT NULL,
	[AnsweredMessageID] [bigint] NOT NULL,
	[TotalRead] [int] NOT NULL,
	[FromUser] [varchar](50) NULL,
	[ToUser] [varchar](50) NULL,
	[Private] [bit] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[Title] [varchar](150) NULL,
	[Message] [varchar](255) NULL,
	[CreatedBy] [varchar](25) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [varchar](25) NULL,
	[ModifiedDate] [datetime] NULL,
	[ActiveFlag] [smallint] NULL,
 CONSTRAINT [PK_dbo.Mensagens] PRIMARY KEY CLUSTERED 
(
	[NomeBolao] ASC,
	[MessageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


ALTER TABLE [dbo].[Mensagens]   ADD  CONSTRAINT [FK_dbo.Mensagens_dbo.Boloes_NomeBolao] FOREIGN KEY([NomeBolao])
REFERENCES [dbo].[Boloes] ([Nome])
GO
ALTER TABLE [dbo].[Mensagens] CHECK CONSTRAINT [FK_dbo.Mensagens_dbo.Boloes_NomeBolao]
GO
GO
