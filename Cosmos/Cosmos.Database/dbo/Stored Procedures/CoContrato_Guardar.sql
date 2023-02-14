CREATE PROCEDURE [dbo].[CoContrato_Guardar]
@CoContratoID int,
@CoContratoClave varchar(30) = null,
@Nombre varchar(80) = null,
@NombreCorto varchar(15) = null,
@CoProyectoID int = null,
@PpalProveedorID int = null,
@FechaAlta date = null,
@FechaInicio date = null,
@FechaFin date = null,
@TipoContrato char(1) = null,
@Comentarios varchar(500) = null
/************   COPY 1  ************************************/
-- Parámetros para Bitácora
	,@UserIDBitacora	int
	,@DescripcionBitacora		varchar(500)	= null
	,@IpAddress			varchar(40)		= null
	,@HostName			varchar(50)		= null
/************************************************/
AS
-- Variables para manejo de Respuesta
DECLARE @Errores int = 0,						@Mensaje nvarchar(500) = '',				@IDAActualizar int,
		@ClaveNoAsignado varchar(5),			@TituloMensaje varchar(100) = ''
-- Variables para Bitácora
DECLARE @TablaNombreIDBitacora   nvarchar(100) = 'CoContrato',	
		@Operacion	nvarchar(20) = '', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit
-- Variables para valores anteriores (Bitácora Update) 
DECLARE	@CoContratoClave_ nvarchar(30) = '',
		@Nombre_ nvarchar(80) = '',			
		@NombreCorto_ varchar(15) = '',
		@CoProyectoID_ int = 0,
		@CoContratoID_ int = @CoContratoID,
		@PpalProveedorID_ int = 0,
		@FechaAlta_ date = GetDate(),
		@FechaInicio_ date = GetDate(),
		@FechaFin_ date = GetDate(),
		@TipoContrato_ char(1) = '',
		@Comentarios_ varchar(500) = ''

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION

	SET @IDAActualizar = @CoContratoID
	-- Lee ClaveNoAsignado y Títulos de mensajes de Parámetros Cosmos
	SELECT	@ClaveNoAsignado = IsNull(ClaveNoAsignado,''),	@TituloMensaje = IsNull(TituloMensajeRespuesta,'')
		FROM	SistemaParamCosmos;
	-- Si es UPDATE -> Lee valores anteriores de las columnas (Bitácora Update) 
	IF @IDAActualizar > 0
	BEGIN
		-- Lee Valores anteriores para Bitácora
		SELECT	@CoContratoClave_ = IsNull(CoContratoClave,''),
	 			@Nombre_ = IsNull(Nombre,''),
				@NombreCorto_ = IsNull(NombreCorto,''),
				@CoProyectoID_ = IsNull(CoProyectoID,0),
				@CoContratoID_ = IsNull(CoContratoID,0),
				@PpalProveedorID_ = IsNull(PpalProveedorID,0),
				@FechaAlta_ = IsNull(FechaAlta,GetDate()),
				@FechaInicio_ = IsNull(FechaInicio,GetDate()),
				@FechaFin_ = IsNull(FechaFin,GetDate()),
				@TipoContrato_ = IsNull(TipoContrato,''),
				@Comentarios_ = IsNull(Comentarios,'')
		   FROM	CoContrato WHERE CoContratoID = @IDAActualizar

		-- Si no se encontró registro a actualizar -> error
		IF @@RowCount = 0
			SELECT @Errores = 999999, @Mensaje = CONCAT('No se encontró el ID a Actualizar: ', @IDAActualizar),
					@TituloMensaje = 'Error de Inconsistencia de Información.';
		-- No se permite cambiar Clave cuando es igual a @ClaveNoAsignado
		IF @CoContratoClave_ = @ClaveNoAsignado and @CoContratoClave <> @ClaveNoAsignado
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
			UPDATE  CoContrato
			SET     CoContratoClave = @CoContratoClave,
					Nombre = @Nombre,
					NombreCorto = @NombreCorto,
					CoProyectoID = @CoProyectoID,
					CoContratoID = @CoContratoID,
					PpalProveedorID = @PpalProveedorID,
					FechaAlta = @FechaAlta,
					FechaInicio = @FechaInicio,
					FechaFin = @FechaFin,
					TipoContrato = @TipoContrato,
					Comentarios = @Comentarios
			WHERE   CoContratoID = @IDAActualizar
		END
		ELSE
		BEGIN        
			INSERT  INTO CoContrato(
					CoContratoClave,			Nombre,					NombreCorto,
					CoProyectoID,				CoContratoID,			PpalProveedorID,
					FechaAlta,					FechaInicio,			FechaFin,
					TipoContrato,				Comentarios)
			VALUES  (
					@CoContratoClave,			@Nombre,				@NombreCorto,
					@CoProyectoID,				@CoContratoID,			@PpalProveedorID,
					@FechaAlta,					@FechaInicio,			@FechaFin,
					@TipoContrato,				@Comentarios)
        
			SET     @IDAActualizar = SCOPE_IDENTITY()
		END

		/****************** COPY 3 ************************************************/
		IF @@RowCount > 0
		BEGIN
			/* Procesa Bitácora */
			-- Determina si fue UPDATE o INSERT
			IF @CoContratoID_ > 0  SET @Operacion = 'Update' 	
						ELSE SET @Operacion = 'Create' 

			-- Revisa si el cambio debe ser guardado en Bitácora
			EXEC	@isChangeBeLogged	=   SistemaLogRegla_Consultar_LogBit
					@UsuarioID			=	@UserIDBitacora,
					@TablaNombre		=   @TablaNombreIDBitacora,
					@Operacion			=	@Operacion

			-- Si el cambio debe guardarse, prepara variables de Bitácora y lo guarda
			IF @isChangeBeLogged = 1 
			BEGIN
				-- logMessage = Cambios efectuados
				SET @logMessage = Concat('CoContratoClave::', @CoContratoClave_, ':', @CoContratoClave, ';')
				SET @logMessage = Concat(@logMessage, 'Nombre::', @Nombre_, ':', @Nombre, ';')
				SET @logMessage = Concat(@logMessage, 'NombreCorto::', @NombreCorto_, ':', @NombreCorto, ';')
				SET @logMessage = Concat(@logMessage, 'CoProyectoID::', @CoProyectoID_, ':', @CoProyectoID, ';')
				SET @logMessage = Concat(@logMessage, 'CoContratoID::', @CoContratoID_, ':', @CoContratoID, ';')
				SET @logMessage = Concat(@logMessage, 'PpalProveedorID::', @PpalProveedorID_, ':', @PpalProveedorID, ';')
				SET @logMessage = Concat(@logMessage, 'FechaAlta::', @FechaAlta_, ':', @FechaAlta, ';')
				SET @logMessage = Concat(@logMessage, 'FechaInicio::', @FechaInicio_, ':', @FechaInicio, ';')
				SET @logMessage = Concat(@logMessage, 'FechaFin::', @FechaFin_, ':', @FechaFin, ';')
				SET @logMessage = Concat(@logMessage, 'TipoContrato::', @TipoContrato_, ':', @TipoContrato, ';')
				SET @logMessage = Concat(@logMessage, 'Comentarios::', @Comentarios_, ':', @Comentarios, ';')

				-- Guarda en Bitácora
				EXEC 	 [dbo].[SistemaLog_Guardar] @TablaNombre		= @TablaNombreIDBitacora
														,@TablaID			= @IDAActualizar
														,@TablaColumna1		= ''
														,@TablaColumna2		= ''
														,@Operacion			= @Operacion
														,@UsuarioID			= @UserIDBitacora
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