

CREATE PROCEDURE [dbo].[PpalRepresentanteProveedorFecha_Listado]
AS

SELECT  PpalRepresentanteProveedorFechaID,PpalRepresentanteProveedorID,Fecha,CfgTipoFechaID,Comentarios,Predeterminado
FROM    PpalRepresentanteProveedorFecha