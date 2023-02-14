

CREATE PROCEDURE Presupuestos_PptoAdiDetEgr_Guardar
@PptoAdiDetEgrID int,
@PptoAdiEncEgrID int,
@PptoPerEgrID int,
@Importe money
AS
SET NOCOUNT ON 

DECLARE @Errores bit, @Mensaje nvarchar(300)

BEGIN TRANSACTION 
BEGIN TRY
    IF EXISTS(SELECT PptoAdiDetEgrID FROM PptoAdiDetEgr WHERE PptoAdiDetEgrID = @PptoAdiDetEgrID)
    BEGIN
        UPDATE  PptoAdiDetEgr
        SET     
                PptoAdiEncEgrID = @PptoAdiEncEgrID, 
                PptoPerEgrID = @PptoPerEgrID,
                Importe = @Importe
        WHERE   PptoAdiDetEgrID = @PptoAdiDetEgrID
    END
    ELSE
    BEGIN        
        INSERT  INTO PptoAdiDetEgr(
                PptoAdiEncEgrID,
                PptoPerEgrID,
                Importe)
        VALUES  (
                @PptoAdiEncEgrID,
                @PptoPerEgrID,
                @Importe)
        
        SET     @PptoAdiDetEgrID = SCOPE_IDENTITY()
    END
    COMMIT TRANSACTION
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION
    SELECT @Errores = 1, @Mensaje = ERROR_MESSAGE()
END CATCH 

SELECT  COALESCE(@Errores, 0) as Errores, 
        COALESCE(@Mensaje, '') as Mensaje,
        @PptoAdiDetEgrID as PptoAdiDetEgrID