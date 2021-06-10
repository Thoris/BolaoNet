

CREATE TABLE [dbo].[Times](
	[Nome] [varchar](150) NOT NULL,
	[IsClube] [bit] NOT NULL,
	[Fundacao] [datetime] NULL,
	[Site] [varchar](100) NULL,
	[Pais] [varchar](30) NULL,
	[Estado] [varchar](30) NULL,
	[Cidade] [varchar](150) NULL,
	[Descricao] [varchar](255) NULL,
	[NomeMascote] [varchar](30) NULL,
	[CreatedBy] [varchar](25) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [varchar](25) NULL,
	[ModifiedDate] [datetime] NULL,
	[ActiveFlag] [smallint] NULL,
 CONSTRAINT [PK_dbo.Times] PRIMARY KEY CLUSTERED 
(
	[Nome] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


GO

--ALTER TABLE [dbo].[Times]  ADD  CONSTRAINT FK_Times_Users_CreatedBy FOREIGN KEY([CreatedBy])
--REFERENCES [dbo].[Users] ([UserName])
--GO

--ALTER TABLE [dbo].[Times]  ADD  CONSTRAINT FK_Times_Users_ModifiedBy FOREIGN KEY([ModifiedBy])
--REFERENCES [dbo].[Users] ([UserName])
--GO
