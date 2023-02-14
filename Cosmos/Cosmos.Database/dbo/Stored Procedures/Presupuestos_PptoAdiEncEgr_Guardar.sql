

CREATE PROCEDURE Presupuestos_PptoAdiEncEgr_Guardar
@PptoAdiEncEgrID int,
@PptoEncEgrID int,
@FechaHora datetime,
@EstatusDocumentoID varchar(10),
@Comentario varchar(200)
AS
SET NOCOUNT ON 

DECLARE @Errores bit, @Mensaje nvarchar(300)

BEGIN TRANSACTION 
BEGIN TRY
    IF EXISTS(SELECT PptoAdiEncEgrID FROM PptoAdiEncEgr WHERE PptoAdiEncEgrID = @PptoAdiEncEgrID)
    BEGIN
        UPDATE  PptoAdiEncEgr
        SET   
                PptoEncEgrID = @PptoEncEgrID,
                FechaHora = @FechaHora,
                Comentarios = @Comentario
        WHERE   PptoAdiEncEgrID = @PptoAdiEncEgrID;
    END
    ELSE
    BEGIN        
        INSERT  INTO PptoAdiEncEgr(
                PptoEncEgrID,
                FechaHora,
                EstatusDocumentoID,
                Comentarios)
        VALUES  (
                @PptoEncEgrID,
                @FechaHora,
                @EstatusDocumentoID,
                @Comentario)
        SET     @PptoAdiEncEgrID = SCOPE_IDENTITY()
    END
    COMMIT TRANSACTION
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION
    SELECT @Errores = 1, @Mensaje = ERROR_MESSAGE()
END CATCH 

SELECT  COALESCE(@Errores, 0) as Errores, 
        COALESCE(@Mensaje, '') as Mensaje,
        @PptoAdiEncEgrID as PptoAdiEncEgrID