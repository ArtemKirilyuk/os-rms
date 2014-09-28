create table [dbo].[Bookings] (
    [Id] [int] not null identity,
    [CustomerId] [int] not null,
    [BookingTypeId] [int] not null,
    [From] [datetime] not null,
    [Till] [datetime] not null,
    [RequestedOn] [datetime] not null,
    [ForPeople] [int] not null,
    [Cancelled] [bit] not null,
    [Confirmed] [bit] not null,
    primary key ([Id])
)
Go
create table [dbo].[BookingTypes] (
    [Id] [int] not null identity,
    [Code] [nvarchar](3) not null,
    [Description] [nvarchar](300) not null,
    primary key ([Id])
)
Go
create table [dbo].[Customers] (
    [Id] [int] not null identity,
    [CustomerTypeId] [int] not null,
    [FirstName] [nvarchar](100) null,
    [LastName] [nvarchar](100) null,
    [AddressLine1] [nvarchar](100) not null,
    [AddressLine2] [nvarchar](300) null,
    [PostCode] [nvarchar](100) not null,
    [MobilePhone] [nvarchar](max) null,
    [TelePhone] [nvarchar](max) null,
    [Disabled] [bit] not null,
    primary key ([Id])
)
Go
create table [dbo].[CustomerTypes] (
    [Id] [int] not null identity,
    [Code] [nvarchar](3) not null,
    [Description] [nvarchar](300) not null,
    primary key ([Id])
)
Go
create table [dbo].[Roles] (
    [Id] [nvarchar](128) not null,
    [Name] [nvarchar](max) not null,
    [Description] [nvarchar](max) null,
    [Discriminator] [nvarchar](128) not null,
    primary key ([Id])
)
Go
create table [dbo].[UserClaims] (
    [Id] [int] not null identity,
    [UserId] [nvarchar](128) null,
    [ClaimType] [nvarchar](max) null,
    [ClaimValue] [nvarchar](max) null,
    primary key ([Id])
)
Go
create table [dbo].[UserLogins] (
    [UserId] [nvarchar](128) not null,
    [LoginProvider] [nvarchar](128) not null,
    [ProviderKey] [nvarchar](128) not null,
    primary key ([UserId], [LoginProvider], [ProviderKey])
)
Go
create table [dbo].[UserRoles] (
    [UserId] [nvarchar](128) not null,
    [RoleId] [nvarchar](128) not null,
    [IdentityRole_Id] [nvarchar](128) null,
    primary key ([UserId], [RoleId])
)
Go
create table [dbo].[OrderDetails] (
    [Id] [int] not null identity,
    [OrderHeaderId] [int] not null,
    [ProductId] [int] not null,
    [Quantity] [int] not null,
    [SpiceTypeId] [int] not null,
    [Price] [decimal](18, 2) not null,
    [Total] [decimal](18, 2) not null,
    primary key ([Id])
)
Go
create table [dbo].[OrderHeaders] (
    [Id] [int] not null identity,
    [OrderDate] [datetime] not null,
    [CustomerId] [int] not null,
    [OrderTypeId] [int] not null,
    [Cancelled] [bit] not null,
    [SubTotal] [decimal](18, 2) not null,
    [Discount] [decimal](18, 2) not null,
    [Total] [decimal](18, 2) not null,
    [Notes] [nvarchar](300) null,
    primary key ([Id])
)
Go
create table [dbo].[OrderTypes] (
    [Id] [int] not null identity,
    [Code] [nvarchar](3) not null,
    [Description] [nvarchar](300) not null,
    primary key ([Id])
)
Go
create table [dbo].[Products] (
    [Id] [int] not null identity,
    [ProductCategoryId] [int] not null,
    [LongName] [nvarchar](300) null,
    [ShortName] [nvarchar](100) null,
    [Image] [varbinary](max) null,
    [Price] [decimal](18, 2) not null,
    [Deleted] [bit] not null,
    primary key ([Id])
)
Go
create table [dbo].[ProductCategories] (
    [Id] [int] not null identity,
    [Description] [nvarchar](300) not null,
    [Deleted] [bit] not null,
    [Image] [varbinary](max) null,
    primary key ([Id])
)
Go
create table [dbo].[SpiceTypes] (
    [Id] [int] not null identity,
    [Code] [nvarchar](3) not null,
    [Description] [nvarchar](300) not null,
    primary key ([Id])
)
Go
create table [dbo].[Users] (
    [Id] [nvarchar](128) not null,
    [Email] [nvarchar](max) null,
    [EmailConfirmed] [bit] not null,
    [PasswordHash] [nvarchar](max) null,
    [SecurityStamp] [nvarchar](max) null,
    [PhoneNumber] [nvarchar](max) null,
    [PhoneNumberConfirmed] [bit] not null,
    [TwoFactorEnabled] [bit] not null,
    [LockoutEndDateUtc] [datetime] null,
    [LockoutEnabled] [bit] not null,
    [AccessFailedCount] [int] not null,
    [UserName] [nvarchar](max) null,
    primary key ([Id])
)
Go
alter table [dbo].[Bookings] add constraint [Booking_BookingType] foreign key ([BookingTypeId]) references [dbo].[BookingTypes]([Id]) on delete cascade
Go
alter table [dbo].[Bookings] add constraint [Booking_Customer] foreign key ([CustomerId]) references [dbo].[Customers]([Id]) on delete cascade
Go
alter table [dbo].[Customers] add constraint [Customer_CustomerType] foreign key ([CustomerTypeId]) references [dbo].[CustomerTypes]([Id]) on delete cascade
Go
alter table [dbo].[UserRoles] add constraint [IdentityRole_Users] foreign key ([IdentityRole_Id]) references [dbo].[Roles]([Id])
Go
alter table [dbo].[OrderDetails] add constraint [OrderDetail_Product] foreign key ([ProductId]) references [dbo].[Products]([Id]) on delete cascade
Go
alter table [dbo].[OrderDetails] add constraint [OrderDetail_SpiceType] foreign key ([SpiceTypeId]) references [dbo].[SpiceTypes]([Id]) on delete cascade
Go
alter table [dbo].[OrderHeaders] add constraint [OrderHeader_Customer] foreign key ([CustomerId]) references [dbo].[Customers]([Id]) on delete cascade
Go
alter table [dbo].[OrderDetails] add constraint [OrderHeader_OrderDetails] foreign key ([OrderHeaderId]) references [dbo].[OrderHeaders]([Id]) on delete cascade
Go
alter table [dbo].[OrderHeaders] add constraint [OrderHeader_OrderType] foreign key ([OrderTypeId]) references [dbo].[OrderTypes]([Id]) on delete cascade
Go
alter table [dbo].[Products] add constraint [Product_ProductCategory] foreign key ([ProductCategoryId]) references [dbo].[ProductCategories]([Id]) on delete cascade
Go
alter table [dbo].[UserClaims] add constraint [User_Claims] foreign key ([UserId]) references [dbo].[Users]([Id])
Go
alter table [dbo].[UserLogins] add constraint [User_Logins] foreign key ([UserId]) references [dbo].[Users]([Id]) on delete cascade
Go
alter table [dbo].[UserRoles] add constraint [User_Roles] foreign key ([UserId]) references [dbo].[Users]([Id]) on delete cascade
Go
