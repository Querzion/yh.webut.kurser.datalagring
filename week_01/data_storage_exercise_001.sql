CREATE TABLE [Kund] (
  [Kundnummer] int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [Namn] varchar(200) NOT NULL,
  [Kontaktperson] varchar(200) NOT NULL
)
GO

CREATE TABLE [Anställd] (
  [Anställningsnummer] int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [Namn] varchar(200) NOT NULL,
  [Roll] varchar(200) NOT NULL
)
GO

CREATE TABLE [Tjänst] (
  [Tjänstenummer] int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [Namn] varchar(200) NOT NULL,
  [Pris] money NOT NULL
)
GO

CREATE TABLE [Projekt] (
  [Projektnummer] int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [ProjektNamn] varchar(200) NOT NULL,
  [Beskrivning] nvarchar(1000),
  [StartDatum] datetime2 NOT NULL,
  [SlutDatum] datetime2 NOT NULL,
  [Status] nvarchar,
  [KundId] int NOT NULL,
  [TjänstId] int NOT NULL,
  [AnställningsId] int NOT NULL
)
GO

ALTER TABLE [Projekt] ADD FOREIGN KEY ([KundId]) REFERENCES [Kund] ([Kundnummer])
GO

ALTER TABLE [Projekt] ADD FOREIGN KEY ([TjänstId]) REFERENCES [Tjänst] ([Tjänstenummer])
GO

ALTER TABLE [Projekt] ADD FOREIGN KEY ([AnställningsId]) REFERENCES [Anställd] ([Anställningsnummer])
GO
