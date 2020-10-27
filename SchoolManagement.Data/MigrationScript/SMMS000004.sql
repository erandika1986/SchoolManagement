ALTER TABLE [Master].[Class] ADD [ClassCategory] int NOT NULL DEFAULT 1;

GO

ALTER TABLE [Master].[Class] ADD [LanguageStream] int NOT NULL DEFAULT 2;

GO

UPDATE [Account].[Role] SET [CreatedOn] = '2020-08-09T00:43:23.5093384Z', [UpdatedOn] = '2020-08-09T00:43:23.5095459Z'
WHERE [Id] = CAST(1 AS bigint);
SELECT @@ROWCOUNT;


GO

UPDATE [Account].[Role] SET [CreatedOn] = '2020-08-09T00:43:23.5099409Z', [UpdatedOn] = '2020-08-09T00:43:23.5099436Z'
WHERE [Id] = CAST(2 AS bigint);
SELECT @@ROWCOUNT;


GO

UPDATE [Account].[Role] SET [CreatedOn] = '2020-08-09T00:43:23.5099517Z', [UpdatedOn] = '2020-08-09T00:43:23.5099518Z'
WHERE [Id] = CAST(3 AS bigint);
SELECT @@ROWCOUNT;


GO

UPDATE [Account].[Role] SET [CreatedOn] = '2020-08-09T00:43:23.5099520Z', [UpdatedOn] = '2020-08-09T00:43:23.5099520Z'
WHERE [Id] = CAST(4 AS bigint);
SELECT @@ROWCOUNT;


GO

UPDATE [Account].[Role] SET [CreatedOn] = '2020-08-09T00:43:23.5099522Z', [UpdatedOn] = '2020-08-09T00:43:23.5099522Z'
WHERE [Id] = CAST(5 AS bigint);
SELECT @@ROWCOUNT;


GO

UPDATE [Account].[Role] SET [CreatedOn] = '2020-08-09T00:43:23.5099523Z', [UpdatedOn] = '2020-08-09T00:43:23.5099523Z'
WHERE [Id] = CAST(6 AS bigint);
SELECT @@ROWCOUNT;


GO

UPDATE [Account].[Role] SET [CreatedOn] = '2020-08-09T00:43:23.5099524Z', [UpdatedOn] = '2020-08-09T00:43:23.5099524Z'
WHERE [Id] = CAST(7 AS bigint);
SELECT @@ROWCOUNT;


GO

UPDATE [Account].[Role] SET [CreatedOn] = '2020-08-09T00:43:23.5099525Z', [UpdatedOn] = '2020-08-09T00:43:23.5099526Z'
WHERE [Id] = CAST(8 AS bigint);
SELECT @@ROWCOUNT;


GO

UPDATE [Account].[User] SET [CreatedOn] = '2020-08-09T00:43:23.4953039Z', [UpdatedOn] = '2020-08-09T00:43:23.4953673Z'
WHERE [Id] = CAST(1 AS bigint);
SELECT @@ROWCOUNT;


GO

UPDATE [Account].[User] SET [CreatedOn] = '2020-08-09T00:43:23.4956467Z', [UpdatedOn] = '2020-08-09T00:43:23.4956483Z'
WHERE [Id] = CAST(2 AS bigint);
SELECT @@ROWCOUNT;


GO

UPDATE [Account].[UserRole] SET [CreatedOn] = '2020-08-09T00:43:23.5291316Z', [UpdatedOn] = '2020-08-09T00:43:23.5292401Z'
WHERE [UserId] = CAST(1 AS bigint) AND [RoleId] = CAST(1 AS bigint);
SELECT @@ROWCOUNT;


GO

UPDATE [Account].[UserRole] SET [CreatedOn] = '2020-08-09T00:43:23.5297359Z', [UpdatedOn] = '2020-08-09T00:43:23.5297373Z'
WHERE [UserId] = CAST(2 AS bigint) AND [RoleId] = CAST(2 AS bigint);
SELECT @@ROWCOUNT;


GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200809004327_SMMS000004', N'3.1.5');

GO

