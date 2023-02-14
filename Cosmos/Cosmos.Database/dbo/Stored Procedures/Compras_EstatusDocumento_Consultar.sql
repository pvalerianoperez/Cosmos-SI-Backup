

CREATE PROCEDURE Compras_EstatusDocumento_Consultar
@EstatusDocumentoID int
AS

SELECT  EstatusDocumentoID,EstatusDocumentoClave,Nombre,NombreCorto,SistemaEstatusTipoDocumentoID,Predeterminado
FROM    EstatusDocumento
WHERE   EstatusDocumentoID = @EstatusDocumentoID