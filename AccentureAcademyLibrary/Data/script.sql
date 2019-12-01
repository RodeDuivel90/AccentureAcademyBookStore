create database AccentureAcademyBooks

go

use AccentureAcademyBooks


create table Autores

(

Id int primary key identity(1,1),

Apellido varchar(30) not null,

Nombre varchar(30),

Nacionalidad varchar(20) not null,

AñoNacimiento int not null,

AñoFallecimiento int

CONSTRAINT UQ_APELLIDO_NOMBRE UNIQUE (Apellido, Nombre)



)



create table Generos

(

Id int primary key identity(1,1),

NombreGenero varchar(30) not null

CONSTRAINT UQ_NOMBREGENERO UNIQUE (NombreGenero)



)





create table Editoriales

(

Id int primary key identity(1,1),

NombreEditorial varchar(30) not null,

Pais varchar(20) not null,

Website varchar(70), 

CONSTRAINT UQ_NOMBREEDITORIAL UNIQUE (NombreEditorial)



)









create table Libros

(

Id int primary key identity (1,1),

Isbn varchar(13) not null,

NombreLibro varchar(50) not null,

Idioma varchar(20) not null,

AñoEdicion int not null,

CONSTRAINT UQ_ISBN UNIQUE (Isbn),

CONSTRAINT CHK_ISBN CHECK (len(Isbn)=13 or len(Isbn)=10),

)

create table GenerosLibros(
Id_Libro int not null,
Id_Genero int not null,
constraint FK_GenerosLibros_Libro

FOREIGN KEY (Id_Libro)

REFERENCES Libros(Id)

ON DELETE CASCADE,

constraint FK_GenerosLibros_Genero

FOREIGN KEY (Id_Genero)

REFERENCES Generos(Id)

ON DELETE CASCADE,

CONSTRAINT PK_GENEROS_LIBROS PRIMARY KEY(Id_Libro, Id_Genero),

CONSTRAINT UQ_GENEROS_LIBROS UNIQUE (Id_Libro, Id_Genero)

)

create table EditorialesLibros
(
Id_Libro int not null,
Id_Editorial int not null,

constraint FK_EditorialesLibros_Libro

FOREIGN KEY (Id_Libro)

REFERENCES Libros(Id)

ON DELETE CASCADE,

constraint FK_EditorialesLibros_Editorial

FOREIGN KEY (Id_Editorial)

REFERENCES Editoriales(Id)

ON DELETE CASCADE,

CONSTRAINT PK_EDITORIALES_LIBROS PRIMARY KEY(Id_Libro, Id_Editorial),

CONSTRAINT UQ_EDITORIALES_LIBROS UNIQUE (Id_Libro, Id_Editorial)


)



create table AutoresDeLibros
(


Id_Libro int not null, 
Id_Autor int not null,
constraint FK_AutoresLibros_Libro

FOREIGN KEY (Id_Libro)

REFERENCES Libros(Id)

ON DELETE CASCADE,

constraint FK_AutoresLibros_Autor

FOREIGN KEY (Id_Autor)

REFERENCES Autores(Id)

ON DELETE CASCADE,

CONSTRAINT PK_AUTORES_LIBROS PRIMARY KEY(Id_Libro, Id_Autor)

)

insert into Generos
(NombreGenero) values
('Novela Histórica')

insert into Autores
(Apellido,Nombre,Nacionalidad,AñoNacimiento,AñoFallecimiento)
values
('Luo','Guanzhong','Chino',1320,1400)

insert into Editoriales
(NombreEditorial,Pais,Website)
values
('Tuttle Publishing','Estados Unidos','www.tuttlepublishing.com')

insert into Libros
(Isbn,NombreLibro,Idioma,AñoEdicion)
values
(9780804843935,'The Three Kingdoms : The Sacred Oath','Inglés',2014)


insert into Generos
(NombreGenero) values
('Ficción Narrativa')

insert into Autores
(Apellido,Nombre,Nacionalidad,AñoNacimiento,AñoFallecimiento)
values
('Borges','Jorge Luis','Argentino',1899,1986)

insert into Editoriales
(NombreEditorial,Pais,Website)
values
('Debolsillo','Argentina','https://www.penguinrandomhousegrupoeditorial.com/sellos/')

insert into Libros
(Isbn,NombreLibro,Idioma,AñoEdicion)
values
(9789875666481,'El Aleph','Castellano',2011)


insert into Generos
(NombreGenero) values
('Literatura Fantástica')

insert into Autores
(Apellido,Nombre,Nacionalidad,AñoNacimiento,AñoFallecimiento)
values
('Tolkien','John Ronald Reuel','Británico',1892,1973)

insert into Editoriales
(NombreEditorial,Pais,Website)
values
('Minotauro','España','www.planetadelibros.com/editorial/minotauro/21')

insert into Libros
(Isbn,NombreLibro,Idioma,AñoEdicion)
values
(9788445073728,'El Señor de los Anillos : La Comunidad del Anillo','Castellano',2002)

insert into AutoresDeLibros
(Id_Libro,Id_Autor)
values
(1,1),
(2,2),
(3,3)


insert into GenerosLibros
(Id_Libro,Id_Genero)
values
(1,1),
(2,2),
(3,3)

insert into EditorialesLibros
(Id_Libro,Id_Editorial)
values
(1,1),
(2,2),
(3,3)