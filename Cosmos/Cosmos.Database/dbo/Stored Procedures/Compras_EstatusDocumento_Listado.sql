﻿

CREATE PROCEDURE Compras_EstatusDocumento_Listado
AS

SELECT  EstatusDocumentoID,EstatusDocumentoClave,Nombre,NombreCorto,SistemaEstatusTipoDocumentoID,Predeterminado
FROM    EstatusDocumento