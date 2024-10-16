USE [Taxi_Qualifier]
GO

/****** Object: Table [dbo].[AspNetRoles] Script Date: 16/10/2024 09:04:42 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AspNetRoles] (
    [Id]               NVARCHAR (450) NOT NULL,
    [Name]             NVARCHAR (256) NULL,
    [NormalizedName]   NVARCHAR (256) NULL,
    [ConcurrencyStamp] NVARCHAR (MAX) NULL
);
GO
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex]
    ON [dbo].[AspNetRoles]([NormalizedName] ASC) WHERE ([NormalizedName] IS NOT NULL);
GO
ALTER TABLE [dbo].[AspNetRoles]
    ADD CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED ([Id] ASC);
GO

/****** Object: Table [dbo].[UserGroups] Script Date: 16/10/2024 09:15:02 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UserGroups] (
    [Id]     INT            IDENTITY (1, 1) NOT NULL,
    [UserId] NVARCHAR (450) NULL
);
GO
CREATE NONCLUSTERED INDEX [IX_UserGroups_UserId]
    ON [dbo].[UserGroups]([UserId] ASC);
GO

/****** Object: Table [dbo].[AspNetUsers] Script Date: 16/10/2024 09:10:31 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AspNetUsers] (
    [Id]                   NVARCHAR (450)     NOT NULL,
    [UserName]             NVARCHAR (256)     NULL,
    [NormalizedUserName]   NVARCHAR (256)     NULL,
    [Email]                NVARCHAR (256)     NULL,
    [NormalizedEmail]      NVARCHAR (256)     NULL,
    [EmailConfirmed]       BIT                NOT NULL,
    [PasswordHash]         NVARCHAR (MAX)     NULL,
    [SecurityStamp]        NVARCHAR (MAX)     NULL,
    [ConcurrencyStamp]     NVARCHAR (MAX)     NULL,
    [PhoneNumber]          NVARCHAR (MAX)     NULL,
    [PhoneNumberConfirmed] BIT                NOT NULL,
    [TwoFactorEnabled]     BIT                NOT NULL,
    [LockoutEnd]           DATETIMEOFFSET (7) NULL,
    [LockoutEnabled]       BIT                NOT NULL,
    [AccessFailedCount]    INT                NOT NULL,
    [Document]             NVARCHAR (20)      NOT NULL,
    [FirstName]            NVARCHAR (50)      NOT NULL,
    [LastName]             NVARCHAR (50)      NOT NULL,
    [Address]              NVARCHAR (100)     NULL,
    [PicturePath]          NVARCHAR (MAX)     NULL,
    [UserType]             INT                NOT NULL,
    [UserGroupEntityId]    INT                NULL
);
GO
CREATE NONCLUSTERED INDEX [EmailIndex]
    ON [dbo].[AspNetUsers]([NormalizedEmail] ASC);
GO
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex]
    ON [dbo].[AspNetUsers]([NormalizedUserName] ASC) WHERE ([NormalizedUserName] IS NOT NULL);
GO
CREATE NONCLUSTERED INDEX [IX_AspNetUsers_UserGroupEntityId]
    ON [dbo].[AspNetUsers]([UserGroupEntityId] ASC);
GO
ALTER TABLE [dbo].[AspNetUsers]
    ADD CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED ([Id] ASC);
GO
ALTER TABLE [dbo].[AspNetUsers]
    ADD CONSTRAINT [FK_AspNetUsers_UserGroups_UserGroupEntityId] FOREIGN KEY ([UserGroupEntityId]) REFERENCES [dbo].[UserGroups] ([Id]);
GO

/****** Object: Table [dbo].[UserGroups] Script Date: 16/10/2024 09:15:02 a. m. ******/
ALTER TABLE [dbo].[UserGroups]
    ADD CONSTRAINT [PK_UserGroups] PRIMARY KEY CLUSTERED ([Id] ASC);
GO
ALTER TABLE [dbo].[UserGroups]
    ADD CONSTRAINT [FK_UserGroups_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]);
GO

/****** Object: Table [dbo].[AspNetRoleClaims] Script Date: 16/10/2024 08:33:00 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AspNetRoleClaims] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [RoleId]     NVARCHAR (450) NOT NULL,
    [ClaimType]  NVARCHAR (MAX) NULL,
    [ClaimValue] NVARCHAR (MAX) NULL
);
GO
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId]
    ON [dbo].[AspNetRoleClaims]([RoleId] ASC);
GO
ALTER TABLE [dbo].[AspNetRoleClaims]
    ADD CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED ([Id] ASC);
GO
ALTER TABLE [dbo].[AspNetRoleClaims]
    ADD CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[AspNetRoles] ([Id]) ON DELETE CASCADE;
GO

/****** Object: Table [dbo].[AspNetUserClaims] Script Date: 16/10/2024 09:07:32 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AspNetUserClaims] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [UserId]     NVARCHAR (450) NOT NULL,
    [ClaimType]  NVARCHAR (MAX) NULL,
    [ClaimValue] NVARCHAR (MAX) NULL
);
GO
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId]
    ON [dbo].[AspNetUserClaims]([UserId] ASC);
GO
ALTER TABLE [dbo].[AspNetUserClaims]
    ADD CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED ([Id] ASC);
GO
ALTER TABLE [dbo].[AspNetUserClaims]
    ADD CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE;
GO

/****** Object: Table [dbo].[AspNetUserLogins] Script Date: 16/10/2024 09:08:42 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AspNetUserLogins] (
    [LoginProvider]       NVARCHAR (450) NOT NULL,
    [ProviderKey]         NVARCHAR (450) NOT NULL,
    [ProviderDisplayName] NVARCHAR (MAX) NULL,
    [UserId]              NVARCHAR (450) NOT NULL
);
GO
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId]
    ON [dbo].[AspNetUserLogins]([UserId] ASC);
GO
ALTER TABLE [dbo].[AspNetUserLogins]
    ADD CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED ([LoginProvider] ASC, [ProviderKey] ASC);
GO
ALTER TABLE [dbo].[AspNetUserLogins]
    ADD CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE;
GO

/****** Object: Table [dbo].[AspNetUserRoles] Script Date: 16/10/2024 09:09:30 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AspNetUserRoles] (
    [UserId] NVARCHAR (450) NOT NULL,
    [RoleId] NVARCHAR (450) NOT NULL
);
GO
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId]
    ON [dbo].[AspNetUserRoles]([RoleId] ASC);
GO
ALTER TABLE [dbo].[AspNetUserRoles]
    ADD CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED ([UserId] ASC, [RoleId] ASC);
GO
ALTER TABLE [dbo].[AspNetUserRoles]
    ADD CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[AspNetRoles] ([Id]) ON DELETE CASCADE;
GO
ALTER TABLE [dbo].[AspNetUserRoles]
    ADD CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE;
GO

/****** Object: Table [dbo].[AspNetUserTokens] Script Date: 16/10/2024 09:12:01 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AspNetUserTokens] (
    [UserId]        NVARCHAR (450) NOT NULL,
    [LoginProvider] NVARCHAR (450) NOT NULL,
    [Name]          NVARCHAR (450) NOT NULL,
    [Value]         NVARCHAR (MAX) NULL
);
GO

/****** Object: Table [dbo].[Taxis] Script Date: 16/10/2024 09:12:38 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Taxis] (
    [Id]     INT            IDENTITY (1, 1) NOT NULL,
    [Plaque] NVARCHAR (6)   NOT NULL,
    [UserId] NVARCHAR (450) NULL
);
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Taxis_Plaque]
    ON [dbo].[Taxis]([Plaque] ASC);
GO
CREATE NONCLUSTERED INDEX [IX_Taxis_UserId]
    ON [dbo].[Taxis]([UserId] ASC);
GO
ALTER TABLE [dbo].[Taxis]
    ADD CONSTRAINT [PK_Taxis] PRIMARY KEY CLUSTERED ([Id] ASC);
GO
ALTER TABLE [dbo].[Taxis]
    ADD CONSTRAINT [FK_Taxis_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]);
GO

/****** Object: Table [dbo].[Trips] Script Date: 16/10/2024 09:14:10 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Trips] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [StartDate]       DATETIME2 (7)  NOT NULL,
    [EndDate]         DATETIME2 (7)  NULL,
    [Source]          NVARCHAR (100) NULL,
    [Target]          NVARCHAR (100) NULL,
    [Qualification]   REAL           NOT NULL,
    [SourceLatitude]  FLOAT (53)     NOT NULL,
    [SourceLongitude] FLOAT (53)     NOT NULL,
    [TargetLatitude]  FLOAT (53)     NOT NULL,
    [TargetLongitude] FLOAT (53)     NOT NULL,
    [Remarks]         NVARCHAR (MAX) NULL,
    [TaxiId]          INT            NULL,
    [UserId]          NVARCHAR (450) NULL
);
GO
CREATE NONCLUSTERED INDEX [IX_Trips_TaxiId]
    ON [dbo].[Trips]([TaxiId] ASC);
GO
CREATE NONCLUSTERED INDEX [IX_Trips_UserId]
    ON [dbo].[Trips]([UserId] ASC);
GO
ALTER TABLE [dbo].[Trips]
    ADD CONSTRAINT [PK_Trips] PRIMARY KEY CLUSTERED ([Id] ASC);
GO
ALTER TABLE [dbo].[Trips]
    ADD CONSTRAINT [FK_Trips_Taxis_TaxiId] FOREIGN KEY ([TaxiId]) REFERENCES [dbo].[Taxis] ([Id]);
GO
ALTER TABLE [dbo].[Trips]
    ADD CONSTRAINT [FK_Trips_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]);
GO

/****** Object: Table [dbo].[TripDetails] Script Date: 16/10/2024 09:13:34 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TripDetails] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [Date]      DATETIME2 (7) NOT NULL,
    [Latitude]  FLOAT (53)    NOT NULL,
    [Longitude] FLOAT (53)    NOT NULL,
    [TripId]    INT           NULL
);
GO
CREATE NONCLUSTERED INDEX [IX_TripDetails_TripId]
    ON [dbo].[TripDetails]([TripId] ASC);
GO
ALTER TABLE [dbo].[TripDetails]
    ADD CONSTRAINT [PK_TripDetails] PRIMARY KEY CLUSTERED ([Id] ASC);
GO
ALTER TABLE [dbo].[TripDetails]
    ADD CONSTRAINT [FK_TripDetails_Trips_TripId] FOREIGN KEY ([TripId]) REFERENCES [dbo].[Trips] ([Id]);
GO