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

-- ARTICULOS

CREATE TABLE Articulos
(
IdArticulo INT IDENTITY(1,1),
Nombre VARCHAR(100),
Grupo INT,
Codigo VARCHAR(100),
Precio FLOAT,
Activo BIT,
Cantidad FLOAT,
UnidadMedida VARCHAR(10),
Img IMAGE,
Descripcion VARCHAR(256)
)

CREATE TABLE Grupos
(
IdGrupo INT IDENTITY (1,1),
Nombre VARCHAR(50)
)


INSERT INTO Grupos VALUES('Bebidas')
INSERT INTO Grupos VALUES('Alimentos')
INSERT INTO Grupos VALUES('Electrodomésticos')

SELECT * FROM Grupos


-- CREACIÓN DE PROCEDIMIENTOS ALMACENADOS PARA ARTICULOS

CREATE PROCEDURE SP_A_CargarArticulos
AS BEGIN
SELECT * FROM Articulos
INNER JOIN Grupos
ON Grupos.IdGrupo = Articulos.Grupo
END

CREATE PROCEDURE SP_G_CargarGrupos
AS BEGIN
SELECT Nombre FROM Grupos
END

CREATE PROCEDURE SP_G_IdGrupo
@Nombre VARCHAR(50)
AS BEGIN
SELECT IdGrupo FROM Grupos
WHERE Nombre = @Nombre
END

CREATE PROCEDURE SP_G_NombreGrupo
@IdGrupo INT
AS BEGIN
SELECT Nombre FROM Grupos
WHERE IdGrupo = @IdGrupo
END

CREATE PROCEDURE SP_A_Buscar
@Nombre VARCHAR(50)
AS BEGIN
SELECT * FROM Articulos
WHERE Nombre LIKE @Nombre+'%' OR Codigo LIKE @Nombre+'%'
END

CREATE PROCEDURE SP_A_Insertar
@Nombre VARCHAR(100),
@Grupo INT,
@Codigo VARCHAR(100),
@Precio FLOAT,
@Activo BIT,
@Cantidad FLOAT,
@UnidadMedida VARCHAR(10),
@Img IMAGE,
@Descripcion VARCHAR(256)
AS BEGIN
INSERT INTO Articulos VALUES(@Nombre, @Grupo, @Codigo, @Precio, @Activo, @Cantidad, @UnidadMedida,
@Img, @Descripcion)
END

CREATE PROCEDURE SP_A_Eliminar
@IdArticulo INT
AS BEGIN
DELETE FROM Articulos
WHERE IdArticulo = @IdArticulo
END

CREATE PROCEDURE SP_A_Consultar
@IdArticulo INT
AS BEGIN
SELECT * FROM Articulos
WHERE IdArticulo = @IdArticulo
END

CREATE PROCEDURE SP_A_Actualizar
@IdArticulo INT,
@Nombre VARCHAR(100),
@Grupo INT,
@Codigo VARCHAR(100),
@Precio FLOAT,
@Activo BIT,
@Cantidad FLOAT,
@UnidadMedida VARCHAR(10),
@Descripcion VARCHAR(256)
AS BEGIN
UPDATE Articulos SET Nombre=@Nombre, Grupo=@Grupo, Codigo=@Codigo, Precio=@Precio, Activo=@Activo, Cantidad=@Cantidad,
UnidadMedida=@UnidadMedida, Descripcion=@Descripcion
WHERE IdArticulo=@IdArticulo
END

CREATE PROCEDURE SP_A_ActualizarIMG
@IdArticulo INT,
@Img IMAGE
AS BEGIN
UPDATE Articulos SET Img=@Img
WHERE IdArticulo=@IdArticulo
END
