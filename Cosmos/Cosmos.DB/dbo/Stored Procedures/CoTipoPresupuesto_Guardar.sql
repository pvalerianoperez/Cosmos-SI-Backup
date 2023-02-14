
CREATE PROCEDURE [dbo].[CoTipoPresupuesto_Guardar]
@CoTipoPresupuestoID int,
@CoTipoPresupuestoClave varchar(10) = null,
@Nombre varchar(80) = null,
@NombreCorto varchar(12) = null,
@CoProyectoID int,
@NivelPartida tinyint,
@NivelCalendario tinyint,
@CfgEstatusDocumentoID int,
@CoTipoPresupuestoBaseID int,
@CoTipoConstruccionID int

-- Parámetros para Bitácora
	,@UsuarioIDBitacora	int
	,@DescripcionBitacora		varchar(500)	= null
	,@IpAddress			varchar(40)		= null
	,@HostName			varchar(50)		= null
/************************************************/
AS
-- Variables para manejo de Respuesta
DECLARE @Errores int = 0,						@Mensaje nvarchar(500) = '',				@IDAActualizar int,
		@ClaveNoAsignado varchar(5),			@TituloMensaje varchar(100) = ''
-- Variables para Bitácora
DECLARE @TablaNombreBitacora   nvarchar(100) = 'CoTipoPresupuesto',	
		@Operacion	nvarchar(20) = '', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit
-- Variables para valores anteriores (Bitácora Update) 
DECLARE	@CoTipoPresupuestoClave_ nvarchar(10) = '',
		@CoTipoPresupuestoID_ int = @CoTipoPresupuestoID,
		@Nombre_ nvarchar(80) = '',			
		@NombreCorto_ varchar(12) = '',
		@CoProyectoID_ int = 0,
		@NivelPartida_ tinyint = 0,
		@NivelCalendario_ tinyint = 0,
		@CfgEstatusDocumentoID_ int = 0,
		@CoTipoPresupuestoBaseID_ int = 0,
		@CoTipoConstruccionID_ int = 0
		

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION

	SET @IDAActualizar = @CoTipoPresupuestoID
	-- Lee ClaveNoAsignado y Títulos de mensajes de Parámetros Cosmos
	SELECT	@ClaveNoAsignado = IsNull(ClaveNoAsignado,''),	@TituloMensaje = IsNull(TituloMensajeRespuesta,'')
		FROM	SistemaParamCosmos;
	-- Si es UPDATE -> Lee valores anteriores de las columnas (Bitácora Update) 
	IF @IDAActualizar > 0
	BEGIN
		-- Lee Valores anteriores para Bitácora
		SELECT	@CoTipoPresupuestoClave_ = IsNull(CoTipoPresupuestoClave,''),
				@CoTipoPresupuestoID_ = IsNull(CoTipoPresupuestoID,0),
	 			@Nombre_ = IsNull(Nombre,''),
				@NombreCorto_ = IsNull(NombreCorto,''),
				@CoProyectoID_ = IsNull(CoProyectoID,0),
				@NivelPartida_ = IsNull(NivelPartida,0),
				@NivelCalendario_ = IsNull(NivelCalendario,0),
				@CfgEstatusDocumentoID_ = IsNull(CfgEstatusDocumentoID,0),
				@CoTipoPresupuestoBaseID_ = IsNull(CoTipoPresupuestoBaseID,0),
				@CoTipoConstruccionID_ = IsNull(CoTipoConstruccionID,0)
		   FROM	CoTipoPresupuesto WHERE CoTipoPresupuestoID = @IDAActualizar
		-- Si no se encontró registro a actualizar -> error
		IF @@RowCount = 0
			SELECT @Errores = 999999, @Mensaje = CONCAT('No se encontró el ID a Actualizar: ', @IDAActualizar),
					@TituloMensaje = 'Error de Inconsistencia de Información.';
		-- No se permite cambiar Clave cuando es igual a @ClaveNoAsignado
		IF @CoTipoPresupuestoClave_ = @ClaveNoAsignado and @CoTipoPresupuestoClave <> @ClaveNoAsignado
			SELECT @Errores = 999996, @Mensaje = CONCAT('No es permitido cambiar la clave ', @ClaveNoAsignado),
					@TituloMensaje = 'Error de Protección de Integridad.';
	END
	-- Si no hubo error (es INSERT o es UPDATE y existe el registro)
	IF @Errores = 0
	BEGIN
		-- Si la llave existe hace UPDATE y si no, hace INSERT
		IF @IDAActualizar > 0
		BEGIN
			UPDATE  CoTipoPresupuesto
			SET     CoTipoPresupuestoClave = @CoTipoPresupuestoClave,
					Nombre = @Nombre,
					NombreCorto = @NombreCorto,
					CoProyectoID = @CoProyectoID,
					NivelPartida = @NivelPartida,
					NivelCalendario = @NivelCalendario,
					CfgEstatusDocumentoID = @CfgEstatusDocumentoID,
					CoTipoPresupuestoBaseID = @CoTipoPresupuestoBaseID,
					CoTipoConstruccionID = @CoTipoConstruccionID
					
			WHERE   CoTipoPresupuestoID = @IDAActualizar
		END
		ELSE
		BEGIN        
			INSERT  INTO CoTipoPresupuesto(
					CoTipoPresupuestoClave,
					Nombre,
					NombreCorto,
					CoProyectoID,
					NivelPartida,
					NivelCalendario,
					CfgEstatusDocumentoID,
					CoTipoPresupuestoBaseID,
					CoTipoConstruccionID)
			VALUES  (
					@CoTipoPresupuestoClave,
					@Nombre,
					@NombreCorto,
					@CoProyectoID,
					@NivelPartida,
					@NivelCalendario,
					@CfgEstatusDocumentoID,
					@CoTipoPresupuestoBaseID,
					@CoTipoConstruccionID)
        
			SET     @IDAActualizar = SCOPE_IDENTITY()
		END

		IF @@RowCount > 0
		BEGIN
			/* Procesa Bitácora */
			-- Determina si fue UPDATE o INSERT
			IF @CoTipoPresupuestoID_ > 0  SET @Operacion = 'Update' 	
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
				SET @logMessage = Concat('CoTipoPresupuestoClave::', @CoTipoPresupuestoClave_, ':', @CoTipoPresupuestoClave, ';')
				SET @logMessage = Concat(@logMessage, 'Nombre::', @Nombre_, ':', @Nombre, ';')
				SET @logMessage = Concat(@logMessage, 'NombreCorto::', @NombreCorto_, ':', @NombreCorto, ';')
				SET @logMessage = Concat(@logMessage, 'CoProyectoID::', @CoProyectoID_, ':', @CoProyectoID, ';')
				SET @logMessage = Concat(@logMessage, 'NivelPartida::', @NivelPartida_, ':', @NivelPartida, ';')
				SET @logMessage = Concat(@logMessage, 'NivelCalendario::', @NivelCalendario_, ':', @NivelCalendario, ';')
				SET @logMessage = Concat(@logMessage, 'CfgEstatusDocumentoID::', @CfgEstatusDocumentoID_, ':', @CfgEstatusDocumentoID, ';')
				SET @logMessage = Concat(@logMessage, 'CoTipoPresupuestoBaseID::', @CoTipoPresupuestoBaseID_, ':', @CoTipoPresupuestoBaseID, ';')
				SET @logMessage = Concat(@logMessage, 'CoTipoConstruccionID::', @CoTipoConstruccionID_, ':', @CoTipoConstruccionID, ';')
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