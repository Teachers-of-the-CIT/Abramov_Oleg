use GoodsStore
go

create table Products
(
    Id           int identity
        constraint [PK_dbo.Products]
            primary key,
    Title        nvarchar(max),
    Description  nvarchar(max),
    Manufacturer nvarchar(max),
    Price        decimal(18, 2) not null,
    Discount     decimal(18, 2) not null
)
go

create table ReceivingPoints
(
    Id        int identity
        constraint [PK_dbo.ReceivingPoints]
            primary key,
    PostIndex nvarchar(max),
    Address   nvarchar(max)
)
go

create table Users
(
    Id         int identity
        constraint [PK_dbo.Users]
            primary key,
    LastName   nvarchar(max),
    FirstName  nvarchar(max),
    MiddleName nvarchar(max),
    Login      nvarchar(max),
    Password   nvarchar(max),
    Role       int not null
)
go

create table Orders
(
    Id               int identity
        constraint [PK_dbo.Orders]
            primary key,
    OrderDate        datetime not null,
    ReceivingDate    datetime not null,
    UserId           int
        constraint [FK_dbo.Orders_dbo.Users_UserId]
            references Users,
    ReceivingPointId int      not null
        constraint [FK_dbo.Orders_dbo.ReceivingPoints_ReceivingPointId]
            references ReceivingPoints
            on delete cascade,
    ReceivingCode    int      not null,
    Status           int      not null
)
go

create table OrderProducts
(
    Id        int identity
        constraint [PK_dbo.OrderProducts]
            primary key,
    ProductId int not null
        constraint [FK_dbo.OrderProducts_dbo.Products_ProductId]
            references Products
            on delete cascade,
    OrderId   int not null
        constraint [FK_dbo.OrderProducts_dbo.Orders_OrderId]
            references Orders
            on delete cascade
)
go

create index IX_ProductId
    on OrderProducts (ProductId)
go

create index IX_OrderId
    on OrderProducts (OrderId)
go

create index IX_UserId
    on Orders (UserId)
go

create index IX_ReceivingPointId
    on Orders (ReceivingPointId)
go

create table __MigrationHistory
(
    MigrationId    nvarchar(150)  not null,
    ContextKey     nvarchar(300)  not null,
    Model          varbinary(max) not null,
    ProductVersion nvarchar(32)   not null,
    constraint [PK_dbo.__MigrationHistory]
        primary key (MigrationId, ContextKey)
)
go

