
CREATE TABLE [dbo].[UserInRole](
	[UserName] [varchar](50) NOT NULL,
	[RoleName] [varchar](150) NOT NULL,
	[CreatedBy] [varchar](25) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [varchar](25) NULL,
	[ModifiedDate] [datetime] NULL,
	[ActiveFlag] [smallint] NULL,
 CONSTRAINT [PK_dbo.UserInRole] PRIMARY KEY CLUSTERED 
(
	[UserName] ASC,
	[RoleName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


----ALTER TABLE [dbo].[UsersInRoles]  ADD  CONSTRAINT FK_UsersInRoles_Users_CreatedBy FOREIGN KEY([CreatedBy])
----REFERENCES [dbo].[Users] ([UserName])
----GO

----ALTER TABLE [dbo].[UsersInRoles]  ADD  CONSTRAINT FK_UsersInRoles_Users_ModifiedBy FOREIGN KEY([ModifiedBy])
----REFERENCES [dbo].[Users] ([UserName])
----GO

--ALTER TABLE [dbo].[UsersInRoles]  ADD  CONSTRAINT FK_UsersInRoles_Roles_RoleName FOREIGN KEY([RoleName])
--REFERENCES [dbo].[Roles] ([RoleName])
--GO

--ALTER TABLE [dbo].[UsersInRoles]  ADD  CONSTRAINT FK_UsersInRoles_Users_UserName FOREIGN KEY([UserName])
--REFERENCES [dbo].[Users] ([UserName])
--GO

--ALTER TABLE [dbo].[UsersInRoles]  ADD CONSTRAINT FK_UsersInRoles_Users_FOREIGN KEY([UserName])
--REFERENCES [dbo].[Users] ([UserName])
--GO


ALTER TABLE [dbo].[UserInRole]   ADD  CONSTRAINT [FK_dbo.UserInRole_dbo.Roles_RoleName] FOREIGN KEY([RoleName])
REFERENCES [dbo].[Roles] ([RoleName])
GO
ALTER TABLE [dbo].[UserInRole] CHECK CONSTRAINT [FK_dbo.UserInRole_dbo.Roles_RoleName]
GO
ALTER TABLE [dbo].[UserInRole]   ADD  CONSTRAINT [FK_dbo.UserInRole_dbo.Usuarios_UserName] FOREIGN KEY([UserName])
REFERENCES [dbo].[Usuarios] ([UserName])
GO
ALTER TABLE [dbo].[UserInRole] CHECK CONSTRAINT [FK_dbo.UserInRole_dbo.Usuarios_UserName]
GO