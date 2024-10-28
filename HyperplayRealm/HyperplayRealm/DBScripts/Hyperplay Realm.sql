use master
go
if exists (select name from sys.databases where name = 'HyperplayRealmDB')
begin
	alter database HyperplayRealmDB set single_user with rollback immediate
	drop database HyperplayRealmDB
end
go
create database HyperplayRealmDB
go
use HyperplayRealmDB
go

-- creates Users table
create table Users
(
	Id int primary key identity(1, 1),
	Name nvarchar(50) not null,
	Surname nvarchar(50) not null,
	Email nvarchar(50) not null,
	Password nvarchar(255) not null, --hashed passwords
	ProfilePicturePath nvarchar(100) -- path of the file, use firebase storage
)
go

-- creates Roles table
create table Roles
(
	Id int primary key identity(1, 1),
	Name nvarchar(50) not null,
	Description nvarchar(50) not null
)
go

-- creates UserRoles table (for many-to-many relationship)

create table UserRoles
(
	UserId int not null, 
	RoleId int not null,
	PRIMARY KEY (UserId, RoleId),
	FOREIGN KEY (UserId) REFERENCES Users(Id),
	FOREIGN KEY (RoleId) REFERENCES Roles(Id)
)
go

-- create Developers table

create table Developers
(
	DeveloperId int primary key identity(1, 1),
	Name nvarchar(50) not null,
)

go

-- create Publishers table

create table Publishers
(
	PublisherId int primary key identity(1, 1),
	Name nvarchar(50) not null,
)

go
-- creates Games table

create table Games
(
	Id int primary key identity(1, 1),
	Title nvarchar(50) not null, 
	Price decimal (4,2) not null,
	Quantity int not null,
	PublisherId int not null,
	ReleaseDate DateTime not null,
	FOREIGN KEY (PublisherId) REFERENCES Publishers(PublisherId)
)

go

-- creates Genres table

create table Genres
(
	Id int primary key identity(1, 1),
	Genre nvarchar(20) not null,
)

go

-- creates Genres table

create table GameGenres
(
	GameId int not null,
	GenreId int not null,
	PRIMARY KEY (GameId, GenreId),
	FOREIGN KEY (GameId) REFERENCES Games(Id),
	FOREIGN KEY (GenreId) REFERENCES Genres(Id),
)

go

-- creates GameDevelopers table (for many-to-many relationship)

create table GameDevelopers
(
	GameId int not null,
	DeveloperId int not null,
	PRIMARY KEY (GameId, DeveloperId),
	FOREIGN KEY (GameId) REFERENCES Games(Id),
	FOREIGN KEY (DeveloperId) REFERENCES Developers(DeveloperId)
)
 
go

-- creates Purchases table (for many-to-many relationship between users and games purchases (library))

create table Purchases
(
	UserId int not null,
	GameId int not null,
	PurchaseDate DateTime not NULL default GETDATE(),
	PRIMARY KEY (UserId, GameId),
	FOREIGN KEY (GameId) REFERENCES Games(Id),
	FOREIGN KEY (UserId) REFERENCES Users(Id)
)