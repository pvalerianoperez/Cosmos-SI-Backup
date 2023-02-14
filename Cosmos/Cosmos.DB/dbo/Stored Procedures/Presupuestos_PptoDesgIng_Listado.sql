CREATE PROCEDURE [dbo].[Presupuestos_PptoDesgIng_Listado]
	@PptoPerIngID int = null
AS
	SELECT 
		PptoDesgIngID,
		PptoPerIngID,
		PptoConceptoID,
		ImporteSolicitado
	FROM PptoDesgIng
	WHERE @PptoPerIngID IS NULL OR PptoPerIngID = @PptoPerIngID;
RETURN 0