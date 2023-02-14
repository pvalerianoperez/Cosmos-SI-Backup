

CREATE PROCEDURE Sistema_Naturaleza_Guardar
@ModificacionUsuarioID int = null,
@NaturalezaID int,
@NaturalezaClave varchar(6),
@Nombre varchar(30),
@NombreCorto varchar(10)
AS
SET NOCOUNT ON 

DECLARE @Errores bit, @Mensaje nvarchar(300)

BEGIN TRANSACTION 
BEGIN TRY
    IF EXISTS(SELECT NaturalezaID FROM SistemaNaturaleza WHERE NaturalezaID = @NaturalezaID)
    BEGIN
        UPDATE  SistemaNaturaleza
        SET                     NaturalezaClave = @NaturalezaClave,
				Nombre = @Nombre,
				NombreCorto = @NombreCorto
        WHERE   NaturalezaID = @NaturalezaID
    END
    ELSE
    BEGIN        
        INSERT  INTO SistemaNaturaleza(
                NaturalezaClave,
				Nombre,
				NombreCorto)
        VALUES  (
                @NaturalezaClave,
				@Nombre,
				@NombreCorto)
        
        SET     @NaturalezaID = SCOPE_IDENTITY()
    END
    COMMIT TRANSACTION
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION
    SELECT @Errores = 1, @Mensaje = ERROR_MESSAGE()
END CATCH 

SELECT  COALESCE(@Errores, 0) as Errores, 
        COALESCE(@Mensaje, '') as Mensaje,
        @NaturalezaID as NaturalezaID