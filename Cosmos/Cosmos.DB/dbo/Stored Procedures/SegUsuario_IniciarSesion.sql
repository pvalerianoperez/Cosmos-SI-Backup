



CREATE PROCEDURE [dbo].[SegUsuario_IniciarSesion]
@CorreoElectronico nvarchar(150), 
@Contrasena nvarchar(50),
@IP nvarchar(50) = '?'
AS
SET NOCOUNT ON 

DECLARE @Errores bit, @Mensaje nvarchar(300)
SELECT @Errores = 0, @Mensaje = ''

--BEGIN TRANSACTION 
BEGIN TRY
	DECLARE @SegUsuarioID int
	SELECT	@SegUsuarioID = SegUsuarioID FROM SegUsuario WHERE CorreoElectronico = @CorreoElectronico
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
			--revisa la contraseña primero
			IF NOT EXISTS(SELECT SegUsuarioID FROM SegUsuario WHERE SegUsuarioID = @SegUsuarioID AND PWDCOMPARE(@Contrasena, Contrasena) = 1)
			BEGIN
				-- la contraseña no coincide, pero el usuario SI existe			
				IF @MaximoIntentosLogin > 0 AND @Intentos >= @MaximoIntentosLogin 
				BEGIN
					--en la configuracion se definio un maximo de intentos y ya se llego a ese numero, bloquea al usuario
					UPDATE	SegUsuario SET Bloqueado = 1, Intentos = 0 WHERE SegUsuarioID = @SegUsuarioID
					SELECT @Errores = 1, @Mensaje = 'La cuenta del usuario se encuentra bloqueada por seguridad, contacte al administrador.'
				END
				ELSE
				BEGIN				
					UPDATE	SegUsuario SET Intentos = COALESCE(Intentos, 0) + 1 WHERE SegUsuarioID = @SegUsuarioID
					INSERT	INTO SistemaUsuarioIntentos(UsuarioID, Fecha, IP, Contrasena) VALUES(@SegUsuarioID, GETDATE(), @IP, @Contrasena)
					SELECT @Errores = 1, @Mensaje = 'El usuario no existe o la contraseña es incorrecta.'
				END			
			END
		END

		-- si no hubo errores...
		IF @Errores = 0 
		BEGIN
			UPDATE	SegUsuario
			SET		UltimoAcceso = GETDATE(), 
					Intentos = 0, 
					Bloqueado = 0, 
					UltimaIP = @IP
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