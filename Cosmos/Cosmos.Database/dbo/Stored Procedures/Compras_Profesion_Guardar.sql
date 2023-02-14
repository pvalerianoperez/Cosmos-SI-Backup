

CREATE PROCEDURE Compras_Profesion_Guardar
@ModificacionUsuarioID int = null,
@ProfesionID int,
@ProfesionClave varchar(8),
@Nombre varchar(60),
@NombreCorto varchar(20)
AS
SET NOCOUNT ON 

DECLARE @Errores bit, @Mensaje nvarchar(300)

BEGIN TRANSACTION 
BEGIN TRY
    IF EXISTS(SELECT ProfesionID FROM Profesion WHERE ProfesionID = @ProfesionID)
    BEGIN
        UPDATE  Profesion
        SET     
                ModificacionUsuarioID = @ModificacionUsuarioID, 
                ModificacionFecha = GETDATE(),
                ProfesionClave = @ProfesionClave,
				Nombre = @Nombre,
				NombreCorto = @NombreCorto
        WHERE   ProfesionID = @ProfesionID
    END
    ELSE
    BEGIN        
        INSERT  INTO Profesion(
                AltaUsuarioID,
                AltaFecha,
                ProfesionClave,
				Nombre,
				NombreCorto)
        VALUES  (
                @ModificacionUsuarioID,
                GETDATE(),
                @ProfesionClave,
				@Nombre,
				@NombreCorto)
        
        SET     @ProfesionID = SCOPE_IDENTITY()
    END
    COMMIT TRANSACTION
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION
    SELECT @Errores = 1, @Mensaje = ERROR_MESSAGE()
END CATCH 

SELECT  COALESCE(@Errores, 0) as Errores, 
        COALESCE(@Mensaje, '') as Mensaje,
        @ProfesionID as ProfesionID