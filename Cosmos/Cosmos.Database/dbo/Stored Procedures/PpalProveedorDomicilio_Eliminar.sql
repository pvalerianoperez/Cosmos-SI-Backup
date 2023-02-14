

CREATE PROCEDURE [dbo].[PpalProveedorDomicilio_Eliminar]
@PpalProveedorDomicilioID int
-- Parámetros para Bitácora
	,@UsuarioIDBitacora		int
	,@DescripcionBitacora	varchar(500)	= null
	,@IpAddress			varchar(40)		= null
	,@HostName			varchar(50)		= null
AS

SET NOCOUNT ON 

DECLARE @Errores bit, @Mensaje nvarchar(300),@EliminarDomicilioID int
select @EliminarDomicilioID = EspDomicilioID  from PpalProveedorDomicilio where PpalProveedorDomicilioID = @PpalProveedorDomicilioID

BEGIN TRANSACTION 
BEGIN TRY
    DELETE
    FROM    PpalProveedorDomicilio
    WHERE   PpalProveedorDomicilioID = @PpalProveedorDomicilioID
    
    COMMIT TRANSACTION
    SELECT @Errores = 0, @Mensaje = ''
	
END TRY
BEGIN CATCH 
    ROLLBACK TRANSACTION
    SELECT @Errores = 1, @Mensaje = ERROR_MESSAGE()
END CATCH 


SELECT  COALESCE(@Errores, 0) as Errores, 
        COALESCE(@Mensaje, '') as Mensaje

SET NOCOUNT OFF