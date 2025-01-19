-- SQL Script
-- Created on 19/01/2025 by querzion

-- Write your SQL queries below:
-- INSERT INTO Roles VALUES
--     ('Admin'),
--     ('User')
-- -- 
-- INSERT INTO Users (IsEnabled, RoleId) VALUES (1, 1)
-- 
-- INSERT INTO UserAuthentications VALUES (1, 'iam@querzion.com', 'Scam2014')
-- 
-- INSERT INTO UserProfiles VALUES (1, 'Mats', 'Lindqvist', '0700797082', '/home/querzion/RiderProjects/Images/s.png')
-- 
-- UPDATE UserProfiles SET FirstName = 'Slisk'
-- UPDATE UserAuthentications SET Email = 'slisk.lindqvist@querzion.com'
-- 
-- IF EXISTS (SELECT 1 FROM Users WHERE Id = 4)
--     UPDATE Users SET RoleId = 1 WHERE Id = 4
-- 
-- IF NOT EXISTS (SELECT 1 FROM UserAuthentications WHERE Email = 'iam@querzion.com')
-- BEGIN
--     INSERT INTO Users (IsEnabled, RoleId) VALUES (1, 2)
--     INSERT INTO UserAuthentications VALUES (2, 'trash@gmail.com', 'TrashPost123!')
--     INSERT INTO UserProfiles VALUES (2, 'Terminal', 'Error', '', '')
-- END

IF EXISTS (SELECT 1 FROM UserAuthentications WHERE Email = 'trash@gmail.com')
BEGIN
    DELETE FROM UserProfiles WHERE UserId = 2
    DELETE FROM UserAuthentications WHERE UserId = 2
    DELETE FROM Users Where Id = 2
END