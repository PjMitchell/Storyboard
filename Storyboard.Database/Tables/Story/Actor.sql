CREATE TABLE [Story].[Actor]
(
	[Id] INT NOT NULL PRIMARY KEY Identity(1,1), 
    [Name] NVARCHAR(200) NOT NULL, 
    [Description] NVARCHAR(4000) NULL
)
