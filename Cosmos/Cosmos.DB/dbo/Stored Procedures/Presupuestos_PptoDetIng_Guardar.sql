

CREATE PROCEDURE [dbo].[Presupuestos_PptoDetIng_Guardar]
@PptoDetIngID int,
@PptoEncIngID int,
@ConceptoIngresoID int,
@PpalCuentaContableID int,
@RubroContableID int
AS
SET NOCOUNT ON 

DECLARE @Errores bit, @Mensaje nvarchar(300)

BEGIN TRANSACTION 
BEGIN TRY
    IF EXISTS(SELECT PptoDetIngID FROM PptoDetIng WHERE PptoDetIngID = @PptoDetIngID)
    BEGIN
        UPDATE  PptoDetIng
        SET     
                PptoEncIngID = @PptoEncIngID, 
                PpalConceptoIngresoID = @ConceptoIngresoID,
                PpalCuentaContableID = @PpalCuentaContableID,
                RubroContableID = @RubroContableID
        WHERE   PptoDetIngID = @PptoDetIngID;
    END
    ELSE
    BEGIN        
        INSERT  INTO PptoDetIng(
                PptoEncIngID,
                PpalConceptoIngresoID,
                PpalCuentaContableID,
                RubroContableID)
        VALUES  (
                @PptoEncIngID,
                @ConceptoIngresoID,
                @PpalCuentaContableID,
                @RubroContableID)
        
        SET     @PptoDetIngID = SCOPE_IDENTITY()
    END
    COMMIT TRANSACTION
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION
    SELECT @Errores = 1, @Mensaje = ERROR_MESSAGE()
END CATCH 

SELECT  COALESCE(@Errores, 0) as Errores, 
        COALESCE(@Mensaje, '') as Mensaje,
        @PptoDetIngID as PptoDetIngID