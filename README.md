# yh.webut.kurser.datalagring
This repo was created to house the 6 week database course. 

#### CRUD
Create
Read
Update
Delete

# Video Library

## Introduction Video
* https://youtu.be/p37aXuQ3pro

## Databasnormalisering (1-3NF)
* https://youtu.be/9K6ZHTriZS0

##### 1NF - Första Normaliseringsformen
* Det måste finnas en primär nyckel som unikt identifierar varje rad i tabellen
* Det får inte förekomma några flervärdiga attribut i en/ett kolumn/fält
##### 2NF - Andra Normaliseringsformen
* Det får inte finnas några återupprepande kolumner i en tabell.
##### 3NF - Tredje Normaliseringsformen
* Alla kolumner måste vara härledd den primära nyckeln i en tabell.

## ERD - Entity-Relationship Diagram (Konceptuell modellering)
* https://youtu.be/l-yT20hG620

##### Primary Key (PK)
id => Customer => FirstName, LastName, Email

##### Entity 
Address => Address =>  id, StreetName, PostalCode, City

##### Relationship - Foreign Key (FK)
Customer --- Has One --- Address
(Conceptual_Models folder for more clarity)

## Databasmodellering med Crow's Foot - Entity-Relationship Diagram
* https://youtu.be/ItfEoQ0PUCY

x(n) ?> 123 56 (PostalCode with a space is 6 characters n=6 x=one of the below)

##### char(n) - ascii based (n = 1 byte) 
Lagrar ett fixerat värde med n-tecken
(PostalCode would be char(6)) = 6 bytes
12345/123 45 = 6 bytes
##### nchar(n) - unicode based (n = 2 bytes)
Lagrar ett fixerat Unicode värde med n-tecken
(can use åäö and other special signs)
(PostalCode would be nchar(6)) = 12 bytes
##### varchar(n) - (n = 1 byte + var = 1 byte)
Lagrar ett dynamiskt värde upp till n-värde
(PostalCode would be varchar(6)) = upto 7bytes
12345/123 45 = 6/7 bytes
##### nvarchar(n) - (n = 2 bytes + var = 2 bytes)
Lagrar ett dynamiskt Unicode värde upp till n-tecken
(PostalCode would be nvarchar(6)) = upto 14 bytes
##### varbinary(n) - (n = 1 byte + var = 2 bytes)
Lagrar binära data som bilder, filer och annat 
(kan lagra upp till 2GB data om n=max)
Bara för att den kan, betyder det inte att man ska.
Bilder föredrar man att lägga på en separat server och endast
länka innehållet till. 

More info in the Database_Modelling folder.

### Primary Key (PK)
Ett värde som kan unikt identifiera varje rad i en tabell
### Foreign Key (FK)
Ett värde som kopplas till och är samm som en annan tabells primära nyckel (PK)

## dbDiagram.io for making crow's foot diagrams
https://dbdiagram.io/
##### Documentation
https://dbml.dbdiagram.io/docs/