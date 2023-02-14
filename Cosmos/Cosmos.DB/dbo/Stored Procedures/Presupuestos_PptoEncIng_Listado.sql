CREATE PROCEDURE [dbo].[Presupuestos_PptoEncIng_Listado]
	@PpalCentroCostosID INT = NULL
AS
	SELECT 
		PptoEncIngID,
		PpalCentroCostoID,
		EstatusDocumentoID,
		PpalCuentaContableID
	FROM PptoEncIng
	WHERE @PpalCentroCostosID IS NULL OR @PpalCentroCostosID = PpalCentroCostoID;
RETURN 0