

CREATE PROCEDURE [dbo].[Presupuestos_PptoConcepto_Guardar]
@PptoConceptoID int,
@Concepto varchar(100)
AS
SET NOCOUNT ON 

DECLARE @Errores bit, @Mensaje nvarchar(300)

BEGIN TRANSACTION 
BEGIN TRY
    IF EXISTS(SELECT PptoConceptoID FROM PptoConcepto WHERE PptoConceptoID = @PptoConceptoID OR Concepto = @Concepto)
    BEGIN
        UPDATE  PptoConcepto
        SET     
                @PptoConceptoID = PptoConceptoID,
                Concepto = @Concepto
        WHERE   PptoConceptoID = @PptoConceptoID 
        OR      Concepto = @Concepto;
    END
    ELSE
    BEGIN        
        INSERT  INTO PptoConcepto(
                Concepto
                )
        VALUES  (
                @Concepto
                )
        
        SET     @PptoConceptoID = SCOPE_IDENTITY()
    END
    COMMIT TRANSACTION
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION
    SELECT @Errores = 1, @Mensaje = ERROR_MESSAGE()
END CATCH 

SELECT  COALESCE(@Errores, 0) as Errores, 
        COALESCE(@Mensaje, '') as Mensaje,
        @PptoConceptoID as PptoConceptoID