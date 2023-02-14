

CREATE PROCEDURE [dbo].[EspPersona_ValidarRazonSocialUnico]
@RazonSocial varchar(10)
AS
DECLARE @PersonaID int, @Asignado int
--SET @PersonaID = (SELECT PersonaID FROM Persona WHERE RazonSocial = @RazonSocial Group by PersonaID)
SELECT P.EspPersonaID, P.RFC, P.CURP, P.FechaNacimiento,P.AuxEstadoCivilID, ec.Nombre as EstadoCivilNombre,P.*
FROM EspPersona P
inner join AuxEstadoCivil ec on P.AuxEstadoCivilID = ec.AuxEstadoCivilID
WHERE RazonSocial = @RazonSocial