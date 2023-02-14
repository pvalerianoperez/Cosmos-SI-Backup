CREATE PROCEDURE Seguridad_Perfil_ConsultarAcciones
@PerfilID int,
@OpcionID int
AS


SELECT	DISTINCT a.OpcionID, a.Nombre, b.TipoOpcionID, c.Nombre as TipoOpcion, e.AccionID, e.Nombre as Accion, 
		(CASE WHEN COALESCE(f.PerfilID,0) > 0 THEN 1 ELSE 0 END) as Permiso
FROM	SistemaOpcion a 
		INNER JOIN SistemaOpcionTipoOpcion b ON a.OpcionID = b.OpcionID
		INNER JOIN SistemaTipoOpcion c ON b.TipoOpcionID = c.TipoOpcionID
		INNER JOIN SistemaTipoOpcionAccion d ON c.TipoOpcionID = d.TipoOpcionID
		INNER JOIN SistemaAccion e ON d.AccionID = e.AccionID 
		LEFT OUTER JOIN SistemaPerfilOpcionAccion f ON a.OpcionID = f.OpcionID AND e.AccionID = f.AccionID AND f.PerfilID = @PerfilID
WHERE	a.OpcionID = @OpcionID