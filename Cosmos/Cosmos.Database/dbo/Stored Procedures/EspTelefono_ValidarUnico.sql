

CREATE PROCEDURE [dbo].[EspTelefono_ValidarUnico]
@ClaveTelefonicaPais varchar(10),
@NumeroTelefonico varchar(10)
AS
DECLARE @TelefonoID int, @Asignado int
SET @TelefonoID = (SELECT EspTelefonoID FROM EspTelefono WHERE ClaveTelefonicaPais = @ClaveTelefonicaPais and NumeroTelefonico = @NumeroTelefonico)
SELECT T.EspTelefonoID, T.ClaveTelefonicaPais, T.NumeroTelefonico,T.SistemaEstatusTelefonoID,T.Comentario,T.CfgTipoTelefonoID,
		tpt.Nombre as TipoTelefonoNombre, et.Nombre as EstatusTelefonoNombre
FROM EspTelefono T
inner join CfgTipoTelefono tpt on T.CfgTipoTelefonoID = tpt.CfgTipoTelefonoID
inner join SistemaEstatusTelefono et on T.SistemaEstatusTelefonoID = et.EstatusTelefonoID

WHERE EspTelefonoID = @TelefonoID