

CREATE PROCEDURE Sistema_EstatusProducto_Guardar
@ModificacionUsuarioID int = null,
@EstatusProductoID int,
@EstatusProductoClave varchar(4),
@Nombre varchar(25),
@NombreCorto varchar(8)
AS
SET NOCOUNT ON 

DECLARE @Errores bit, @Mensaje nvarchar(300)

BEGIN TRANSACTION 
BEGIN TRY
    IF EXISTS(SELECT EstatusProductoID FROM SistemaEstatusProducto WHERE EstatusProductoID = @EstatusProductoID)
    BEGIN
        UPDATE  SistemaEstatusProducto
        SET                     EstatusProductoClave = @EstatusProductoClave,
				Nombre = @Nombre,
				NombreCorto = @NombreCorto
        WHERE   EstatusProductoID = @EstatusProductoID
    END
    ELSE
    BEGIN        
        INSERT  INTO SistemaEstatusProducto(
                EstatusProductoClave,
				Nombre,
				NombreCorto)
        VALUES  (
                @EstatusProductoClave,
				@Nombre,
				@NombreCorto)
        
        SET     @EstatusProductoID = SCOPE_IDENTITY()
    END
    COMMIT TRANSACTION
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION
    SELECT @Errores = 1, @Mensaje = ERROR_MESSAGE()
END CATCH 

SELECT  COALESCE(@Errores, 0) as Errores, 
        COALESCE(@Mensaje, '') as Mensaje,
        @EstatusProductoID as EstatusProductoID