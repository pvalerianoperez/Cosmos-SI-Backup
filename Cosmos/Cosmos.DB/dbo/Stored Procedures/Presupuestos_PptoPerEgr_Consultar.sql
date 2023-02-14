CREATE PROCEDURE [dbo].[Presupuestos_PptoPerEgr_Consultar]
	@PptoPerEgrID int = null
AS
	SELECT 
		PptoPerEgrID,
        PptoDetEgrID,
        CfgPeriodoOperativoID,
        ImporteMeta,
        ImporteSolicitado,
        ImporteBase,
        ImporteEjercido
	FROM PptoPerEgr
	WHERE @PptoPerEgrID = PptoPerEgrID;
RETURN 0