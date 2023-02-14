

CREATE PROCEDURE [dbo].[PpalProveedorFecha_Consultar]
@PpalProveedorFechaID int
-- Parámetros para Bitácora
	,@UsuarioIDBitacora		int
	,@DescripcionBitacora	varchar(500)	= null
	,@IpAddress				varchar(40)		= null
	,@HostName				varchar(50)		= null
AS

SELECT  PpalProveedorFechaID,PpalProveedorID,Fecha,CfgTipoFechaID,Comentarios
FROM    PpalProveedorFecha
WHERE   PpalProveedorFechaID = @PpalProveedorFechaID