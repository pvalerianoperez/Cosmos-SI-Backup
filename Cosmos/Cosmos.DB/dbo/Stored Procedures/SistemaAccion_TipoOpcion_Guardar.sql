

CREATE PROCEDURE [SistemaAccion_TipoOpcion_Guardar]
@ModificacionUsuarioID int = null,
@AccionID int, 
@TipoOpcionID int
AS
SET NOCOUNT ON 
DECLARE @Errores bit, @Mensaje nvarchar(300)

BEGIN TRANSACTION 
BEGIN TRY
    INSERT  INTO SistemaTipoOpcionAccion (AccionID, TipoOpcionID)
    VALUES  (@AccionID, @TipoOpcionID)
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