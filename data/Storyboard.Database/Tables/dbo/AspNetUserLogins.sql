CREATE TABLE [dbo].[AspNetUserLogins]
(
	[LoginProvider] nvarchar(450),
    [ProviderDisplayName] nvarchar(max),
    [ProviderKey] nvarchar(450),
    [UserId] nvarchar(450),
	Constraint [PK_UserLogins] PRIMARY KEY ([LoginProvider],[ProviderKey]),
	CONSTRAINT [FK_UserLogins_UserId] FOREIGN KEY([UserId]) REFERENCES  [dbo].[AspNetUsers](Id) 

)
