CREATE PROCEDURE [dbo].[CoPartidaDetalle_Guardar]
@CoPartidaDetalleID int,
@CoPartidaID int,
@PpalProductoID int,
@Cantidad decimal(18,6),
@Precio decimal(18,6),
@AuxUnidadID int,
@Adicional varchar(500) = null,
@Observaciones varchar(500) = null,
@PpalAreaID int,
@SustituirConAdicional bit,
@PpalConceptoEgresoID int
/************   COPY 1  ************************************/
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
DECLARE @TablaNombreIDBitacora   nvarchar(100) = 'CoPartidaDetalle',	
		@Operacion	nvarchar(20) = '', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit
-- Variables para valores anteriores (Bitácora Update) 
DECLARE	@CoPartidaDetalleID_ int = @CoPartidaDetalleID,
		@CoPartidaID_ int = 0,
		@PpalProductoID_ int = 0,
		@Cantidad_ decimal(18,6) = 0,
		@Precio_ decimal(18,6) = 0,
		@AuxUnidadID_ int = 0,
		@Adicional_ varchar(500) = '',
		@Observaciones_ varchar(500) = '',
		@PpalAreaID_ int = 0,
		@SustituirConAdicional_ bit = 0,
		@PpalConceptoEgresoID_ int = 0
		
		

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION

	SET @IDAActualizar = @CoPartidaDetalleID
	-- Lee ClaveNoAsignado y Títulos de mensajes de Parámetros Cosmos
	SELECT	@ClaveNoAsignado = IsNull(ClaveNoAsignado,''),	@TituloMensaje = IsNull(TituloMensajeRespuesta,'')
		FROM	SistemaParamCosmos;
	-- Si es UPDATE -> Lee valores anteriores de las columnas (Bitácora Update) 
	IF @IDAActualizar > 0
	BEGIN
		-- Lee Valores anteriores para Bitácora
		SELECT	@CoPartidaDetalleID_  = IsNull(CoPartidaDetalleID,0),
				@CoPartidaID_ = IsNull(CoPartidaID,0),
				@PpalProductoID_ = IsNull(PpalProductoID,0),
				@Cantidad_ = IsNull(Cantidad,0),
				@Precio_ = IsNull(Precio,0),
				@AuxUnidadID_ = IsNull(AuxUnidadID,0),
				@Adicional_ = IsNull(Adicional,''),
				@Observaciones_ = IsNull(Observaciones,''),
				@PpalAreaID_ = IsNull(CoPartidaID,0),
				@SustituirConAdicional_ = IsNull(CoPartidaID,0),
				@PpalConceptoEgresoID_ = IsNull(CoPartidaID,0)
	
		   FROM	CoPartidaDetalle WHERE CoPartidaDetalleID = @IDAActualizar
		-- Si no se encontró registro a actualizar -> error
		IF @@RowCount = 0
			SELECT @Errores = 999999, @Mensaje = CONCAT('No se encontró el ID a Actualizar: ', @IDAActualizar),
					@TituloMensaje = 'Error de Inconsistencia de Información.';
		-- No se permite cambiar Clave cuando es igual a @ClaveNoAsignado
		--IF @CoPartidaDetalleClave_ = @ClaveNoAsignado and @CoPartidaDetalleClave <> @ClaveNoAsignado
			--SELECT @Errores = 999996, @Mensaje = CONCAT('No es permitido cambiar la clave ', @ClaveNoAsignado),
					--@TituloMensaje = 'Error de Protección de Integridad.';
	END
	-- Si no hubo error (es INSERT o es UPDATE y existe el registro)
	IF @Errores = 0
	BEGIN
		-- Si la llave existe hace UPDATE y si no, hace INSERT
		IF @IDAActualizar > 0
/************* FIN COPY 1  *********************/
		BEGIN
			UPDATE  CoPartidaDetalle
			SET CoPartidaID = @CoPartidaID,
				PpalProductoID = @PpalProductoID,
				Cantidad = @Cantidad,
				Precio = @Precio,
				AuxUnidadID = @AuxUnidadID,
				Adicional = @Adicional,
				Observaciones = @Observaciones,
				PpalAreaID = @PpalAreaID,
				SustituirConAdicional = @SustituirConAdicional, 
				PpalConceptoEgresoID = @PpalConceptoEgresoID
			WHERE   CoPartidaDetalleID = @IDAActualizar
		END
		ELSE
		BEGIN        
			INSERT  INTO CoPartidaDetalle(
					CoPartidaID,
					PpalProductoID,
					Cantidad,
					Precio,
					AuxUnidadID,
					Adicional,
					Observaciones,
					PpalAreaID,
					SustituirConAdicional, 
					PpalConceptoEgresoID)
			VALUES  (
					@CoPartidaID,
					@PpalProductoID,
					@Cantidad,
					@Precio,
					@AuxUnidadID,
					@Adicional,
					@Observaciones,
					@PpalAreaID,
					@SustituirConAdicional, 
					@PpalConceptoEgresoID)
        
			SET     @IDAActualizar = SCOPE_IDENTITY()
		END

		/****************** COPY 3 ************************************************/
		IF @@RowCount > 0
		BEGIN
			/* Procesa Bitácora */
			-- Determina si fue UPDATE o INSERT
			IF @CoPartidaDetalleID_ > 0  SET @Operacion = 'Update' 	
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
				SET @logMessage = Concat('CoPartidaDetalleID::', @CoPartidaDetalleID_, ':', @CoPartidaDetalleID, ';')
				SET @logMessage = Concat(@logMessage, 'CoPartidaID::', @CoPartidaID_, ':', @CoPartidaID, ';')
				SET @logMessage = Concat(@logMessage, 'PpalProductoID::', @PpalProductoID_, ':', @PpalProductoID, ';')
				SET @logMessage = Concat(@logMessage, 'Cantidad::', @Cantidad_, ':', @Cantidad, ';')
				SET @logMessage = Concat(@logMessage, 'Precio::', @Precio_, ':', @Precio, ';')
				SET @logMessage = Concat(@logMessage, 'AuxUnidadID::', @AuxUnidadID_, ':', @AuxUnidadID, ';')
				SET @logMessage = Concat(@logMessage, 'Adicional::', @Adicional_, ':', @Adicional, ';')
				SET @logMessage = Concat(@logMessage, 'Observaciones::', @Observaciones_, ':', @Observaciones, ';')
				SET @logMessage = Concat(@logMessage, 'PpalAreaID::', @PpalAreaID_, ':', @PpalAreaID, ';')
				SET @logMessage = Concat(@logMessage, 'SustituirConAdicional::', @SustituirConAdicional_, ':', @SustituirConAdicional, ';')
				SET @logMessage = Concat(@logMessage, 'PpalConceptoEgresoID::', @PpalConceptoEgresoID_, ':', @PpalConceptoEgresoID, ';')
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