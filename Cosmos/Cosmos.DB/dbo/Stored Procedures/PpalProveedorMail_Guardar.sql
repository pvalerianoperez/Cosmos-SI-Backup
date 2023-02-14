

CREATE PROCEDURE [dbo].[PpalProveedorMail_Guardar]
@ModificacionUsuarioID int = null,
@PpalProveedorMailID int,
@PpalProveedorID int,
@TipoMailID int,
@Mail varchar(90),
@Predeterminado bit,
@Comentarios varchar(30)
AS
SET NOCOUNT ON 

DECLARE @Errores bit, @Mensaje nvarchar(300)

BEGIN TRANSACTION 
BEGIN TRY
    IF EXISTS(SELECT PpalProveedorMailID FROM PpalProveedorMail WHERE PpalProveedorMailID = @PpalProveedorMailID)
    BEGIN
        UPDATE  PpalProveedorMail
        SET     
               
                PpalProveedorID = @PpalProveedorID,
				CfgTipoMailID = @TipoMailID,
				Mail = @Mail,
				Predeterminado = @Predeterminado,
				Comentarios = @Comentarios
        WHERE   PpalProveedorMailID = @PpalProveedorMailID
    END
    ELSE
    BEGIN        
        INSERT  INTO PpalProveedorMail(
               
                PpalProveedorID,
				CfgTipoMailID,
				Mail,
				Predeterminado,
				Comentarios)
        VALUES  (
               
                @PpalProveedorID,
				@TipoMailID,
				@Mail,
				@Predeterminado,
				@Comentarios)
        
        SET     @PpalProveedorMailID = SCOPE_IDENTITY()
    END
    COMMIT TRANSACTION
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION
    SELECT @Errores = 1, @Mensaje = ERROR_MESSAGE()
END CATCH 

SELECT  COALESCE(@Errores, 0) as Errores, 
        COALESCE(@Mensaje, '') as Mensaje,
        @PpalProveedorMailID as PpalProveedorMailID