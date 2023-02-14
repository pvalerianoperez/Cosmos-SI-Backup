CREATE PROCEDURE [dbo].[Presupuestos_PptoAdiEncIng_Listado]
@PptoEncIngID INT = NULL
AS
	SET @PptoEncIngID = NULLIF(@PptoEncIngID, -1);
	SELECT 
	PptoAdiEncIngID,
	PptoEncIngID,
	FechaHora,
	EstatusDocumentoID,
	Comentarios
	FROM PptoAdiEncIng
	WHERE @PptoEncIngID IS NULL OR PptoEncIngID = @PptoEncIngID;
RETURN 0