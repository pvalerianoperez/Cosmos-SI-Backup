

CREATE PROCEDURE [dbo].[PpalProveedorDomicilio_Consultar]
@PpalProveedorDomicilioID int
-- Parámetros para Bitácora
	,@UsuarioIDBitacora		int
	,@DescripcionBitacora	varchar(500)	= null
	,@IpAddress				varchar(40)		= null
	,@HostName				varchar(50)		= null
AS


SELECT  PpalProveedorDomicilioID,PpalProveedorID,EspDomicilioID,Comentario, Predeterminado
FROM    PpalProveedorDomicilio
WHERE   PpalProveedorDomicilioID = @PpalProveedorDomicilioID