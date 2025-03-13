CREATE TABLE [AgencyMatrixDB].[dbo].Users (
    id INT PRIMARY KEY IDENTITY,  -- Unique user ID
    name VARCHAR(255) NOT NULL,          -- Full name of the user
    email VARCHAR(255) UNIQUE NOT NULL,  -- Unique email address
    creation_date DATETIME DEFAULT CURRENT_TIMESTAMP, -- Date of creation
    active BIT DEFAULT 1,         -- Active status
 );
Go;

CREATE PROCEDURE [dbo].sp_Insert
    @Name VARCHAR(255),
    @Email VARCHAR(255)
AS
BEGIN
    INSERT INTO [AgencyMatrixDB].[dbo].Users (name, email)
    VALUES (@Name, @Email);
END;
Go;

CREATE VIEW [dbo].vwGetUsers
AS
    SELECT 
	id,
	name,
	email,
	creation_date,
	active
	FROM [AgencyMatrixDB].[dbo].Users WITH (NOLOCK)
GO;

CREATE PROCEDURE [dbo].sp_GetUsers 
AS
BEGIN
	SELECT * 
	FROM [dbo].vwGetUsers WITH (NOLOCK)
	WHERE active = 1
	ORDER BY name ASC;
END
GO;

CREATE PROCEDURE [dbo].sp_GetUserById
    @Id INT
AS
BEGIN
   SELECT * 
	FROM [dbo].vwGetUsers WITH (NOLOCK)
	WHERE id= @Id 
	ORDER BY name ASC;
END;
GO; 

CREATE PROCEDURE [dbo].sp_DeleteUser
    @Id INT,
	@Active BIT
AS
BEGIN
    UPDATE [AgencyMatrixDB].[dbo].Users 
	SET active = @Active
	WHERE id = @Id;
END;
GO;

--EXEC [dbo].sp_Insert @Name = 'John Doe', @Email = 'john.doe@example.com';
--EXEC [dbo].sp_Insert  @Name = 'Alice Smith', @Email='alice.smith@example.com';
--EXEC [dbo].sp_Insert  @Name = 'Bob Johnson', @Email= 'bob.johnson@example.com';
--EXEC [dbo].sp_Insert  @Name = 'Charlie Brown', @Email='charlie.brown@example.com';
--EXEC [dbo].sp_Insert  @Name = 'David Lee', @Email='david.lee@example.com';
--EXEC [dbo].sp_Insert  @Name = 'Eve White', @Email='eve.white@example.com';

--EXEC [dbo].sp_Insert  @Name = 'Grace Kim', @Email='grace.kim@example.com';
--EXEC [dbo].sp_Insert  @Name = 'Henry Lee', @Email='henry.lee@example.com';
--EXEC [dbo].sp_Insert  @Name = 'Ivy Park', @Email='ivy.park@example.com';
--EXEC [dbo].sp_Insert @Name = 'Henry Adams', @Email = 'henry.adams@example.com';
--EXEC [dbo].sp_Insert @Name = 'Isabel Torres', @Email = 'isabel.torres@example.com';
--EXEC [dbo].sp_Insert @Name = 'Jacky Hill', @Email = 'jacky.hill@example.com';

--EXEC [dbo].sp_Insert @Name = 'Liam James', @Email = 'liam.james@example.com';
--EXEC [dbo].sp_Insert @Name = 'Mia Green', @Email = 'mia.green@example.com';
--EXEC [dbo].sp_Insert @Name = 'Noah Brown', @Email = 'noah.brown@example.com';
--EXEC [dbo].sp_Insert @Name = 'Olivia Davis', @Email = 'olivia.davis@example.com';
--EXEC [dbo].sp_Insert @Name = 'Peyton Taylor', @Email = 'peyton.taylor@example.com';

EXEC [dbo].sp_GetUsers 

EXEC [dbo].sp_GetUserById @Id = 1

EXEC [dbo].sp_DeleteUser  @Id = 1,@Active=1