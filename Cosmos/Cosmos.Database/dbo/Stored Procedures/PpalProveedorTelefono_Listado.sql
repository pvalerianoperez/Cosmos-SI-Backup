

CREATE PROCEDURE [dbo].[PpalProveedorTelefono_Listado]
@TipoListado varchar(10) = ''
-- Parámetros para Bitácora
	,@EmpresaIDSolicitudBase int = null
	,@UsuarioIDBitacora		int
	,@DescripcionBitacora	varchar(500)	= null
	,@IpAddress				varchar(40)		= null
	,@HostName				varchar(50)		= null
AS

SELECT  PpalProveedorTelefonoID,PpalProveedorID,EspTelefonoID,Predeterminado,Comentarios,CfgUsoTelefonoID
FROM    PpalProveedorTelefono