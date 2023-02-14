

CREATE PROCEDURE [dbo].[PpalRepresentanteProveedorFecha_Eliminar]
@ModificacionUsuarioID int = null,
@PpalRepresentanteProveedorFechaID int
AS

SET NOCOUNT ON 

DECLARE @Errores bit, @Mensaje nvarchar(300)

BEGIN TRANSACTION 
BEGIN TRY
    DELETE
    FROM    PpalRepresentanteProveedorFecha
    WHERE   PpalRepresentanteProveedorFechaID = @PpalRepresentanteProveedorFechaID
    
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