CREATE PROCEDURE [dbo].[Presupuestos_PptoAdiDetIng_Listado]
@PptoEncIngID int = null
AS
	SELECT 
	PptoAdiDetIngID,
	PptoAdiEncIngID,
	PptoPerIngID,
	Importe
	FROM PptoAdiDetIng
	WHERE @PptoEncIngID IS NULL OR PptoAdiEncIngID = @PptoEncIngID;
RETURN 0