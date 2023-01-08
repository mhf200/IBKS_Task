ALTER TABLE Projects
   ADD FOREIGN KEY (UserName) REFERENCES Users (Name);