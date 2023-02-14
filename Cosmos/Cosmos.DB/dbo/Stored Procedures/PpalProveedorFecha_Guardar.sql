

CREATE PROCEDURE [dbo].[PpalProveedorFecha_Guardar]
@ModificacionUsuarioID int = null,
@PpalProveedorFechaID int,
@PpalProveedorID int,
@Fecha date,
@TipoFechaID int,
@Comentarios varchar(100),
@Predeterminado bit

AS

DECLARE @Errores bit, @Mensaje nvarchar(300)

BEGIN TRANSACTION 
BEGIN TRY
    IF EXISTS(SELECT PpalProveedorFechaID FROM PpalProveedorFecha WHERE PpalProveedorFechaID = @PpalProveedorFechaID)
    BEGIN
        UPDATE  PpalProveedorFecha
        SET     
               PpalProveedorID = @PpalProveedorID,
			   Fecha = @Fecha,
			   CfgTipoFechaID = @TipoFechaID,
			   Comentarios = @Comentarios,
			   Predeterminado = @Predeterminado
        WHERE  PpalProveedorFechaID = @PpalProveedorFechaID
    END
    ELSE
    BEGIN        
        INSERT  INTO PpalProveedorFecha(
               
                PpalProveedorID,
				Fecha,
				CfgTipoFechaID,
				Comentarios,
				Predeterminado)
        VALUES  (
               @PpalProveedorID,
			   @Fecha,
			   @TipoFechaID,
			   @Comentarios,
			   @Predeterminado)
        
        SET     @PpalProveedorFechaID = SCOPE_IDENTITY()
    END
    COMMIT TRANSACTION
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION
    SELECT @Errores = 1, @Mensaje = ERROR_MESSAGE()
END CATCH 

SELECT  COALESCE(@Errores, 0) as Errores, 
        COALESCE(@Mensaje, '') as Mensaje,
        @PpalProveedorFechaID as PpalProveedorFechaID