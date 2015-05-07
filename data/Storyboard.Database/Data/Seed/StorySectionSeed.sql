If (SELECT count(*) FROM Story.StorySection) = 0
BEGIN
SET IDENTITY_INSERT  Story.StorySection ON
INSERT INTO Story.StorySection ([Id], [Description], [HierarchyLevel],[Order],[ParentHierarchyElementId],[StoryId])
VALUES 
(1,N'Act one', 1,1,-1,1),
(2,N'Act two', 1,2,-1,1),
(3,N'Act three', 1,3,-1,1);
SET IDENTITY_INSERT  Story.StorySection OFF
END