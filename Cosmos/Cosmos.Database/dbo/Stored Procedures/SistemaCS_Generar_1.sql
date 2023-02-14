CREATE PROCEDURE [dbo].[SistemaCS_Generar]
AS

SELECT	a.Tabla, a.NS, 
		coalesce(b.Nombre, '') as Modulo, 
		coalesce(a.gEntidad,0) as gEntidad, 
		coalesce(a.gAPI,0) as gAPI, 
		coalesce(a.gAPIClient,0) as gAPIClient, 
		coalesce(a.gASPX,0) as gASPX, 
		coalesce(a.gSQL,0) as gSQL, 
		coalesce(dSQL, 0) as dSQL, 
		coalesce(gNegocio,0) as gNegocio 
FROM	SistemaCS a 
		left outer join SistemaModulo b on a.moduloid = b.ModuloID 
WHERE	a.ModuloID = 5 -- a.Tabla = 'TipoFecha'

ORDER BY a.Tabla