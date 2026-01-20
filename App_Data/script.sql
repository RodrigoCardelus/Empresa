use master

if exists (select * from sys.databases WHERE name = 'Empresa')
begin
	DROP DATABASE Empresa
end
go

create database Empresa
go

use Empresa
go

create table Empleados
(
	cedula int primary key,
	nombre varchar(20),
	apellido varchar(20),
	nacimiento datetime
)
go

CREATE PROC ListarEmpleados
as
begin
	SELECT * FROM Empleados
end
go

CREATE PROC BuscarEmpleado
	@cedula int
as
begin
	SELECT * FROM Empleados WHERE cedula = @cedula
end
go

CREATE PROC AgregarEmpleado
	@cedula int,
	@nombre varchar(20),
	@apellido varchar(20),
	@nac datetime
as
begin
	if exists (SELECT * FROM Empleados WHERE cedula = @cedula)
		return -1
	INSERT Empleados VALUES (@cedula, @nombre, @apellido, @nac)
		return 1
end
go

CREATE PROC ModificarEmpleado
	@cedula int,
	@nombre varchar(20),
	@apellido varchar(20),
	@nac datetime
as
begin
	if @nac >= GETDATE()
		return -2
	if not exists (SELECT * FROM Empleados WHERE cedula = @cedula)
		return -1
	UPDATE Empleados SET nombre = @nombre
		, apellido = @apellido
		, nacimiento = @nac
	WHERE cedula = @cedula
	return 1
end
go

CREATE PROC EliminarEmpleado
	@cedula int
as
begin
	DELETE Empleados WHERE cedula = @cedula
end