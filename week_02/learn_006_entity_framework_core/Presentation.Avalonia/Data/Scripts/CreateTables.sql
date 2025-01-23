CREATE TABLE [Users] (
  [Id] int PRIMARY KEY NOT NULL,
  [FirstName] nvarchar(50) NOT NULL,
  [LastName] nvarchar(50) NOT NULL,
  [Email] varchar(150) NOT NULL,
  [Password] nvarchar(max) NOT NULL
)
GO
