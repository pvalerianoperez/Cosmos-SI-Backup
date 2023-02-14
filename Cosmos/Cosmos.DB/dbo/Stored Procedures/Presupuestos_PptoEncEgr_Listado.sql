CREATE PROCEDURE [dbo].[Presupuestos_PptoEncEgr_Listado]
AS
	SELECT 
		PptoEncEgrID,
		PpalCentroCostoID,
		EstatusDocumentoID,
		PpalCuentaContableID
	FROM PptoEncEgr
RETURN 0