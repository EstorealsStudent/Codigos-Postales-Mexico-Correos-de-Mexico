Use master
go
IF EXISTS (SELECT name FROM master.sys.databases WHERE name = N'CorreosMexico')
Drop DATABASE CorreosMexico
GO

CREATE DATABASE CorreosMexico
GO
USE CorreosMexico
GO

CREATE TABLE codigospostaless (
  d_codigo NVARCHAR(255) ,
    d_asenta NVARCHAR(255) ,
    d_tipo_asenta NVARCHAR(255) ,
    D_mnpio NVARCHAR(255) ,
    d_estado NVARCHAR(255) ,
    d_ciudad NVARCHAR(255) ,
    d_CP NVARCHAR(255) ,
    c_estado NVARCHAR(255) ,
    c_oficina NVARCHAR(255) ,
    c_CP NVARCHAR(255) ,
    c_tipo_asenta NVARCHAR(255) ,
    c_mnpio NVARCHAR(255) ,
    id_asenta_cpcons NVARCHAR(255) ,
    d_zona NVARCHAR(255) ,
    c_cve_ciudad NVARCHAR(255) 
) ;
-- Cargar datos desde el archivo de texto
BULK INSERT codigospostaless
FROM 'C:\Users\estor\Downloads\CPdescarga.txt'
WITH (
    FIELDTERMINATOR = '|',
    ROWTERMINATOR = '\n',
	FIRSTROW = 2,
    CODEPAGE = '65001' -- 65001 es el código de página para UTF-8
)
select*from codigospostaless


CREATE TABLE Asentamiento
(
 id INT IDENTITY(1,1) PRIMARY KEY,
 Nombre VARCHAR(500) NOT NULL,
 CodigoPostal CHAR(5) NOT NULL,

 IdTipoAsentamiento INT,
 IdZona INT,
 IdMunicipio INT,
 IdUsuarioCrea INT,
 FechaCrea DATETIME DEFAULT GETDATE(),
 IdUsuarioModifica INT NULL,
 FechaModifica DATETIME DEFAULT NULL,
 Estatus BIT DEFAULT 1
)
GO
CREATE TABLE TipoAsentamiento
(
 id INT IDENTITY(1,1) PRIMARY KEY,
 Nombre VARCHAR(500) NOT NULL,
 IdUsuarioCrea INT,
 FechaCrea DATETIME DEFAULT GETDATE(),
 IdUsuarioModifica INT NULL,
 FechaModifica DATETIME DEFAULT NULL,
 Estatus BIT DEFAULT 1
)
GO

CREATE TABLE Zona
(
 id INT IDENTITY(1,1) PRIMARY KEY,
 Nombre VARCHAR(500) NOT NULL,
 IdUsuarioCrea INT,
 FechaCrea DATETIME DEFAULT GETDATE(),
 IdUsuarioModifica INT NULL,
 FechaModifica DATETIME DEFAULT NULL,
 Estatus BIT DEFAULT 1
)
GO
CREATE TABLE Municipio
(
 id INT IDENTITY(1,1) PRIMARY KEY,
 Nombre VARCHAR(500) NOT NULL,
 IdEstado INT,
 IdUsuarioCrea INT,
 FechaCrea DATETIME DEFAULT GETDATE(),
 IdUsuarioModifica INT NULL,
 FechaModifica DATETIME DEFAULT NULL,
 Estatus BIT DEFAULT 1
)

CREATE TABLE Estado
(
 id INT IDENTITY(1,1) PRIMARY KEY,
 Nombre VARCHAR(500) NOT NULL,
 IdUsuarioCrea INT,
 FechaCrea DATETIME DEFAULT GETDATE(),
 IdUsuarioModifica INT NULL,
 FechaModifica DATETIME DEFAULT NULL,
 Estatus BIT DEFAULT 1
)
GO


 
ALTER TABLE Municipio
ADD CONSTRAINT  FK_MunicipioEstado
FOREIGN KEY  (IdEstado)
REFERENCES Estado(id)
GO

ALTER TABLE Asentamiento
ADD CONSTRAINT  FK_AsentamientoZona
FOREIGN KEY  (idzona)
REFERENCES zona(id)
GO
ALTER TABLE Asentamiento
ADD CONSTRAINT  FK_AsentamientoTipoAsentamiento
FOREIGN KEY  (IdTipoAsentamiento)
REFERENCES TipoAsentamiento(id)
GO
ALTER TABLE Asentamiento
ADD CONSTRAINT  FK_AsentamientoMunicipio
FOREIGN KEY  (Idmunicipio)
REFERENCES municipio(id)
GO

CREATE TABLE Usuario
(
 id INT IDENTITY(1,1) PRIMARY KEY,
 Nombre VARCHAR(50) NOT NULL,
 username VARCHAR(50) NOT NULL,
 Password VARCHAR(50) NOT NULL,
 Estatus BIT DEFAULT 1
)
GO

ALTER TABLE Asentamiento
ADD CONSTRAINT  FK_AsentamientoUsuarioCrea
FOREIGN KEY  (IdUsuarioCrea)
REFERENCES usuario(id)
GO

ALTER TABLE Asentamiento
ADD CONSTRAINT  FK_AsentamientoUsuarioModifica
FOREIGN KEY  (IdUsuarioModifica)
REFERENCES usuario(id)
GO
ALTER TABLE TipoAsentamiento
ADD CONSTRAINT  FK_TipoAsentamientoUsuarioCrea
FOREIGN KEY  (IdUsuarioCrea)
REFERENCES usuario(id)
GO

ALTER TABLE TipoAsentamiento
ADD CONSTRAINT  FK_TipoAsentamientoUsuarioModifica
FOREIGN KEY  (IdUsuarioModifica)
REFERENCES usuario(id)
GO

ALTER TABLE Zona
ADD CONSTRAINT  FK_ZonaUsuarioCrea
FOREIGN KEY  (IdUsuarioCrea)
REFERENCES usuario(id)
GO

ALTER TABLE Zona
ADD CONSTRAINT  FK_ZonaUsuarioModifica
FOREIGN KEY  (IdUsuarioModifica)
REFERENCES usuario(id)
GO
ALTER TABLE Municipio
ADD CONSTRAINT  FK_MunicipioUsuarioCrea
FOREIGN KEY  (IdUsuarioCrea)
REFERENCES usuario(id)
GO

ALTER TABLE Municipio
ADD CONSTRAINT  FK_MunicipioUsuarioModifica
FOREIGN KEY  (IdUsuarioModifica)
REFERENCES usuario(id)
GO
ALTER TABLE Estado
ADD CONSTRAINT  FK_EstadoUsuarioCrea
FOREIGN KEY  (IdUsuarioCrea)
REFERENCES usuario(id)
GO

ALTER TABLE Estado
ADD CONSTRAINT  FK_EstadoUsuarioModifica
FOREIGN KEY  (IdUsuarioModifica)
REFERENCES usuario(id)
GO


--INDICES
CREATE INDEX IX_Usuario ON Usuario(id)
GO
CREATE INDEX IX_Asentamiento ON Asentamiento(id)
GO
CREATE INDEX IX_TipoAsentamiento ON TipoAsentamiento(id)
GO
CREATE INDEX IX_Zona ON zona(id)
GO
CREATE INDEX IX_Municipio ON Municipio(id)
GO
CREATE INDEX IX_Estado ON Estado(id)
GO
--Poblar
INSERT INTO Usuario(Nombre,username,Password)
VALUES('Admin','admin', CONVERT(NVARCHAR(50),HashBYTES('SHA1','Admin'),2))

select CONVERT(NVARCHAR(50),HashBYTES('SHA1','Admin'),2)
length

SELECT* FROM Usuario


INSERT INTO Zona(Nombre,IdUsuarioCrea)
SELECT DISTINCT d_zona,1 FROM codigospostaless

SELECT * FROM Zona
--Por si te equivocas
--Delete Asentamiento
--DBCC CHEKIDENT ('Zona',RESEED,0) --- Esto hace el reinicio de los numero sde los identity


INSERT INTO Estado(Nombre,IdUsuarioCrea)
SELECT DISTINCT d_Estado,1 FROM codigospostaless

SELECT * FROM Estado

INSERT INTO TipoAsentamiento(Nombre,IdUsuarioCrea)
SELECT DISTINCT d_tipo_asenta,1 FROM codigospostaless order by d_tipo_asenta --27


select*from Asentamiento


INSERT INTO Municipio(Nombre,IdEstado,IdUsuarioCrea)
select distinct D_mnpio,(select id from Estado where nombre=d_estado) as d_estado,1
from codigospostaless order by d_estado,D_mnpio


INSERT INTO Asentamiento(Nombre,CodigoPostal,idtipoasentamiento,idzona,IdMunicipio,IdUsuarioCrea)
SELECT DISTINCT d_asenta,d_codigo,
(select id from TipoAsentamiento where Nombre=d_tipo_asenta) as d_tipo_asenta,
(select id from zona where nombre=d_zona) as idzona,
(select id from Municipio where nombre=d_mnpio and IdEstado=(select id from Estado where nombre=d_estado)) as idmunicipio,
1 as idUsuario
from codigospostaless order by d_asenta,d_codigo,d_tipo_asenta

--Delete Asentamiento
--DBCC CHEKIDENT ('asentamiento',RESEED,0) --- Esto hace el reinicio de los numero sde los identity
 
select*from Asentamiento
select*from TipoAsentamiento
select*from Zona
select*from Estado
select*from Municipio
select*from Usuario
GO

CREATE VIEW VnombreBUSQUEDA 
AS
select Asentamiento.id,Asentamiento.Nombre AS [Nombre Asentamiento],Asentamiento.CodigoPostal,
TipoAsentamiento.nombre AS [Tipo de Asentamiento] ,Zona.nombre AS [NombreZona],municipio.nombre AS [Nombre Municipio],Estado.Nombre AS [Nombre Estado]
from Asentamiento 
inner join TipoAsentamiento on TipoAsentamiento.id=Asentamiento.IdTipoAsentamiento
inner join Zona on Zona.id=Asentamiento.IdZona
inner join Municipio on Municipio.id=Asentamiento.IdMunicipio
inner join Estado on Estado.id=Municipio.IdEstado
