


CREATE VIEW [dbo].[vCiudad] 
AS

SELECT	a.EspCiudadID, a.EspCiudadClave, a.Nombre as CiudadNombre, a.NombreCorto as CiudadNombreCorto, 
		b.EspMunicipioID, b.EspMunicipioClave, b.Nombre as MunicipioNombre, b.NombreCorto as MunicipioNombreCorto,
		c.EspEstadoID, c.EspEstadoClave, c.Nombre as EstadoNombre, c.NombreCorto as EstadoNombreCorto,
		d.EspPaisID, d.EspPaisClave, d.Nombre as PaisNombre, d.NombreCorto as PaisNombreCorto,
		(a.Nombre + ', ' + b.Nombre  + ', ' + c.Nombre  + ', ' + d.Nombre) as NombreCompleto
FROM	EspCiudad a 
		INNER JOIN EspMunicipio b  ON a.EspMunicipioID = b.EspMunicipioID
		INNER JOIN EspEstado c ON b.EspEstadoID = c.EspEstadoID
		INNER JOIN EspPais d ON c.EspPaisID = d.EspPaisID