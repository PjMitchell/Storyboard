If (SELECT count(*) FROM Story.Actor) = 0
BEGIN
INSERT INTO Story.Actor ([Name], [Description])
VALUES 
(N'Red Riding Hood', N'Girl who likes red'),
(N'The Big, Bad Wolf', N'A Wolf that is both big and bad'),
(N'Grandma', N'Red''s Grandma'),
(N'The woodsman', N'A man with an axe')

END