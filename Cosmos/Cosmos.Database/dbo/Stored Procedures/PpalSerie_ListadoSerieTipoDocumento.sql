
CREATE PROCEDURE [dbo].[PpalSerie_ListadoSerieTipoDocumento]
@TipoDocumentoID int, 
@PpalSucursalID int
AS

SELECT	a.*
FROM	PpalSerie a 
			INNER JOIN SistemaTipoDocumento b ON a.TipoDocumentoID = b.TipoDocumentoID AND b.Activo = 1 
WHERE	a.TipoDocumentoID = @TipoDocumentoID
AND		a.PpalSucursalID = @PpalSucursalID