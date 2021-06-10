
CREATE TABLE [dbo].[BoloesRequests](
	[NomeBolao] [varchar](100) NOT NULL,
	[RequestID] [int] NOT NULL,
	[Descricao] [varchar](255) NULL,
	[AnsweredDate] [datetime] NOT NULL,
	[AnsweredBy] [varchar](50) NULL,
	[StatusRequestID] [int] NOT NULL,
	[Owner] [varchar](50) NULL,
	[RequestedDate] [datetime] NOT NULL,
	[RequestedBy] [varchar](50) NULL,
	[CreatedBy] [varchar](25) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [varchar](25) NULL,
	[ModifiedDate] [datetime] NULL,
	[ActiveFlag] [smallint] NULL,
 CONSTRAINT [PK_dbo.BoloesRequests] PRIMARY KEY CLUSTERED 
(
	[NomeBolao] ASC,
	[RequestID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


ALTER TABLE [dbo].[BoloesRequests]   ADD  CONSTRAINT [FK_dbo.BoloesRequests_dbo.Boloes_NomeBolao] FOREIGN KEY([NomeBolao])
REFERENCES [dbo].[Boloes] ([Nome])
GO
ALTER TABLE [dbo].[BoloesRequests] CHECK CONSTRAINT [FK_dbo.BoloesRequests_dbo.Boloes_NomeBolao]
GO
ALTER TABLE [dbo].[BoloesRequests]   ADD  CONSTRAINT [FK_dbo.BoloesRequests_dbo.BoloesRequestsStatus_StatusRequestID] FOREIGN KEY([StatusRequestID])
REFERENCES [dbo].[BoloesRequestsStatus] ([StatusRequestID])
GO
ALTER TABLE [dbo].[BoloesRequests] CHECK CONSTRAINT [FK_dbo.BoloesRequests_dbo.BoloesRequestsStatus_StatusRequestID]
GO
GO
