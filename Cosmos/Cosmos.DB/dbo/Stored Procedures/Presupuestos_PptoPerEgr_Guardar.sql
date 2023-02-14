CREATE PROCEDURE [dbo].[Presupuestos_PptoPerEgr_Guardar]
		@PptoPerEgrID INT = 0,
        @PptoDetEgrID INT = 0,
        @PeriodoOperativoID INT = 0,
        @ImporteMeta MONEY = 0,
        @ImporteSolicitado MONEY = 0,
        @ImporteBase MONEY = 0,
        @ImporteEjercido MONEY = 0
AS
SET NOCOUNT ON 

DECLARE @Errores bit, @Mensaje nvarchar(300)

BEGIN TRANSACTION 
BEGIN TRY
    IF EXISTS(SELECT PptoPerEgrID FROM PptoPerEgr WHERE PptoPerEgrID = @PptoPerEgrID)
    BEGIN
        UPDATE  PptoPerEgr
        SET     
        CfgPeriodoOperativoID = @PeriodoOperativoID,
        ImporteMeta = @ImporteMeta,
        ImporteSolicitado = @ImporteSolicitado,
        ImporteBase = @ImporteBase,
        ImporteEjercido = @ImporteEjercido
        WHERE   PptoPerEgrID = @PptoPerEgrID
    END
    ELSE IF EXISTS (SELECT PptoPerEgrID FROM PptoPerEgr WHERE CfgPeriodoOperativoID = @PeriodoOperativoID AND [PptoDetEgrID] = @PptoDetEgrID)
    BEGIN
        UPDATE  PptoPerEgr
        SET
        ImporteMeta = @ImporteMeta,
        ImporteSolicitado = @ImporteSolicitado,
        ImporteBase = @ImporteBase,
        ImporteEjercido = @ImporteEjercido
        WHERE   CfgPeriodoOperativoID = @PeriodoOperativoID
        AND [PptoDetEgrID] = @PptoDetEgrID
    END
    ELSE
    BEGIN        
        INSERT  INTO PptoPerEgr(
            PptoDetEgrID,
            CfgPeriodoOperativoID,
            ImporteMeta,
            ImporteSolicitado,
            ImporteBase,
            ImporteEjercido)
        VALUES  (
            @PptoDetEgrID,
            @PeriodoOperativoID,
            @ImporteMeta,
            @ImporteSolicitado,
            @ImporteBase,
            @ImporteEjercido)
        SET @PptoPerEgrID = SCOPE_IDENTITY()
    END
    COMMIT TRANSACTION
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION
    SELECT @Errores = 1, @Mensaje = ERROR_MESSAGE()
END CATCH 

SELECT  COALESCE(@Errores, 0) as Errores, 
        COALESCE(@Mensaje, '') as Mensaje,
        @PptoPerEgrID as PptoPerEgrID