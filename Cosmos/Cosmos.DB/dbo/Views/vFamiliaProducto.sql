
CREATE VIEW [dbo].[vFamiliaProducto]
AS

SELECT	a.*, 
		((CASE WHEN d.Nombre IS NULL THEN '' ELSE d.Nombre + ' > ' END) +
		(CASE WHEN c.Nombre IS NULL THEN '' ELSE c.Nombre + ' > ' END) +
		(CASE WHEN b.Nombre IS NULL THEN '' ELSE b.Nombre + ' > ' END) +
		a.Nombre) as NombreCompleto
FROM	CfgFamiliaProducto a 
			LEFT OUTER JOIN CfgFamiliaProducto b ON a.PadreID = b.CfgFamiliaProductoID
			LEFT OUTER JOIN CfgFamiliaProducto c ON b.PadreID = c.CfgFamiliaProductoID
			LEFT OUTER JOIN CfgFamiliaProducto d ON c.PadreID = d.CfgFamiliaProductoID
			LEFT OUTER JOIN CfgFamiliaProducto e ON d.PadreID = e.CfgFamiliaProductoID