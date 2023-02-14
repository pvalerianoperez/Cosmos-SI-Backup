CREATE PROCEDURE [dbo].[Presupuestos_PptoPerIng_Guardar]
		@PptoPerIngID INT,
        @PptoDetIngID INT,
        @PeriodoOperativoID INT,
        @ImporteMeta MONEY,
        @ImporteSolicitado MONEY,
        @ImporteBase MONEY,
        @ImporteEjercido MONEY
AS
SET NOCOUNT ON 

DECLARE @Errores bit, @Mensaje nvarchar(300)

BEGIN TRANSACTION 
BEGIN TRY
    IF EXISTS(SELECT PptoPerIngID FROM PptoPerIng WHERE PptoPerIngID = @PptoPerIngID)
    BEGIN
        UPDATE  PptoPerIng
        SET     
        [PptoDetIngID] = @PptoDetIngID,
        [CfgPeriodoOperativoID] = @PeriodoOperativoID,
        [ImporteMeta] = @ImporteMeta,
        [ImporteSolicitado] = @ImporteSolicitado,
        [ImporteBase] = @ImporteBase,
        [ImporteEjercido] = @ImporteEjercido
        WHERE   PptoPerIngID = @PptoPerIngID
    END
    ELSE
    BEGIN        
        INSERT  INTO PptoPerIng(
            [PptoDetIngID],
            [CfgPeriodoOperativoID],
            [ImporteMeta],
            [ImporteSolicitado],
            [ImporteBase],
            [ImporteEjercido])
        VALUES  (
            @PptoDetIngID,
            @PeriodoOperativoID,
            @ImporteMeta,
            @ImporteSolicitado,
            @ImporteBase,
            @ImporteEjercido)
        SET @PptoPerIngID = SCOPE_IDENTITY()
    END
    COMMIT TRANSACTION
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION
    SELECT @Errores = 1, @Mensaje = ERROR_MESSAGE()
END CATCH 

SELECT  COALESCE(@Errores, 0) as Errores, 
        COALESCE(@Mensaje, '') as Mensaje,
        @PptoPerIngID as PptoPerIngID