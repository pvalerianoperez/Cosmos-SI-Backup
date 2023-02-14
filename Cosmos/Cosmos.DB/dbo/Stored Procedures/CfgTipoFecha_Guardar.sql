CREATE PROCEDURE [dbo].[CfgTipoFecha_Guardar]
@CfgTipoFechaID int,
@CfgTipoFechaClave varchar(10) = null,
@Nombre varchar(40) = null,
@NombreCorto varchar(15) = null,
@Estatus bit,
@TipoFechaID int
-- Parámetros para Bitácora
	,@UsuarioIDBitacora		int
	,@DescripcionBitacora	varchar(500)	= null
	,@IpAddress				varchar(40)		= null
	,@HostName				varchar(50)		= null

AS
-- Variables para manejo de Errores
DECLARE @Errores int = 0,						@Mensaje nvarchar(500) = '',				@IDAActualizar int,
		@ClaveNoAsignado varchar(5),			@TituloMensaje varchar(100) = ''
-- Variables para Bitácora
DECLARE @TablaNombreBitacora   nvarchar(100) = 'CfgTipoFecha',	
		@Operacion	nvarchar(20) = '', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit
-- Variables para valores anteriores (Bitácora Update) 
DECLARE	@CfgTipoFechaClave_ nvarchar(10) = '',
		@Nombre_ nvarchar(60) = '',			
		@NombreCorto_ varchar(10) = '',
		@TipoFechaID_ int = 0,
		@Estatus_ bit = 0,
		@CfgTipoFechaID_ int = @CfgTipoFechaID

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION

	SET @IDAActualizar = @CfgTipoFechaID
	-- Lee ClaveNoAsignado y Títulos de mensajes de Parámetros Cosmos
	SELECT	@ClaveNoAsignado = IsNull(ClaveNoAsignado,''),	@TituloMensaje = IsNull(TituloMensajeRespuesta,'')
		FROM	SistemaParamCosmos;
	-- Si es UPDATE -> Lee valores anteriores de las columnas (Bitácora Update) 
	IF @IDAActualizar > 0
	BEGIN
		-- Lee ClaveNoAsignado de Parámetros Cosmos
		SELECT	@ClaveNoAsignado = IsNull(ClaveNoAsignado,'')
		  FROM	SistemaParamCosmos;
		-- Lee Valores anteriores para Bitácora
		SELECT	@CfgTipoFechaClave_ =	IsNull(CfgTipoFechaClave,''),
	 			@Nombre_ =				IsNull(Nombre,''),
				@NombreCorto_ =			IsNull(NombreCorto,''),
				@TipoFechaID_ =			IsNull(TipoFechaID,0),
				@Estatus_ =				IsNull(Estatus,0),
				@CfgTipoFechaID_ =		IsNull(CfgTipoFechaID,0)
		   FROM	CfgTipoFecha WHERE CfgTipoFechaID = @IDAActualizar
		-- Si no se encontró registro a actualizar -> error
		IF @@RowCount = 0
			SELECT @Errores = 999999, @Mensaje = CONCAT('No se encontró el ID a Actualizar:', ' ', @IDAActualizar),
					@TituloMensaje = 'Error de Inconsistencia de Información.';
		-- No se permite cambiar Clave cuando es igual a @ClaveNoAsignado
		IF @CfgTipoFechaClave_ = @ClaveNoAsignado and @CfgTipoFechaClave <> @ClaveNoAsignado
			SELECT @Errores = 999996, @Mensaje = CONCAT('No es permitido cambiar la clave ', @ClaveNoAsignado),
					@TituloMensaje = 'Error de Protección de Integridad.';
	END
	-- Si no hubo error (es INSERT o es UPDATE y existe el registro)
	IF @Errores = 0
	BEGIN
		-- Si la llave existe hace UPDATE y si no, hace INSERT
		IF @IDAActualizar > 0
		BEGIN
			UPDATE  CfgTipoFecha
			SET     CfgTipoFechaClave = @CfgTipoFechaClave,
					Nombre = @Nombre,
					NombreCorto = @NombreCorto,
					TipoFechaID = @TipoFechaID,
					Estatus = @Estatus
			WHERE   CfgTipoFechaID = @IDAActualizar
		END
		ELSE
		BEGIN        
			INSERT  INTO CfgTipoFecha(
					CfgTipoFechaClave,
					TipoFechaID,
					Nombre,
					NombreCorto,
					Estatus
					)
			VALUES  (
					@CfgTipoFechaClave,
					@TipoFechaID,
					@Nombre,
					@NombreCorto,
					@Estatus
					)
        
			SET     @IDAActualizar = SCOPE_IDENTITY()
		END

		IF @@RowCount > 0
		BEGIN
			/* Procesa Bitácora */
			-- Determina si fue UPDATE o INSERT
			IF @CfgTipoFechaID_ > 0  SET @Operacion = 'Update' 	
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
				SET @logMessage = Concat('CfgTipoFechaClave::', @CfgTipoFechaClave_, ':', @CfgTipoFechaClave, ';')
				SET @logMessage = Concat(@logMessage, 'Nombre::', @Nombre_, ':', @Nombre, ';')
				SET @logMessage = Concat(@logMessage, 'NombreCorto::', @NombreCorto_, ':', @NombreCorto, ';')
				SET @logMessage = Concat(@logMessage, 'Estatus::', @Estatus_, ':', @Estatus, ';')
				SET @logMessage = Concat(@logMessage, 'SistemaTipoFechaID::', @TipoFechaID_, ':', @TipoFechaID, ';')
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