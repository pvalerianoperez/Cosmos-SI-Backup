CREATE PROCEDURE [dbo].[Presupuestos_PptoEncIng_Consultar]
	@PptoEncIngID INT = NULL
AS
	SELECT 
		PptoEncIngID,
		PpalCentroCostoID,
		EstatusDocumentoID,
		PpalCuentaContableID
	FROM PptoEncIng
	WHERE @PptoEncIngID = PptoEncIngID;
RETURN 0