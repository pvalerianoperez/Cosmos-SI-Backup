

CREATE PROCEDURE Sistema_EstatusDocumento_Guardar
@ModificacionUsuarioID int = null,
@SistemaEstatusDocumentoID int,
@SistemaEstatusDocumentoClave varchar(4),
@Nombre varchar(30),
@NombreCorto varchar(10)
AS
SET NOCOUNT ON 

DECLARE @Errores bit, @Mensaje nvarchar(300)

BEGIN TRANSACTION 
BEGIN TRY
    IF EXISTS(SELECT SistemaEstatusDocumentoID FROM SistemaEstatusDocumento WHERE SistemaEstatusDocumentoID = @SistemaEstatusDocumentoID)
    BEGIN
        UPDATE  SistemaEstatusDocumento
        SET                     SistemaEstatusDocumentoClave = @SistemaEstatusDocumentoClave,
				Nombre = @Nombre,
				NombreCorto = @NombreCorto
        WHERE   SistemaEstatusDocumentoID = @SistemaEstatusDocumentoID
    END
    ELSE
    BEGIN        
        INSERT  INTO SistemaEstatusDocumento(
                SistemaEstatusDocumentoClave,
				Nombre,
				NombreCorto)
        VALUES  (
                @SistemaEstatusDocumentoClave,
				@Nombre,
				@NombreCorto)
        
        SET     @SistemaEstatusDocumentoID = SCOPE_IDENTITY()
    END
    COMMIT TRANSACTION
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION
    SELECT @Errores = 1, @Mensaje = ERROR_MESSAGE()
END CATCH 

SELECT  COALESCE(@Errores, 0) as Errores, 
        COALESCE(@Mensaje, '') as Mensaje,
        @SistemaEstatusDocumentoID as SistemaEstatusDocumentoID