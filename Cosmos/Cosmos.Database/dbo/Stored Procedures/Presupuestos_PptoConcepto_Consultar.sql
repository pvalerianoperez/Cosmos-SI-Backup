CREATE PROCEDURE [dbo].[Presupuestos_PptoConcepto_Consultar]
	@PptoConceptoID int
AS
	SELECT PptoConceptoID, Concepto 
	FROM PptoConcepto
	WHERE PptoConceptoID = @PptoConceptoID;
RETURN 0