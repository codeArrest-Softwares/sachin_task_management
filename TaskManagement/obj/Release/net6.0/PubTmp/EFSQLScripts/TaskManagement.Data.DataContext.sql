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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230808174932_initial')
BEGIN
    CREATE TABLE [Permission] (
        [PermissionId] int NOT NULL IDENTITY,
        [PermissionName] nvarchar(255) NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [ModifiedDate] datetime2 NOT NULL,
        CONSTRAINT [PK_Permission] PRIMARY KEY ([PermissionId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230808174932_initial')
BEGIN
    CREATE TABLE [Role] (
        [RoleId] uniqueidentifier NOT NULL,
        [RoleName] nvarchar(255) NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [ModifiedDate] datetime2 NOT NULL,
        CONSTRAINT [PK_Role] PRIMARY KEY ([RoleId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230808174932_initial')
BEGIN
    CREATE TABLE [Task] (
        [TaskId] uniqueidentifier NOT NULL,
        [Title] nvarchar(100) NOT NULL,
        [Description] nvarchar(500) NOT NULL,
        [Priority] int NOT NULL,
        [AssociatedProject] nvarchar(100) NOT NULL,
        [Status] int NOT NULL,
        [DueDate] datetime2 NOT NULL,
        CONSTRAINT [PK_Task] PRIMARY KEY ([TaskId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230808174932_initial')
BEGIN
    CREATE TABLE [User] (
        [Id] uniqueidentifier NOT NULL,
        [Username] nvarchar(20) NOT NULL,
        [Email] nvarchar(30) NOT NULL,
        [Password] nvarchar(15) NOT NULL,
        [IsActive] bit NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [ModifiedDate] datetime2 NULL,
        CONSTRAINT [PK_User] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230808174932_initial')
BEGIN
    CREATE TABLE [RolePermission] (
        [RoleId] uniqueidentifier NOT NULL,
        [PermissionId] int NOT NULL,
        CONSTRAINT [PK_RolePermission] PRIMARY KEY ([RoleId], [PermissionId]),
        CONSTRAINT [FK_RolePermission_Permission_PermissionId] FOREIGN KEY ([PermissionId]) REFERENCES [Permission] ([PermissionId]) ON DELETE CASCADE,
        CONSTRAINT [FK_RolePermission_Role_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Role] ([RoleId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230808174932_initial')
BEGIN
    CREATE TABLE [UserRole] (
        [Id] uniqueidentifier NOT NULL,
        [RoleId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_UserRole] PRIMARY KEY ([RoleId], [Id]),
        CONSTRAINT [FK_UserRole_Role_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Role] ([RoleId]) ON DELETE CASCADE,
        CONSTRAINT [FK_UserRole_User_Id] FOREIGN KEY ([Id]) REFERENCES [User] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230808174932_initial')
BEGIN
    CREATE TABLE [UserTask] (
        [Id] uniqueidentifier NOT NULL,
        [TaskId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_UserTask] PRIMARY KEY ([Id], [TaskId]),
        CONSTRAINT [FK_UserTask_Task_TaskId] FOREIGN KEY ([TaskId]) REFERENCES [Task] ([TaskId]) ON DELETE CASCADE,
        CONSTRAINT [FK_UserTask_User_Id] FOREIGN KEY ([Id]) REFERENCES [User] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230808174932_initial')
BEGIN
    CREATE INDEX [IX_RolePermission_PermissionId] ON [RolePermission] ([PermissionId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230808174932_initial')
BEGIN
    CREATE INDEX [IX_UserRole_Id] ON [UserRole] ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230808174932_initial')
BEGIN
    CREATE INDEX [IX_UserTask_TaskId] ON [UserTask] ([TaskId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230808174932_initial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230808174932_initial', N'7.0.9');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230808183530_taskchanges')
BEGIN
    ALTER TABLE [Task] ADD [TaskCompletion] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230808183530_taskchanges')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230808183530_taskchanges', N'7.0.9');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230808220820_tuos')
BEGIN
    CREATE TABLE [Comments] (
        [CommentsID] uniqueidentifier NOT NULL,
        [Author] nvarchar(30) NOT NULL,
        [Text] nvarchar(500) NOT NULL,
        [TimeStamp] datetime2 NOT NULL,
        CONSTRAINT [PK_Comments] PRIMARY KEY ([CommentsID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230808220820_tuos')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230808220820_tuos', N'7.0.9');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230809171950_taskcommentadded')
BEGIN
    CREATE TABLE [TaskComment] (
        [TaskId] uniqueidentifier NOT NULL,
        [CommentsID] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_TaskComment] PRIMARY KEY ([TaskId], [CommentsID]),
        CONSTRAINT [FK_TaskComment_Comments_CommentsID] FOREIGN KEY ([CommentsID]) REFERENCES [Comments] ([CommentsID]) ON DELETE CASCADE,
        CONSTRAINT [FK_TaskComment_Task_TaskId] FOREIGN KEY ([TaskId]) REFERENCES [Task] ([TaskId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230809171950_taskcommentadded')
BEGIN
    CREATE INDEX [IX_TaskComment_CommentsID] ON [TaskComment] ([CommentsID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230809171950_taskcommentadded')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230809171950_taskcommentadded', N'7.0.9');
END;
GO

COMMIT;
GO

