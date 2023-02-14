

CREATE PROCEDURE [dbo].[EspPersona_ValidarNombreUnico]
@Nombre varchar(30),
@ApellidoPaterno varchar(30),
@ApellidoMaterno varchar(30)
AS
DECLARE @PersonaID int, @Asignado int
--SET @PersonaID = (SELECT PersonaID FROM Persona WHERE RazonSocial = @RazonSocial Group by PersonaID)
SELECT P.EspPersonaID, P.RFC, P.CURP, P.FechaNacimiento,P.AuxEstadoCivilID, ec.Nombre as EstadoCivilNombre,P.Nombre,
P.ApellidoPaterno, P.ApellidoMaterno, P.*
FROM EspPersona P
inner join AuxEstadoCivil ec on P.AuxEstadoCivilID = ec.AuxEstadoCivilID
WHERE P.Nombre = @Nombre and P.ApellidoPaterno = @ApellidoPaterno and P.ApellidoMaterno = @ApellidoMaterno