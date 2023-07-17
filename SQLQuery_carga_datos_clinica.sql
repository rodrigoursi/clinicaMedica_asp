USE TURNOS_MEDICOS
GO

INSERT INTO estados(codigo, estado)
VALUES
  (1, 'Borrador'),
  (2, 'Confirmado'),
  (3, 'No asistio'),
  (4, 'Realizado'),
  (5, 'Cancelado')
GO

INSERT INTO especialidades (codigo, especialidad)
VALUES
  (1, 'N/A'),
  (2, 'Dermatología'),
  (3, 'Endocrinología'),
  (4, 'Gastroenterología'),
  (5, 'Hematología'),
  (6, 'Neurología'),
  (7, 'Oftalmología'),
  (8, 'Otorrinolaringología'),
  (9, 'Pediatría'),
  (10, 'Psiquiatría')

GO

INSERT INTO roles(codigo, rol, horariosSi, permisosConfiguracion, permisosFichas, permisosModificarTurno, permisosSoloTurnosPropios)
VALUES
  (1, 'Administrador', 0, 1, 1, 1 ,0),
  (2, 'Recepcionista', 0, 0, 1, 1 ,1),
  (3, 'Medico', 1, 0, 0, 1 ,1),
  (4, 'Paciente', 0, 0, 0, 0, 0)
GO

INSERT INTO dSemana(cod_dia, diaSemana)
VALUES
  (1, 'Lunes'),
  (2, 'Martes'),
  (3, 'Miercoles'),
  (4, 'Jueves'),
  (5, 'Viernes'),
  (6, 'Sabado'),
  (7, 'Dpmingo')
GO

INSERT INTO provincias(provincia)
VALUES
	('CABA'),
	('Buenos Aires'),
	('Catamarca'),
	('Chaco'),
	('Chubut'),
	('Córdoba'),
    ('Corrientes'),
	('Entre Ríos'),
	('Formosa'),
	('Jujuy'),
	('La Pampa'),
    ('La Rioja'),
	('Mendoza'),
	('Misiones'),
	('Neuquén'),
	('Río Negro'),
    ('Salta'),
	('San Juan'),
	('San Luis'),
	('Santa Cruz'),
	('Santa Fe'),
    ('Santiago del Estero'),
	('Tierra del Fuego'),
	('Tucumán')

INSERT INTO localidades(localidad, id_prov)
VALUES
	('Almagro', 1),
	('Pacheco', 2),
	('San Fernando', 2),
	('Caballito', 1),
	('San Telmo', 1)

INSERT INTO usuarios(cod_usu, password, nombre_apellido, email, tipo_documento, numero_doc, fecha_nacimiento, direccion, localidad, especialidad, rol, altaUsu, altaFecha)
VALUES
	('PAS1', 'pas1', 'paciente 1', 'pas1@pas1.com', 'DNI', '10', '01/01/2002', 'Av. liniers 100', 1, 1, 4, 'Admin', '01/01/2021'),
	('PAS2', 'pas2', 'paciente 2', 'pas2@pas2.com', 'DNI', '11', '01/01/2002', 'Av. liniers 200', 2, 1, 4, 'Admin', '01/01/2021'),
	('PAS3', 'pas3', 'paciente 3', 'pas3@pas3.com', 'DNI', '12', '01/01/2002', 'Av. liniers 300', 3, 1, 4, 'Admin', '01/01/2021'),
	('EMP4', 'emp4', 'empleado 1', 'emp1@emp1.com', 'DNI', '13', '01/01/2002', 'Av. liniers 300', 5, 1, 2, 'Admin', '01/01/2021'),
	('MED5', 'med5', 'med5', 'med5@med5.com', 'DNI', '14', '01/01/2002', 'Av. liniers 400', 4, 5, 3, 'Admin', '01/01/2021'),
	('MED6', 'med6', 'med6', 'med6@med6.com', 'DNI', '15', '01/01/2002', 'Av. liniers 400', 4, 6, 3, 'Admin', '01/01/2021'),
	('MED7', 'med7', 'med7', 'med7@med7.com', 'DNI', '16', '01/01/2002', 'Av. liniers 400', 4, 7, 3, 'Admin', '01/01/2021'),
	('MED8', 'med8', 'med8', 'med8@med8.com', 'DNI', '17', '01/01/2002', 'Av. liniers 400', 4, 8, 3, 'Admin', '01/01/2021'),
	('MED9', 'med9', 'med9', 'med9@med9.com', 'DNI', '18', '01/01/2002', 'Av. liniers 400', 4, 9, 3, 'Admin', '01/01/2021'),
	('admin', 'admin', 'admin', 'admin@admin.com', 'DNI', '19', '01/01/2020', 'Av. liniers 500', 1, 1, 1, 'Admin', '01/01/2021')

INSERT INTO horarios(id_medico, id_dia, hora_ini, hora_fin)
VALUES
	(5, 1, '8:00', '11:00'),
	(5, 4, '15:00', '18:00'),
	(6, 3, '13:00', '15:00'),
	(6, 5, '9:00', '13:00'),
	(7, 1, '8:00', '11:00'),
	(7, 4, '15:00', '18:00'),
	(8, 3, '13:00', '15:00'),
	(8, 5, '9:00', '13:00'),
	(9, 1, '8:00', '11:00'),
	(9, 2, '15:00', '18:00'),
	(9, 3, '13:00', '15:00'),
	(9, 4, '9:00', '13:00')

INSERT INTO turnos(id_paciente, id_medico, fecha_hora, observaciones, estado, altaUsu)
VALUES
	(3, 6, '2023-07-19 13:00:00', 'observacion general', 1, 'Admin')