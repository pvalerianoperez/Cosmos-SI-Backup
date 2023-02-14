

CREATE PROCEDURE Sistema_EstatusDocumento_Consultar
@SistemaEstatusDocumentoID int
AS

SELECT  SistemaEstatusDocumentoID,SistemaEstatusDocumentoClave,Nombre,NombreCorto
FROM    SistemaEstatusDocumento
WHERE   SistemaEstatusDocumentoID = @SistemaEstatusDocumentoID