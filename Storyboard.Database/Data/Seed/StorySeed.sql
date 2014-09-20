If (SELECT count(*) FROM Story.Story) = 0
BEGIN
INSERT INTO Story.Story (Title, [Synopsis])
VALUES 
(N'Red Riding Hood', N'Girl visits Granma, it does end well for grandma');
END