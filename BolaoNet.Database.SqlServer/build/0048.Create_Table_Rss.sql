CREATE TABLE [dbo].[Rss](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](500) NULL,
	[Description] [varchar](4000) NULL,
	[DateAdded] [datetime] NOT NULL,
	[CreatedBy] [varchar](255) NULL,
 CONSTRAINT [PK_dbo.Rss] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
 
