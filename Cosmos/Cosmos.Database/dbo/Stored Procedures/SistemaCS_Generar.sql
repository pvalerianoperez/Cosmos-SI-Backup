CREATE PROCEDURE SistemaCS_Generar
AS

SELECT	a.Tabla, a.NS, coalesce(b.Nombre, '') as Modulo, coalesce(a.gEntidad,0) as gEntidad, coalesce(a.gapi,0) as gapi, coalesce(a.gapiclient,0) as gapiclient, coalesce(a.gaspx,0) as gaspx, coalesce(a.gsql,0) as gsql, coalesce(dsql, 0) as dsql, coalesce(gnegocio,0) as gnegocio 
FROM	SistemaCS a 
		left outer join sistemamodulo b on a.moduloid = b.moduloid 
WHERE	a.ModuloID = 5 -- a.Tabla = 'TipoFecha'

ORDER BY a.Tabla