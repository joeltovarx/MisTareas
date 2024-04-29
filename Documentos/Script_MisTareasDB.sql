/*CREACION DE LA DB MisTareasDB*/
--CREATE DATABASE MisTareasDB;
GO
USE MisTareasDB;

/*CREACION DE LA TABLA DE USUARIOS*/
GO
CREATE TABLE usuarios(
	idUsuario INT IDENTITY(1,1) PRIMARY KEY,
	nombre VARCHAR(50) NOT NULL,
	email VARCHAR(50) NOT NULL,
	passwd VARCHAR(50) NOT NULL,
	created_at DATETIME,
	updated_at DATETIME
)


/*CREACION DE LA TABLA DE ESTADOS*/
GO
CREATE TABLE catalogo_estados_tareas(
	idEstadoTarea INT IDENTITY(1,1) PRIMARY KEY,
	descripcion VARCHAR(50) NOT NULL,
	created_at DATETIME,
	updated_at DATETIME
)

/*CREACION DE LA TABLA DE TAREAS*/
GO
CREATE TABLE tareas(
	idTarea INT IDENTITY(1,1),
	fecha DATETIME NOT NULL,
	descripcion VARCHAR(255) NOT NULL,
	estado INT FOREIGN KEY REFERENCES catalogo_estados_tareas(idEstadoTarea),
	created_at DATETIME,
	updated_at DATETIME
)

/*ESTADOS INICIALES*/
GO
INSERT INTO catalogo_estados_tareas(descripcion,created_at) VALUES ('ACTIVA',CURRENT_TIMESTAMP);
INSERT INTO catalogo_estados_tareas(descripcion,created_at) VALUES ('FINALIZADA',CURRENT_TIMESTAMP);
INSERT INTO catalogo_estados_tareas(descripcion,created_at) VALUES ('ANULADA',CURRENT_TIMESTAMP);

/*TAREAS DE EJEMPLO*/
GO
INSERT INTO tareas(fecha,descripcion,estado,created_at) VALUES (CURRENT_TIMESTAMP,'Tarea de prueba creada',1,CURRENT_TIMESTAMP);
INSERT INTO tareas(fecha,descripcion,estado,created_at) VALUES (CURRENT_TIMESTAMP,'Tarea de prueba finalizada',2,CURRENT_TIMESTAMP);
INSERT INTO tareas(fecha,descripcion,estado,created_at) VALUES (CURRENT_TIMESTAMP,'Tarea de prueba anulada',3,CURRENT_TIMESTAMP);
GO
SELECT * FROM catalogo_estados_tareas;
SELECT * FROM tareas;


--SELECT T.idTarea, T.fecha,T.descripcion, C.descripcion FROM tareas AS T
--INNER JOIN catalogo_estados_tareas AS C ON T.estado = C.idEstadoTarea

/*PROCEDIMIENTO PARA LISTAR TAREAS*/
GO
CREATE PROCEDURE sp_listar_tareas
AS
BEGIN
	SELECT T.idTarea, T.fecha AS Fecha,T.descripcion AS Descripcion, C.descripcion AS Estado FROM tareas AS T
	INNER JOIN catalogo_estados_tareas AS C ON T.estado = C.idEstadoTarea
END

/*PROCEDIMIENTO PARA OBTENER UNA TAREA*/
GO
CREATE PROCEDURE sp_obtener_tarea(
	@idTarea INT
)
AS
BEGIN 
	SELECT * FROM tareas WHERE idTarea = @idTarea
END

EXEC sp_obtener_tarea @idTarea=4;

/*PROCEDIMIENTO PARA CREAR TAREA*/
GO
CREATE PROCEDURE sp_crear_tarea(
	@descripcion VARCHAR(255)
)
AS
BEGIN
	INSERT INTO tareas(fecha,descripcion,estado,created_at) 
		VALUES (CURRENT_TIMESTAMP,@descripcion,1,CURRENT_TIMESTAMP);
END


/*PROCEDIMIENTO PARA MODIFICAR TAREA*/
GO
CREATE PROCEDURE sp_modificar_tarea(
	@idTarea INT,
	@descripcion VARCHAR(255)
)
AS
BEGIN
	UPDATE  tareas SET descripcion = @descripcion, updated_at = CURRENT_TIMESTAMP 
		WHERE idTarea = @idTarea
END


/*PROCEDIMIENTO PARA ANULAR TAREA*/
GO
CREATE PROCEDURE sp_anular_tarea(
	@idTarea INT
)
AS
BEGIN
	UPDATE  tareas SET		 = 3, updated_at = CURRENT_TIMESTAMP 
		WHERE idTarea = @idTarea
END



/*******************************************/
/***********USUARIIO************************/
/*******************************************/

