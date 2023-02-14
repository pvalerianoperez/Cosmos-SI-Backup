
CREATE PROCEDURE [dbo].[PpalProveedorDomicilio_ListadoProveedorID]
@PpalProveedorID int
AS


SELECT	PD.PpalProveedorDomicilioID,		PD.PpalProveedorID,			PD.EspDomicilioID, 
		PD.Comentario,					PD.CfgTipoDomicilioID,		STD.Nombre as TipoDomicilioNombre,
		PD.Predeterminado,
		(select CONCAT( d.Calle, ' ', d.NumeroExterior, ' ', 
			CASE WHEN d.NumeroInterior > '' THEN '- ' + d.NumeroInterior + ' ' END, 
			', Col. ', C.Nombre, ' C.P.: ', CodigoPostal)) as DomicilioSemiCompleto,
		(select CONCAT(Ciu.Nombre,',',E.Nombre,',',P.Nombre))as CiudadCompleta, 
		STD.Nombre as TipoDomicilioNombre, P.EspPaisID as EspPaisID
FROM	PpalProveedorDomicilio PD
inner join SistemaTipoDomicilio STD on PD.CfgTipoDomicilioID = STD.SistemaTipoDomicilioID
inner join EspDomicilio D on PD.EspDomicilioID = D.EspDomicilioID
inner join EspColonia C on D.EspColoniaID = C.EspColoniaID
inner join EspCiudad Ciu on D.EspCiudadID = Ciu.EspCiudadID
inner join EspMunicipio M on Ciu.EspMunicipioID = M.EspMunicipioID
inner join EspEstado E on M.EspEstadoID = E.EspEstadoID
inner join EspPais P on E.EspPaisID = P.EspPaisID
WHERE	PpalProveedorID = @PpalProveedorID