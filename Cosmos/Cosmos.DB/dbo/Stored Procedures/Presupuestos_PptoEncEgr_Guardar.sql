

CREATE PROCEDURE [dbo].[Presupuestos_PptoEncEgr_Guardar]
@PptoEncEgrID INT,
@PpalCentroCostoID INT,
@EstatosDocumentoID INT,
@PpalCuentaContableID INT
AS
SET NOCOUNT ON 

DECLARE @Errores bit, @Mensaje nvarchar(300)

BEGIN TRANSACTION 
BEGIN TRY
    IF EXISTS(SELECT PptoEncEgrID FROM PptoEncEgr WHERE PptoEncEgrID = @PptoEncEgrID)
    BEGIN
        UPDATE  PptoEncEgr
        SET     
                PpalCentroCostoID = @PpalCentroCostoID, 
                EstatusDocumentoID = @EstatosDocumentoID,
				PpalCuentaContableID = @PpalCuentaContableID
        WHERE   PptoEncEgrID = @PptoEncEgrID
    END
    ELSE
    BEGIN        
        INSERT  INTO PptoEncEgr(
                PpalCentroCostoID,
                EstatusDocumentoID,
				PpalCuentaContableID)
        VALUES  (
                @PpalCentroCostoID,
                @EstatosDocumentoID,
				@PpalCuentaContableID)
        
        SET     @PptoEncEgrID = SCOPE_IDENTITY()
    END
    COMMIT TRANSACTION
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION
    SELECT @Errores = 1, @Mensaje = ERROR_MESSAGE()
END CATCH 

SELECT  COALESCE(@Errores, 0) as Errores, 
        COALESCE(@Mensaje, '') as Mensaje,
        @PptoEncEgrID as PptoEncEgrID