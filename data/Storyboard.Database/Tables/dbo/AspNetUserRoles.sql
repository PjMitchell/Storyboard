CREATE TABLE [dbo].[AspNetUserRoles]
(
	[UserId] nvarchar(450),
	[RoleId] nvarchar(450),
	CONSTRAINT [FK_UserRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[AspNetRoles](Id), 
	Constraint [PK_UserRoles] PRIMARY KEY ([UserId],[RoleId]),
	CONSTRAINT [FK_UserRoles_UserId] FOREIGN KEY([UserId]) REFERENCES  [dbo].[AspNetUsers](Id) 
)
