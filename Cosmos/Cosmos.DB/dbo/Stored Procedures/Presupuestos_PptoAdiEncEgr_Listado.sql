CREATE PROCEDURE [dbo].[Presupuestos_PptoAdiEncEgr_Listado]
@PptoEncEgrID INT = NULL
AS
	DECLARE @ENCID INT;
	SET @EncID = NULLIF(@PptoEncEgrID, -1)
	SELECT 
	PptoAdiEncEgrID,
	PptoEncEgrID,
	FechaHora,
	EstatusDocumentoID,
	Comentarios
	FROM PptoAdiEncEgr
	WHERE @ENCID IS NULL OR PptoEncEgrID = @PptoEncEgrID;
RETURN 0