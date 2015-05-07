CREATE TABLE [Story].[StorySection]
(
    [Id] INT NOT NULL PRIMARY KEY Identity(1,1), 
    [Description] NVARCHAR(200) NOT NULL, 
    [HierarchyLevel] INT NOT NULL,
    [Order] INT NOT NULL,
    [ParentHierarchyElementId] INT NOT NULL DEFAULT(-1),
    [StoryId] INT NOT NULL,
    CONSTRAINT [FK_StorySection_Story] FOREIGN KEY ([StoryId]) REFERENCES [Story].[Story] ON DELETE CASCADE
)
