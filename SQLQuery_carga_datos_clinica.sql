USE TURNOS_MEDICOS
GO

INSERT INTO estados(codigo, estado)
VALUES
  (1, 'Borrador'),
  (2, 'Confirmado'),
  (3, 'Reprogramado'),
  (4, 'Realizado'),
  (5, 'Cancelado')
GO

INSERT INTO especialidades (codigo, especialidad)
VALUES
  (1, 'Cardiolog�a'),
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

INSERT INTO roles(codigo, rol)
VALUES
  (1, 'Administrador'),
  (2, 'Empleado'),
  (3, 'Medico'),
  (4, 'Paciente'),
  (5, 'Otro')
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