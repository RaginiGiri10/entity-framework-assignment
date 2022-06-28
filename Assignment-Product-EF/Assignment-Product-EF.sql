--create database ProductDB
create database ProductDB
go
use ProductDB
go
--create table Product
create table Product(
Id int not null primary key Identity(1000,1),
[Name] varchar(50),
[Description] varchar(50),
ManufacturedBy varchar(50),
Price int)
go
--Insert record in Product Table
insert into Product values('Iphone','Ios','India',45000)
go
select * from Product