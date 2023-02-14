

CREATE PROCEDURE [dbo].[PpalProveedorTelefono_Eliminar]
@ModificacionUsuarioID int = null,
@PpalProveedorTelefonoID int
AS

SET NOCOUNT ON 

DECLARE @Errores bit, @Mensaje nvarchar(300), @EliminarTelefonoID int
select @EliminarTelefonoID = EspTelefonoID  from PpalProveedorTelefono where PpalProveedorTelefonoID = @PpalProveedorTelefonoID


BEGIN TRANSACTION 
BEGIN TRY
    DELETE
    FROM    PpalProveedorTelefono
    WHERE   PpalProveedorTelefonoID = @PpalProveedorTelefonoID
    
    COMMIT TRANSACTION
    SELECT @Errores = 0, @Mensaje = ''
END TRY
BEGIN CATCH 
    ROLLBACK TRANSACTION
    SELECT @Errores = 1, @Mensaje = ERROR_MESSAGE()
END CATCH 
EXEC [EspTelefono_Eliminar]
	@TelefonoID = @EliminarTelefonoID,
	@UsuarioIDBitacora = @PpalProveedorTelefonoID

SELECT  COALESCE(@Errores, 0) as Errores, 
        COALESCE(@Mensaje, '') as Mensaje

SET NOCOUNT OFF