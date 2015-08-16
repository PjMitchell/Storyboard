CREATE TABLE [dbo].[AspNetRoleClaims]
(
	[Id] INT Identity(1,1) PRIMARY KEY,
	[ClaimType] nvarchar(max),
	[ClaimValue] nvarchar(max),
	[RoleId] nvarchar(450),
	CONSTRAINT [FK_RoleClaim_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[AspNetRoles](Id) 

)
