CREATE PROCEDURE [dbo].[Presupuestos_PptoAdiDetIng_Consultar]
	@PptoAdiDetIngID int = 0
AS
	SELECT 
	PptoAdiDetIngID,
	PptoAdiEncIngID,
	PptoPerIngID,
	Importe
	FROM PptoAdiDetIng
	WHERE PptoAdiDetIngID = @PptoAdiDetIngID;
RETURN 0