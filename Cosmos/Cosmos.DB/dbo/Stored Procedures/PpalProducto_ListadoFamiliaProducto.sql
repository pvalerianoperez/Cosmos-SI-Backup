

CREATE PROCEDURE [dbo].[PpalProducto_ListadoFamiliaProducto]
@FamiliaProductoID int = 0 
AS
SET NOCOUNT ON 

SET  @FamiliaProductoID = NULLIF(@FamiliaProductoID, 0)

SELECT  a.PpalProductoID, a.MarcaID, a.Nombre, a.NombreCorto, a.AuxUnidadID,
		a.ClaseProductoID, a.CfgTipoProductoID, a.NivelProductoID, a.MetodoCosteoID, a.ManejaLotes, a.ManejaSeries, a.Reorden, a.CfgFamiliaProductoID, a.EstatusProductoID,
		b.NombreCompleto as FamiliaProductoNombreCompleto
FROM    PpalProducto a
			LEFT OUTER JOIN vFamiliaProducto b ON a.CfgFamiliaProductoID = b.CfgFamiliaProductoID
WHERE	a.CfgFamiliaProductoID = ISNULL(@FamiliaProductoID, a.CfgFamiliaProductoID)
ORDER	BY b.NombreCompleto, a.Nombre, a.PpalProductoID

SET NOCOUNT ON