CREATE PROCEDURE [dbo].[Presupuestos_PptoDesgEgr_Guardar]
    @PptoDesgEgrID int,
    @PptoPerEgrID int,
    @PptoConceptoID int,
    @ImporteSolicitado money
AS
SET NOCOUNT ON 

DECLARE @Errores bit, @Mensaje nvarchar(300)

BEGIN TRANSACTION 
BEGIN TRY
    IF EXISTS(SELECT PptoDesgEgrID FROM PptoDesgEgr WHERE PptoDesgEgrID = @PptoDesgEgrID)
    BEGIN
        UPDATE  PptoDesgEgr
        SET     
                PptoPerEgrID = @PptoPerEgrID, 
                PptoConceptoID = @PptoConceptoID,
                ImporteSolicitado = @ImporteSolicitado
        WHERE   PptoDesgEgrID = @PptoDesgEgrID;
    END
    ELSE IF EXISTS(SELECT PptoDesgEgrID FROM PptoDesgEgr WHERE @PptoConceptoID = PptoConceptoID AND PptoPerEgrID = @PptoPerEgrID)
    BEGIN
        UPDATE  PptoDesgEgr
        SET     
                @PptoDesgEgrID = PptoDesgEgrID,
                ImporteSolicitado = @ImporteSolicitado
        WHERE   @PptoConceptoID = PptoConceptoID AND PptoPerEgrID = @PptoPerEgrID
    END
    ELSE
    BEGIN        
        INSERT  INTO PptoDesgEgr(
                PptoPerEgrID,
                PptoConceptoID,
                ImporteSolicitado)
        VALUES  (
                @PptoPerEgrID,
                @PptoConceptoID,
                @ImporteSolicitado)
        
        SET     @PptoDesgEgrID = SCOPE_IDENTITY()
    END
    COMMIT TRANSACTION
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION
    SELECT @Errores = 1, @Mensaje = ERROR_MESSAGE()
END CATCH 

SELECT  COALESCE(@Errores, 0) as Errores, 
        COALESCE(@Mensaje, '') as Mensaje,
        @PptoDesgEgrID as PptoDesgEgrID