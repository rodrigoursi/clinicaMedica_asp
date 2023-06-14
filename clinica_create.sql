CREATE TABLE estados (
id tinyint not null primary key identity(1,1),
codigo tinyint not null unique check(codigo > 0),
estado varchar(50) not null
)
go

CREATE TABLE roles (
id tinyint not null primary key identity(1,1),
codigo tinyint not null unique check(codigo > 0),
rol varchar(50) not null
)
go

CREATE TABLE especialidades (
id smallint not null primary key identity(1,1),
codigo smallint not null unique check(codigo > 0),
especialidad varchar(50) not null
)
go

CREATE TABLE usuarios(
id int not null primary key identity(1,1),
nombre_apellido varchar(200) not null,
email varchar(200) not null unique,
tipo_documento varchar(20) not null,
numero_doc varchar(30) not null unique,
fecha_nacimiento date not null,
direccion varchar(50) not null,
localidad tinyint not null,
especialidad smallint not null,
rol tinyint not null,
altaFecha datetime not null default getdate(),
modiFecha datetime,
bajaFecha datetime,
foreign key (rol) references roles (id),
foreign key (especialidad) references especialidades (id)
)
go

CREATE TABLE turnos
(
id int not null primary key identity(1,1),
id_paciente int not null,
id_medico int not null,
fecha_hora datetime not null,
observaciones text not null,
estado tinyint not null,
altaFecha datetime not null default getdate(),
modiFecha datetime,
bajaFecha datetime,
foreign key (estado) references estados (id),
foreign key (id_paciente) references usuarios (id),
foreign key (id_medico) references usuarios (id)
)
go

CREATE TABLE provincias (
id tinyint not null primary key identity(1,1),
provincia varchar(50) not null
)
go

CREATE TABLE localidades
	(
	id tinyint not null primary key identity(1,1),
	localidad varchar(50) NOT NULL,
	id_prov tinyint NOT NULL,
	foreign key (id_prov) references provincias(id)
	)  
go

