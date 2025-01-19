-- SQL Script
-- Created on 19/01/2025 by querzion

-- Write your SQL queries below:
-- SELECT * FROM Roles;
-- SELECT RoleName FROM Roles;
-- SELECT * FROM Roles WHERE RoleName = 'Admin';
-- SELECT * FROM Roles WHERE Id = 2;
-- SELECT * FROM Roles ORDER BY RoleName;
-- SELECT * FROM Roles ORDER BY RoleName DESC;
-- SELECT TOP 1 * FROM Roles;


-- SELECT * FROM Users;

-- SELECT
--     Users.Id,
--     Users.IsEnabled,
--     Roles.RoleName
-- FROM Users
-- JOIN Roles ON Role.Id = Users.RoleId;
-- WHERE Users.Id = 1;

-- SELECT
--     u.Id,
--     u.IsEnabled,
--     r.RoleName
-- FROM Users u
-- JOIN Roles r ON r.Id = u.RoleId;
-- WHERE u.Id = 1;

-- SELECT * FROM UserAuthentications;

-- SELECT
--     u.Id, u.IsEnabled,
--     r.RoleName,
--     ua.Email
-- FROM Users u
-- JOIN Roles r ON r.Id = u.RoleId
-- JOIN UserAuthentications ua ON ua.UserId = u.Id

-- SELECT * FROM UserProfiles;

SELECT
    u.Id, u.IsEnabled,
    r.RoleName,
    ua.Email,
    up.FirstName, up.Lastname, up.PhoneNumber, up.ProfileImage
FROM Users u
JOIN Roles r ON r.Id = u.RoleId
JOIN UserAuthentications ua ON ua.UserId = u.Id
JOIN UserProfiles up ON up.UserId = u.Id