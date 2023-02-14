

CREATE PROCEDURE [dbo].[PpalRepresentanteProveedorDomicilio_Eliminar]
@ModificacionUsuarioID int = null,
@PpalRepresentanteProveedorDomicilioID int
AS

SET NOCOUNT ON 

DECLARE @Errores bit, @Mensaje nvarchar(300), @EliminarDomicilioID int
select @EliminarDomicilioID = EspDomicilioID  
from PpalRepresentanteProveedorDomicilio 
where PpalRepresentanteProveedorDomicilioID = @PpalRepresentanteProveedorDomicilioID

BEGIN TRANSACTION 
BEGIN TRY
    DELETE
    FROM    PpalRepresentanteProveedorDomicilio
    WHERE   PpalRepresentanteProveedorDomicilioID = @PpalRepresentanteProveedorDomicilioID
    
    COMMIT TRANSACTION
    SELECT @Errores = 0, @Mensaje = ''
END TRY
BEGIN CATCH 
    ROLLBACK TRANSACTION
    SELECT @Errores = 1, @Mensaje = ERROR_MESSAGE()
END CATCH 
exec [EspDomicilio_Eliminar]
		@EspDomicilioID			= @EliminarDomicilioID
		,@UsuarioIDBitacora		= @ModificacionUsuarioID
		,@DescripcionBitacora	= "null"
		,@IpAddress				= "null"
		,@HostName				= "null"
SELECT  COALESCE(@Errores, 0) as Errores, 
        COALESCE(@Mensaje, '') as Mensaje

SET NOCOUNT OFF