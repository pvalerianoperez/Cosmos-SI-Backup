CREATE PROCEDURE [dbo].[Presupuestos_PptoAdiEncIng_Consultar]
	@PptoAdiEncIngID int
AS
	SELECT 
		PptoAdiEncIngID,
		PptoEncIngID,
		FechaHora,
		EstatusDocumentoID,
		Comentarios
	FROM PptoAdiEncIng
	WHERE PptoAdiEncIngID = @PptoAdiEncIngID;
RETURN 0