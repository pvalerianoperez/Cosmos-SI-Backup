

CREATE PROCEDURE [dbo].[EspTelefono_Guardar]
--@ModificacionUsuarioID int = null,
@TelefonoID int,
@ClaveTelefonicaPais varchar(3),
@NumeroTelefonico varchar(10),
@EstatusTelefonoID int,
@CfgTipoTelefonoID int,
@Comentario varchar(100)
-- Parámetros para Bitácora
	,@UsuarioIDBitacora	int
	,@DescripcionBitacora		varchar(500)	= null
	,@IpAddress			varchar(40)		= null
	,@HostName			varchar(50)		= null
AS
-- Variables para manejo de Errores
DECLARE @Errores int = 0, @Mensaje nvarchar(500) = '', @IDAActualizar int, @ClaveNoAsignado varchar(5)
-- Variables para Bitácora
DECLARE @TablaNombreIDBitacora   nvarchar(100) = 'EspTelefono',	
		@Operacion	nvarchar(20) = '', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit
-- Variables para valores anteriores (Bitácora Update) 
DECLARE	@ClaveTelefonicaPais_ varchar(3)='',
		@NumeroTelefonico_ varchar(10)='',
		@EstatusTelefonoID_ int =0,
		@CfgTipoTelefonoID_ int =0,
		@Comentario_ varchar(100)='',
		@TelefonoID_ int = @TelefonoID

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION

	SET @IDAActualizar = @TelefonoID
	-- Si es UPDATE -> Lee valores anteriores de las columnas (Bitácora Update) 
	IF @IDAActualizar > 0
	BEGIN
		-- Lee ClaveNoAsignado de Parámetros Cosmos
		SELECT	@ClaveNoAsignado = IsNull(ClaveNoAsignado,'')
		  FROM	SistemaParamCosmos;
		-- Lee Valores anteriores para Bitácora
		SELECT	@ClaveTelefonicaPais_ =IsNull(ClaveTelefonicaPais,''),
				@NumeroTelefonico_ =IsNull(NumeroTelefonico,''),
				@EstatusTelefonoID_ = IsNull(SistemaEstatusTelefonoID,0),
				@CfgTipoTelefonoID_ = IsNull(CfgTipoTelefonoID,0),
				@Comentario_ =IsNull(Comentario,'')
		   FROM	EspTelefono WHERE EspTelefonoID = @IDAActualizar
		-- Si no se encontró registro a actualizar -> error
		IF @@RowCount = 0
			SELECT @Errores = 999999, @Mensaje = CONCAT('No se encontró el ID a Actualizar: ', @IDAActualizar);
		-- No se permite cambiar Clave cuando es igual a @ClaveNoAsignado
		--IF @PpalAreaClave_ = @ClaveNoAsignado and @PpalAreaClave <> @ClaveNoAsignado
		--	SELECT @Errores = 999996, @Mensaje = CONCAT('No es permitido cambiar la clave ', @ClaveNoAsignado);
	END
	-- Si no hubo error (es INSERT o es UPDATE y existe el registro)
	IF @Errores = 0
	BEGIN
		-- Si la llave existe hace UPDATE y si no, hace INSERT
		IF @IDAActualizar > 0
		BEGIN
			UPDATE  EspTelefono
			SET     ClaveTelefonicaPais = @ClaveTelefonicaPais,
					NumeroTelefonico = @NumeroTelefonico,
					SistemaEstatusTelefonoID = @EstatusTelefonoID,
					CfgTipoTelefonoID = @CfgTipoTelefonoID,
					Comentario = @Comentario
			WHERE   EspTelefonoID = @TelefonoID
		END
		ELSE
		BEGIN        
			INSERT  INTO EspTelefono(
					ClaveTelefonicaPais,
					NumeroTelefonico,
					SistemaEstatusTelefonoID,
					CfgTipoTelefonoID,
					Comentario)
			VALUES  (
					@ClaveTelefonicaPais,
					@NumeroTelefonico,
					@EstatusTelefonoID,
					@CfgTipoTelefonoID,
					@Comentario)
        
			SET     @TelefonoID = SCOPE_IDENTITY()
		END
  IF @@RowCount > 0
		BEGIN
			/* Procesa Bitácora */
			-- Determina si fue UPDATE o INSERT
			IF @TelefonoID_ > 0  SET @Operacion = 'Update' 	
						ELSE SET @Operacion = 'Create' 

			-- Revisa si el cambio debe ser guardado en Bitácora
			EXEC	@isChangeBeLogged	=   SistemaLogRegla_Consultar_LogBit
					@UsuarioID			=	@UsuarioIDBitacora,
					@TablaNombre		=   @TablaNombreIDBitacora,
					@Operacion			=	@Operacion

			-- Si el cambio debe guardarse, prepara variables de Bitácora y lo guarda
			IF @isChangeBeLogged = 1 
			BEGIN
				-- logMessage = Cambios efectuados
				SET @logMessage = Concat('ClaveTelefonicaPais::', @ClaveTelefonicaPais_, ':', @ClaveTelefonicaPais, ';')
				SET @logMessage = Concat(@logMessage, 'NumeroTelefonico::', @NumeroTelefonico_, ':', @NumeroTelefonico, ';')
				SET @logMessage = Concat(@logMessage, 'EstatusTelefonoID::', @EstatusTelefonoID_, ':', @EstatusTelefonoID, ';')
				SET @logMessage = Concat(@logMessage, 'CfgTipoTelefonoID::', @CfgTipoTelefonoID_, ':', @CfgTipoTelefonoID, ';')
				SET @logMessage = Concat(@logMessage, 'Comentario::', @Comentario_, ':', @Comentario, ';')
				-- Guarda en Bitácora
				EXEC 	 [dbo].[SistemaLog_Guardar] @TablaNombre		= @TablaNombreIDBitacora
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