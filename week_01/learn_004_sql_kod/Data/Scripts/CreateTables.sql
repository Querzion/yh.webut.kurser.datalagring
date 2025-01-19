-- SQL Script
-- Created on 19/01/2025 by querzion

-- Write your SQL queries below:
DROP TABLE UserProfiles
DROP TABLE UserAuthentications
DROP TABLE Users
DROP TABLE Roles

CREATE TABLE Roles
(
    Id int not null identity primary key,
    RoleName nvarchar(20) not null unique
)

CREATE TABLE Users 
(
    Id int not null identity primary key,
    Created datetime2 null,
    Modified datetime2 null,
    IsEnabled bit not null default 0,
    RoleId int not null references Roles(Id)
)

CREATE TABLE UserAuthentications
(
    UserId int not null primary key,
    Email varchar(200) not null,
    Password nvarchar(max) not null
    
    constraint FK_UA_Users foreign key (UserId) references Users(Id)
)

CREATE TABLE UserProfiles
(
    UserId int not null primary key,
    FirstName nvarchar(50) not null,
    LastName nvarchar(50) not null,
    PhoneNumber varchar(20) null,
    ProfileImage nvarchar(max) null
    
    constraint FK_UP_Users foreign key (UserId) references Users(Id)
)