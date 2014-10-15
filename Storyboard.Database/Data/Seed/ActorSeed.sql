If (SELECT count(*) FROM Story.Actor) = 0
BEGIN
SET IDENTITY_INSERT  Story.Actor ON
INSERT INTO Story.Actor ([Id], [Name], [Description])
VALUES 
(1,N'Red Riding Hood', N'Girl who likes red'),
(2,N'The Big, Bad Wolf', N'A Wolf that is both big and bad'),
(3,N'Grandma', N'Red''s Grandma'),
(4,N'The woodsman', N'A man with an axe')
SET IDENTITY_INSERT  Story.Actor OFF
END