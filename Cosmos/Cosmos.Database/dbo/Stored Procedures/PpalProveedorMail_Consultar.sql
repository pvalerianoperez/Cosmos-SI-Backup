

CREATE PROCEDURE [dbo].[PpalProveedorMail_Consultar]
@PpalProveedorMailID int
-- Parámetros para Bitácora
	,@UsuarioIDBitacora		int
	,@DescripcionBitacora	varchar(500)	= null
	,@IpAddress				varchar(40)		= null
	,@HostName				varchar(50)		= null
AS

SELECT  PpalProveedorMailID,PpalProveedorID,CfgTipoMailID,Mail,Predeterminado,Comentarios
FROM    PpalProveedorMail
WHERE   PpalProveedorMailID = @PpalProveedorMailID