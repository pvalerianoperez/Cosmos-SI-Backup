

CREATE PROCEDURE [dbo].[EspDomicilio_ValidarUnico]
@CodigoPostal int,
@NumeroInterior varchar (20),
@NumeroExterior varchar (20),
@CiudadID int 

AS
DECLARE @DomicilioID int
SET @DomicilioID = (SELECT EspDomicilioID FROM EspDomicilio 
					WHERE CodigoPostal = @CodigoPostal and NumeroInterior = @NumeroInterior and NumeroExterior = @NumeroExterior and
						EspCiudadID = @CiudadID)

SELECT EspDomicilioID
FROM EspDomicilio
Where CodigoPostal = @CodigoPostal and NumeroInterior = @NumeroInterior and NumeroExterior = @NumeroExterior and
		EspCiudadID = @CiudadID