/********************************************* INICIO - CREACION ESQUEMA *******************************************/
USE GD2C2017;
GO
CREATE SCHEMA GOQ AUTHORIZATION gd 
GO

/********************************************* FIN - CREACION ESQUEMA **********************************************/

/******************************************** INICIO - CREACION DE TABLAS ******************************************/

create table GOQ.Rol( 
	rol_id int CONSTRAINT PK_rol_id PRIMARY KEY IDENTITY(1,1),
	rol_nombre nvarchar(15) not null,
	rol_habilitado bit  DEFAULT 1 not null 
);

GO	
create table GOQ.Funcionalidad(
	fun_id int CONSTRAINT PK_fun_id PRIMARY KEY IDENTITY(1,1),
	fun_nombre nvarchar(30)
);

GO	
create table GOQ.Funcionalidad_Rol(
	fun_rol_rol_id int, /* FK  GOQ.Rol */
	fun_rol_fun_id int, /* FK  GOQ.Funcionalidad */
	CONSTRAINT PK_funcionalidad_rol PRIMARY KEY (fun_rol_rol_id, fun_rol_fun_id)
); 

GO
create table GOQ.Usuario(
	usu_id int CONSTRAINT PK_usu_id PRIMARY KEY IDENTITY(1,1),
	usu_username nvarchar(25) not null UNIQUE,
	usu_password varbinary(64) not null,
	usu_intentos int DEFAULT 0,
	usu_habilitado bit DEFAULT 1,
);

GO
create table GOQ.Rol_Usuario(
	rol_usu_rol_id int,  /* FK  GOQ.Rol */
	rol_usu_usu_id int,  /* FK  GOQ.Usuario */
	CONSTRAINT PK_rol_usuario PRIMARY KEY (rol_usu_rol_id, rol_usu_usu_id)
);

GO 
create table GOQ.Sucursal(
	sucu_id int  CONSTRAINT PK_sucu_id PRIMARY KEY IDENTITY(1,1),
	sucu_nombre nvarchar(50)  not null,
	sucu_dir nvarchar(50)  not null ,
	sucu_cp numeric(18,0) not null UNIQUE,
	sucu_habilitado bit DEFAULT 1 
);

GO
create table GOQ.CobradorSucursal(
	sucu_id int, /* FK a GOQ.Sucursal*/ 
	usu_id int, /* FK a GOQ.Usuario */
	CONSTRAINT PK_cobrador_sucursal PRIMARY KEY (sucu_id, usu_id)
);


GO
create table GOQ.Cliente(
	cli_id int CONSTRAINT PK_cli_id PRIMARY KEY IDENTITY(1,1),
	cli_nombre nvarchar(255) not null,
	cli_apellido nvarchar(255) not null,
	cli_dni numeric(18,0) not null,
	cli_mail nvarchar(255) not null UNIQUE,
	cli_tel numeric(18,0) not null,
	cli_dir nvarchar(255) not null,
	cli_cp nvarchar(255) not null,
	cli_habilitado bit DEFAULT 1,
	cli_fecha_nac datetime not null
);

GO
create table GOQ.Empresa(
	ID_empresa int CONSTRAINT PK_empresa_id_empresa PRIMARY KEY IDENTITY(1,1),
	empresa_cuit nvarchar(50) not null UNIQUE,
	empresa_nombre nvarchar(255) not null,
	empresa_dir nvarchar(255) not null,
	empresa_habilitado bit DEFAULT 1
);

GO
create table GOQ.Servicio_Empresa(
	ID_servicio int, /* FK a GOQ.Servicio*/
	ID_empresa int, /* FK a GOQ.Empresa */
	CONSTRAINT PK_Servicio_Empresa PRIMARY KEY (ID_servicio, ID_empresa)
);

GO
create table GOQ.Servicio(
	serv_id int CONSTRAINT PK_serv_id PRIMARY KEY IDENTITY(1,1),
	serv_descripcion nvarchar(50)
);

GO
create table GOQ.Pago(
	pago_id numeric(18,0) CONSTRAINT PK_pago_id PRIMARY KEY,
	pago_fac_id numeric(18,0), /* FK a GOQ.Factura*/
	pago_fecha_cobro datetime not null,
	pago_empresa_id int, /* FK a GOQ.Empresa*/
	pago_cliente_id int, /* FK a GOQ.Cliente*/
	pago_fecha_vencim datetime not null CHECK(pago_fecha_vencim<getDate()) ,
	pago_importe numeric(18,0) not null CHECK(pago_importe>0),
	pago_tipo_id int , /* FK a GOQ.Tipo_Pago*/
	pago_usuario_id int /* FK a GOQ.Usuario*/
);

GO
create table GOQ.Rendicion(
	ren_id numeric(18,0) CONSTRAINT PK_ren_id PRIMARY KEY,
	ren_fecha_ren datetime not null,
	ren_cant_fac int not null,
	ren_imp_comision numeric(18,0) not null,
	ren_empresa_id int, /*FK GOQ.Empresa*/
	ren_porc_comision_id int, /*FK GOQ.Porcentaje_Comision*/
	ren_imp_total numeric(18,2) not null
);

GO
create table GOQ.Factura(
	 fac_id numeric(18,0) CONSTRAINT PK_fac_id PRIMARY KEY,
	 fac_cli_id int, /*FK GOQ.Cliente*/
	 fac_empresa_id int, /* FK GOQ.Empresa */
	 fac_fecha_alta datetime not null,
	 fac_fecha_vec datetime not null,
	 fac_total numeric(18,2) not null
);

GO
create table GOQ.Item(
	numeroItem int CONSTRAINT PK_numeroItem_id PRIMARY KEY IDENTITY(1,1),
	fac_id numeric(18,0),  /*FK GOQ.Factura*/
	Monto numeric(18,2) not null,
	Cantidad numeric(18,0) not null
);

GO
create table GOQ.Tipo_Pago(
	tipo_pago_id int CONSTRAINT PK_tipo_pago_id PRIMARY KEY IDENTITY(1,1),
	tipo_pago_descripcion nvarchar(255) 
);

GO
create table GOQ.Devolucion(
	dev_id int CONSTRAINT PK_dev_id PRIMARY KEY IDENTITY(1,1),
	dev_fac_id numeric(18,0), /*FK GOQ.Factura*/
	dev_motivo nvarchar(255) not null
);

GO
create table GOQ.RendicionFactura(
	ren_fac_idRendicion int CONSTRAINT PK_ren_fac_idRendicion PRIMARY KEY IDENTITY(1,1),
	ren_id numeric(18,0),  /*FK GOQ.Rendicion*/
	ren_fac_id numeric(18,0)  /*FK GOQ.Factura*/
);

GO
create table GOQ.Porcentaje_Comision(
 porc_comi_id int CONSTRAINT PK_porc_comi_id PRIMARY KEY IDENTITY(1,1),
 porc_periodo int
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
alter table GOQ.CobradorSucursal
add constraint FK_sucu_id foreign key (sucu_id) references GOQ.Sucursal(sucu_id),
	constraint FK_usu_id foreign key (usu_id) references GOQ.Usuario(usu_id);
GO
alter table GOQ.Servicio_Empresa
add constraint FK_servicio foreign key (ID_servicio) references GOQ.Servicio(serv_id),
	constraint FK_empresa foreign key (ID_empresa) references GOQ.Empresa(ID_empresa);
GO
alter table GOQ.Pago
add constraint FK_pago_fac_id foreign key (pago_fac_id) references GOQ.Factura(fac_id),
	constraint FK_empresa_id foreign key (pago_empresa_id) references GOQ.Empresa(ID_empresa),
	constraint FK_cliente_id foreign key (pago_cliente_id) references GOQ.Cliente(cli_id),
	constraint FK_tipo_id foreign key (pago_tipo_id) references GOQ.Tipo_Pago(tipo_pago_id),
	constraint FK_usuario_id foreign key (pago_usuario_id) references GOQ.Usuario(usu_id);
	
GO
alter table GOQ.Rendicion
add constraint FK_ren_empresa_id foreign key (ren_empresa_id) references GOQ.Empresa(ID_empresa),
 constraint FK_ren_porc_comision_id foreign key (ren_porc_comision_id) references GOQ.Porcentaje_Comision(porc_comi_id);

GO

alter table GOQ.Item
add constraint FK_fac_id foreign key (fac_id) references GOQ.Factura(fac_id);
 
GO

alter table GOQ.Factura
add constraint FK_fac_cli_id foreign key (fac_cli_id) references GOQ.Cliente(cli_id),
 constraint FK_fac_empresa_id foreign key (fac_empresa_id) references GOQ.Empresa(ID_empresa);

GO

alter table GOQ.RendicionFactura
add constraint FK_ren_id foreign key (ren_id) references GOQ.Rendicion(ren_id),
 constraint FK_ren_fac_id foreign key (ren_fac_id) references GOQ.Factura(fac_id);

GO

alter table GOQ.Devolucion
add constraint FK_dev_fac_id foreign key (dev_fac_id) references GOQ.Factura(fac_id);

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
/***************************** INICIO / CREACION DE STORED PROCEDURES Y VISTAS *****************************/
/***************************** FIN / CREACION DE STORED PROCEDURES Y VISTAS *****************************/

/******************************************** INICIO - LLENADO DE TABLAS *********************************************/

/*********************************CLIENTES*****************************/

update [gd_esquema].[Maestra] 
set
Cliente_Mail='pedirActualizarMail@mail.com'
where Cliente_Codigo_Postal=5081 and [Cliente-Dni]=31294365
;

update [gd_esquema].[Maestra] 
set
Cliente_Mail='pedirActualizarMail2@mail.com'
where Cliente_Codigo_Postal=8240 and [Cliente-Dni]=3703799
;

INSERT INTO [GOQ].[Cliente]
           ([cli_nombre]
           ,[cli_apellido]
           ,[cli_dni]
           ,[cli_mail]
           ,[cli_tel]
           ,[cli_dir]
           ,[cli_cp]
           ,[cli_habilitado]
           ,[cli_fecha_nac])
select distinct	m.[Cliente-Nombre],
			m.[Cliente-Apellido],
			m.[Cliente-Dni],
			m.Cliente_Mail,
			0000000000 as telefono,
			m.Cliente_Direccion,
			m.Cliente_Codigo_Postal,
			1,
			m.[Cliente-Fecha_Nac]  
from [gd_esquema].[Maestra] m ;
/***********************************************************************/

/***************************EMPRESA*************************************/
INSERT INTO [GOQ].[Empresa]
           ([empresa_cuit]
           ,[empresa_nombre]
           ,[empresa_dir]
           ,[empresa_habilitado])
select		distinct e.Empresa_Cuit,
			e.Empresa_Nombre ,
			e.Empresa_Direccion ,
			1 
from [gd_esquema].[Maestra] e;
/***********************************************************************/

/*************************FACTURA************************************/

INSERT INTO [GOQ].[Factura]
           ([fac_id]
           ,[fac_cli_id]
           ,[fac_empresa_id]
           ,[fac_fecha_alta]
           ,[fac_fecha_vec]
           ,[fac_total])
select		distinct f.Nro_Factura,
			c.cli_id ,
			em.empresa_id_empresa ,
			f.Factura_Fecha ,
			f.Factura_Fecha_Vencimiento ,
			f.Factura_Total 
from [gd_esquema].[Maestra] f
inner join [GOQ].[Cliente] c
on(c.cli_dni =f.[Cliente-Dni] )
inner join [GOQ].[Empresa] em
on(em.empresa_cuit =f.Empresa_Cuit);
/***********************************************************************/

/****************************SUCURSAL*********************************/
INSERT INTO [GOQ].[Sucursal]
           ([sucu_nombre]
           ,[sucu_dir]
           ,[sucu_cp]
           ,[sucu_habilitado])
select		distinct f.Sucursal_Nombre,
			f.Sucursal_Dirección ,
			f.Sucursal_Codigo_Postal ,
			1
from [gd_esquema].[Maestra] f
where Sucursal_Nombre is not null;
/***********************************************************************/











/******************************************** FIN - LLENADO DE TABLAS *********************************************/
/******************************************** INICIO - TRIGGERS *****************************************/
/******************************************** FIN - TRIGGERS *****************************************/

