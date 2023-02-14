

CREATE PROCEDURE [dbo].[PpalRepresentanteProveedor_Eliminar]
@ModificacionUsuarioID int = null,
@PpalRepresentanteProveedorID int
AS

SET NOCOUNT ON 

DECLARE @Errores bit, @Mensaje nvarchar(300),@EliminarPersonaID int 
SELECT @EliminarPersonaID = EspPersonaID FROM PpalRepresentanteProveedor WHERE PpalRepresentanteProveedorID = @PpalRepresentanteProveedorID

BEGIN TRANSACTION 
BEGIN TRY
    DELETE
    FROM    PpalRepresentanteProveedor
    WHERE   PpalRepresentanteProveedorID = @PpalRepresentanteProveedorID
    
    COMMIT TRANSACTION
    SELECT @Errores = 0, @Mensaje = ''
END TRY
BEGIN CATCH 
    ROLLBACK TRANSACTION
    SELECT @Errores = 1, @Mensaje = ERROR_MESSAGE()
END CATCH 

EXEC [EspPersona_Eliminar]
	@EspPersonaID = @EliminarPersonaID
	,@UsuarioIDBitacora	= @PpalRepresentanteProveedorID
	,@DescripcionBitacora		= null
	,@IpAddress			= null
	,@HostName			= null

SELECT  COALESCE(@Errores, 0) as Errores, 
        COALESCE(@Mensaje, '') as Mensaje

SET NOCOUNT OFF