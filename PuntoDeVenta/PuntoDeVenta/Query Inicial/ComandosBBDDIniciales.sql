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