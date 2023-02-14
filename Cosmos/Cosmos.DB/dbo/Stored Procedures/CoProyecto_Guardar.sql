CREATE PROCEDURE [dbo].[CoProyecto_Guardar]
@CoProyectoID int,
@PpalSucursalID int,
@CoProyectoClave varchar(10) = null,
@Nombre varchar(60) = null,
@NombreCorto varchar(10) = null,
@NivelPartidaInicio tinyint,
@PpalCentroCostoID int,
@ManejaElementoInicio bit,
@NivelCalendarioInicio tinyint,
@FechaAlta date,
@EspCP int,
@Inscripcion varchar(30),
@Libro varchar(30),
@Seccion varchar(30),
@TipoCapturaAvance tinyint
/************   COPY 1  ************************************/
-- Parámetros para Bitácora
	,@UsuarioIDBitacora		int
	,@DescripcionBitacora	varchar(500)	= null
	,@IpAddress				varchar(40)		= null
	,@HostName				varchar(50)		= null
/************************************************/
AS
-- Variables para manejo de Respuesta
DECLARE @Errores int = 0,						@Mensaje nvarchar(500) = '',				@IDAActualizar int,
		@ClaveNoAsignado varchar(5),			@TituloMensaje varchar(100) = ''
-- Variables para Bitácora
DECLARE @TablaNombre   nvarchar(100) = 'CoProyecto',	
		@Operacion	nvarchar(20) = '', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit
-- Variables para valores anteriores (Bitácora Update) 
DECLARE	@CoProyectoID_ int = @CoProyectoID,
		@PpalSucursalID_ int = 0,
		@CoProyectoClave_ nvarchar(10) = '',
		@Nombre_ nvarchar(60) = '',			
		@NombreCorto_ varchar(10) = '',
		@NivelPartidaInicio_ tinyint = 0,
		@PpalCentroCostoID_ int = 0,
		@ManejaElementoInicio_ bit = 0,
		@NivelCalendarioInicio_ tinyint = 0,
		@FechaAlta_ date = GetDAte(),
		@EspCP_ int = 0,
		@TipoCapturaAvance_ tinyint = 0,
		@Inscripcion_ varchar(30) = '',
		@Libro_ varchar(30) = '',
		@Seccion_ varchar(30) = ''

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION

	SET @IDAActualizar = @CoProyectoID
	-- Lee ClaveNoAsignado y Títulos de mensajes de Parámetros Cosmos
	SELECT	@ClaveNoAsignado = IsNull(ClaveNoAsignado,''),	@TituloMensaje = IsNull(TituloMensajeRespuesta,'')
		FROM	SistemaParamCosmos;
	-- Si es UPDATE -> Lee valores anteriores de las columnas (Bitácora Update) 
	IF @IDAActualizar > 0
	BEGIN
		-- Lee Valores anteriores para Bitácora
		SELECT	@CoProyectoID_ = IsNull(CoProyectoID,0),
				@PpalSucursalID_ = IsNull(PpalSucursalID,0),
				@CoProyectoClave_ = IsNull(CoProyectoClave,''),
	 			@Nombre_ = IsNull(Nombre,''),
				@NombreCorto_ = IsNull(NombreCorto,''),
				@NivelPartidaInicio_ = IsNull(NivelPartidaInicio,0),
				@PpalCentroCostoID_= IsNull(PpalCentroCostoID,0),
				@ManejaElementoInicio_ = IsNull(ManejaElementoInicio,0),
				@NivelCalendarioInicio_ = IsNull(NivelCalendarioInicio,0),
				@FechaAlta_ = FechaAlta,
				@EspCP_ = IsNull(EspCP,0),
				@TipoCapturaAvance = IsNull(TipoCapturaAvance,0),
				@Inscripcion_ = Inscripcion,
				@Libro_ = Libro,
				@Seccion_ = Seccion
		   FROM	CoProyecto WHERE CoProyectoID = @IDAActualizar
		-- Si no se encontró registro a actualizar -> error
		IF @@RowCount = 0
			SELECT @Errores = 999999, @Mensaje = CONCAT('No se encontró el ID a Actualizar: ', @IDAActualizar),
					@TituloMensaje = 'Error de Inconsistencia de Información.';
		-- No se permite cambiar Clave cuando es igual a @ClaveNoAsignado
		IF @CoProyectoClave_ = @ClaveNoAsignado and @CoProyectoClave <> @ClaveNoAsignado
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
			UPDATE  CoProyecto
			SET     PpalSucursalID = @PpalSucursalID,
					CoProyectoClave = @CoProyectoClave,
					Nombre = @Nombre,
					NombreCorto = @NombreCorto,
					NivelPartidaInicio = @NivelPartidaInicio,
					PpalCentroCostoID = @PpalCentroCostoID,
					ManejaElementoInicio = @ManejaElementoInicio,
					NivelCalendarioInicio = @NivelCalendarioInicio,
					FechaAlta = @FechaAlta,
					EspCP = @EspCP,
					TipoCapturaAvance = @TipoCapturaAvance,
					Inscripcion = @Inscripcion,
					Libro = @Libro,
					Seccion = @Seccion
			WHERE   CoProyectoID = @IDAActualizar
		END
		ELSE
		BEGIN        
			INSERT  INTO CoProyecto(
					PpalSucursalID,
					CoProyectoClave,
					Nombre,
					NombreCorto,
					NivelPartidaInicio,
					PpalCentroCostoID,
					ManejaElementoInicio,
					NivelCalendarioInicio,
					FechaAlta,
					EspCP,
					TipoCapturaAvance,
					Inscripcion,
					Libro,
					Seccion)
			VALUES  (
					@PpalSucursalID,
					@CoProyectoClave,
					@Nombre,
					@NombreCorto,
					@NivelPartidaInicio,
					@PpalCentroCostoID,
					@ManejaElementoInicio,
					@NivelCalendarioInicio,
					@FechaAlta,
					@EspCP,
					@TipoCapturaAvance,
					@Inscripcion,
					@Libro,
					@Seccion)
        
			SET     @IDAActualizar = SCOPE_IDENTITY()
		END

		/****************** COPY 3 ************************************************/
		IF @@RowCount > 0
		BEGIN
			/* Procesa Bitácora */
			-- Determina si fue UPDATE o INSERT
			IF @CoProyectoID_ > 0  SET @Operacion = 'Update' 	
						ELSE SET @Operacion = 'Create' 

			-- Revisa si el cambio debe ser guardado en Bitácora
			EXEC	@isChangeBeLogged	=   SistemaLogRegla_Consultar_LogBit
					@UsuarioID			=	@UsuarioIDBitacora,
					@TablaNombre		=   @TablaNombre,
					@Operacion			=	@Operacion

			-- Si el cambio debe guardarse, prepara variables de Bitácora y lo guarda
			IF @isChangeBeLogged = 1 
			BEGIN
				-- logMessage = Cambios efectuados
				SET @logMessage = Concat('PpalSucursalID::', @PpalSucursalID_, ':', @PpalSucursalID, ';')
				SET @logMessage = Concat(@logMessage, 'CoProyectoClave::', @CoProyectoClave_, ':', @CoProyectoClave, ';')
				SET @logMessage = Concat(@logMessage, 'Nombre::', @Nombre_, ':', @Nombre, ';')
				SET @logMessage = Concat(@logMessage, 'NombreCorto::', @NombreCorto_, ':', @NombreCorto, ';')
				SET @logMessage = Concat(@logMessage, 'NivelPartidaInicio::', @NivelPartidaInicio_, ':', @NivelPartidaInicio, ';')
				SET @logMessage = Concat(@logMessage, 'PpalCentroCostoID::', @PpalCentroCostoID_, ':', @PpalCentroCostoID, ';')
				SET @logMessage = Concat(@logMessage, 'ManejaElementoInicio::', @ManejaElementoInicio_, ':', @ManejaElementoInicio, ';')
				SET @logMessage = Concat(@logMessage, 'NivelCalendarioInicio::', @NivelCalendarioInicio_, ':', @NivelCalendarioInicio, ';')
				SET @logMessage = Concat(@logMessage, 'FechaAlta::', @FechaAlta_, ':', @FechaAlta, ';')
				SET @logMessage = Concat(@logMessage, 'CP::', @EspCP_, ':', @EspCP, ';')
				SET @logMessage = Concat(@logMessage, 'TipoCapturaAvance::', @TipoCapturaAvance_, ':', @TipoCapturaAvance, ';')
				SET @logMessage = Concat(@logMessage, 'Inscripcion::', @Inscripcion_, ':', @Inscripcion, ';')
				SET @logMessage = Concat(@logMessage, 'Libro::', @Libro_, ':', @Libro, ';')
				SET @logMessage = Concat(@logMessage, 'Seccion::', @Seccion_, ':', @Seccion, ';')
				-- Guarda en Bitácora
				EXEC 	 [dbo].[SistemaLog_Guardar] @TablaNombre		= @TablaNombre
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