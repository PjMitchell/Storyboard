﻿CREATE TABLE [Story].[Link]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[NodeARef] INT NOT NULL,
	[NodeAType] TINYINT NOT NULL,
	[NodeBRef] INT NOT NULL,
	[NodeBType] TINYINT NOT NULL,
	[LinkStrength] FLOAT NOT NULL,
	[LinkTypeRef] INT NOT NULL,
	[LinkDirection] TINYINT NOT NULL


)
