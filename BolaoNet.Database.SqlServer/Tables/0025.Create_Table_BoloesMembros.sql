﻿
CREATE TABLE [dbo].[BoloesMembros](
	[CreatedBy] [varchar](25) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [varchar](25) NULL,
	[ModifiedDate] [datetime] NULL,
	[ActiveFlag] [bit] NULL,
	[UserName] [varchar](25) NOT NULL,
	[NomeBolao] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserName] ASC,
	[NomeBolao] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

--ALTER TABLE [dbo].[BoloesMembros]  ADD FOREIGN KEY([CreatedBy])
--REFERENCES [dbo].[Users] ([UserName])
--GO

--ALTER TABLE [dbo].[BoloesMembros]  ADD FOREIGN KEY([ModifiedBy])
--REFERENCES [dbo].[Users] ([UserName])
--GO

ALTER TABLE [dbo].[BoloesMembros]  ADD  CONSTRAINT FK_BoloesMembros_Boloes_NomeBolao FOREIGN KEY([NomeBolao])
REFERENCES [dbo].[Boloes] ([Nome])
GO

ALTER TABLE [dbo].[BoloesMembros]  ADD  CONSTRAINT FK_BoloesMembros_Users_UserName FOREIGN KEY([UserName])
REFERENCES [dbo].[Users] ([UserName])
GO
