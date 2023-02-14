

CREATE PROCEDURE [dbo].[Presupuestos_PptoEncIng_Guardar]
@PptoEncIngID INT,
@PpalCentroDeCostoID INT,
@EstatosDocumentoID INT,
@PpalCuentaContableID INT
AS
SET NOCOUNT ON 

DECLARE @Errores bit, @Mensaje nvarchar(300)

BEGIN TRANSACTION 
BEGIN TRY
    IF EXISTS(SELECT PptoEncIngID FROM PptoEncIng WHERE PptoEncIngID = @PptoEncIngID)
    BEGIN
        UPDATE  PptoEncIng
        SET     
                PpalCentroCostoID = @PpalCentroDeCostoID, 
                EstatusDocumentoID = @EstatosDocumentoID,
				PpalCuentaContableID = @PpalCuentaContableID
        WHERE   PptoEncIngID = @PptoEncIngID
    END
    ELSE
    BEGIN        
        INSERT  INTO PptoEncIng(
                PpalCentroCostoID,
                EstatusDocumentoID,
				PpalCuentaContableID)
        VALUES  (
                @PpalCentroDeCostoID,
                @EstatosDocumentoID,
				@PpalCuentaContableID)
        
        SET     @PptoEncIngID = SCOPE_IDENTITY()
    END
    COMMIT TRANSACTION
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION
    SELECT @Errores = 1, @Mensaje = ERROR_MESSAGE()
END CATCH 

SELECT  COALESCE(@Errores, 0) as Errores, 
        COALESCE(@Mensaje, '') as Mensaje,
        @PptoEncIngID as PptoEncIngID