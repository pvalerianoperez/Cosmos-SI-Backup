CREATE PROCEDURE [dbo].[Presupuestos_PptoAdiEncEgr_Consultar]
	@PptoAdiEncEgrID int
AS
	SELECT 
		PptoAdiEncEgrID,
		PptoEncEgrID,
		FechaHora,
		EstatusDocumentoID,
		Comentarios
	FROM PptoAdiEncEgr
	WHERE PptoAdiEncEgrID = @PptoAdiEncEgrID;
RETURN 0