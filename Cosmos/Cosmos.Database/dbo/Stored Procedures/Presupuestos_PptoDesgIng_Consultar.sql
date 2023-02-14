CREATE PROCEDURE [dbo].[Presupuestos_PptoDesgIng_Consultar]
	@PptoDesIngID int = null
AS
	SELECT 
		PptoDesgIngID,
		PptoPerIngID,
		PptoConceptoID,
		ImporteSolicitado
	FROM PptoDesgIng
	WHERE PptoDesgIngID = @PptoDesIngID;
RETURN 0