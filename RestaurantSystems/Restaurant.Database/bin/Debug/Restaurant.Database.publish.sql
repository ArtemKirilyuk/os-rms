﻿/*
Deployment script for Restaurant.Database

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "Restaurant.Database"
:setvar DefaultFilePrefix "Restaurant.Database"
:setvar DefaultDataPath ""
:setvar DefaultLogPath ""

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
PRINT N'Creating [dbo].[Bookings]...';


GO
CREATE TABLE [dbo].[Bookings] (
    [Id]            INT      IDENTITY (1, 1) NOT NULL,
    [CustomerId]    INT      NOT NULL,
    [BookingTypeId] INT      NOT NULL,
    [From]          DATETIME NOT NULL,
    [Till]          DATETIME NOT NULL,
    [RequestedOn]   DATETIME NOT NULL,
    [ForPeople]     INT      NOT NULL,
    [Cancelled]     BIT      NOT NULL,
    [Confirmed]     BIT      NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[BookingTypes]...';


GO
CREATE TABLE [dbo].[BookingTypes] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Code]        NVARCHAR (3)   NOT NULL,
    [Description] NVARCHAR (300) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[Customers]...';


GO
CREATE TABLE [dbo].[Customers] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [CustomerTypeId] INT            NOT NULL,
    [FirstName]      NVARCHAR (100) NULL,
    [LastName]       NVARCHAR (100) NULL,
    [AddressLine1]   NVARCHAR (100) NOT NULL,
    [AddressLine2]   NVARCHAR (300) NULL,
    [PostCode]       NVARCHAR (100) NOT NULL,
    [MobilePhone]    NVARCHAR (MAX) NULL,
    [TelePhone]      NVARCHAR (MAX) NULL,
    [Disabled]       BIT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[CustomerTypes]...';


GO
CREATE TABLE [dbo].[CustomerTypes] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Code]        NVARCHAR (3)   NOT NULL,
    [Description] NVARCHAR (300) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[Roles]...';


GO
CREATE TABLE [dbo].[Roles] (
    [Id]            NVARCHAR (128) NOT NULL,
    [Name]          NVARCHAR (MAX) NOT NULL,
    [Description]   NVARCHAR (MAX) NULL,
    [Discriminator] NVARCHAR (128) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[UserClaims]...';


GO
CREATE TABLE [dbo].[UserClaims] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [UserId]     NVARCHAR (128) NULL,
    [ClaimType]  NVARCHAR (MAX) NULL,
    [ClaimValue] NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[UserLogins]...';


GO
CREATE TABLE [dbo].[UserLogins] (
    [UserId]        NVARCHAR (128) NOT NULL,
    [LoginProvider] NVARCHAR (128) NOT NULL,
    [ProviderKey]   NVARCHAR (128) NOT NULL,
    PRIMARY KEY CLUSTERED ([UserId] ASC, [LoginProvider] ASC, [ProviderKey] ASC)
);


GO
PRINT N'Creating [dbo].[UserRoles]...';


GO
CREATE TABLE [dbo].[UserRoles] (
    [UserId]          NVARCHAR (128) NOT NULL,
    [RoleId]          NVARCHAR (128) NOT NULL,
    [IdentityRole_Id] NVARCHAR (128) NULL,
    PRIMARY KEY CLUSTERED ([UserId] ASC, [RoleId] ASC)
);


GO
PRINT N'Creating [dbo].[OrderDetails]...';


GO
CREATE TABLE [dbo].[OrderDetails] (
    [Id]            INT             IDENTITY (1, 1) NOT NULL,
    [OrderHeaderId] INT             NOT NULL,
    [ProductId]     INT             NOT NULL,
    [Quantity]      INT             NOT NULL,
    [SpiceTypeId]   INT             NOT NULL,
    [Price]         DECIMAL (18, 2) NOT NULL,
    [Total]         DECIMAL (18, 2) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[OrderHeaders]...';


GO
CREATE TABLE [dbo].[OrderHeaders] (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [OrderDate]   DATETIME        NOT NULL,
    [CustomerId]  INT             NOT NULL,
    [OrderTypeId] INT             NOT NULL,
    [Cancelled]   BIT             NOT NULL,
    [SubTotal]    DECIMAL (18, 2) NOT NULL,
    [Discount]    DECIMAL (18, 2) NOT NULL,
    [Total]       DECIMAL (18, 2) NOT NULL,
    [Notes]       NVARCHAR (300)  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[OrderTypes]...';


GO
CREATE TABLE [dbo].[OrderTypes] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Code]        NVARCHAR (3)   NOT NULL,
    [Description] NVARCHAR (300) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[Products]...';


GO
CREATE TABLE [dbo].[Products] (
    [Id]                INT             IDENTITY (1, 1) NOT NULL,
    [ProductCategoryId] INT             NOT NULL,
    [LongName]          NVARCHAR (300)  NULL,
    [ShortName]         NVARCHAR (100)  NULL,
    [Image]             VARBINARY (MAX) NULL,
    [Price]             DECIMAL (18, 2) NOT NULL,
    [Deleted]           BIT             NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[ProductCategories]...';


GO
CREATE TABLE [dbo].[ProductCategories] (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [Description] NVARCHAR (300)  NOT NULL,
    [Deleted]     BIT             NOT NULL,
    [Image]       VARBINARY (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[SpiceTypes]...';


GO
CREATE TABLE [dbo].[SpiceTypes] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Code]        NVARCHAR (3)   NOT NULL,
    [Description] NVARCHAR (300) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[Users]...';


GO
CREATE TABLE [dbo].[Users] (
    [Id]                   NVARCHAR (128) NOT NULL,
    [Email]                NVARCHAR (MAX) NULL,
    [EmailConfirmed]       BIT            NOT NULL,
    [PasswordHash]         NVARCHAR (MAX) NULL,
    [SecurityStamp]        NVARCHAR (MAX) NULL,
    [PhoneNumber]          NVARCHAR (MAX) NULL,
    [PhoneNumberConfirmed] BIT            NOT NULL,
    [TwoFactorEnabled]     BIT            NOT NULL,
    [LockoutEndDateUtc]    DATETIME       NULL,
    [LockoutEnabled]       BIT            NOT NULL,
    [AccessFailedCount]    INT            NOT NULL,
    [UserName]             NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[Booking_BookingType]...';


GO
ALTER TABLE [dbo].[Bookings]
    ADD CONSTRAINT [Booking_BookingType] FOREIGN KEY ([BookingTypeId]) REFERENCES [dbo].[BookingTypes] ([Id]) ON DELETE CASCADE;


GO
PRINT N'Creating [dbo].[Booking_Customer]...';


GO
ALTER TABLE [dbo].[Bookings]
    ADD CONSTRAINT [Booking_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customers] ([Id]) ON DELETE CASCADE;


GO
PRINT N'Creating [dbo].[Customer_CustomerType]...';


GO
ALTER TABLE [dbo].[Customers]
    ADD CONSTRAINT [Customer_CustomerType] FOREIGN KEY ([CustomerTypeId]) REFERENCES [dbo].[CustomerTypes] ([Id]) ON DELETE CASCADE;


GO
PRINT N'Creating [dbo].[User_Claims]...';


GO
ALTER TABLE [dbo].[UserClaims]
    ADD CONSTRAINT [User_Claims] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id]);


GO
PRINT N'Creating [dbo].[User_Logins]...';


GO
ALTER TABLE [dbo].[UserLogins]
    ADD CONSTRAINT [User_Logins] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id]) ON DELETE CASCADE;


GO
PRINT N'Creating [dbo].[IdentityRole_Users]...';


GO
ALTER TABLE [dbo].[UserRoles]
    ADD CONSTRAINT [IdentityRole_Users] FOREIGN KEY ([IdentityRole_Id]) REFERENCES [dbo].[Roles] ([Id]);


GO
PRINT N'Creating [dbo].[User_Roles]...';


GO
ALTER TABLE [dbo].[UserRoles]
    ADD CONSTRAINT [User_Roles] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id]) ON DELETE CASCADE;


GO
PRINT N'Creating [dbo].[OrderDetail_Product]...';


GO
ALTER TABLE [dbo].[OrderDetails]
    ADD CONSTRAINT [OrderDetail_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([Id]) ON DELETE CASCADE;


GO
PRINT N'Creating [dbo].[OrderDetail_SpiceType]...';


GO
ALTER TABLE [dbo].[OrderDetails]
    ADD CONSTRAINT [OrderDetail_SpiceType] FOREIGN KEY ([SpiceTypeId]) REFERENCES [dbo].[SpiceTypes] ([Id]) ON DELETE CASCADE;


GO
PRINT N'Creating [dbo].[OrderHeader_OrderDetails]...';


GO
ALTER TABLE [dbo].[OrderDetails]
    ADD CONSTRAINT [OrderHeader_OrderDetails] FOREIGN KEY ([OrderHeaderId]) REFERENCES [dbo].[OrderHeaders] ([Id]) ON DELETE CASCADE;


GO
PRINT N'Creating [dbo].[OrderHeader_Customer]...';


GO
ALTER TABLE [dbo].[OrderHeaders]
    ADD CONSTRAINT [OrderHeader_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customers] ([Id]) ON DELETE CASCADE;


GO
PRINT N'Creating [dbo].[OrderHeader_OrderType]...';


GO
ALTER TABLE [dbo].[OrderHeaders]
    ADD CONSTRAINT [OrderHeader_OrderType] FOREIGN KEY ([OrderTypeId]) REFERENCES [dbo].[OrderTypes] ([Id]) ON DELETE CASCADE;


GO
PRINT N'Creating [dbo].[Product_ProductCategory]...';


GO
ALTER TABLE [dbo].[Products]
    ADD CONSTRAINT [Product_ProductCategory] FOREIGN KEY ([ProductCategoryId]) REFERENCES [dbo].[ProductCategories] ([Id]) ON DELETE CASCADE;


GO
/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/



DELETE FROM [Customers]
DELETE FROM [CustomerTypes]
DELETE FROM [Bookings]
DELETE FROM [BookingTypes]

DELETE FROM [OrderDetails]
DELETE FROM [OrderHeaders]
DELETE FROM [OrderTypes]

DELETE FROM [Products]
DELETE FROM [ProductCategories]

	
SET IDENTITY_INSERT [dbo].[ProductCategories] ON
INSERT INTO [dbo].[ProductCategories]([Id], [Description], [Deleted])VALUES(1, 'Beverages', 0)
INSERT INTO [dbo].[ProductCategories]([Id], [Description], [Deleted])VALUES(2, 'Starters', 0)
INSERT INTO [dbo].[ProductCategories]([Id], [Description], [Deleted])VALUES(3, 'House specials', 0)
INSERT INTO [dbo].[ProductCategories]([Id], [Description], [Deleted])VALUES(4, 'Main dishes', 0)
INSERT INTO [dbo].[ProductCategories]([Id], [Description], [Deleted])VALUES(5, 'Biryani dishes', 0)
INSERT INTO [dbo].[ProductCategories]([Id], [Description], [Deleted])VALUES(6, 'Vegetarian dishes', 0)
INSERT INTO [dbo].[ProductCategories]([Id], [Description], [Deleted])VALUES(7, 'Rice', 0)
INSERT INTO [dbo].[ProductCategories]([Id], [Description], [Deleted])VALUES(8, 'Bread', 0)
INSERT INTO [dbo].[ProductCategories]([Id], [Description], [Deleted])VALUES(9, 'Accompainments', 0)
INSERT INTO [dbo].[ProductCategories]([Id], [Description], [Deleted])VALUES(10, 'Desserts', 0)
SET IDENTITY_INSERT [dbo].[ProductCategories] OFF


SET IDENTITY_INSERT [dbo].[CustomerTypes] ON
INSERT INTO [dbo].[CustomerTypes]([Id], [Code], [Description])VALUES(1, 'BOK', 'Booking')
INSERT INTO [dbo].[CustomerTypes]([Id], [Code], [Description])VALUES(2, 'ORD', 'Order')
SET IDENTITY_INSERT [dbo].[CustomerTypes] OFF


SET IDENTITY_INSERT [dbo].[Customers] ON
INSERT INTO [dbo].[Customers]
           ([Id], [CustomerTypeId],[FirstName],[LastName],[AddressLine1],[AddressLine2],[PostCode],[MobilePhone],[TelePhone], [Disabled])
     VALUES (1, 1, 'Abdul', 'Aziz', '21 First Streest', 'Some Road',  'NP12 6NX', '00000000000', NULL, 0)
INSERT INTO [dbo].[Customers]
           ([Id], [CustomerTypeId],[FirstName],[LastName],[AddressLine1],[AddressLine2],[PostCode],[MobilePhone],[TelePhone], [Disabled])
     VALUES (2, 1, 'Penquin', 'Skipper', '21 First Streest', 'Some Road',  'NP12 6NX', '00000000000', NULL, 0)
INSERT INTO [dbo].[Customers]
           ([Id], [CustomerTypeId],[FirstName],[LastName],[AddressLine1],[AddressLine2],[PostCode],[MobilePhone],[TelePhone], [Disabled])
     VALUES (3, 1, 'Penquin', 'Rico', '21 First Streest', 'Some Road',  'NP12 6NX', '00000000000', NULL, 0)
INSERT INTO [dbo].[Customers]
           ([Id], [CustomerTypeId],[FirstName],[LastName],[AddressLine1],[AddressLine2],[PostCode],[MobilePhone],[TelePhone], [Disabled])
     VALUES (4, 1, 'King', 'Julien XIII', '21 First Streest', 'Some Road',  'NP12 6NX', '00000000000', NULL, 0)
INSERT INTO [dbo].[Customers]
           ([Id], [CustomerTypeId],[FirstName],[LastName],[AddressLine1],[AddressLine2],[PostCode],[MobilePhone],[TelePhone], [Disabled])
     VALUES (5, 1, 'Penquin', 'Kowalski', '21 First Streest', 'Some Road',  'NP12 6NX', '00000000000', NULL, 0)
INSERT INTO [dbo].[Customers]
           ([Id], [CustomerTypeId],[FirstName],[LastName],[AddressLine1],[AddressLine2],[PostCode],[MobilePhone],[TelePhone], [Disabled])
     VALUES (6, 1, 'Penquin', 'Private', '21 First Streest', 'Some Road',  'NP12 6NX', '00000000000', NULL, 0)
INSERT INTO [dbo].[Customers]
           ([Id], [CustomerTypeId],[FirstName],[LastName],[AddressLine1],[AddressLine2],[PostCode],[MobilePhone],[TelePhone], [Disabled])
     VALUES (7, 1, 'Madagascar', 'Maurice', '21 First Streest', 'Some Road',  'NP12 6NX', '00000000000', NULL, 0)
SET IDENTITY_INSERT [dbo].[Customers] OFF

SET IDENTITY_INSERT [dbo].[BookingTypes] ON
INSERT INTO [dbo].[BookingTypes]([Id], [Code], [Description])VALUES(1, 'BUF', 'Buffect')
INSERT INTO [dbo].[BookingTypes]([Id], [Code], [Description])VALUES(2, 'MNU', 'Menu')
SET IDENTITY_INSERT [dbo].[BookingTypes] OFF


SET IDENTITY_INSERT [dbo].[Products] ON
INSERT INTO [dbo].[Products] ([Id], [ProductCategoryId] ,[LongName] ,[ShortName] ,[Image] ,[Price], [Deleted]) VALUES (1, 1, 'Coca-Cola 1.5L', 'Coca-Cola 1.5L', null, 2.50, 0)
INSERT INTO [dbo].[Products] ([Id], [ProductCategoryId] ,[LongName] ,[ShortName] ,[Image] ,[Price], [Deleted]) VALUES (2, 2, 'Meast Samosa', 'Meast Samosa', null, 3.95, 0)
INSERT INTO [dbo].[Products] ([Id], [ProductCategoryId] ,[LongName] ,[ShortName] ,[Image] ,[Price], [Deleted]) VALUES (3, 3, 'Hyderabad Chicken', 'Hyderabad Chicken', null, 8.45, 0)
INSERT INTO [dbo].[Products] ([Id], [ProductCategoryId] ,[LongName] ,[ShortName] ,[Image] ,[Price], [Deleted]) VALUES (4, 4, 'Korma - Chicken', 'Korma - Chicken', null, 7.45, 0)
INSERT INTO [dbo].[Products] ([Id], [ProductCategoryId] ,[LongName] ,[ShortName] ,[Image] ,[Price], [Deleted]) VALUES (5, 5, 'Chicken Biryani', 'Chicken Biryani', null, 7.95, 0)
INSERT INTO [dbo].[Products] ([Id], [ProductCategoryId] ,[LongName] ,[ShortName] ,[Image] ,[Price], [Deleted]) VALUES (6, 6, 'Mixed Vegetables', 'Mixed Vegetables', null, 6.95, 0)
INSERT INTO [dbo].[Products] ([Id], [ProductCategoryId] ,[LongName] ,[ShortName] ,[Image] ,[Price], [Deleted]) VALUES (7, 7, 'Boiled Rice', 'Boiled Rice', null, 2.00, 0)
INSERT INTO [dbo].[Products] ([Id], [ProductCategoryId] ,[LongName] ,[ShortName] ,[Image] ,[Price], [Deleted]) VALUES (8, 8, 'Naan', 'Naan', null, 2.00, 0)
INSERT INTO [dbo].[Products] ([Id], [ProductCategoryId] ,[LongName] ,[ShortName] ,[Image] ,[Price], [Deleted]) VALUES (9, 9, 'Pickle Tray', 'Pickle Tray', null, 2.00, 0)
INSERT INTO [dbo].[Products] ([Id], [ProductCategoryId] ,[LongName] ,[ShortName] ,[Image] ,[Price], [Deleted]) VALUES (10, 10, 'Ras Malai', 'Ras Malai', null, 2.95, 0)
SET IDENTITY_INSERT [dbo].[Products] OFF


SET IDENTITY_INSERT [dbo].[SpiceTypes] ON
INSERT INTO [dbo].[SpiceTypes]([Id], [Code], [Description])VALUES(0, 'NOR', 'Normal')
INSERT INTO [dbo].[SpiceTypes]([Id], [Code], [Description])VALUES(1, 'SPI', 'Spicy')
INSERT INTO [dbo].[SpiceTypes]([Id], [Code], [Description])VALUES(2, 'VSP', 'Very spicy')
SET IDENTITY_INSERT [dbo].[SpiceTypes] OFF

SET IDENTITY_INSERT [dbo].[OrderTypes] ON
INSERT INTO [dbo].[OrderTypes]([Id], [Code], [Description])VALUES(0, 'DEL', 'Delivery')
SET IDENTITY_INSERT [dbo].[OrderTypes] OFF

GO

GO
PRINT N'Update complete.';


GO
