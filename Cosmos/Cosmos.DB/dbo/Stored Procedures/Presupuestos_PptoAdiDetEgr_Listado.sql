CREATE PROCEDURE [dbo].[Presupuestos_PptoAdiDetEgr_Listado]
@PptoAdiEncEgrID int = null
AS
	SELECT 
	PptoAdiDetEgrID,
	PptoAdiEncEgrID,
	PptoPerEgrID,
	Importe
	FROM PptoAdiDetEgr
	WHERE @PptoAdiEncEgrID is null OR @PptoAdiEncEgrID = PptoAdiEncEgrID;
RETURN 0