

CREATE PROCEDURE Sistema_EstatusTipoDocumento_Guardar
@ModificacionUsuarioID int = null,
@SistemaEstatusTipoDocumentoID int,
@SistemaEstatusDocumentoID int,
@TipoDocumentoID int
AS
SET NOCOUNT ON 

DECLARE @Errores bit, @Mensaje nvarchar(300)

BEGIN TRANSACTION 
BEGIN TRY
    IF EXISTS(SELECT SistemaEstatusTipoDocumentoID FROM SistemaEstatusTipoDocumento WHERE SistemaEstatusTipoDocumentoID = @SistemaEstatusTipoDocumentoID)
    BEGIN
        UPDATE  SistemaEstatusTipoDocumento
        SET                     SistemaEstatusDocumentoID = @SistemaEstatusDocumentoID,
				TipoDocumentoID = @TipoDocumentoID
        WHERE   SistemaEstatusTipoDocumentoID = @SistemaEstatusTipoDocumentoID
    END
    ELSE
    BEGIN        
        INSERT  INTO SistemaEstatusTipoDocumento(
                SistemaEstatusDocumentoID,
				TipoDocumentoID)
        VALUES  (
                @SistemaEstatusDocumentoID,
				@TipoDocumentoID)
        
        SET     @SistemaEstatusTipoDocumentoID = SCOPE_IDENTITY()
    END
    COMMIT TRANSACTION
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION
    SELECT @Errores = 1, @Mensaje = ERROR_MESSAGE()
END CATCH 

SELECT  COALESCE(@Errores, 0) as Errores, 
        COALESCE(@Mensaje, '') as Mensaje,
        @SistemaEstatusTipoDocumentoID as SistemaEstatusTipoDocumentoID