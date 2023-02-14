

CREATE PROCEDURE [dbo].[Presupuestos_PptoDetEgr_Guardar]
@PptoDetEgrID int,
@PptoEncEgrID int,
@ConceptoEgresoID int,
@PpalCuentaContableID int,
@RubroContableID int
AS
SET NOCOUNT ON 

DECLARE @Errores bit, @Mensaje nvarchar(300)

BEGIN TRANSACTION 
BEGIN TRY
    IF EXISTS(SELECT PptoDetEgrID FROM PptoDetEgr WHERE PptoDetEgrID = @PptoDetEgrID)
    BEGIN
        UPDATE  PptoDetEgr
        SET     
                PptoEncEgrID = @PptoEncEgrID, 
                ConceptoEgresoID = @ConceptoEgresoID,
                PpalCuentaContableID = @PpalCuentaContableID,
                RubroContableID = @RubroContableID
        WHERE   PptoDetEgrID = @PptoDetEgrID;
    END
    ELSE
    BEGIN        
        INSERT  INTO PptoDetEgr(
                PptoEncEgrID,
                ConceptoEgresoID,
                PpalCuentaContableID,
                RubroContableID)
        VALUES  (
                @PptoEncEgrID,
                @ConceptoEgresoID,
                @PpalCuentaContableID,
                @RubroContableID)
        
        SET     @PptoDetEgrID = SCOPE_IDENTITY()
    END
    COMMIT TRANSACTION
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION
    SELECT @Errores = 1, @Mensaje = ERROR_MESSAGE()
END CATCH 

SELECT  COALESCE(@Errores, 0) as Errores, 
        COALESCE(@Mensaje, '') as Mensaje,
        @PptoDetEgrID as PptoDetEgrID