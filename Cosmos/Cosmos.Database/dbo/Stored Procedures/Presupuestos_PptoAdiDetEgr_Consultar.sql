CREATE PROCEDURE [dbo].[Presupuestos_PptoAdiDetEgr_Consultar]
	@PptoAdiDetEgrID int = 0
AS
	SELECT 
	PptoAdiDetEgrID,
	PptoAdiEncEgrID,
	PptoPerEgrID,
	Importe
	FROM PptoAdiDetEgr
	WHERE PptoAdiDetEgrID = @PptoAdiDetEgrID;
RETURN 0