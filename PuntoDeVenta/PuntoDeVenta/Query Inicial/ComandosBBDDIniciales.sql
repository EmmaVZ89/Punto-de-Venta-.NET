CREATE DATABASE PuntoDeVenta;
USE PuntoDeVenta;

CREATE TABLE Privilegios
(
IdPrivilegio INT IDENTITY(1,1),
NombrePrivilegio VARCHAR(50)
);

CREATE TABLE Usuarios
(
IdUsuario INT IDENTITY(1,1),
Nombre VARCHAR(50),
Apellido VARCHAR(50),
DNI INT,
CUIT FLOAT,
Correo VARCHAR(100),
Telefono INT,
Fecha_Nac DATE,
Privilegio INT
);

SELECT * FROM Privilegios;
SELECT * FROM Usuarios;

INSERT INTO Privilegios VALUES ('Administrador');
INSERT INTO Privilegios VALUES ('Vendedor');

INSERT INTO Usuarios VALUES('Emmanuel','Zelarayán',123456789, 98989898,'emma@mail.com', '123456','11/03/1989',1);

ALTER TABLE Usuarios ADD img IMAGE;
ALTER TABLE Usuarios ADD usuario VARCHAR(50);
ALTER TABLE Usuarios ADD contrasenia VARBINARY(500);


SELECT (CONVERT(Varchar(50), DECRYPTBYPASSPHRASE('PuntoDeVenta', contrasenia))) FROM Usuarios WHERE IdUsuario = 1;


-- ####### CREACION DE PROCEDIMIENTOS ALMACENADOS USUARIOS ######

-- PROCEDIMIENTO CONSULTAR
CREATE PROCEDURE SP_U_Consultar
@IdUsuario INT
AS
BEGIN
SELECT * FROM Usuarios WHERE IdUsuario=@IdUsuario
END

-- PROCEDIMIENTO INSERTAR
CREATE PROCEDURE SP_U_Insertar
@Nombre VARCHAR(50),
@Apellido VARCHAR(50),
@DNI INT,
@CUIT FLOAT,
@Correo VARCHAR(100),
@Telefono INT,
@Fecha_Nac DATE,
@Privilegio INT,
@Img VARCHAR(MAX),
@usuario VARCHAR(50),
@contrasenia VARCHAR(500),
@patron VARCHAR(50)
AS BEGIN
INSERT INTO Usuarios VALUES (@Nombre, @Apellido, @DNI, @CUIT, @Correo, @Telefono, @Fecha_Nac, @Privilegio, @Img,
@usuario, (ENCRYPTBYPASSPHRASE(@patron, @contrasenia)))
END

-- PROCEDIMIENTO ELIMINAR
CREATE PROCEDURE SP_U_Eliminar
@IdUsuario INT
AS BEGIN
DELETE FROM Usuarios WHERE IdUsuario=@IdUsuario
END

-- PROCEDIMIENTO ACTUALIZAR DATOS
CREATE PROCEDURE SP_U_ActualizarDatos
@IdUsuario INT,
@Nombre VARCHAR(50),
@Apellido VARCHAR(50),
@DNI INT,
@CUIT FLOAT,
@Correo VARCHAR(100),
@Telefono INT,
@Fecha_Nac DATE,
@Privilegio INT,
@usuario VARCHAR(50)
AS BEGIN
UPDATE Usuarios SET Nombre=@Nombre, Apellido=@Apellido, DNI=@DNI, CUIT=@CUIT, Correo=@Correo, Telefono=@Telefono,
Fecha_Nac=@Fecha_Nac, Privilegio=@Privilegio, usuario=@usuario
WHERE IdUsuario = @IdUsuario
END

-- PROCEDIMIENTO ACTUALIZAR IMÁGEN
CREATE PROCEDURE SP_U_ActualizarIMG
@IdUsuario INT,
@img IMAGE
AS BEGIN
UPDATE Usuarios SET img=@img WHERE IdUsuario=@IdUsuario
END

-- PROCEDIMIENTO ACTUALIZAR CONTRASEÑA
CREATE PROCEDURE SP_U_ActualizarPass
@IdUsuario INT,
@Contrasenia VARCHAR(500),
@patron VARCHAR(50)
AS BEGIN
UPDATE Usuarios SET contrasenia=(ENCRYPTBYPASSPHRASE(@patron, @Contrasenia))
WHERE IdUsuario=@IdUsuario
END

-- PROCEDIMIENTO CARGAR USUARIOS
CREATE PROCEDURE SP_U_CargarUsuarios
AS BEGIN
SELECT * FROM Usuarios
INNER JOIN Privilegios
ON Usuarios.Privilegio=Privilegios.IdPrivilegio
END

-- PROCEDIMIENTO OBTENER NOMBRE PRIVILEGIO
CREATE PROCEDURE SP_P_NombrePrivilegio
@IdPrivilegio VARCHAR(50)
AS BEGIN
SELECT NombrePrivilegio FROM Privilegios
WHERE IdPrivilegio=@IdPrivilegio
END

-- PROCEDIMIENTO OBTENER ID PRIVILEGIO
CREATE PROCEDURE SP_P_InPrivilegio
@NombrePrivilegio VARCHAR(50)
AS BEGIN
SELECT IdPrivilegio FROM Privilegios
WHERE NombrePrivilegio=@NombrePrivilegio
END

-- PROCEDIMIENTO CARGAR PRIVILEGIOS
CREATE PROCEDURE SP_P_CargarPrivilegio
AS BEGIN
SELECT NombrePrivilegio FROM Privilegios
END

-- PROCEDIMIENTO BUSCAR USUARIOS
CREATE PROCEDURE SP_U_Buscar
@buscar VARCHAR(50)
AS BEGIN
SELECT * FROM Usuarios
WHERE Nombre LIKE @buscar+'%' OR Apellido LIKE @buscar+'%'
END