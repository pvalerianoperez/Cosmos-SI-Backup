CREATE PROCEDURE [dbo].[Presupuestos_PptoPerIng_Listado]
	@PptoDetIngID int = null
AS
	SELECT 
		[PptoPerIngID],
        [PptoDetIngID],
        [CfgPeriodoOperativoID],
        [ImporteMeta],
        [ImporteSolicitado],
        [ImporteBase],
        [ImporteEjercido]
	FROM [PptoPerIng] 
	WHERE @PptoDetIngID = PptoDetIngID;
RETURN 0