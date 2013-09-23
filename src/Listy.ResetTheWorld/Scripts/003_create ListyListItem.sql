
CREATE TABLE [dbo].[ListyListItem] (
	[Id] UNIQUEIDENTIFIER NOT NULL,
	[ListyListId] UNIQUEIDENTIFIER NOT NULL,
	[Name] NVARCHAR(MAX) NOT NULL,
	[Ordinal] INT NOT NULL,

	CONSTRAINT [PK_ListyListItem]
		PRIMARY KEY ([Id]),
	CONSTRAINT [FK_ListyListItem_ListyList]
		FOREIGN KEY ([ListyListId])
		REFERENCES [dbo].[ListyList] ([Id])
)
GO

