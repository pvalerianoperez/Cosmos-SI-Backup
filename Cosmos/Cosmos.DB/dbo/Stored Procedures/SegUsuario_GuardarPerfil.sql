
CREATE PROCEDURE [dbo].[SegUsuario_GuardarPerfil]
@SegUsuarioID int,
@EmpresaID int,
@SegPerfilID int
AS

SET NOCOUNT ON 

DECLARE @Errores bit, @Mensaje nvarchar(300)

BEGIN TRANSACTION 
BEGIN TRY

	DELETE 
	FROM	SegUsuarioPerfil
	WHERE	SegUsuarioID = @SegUsuarioID
	AND		SegPerfilID = @SegPerfilID
	AND		EmpresaID = @EmpresaID
    
	INSERT	INTO SegUsuarioPerfil(SegUsuarioID, EmpresaID, SegPerfilID)
	VALUES	(@SegUsuarioID, @EmpresaID, @SegPerfilID)

	    
    COMMIT TRANSACTION
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION
    SELECT @Errores = 1, @Mensaje = ERROR_MESSAGE()
END CATCH 

SELECT  COALESCE(@Errores, 0) as Errores, 
        COALESCE(@Mensaje, '') as Mensaje,
        @SegUsuarioID as SegUsuarioID