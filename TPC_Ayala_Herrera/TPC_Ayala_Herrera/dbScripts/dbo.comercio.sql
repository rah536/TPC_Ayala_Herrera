use master
go
create database Comercio
go
use Comercio
go

--drop table Marca
--drop table productos
--drop table proveedor
--drop table persona
--drop table cliente
--drop table empleado
--	
--drop table categoria
--drop table merchandising
--drop table indumentaria
--drop table rol
--drop table biblioteca



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

insert into productos
(Codigo, IdProveedor, Descripcion, Marca, Categoria, Costo, StockActual, StockMinimo, PorcentajeGanancia, UrlImagen)
VALUES 
(2311,45,'Flanders Camisa Simpsons','TSN','Indumentaria',8899,10,3,15.3,'https://d3ugyf2ht6aenh.cloudfront.net/stores/026/096/products/camisa-flanders-detalle1-bb548264067571ba9115948165995350-1024-1024.jpg'),
(354,49,'Grogu Remera','Estrella Verde ','Indumentaria',6778,5,4,18.4,'https://d3ugyf2ht6aenh.cloudfront.net/stores/026/096/products/remera-grogu1-0a04076c696551199a16551605700897-1024-1024.jpg'),
(666,48,'Bob Esponja pantalon','Macarroni Pizza','Indumentaria',8960,60,4,18.4,'https://d3ugyf2ht6aenh.cloudfront.net/stores/026/096/products/remera-grogu1-0a04076c696551199a16551605700897-1024-1024.jpg'),
(975,12,'Poster Star Wars','Termidor','Merchandising',3060,12,8,4.9,'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSt-vUK7hShpo4iFaANal9dPzSswmYHIX8xFQ&usqp=CAU'),
(541,15,'Taza Seinfeld','Fantoche','Merchandising',1509,33,2,18.9,'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSt-vUK7hShpo4iFaANal9dPzSswmYHIX8xFQ&usqp=CAU'),
(654,10,'Patineta Back to the future','Neurus','Merchandising',17669,10,2,35.4,'https://http2.mlstatic.com/D_NQ_NP_902950-MLA43827219453_102020-O.webp'),
(94,76,'Libros Game of thrones','Guts','Biblioteca',13669,11,4,23.5,'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTOvU1uQ2CvF-v5WCC495jtRPMNWqhMm3ZdtQ&usqp=CAU'),
(99,78,'Libros Harry Potter','BiblioMaster','Biblioteca',9654,16,21,3.5,'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ5hz8gmg9W9mzrgVni6qSBFV1No_rWA_EK7w&usqp=CAU'),
(100,78,'Libros Lord of the Rings','BiblioMaster','Biblioteca',19374,9,2,3.5,'https://http2.mlstatic.com/D_NQ_NP_755931-MLA51914578740_102022-O.webp')

--
create table Marca(
	Id int not null PRIMARY KEY IDENTITY(1,1),
	Descripcion varchar(50) not null,
	Estado bit null
)
insert into Marca (Descripcion, Estado) Values ('Estrella Verde', 1), ('Macarroni Pizza', 1), ('Termi Door', 1)

--

create table proveedor (
	idProveedor int not null primary key identity (1,1),
	razonSocial varchar(50),
	idProducto int  null,
	numeroCliente int  null,
	Nombre varchar (50),
	Apellido varchar (50),
	dni bigint  null,
	cuit bigint,
	domicilio varchar (50),
	mail varchar (50),
	telefono varchar (50),
	estado bit,
	idRol int,
	fechaAlta datetime
)

insert into proveedor(razonSocial,Nombre,Apellido, dni, cuit, domicilio, mail, telefono,estado,idRol) Values 
('Proveeduria los tacaños', 'Juan Claudio', 'Montesordo', 10546197, 20105461975, 'Antigua 351', 'montesano@aol.com', '6666777',1,3),
('Almacen no positivo', 'Raul', 'Mandarinna',23647195,20236471950, 'Larralde 1890','raulinElcapo@hotcorreo.com.ar', '89994343', 1,3),
('Fiado para todos', 'Cristiana', 'Ronalda', 31650942, 2731650942, 'Inyusticia 333','bebetoromario@siuuuu.com', '99991010',1,3)
 
--
create table persona(
	id int not null primary key identity (1,1),
	Nombre varchar (50),
	Apellido varchar (50),
	dni int not null,
	cuit int,
	domicilio varchar (50),
	mail varchar (50),
	telefono varchar (50),
	estado bit,
	idRol int,
	fechaAlta datetime
)

--

Create Table Cliente(
	Id int not null primary key identity (1,1),
	Nombre varchar (50),
	Apellido varchar (50),
	Dni bigint not null,
	Cuit bigint,
	Domicilio varchar (50),
	Mail varchar (50),
	telefono varchar (50),
	estado bit,
	IdRol int,
	FechaAlta datetime,
	NumeroCliente int not null
)

insert into Cliente (Nombre,Apellido, Dni, Cuit, Domicilio, Mail, Telefono, Estado, IdRol, FechaAlta, NumeroCliente) VALUES ('Jose Eduardo','Martinez', 37370566, 20373705660,'A. Contreras 1860 Quilmes', 'je@gmail.com', '',1,2,11/10/2022,1001)

--

create table empleado(
	id int not null primary key identity (1,1),
	Nombre varchar (50),
	Apellido varchar (50),
	dni int not null,
	cuit int,
	domicilio varchar (50),
	mail varchar (50),
	telefono varchar (50),
	estado bit,
	idRol int,
	fechaAlta datetime
)


			 


--________________________________
create table Categoria(
	Id int not null PRIMARY KEY IDENTITY(1,1),
	Descripcion varchar(50) not null,
	Estado bit
)
insert into Categoria (descripcion) values ('sabath')
--
Create Table Merchandising (
    IdCategoria int Foreign Key References Categoria(Id),
	Material varchar(50),
	Tamaño varchar(50)
);

Insert into Merchandising Values (2, 'POLYSTONE', '22 cm')



--
Create Table Indumentaria(
	IdCategoria int Foreign Key References Categoria(Id),
	Genero varchar(10),
	Color varchar(20),
	Talle varchar(5)
);

Insert into Indumentaria Values (1, 'Femenino', 'Blanco', 'XL')

--
Create Table Biblioteca(
	IdCategoria int Foreign Key References Categoria(Id),
	Autor varchar(100),
	Editorial varchar(30),
	Tapa varchar(20),
	FechaPublicacion date
);
          
Insert into Biblioteca Values (3, 'Frank Miller', 'Comicoso', 'Dura', '2020')

--

Create Table Rol(
	Id int primary key identity(1,1),
	Descripcion varchar(50) not null,
	Estado bit null
);

insert into Rol (Descripcion, Estado) VALUES ('Empleado', 1), ('Cliente', 1),('Proveedor', 1),('Administrador', 1)
Create Table Productos(
	Id int primary key identity(1,1),
	Codigo int not null,
	IdProveedor int foreign key references Proveedor(IdProveedor),
	Descripcion varchar(50) not null,
	IdMarca int foreign key references Marca(Id),
	IdCategoria int foreign key references Categoria(Id),
	CostoUnidad money not null,
	StockActual int not null,
	StockMinimo int not null,
	PorcentajeGanancia float not null,
	UrlImagen varchar(200),
	Estado bit
)






Select Prod.Id, Prod.Codigo, prov.razonSocial as razonSocial, Prod.Descripcion, Mar.Descripcion as Marca, Cat.Descripcion as Categoria, Prod.CostoUnidad, Prod.StockActual, Prod.StockMinimo, Prod.PorcentajeGanancia, Prod.UrlImagen from Productos Prod Inner Join proveedor prov On Prod.IdProveedor = prov.idProveedor Inner Join Marca Mar On Mar.Id = Prod.IdMarca Inner Join Categoria Cat On Cat.Id = Prod.IdCategoria


_________________________________________
Create table CompraOperacion(
	Id int not null primary key identity(1,1),
	IdProveedor int foreign key references proveedor(idProveedor),
	FechaCompra datetime,
	--
	IdProducto int foreign key references Productos(Id),
	Cantidad int not null,
	Total money
);