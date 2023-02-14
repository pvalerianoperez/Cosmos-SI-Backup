CREATE PROCEDURE [dbo].[Presupuestos_PptoDesgEgr_Listado]
	@PptoPerEgrID int = null
AS
	SELECT 
		PptoDesgEgrID,
		PptoPerEgrID,
		PptoConceptoID,
		ImporteSolicitado
	FROM PptoDesgEgr
	WHERE @PptoPerEgrID IS NULL OR PptoPerEgrID = @PptoPerEgrID;
RETURN 0