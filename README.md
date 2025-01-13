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