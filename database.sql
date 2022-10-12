CREATE DATABASE multiscan;

use multiscan;

CREATE TABLE users (
    id INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
    username VARCHAR(30) NOT NULL,
    password BINARY(64) NOT NULL,
    role TINYINT DEFAULT 0,
    salt UNIQUEIDENTIFIER NOT NULL,
    createdAt DATETIME DEFAULT GETDATE()
);

CREATE PROCEDURE AddUser @username VARCHAR(30),
@password VARCHAR(30),
@role TINYINT AS BEGIN DECLARE @salt UNIQUEIDENTIFIER = NEWID()
INSERT INTO
    users (username, password, role, salt)
VALUES
    (
        @username,
        HASHBYTES(
            'SHA2_512',
            @password + CAST(@salt AS NVARCHAR(36))
        ),
        @role,
        @salt
    )
END;

CREATE PROCEDURE LoginUser @username VARCHAR(30),
@password VARCHAR(30) AS BEGIN IF EXISTS (
    SELECT
        TOP 1 id
    FROM
        users
    WHERE
        username = @username
        and password = HASHBYTES(
            'SHA2_512',
            @password + CAST(Salt as NVARCHAR(36))
        )
) BEGIN
SELECT
    id,
    username,
    role
FROM
    users
WHERE
    username = @username
    and password = HASHBYTES(
        'SHA2_512',
        @password + CAST(Salt as NVARCHAR(36))
    )
END
END;