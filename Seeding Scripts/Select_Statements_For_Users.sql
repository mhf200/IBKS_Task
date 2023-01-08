SELECT  * FROM Users;
SELECT  * FROM Projects;

SELECT * FROM Users
WHERE Name='Alex';


SELECT * FROM Users
WHERE Name='Alex' OR Email='mhmd@gmail.com';

SELECT * FROM Users
WHERE NOT Name='Alex';

SELECT * FROM Users
ORDER BY salary;


SELECT Name, salary
FROM Users
WHERE Name IS NOT NULL;

SELECT Users.Name, Projects.ProjName
FROM Users
INNER JOIN Projects ON Users.Name = UserName
ORDER BY Users.Name;

SELECT Users.Name, Projects.ProjName
FROM Users
FULL OUTER JOIN Projects ON Users.Name = UserName
ORDER BY Users.Name;

SELECT Users.Name, Users.salary, Users.Email ,Users.DateOfBirth, Users.Department , Projects.ProjName
FROM Users
FULL OUTER JOIN Projects ON Users.Name = UserName
ORDER BY Users.Name;





