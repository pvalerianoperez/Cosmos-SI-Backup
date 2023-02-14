

CREATE PROCEDURE Sistema_EstatusTelefono_Consultar
@EstatusTelefonoID int
AS

SELECT  EstatusTelefonoID,EstatusTelefonoClave,Nombre,NombreCorto
FROM    SistemaEstatusTelefono
WHERE   EstatusTelefonoID = @EstatusTelefonoID