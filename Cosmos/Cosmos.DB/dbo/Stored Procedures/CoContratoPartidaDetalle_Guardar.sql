CREATE PROCEDURE [dbo].[CoContratoPartidaDetalle_Guardar]
@CoContratoPartidaDetalleID int,
@CoContratoID int,			
@CoPartidaDetalleID int,
@Cantidad decimal(18,6),
@Precio decimal(18,6),
@Adicional varchar(500) = null,
@SustituirConAdicional bit,
@CfgEstatusDocumentoID int

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
DECLARE @TablaNombreIDBitacora   nvarchar(100) = 'CoContratoPartidaDetalle',	
		@Operacion	nvarchar(20) = '', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit
-- Variables para valores anteriores (Bitácora Update) 
DECLARE	@CoContratoPartidaDetalleID_ int = 0,
		@CoContratoID_ int = 0 ,			
		@CoPartidaDetalleID_ int = 0,
		@Cantidad_ decimal(18,6) = 0,
		@Precio_ decimal(18,6) = 0,
		@Adicional_ varchar(500) = '',
		@SustituirConAdicional_ bit = 0,
		@CfgEstatusDocumentoID_ int = 0


SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION

	SET @IDAActualizar = @CoContratoPartidaDetalleID
	-- Lee ClaveNoAsignado y Títulos de mensajes de Parámetros Cosmos
	SELECT	@ClaveNoAsignado = IsNull(ClaveNoAsignado,''),	@TituloMensaje = IsNull(TituloMensajeRespuesta,'')
		FROM	SistemaParamCosmos;
	-- Si es UPDATE -> Lee valores anteriores de las columnas (Bitácora Update) 
	IF @IDAActualizar > 0
	BEGIN
		-- Lee Valores anteriores para Bitácora
		SELECT	@CoContratoPartidaDetalleID_ = IsNULL(CoContratoPartidaDetalleID,0),
				@CoContratoID_ =	IsNULL(CoContratoID,0),
				@CoPartidaDetalleID_ = IsNULL(CoPartidaDetalleID,0),
				@Cantidad_ = IsNULL(Cantidad,0),
				@Precio_ = IsNULL(Precio,0),
				@Adicional_ = IsNull(Adicional,''),
				@SustituirConAdicional_ = IsNULL(SustituirConAdicional,0),
				@CfgEstatusDocumentoID_ = IsNULL(CfgEstatusDocumentoID,0)
		
		   FROM	CoContratoPartidaDetalle WHERE CoContratoPartidaDetalleID = @IDAActualizar
		-- Si no se encontró registro a actualizar -> error
		IF @@RowCount = 0
			SELECT @Errores = 999999, @Mensaje = CONCAT('No se encontró el ID a Actualizar: ', @IDAActualizar),
					@TituloMensaje = 'Error de Inconsistencia de Información.';
		-- No se permite cambiar Clave cuando es igual a @ClaveNoAsignado
		--IF @CoContratoPartidaDetalleClave_ = @ClaveNoAsignado and @CoContratoPartidaDetalleClave <> @ClaveNoAsignado
			--SELECT @Errores = 999996, @Mensaje = CONCAT('No es permitido cambiar la clave ', @ClaveNoAsignado),
				--	@TituloMensaje = 'Error de Protección de Integridad.';
	END
	-- Si no hubo error (es INSERT o es UPDATE y existe el registro)
	IF @Errores = 0
	BEGIN
		-- Si la llave existe hace UPDATE y si no, hace INSERT
		IF @IDAActualizar > 0
/************* FIN COPY 1  *********************/
		BEGIN
			UPDATE  CoContratoPartidaDetalle
			SET		CoContratoID	= @CoContratoID,		
					CoPartidaDetalleID = @CoPartidaDetalleID, 
					Cantidad = @Cantidad, 
					Precio = @Precio,
					Adicional = @Adicional,
					SustituirConAdicional = @SustituirConAdicional, 
					CfgEstatusDocumentoID = @CfgEstatusDocumentoID 
			WHERE   CoContratoPartidaDetalleID = @IDAActualizar
		END
		ELSE
		BEGIN        
			INSERT  INTO CoContratoPartidaDetalle(
					CoContratoID,		
					CoPartidaDetalleID, 
					Cantidad, 
					Precio,
					Adicional,
					SustituirConAdicional, 
					CfgEstatusDocumentoID)
			VALUES  (
					@CoContratoID,		
					@CoPartidaDetalleID, 
					@Cantidad, 
					@Precio,
					@Adicional,
					@SustituirConAdicional, 
					@CfgEstatusDocumentoID)
        
			SET     @IDAActualizar = SCOPE_IDENTITY()
		END

		/****************** COPY 3 ************************************************/
		IF @@RowCount > 0
		BEGIN
			/* Procesa Bitácora */
			-- Determina si fue UPDATE o INSERT
			IF @CoContratoPartidaDetalleID_ > 0  SET @Operacion = 'Update' 	
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
				SET @logMessage = Concat('CoContratoPartidaDetalleID::', @CoContratoPartidaDetalleID_, ':', @CoContratoPartidaDetalleID, ';')
				SET @logMessage = Concat(@logMessage, 'CoContratoID::', @CoContratoID_, ':', @CoContratoID, ';')
				SET @logMessage = Concat(@logMessage, 'CoPartidaDetalleID::', @CoPartidaDetalleID_, ':', @CoPartidaDetalleID, ';')
				SET @logMessage = Concat(@logMessage, 'Cantidad::', @Cantidad_, ':', @Cantidad, ';')
				SET @logMessage = Concat(@logMessage, 'Precio::', @Precio_, ':', @Precio, ';')
				SET @logMessage = Concat(@logMessage, 'Adicional::', @Adicional_, ':', @Adicional, ';')
				SET @logMessage = Concat(@logMessage, 'SustituirConAdicional::', @SustituirConAdicional_, ':', @SustituirConAdicional, ';')
				SET @logMessage = Concat(@logMessage, 'CfgEstatusDocumentoID::', @CfgEstatusDocumentoID_, ':', @CfgEstatusDocumentoID, ';')

		
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