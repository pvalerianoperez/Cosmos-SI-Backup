CREATE VIEW vSeguridadUsuarioPerfil
AS

SELECT	a.SegUsuarioID, a.Nombre, a.Activo, a.Bloqueado, a.Administrador, 
		b.SegPerfilID, c.Nombre as PerfilNombre, c.NombreCorto as PerfilNombreCorto,
		b.EmpresaID, d.Nombre as EmpresaNombre, d.NombreCorto as EmpresaNombreCorto
FROM	SegUsuario a
		LEFT OUTER JOIN SegUsuarioPerfil b ON a.SegUsuarioID = b.SegUsuarioID
		LEFT OUTER JOIN SegPerfil c ON b.SegPerfilID = c.SegPerfilID
		LEFT OUTER JOIN SistemaEmpresa d ON b.EmpresaID = d.EmpresaID
WHERE	COALESCE(a.Administrador,0) = 0
UNION ALL
SELECT	a.SegUsuarioID, a.Nombre, a.Activo, a.Bloqueado, a.Administrador, 
		b.SegPerfilID, b.Nombre, b.NombreCorto, c.EmpresaID, c.Nombre, c.NombreCorto
FROM	SegUsuario a
		CROSS JOIN SegPerfil b
		CROSS JOIN SistemaEmpresa c 
WHERE	COALESCE(a.Administrador,0) = 1