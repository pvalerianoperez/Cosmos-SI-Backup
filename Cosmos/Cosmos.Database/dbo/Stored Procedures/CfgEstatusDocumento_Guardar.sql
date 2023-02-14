CREATE PROCEDURE [dbo].[CfgEstatusDocumento_Guardar]
@CfgEstatusDocumentoID int,
@CfgEstatusDocumentoClave varchar(8),
@Nombre varchar(40),
@NombreCorto varchar(10),
@SistemaEstatusTipoDocumentoID int,
@Predeterminado bit
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
DECLARE @TablaNombreBitacora   nvarchar(100) = 'PpalArea',	
		@Operacion	nvarchar(20) = '', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit
-- Variables para valores anteriores (Bitácora Update) 
DECLARE	@CfgEstatusDocumentoClave_ varchar(8) = '',
		@Nombre_ varchar(40) = '',
		@NombreCorto_ varchar(10) = '',
		@SistemaEstatusTipoDocumentoID_ int = 0,
		@Predeterminado_ bit = 0,
		@CfgEstatusDocumentoID_ int = @CfgEstatusDocumentoID

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION

	SET @IDAActualizar = @CfgEstatusDocumentoID
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
		SELECT	@CfgEstatusDocumentoClave_ = IsNull(CfgEstatusDocumentoClave,''),
				@Nombre_  = IsNull(Nombre, ''),
				@NombreCorto_  = IsNull(NombreCorto,''),
				@SistemaEstatusTipoDocumentoID_ = IsNull(SistemaEstatusTipoDocumentoID, 0),
				@Predeterminado_  = IsNull(@Predeterminado, 0)
		   FROM	CfgEstatusDocumento WHERE CfgEstatusDocumentoID = @IDAActualizar
		-- Si no se encontró registro a actualizar -> error
		IF @@RowCount = 0
			SELECT @Errores = 999999, @Mensaje = CONCAT('No se encontró el ID a Actualizar: ', @IDAActualizar),
					@TituloMensaje = 'Error de Inconsistencia de Información.';
		-- No se permite cambiar Clave cuando es igual a @ClaveNoAsignado
		IF @CfgEstatusDocumentoClave_ = @ClaveNoAsignado and @CfgEstatusDocumentoClave_ <> @ClaveNoAsignado
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
			UPDATE  CfgEstatusDocumento
			SET     CfgEstatusDocumentoClave = @CfgEstatusDocumentoClave,
					Nombre = @Nombre,
					NombreCorto = @NombreCorto,
					SistemaEstatusTipoDocumentoID = @SistemaEstatusTipoDocumentoID,
					Predeterminado = @Predeterminado
			WHERE   CfgEstatusDocumentoID = @CfgEstatusDocumentoID
		END
		ELSE
		BEGIN        
			 INSERT  INTO CfgEstatusDocumento(
					CfgEstatusDocumentoClave,
					Nombre,
					NombreCorto,
					SistemaEstatusTipoDocumentoID,
					Predeterminado)
			 VALUES  (
					@CfgEstatusDocumentoClave,
					@Nombre,
					@NombreCorto,
					@SistemaEstatusTipoDocumentoID,
					@Predeterminado)
       
			SET     @IDAActualizar = SCOPE_IDENTITY()
		END

		/****************** COPY 3 ************************************************/
		IF @@RowCount > 0
		BEGIN
			/* Procesa Bitácora */
			-- Determina si fue UPDATE o INSERT
			IF @CfgEstatusDocumentoID_ > 0  SET @Operacion = 'Update' 	
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
				SET @logMessage = Concat('PpalAreaClave::', @CfgEstatusDocumentoClave, ':', @CfgEstatusDocumentoClave, ';')
				SET @logMessage = Concat(@logMessage, 'Nombre::', @Nombre_, ':', @Nombre, ';')
				SET @logMessage = Concat(@logMessage, 'NombreCorto::', @NombreCorto_, ':', @NombreCorto, ';')
				SET @logMessage = Concat(@logMessage, 'NombreCorto::', @NombreCorto_, ':', @NombreCorto, ';')
				SET @logMessage = Concat(@logMessage, 'SistemaEstatusTipoDocumentoID::', @SistemaEstatusTipoDocumentoID_, ':', @SistemaEstatusTipoDocumentoID, ';')
				SET @logMessage = Concat(@logMessage, 'Predeterminado::', @Predeterminado, ':', @Predeterminado, ';')

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
/**************** FIN COPY 3 *********************************************/