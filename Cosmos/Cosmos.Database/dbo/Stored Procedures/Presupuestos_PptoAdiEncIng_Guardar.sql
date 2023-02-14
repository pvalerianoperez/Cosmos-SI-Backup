

CREATE PROCEDURE Presupuestos_PptoAdiEncIng_Guardar
@PptoAdiEncIngID int,
@PptoEncIngID int,
@FechaHora datetime,
@EstatusDocumentoID varchar(10),
@Comentario varchar(200)
AS
SET NOCOUNT ON 

DECLARE @Errores bit, @Mensaje nvarchar(300)

BEGIN TRANSACTION 
BEGIN TRY
    IF EXISTS(SELECT PptoAdiEncIngID FROM PptoAdiEncIng WHERE PptoAdiEncIngID = @PptoAdiEncIngID)
    BEGIN
        UPDATE  PptoAdiEncIng
        SET     
                PptoEncIngID = @PptoEncIngID,
                FechaHora = @FechaHora,
                Comentarios = @Comentario
        WHERE   PptoAdiEncIngID = @PptoAdiEncIngID;
    END
    ELSE
    BEGIN        
        INSERT  INTO PptoAdiEncIng(
                PptoEncIngID,
                FechaHora,
                EstatusDocumentoID,
                Comentarios)
        VALUES  (
                @PptoEncIngID,
                @FechaHora,
                @EstatusDocumentoID,
                @Comentario)
        
        SET     @PptoAdiEncIngID = SCOPE_IDENTITY()
    END
    COMMIT TRANSACTION
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION
    SELECT @Errores = 1, @Mensaje = ERROR_MESSAGE()
END CATCH 

SELECT  COALESCE(@Errores, 0) as Errores, 
        COALESCE(@Mensaje, '') as Mensaje,
        @PptoAdiEncIngID as PptoAdiEncIngID