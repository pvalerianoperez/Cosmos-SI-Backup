

CREATE PROCEDURE Sistema_EstatusTelefono_Guardar
@ModificacionUsuarioID int = null,
@EstatusTelefonoID int,
@EstatusTelefonoClave varchar(4),
@Nombre varchar(25),
@NombreCorto varchar(8)
AS
SET NOCOUNT ON 

DECLARE @Errores bit, @Mensaje nvarchar(300)

BEGIN TRANSACTION 
BEGIN TRY
    IF EXISTS(SELECT EstatusTelefonoID FROM SistemaEstatusTelefono WHERE EstatusTelefonoID = @EstatusTelefonoID)
    BEGIN
        UPDATE  SistemaEstatusTelefono
        SET                     EstatusTelefonoClave = @EstatusTelefonoClave,
				Nombre = @Nombre,
				NombreCorto = @NombreCorto
        WHERE   EstatusTelefonoID = @EstatusTelefonoID
    END
    ELSE
    BEGIN        
        INSERT  INTO SistemaEstatusTelefono(
                EstatusTelefonoClave,
				Nombre,
				NombreCorto)
        VALUES  (
                @EstatusTelefonoClave,
				@Nombre,
				@NombreCorto)
        
        SET     @EstatusTelefonoID = SCOPE_IDENTITY()
    END
    COMMIT TRANSACTION
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION
    SELECT @Errores = 1, @Mensaje = ERROR_MESSAGE()
END CATCH 

SELECT  COALESCE(@Errores, 0) as Errores, 
        COALESCE(@Mensaje, '') as Mensaje,
        @EstatusTelefonoID as EstatusTelefonoID