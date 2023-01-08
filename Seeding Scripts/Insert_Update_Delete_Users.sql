--INSERT INTO Users(Id , Name, Email, salary , DateOfBirth , Department)
--VALUES ('F9DCD826-CB9D-486F-B6F8-DF38B3F860E5' , 'Sally', 'Sally@gmail.com', 13200 , '2000-03-19', 'Physics');

UPDATE Users
SET salary=2300
WHERE DateOfBirth='2000-09-02';