

CREATE PROCEDURE Compras_CompraDetalle_Guardar
@ModificacionUsuarioID int = null,
@CompraDetalleID int,
@CompraEncabezadoID int,
@RenglonID int,
@ProductoID int,
@Cantidad float,
@UnidadID int,
@Costo float
AS
SET NOCOUNT ON 

DECLARE @Errores bit, @Mensaje nvarchar(300)

BEGIN TRANSACTION 
BEGIN TRY
    IF EXISTS(SELECT CompraDetalleID FROM CompraDetalle WHERE CompraDetalleID = @CompraDetalleID)
    BEGIN
        UPDATE  CompraDetalle
        SET     
                ModificacionUsuarioID = @ModificacionUsuarioID, 
                ModificacionFecha = GETDATE(),
                CompraEncabezadoID = @CompraEncabezadoID,
				RenglonID = @RenglonID,
				ProductoID = @ProductoID,
				Cantidad = @Cantidad,
				UnidadID = @UnidadID,
				Costo = @Costo
        WHERE   CompraDetalleID = @CompraDetalleID
    END
    ELSE
    BEGIN        
        INSERT  INTO CompraDetalle(
                AltaUsuarioID,
                AltaFecha,
                CompraEncabezadoID,
				RenglonID,
				ProductoID,
				Cantidad,
				UnidadID,
				Costo)
        VALUES  (
                @ModificacionUsuarioID,
                GETDATE(),
                @CompraEncabezadoID,
				@RenglonID,
				@ProductoID,
				@Cantidad,
				@UnidadID,
				@Costo)
        
        SET     @CompraDetalleID = SCOPE_IDENTITY()
    END
    COMMIT TRANSACTION
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION
    SELECT @Errores = 1, @Mensaje = ERROR_MESSAGE()
END CATCH 

SELECT  COALESCE(@Errores, 0) as Errores, 
        COALESCE(@Mensaje, '') as Mensaje,
        @CompraDetalleID as CompraDetalleID