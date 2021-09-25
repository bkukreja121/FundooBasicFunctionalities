IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Users] (
    [UserId] bigint NOT NULL IDENTITY,
    [FirstName] nvarchar(max) NULL,
    [LastName] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    [Password] nvarchar(max) NULL,
    [CreatedAt] datetime2 NOT NULL,
    [ModifiedAt] datetime2 NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([UserId])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210920094107_FirstMigration', N'5.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'UserId', N'CreatedAt', N'Email', N'FirstName', N'LastName', N'ModifiedAt', N'Password') AND [object_id] = OBJECT_ID(N'[Users]'))
    SET IDENTITY_INSERT [Users] ON;
INSERT INTO [Users] ([UserId], [CreatedAt], [Email], [FirstName], [LastName], [ModifiedAt], [Password])
VALUES (CAST(1 AS bigint), '0001-01-01T00:00:00.0000000', N'uncle.bob@gmail.com', N'Uncle', N'Bob', '0001-01-01T00:00:00.0000000', N'1234');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'UserId', N'CreatedAt', N'Email', N'FirstName', N'LastName', N'ModifiedAt', N'Password') AND [object_id] = OBJECT_ID(N'[Users]'))
    SET IDENTITY_INSERT [Users] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'UserId', N'CreatedAt', N'Email', N'FirstName', N'LastName', N'ModifiedAt', N'Password') AND [object_id] = OBJECT_ID(N'[Users]'))
    SET IDENTITY_INSERT [Users] ON;
INSERT INTO [Users] ([UserId], [CreatedAt], [Email], [FirstName], [LastName], [ModifiedAt], [Password])
VALUES (CAST(2 AS bigint), '0001-01-01T00:00:00.0000000', N'aunty.bob@gmail.com', N'Aunty', N'Bob', '0001-01-01T00:00:00.0000000', N'1234');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'UserId', N'CreatedAt', N'Email', N'FirstName', N'LastName', N'ModifiedAt', N'Password') AND [object_id] = OBJECT_ID(N'[Users]'))
    SET IDENTITY_INSERT [Users] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210920095115_Second', N'5.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DELETE FROM [Users]
WHERE [UserId] = CAST(1 AS bigint);
SELECT @@ROWCOUNT;

GO

DELETE FROM [Users]
WHERE [UserId] = CAST(2 AS bigint);
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210920095713_Third', N'5.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'UserId', N'CreatedAt', N'Email', N'FirstName', N'LastName', N'ModifiedAt', N'Password') AND [object_id] = OBJECT_ID(N'[Users]'))
    SET IDENTITY_INSERT [Users] ON;
INSERT INTO [Users] ([UserId], [CreatedAt], [Email], [FirstName], [LastName], [ModifiedAt], [Password])
VALUES (CAST(1 AS bigint), '0001-01-01T00:00:00.0000000', N'uncle.bob@gmail.com', N'Uncle', N'Bob', '0001-01-01T00:00:00.0000000', N'1234');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'UserId', N'CreatedAt', N'Email', N'FirstName', N'LastName', N'ModifiedAt', N'Password') AND [object_id] = OBJECT_ID(N'[Users]'))
    SET IDENTITY_INSERT [Users] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'UserId', N'CreatedAt', N'Email', N'FirstName', N'LastName', N'ModifiedAt', N'Password') AND [object_id] = OBJECT_ID(N'[Users]'))
    SET IDENTITY_INSERT [Users] ON;
INSERT INTO [Users] ([UserId], [CreatedAt], [Email], [FirstName], [LastName], [ModifiedAt], [Password])
VALUES (CAST(2 AS bigint), '0001-01-01T00:00:00.0000505', N'aunty.bob@gmail.com', N'Aunty', N'Bob', '0001-01-01T00:00:00.0000505', N'1234');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'UserId', N'CreatedAt', N'Email', N'FirstName', N'LastName', N'ModifiedAt', N'Password') AND [object_id] = OBJECT_ID(N'[Users]'))
    SET IDENTITY_INSERT [Users] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210920100235_Fourth', N'5.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DELETE FROM [Users]
WHERE [UserId] = CAST(1 AS bigint);
SELECT @@ROWCOUNT;

GO

DELETE FROM [Users]
WHERE [UserId] = CAST(2 AS bigint);
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210920100616_5', N'5.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'UserId', N'CreatedAt', N'Email', N'FirstName', N'LastName', N'ModifiedAt', N'Password') AND [object_id] = OBJECT_ID(N'[Users]'))
    SET IDENTITY_INSERT [Users] ON;
INSERT INTO [Users] ([UserId], [CreatedAt], [Email], [FirstName], [LastName], [ModifiedAt], [Password])
VALUES (CAST(1 AS bigint), '0001-01-01T00:00:00.0000000', N'uncle.bob@gmail.com', N'Uncle', N'Bob', '0001-01-01T00:00:00.0000000', N'1234');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'UserId', N'CreatedAt', N'Email', N'FirstName', N'LastName', N'ModifiedAt', N'Password') AND [object_id] = OBJECT_ID(N'[Users]'))
    SET IDENTITY_INSERT [Users] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'UserId', N'CreatedAt', N'Email', N'FirstName', N'LastName', N'ModifiedAt', N'Password') AND [object_id] = OBJECT_ID(N'[Users]'))
    SET IDENTITY_INSERT [Users] ON;
INSERT INTO [Users] ([UserId], [CreatedAt], [Email], [FirstName], [LastName], [ModifiedAt], [Password])
VALUES (CAST(2 AS bigint), '2020-02-02T00:00:00.0000000', N'aunty.bob@gmail.com', N'Aunty', N'Bob', '2020-02-02T00:00:00.0000000', N'1234');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'UserId', N'CreatedAt', N'Email', N'FirstName', N'LastName', N'ModifiedAt', N'Password') AND [object_id] = OBJECT_ID(N'[Users]'))
    SET IDENTITY_INSERT [Users] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210920100729_6', N'5.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DELETE FROM [Users]
WHERE [UserId] = CAST(1 AS bigint);
SELECT @@ROWCOUNT;

GO

DELETE FROM [Users]
WHERE [UserId] = CAST(2 AS bigint);
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210920100824_7', N'5.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'UserId', N'CreatedAt', N'Email', N'FirstName', N'LastName', N'ModifiedAt', N'Password') AND [object_id] = OBJECT_ID(N'[Users]'))
    SET IDENTITY_INSERT [Users] ON;
INSERT INTO [Users] ([UserId], [CreatedAt], [Email], [FirstName], [LastName], [ModifiedAt], [Password])
VALUES (CAST(1 AS bigint), '2020-02-02T00:00:00.0000000', N'uncle.bob@gmail.com', N'Uncle', N'Bob', '2020-02-02T00:00:00.0000000', N'1234');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'UserId', N'CreatedAt', N'Email', N'FirstName', N'LastName', N'ModifiedAt', N'Password') AND [object_id] = OBJECT_ID(N'[Users]'))
    SET IDENTITY_INSERT [Users] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'UserId', N'CreatedAt', N'Email', N'FirstName', N'LastName', N'ModifiedAt', N'Password') AND [object_id] = OBJECT_ID(N'[Users]'))
    SET IDENTITY_INSERT [Users] ON;
INSERT INTO [Users] ([UserId], [CreatedAt], [Email], [FirstName], [LastName], [ModifiedAt], [Password])
VALUES (CAST(2 AS bigint), '2020-02-02T00:00:00.0000000', N'aunty.bob@gmail.com', N'Aunty', N'Bob', '2020-02-02T00:00:00.0000000', N'1234');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'UserId', N'CreatedAt', N'Email', N'FirstName', N'LastName', N'ModifiedAt', N'Password') AND [object_id] = OBJECT_ID(N'[Users]'))
    SET IDENTITY_INSERT [Users] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210920100859_8', N'5.0.10');
GO

COMMIT;
GO

