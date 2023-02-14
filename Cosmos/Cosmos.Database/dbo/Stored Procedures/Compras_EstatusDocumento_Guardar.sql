

CREATE PROCEDURE Compras_EstatusDocumento_Guardar
@ModificacionUsuarioID int = null,
@EstatusDocumentoID int,
@EstatusDocumentoClave varchar(8),
@Nombre varchar(40),
@NombreCorto varchar(10),
@SistemaEstatusTipoDocumentoID int,
@Predeterminado bit
AS
SET NOCOUNT ON 

DECLARE @Errores bit, @Mensaje nvarchar(300)

BEGIN TRANSACTION 
BEGIN TRY
    IF EXISTS(SELECT EstatusDocumentoID FROM EstatusDocumento WHERE EstatusDocumentoID = @EstatusDocumentoID)
    BEGIN
        UPDATE  EstatusDocumento
        SET     
                ModificacionUsuarioID = @ModificacionUsuarioID, 
                ModificacionFecha = GETDATE(),
                EstatusDocumentoClave = @EstatusDocumentoClave,
				Nombre = @Nombre,
				NombreCorto = @NombreCorto,
				SistemaEstatusTipoDocumentoID = @SistemaEstatusTipoDocumentoID,
				Predeterminado = @Predeterminado
        WHERE   EstatusDocumentoID = @EstatusDocumentoID
    END
    ELSE
    BEGIN        
        INSERT  INTO EstatusDocumento(
                AltaUsuarioID,
                AltaFecha,
                EstatusDocumentoClave,
				Nombre,
				NombreCorto,
				SistemaEstatusTipoDocumentoID,
				Predeterminado)
        VALUES  (
                @ModificacionUsuarioID,
                GETDATE(),
                @EstatusDocumentoClave,
				@Nombre,
				@NombreCorto,
				@SistemaEstatusTipoDocumentoID,
				@Predeterminado)
        
        SET     @EstatusDocumentoID = SCOPE_IDENTITY()
    END
    COMMIT TRANSACTION
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION
    SELECT @Errores = 1, @Mensaje = ERROR_MESSAGE()
END CATCH 

SELECT  COALESCE(@Errores, 0) as Errores, 
        COALESCE(@Mensaje, '') as Mensaje,
        @EstatusDocumentoID as EstatusDocumentoID