
CREATE VIEW [dbo].[vSeguridad]
AS
SELECT	M.ModuloID,		M.ModuloClave,		M.Nombre as ModuloNombre,		M.NombreCorto as ModuloNombreCorto,
		O.OpcionID,							O.Nombre as OpcionNombre,		O.NombreCorto as OpcionNombreCorto,		O.Orden,
		A.AccionID,		A.AccionClave,		A.Nombre as AccionNombre,		A.NombreCorto as AccionNombreCorto,
		P.SegPerfilID,	P.SegPerfilClave,	P.Nombre as PerfilNombre,		P.NombreCorto as PerfilNombreCorto, 
		U.SegUsuarioID,						U.Nombre as UsuarioNombre,		U.Activo,			U.Bloqueado,		U.Administrador,
		E.EmpresaID,	E.EmpresaClave,		E.Nombre as EmpresaNombre,		E.NombreCorto as EmpresaNombreCorto	
		---Prueba de Vista---
		,O.PadreID,
		O.RecursoWebsite,								O.Protegido,		O.Popup,								O.VisibleMenu,
		O.Icono
		---Termina Prueba-----
FROM	SegUsuarioPerfil UP
		LEFT OUTER JOIN SegPerfilOpcion PO ON UP.SegPerfilID = PO.SegPerfilID
		LEFT OUTER JOIN SegPerfilOpcionAccion POA ON PO.SegPerfilOpcionID = POA.SegPerfilOpcionID
		LEFT OUTER JOIN SegPerfil P ON UP.SegPerfilID = P.SegPerfilID
		LEFT OUTER JOIN SistemaOpcion O ON PO.OpcionID = O.OpcionID
		LEFT OUTER JOIN SistemaModulo M ON M.ModuloID = O.ModuloID
		LEFT OUTER JOIN SistemaAccion A ON POA.AccionID = A.AccionID
		LEFT OUTER JOIN SegUsuario U ON UP.SegUsuarioID = U.SegUsuarioID
		LEFT OUTER JOIN SistemaEmpresa E ON UP.EmpresaID = E.EmpresaID
UNION
SELECT	M.ModuloID,		M.ModuloClave,		M.Nombre as ModuloNombre,		M.NombreCorto as ModuloNombreCorto,
		O.OpcionID,							O.Nombre as OpcionNombre,		O.NombreCorto as OpcionNombreCorto,		O.Orden,
		A.AccionID,		A.AccionClave,		A.Nombre as AccionNombre,		A.NombreCorto as AccionNombreCorto,
		NULL,	NULL,	NULL as PerfilNombre,		NULL as PerfilNombreCorto, 
		NULL,						NULL as UsuarioNombre,		NULL,			NULL,		NULL,
		NULL,	NULL,		NULL as EmpresaNombre,		NULL as EmpresaNombreCorto	
		---Prueba de Vista---
		,O.PadreID,
		O.RecursoWebsite,								O.Protegido,		O.Popup,								O.VisibleMenu,
		O.Icono
		---Termina Prueba-----
FROM	SistemaModulo M
		LEFT OUTER JOIN SistemaOpcion O ON M.ModuloID = O.ModuloID
		LEFT OUTER JOIN SistemaOpcionTipoOpcion OTo ON O.OpcionID = OTo.OpcionID
		LEFT OUTER JOIN SistemaTipoOpcion TiO ON OTo.TipoOpcionID = TiO.TipoOpcionID
		LEFT OUTER JOIN SistemaTipoOpcionAccion ToA ON OTo.TipoOpcionID = ToA.TipoOpcionID
		LEFT OUTER JOIN SistemaAccion A ON ToA.AccionID = A.AccionID