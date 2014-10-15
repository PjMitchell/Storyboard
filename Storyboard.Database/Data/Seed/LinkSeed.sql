If (SELECT count(*) FROM Story.Link) = 0
BEGIN
INSERT INTO Story.Link ([NodeARef], [NodeAType],[NodeBRef],[NodeBType],[LinkStrength],[LinkTypeRef],[LinkDirection])
VALUES 
(1,1,1,2,1,1,0),
(1,1,2,2,1,1,0),
(1,1,3,2,0.9,1,0),
(1,1,4,2,0.8,1,0)
END