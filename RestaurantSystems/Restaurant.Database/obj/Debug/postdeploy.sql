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
