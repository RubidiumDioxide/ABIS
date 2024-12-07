USE abis
GO 

CREATE TABLE [Book] (
	[ISBN] bigint NOT NULL,
	[Title] nvarchar (200) NOT NULL,
	[Author] nvarchar(200) NOT NULL,
	[Pages] smallint NOT NULL,
	[PublishingHouse] nvarchar (200) NOT NULL,
	[YearPublished] smallint NOT NULL, 
	[Description] nvarchar (500) NULL,
	[Quantity] tinyint NOT NULL,
	active bit NOT NULL,

	CONSTRAINT [PK_Book] PRIMARY KEY ([ISBN]) 
) 
GO 

CREATE TABLE [Reader] (
	[GradebookNum] int NOT NULL,
	[Surname] nvarchar (20) NOT NULL, 
	[FirstName] nvarchar (20) NOT NULL,
	[LastName] nvarchar (20) NULL, 
	[GroupNum] smallint NOT NULL,
	[DateOfBirth] date NOT NULL, 
	[Active] bit NOT NULL DEFAULT 1,
	[Debt] bit NOT NULL DEFAULT 0,

	CONSTRAINT [PK_Reader] PRIMARY KEY ([GradebookNum])
)
GO

CREATE TABLE [Book_Reader] (
	[ID] bigint IDENTITY, 
	[ReaderGradebookNum] int NOT NULL, 
	[BookISBN] bigint NOT NULL, 
	[DateBorrowed] date NOT NULL, 
	[DateReturned] date NULL,
	[DateDeadline] date NOT NULL,
	[Returned] bit DEFAULT 0 NOT NULL, 

	CONSTRAINT [PK_Book_Reader] PRIMARY KEY ([ID])
)
GO

CREATE TABLE [BookHistory](
	[OperationID] bigint NOT NULL,
	[BookISBN] bigint NOT NULL,
	[Action] varchar(20) NOT NULL,
	[Date] date NOT NULL

	CONSTRAINT [PK_BookHistory] PRIMARY KEY ([BookISBN])
)
GO

CREATE TABLE [ReaderHistory](
	[OperationID] bigint NOT NULL,
	[ReaderGradebookNum] int NOT NULL,
	[Action] varchar(20) NOT NULL,
	[Date] date NOT NULL

	CONSTRAINT [PK_ReaderHistory] PRIMARY KEY ([ReaderGradebookNum])
)
GO

ALTER TABLE [Book] 
	ADD
		CONSTRAINT [Format_ISBN] CHECK (([ISBN] > 9780000000000) and ([ISBN] < 9790000000000)),
		CONSTRAINT [Unsigned_Pages] CHECK ([Pages] > 0),
		CONSTRAINT [Format_YearPublished] CHECK (([YearPublished] > 0) and ([YearPublished] <= YEAR(GETDATE()))),
		CONSTRAINT [Unsigned_Quantity] CHECK ([Quantity] >= 0)
GO

ALTER TABLE [Reader]
	ADD 
		CONSTRAINT [Format_GroupNum] CHECK (([GroupNum] > 1000) and ([GroupNum] < 10000))
GO

ALTER TABLE [Book_Reader]
	ADD 
		CONSTRAINT [FK_Reader-Book_Reader] FOREIGN KEY ([ReaderGradebookNum]) REFERENCES [Reader] ([GradebookNum]),
		CONSTRAINT [FK_Book-Book_Reader] FOREIGN KEY ([BookISBN]) REFERENCES [Book] ([ISBN]),
		CONSTRAINT [Dates] CHECK (([DateBorrowed] <= [DateReturned]) and ([DateBorrowed] <= [DateDeadline]))
GO

ALTER TABLE [BookHistory]
	ADD
		CONSTRAINT [FK_Book-BookHistory] FOREIGN KEY ([BookISBN]) REFERENCES [Book] ([ISBN]),
		CONSTRAINT [IN_BookHistoryAction] CHECK (Action IN ('Добавление', 'Удаление', 'Изменение')) 
GO

ALTER TABLE [ReaderHistory]
	ADD
		CONSTRAINT [FK_Reader-ReaderHistory] FOREIGN KEY ([ReaderGradebookNum]) REFERENCES [Reader] ([GradebookNum]),
		CONSTRAINT [IN_ReaderHistoryAction] CHECK (Action IN ('Добавление', 'Удаление', 'Изменение')) 
GO

CREATE INDEX [Book_Title_Ind] 
	ON [Book] ([Title])
GO

CREATE INDEX [Book_Qauntity_Ind]
	ON [Book] ([Quantity]) 
GO

CREATE INDEX [Reader_Surname_Ind] 
	ON [Reader] ([Surname])
GO

CREATE INDEX [Reader_GroupNum_Ind]
	ON [Reader] ([GroupNum]) 
GO

USE abis
GO
SELECT * FROM [Book]
GO