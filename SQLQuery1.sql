create database DBean
go

use DBean
go

create table libros
(
codigo varchar(5),
titulo varchar(40),
autor varchar(30),
editorial varchar(20),
precio decimal(5,2),
cantidad smallint,
primary key(codigo)
)  

go

create proc sp_listar_libros
as
select * from libros order by codigo
go

create proc sp_buscar_libros
@autor varchar(50)
as
select codigo,titulo,autor,editorial,precio,cantidad from libros where autor like @autor + '%'
go
