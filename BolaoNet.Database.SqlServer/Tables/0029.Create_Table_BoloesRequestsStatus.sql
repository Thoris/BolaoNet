  
CREATE TABLE [dbo].[BoloesRequestsStatus](
	[StatusRequestID] [int] NOT NULL,
	[Descricao] [varchar](255) NULL,
	[CreatedBy] [varchar](25) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [varchar](25) NULL,
	[ModifiedDate] [datetime] NULL,
	[ActiveFlag] [smallint] NULL,
 CONSTRAINT [PK_dbo.BoloesRequestsStatus] PRIMARY KEY CLUSTERED 
(
	[StatusRequestID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
