

CREATE PROCEDURE Presupuestos_PptoAdiDetIng_Guardar
@PptoAdiDetIngID int,
@PptoAdiEncIngID int,
@PptoPerIngID int,
@Importe money
AS
SET NOCOUNT ON 

DECLARE @Errores bit, @Mensaje nvarchar(300)

BEGIN TRANSACTION 
BEGIN TRY
    IF EXISTS(SELECT PptoAdiDetIngID FROM PptoAdiDetIng WHERE PptoAdiDetIngID = @PptoAdiDetIngID)
    BEGIN
        UPDATE  PptoAdiDetIng
        SET     
                PptoAdiEncIngID = @PptoAdiEncIngID, 
                PptoPerIngID = @PptoPerIngID,
                Importe = @Importe
        WHERE   PptoAdiDetIngID = @PptoAdiDetIngID
    END
    ELSE
    BEGIN        
        INSERT  INTO PptoAdiDetIng(
                PptoAdiEncIngID,
                PptoPerIngID,
                Importe)
        VALUES  (
                @PptoAdiEncIngID,
                @PptoPerIngID,
                @Importe)
        
        SET     @PptoAdiDetIngID = SCOPE_IDENTITY()
    END
    COMMIT TRANSACTION
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION
    SELECT @Errores = 1, @Mensaje = ERROR_MESSAGE()
END CATCH 

SELECT  COALESCE(@Errores, 0) as Errores, 
        COALESCE(@Mensaje, '') as Mensaje,
        @PptoAdiDetIngID as PptoAdiDetIngID