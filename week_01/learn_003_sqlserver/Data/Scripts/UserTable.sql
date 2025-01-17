-- SQL Script
-- Created on 17/01/2025 by querzion

-- Write your SQL queries below:
IF OBJECT_ID('Users', 'U') IS NULL

CREATE TABLE Users (
   Id INT IDENTITY (1,1) PRIMARY KEY,
   FirstName NVARCHAR(50) NOT NULL,
   LastName NVARCHAR(50) NOT NULL,
   Email NVARCHAR(100) NOT NULL,
   PhoneNumber NVARCHAR(15) NULL
)
