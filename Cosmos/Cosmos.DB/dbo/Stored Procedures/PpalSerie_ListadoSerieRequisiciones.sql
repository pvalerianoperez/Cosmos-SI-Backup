CREATE PROCEDURE [dbo].[PpalSerie_ListadoSerieRequisiciones]
AS

SELECT	a.*
FROM	PpalSerie a 
			INNER JOIN SistemaTipoDocumento b ON a.TipoDocumentoID = b.TipoDocumentoID AND b.Activo = 1 
WHERE	a.TipoDocumentoID = 1