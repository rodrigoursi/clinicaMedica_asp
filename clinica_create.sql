--create database TURNOS_MEDICOS
--go

--drop database TURNOS_MEDICOS
--go

use TURNOS_MEDICOS
Go

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
	cod_usu varchar(10) not null unique,
	password varchar(140) not null,
	nombre_apellido varchar(200) not null,
	email varchar(200) not null unique,
	tipo_documento varchar(20) not null check (tipo_documento in('dni', 'cuil', 'cuit', 'pasaporte')), --solo funciona para sql server
	numero_doc varchar(30) not null unique,
	fecha_nacimiento date not null,
	direccion varchar(50) not null,
	localidad tinyint not null,
	especialidad smallint not null,
	rol tinyint not null,
	altaUsu int not null,
	modiUsu int,
	bajaUsu int,
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
	altaUsu int not null,
	modiUsu int,
	bajaUsu int,
	altaFecha datetime not null default getdate(),
	modiFecha datetime,
	bajaFecha datetime,
	foreign key (estado) references estados (id),
	foreign key (id_paciente) references usuarios (id),
	foreign key (id_medico) references usuarios (id)
)
go

CREATE TABLE dSemana(
	id tinyint primary key identity(1,1),
	cod_dia tinyint not null unique check(cod_dia between 1 and 7),
	diaSemana varchar(10) not null unique
)
go

CREATE TABLE horarios (
	id int primary key identity(1,1),
	id_medico int not null,
	id_dia tinyint not null,
	hora_ini time not null,
	hora_fin time not null,
	foreign key (id_medico) references usuarios (id),
	foreign key (id_dia) references dSemana (id),
	constraint UQ_horarios_id_dia_id_medico unique (id_dia, id_medico)
)
go

CREATE TABLE provincias (
	id tinyint not null primary key identity(1,1),
	provincia varchar(50) not null
)
go

CREATE TABLE localidades(
	id smallint not null primary key identity(1,1),
	localidad varchar(50) NOT NULL,
	id_prov tinyint NOT NULL,
	foreign key (id_prov) references provincias(id)
)  
go


create trigger TR_automaticoFechamodi on usuarios
after update as 
begin 
	update usuarios 
	set modiFecha = getdate()
	from usuarios
	inner join inserted on inserted.id = usuarios.id
end
go

create trigger TR_deleteLogicoyFisico on usuarios
instead of delete as
begin
	declare @bajaFec datetime
	select @bajaFec = bajaFecha from deleted
	if @bajaFec is null begin
		update usuarios set bajausu = 0, bajaFecha = getdate() 
		from usuarios 
		inner join deleted on deleted.id = usuarios.id  end
	else begin
		delete from usuarios
		from usuarios
		inner join deleted on deleted.id = usuarios.id
	end
end
go

create trigger TR_turnos_automaticoFechamodi on turnos
after update as 
begin 
	update turnos 
	set modiFecha = getdate()
	from turnos
	inner join inserted on inserted.id = turnos.id
end
go

create trigger TR_turnos_deleteLogicoyFisico on turnos
instead of delete as
begin
	declare @bajaFec datetime
	select @bajaFec = bajaFecha from deleted
	if @bajaFec is null begin
		update turnos set bajausu = 0, bajaFecha = getdate() 
		from turnos 
		inner join deleted on deleted.id = turnos.id  
	end
	else begin
		delete from turnos
		from turnos
		inner join deleted on deleted.id = turnos.id
	end
end
go