

CREATE PROCEDURE [dbo].[PpalRepresentanteProveedorTelefono_Eliminar]
@ModificacionUsuarioID int = null,
@PpalRepresentanteProveedorTelefonoID int
AS

SET NOCOUNT ON 

DECLARE @Errores bit, @Mensaje nvarchar(300), @EliminarTelefonoID int
SELECT @EliminarTelefonoID = EspTelefonoID FROM PpalRepresentanteProveedorTelefono WHERE PpalRepresentanteProveedorID = @PpalRepresentanteProveedorTelefonoID
BEGIN TRANSACTION 
BEGIN TRY
    DELETE
    FROM    PpalRepresentanteProveedorTelefono
    WHERE   PpalRepresentanteProveedorTelefonoID = @PpalRepresentanteProveedorTelefonoID
    
    COMMIT TRANSACTION
    SELECT @Errores = 0, @Mensaje = ''
END TRY
BEGIN CATCH 
    ROLLBACK TRANSACTION
    SELECT @Errores = 1, @Mensaje = ERROR_MESSAGE()
END CATCH 
exec [EspTelefono_Eliminar]
		@TelefonoID = @EliminarTelefonoID,
		@UsuarioIDBitacora = null
SELECT  COALESCE(@Errores, 0) as Errores, 
        COALESCE(@Mensaje, '') as Mensaje

SET NOCOUNT OFF