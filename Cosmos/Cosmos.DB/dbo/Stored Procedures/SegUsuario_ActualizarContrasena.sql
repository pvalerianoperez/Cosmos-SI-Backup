



CREATE PROCEDURE [dbo].[SegUsuario_ActualizarContrasena]
@SegUsuarioID int, 
@Contrasena nvarchar(50),
@IP nvarchar(50) = '?'
AS
SET NOCOUNT ON 

DECLARE @Errores bit, @Mensaje nvarchar(300)
SELECT @Errores = 0, @Mensaje = ''

--BEGIN TRANSACTION 
BEGIN TRY
	
	SELECT	@SegUsuarioID = SegUsuarioID FROM SegUsuario WHERE SegUsuarioID = @SegUsuarioID
	SET @SegUsuarioID = COALESCE(@SegUsuarioID, 0)
    IF @SegUsuarioID > 0 
    BEGIN
		DECLARE @Activo bit, @Intentos tinyint, @Bloqueado bit, @MaximoIntentosLogin tinyint
		SELECT	@Activo = Activo, @Intentos = Intentos, @Bloqueado = Bloqueado FROM SegUsuario WHERE SegUsuarioID = @SegUsuarioID
		SELECT	TOP 1 @MaximoIntentosLogin = MaximoIntentosLogin FROM SistemaConfiguracion WHERE COALESCE(Activa,0) = 1
		SET @MaximoIntentosLogin = COALESCE(@MaximoIntentosLogin, 0)

		-- revisa si el usuario esta bloqueado
		IF @Errores = 0 
		BEGIN			
			IF @Bloqueado = 1 
			BEGIN
				SELECT @Errores = 1, @Mensaje = 'La cuenta del usuario se encuentra bloqueada por seguridad, contacte al administrador.'
			END
		END
		-- revisa si el usuario esta inactivo
		IF @Errores = 0 
		BEGIN			
			IF @Activo = 0 
			BEGIN
				SELECT @Errores = 1, @Mensaje = 'La cuenta del usuario se encuentra desactivada, contacte al administrador.'
			END
		END

		IF @Errores = 0
		BEGIN			
			UPDATE	SegUsuario
			SET		Contrasena = PWDENCRYPT(@Contrasena)
			WHERE	SegUsuarioID = @SegUsuarioID
		END

    END
    ELSE
    BEGIN        
        SELECT @Errores = 1, @Mensaje = 'El usuario no existe.'       
    END
    --COMMIT TRANSACTION
END TRY
BEGIN CATCH
    --ROLLBACK TRANSACTION
    SELECT @Errores = 1, @Mensaje = ERROR_MESSAGE()
END CATCH 

IF @Errores = 1 
BEGIN
	SET @SegUsuarioID = 0
END

IF @SegUsuarioID = 0 
BEGIN
	SELECT  COALESCE(@Errores, 0) as Errores, 
			COALESCE(@Mensaje, '') as Mensaje,
			@SegUsuarioID as SegUsuarioID
END
ELSE
BEGIN
	SELECT  COALESCE(@Errores, 0) as Errores, 
			COALESCE(@Mensaje, '') as Mensaje,
			SegUsuarioID, CorreoElectronico, 
			Nombre, Alias, UsuarioAD, UltimoAcceso, 
			Administrador, UltimaEmpresaID, UltimoModuloID, UltimaOpcionID
	FROM	SegUsuario
	WHERE	SegUsuarioID = @SegUsuarioID			
END
SET NOCOUNT OFF