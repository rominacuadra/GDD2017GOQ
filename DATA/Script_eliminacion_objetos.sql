USE [GD2C2017]
GO

/*******************************************
***** ELIMINAR TABLAS ***************** 
********************************************/


DROP TABLE GOQ.Funcionalidad_Rol
DROP TABLE GOQ.Funcionalidad
DROP TABLE GOQ.Rol_Usuario
DROP TABLE GOQ.Rol
DROP TABLE GOQ.CobradorSucursal
DROP TABLE GOQ.Sucursal
DROP TABLE GOQ.Pago
DROP TABLE GOQ.Usuario
DROP TABLE GOQ.Item 
DROP TABLE GOQ.RendicionFactura
DROP TABLE GOQ.Devolucion
DROP TABLE GOQ.Factura
DROP TABLE GOQ.Cliente
DROP TABLE GOQ.Servicio_Empresa
DROP TABLE GOQ.Rendicion
DROP TABLE GOQ.Empresa
DROP TABLE GOQ.Porcentaje_Comision
DROP TABLE GOQ.Servicio
DROP TABLE GOQ.Tipo_Pago
DROP TABLE GOQ.Pago_Factura


/*ELIMINAR FUNCIONES*/
DROP FUNCTION GOQ.F_Hash256
DROP FUNCTION GOQ.F_ObtenerPasswordGenerica

/*******************************************
***** ELIMINAR ESQUEMA ***************** 
********************************************/

DROP SCHEMA GOQ
