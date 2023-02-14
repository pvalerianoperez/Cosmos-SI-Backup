CREATE PROCEDURE [dbo].[Presupuestos_PptoEncEgr_Consultar]
	@PptoEncEgrID INT = NULL
AS
	SELECT 
		PptoEncEgrID,
		PpalCentroCostoID,
		EstatusDocumentoID,
		PpalCuentaContableID
	FROM PptoEncEgr
	WHERE @PptoEncEgrID = PptoEncEgrID;
RETURN 0