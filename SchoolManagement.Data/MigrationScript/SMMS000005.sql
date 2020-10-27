ALTER TABLE [Master].[Subject] ADD [SubjectStream] int NOT NULL DEFAULT 1;

GO

UPDATE [Account].[Role] SET [CreatedOn] = '2020-08-09T03:36:53.4820193Z', [UpdatedOn] = '2020-08-09T03:36:53.4822053Z'
WHERE [Id] = CAST(1 AS bigint);
SELECT @@ROWCOUNT;


GO

UPDATE [Account].[Role] SET [CreatedOn] = '2020-08-09T03:36:53.4826237Z', [UpdatedOn] = '2020-08-09T03:36:53.4826261Z'
WHERE [Id] = CAST(2 AS bigint);
SELECT @@ROWCOUNT;


GO

UPDATE [Account].[Role] SET [CreatedOn] = '2020-08-09T03:36:53.4826405Z', [UpdatedOn] = '2020-08-09T03:36:53.4826406Z'
WHERE [Id] = CAST(3 AS bigint);
SELECT @@ROWCOUNT;


GO

UPDATE [Account].[Role] SET [CreatedOn] = '2020-08-09T03:36:53.4826407Z', [UpdatedOn] = '2020-08-09T03:36:53.4826412Z'
WHERE [Id] = CAST(4 AS bigint);
SELECT @@ROWCOUNT;


GO

UPDATE [Account].[Role] SET [CreatedOn] = '2020-08-09T03:36:53.4826413Z', [UpdatedOn] = '2020-08-09T03:36:53.4826413Z'
WHERE [Id] = CAST(5 AS bigint);
SELECT @@ROWCOUNT;


GO

UPDATE [Account].[Role] SET [CreatedOn] = '2020-08-09T03:36:53.4826415Z', [UpdatedOn] = '2020-08-09T03:36:53.4826416Z'
WHERE [Id] = CAST(6 AS bigint);
SELECT @@ROWCOUNT;


GO

UPDATE [Account].[Role] SET [CreatedOn] = '2020-08-09T03:36:53.4826418Z', [UpdatedOn] = '2020-08-09T03:36:53.4826419Z'
WHERE [Id] = CAST(7 AS bigint);
SELECT @@ROWCOUNT;


GO

UPDATE [Account].[Role] SET [CreatedOn] = '2020-08-09T03:36:53.4826420Z', [UpdatedOn] = '2020-08-09T03:36:53.4826420Z'
WHERE [Id] = CAST(8 AS bigint);
SELECT @@ROWCOUNT;


GO

UPDATE [Account].[User] SET [CreatedOn] = '2020-08-09T03:36:53.4500743Z', [UpdatedOn] = '2020-08-09T03:36:53.4501703Z'
WHERE [Id] = CAST(1 AS bigint);
SELECT @@ROWCOUNT;


GO

UPDATE [Account].[User] SET [CreatedOn] = '2020-08-09T03:36:53.4504495Z', [UpdatedOn] = '2020-08-09T03:36:53.4504506Z'
WHERE [Id] = CAST(2 AS bigint);
SELECT @@ROWCOUNT;


GO

UPDATE [Account].[UserRole] SET [CreatedOn] = '2020-08-09T03:36:53.5232992Z', [UpdatedOn] = '2020-08-09T03:36:53.5234192Z'
WHERE [UserId] = CAST(1 AS bigint) AND [RoleId] = CAST(1 AS bigint);
SELECT @@ROWCOUNT;


GO

UPDATE [Account].[UserRole] SET [CreatedOn] = '2020-08-09T03:36:53.5240125Z', [UpdatedOn] = '2020-08-09T03:36:53.5240146Z'
WHERE [UserId] = CAST(2 AS bigint) AND [RoleId] = CAST(2 AS bigint);
SELECT @@ROWCOUNT;


GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200809033658_SMMS000005', N'3.1.5');

GO

