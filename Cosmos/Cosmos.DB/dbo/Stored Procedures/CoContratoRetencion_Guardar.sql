CREATE PROCEDURE [dbo].[CoContratoRetencion_Guardar]
@CoContratoRetencionID int,
@CoContratoRetencionClave nvarchar(10) = null,
@Nombre nvarchar(80) = null,			
@NombreCorto varchar(12) = null,
@CoContratoID int,
@TipoRetencion char(1) = null,
@Porcentaje decimal(5,2),
@EstimacionInicialAmortizacion smallint,
@EstimacionFinalAmortizacion smallint,
@TipoAmortizacion char(1) = null,
@PorcentajeInicialAmortizacion decimal(5,2),
@PorcentajeFinalAmortizacion decimal(5,2)  

/************   COPY 1  ************************************/
-- Parámetros para Bitácora
	,@UsuarioIDBitacora			int
	,@DescripcionBitacora		varchar(500)	= null
	,@IpAddress			varchar(40)		= null
	,@HostName			varchar(50)		= null
/************************************************/
AS
-- Variables para manejo de Respuesta
DECLARE @Errores int = 0,						@Mensaje nvarchar(500) = '',				@IDAActualizar int,
		@ClaveNoAsignado varchar(5),			@TituloMensaje varchar(100) = ''
-- Variables para Bitácora
DECLARE @TablaNombreIDBitacora   nvarchar(100) = 'CoContratoRetencion',	
		@Operacion	nvarchar(20) = '', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit
-- Variables para valores anteriores (Bitácora Update) 
DECLARE	@CoContratoRetencionID_ int = 0,
		@CoContratoRetencionClave_ nvarchar(10) = '',
		@Nombre_ nvarchar(50) = '',			
		@NombreCorto_ varchar(10) = '',
		@CoContratoID_ int = 0,
		@TipoRetencion_ char(1) = '',
		@Porcentaje_ decimal(5,2) = 0,
		@EstimacionInicialAmortizacion_ smallint = 0,
		@EstimacionFinalAmortizacion_ smallint = 0,
		@TipoAmortizacion_ char(1) = '',
		@PorcentajeInicialAmortizacion_ decimal(5,2) = 0,
		@PorcentajeFinalAmortizacion_ decimal(5,2) = 0


SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION

	SET @IDAActualizar = @CoContratoRetencionID
	-- Lee ClaveNoAsignado y Títulos de mensajes de Parámetros Cosmos
	SELECT	@ClaveNoAsignado = IsNull(ClaveNoAsignado,''),	@TituloMensaje = IsNull(TituloMensajeRespuesta,'')
		FROM	SistemaParamCosmos;
	-- Si es UPDATE -> Lee valores anteriores de las columnas (Bitácora Update) 
	IF @IDAActualizar > 0
	BEGIN
		-- Lee Valores anteriores para Bitácora
		SELECT	@CoContratoRetencionID_ = IsNULL(CoContratoRetencionID,0),
				@CoContratoRetencionClave_  = IsNull(CoContratoRetencionClave,''),
				@Nombre_  = IsNull(Nombre,''),			
				@NombreCorto_  = IsNull(NombreCorto,''),
				@CoContratoID_ = IsNULL(CoContratoID,0),
				@TipoRetencion_ = IsNull(TipoRetencion,''),
				@Porcentaje_  = IsNull(Porcentaje,0),
				@EstimacionInicialAmortizacion_  = IsNull(EstimacionInicialAmortizacion,0),
				@EstimacionFinalAmortizacion_  = IsNull(EstimacionFinalAmortizacion,0),
				@TipoAmortizacion_ = IsNull(TipoAmortizacion,''),
				@PorcentajeInicialAmortizacion_  = IsNull(PorcentajeInicialAmortizacion,0),
				@PorcentajeFinalAmortizacion_ = IsNull(PorcentajeFinalAmortizacion,0)
		
		   FROM	CoContratoRetencion WHERE CoContratoRetencionID = @IDAActualizar
		-- Si no se encontró registro a actualizar -> error
		IF @@RowCount = 0
			SELECT @Errores = 999999, @Mensaje = CONCAT('No se encontró el ID a Actualizar: ', @IDAActualizar),
					@TituloMensaje = 'Error de Inconsistencia de Información.';
		-- No se permite cambiar Clave cuando es igual a @ClaveNoAsignado
		IF @CoContratoRetencionClave_ = @ClaveNoAsignado and @CoContratoRetencionClave <> @ClaveNoAsignado
			SELECT @Errores = 999996, @Mensaje = CONCAT('No es permitido cambiar la clave ', @ClaveNoAsignado),
					@TituloMensaje = 'Error de Protección de Integridad.';
	END
	-- Si no hubo error (es INSERT o es UPDATE y existe el registro)
	IF @Errores = 0
	BEGIN
		-- Si la llave existe hace UPDATE y si no, hace INSERT
		IF @IDAActualizar > 0
/************* FIN COPY 1  *********************/
		BEGIN
			UPDATE  CoContratoRetencion
			SET    	CoContratoRetencionClave = @CoContratoRetencionClave,	Nombre = @Nombre,			
					NombreCorto = @NombreCorto,	CoContratoID = @CoContratoID,		TipoRetencion = @TipoRetencion,	Porcentaje = @Porcentaje,
					EstimacionInicialAmortizacion = @EstimacionInicialAmortizacion,	EstimacionFinalAmortizacion = @EstimacionFinalAmortizacion,
					TipoAmortizacion = @TipoAmortizacion,	PorcentajeInicialAmortizacion = @PorcentajeInicialAmortizacion, 
					PorcentajeFinalAmortizacion = @PorcentajeFinalAmortizacion
			WHERE   CoContratoRetencionID = @IDAActualizar
		END
		ELSE
		BEGIN        
			INSERT  INTO CoContratoRetencion(
					CoContratoRetencionClave,
					Nombre,			
					NombreCorto,
					CoContratoID,	
					TipoRetencion,	 
					Porcentaje,
					EstimacionInicialAmortizacion,	
					EstimacionFinalAmortizacion,
					TipoAmortizacion,	
					PorcentajeInicialAmortizacion, 
					PorcentajeFinalAmortizacion)
			VALUES  (
					@CoContratoRetencionClave,
					@Nombre,			
					@NombreCorto,
					@CoContratoID,	
					@TipoRetencion,	 
					@Porcentaje,
					@EstimacionInicialAmortizacion,	
					@EstimacionFinalAmortizacion,
					@TipoAmortizacion,	
					@PorcentajeInicialAmortizacion, 
					@PorcentajeFinalAmortizacion)
        
			SET     @IDAActualizar = SCOPE_IDENTITY()
		END

		/****************** COPY 3 ************************************************/
		IF @@RowCount > 0
		BEGIN
			/* Procesa Bitácora */
			-- Determina si fue UPDATE o INSERT
			IF @CoContratoRetencionID_ > 0  SET @Operacion = 'Update' 	
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
				SET @logMessage = Concat('CoContratoRetencionID::', @CoContratoRetencionID_, ':', @CoContratoRetencionID, ';')
				SET @logMessage = Concat(@logMessage, 'CoContratoRetencionClave::', @CoContratoRetencionClave_, ':', @CoContratoRetencionClave, ';')
				SET @logMessage = Concat(@logMessage, 'Nombre::', @Nombre_, ':', @Nombre, ';')
				SET @logMessage = Concat(@logMessage, 'NombreCorto::', @NombreCorto_, ':', @NombreCorto, ';')
				SET @logMessage = Concat(@logMessage, 'CoContratoID::', @CoContratoID_, ':', @CoContratoID, ';')
				SET @logMessage = Concat(@logMessage, 'TipoRetencion::', @TipoRetencion_, ':', @TipoRetencion, ';')
				SET @logMessage = Concat(@logMessage, 'Porcentaje::', @Porcentaje_, ':', @Porcentaje, ';')
				SET @logMessage = Concat(@logMessage, 'EstimacionInicialAmortizacion::', @EstimacionInicialAmortizacion_, ':', @EstimacionInicialAmortizacion, ';')
				SET @logMessage = Concat(@logMessage, 'EstimacionFinalAmortizacion::', @EstimacionFinalAmortizacion_, ':', @EstimacionFinalAmortizacion, ';')
				SET @logMessage = Concat(@logMessage, 'TipoAmortizacion::', @TipoAmortizacion_, ':', @TipoAmortizacion, ';')
				SET @logMessage = Concat(@logMessage, 'PorcentajeInicialAmortizacion::', @PorcentajeInicialAmortizacion_, ':', @PorcentajeInicialAmortizacion, ';')
				SET @logMessage = Concat(@logMessage, 'PorcentajeFinalAmortizacion::', @PorcentajeFinalAmortizacion_, ':', @PorcentajeFinalAmortizacion, ';')

		
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
/**************** FIN COPY 3 *********************************************/