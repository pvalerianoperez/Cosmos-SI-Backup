CREATE PROCEDURE [dbo].[Presupuestos_PptoDesgIng_Guardar]
    @PptoDesgIngID int,
    @PptoPerIngID int,
    @PptoConceptoID int,
    @ImporteSolicitado money
AS
SET NOCOUNT ON 

DECLARE @Errores bit, @Mensaje nvarchar(300)

BEGIN TRANSACTION 
BEGIN TRY
    IF EXISTS(SELECT PptoDesgIngID FROM PptoDesgIng WHERE PptoDesgIngID = @PptoDesgIngID)
    BEGIN
        UPDATE  PptoDesgIng
        SET     
                PptoPerIngID = @PptoPerIngID, 
                PptoConceptoID = @PptoConceptoID,
                ImporteSolicitado = @ImporteSolicitado
        WHERE   PptoDesgIngID = @PptoDesgIngID;
    END
    ELSE IF EXISTS(SELECT PptoDesgIngID FROM PptoDesgIng WHERE @PptoConceptoID = PptoConceptoID AND PptoPerIngID = @PptoPerIngID)
    BEGIN
        UPDATE  PptoDesgIng
        SET     
                @PptoDesgIngID = PptoDesgIngID,
                ImporteSolicitado = @ImporteSolicitado
        WHERE   @PptoConceptoID = PptoConceptoID AND PptoPerIngID = @PptoPerIngID
    END
    ELSE
    BEGIN        
        INSERT  INTO PptoDesgIng(
                PptoPerIngID,
                PptoConceptoID,
                ImporteSolicitado)
        VALUES  (
                @PptoPerIngID,
                @PptoConceptoID,
                @ImporteSolicitado)
        
        SET     @PptoDesgIngID = SCOPE_IDENTITY()
    END
    COMMIT TRANSACTION
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION
    SELECT @Errores = 1, @Mensaje = ERROR_MESSAGE()
END CATCH 

SELECT  COALESCE(@Errores, 0) as Errores, 
        COALESCE(@Mensaje, '') as Mensaje,
        @PptoDesgIngID as PptoDesgIngID