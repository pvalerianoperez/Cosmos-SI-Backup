CREATE PROCEDURE Seguridad_Perfil_ConsultarOpciones
@PerfilID int
AS


SELECT	a.OpcionID, a.ModuloID, COALESCE(a.PadreID, (1000+a.ModuloID)) as PadreID, a.Nombre, a.NombreCorto, a.RecursoWebsite, a.Activo, a.Protegido, a.Popup, a.VisibleMenu, a.Icono, a.Orden, 
		(CASE WHEN b.PerfilID IS NULL THEN 0 ELSE 1 END) as Permiso
INTO	#Opciones
FROM	SistemaOpcion a
		LEFT OUTER JOIN SistemaPerfilOpcion b ON a.OpcionID = b.OpcionID AND b.PerfilID = @PerfilID

INSERT	INTO #Opciones
SELECT	(1000 + ModuloID) as OpcionID, ModuloID, NULL as PadreID, Nombre, NULL as NombreCorto, NULL as RecursoWebSite, 1 as Activo, 1 as Protegido, 0 as Popup, 0 as VisibleMenu, NULL as Icono, 
		NULL as Orden, 
		1 as Permiso
FROM	SistemaModulo



SELECT	* 
FROM	#Opciones
WHERE	Activo = 1 
ORDER	BY PadreID, COALESCE(Orden, 9999), Nombre

DROP TABLE #Opciones