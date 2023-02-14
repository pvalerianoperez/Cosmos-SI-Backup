CREATE PROCEDURE [dbo].[Presupuestos_PptoDesgEgr_Consultar]
	@PptoDesEgrID int = null
AS
	SELECT 
		PptoDesgEgrID,
		PptoPerEgrID,
		PptoConceptoID,
		ImporteSolicitado
	FROM PptoDesgEgr
	WHERE PptoDesgEgrID = @PptoDesEgrID;
RETURN 0