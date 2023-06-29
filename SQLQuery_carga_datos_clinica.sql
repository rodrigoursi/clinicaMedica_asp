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
  (1, 'Cardiología'),
  (2, 'Dermatología'),
  (3, 'Endocrinología'),
  (4, 'Gastroenterología'),
  (5, 'Hematología'),
  (6, 'Neurología'),
  (7, 'Oftalmología'),
  (8, 'Otorrinolaringología'),
  (9, 'Pediatría'),
  (10, 'Psiquiatría'),
  (11, 'Radiología'),
  (12, 'Urología'),
  (13, 'Traumatología'),
  (14, 'Ginecología'),
  (15, 'Oncología'),
  (16, 'Nefrología'),
  (17, 'Neumología'),
  (18, 'Reumatología'),
  (19, 'Anestesiología'),
  (20, 'Cirugía General')
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