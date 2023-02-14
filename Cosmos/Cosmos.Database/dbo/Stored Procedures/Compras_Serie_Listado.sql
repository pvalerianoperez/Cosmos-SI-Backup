
CREATE PROCEDURE Compras_Serie_Listado
@EmpresaID int
AS

SELECT  a.SerieID, a.TipoDocumentoID, a.SerieClave, a.FolioInicial, a.FolioFinal, a.UltimoFolio, a.Estatus, a.Predeterminado, a.SucursalID
FROM    Serie a 
		INNER JOIN Sucursal b ON a.SucursalID = b.SucursalID
WHERE	b.EmpresaID = @EmpresaID