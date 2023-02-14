CREATE PROCEDURE [dbo].[Presupuestos_PptoPerIng_Consultar]
	@PptoPerIngID int = null
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
	WHERE @PptoPerIngID = PptoPerIngID;
RETURN 0