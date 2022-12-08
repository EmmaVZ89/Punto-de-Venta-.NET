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
