Use master;
go
drop database if exists ShopDB
go
create database ShopDB
go
use ShopDB
go

create table CustomerInvoice
(
CID int primary key,
CName varchar(100),
Email varchar (100),
Paid money,

)
go


insert into CustomerInvoice values
(1,'Asif Ali','asif@gmail.com',100),
(2,'Afftab Ahmed','aftab@gmail.com',200),
(3,'Imtiaz Hossain','imtiaz@gmail.com',300),
(4,'Jahangir Alom','jahangir@gmail.com',400),
(5,'Zahir Khan','zahir@gmail.com',500),
(6,'Fazle Rahat','rahat@gmail.com',600),
(7,'Mohiuddin Shafak','shafak@gmail.com',700)
go
select * from CustomerInvoice