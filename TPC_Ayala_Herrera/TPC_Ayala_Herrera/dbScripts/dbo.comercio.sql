use master
go
create database Comercio
go
use Comercio
go

--drop table productos

create table Productos(
Id INT not null PRIMARY KEY IDENTITY(1,1),
Codigo int not null,
IdProveedor int not null,
Descripcion varchar(50) not null,
Marca varchar(50) not null,
Categoria varchar (50) not null,
Costo Money not null check (Costo >=0),
StockActual int not null,
StockMinimo int not null,
PorcentajeGanancia float not null,
UrlImagen varchar (200) null)

