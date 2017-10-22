USE GD2C2017;
GO
CREATE SCHEMA GOQ AUTHORIZATION gd 
GO

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
