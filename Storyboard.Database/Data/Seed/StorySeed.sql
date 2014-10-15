If (SELECT count(*) FROM Story.Story) = 0
BEGIN
SET IDENTITY_INSERT  Story.Story ON
INSERT INTO Story.Story ([Id], Title, [Synopsis])
VALUES 
(1,N'Red Riding Hood', N'Girl visits Granma, it does end well for grandma');
SET IDENTITY_INSERT  Story.Story OFF
END