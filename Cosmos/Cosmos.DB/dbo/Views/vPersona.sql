
CREATE VIEW [dbo].[vPersona]
AS
SELECT	a.*, 
		(CASE WHEN a.FisicaMoral = 'F' THEN LTRIM(RTRIM((LTRIM(RTRIM(COALESCE(Nombre, ''))) + ' ' + LTRIM(RTRIM(COALESCE(ApellidoPaterno, ''))) + ' ' + LTRIM(RTRIM(COALESCE(ApellidoMaterno, ''))))))
		WHEN a.FisicaMoral = 'M' THEN COALESCE(NULLIF(NombreComercial,''), RazonSocial) END) AS NombreCompleto
FROM	EspPersona a