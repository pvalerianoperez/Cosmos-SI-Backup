

CREATE PROCEDURE [dbo].[SegUsuario_Guardar]
@SegUsuarioID int,		@CorreoElectronico nvarchar(150),		@Nombre nvarchar(150),
@Alias nvarchar(50),	@Contrasena nvarchar(50),				@Activo bit,
@Intentos tinyint,		@Bloqueado bit,							@UsuarioAD nvarchar(50),
@Administrador bit,		@UltimoAcceso datetime,					@UltimaEmpresaID int,
@UltimoModuloID int,	@UltimaOpcionID int,					@UltimaIP nvarchar(50),
@LinkFoto varchar(250), @EspPersonaID int

-- Parámetros para Bitácora
	,@UsuarioIDBitacora		int
	,@DescripcionBitacora	varchar(500)	= null
	,@IpAddress				varchar(40)		= null
	,@HostName				varchar(50)		= null	

AS
-- Variables para manejo de Respuesta
DECLARE @Errores int = 0,						@Mensaje nvarchar(500) = '',				@IDAActualizar int,
		@ClaveNoAsignado varchar(5),			@TituloMensaje varchar(100) = ''
-- Variables para Bitácora
DECLARE @TablaNombreBitacora   nvarchar(100) = 'SegUsuario',	
		@Operacion	nvarchar(20) = '', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit
-- Variables para valores anteriores (Bitácora Update) 
DECLARE	@CorreoElectronico_		nvarchar(150) = '',
		@Nombre_				nvarchar(150) = '',
		@Alias_					nvarchar(50) = '',
		@Activo_				bit = 0,
		@Intentos_				tinyint = 0,
		@Bloqueado_				bit = 0,
		@UsuarioAD_				nvarchar(50) = '',
		@Administrador_			bit = 0,
		@UltimoAcceso_			datetime = 0,
		@UltimaEmpresaID_		int = 0,
		@UltimoModuloID_		int = 0,
		@UltimaOpcionID_		int = 0,
		@UltimaIP_				nvarchar(50) = '',
		@SegUsuarioID_			int = @SegUsuarioID,
		@LinkFoto_				varchar(250) = '',
		@EspPersonaID_			int = 0

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION

	SET @IDAActualizar = @SegUsuarioID
	-- Si es UPDATE -> Lee valores anteriores de las columnas (Bitácora Update) 
	IF @IDAActualizar > 0
	BEGIN

		SELECT	@CorreoElectronico_ =	IsNull(CorreoElectronico,''),	@Nombre_ =				IsNull(Nombre,''),
				@Alias_ =				IsNull(Alias,''),				@Activo_ =				IsNull(Activo,0),
				@Intentos_ =			IsNull(Intentos,0),				@Bloqueado_ =			IsNull(Bloqueado,0),
				@UsuarioAD_ =			IsNull(UsuarioAD,''),			@Administrador_ =		IsNull(Administrador,0),
				@UltimoAcceso_ =		IsNull(UltimoAcceso,0),			@UltimaEmpresaID_ =		IsNull(UltimaEmpresaID,0),
				@UltimoModuloID_ =		IsNull(UltimoModuloID,0),		@UltimaOpcionID_ =		IsNull(UltimaOpcionID,0),
				@UltimaIP_ = IsNull(UltimaIP,''),						@LinkFoto_ = LinkFoto,	@EspPersonaID_ = EspPersonaID
		FROM	SegUsuario WHERE SegUsuarioID = @IDAActualizar
		-- Si no se encontró registro a actualizar -> error
		IF @@RowCount = 0
			SELECT @Errores = 999999, @Mensaje = CONCAT('No se encontró el ID a Actualizar: ', @IDAActualizar),
					@TituloMensaje = 'Error de Inconsistencia de Información.';
	END
	-- Si no hubo error (es INSERT o es UPDATE y existe el registro)
	IF @Errores = 0
	BEGIN
		-- Si la llave existe hace UPDATE y si no, hace INSERT
		IF @EspPersonaID = 0
			SET @EspPersonaID = NULL;
		IF @IDAActualizar > 0
		BEGIN
			UPDATE  SegUsuario
			SET     CorreoElectronico = @CorreoElectronico,			Nombre =          @Nombre,				Alias = @Alias,
					Contrasena =	CASE WHEN @Contrasena > '' THEN	PWDENCRYPT(@Contrasena) ELSE Contrasena END,	
					Activo =          @Activo,				Intentos = @Intentos,
					Bloqueado =			@Bloqueado,					UsuarioAD =       @UsuarioAD,			Administrador = @Administrador,
					UltimoAcceso =		@UltimoAcceso,				UltimaEmpresaID = @UltimaEmpresaID,		UltimoModuloID = @UltimoModuloID,
					UltimaOpcionID = @UltimaOpcionID,				UltimaIP = @UltimaIP,					LinkFoto = @LinkFoto,
					EspPersonaID = @EspPersonaID
			WHERE   SegUsuarioID = @IDAActualizar
		END
		ELSE
		BEGIN
			INSERT  INTO SegUsuario(
					CorreoElectronico,
					Nombre,
					Alias,
					Contrasena,
					Activo,
					Intentos,
					Bloqueado,
					UsuarioAD,
					Administrador,
					UltimoAcceso,
					UltimaEmpresaID,
					UltimoModuloID,
					UltimaOpcionID,
					UltimaIP,
					LinkFoto,
					EspPersonaID)
			VALUES  (
					@CorreoElectronico,
					@Nombre,
					@Alias,
					PWDENCRYPT(@Contrasena),
					@Activo,
					@Intentos,
					@Bloqueado,
					@UsuarioAD,
					@Administrador,
					@UltimoAcceso,
					@UltimaEmpresaID,
					@UltimoModuloID,
					@UltimaOpcionID,
					@UltimaIP,
					@LinkFoto,
					@EspPersonaID)
        
			SET     @IDAActualizar = SCOPE_IDENTITY()
		END

		IF @@RowCount > 0
		BEGIN
			/* Procesa Bitácora */
			-- Determina si fue UPDATE o INSERT
			IF @SegUsuarioID_ > 0  SET @Operacion = 'Update' 	
						ELSE SET @Operacion = 'Create' 

			-- Revisa si el cambio debe ser guardado en Bitácora
			EXEC	@isChangeBeLogged	=   SistemaLogRegla_Consultar_LogBit
					@UsuarioID			=	@UsuarioIDBitacora,
					@TablaNombre		=   @TablaNombreBitacora,
					@Operacion			=	@Operacion

			-- Si el cambio debe guardarse, prepara variables de Bitácora y lo guarda
			IF @isChangeBeLogged = 1 
			BEGIN
				-- logMessage = Cambios efectuados
				SET @logMessage = Concat('CorreoElectronico::', @CorreoElectronico_, ':', @CorreoElectronico, ';')
				SET @logMessage = Concat(@logMessage, 'Alias::', @Alias_, ':', @Alias, ';')
				SET @logMessage = Concat(@logMessage, 'Activo::', @Activo_, ':', @Activo, ';')
				SET @logMessage = Concat(@logMessage, 'Intentos::', @Intentos_, ':', @Intentos, ';')
				SET @logMessage = Concat('Bloqueado::', @Bloqueado_, ':', @Bloqueado, ';')
				SET @logMessage = Concat('UsuarioAD::', @UsuarioAD_, ':', @UsuarioAD, ';')
				SET @logMessage = Concat(@logMessage, 'Administrador::', @Administrador_, ':', @Administrador, ';')
				SET @logMessage = Concat(@logMessage, 'UltimoAcceso::', @UltimoAcceso_, ':', @UltimoAcceso, ';')
				SET @logMessage = Concat(@logMessage, 'UltimaEmpresaID::', @UltimaEmpresaID_, ':', @UltimaEmpresaID, ';')
				SET @logMessage = Concat('UltimoModuloID::', @UltimoModuloID_, ':', @UltimoModuloID, ';')
				SET @logMessage = Concat('UltimaOpcionID::', @UltimaOpcionID_, ':', @UltimaOpcionID, ';')
				SET @logMessage = Concat(@logMessage, 'UltimaIP::', @UltimaIP_, ':', @UltimaIP, ';')
				SET @logMessage = Concat(@logMessage, 'LinkFoto::', @LinkFoto_, ':', @LinkFoto, ';')
				SET @logMessage = Concat(@logMessage, 'EspPersonaID::', @EspPersonaID_, ':', @EspPersonaID, ';')
				PRINT @logMessage
				-- Guarda en Bitácora
				EXEC 	 [dbo].[SistemaLog_Guardar] @TablaNombre		= @TablaNombreBitacora
														,@TablaID			= @IDAActualizar
														,@TablaColumna1		= ''
														,@TablaColumna2		= ''
														,@Operacion			= @Operacion
														,@UsuarioID			= @UsuarioIDBitacora
														,@Descripcion		= @DescripcionBitacora
														,@Cambios			= @logMessage
														,@IpAddress			= @IpAddress
														,@HostName			= @HostName
			END
		END
		-- Fin de proceso sin errores -> COMMIT
		COMMIT TRANSACTION
	END
END TRY
-- Si hubo error los procesa y lo regresa
BEGIN CATCH
    SELECT @Errores = ERROR_NUMBER(), 
			@Mensaje = dbo.FDecodificaError(ERROR_NUMBER(), ERROR_MESSAGE(), ERROR_SEVERITY(), ERROR_STATE(), ERROR_PROCEDURE(), ERROR_LINE())
END CATCH 
IF (XACT_STATE()) = -1 ROLLBACK TRANSACTION;
IF (XACT_STATE()) = 1 COMMIT TRANSACTION;

SELECT  COALESCE(@Errores, 0) as Errores, 
        COALESCE(@Mensaje, '') as Mensaje,
		COALESCE(ERROR_SEVERITY(), 0) as Severidad,
		COALESCE(ERROR_STATE(), 0) as Estado,
		COALESCE(ERROR_PROCEDURE(), '') as ProcedimientoAlmacenado,
		COALESCE(ERROR_LINE(), 0) as Linea,
		@IDAActualizar as GuardarID