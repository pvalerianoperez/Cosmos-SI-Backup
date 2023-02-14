

CREATE PROCEDURE [dbo].[PpalRepresentanteProveedorFecha_Guardar]
@ModificacionUsuarioID int = null,
@PpalRepresentanteProveedorFechaID int,
@PpalRepresentanteProveedorID int,
@Fecha date,
@TipoFechaID int,
@Comentarios varchar(100),
@Predeterminado bit

AS

DECLARE @Errores bit, @Mensaje nvarchar(300)

BEGIN TRANSACTION 
BEGIN TRY
    IF EXISTS(SELECT PpalRepresentanteProveedorFechaID FROM PpalRepresentanteProveedorFecha WHERE PpalRepresentanteProveedorFechaID = @PpalRepresentanteProveedorFechaID)
    BEGIN
        UPDATE  PpalRepresentanteProveedorFecha
        SET     
               PpalRepresentanteProveedorID = @PpalRepresentanteProveedorID,
			   Fecha = @Fecha,
			   CfgTipoFechaID = @TipoFechaID,
			   Comentarios = @Comentarios,
			   Predeterminado = @Predeterminado
        WHERE  PpalRepresentanteProveedorFechaID = @PpalRepresentanteProveedorFechaID
    END
    ELSE
    BEGIN        
        INSERT  INTO PpalRepresentanteProveedorFecha(
               
                PpalRepresentanteProveedorID,
				Fecha,
				CfgTipoFechaID,
				Comentarios,
				Predeterminado)
        VALUES  (
               @PpalRepresentanteProveedorID,
			   @Fecha,
			   @TipoFechaID,
			   @Comentarios,
			   @Predeterminado)
        
        SET     @PpalRepresentanteProveedorFechaID = SCOPE_IDENTITY()
    END
    COMMIT TRANSACTION
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION
    SELECT @Errores = 1, @Mensaje = ERROR_MESSAGE()
END CATCH 

SELECT  COALESCE(@Errores, 0) as Errores, 
        COALESCE(@Mensaje, '') as Mensaje,
        @PpalRepresentanteProveedorFechaID as PpalRepresentanteProveedorFechaID