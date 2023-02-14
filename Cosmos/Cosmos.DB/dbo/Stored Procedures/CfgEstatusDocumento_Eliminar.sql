﻿

CREATE PROCEDURE [dbo].[CfgEstatusDocumento_Eliminar]
@ModificacionUsuarioID int = null,
@CfgEstatusDocumentoID int
AS

SET NOCOUNT ON 

DECLARE @Errores bit, @Mensaje nvarchar(300)

BEGIN TRANSACTION 
BEGIN TRY
    DELETE
    FROM    CfgEstatusDocumento
    WHERE   CfgEstatusDocumentoID = @CfgEstatusDocumentoID
    
    COMMIT TRANSACTION
    SELECT @Errores = 0, @Mensaje = ''
END TRY
BEGIN CATCH 
    ROLLBACK TRANSACTION
    SELECT @Errores = 1, @Mensaje = ERROR_MESSAGE()
END CATCH 

SELECT  COALESCE(@Errores, 0) as Errores, 
        COALESCE(@Mensaje, '') as Mensaje

SET NOCOUNT OFF