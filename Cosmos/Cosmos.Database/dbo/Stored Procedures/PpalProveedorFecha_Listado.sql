

CREATE PROCEDURE [dbo].[PpalProveedorFecha_Listado]
@TipoListado varchar(10) = ''
-- Parámetros para Bitácora
	,@EmpresaIDSolicitudBase int = null
	,@UsuarioIDBitacora		int
	,@DescripcionBitacora	varchar(500)	= null
	,@IpAddress				varchar(40)		= null
	,@HostName				varchar(50)		= null
AS

SELECT  PpalProveedorFechaID,PpalProveedorID,Fecha,CfgTipoFechaID,Comentarios,Predeterminado
FROM    PpalProveedorFecha