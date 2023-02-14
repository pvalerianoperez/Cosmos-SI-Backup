CREATE PROCEDURE [dbo].[Presupuestos_PptoPerEgr_Listado]
	@PptoDetEgrID int = 0
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
	WHERE @PptoDetEgrID = PptoDetEgrID;
RETURN 0