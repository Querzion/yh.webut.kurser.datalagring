CREATE TABLE [UnitTypes] (
  [Id] int PRIMARY KEY NOT NULL,
  [Unit] nvarchar(50) NOT NULL
)
GO

CREATE TABLE [StatusTypes] (
  [Id] int PRIMARY KEY NOT NULL,
  [Status] nvarchar(50) NOT NULL
)
GO

CREATE TABLE [RoleTypes] (
  [Id] int PRIMARY KEY NOT NULL,
  [Role] nvarchar(50) NOT NULL
)
GO

CREATE TABLE [CurrencyTypes] (
  [Id] int PRIMARY KEY NOT NULL,
  [CurrencyCode] char(3) NOT NULL,
  [CurrencySymbol] char(2) NOT NULL,
  [Currency] varchar(50) NOT NULL
)
GO

CREATE TABLE [Addresses] (
  [Id] int PRIMARY KEY NOT NULL,
  [StreetName] nvarchar(50) NOT NULL,
  [PostalCode] char(6) NOT NULL,
  [City] nvarchar(50) NOT NULL
)
GO

CREATE TABLE [Customers] (
  [Id] int PRIMARY KEY NOT NULL,
  [CustomerName] nvarchar(50) NOT NULL,
  [AddressId] int NOT NULL
)
GO

CREATE TABLE [ContactPersons] (
  [FirstName] nvarchar(50) NOT NULL,
  [LastName] nvarchar(50) NOT NULL,
  [CustomerId] int NOT NULL,
  PRIMARY KEY ([FirstName], [LastName], [CustomerId])
)
GO

CREATE TABLE [Users] (
  [Id] int PRIMARY KEY NOT NULL,
  [FirstName] nvarchar(50) NOT NULL,
  [LastName] nvarchar(50) NOT NULL,
  [AddressId] int NOT NULL,
  [RoleId] int NOT NULL
)
GO

CREATE TABLE [Services] (
  [Id] int PRIMARY KEY NOT NULL,
  [Name] nvarchar(150) NOT NULL,
  [price] decimal(18,2) NOT NULL,
  [CurrencyTypeId] int NOT NULL,
  [UnitTypeId] int NOT NULL
)
GO

CREATE TABLE [Projects] (
  [Id] varchar(10) PRIMARY KEY NOT NULL,
  [Title] nvarchar(150) NOT NULL,
  [Description] nvarchar(max),
  [StartDate] date NOT NULL,
  [EndDate] date,
  [ServiceId] int NOT NULL,
  [StatusTypeId] int NOT NULL,
  [CustomerId] int NOT NULL,
  [UserId] int NOT NULL
)
GO

ALTER TABLE [Customers] ADD FOREIGN KEY ([AddressId]) REFERENCES [Addresses] ([Id])
GO

ALTER TABLE [ContactPersons] ADD FOREIGN KEY ([CustomerId]) REFERENCES [Customers] ([Id])
GO

ALTER TABLE [Users] ADD FOREIGN KEY ([AddressId]) REFERENCES [Addresses] ([Id])
GO

ALTER TABLE [Users] ADD FOREIGN KEY ([RoleId]) REFERENCES [RoleTypes] ([Id])
GO

ALTER TABLE [Services] ADD FOREIGN KEY ([CurrencyTypeId]) REFERENCES [CurrencyTypes] ([Id])
GO

ALTER TABLE [Services] ADD FOREIGN KEY ([UnitTypeId]) REFERENCES [UnitTypes] ([Id])
GO

ALTER TABLE [Projects] ADD FOREIGN KEY ([ServiceId]) REFERENCES [Services] ([Id])
GO

ALTER TABLE [Projects] ADD FOREIGN KEY ([StatusTypeId]) REFERENCES [StatusTypes] ([Id])
GO

ALTER TABLE [Projects] ADD FOREIGN KEY ([CustomerId]) REFERENCES [Customers] ([Id])
GO

ALTER TABLE [Projects] ADD FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id])
GO
