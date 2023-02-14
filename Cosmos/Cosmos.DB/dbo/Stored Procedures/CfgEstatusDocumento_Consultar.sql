

CREATE PROCEDURE [dbo].[CfgEstatusDocumento_Consultar]
@CfgEstatusDocumentoID int
AS

SELECT  CfgEstatusDocumentoID,CfgEstatusDocumentoClave,Nombre,NombreCorto,SistemaEstatusTipoDocumentoID,Predeterminado
FROM    CfgEstatusDocumento
WHERE   CfgEstatusDocumentoID = @CfgEstatusDocumentoID