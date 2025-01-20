-- SQL Script
-- Created on 20/01/2025 by querzion

-- Tips from ChatGPT ( https://chatgpt.com/share/678eae5d-9cdc-8005-9290-7803bc22e7f7 )

-- Write your SQL queries below:
-- Delete possbile tables if they exist
-- Drop TABLE If exists Projekt;
-- Drop Table IF exists Kund;
-- DROP Table if EXISTS Anställd;
-- Drop Table if exists Tjänst;
-- 
-- -- Create tables
-- create table Kund
-- (
--     KundId int not null primary key,
--     Namn nvarchar(100) not null,
--     Kontaktperson nvarchar(100) not null
-- );
-- 
-- CREATE table Anställd
-- (
--     AnställningsNummer int not null PRIMARY KEY,
--     Namn nvarchar(100) not null,
--     Roll nvarchar(50) not null unique 
-- );
-- 
-- create table Tjänst
-- (
--     TjänstId int not null PRIMARY KEY,
--     Namn nvarchar(20) not null,
--     Pris money not null
-- );
-- 
-- create table Projekt
-- (
--     -- Autoincrement on the Project number
--     ProjektNummer int not null PRIMARY KEY, --identity(101,1), 
--     -- ChatGPT ( https://chatgpt.com/share/678eb48c-bfc0-8005-a592-3012656b3ffe )
--     -- With a P- added before the Project Id
--     FormateratProjektNumber AS CONCAT('P-', ProjektNummer),
--     Namn nvarchar(50) not null,
--     Beskrivning nvarchar(1000) not null,
--     StartDatum datetime2 null,
--     SlutDatum datetime2 null,
--     Status nvarchar(12) not null,
--     KundId int not null,
--     TjänstId int not null,
--     ProjektansvarigId int not null,
--     constraint FK_Projekt_Kund foreign key (KundId) references Kund(KundId),
--     constraint FK_Projekt_Tjänst foreign key (TjänstId) references Tjänst(TjänstId),
--     constraint FK_Projekt_Anställd foreign key (ProjektansvarigId) references Anställd(AnställningsNummer)
-- );
-- 
-- -- Add information about the first event
-- insert into Kund (KundId, Namn, Kontaktperson) values (1, 'ABC Consulting', 'Anna Karlsson');
-- Insert into Tjänst (TjänstId, Namn, Pris) values (1, 'Konsulttid', 1000);
-- insert into Anställd (AnställningsNummer, Namn, Roll) values (101, 'Erik Andersson', 'Projektledare');
-- insert into Projekt (ProjektNummer,Namn, Beskrivning, StartDatum, SlutDatum, Status, KundId, TjänstId, ProjektansvarigId)
--     VALUES (101,'Webbutveckling', 'Utveckling av ny webbplats', '2025-01-01', '2025-03-01', 'Pågående', 1, 1, 101);
-- 
-- -- Add information about the second event
-- insert into Kund (KundId, Namn, Kontaktperson) values (2, 'DEF Industries', 'Bengt Svensson');
-- Insert into Tjänst (TjänstId, Namn, Pris) values (2, 'Utbildning', 5000);
-- insert into Anställd (AnställningsNummer, Namn, Roll) values (102, 'Sara Nilsson', 'Konsult');
-- insert into Projekt (ProjektNummer, Namn, Beskrivning, StartDatum, SlutDatum, Status, KundId, TjänstId, ProjektansvarigId) 
--     VALUES (102,'Systemintegration', 'Integration av ERP-system', '2025-02-01', '2025-06-01', 'Ej påbörjad', 2, 2, 102); 

-- Show All data as a list
-- select
--     p.ProjektNummer,
--     p.Namn, p.Beskrivning, p.StartDatum, p.SlutDatum,
--     p.Status, k.Namn, k.Kontaktperson, a.Namn, a.Roll,
--     t.Namn, t.Pris
-- from Projekt p
-- join Kund k On k.KundId = p.KundId
-- Join Anställd a On a.AnställningsNummer = p.ProjektansvarigId
-- join Tjänst t on t.TjänstId = p.TjänstId

-- Change the status of the second project event from 'ej påbörjad' to 'pågående'
-- Update Projekt set Status = 'Pågående'

-- Show All info again.
-- select
--     p.ProjektNummer,
--     p.Namn, p.Beskrivning, p.StartDatum, p.SlutDatum,
--     p.Status, k.Namn, k.Kontaktperson, a.Namn, a.Roll,
--     t.Namn, t.Pris
-- from Projekt p
--          join Kund k On k.KundId = p.KundId
--          Join Anställd a On a.AnställningsNummer = p.ProjektansvarigId
--          join Tjänst t on t.TjänstId = p.TjänstId

-- Delete everything regarding project 102
If EXISTS (select 1 from Projekt where ProjektNummer = 102)
begin 
    DELETE from Projekt where ProjektNummer = 102
    Delete from Anställd where AnställningsNummer = 102
    Delete from Kund where KundId = 2
    Delete from Tjänst where TjänstId = 2
end