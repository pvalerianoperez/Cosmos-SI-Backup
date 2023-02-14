

CREATE PROCEDURE [dbo].[PpalProveedorDomicilio_Listado]
@TipoListado varchar(10) = ''
-- Parámetros para Bitácora
	,@EmpresaIDSolicitudBase int = null
	,@UsuarioIDBitacora		int
	,@DescripcionBitacora	varchar(500)	= null
	,@IpAddress				varchar(40)		= null
	,@HostName				varchar(50)		= null
AS

SELECT  PpalProveedorDomicilioID,PpalProveedorID,EspDomicilioID,Comentario,Predeterminado,CfgTipoDomicilioID
FROM    PpalProveedorDomicilio