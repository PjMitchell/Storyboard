CREATE TABLE [dbo].[AspNetUserClaims]
(
	[Id] INT Identity(1,1) PRIMARY KEY,
	[ClaimType] nvarchar(max),
	[ClaimValue] nvarchar(max),
	[UserId] nvarchar(450),
	CONSTRAINT [FK_UserClaim_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers](Id) 

)
