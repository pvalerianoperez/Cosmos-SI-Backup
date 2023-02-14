

CREATE PROCEDURE [dbo].[PpalRepresentanteProveedorMail_Guardar]
@ModificacionUsuarioID int = null,
@PpalRepresentanteProveedorMailID int,
@PpalRepresentanteProveedorID int,
@Mail nvarchar(90),
@TipoMailID int,
@Predeterminado bit,
@Comentarios varchar(20)
AS
SET NOCOUNT ON 

DECLARE @Errores bit, @Mensaje nvarchar(300)

BEGIN TRANSACTION 
BEGIN TRY
    IF EXISTS(SELECT PpalRepresentanteProveedorMailID FROM PpalRepresentanteProveedorMail WHERE PpalRepresentanteProveedorMailID = @PpalRepresentanteProveedorMailID)
    BEGIN
        UPDATE  PpalRepresentanteProveedorMail
        SET     
               
                PpalRepresentanteProveedorID = @PpalRepresentanteProveedorID,
				Mail = @Mail,
				CfgTipoMailID = @TipoMailID,
				Predeterminado = @Predeterminado,
				Comentarios = @Comentarios
        WHERE   PpalRepresentanteProveedorMailID = @PpalRepresentanteProveedorMailID
    END
    ELSE
    BEGIN        
        INSERT  INTO PpalRepresentanteProveedorMail(
                
                PpalRepresentanteProveedorID,
				Mail,
				CfgTipoMailID,
				Predeterminado,
				Comentarios)
        VALUES  (
                
                @PpalRepresentanteProveedorID,
				@Mail,
				@TipoMailID,
				@Predeterminado,
				@Comentarios)
        
        SET     @PpalRepresentanteProveedorMailID = SCOPE_IDENTITY()
    END
    COMMIT TRANSACTION
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION
    SELECT @Errores = 1, @Mensaje = ERROR_MESSAGE()
END CATCH 

SELECT  COALESCE(@Errores, 0) as Errores, 
        COALESCE(@Mensaje, '') as Mensaje,
        @PpalRepresentanteProveedorMailID as PpalRepresentanteProveedorMailID