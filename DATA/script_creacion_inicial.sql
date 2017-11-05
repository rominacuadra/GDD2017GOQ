USE GD2C2017;
/*
GO
IF EXISTS (SELECT name FROM sys.schemas where name = 'GOQ')

	BEGIN
		DROP FUNCTION GOQ.F_Hash256
		DROP PROCEDURE GOQ.SP_Insertar_Servicio_Empresa
		DROP TABLE GOQ.CobradorSucursal
		DROP TABLE GOQ.Devolucion
		DROP TABLE GOQ.Funcionalidad_Rol
		DROP TABLE GOQ.Funcionalidad
		DROP TABLE GOQ.Item
		DROP TABLE GOQ.Rol_Usuario
		DROP TABLE GOQ.Rol
		DROP TABLE GOQ.Servicio_Empresa
		DROP TABLE GOQ.Servicio
		DROP TABLE GOQ.Pago_Factura
		DROP TABLE GOQ.Sucursal
		DROP TABLE GOQ.Pago
	
		DROP TABLE GOQ.Factura
		DROP TABLE GOQ.Cliente
		DROP TABLE GOQ.Rendicion
		DROP TABLE GOQ.Empresa
		DROP TABLE GOQ.Porcentaje_Comision
		DROP TABLE GOQ.Tipo_Pago
		DROP TABLE GOQ.Usuario
		DROP SCHEMA GOQ

	END
	*/
GO
CREATE SCHEMA GOQ AUTHORIZATION gd 


/********************************************* FIN - CREACION ESQUEMA **********************************************/

/******************************************** INICIO - CREACION DE TABLAS ******************************************/
GO
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
	pago_id numeric(18,0) CONSTRAINT PK_pago_id PRIMARY KEY IDENTITY(1,1),
	pago_fecha_cobro datetime not null,
	pago_cliente_id int, /* FK a GOQ.Cliente*/
	pago_importe numeric(18,0) not null CHECK(pago_importe>0),
	pago_tipo_id int , /* FK a GOQ.Tipo_Pago*/
	pago_sucursal_id int /* FK a GOQ.Sucursal*/
);

GO
create table GOQ.Rendicion(
	ren_id numeric(18,0) CONSTRAINT PK_ren_id PRIMARY KEY IDENTITY(34620,1),
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
	 fac_total numeric(18,2) not null,
	 fac_ren_id numeric(18,0) null
);

GO
create table GOQ.Item(
	numeroItem int CONSTRAINT PK_numeroItem_id PRIMARY KEY IDENTITY(1,1),
	fac_id numeric(18,0),  /*FK GOQ.Factura*/
	Monto numeric(18,2) not null,
	Cantidad numeric(18,0) not null
);

GO
create table GOQ.Pago_Factura(
	pago_fac_pago_id numeric(18,0), /* FK  GOQ.Pago */
	pago_fac_fac_id numeric(18,0), /* FK  GOQ.Factura */
	CONSTRAINT PK_pago_factura PRIMARY KEY (pago_fac_pago_id, pago_fac_fac_id)
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
add constraint FK_cliente_id foreign key (pago_cliente_id) references GOQ.Cliente(cli_id),
	constraint FK_tipo_id foreign key (pago_tipo_id) references GOQ.Tipo_Pago(tipo_pago_id),
	constraint FK_sucursal_id foreign key (pago_sucursal_id) references GOQ.Sucursal(sucu_id);
	
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
	constraint FK_fac_ren_id foreign key (fac_ren_id) references GOQ.Rendicion(ren_id),
    constraint FK_fac_empresa_id foreign key (fac_empresa_id) references GOQ.Empresa(ID_empresa);

GO

alter table GOQ.Pago_Factura
add constraint FK_pago_fac_pago_id foreign key (pago_fac_pago_id) references GOQ.Pago(pago_id),
	constraint FK_pago_fac_fac_id foreign key (pago_fac_fac_id) references GOQ.Factura(fac_id);

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

/*************************************** FIN / CREACION - FUNCIONES ***************************************/
/***************************** INICIO / CREACION DE STORED PROCEDURES Y VISTAS *****************************/

CREATE PROCEDURE GOQ.SP_Insertar_Servicio_Empresa
	@idServicio int
AS
BEGIN TRAN
	declare @idEmpresaInsertado int
	SET @idEmpresaInsertado = @@IDENTITY
	INSERT INTO [GOQ].Servicio_Empresa (ID_servicio,ID_empresa) VALUES (@idServicio,@idEmpresaInsertado);
	
	if @@ERROR <> 0 
		BEGIN 
			rollback tran
		END
COMMIT TRAN;

GO
CREATE PROCEDURE GOQ.SP_Insertar_Item	
	@monto numeric(18,2),	
	@cantidad numeric(18,0)
AS
BEGIN TRAN	declare @idFacturaInsertado int

	SET @idFacturaInsertado = @@IDENTITY
	INSERT INTO [GOQ].Item(fac_id,Monto,Cantidad) VALUES (@idFacturaInsertado,@monto,@cantidad);
	
	if @@ERROR <> 0 		
		BEGIN 			
			rollback tran		
		END
COMMIT TRAN;

GO
/***************************** FIN / CREACION DE STORED PROCEDURES Y VISTAS *****************************/

/******************************************** INICIO - LLENADO DE TABLAS *********************************************/

/*****************************ROL******************************************/

INSERT INTO [GOQ].[Rol] ([rol_nombre])
VALUES ('Administrador'), ('Cobrador');

/*************************FUNCIONALIDAD*********************************/

GO
INSERT INTO [GOQ].[FUNCIONALIDAD] ([fun_nombre])
VALUES  ('ABM de Rol'),('ABM de Cliente'), ('ABM de Empresa'),
		('ABM de Sucursal'), ('ABM de Factura'),('Registro de Pago de Facturas'), ('Rendición de facturas cobradas'),
		('Devoluciones'), ('Listado Estadístico');

/**********************FUNCIONALIDAD-ROL*******************************/

GO	
INSERT INTO [GOQ].[Funcionalidad_Rol] ([fun_rol_fun_id], [fun_rol_rol_id])
VALUES (1,1),(2,1),(3,1),(4,1),(5,1),(6,2),(6,1),(7,1),(8,1),(9,1);

/**********************USUARIO*******************************/

GO
INSERT INTO [GOQ].[Usuario] (Usu_Username,Usu_Password,usu_intentos,usu_habilitado)
VALUES ('admin', GOQ.F_Hash256('w23e'),0,1);
GO
INSERT INTO [GOQ].[Usuario] (Usu_Username,Usu_Password,usu_intentos,usu_habilitado)
VALUES ('Leandro', GOQ.F_Hash256('Leandro'),0,1);
GO
INSERT INTO [GOQ].[Usuario] (Usu_Username,Usu_Password,usu_intentos,usu_habilitado)
VALUES ('Maru', GOQ.F_Hash256('Maru'),0,1);
GO
INSERT INTO [GOQ].[Usuario] (Usu_Username,Usu_Password,usu_intentos,usu_habilitado)
VALUES ('RominaCA', GOQ.F_Hash256('RominaCA'),0,1);
GO
INSERT INTO [GOQ].[Usuario] (Usu_Username,Usu_Password,usu_intentos,usu_habilitado)
VALUES ('RominaCU', GOQ.F_Hash256('RominaCU'),0,1);

/****************************ROL_USUARIO*********************************/
GO
INSERT INTO [GOQ].[Rol_Usuario] ([rol_usu_rol_id], [rol_usu_usu_id])
VALUES (1, 1), (2, 2), (2, 3), (2, 4), (2, 5);

/****************************SUCURSAL*********************************/
GO
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

/******************************COBRADORSUCURSAL*****************************************/
GO
INSERT INTO [GOQ].[CobradorSucursal] ([usu_id],[sucu_id])
select U.usu_id, S.sucu_id 
from  [GOQ].[Sucursal] S, [GOQ].[Usuario] U
where U.usu_id != 1;

/*********************************CLIENTE*****************************/
GO
create table GOQ.MailsRepetidos(
	cli_nombre nvarchar(255) not null,
	cli_apellido nvarchar(255) not null,
	cli_dni numeric(18,0) not null,
	cli_mail nvarchar(255) not null,
	cli_tel numeric(18,0) not null,
	cli_dir nvarchar(255) not null,
	cli_cp nvarchar(255) not null,
	cli_habilitado bit DEFAULT 1,
	cli_fecha_nac datetime not null
)

GO
INSERT INTO GOQ.MailsRepetidos
           ([cli_nombre]
           ,[cli_apellido]
           ,[cli_dni]
           ,[cli_mail]
           ,[cli_tel]
           ,[cli_dir]
           ,[cli_cp]
           ,[cli_fecha_nac])
select distinct	m.[Cliente-Nombre],
			m.[Cliente-Apellido],
			m.[Cliente-Dni],
			m.Cliente_Mail,
			0000000000 as telefono,
			m.Cliente_Direccion,
			m.Cliente_Codigo_Postal,
			m.[Cliente-Fecha_Nac]  
from [gd_esquema].[Maestra] m

GO
update GOQ.MailsRepetidos 
set
cli_mail='pedirActualizarMail1@mail.com'
where cli_dni=31294365
GO
update GOQ.MailsRepetidos 
set
cli_mail='pedirActualizarMail2@mail.com'
where cli_dni = 3703799

GO
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
select distinct	m.[cli_nombre],
			m.[cli_apellido],
			m.[cli_dni],
			m.[cli_mail],
			0000000000 as telefono,
			m.[cli_dir],
			m.[cli_cp],
			1,
			m.[cli_fecha_nac]  
from GOQ.MailsRepetidos m
GO
drop table GOQ.MailsRepetidos

/***************************EMPRESA*************************************/
GO
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

/************************* FACTURA ************************************/
GO
INSERT INTO [GOQ].[Factura]
           ([fac_id]
           ,[fac_cli_id]
           ,[fac_empresa_id]
           ,[fac_fecha_alta]
           ,[fac_fecha_vec]
           ,[fac_total])
select		distinct f.Nro_Factura,
			c.cli_id ,
			em.ID_empresa ,
			f.Factura_Fecha ,
			f.Factura_Fecha_Vencimiento ,
			f.Factura_Total 
from [gd_esquema].[Maestra] f
inner join [GOQ].[Cliente] c
on(c.cli_dni =f.[Cliente-Dni] )
inner join [GOQ].[Empresa] em
on(em.empresa_cuit =f.Empresa_Cuit);

/****************************ITEM*********************************/
GO
INSERT INTO [GOQ].[Item]
           ([fac_id]
           ,[Monto]
           ,[Cantidad])
select i.Nro_Factura,
	i.ItemFactura_Monto,
	i.ItemFactura_Cantidad 
from [gd_esquema].[Maestra] i
where i.Nro_Factura is not null
group by i.Nro_Factura,
	i.ItemFactura_Monto,
	i.ItemFactura_Cantidad 
order by i.Nro_Factura,i.ItemFactura_Monto,
	i.ItemFactura_Cantidad;

/**********************SERVICIO*******************************/
GO
INSERT INTO [GOQ].[Servicio] (serv_descripcion)
select distinct Rubro_Descripcion from [gd_esquema].[Maestra];

/*******************SERVICIO_EMPRESA ********************************/
GO	
INSERT INTO [GOQ].[Servicio_Empresa] ([ID_servicio],[ID_empresa])
SELECT DISTINCT serv_id, ID_empresa 
from [gd_esquema].[Maestra] m
INNER JOIN [GOQ].Servicio s
on (m.Rubro_Descripcion = s.serv_descripcion)
INNER JOIN [GOQ].Empresa e
on(m.Empresa_Cuit = e.empresa_cuit);

/****************************TIPO_PAGO*********************************/
GO
INSERT INTO [GOQ].[Tipo_Pago]
           ([tipo_pago_descripcion])
select distinct t.FormaPagoDescripcion
from [gd_esquema].[Maestra] t
where t.FormaPagoDescripcion is not null;

/******************************PAGO*****************************************/
GO
INSERT INTO [GOQ].[Pago]
           ([pago_fecha_cobro]
           ,[pago_cliente_id]
           ,[pago_importe]
           ,[pago_tipo_id]
           ,[pago_sucursal_id]
           ,[pago_ren_id])
select distinct p.Pago_Fecha, 
				c.cli_id, 
				p.Total, 
				tp.tipo_pago_id,
				1
				,p.Rendicion_Nro
from [gd_esquema].[Maestra] p
inner join [GOQ].[Empresa] e on (e.empresa_cuit = p.Empresa_Cuit)
inner join [GOQ].[Cliente] c on (c.cli_dni = p.[Cliente-Dni])
inner join [GOQ].[Tipo_Pago] tp on (tp.tipo_pago_descripcion  = p.FormaPagoDescripcion)
where p.Rendicion_Nro is not null
order by 1 asc; 

INSERT INTO [GOQ].[Pago]
           ([pago_fecha_cobro]
           ,[pago_cliente_id]
           ,[pago_importe]
           ,[pago_tipo_id]
           ,[pago_sucursal_id]
           ,[pago_ren_id])
select distinct p.Pago_Fecha, 
				c.cli_id, 
				p.Total, 
				tp.tipo_pago_id,
				1
				,p.Rendicion_Nro
from [gd_esquema].[Maestra] p
inner join [GOQ].[Empresa] e on (e.empresa_cuit = p.Empresa_Cuit)
inner join [GOQ].[Cliente] c on (c.cli_dni = p.[Cliente-Dni])
inner join [GOQ].[Tipo_Pago] tp on (tp.tipo_pago_descripcion  = p.FormaPagoDescripcion)
where p.Rendicion_Nro is null
and p.Pago_nro not in (select distinct pago_id from [GOQ].[Pago])
order by 1 asc; 

/******************************PAGO_FACTURA*****************************************/
GO
INSERT INTO [GOQ].[Pago_Factura](pago_fac_pago_id, pago_fac_fac_id)
SELECT P.pago_id, F.fac_id
FROM GOQ.Pago P, gd_esquema.Maestra M 
JOIN GOQ.Factura F ON (M.Nro_Factura = F.fac_id)
WHERE P.pago_id = M.Pago_nro
GROUP BY P.pago_id, F.fac_id
ORDER BY P.pago_id, F.fac_id;

/****************************PORCENTAJE_COMISION*********************************/
GO
INSERT INTO [GOQ].[Porcentaje_Comision]
           ([porc_periodo])
VALUES (2), (3), (5), (10);

/******************* RENDICION ****************************/	
GO	
INSERT INTO [GOQ].Rendicion (
		[ren_fecha_ren]
       ,[ren_cant_fac]
       ,[ren_imp_comision]
       ,[ren_empresa_id]
       ,[ren_porc_comision_id]
       ,[ren_imp_total])
SELECT m.Rendicion_Fecha,
	   COUNT(m.Nro_Factura) as ren_cant_fac,
	   SUM(m.ItemRendicion_Importe) as ren_imp_comision,
	   e.ID_empresa, 
	   pc.porc_comi_id, 
	   SUM(m.Total)
FROM [gd_esquema].[Maestra] m
inner join [GOQ].[Empresa] e on (e.empresa_cuit = m.Empresa_Cuit)
inner join [GOQ].[Porcentaje_Comision] pc on ( pc.porc_periodo  = ((m.ItemRendicion_Importe * 100) / m.Total) ) 
WHERE Rendicion_Nro is not null
group by m.Rendicion_Nro, m.Rendicion_Fecha,e.ID_empresa,pc.porc_comi_id;

/*******************DEVOLUCION*******--NO HAY NADA PARA MIGRAR*************************/	

/******************************************** FIN - LLENADO DE TABLAS *********************************************/
