



CREATE VIEW [dbo].[vDomicilio] 
AS

SELECT	a.EspDomicilioID, a.Calle, a.NumeroExterior, a.NumeroInterior, a.EntreCalle1, a.EntreCalle2, a.CodigoPostal, c.Nombre as ColoniaNombre, a.Coordenadas, 
		b.EspCiudadID,
		UPPER(RTRIM(LTRIM((
		RTRIM(LTRIM(COALESCE(Calle, ''))) + ' ' + 
		RTRIM(LTRIM(COALESCE(NumeroExterior, ''))) + ' ' + 
		RTRIM(LTRIM(COALESCE(NumeroInterior, ''))) + ' ' + 
		(CASE RTRIM(LTRIM(COALESCE(c.Nombre, ''))) WHEN '' THEN '' ELSE 'COL. ' + RTRIM(LTRIM(COALESCE(c.Nombre, ''))) END) + ' '  +
		(CASE RTRIM(LTRIM(COALESCE(CodigoPostal, ''))) WHEN '' THEN '' ELSE 'C.P. ' + RTRIM(LTRIM(COALESCE(CodigoPostal, ''))) END) + ' '  +
		b.NombreCompleto
		)))) as DomicilioCompleto
FROM	EspDomicilio a 
		LEFT OUTER JOIN EspColonia c ON a.EspColoniaID = c.EspColoniaID
		LEFT OUTER JOIN vCiudad b ON a.EspCiudadID = b.EspCiudadID