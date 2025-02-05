CREATE TABLE [Roles] (
  [Id] int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [RoleName] nvarchar(max) NOT NULL
)
GO

CREATE TABLE [Users] (
  [Id] int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [FirstName] nvarchar(max) NOT NULL,
  [LastName] nvarchar(max) NOT NULL,
  [RoleId] int NOT NULL
)
GO

CREATE TABLE [Products] (
  [Id] int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [Name] nvarchar(max) NOT NULL,
  [Price] decimal(18,2) NOT NULL
)
GO

CREATE TABLE [Customers] (
  [Id] int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [CustomerName] nvarchar(max) NOT NULL
)
GO

CREATE TABLE [CustomerContacts] (
  [FirstName] nvarchar(50) NOT NULL,
  [LastName] nvarchar(50) NOT NULL,
  [CustomerId] int NOT NULL,
  PRIMARY KEY ([FirstName], [LastName], [CustomerId])
)
GO

CREATE TABLE [StatusTypes] (
  [Id] int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [StatusName] nvarchar(max) NOT NULL
)
GO

CREATE TABLE [Projects] (
  [Id] char(6) PRIMARY KEY NOT NULL,
  [Title] nvarchar(max) NOT NULL,
  [Description] nvarchar(max),
  [StartDate] date NOT NULL,
  [EndDate] date,
  [CustomerId] int NOT NULL,
  [StatusId] int NOT NULL,
  [UserId] int NOT NULL,
  [ProductId] int NOT NULL
)
GO

ALTER TABLE [Users] ADD FOREIGN KEY ([RoleId]) REFERENCES [Roles] ([Id])
GO

ALTER TABLE [CustomerContacts] ADD FOREIGN KEY ([CustomerId]) REFERENCES [Customers] ([Id])
GO

ALTER TABLE [Projects] ADD FOREIGN KEY ([CustomerId]) REFERENCES [Customers] ([Id])
GO

ALTER TABLE [Projects] ADD FOREIGN KEY ([StatusId]) REFERENCES [StatusTypes] ([Id])
GO

ALTER TABLE [Projects] ADD FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id])
GO

ALTER TABLE [Projects] ADD FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id])
GO
