IF SCHEMA_ID(N'TimeTable') IS NULL EXEC(N'CREATE SCHEMA [TimeTable];');

GO

ALTER SCHEMA [TimeTable] TRANSFER [Master].[ClassTimeTablePeriodAssignTeacher];

GO

ALTER SCHEMA [TimeTable] TRANSFER [Master].[ClassTimeTablePeriod];

GO

ALTER TABLE [TimeTable].[ClassTimeTablePeriod] ADD [TimeTableId] bigint NOT NULL DEFAULT CAST(0 AS bigint);

GO

CREATE TABLE [TimeTable].[TimeTable] (
    [Id] bigint NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [AcademicYearId] bigint NOT NULL,
    [IsPublished] bit NOT NULL,
    [IsActive] bit NOT NULL,
    [CreatedOn] datetime2 NOT NULL,
    [CreatedById] bigint NULL,
    [UpdatedOn] datetime2 NOT NULL,
    [UpdatedById] bigint NULL,
    CONSTRAINT [PK_TimeTable] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_TimeTable_AcademicYear_AcademicYearId] FOREIGN KEY ([AcademicYearId]) REFERENCES [Master].[AcademicYear] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_TimeTable_User_CreatedById] FOREIGN KEY ([CreatedById]) REFERENCES [Account].[User] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_TimeTable_User_UpdatedById] FOREIGN KEY ([UpdatedById]) REFERENCES [Account].[User] ([Id]) ON DELETE NO ACTION
);

GO

UPDATE [Account].[Role] SET [CreatedOn] = '2020-08-08T03:48:37.7948658Z', [UpdatedOn] = '2020-08-08T03:48:37.7950476Z'
WHERE [Id] = CAST(1 AS bigint);
SELECT @@ROWCOUNT;


GO

UPDATE [Account].[Role] SET [CreatedOn] = '2020-08-08T03:48:37.7954753Z', [UpdatedOn] = '2020-08-08T03:48:37.7954788Z'
WHERE [Id] = CAST(2 AS bigint);
SELECT @@ROWCOUNT;


GO

UPDATE [Account].[Role] SET [CreatedOn] = '2020-08-08T03:48:37.7954888Z', [UpdatedOn] = '2020-08-08T03:48:37.7954888Z'
WHERE [Id] = CAST(3 AS bigint);
SELECT @@ROWCOUNT;


GO

UPDATE [Account].[Role] SET [CreatedOn] = '2020-08-08T03:48:37.7954890Z', [UpdatedOn] = '2020-08-08T03:48:37.7954890Z'
WHERE [Id] = CAST(4 AS bigint);
SELECT @@ROWCOUNT;


GO

UPDATE [Account].[Role] SET [CreatedOn] = '2020-08-08T03:48:37.7954891Z', [UpdatedOn] = '2020-08-08T03:48:37.7954892Z'
WHERE [Id] = CAST(5 AS bigint);
SELECT @@ROWCOUNT;


GO

UPDATE [Account].[Role] SET [CreatedOn] = '2020-08-08T03:48:37.7954892Z', [UpdatedOn] = '2020-08-08T03:48:37.7954895Z'
WHERE [Id] = CAST(6 AS bigint);
SELECT @@ROWCOUNT;


GO

UPDATE [Account].[Role] SET [CreatedOn] = '2020-08-08T03:48:37.7954896Z', [UpdatedOn] = '2020-08-08T03:48:37.7954897Z'
WHERE [Id] = CAST(7 AS bigint);
SELECT @@ROWCOUNT;


GO

UPDATE [Account].[Role] SET [CreatedOn] = '2020-08-08T03:48:37.7954899Z', [UpdatedOn] = '2020-08-08T03:48:37.7954900Z'
WHERE [Id] = CAST(8 AS bigint);
SELECT @@ROWCOUNT;


GO

UPDATE [Account].[User] SET [CreatedOn] = '2020-08-08T03:48:37.7776845Z', [UpdatedOn] = '2020-08-08T03:48:37.7778001Z'
WHERE [Id] = CAST(1 AS bigint);
SELECT @@ROWCOUNT;


GO

UPDATE [Account].[User] SET [CreatedOn] = '2020-08-08T03:48:37.7781013Z', [UpdatedOn] = '2020-08-08T03:48:37.7781035Z'
WHERE [Id] = CAST(2 AS bigint);
SELECT @@ROWCOUNT;


GO

UPDATE [Account].[UserRole] SET [CreatedOn] = '2020-08-08T03:48:37.8290561Z', [UpdatedOn] = '2020-08-08T03:48:37.8291792Z'
WHERE [UserId] = CAST(1 AS bigint) AND [RoleId] = CAST(1 AS bigint);
SELECT @@ROWCOUNT;


GO

UPDATE [Account].[UserRole] SET [CreatedOn] = '2020-08-08T03:48:37.8296677Z', [UpdatedOn] = '2020-08-08T03:48:37.8296693Z'
WHERE [UserId] = CAST(2 AS bigint) AND [RoleId] = CAST(2 AS bigint);
SELECT @@ROWCOUNT;


GO

CREATE INDEX [IX_ClassTimeTablePeriod_TimeTableId] ON [TimeTable].[ClassTimeTablePeriod] ([TimeTableId]);

GO

CREATE INDEX [IX_TimeTable_AcademicYearId] ON [TimeTable].[TimeTable] ([AcademicYearId]);

GO

CREATE INDEX [IX_TimeTable_CreatedById] ON [TimeTable].[TimeTable] ([CreatedById]);

GO

CREATE INDEX [IX_TimeTable_UpdatedById] ON [TimeTable].[TimeTable] ([UpdatedById]);

GO

ALTER TABLE [TimeTable].[ClassTimeTablePeriod] ADD CONSTRAINT [FK_ClassTimeTablePeriod_TimeTable_TimeTableId] FOREIGN KEY ([TimeTableId]) REFERENCES [TimeTable].[TimeTable] ([Id]) ON DELETE NO ACTION;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200808034843_SMMS000003', N'3.1.5');

GO

