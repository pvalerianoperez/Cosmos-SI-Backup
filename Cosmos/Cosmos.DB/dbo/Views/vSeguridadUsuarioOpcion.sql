
CREATE VIEW vSeguridadUsuarioOpcion
AS

SELECT	a.SegUsuarioID, a.Nombre, a.Activo, a.Bloqueado, a.Administrador, 
		a.SegPerfilID, a.PerfilNombre, a.PerfilNombreCorto,
		a.EmpresaID, a.EmpresaNombre, a.EmpresaNombreCorto,
		c.OpcionID, c.ModuloID, d.ModuloClave, d.Nombre as ModuloNombre, d.NombreCorto as ModuloNombreCorto, 
		c.PadreID, c.Nombre as OpcionNombre, c.NombreCorto as OpcionNombreCorto, c.RecursoWebsite, 
		c.Activo as OpcionActivo, c.Protegido, c.Popup, c.VisibleMenu, c.Icono, c.Orden, 
		f.TipoOpcionID, f.Nombre as TipoOpcionNombre, f.NombreCorto as TipoOpcionNombreCorto, 
		h.AccionID, h.AccionClave, h.Nombre as AccionNombre, h.NombreCorto as AccionNombreCorto,
		d.RecursoWebSite as ModuloRecursoWebSite, d.Icono as ModuloIcono
FROM	vSeguridadUsuarioPerfil a
		LEFT OUTER JOIN SegPerfilOpcion b ON a.SegPerfilID = b.SegPerfilID
		LEFT OUTER JOIN SistemaOpcion c ON b.OpcionID = c.OpcionID
		LEFT OUTER JOIN SistemaModulo d ON c.ModuloID = d.ModuloID
		LEFT OUTER JOIN SistemaOpcionTipoOpcion e ON c.OpcionID = e.OpcionID
		LEFT OUTER JOIN SistemaTipoOpcion f ON e.TipoOpcionID = f.TipoOpcionID
		LEFT OUTER JOIN SistemaTipoOpcionAccion g ON f.TipoOpcionID = g.TipoOpcionID
		LEFT OUTER JOIN SistemaAccion h ON g.AccionID = h.AccionID
WHERE	a.Administrador = 0
UNION ALL
SELECT	a.SegUsuarioID, a.Nombre, a.Activo, a.Bloqueado, a.Administrador,
		a.SegPerfilID, a.PerfilNombre, a.PerfilNombreCorto,
		a.EmpresaID, a.EmpresaNombre, a.EmpresaNombreCorto,
		c.OpcionID, c.ModuloID, d.ModuloClave, d.Nombre as ModuloNombre, d.NombreCorto as ModuloNombreCorto, 
		c.PadreID, c.Nombre as OpcionNombre, c.NombreCorto as OpcionNombreCorto, c.RecursoWebsite, 
		c.Activo as OpcionActivo, c.Protegido, c.Popup, c.VisibleMenu, c.Icono, c.Orden,
		f.TipoOpcionID, f.Nombre as TipoOpcionNombre, f.NombreCorto as TipoOpcionNombreCorto,
		h.AccionID, h.AccionClave, h.Nombre as AccionNombre, h.NombreCorto as AccionNombreCorto,
		d.RecursoWebSite as ModuloRecursoWebSite, d.Icono as ModuloIcono
FROM	vSeguridadUsuarioPerfil a
		CROSS JOIN SistemaOpcion c 
		LEFT OUTER JOIN SistemaModulo d ON c.ModuloID = d.ModuloID
		LEFT OUTER JOIN SistemaOpcionTipoOpcion e ON c.OpcionID = e.OpcionID
		LEFT OUTER JOIN SistemaTipoOpcion f ON e.TipoOpcionID = f.TipoOpcionID
		LEFT OUTER JOIN SistemaTipoOpcionAccion g ON f.TipoOpcionID = g.TipoOpcionID
		LEFT OUTER JOIN SistemaAccion h ON g.AccionID = h.AccionID
WHERE	a.Administrador = 1