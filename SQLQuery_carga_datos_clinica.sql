USE TURNOS_MEDICOS
GO

INSERT INTO estados(codigo, estado)
VALUES
  (1, 'Borrador'),
  (2, 'Confirmado'),
  (3, 'Realizado'),
  (4, 'Cancelado')
GO

INSERT INTO especialidades (codigo, especialidad)
VALUES
  (1, 'N/A'),
  (2, 'Dermatolog�a'),
  (3, 'Endocrinolog�a'),
  (4, 'Gastroenterolog�a'),
  (5, 'Hematolog�a'),
  (6, 'Neurolog�a'),
  (7, 'Oftalmolog�a'),
  (8, 'Otorrinolaringolog�a'),
  (9, 'Pediatr�a'),
  (10, 'Psiquiatr�a'),
  (11, 'Radiolog�a'),
  (12, 'Urolog�a'),
  (13, 'Traumatolog�a'),
  (14, 'Ginecolog�a'),
  (15, 'Oncolog�a'),
  (16, 'Nefrolog�a'),
  (17, 'Neumolog�a'),
  (18, 'Reumatolog�a'),
  (19, 'Anestesiolog�a'),
  (20, 'Cirug�a General')
GO

INSERT INTO roles(codigo, rol, horariosSi, permisosConfiguracion, permisosFichas, permisosModificarTurno, permisosSoloTurnosPropios)
VALUES
  (1, 'Administrador', 0, 1, 1, 1 ,0),
  (2, 'Recepcionista', 0, 0, 0, 0 ,0),
  (3, 'Medico', 1, 0, 1, 1 ,1),
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
	('C�rdoba'),
    ('Corrientes'),
	('Entre R�os'),
	('Formosa'),
	('Jujuy'),
	('La Pampa'),
    ('La Rioja'),
	('Mendoza'),
	('Misiones'),
	('Neuqu�n'),
	('R�o Negro'),
    ('Salta'),
	('San Juan'),
	('San Luis'),
	('Santa Cruz'),
	('Santa Fe'),
    ('Santiago del Estero'),
	('Tierra del Fuego'),
	('Tucum�n')

INSERT INTO localidades(localidad, id_prov)
VALUES
	('Almagro', 1),
	('Pacheco', 2),
	('San Fernando', 2),
	('Caballito', 1),
	('San Telmo', 1)

INSERT INTO usuarios(cod_usu, password, nombre_apellido, email, tipo_documento, numero_doc, fecha_nacimiento, direccion, localidad, especialidad, rol, altaUsu, altaFecha)
VALUES
	('MED-3', 'med3', 'med3', 'med3@med3.com', 'DNI', '2222222', '01/01/2002', 'Av. liniers 400', 4, 6, 3, 'Admin', '01/01/2021'),
	('ADM-001', 'admin', 'Admin', 'admin@admin.com', 'DNI', '11111111', '01/01/2020', 'Av. liniers 500', 1, 1, 1, 'Admin', '01/01/2021')