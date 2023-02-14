

CREATE PROCEDURE [dbo].[PpalProveedorTelefono_Consultar]
@PPalProveedorTelefonoID int
-- Parámetros para Bitácora
	,@EmpresaIDSolicitudBase int = null
	,@UsuarioIDBitacora		 int
	,@DescripcionBitacora	 varchar(500)	= null
	,@IpAddress				 varchar(40)		= null
	,@HostName				 varchar(50)		= null
AS

SELECT  PpalProveedorTelefonoID,PpalProveedorID,EspTelefonoID,Predeterminado,Comentarios,CfgUsoTelefonoID
FROM    PpalProveedorTelefono
WHERE   PpalProveedorTelefonoID = @PPalProveedorTelefonoID