DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Account].[User]') AND [c].[name] = N'Username');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Account].[User] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Account].[User] ALTER COLUMN [Username] nvarchar(450) NULL;

GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Account].[User]') AND [c].[name] = N'Email');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Account].[User] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Account].[User] ALTER COLUMN [Email] nvarchar(450) NULL;

GO

UPDATE [Account].[Role] SET [CreatedOn] = '2020-07-11T09:48:49.2568896Z', [UpdatedOn] = '2020-07-11T09:48:49.2570659Z'
WHERE [Id] = CAST(1 AS bigint);
SELECT @@ROWCOUNT;


GO

UPDATE [Account].[Role] SET [CreatedOn] = '2020-07-11T09:48:49.2573620Z', [UpdatedOn] = '2020-07-11T09:48:49.2573638Z'
WHERE [Id] = CAST(2 AS bigint);
SELECT @@ROWCOUNT;


GO

UPDATE [Account].[Role] SET [CreatedOn] = '2020-07-11T09:48:49.2573692Z', [UpdatedOn] = '2020-07-11T09:48:49.2573693Z'
WHERE [Id] = CAST(3 AS bigint);
SELECT @@ROWCOUNT;


GO

UPDATE [Account].[Role] SET [CreatedOn] = '2020-07-11T09:48:49.2573694Z', [UpdatedOn] = '2020-07-11T09:48:49.2573695Z'
WHERE [Id] = CAST(4 AS bigint);
SELECT @@ROWCOUNT;


GO

UPDATE [Account].[Role] SET [CreatedOn] = '2020-07-11T09:48:49.2573695Z', [UpdatedOn] = '2020-07-11T09:48:49.2573696Z'
WHERE [Id] = CAST(5 AS bigint);
SELECT @@ROWCOUNT;


GO

UPDATE [Account].[Role] SET [CreatedOn] = '2020-07-11T09:48:49.2573697Z', [UpdatedOn] = '2020-07-11T09:48:49.2573697Z'
WHERE [Id] = CAST(6 AS bigint);
SELECT @@ROWCOUNT;


GO

UPDATE [Account].[Role] SET [CreatedOn] = '2020-07-11T09:48:49.2573698Z', [UpdatedOn] = '2020-07-11T09:48:49.2573698Z'
WHERE [Id] = CAST(7 AS bigint);
SELECT @@ROWCOUNT;


GO

UPDATE [Account].[Role] SET [CreatedOn] = '2020-07-11T09:48:49.2573699Z', [UpdatedOn] = '2020-07-11T09:48:49.2573699Z'
WHERE [Id] = CAST(8 AS bigint);
SELECT @@ROWCOUNT;


GO

UPDATE [Account].[User] SET [CreatedOn] = '2020-07-11T09:48:49.2457609Z', [UpdatedOn] = '2020-07-11T09:48:49.2458266Z'
WHERE [Id] = CAST(1 AS bigint);
SELECT @@ROWCOUNT;


GO

UPDATE [Account].[User] SET [CreatedOn] = '2020-07-11T09:48:49.2461437Z', [UpdatedOn] = '2020-07-11T09:48:49.2461447Z'
WHERE [Id] = CAST(2 AS bigint);
SELECT @@ROWCOUNT;


GO

UPDATE [Account].[UserRole] SET [CreatedOn] = '2020-07-11T09:48:49.2752902Z', [UpdatedOn] = '2020-07-11T09:48:49.2753800Z'
WHERE [UserId] = CAST(1 AS bigint) AND [RoleId] = CAST(1 AS bigint);
SELECT @@ROWCOUNT;


GO

UPDATE [Account].[UserRole] SET [CreatedOn] = '2020-07-11T09:48:49.2757279Z', [UpdatedOn] = '2020-07-11T09:48:49.2757290Z'
WHERE [UserId] = CAST(2 AS bigint) AND [RoleId] = CAST(2 AS bigint);
SELECT @@ROWCOUNT;


GO

CREATE UNIQUE INDEX [IX_User_Email] ON [Account].[User] ([Email]) WHERE [Email] IS NOT NULL;

GO

CREATE UNIQUE INDEX [IX_User_Username] ON [Account].[User] ([Username]) WHERE [Username] IS NOT NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200711094852_SMMS000002', N'3.1.5');

GO

