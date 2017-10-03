/********************************************* INICIO - CREACION ESQUEMA *******************************************/
USE GD2C2017;
GO
CREATE SCHEMA REQUIRED AUTHORIZATION gd 
GO

/********************************************* FIN - CREACION ESQUEMA **********************************************/

/******************************************** INICIO - CREACION DE TABLAS ******************************************/

create table GOQ.Rol( 
	rol_id int CONSTRAINT PK_rol_id PRIMARY KEY NOT NULL IDENTITY(1,1),
	rol_nombre varchar(15) not null,
	rol_habilitado bit  DEFAULT 1 not null 
);

GO	
create table GOQ.Funcionalidad(
	fun_id int CONSTRAINT PK_fun_id PRIMARY KEY NOT NULL IDENTITY(1,1),
	fun_nombre varchar(30)
);

GO	
create table GOQ.Funcionalidad_Rol(
	fun_rol_rol_id int  not null, /* FK  GOQ.Rol */
	fun_rol_fun_id int not null, /* FK  GOQ.Funcionalidad */
	CONSTRAINT PK_funcionalidad_rol PRIMARY KEY (fun_rol_rol_id, fun_rol_fun_id)
); 

GO
create table GOQ.Usuario(
	usu_id int CONSTRAINT PK_usu_id PRIMARY KEY NOT NULL IDENTITY(1,1),
	usu_username varchar(25) not null UNIQUE,
	usu_password varbinary(64) not null,
	usu_intentos int DEFAULT 0,
	usu_habilitado bit DEFAULT 0,
);

GO
create table GOQ.Rol_Usuario(
	rol_usu_rol_id int  not null,  /* FK  GOQ.Rol */
	rol_usu_usu_id int  not null,  /* FK  GOQ.Usuario */
	CONSTRAINT PK_rol_usuario PRIMARY KEY (rol_usu_rol_id, rol_usu_usu_id)
);

/******************************************** FIN - CREACION DE TABLAS *********************************************/

/******************************************** INICIO - FOREING KEY *************************************************/
GO
alter table GOQ.Funcionalidad_Rol
add constraint FK_fun_rol_rol_id foreign key (fun_rol_rol_id) references GOQ.Rol(rol_id),
	constraint FK_fun_rol_fun_id foreign key (fun_rol_fun_id) references GOQ.Funcionalidad(fun_id);

GO
alter table GOQ.Rol_Usuario
add constraint FK_rol_usu_rol_id foreign key (rol_usu_rol_id) references GOQ.Rol(rol_id),
	constraint FK_rol_usu_usu_id foreign key (rol_usu_usu_id) references GOQ.Usuario(usu_id);

GO

/******************************************** FIN - FOREING KEY ********************************************/

/************************************** INICIO / CREACION - FUNCIONES **************************************/

----------------------------------ENCRIPTAR A HASH256

CREATE FUNCTION GOQ.F_Hash256(@password char(64))
RETURNS varbinary(64)
BEGIN
	RETURN HASHBYTES('SHA2_256',@password)
END;

----------------------------------TRANSFORMAR A MAYUSCULAS SIN TILDES
GO
CREATE FUNCTION GOQ.F_ObtenerPasswordGenerica(@usuario varchar(255))
RETURNS varbinary(64)
BEGIN
	return GOQ.F_Hash256(@usuario)
END;


/*************************************** FIN / CREACION - FUNCIONES ***************************************/
/***************************** INICIO / CREACION DE STORED PROCEDURES Y VISTAS *****************************//***************************** FIN / CREACION DE STORED PROCEDURES Y VISTAS *****************************/

/******************************************** INICIO - LLENADO DE TABLAS *********************************************/
/******************************************** FIN - LLENADO DE TABLAS *********************************************/
/******************************************** INICIO - TRIGGERS *****************************************//******************************************** FIN - TRIGGERS *****************************************/

