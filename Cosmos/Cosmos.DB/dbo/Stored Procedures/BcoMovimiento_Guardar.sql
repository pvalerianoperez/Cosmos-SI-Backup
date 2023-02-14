
CREATE PROCEDURE [dbo].[BcoMovimiento_Guardar]
@BcoMovimientoID int,
@PpalSerieID int,
@Folio int,
@PpalPersonalID int,
@Fecha datetime,
@Referencia varchar(50),
@Concepto  varchar(100),
@Importe   float,
@BcoTipoMovimientoID int,
@BcoCuentaID int,
@AuxFormaPagoID int
-- Parámetros para Bitácora
	,@UsuarioIBitacora		int
	,@DescripcionBitacora	varchar(500)	= null
	,@IpAddress				varchar(40)		= null
	,@HostName				varchar(50)		= null
AS
-- Variables para manejo de Errores
DECLARE @Errores int = 0, @Mensaje nvarchar(300) = '', @IDAActualizar int
-- Variables para Bitácora
DECLARE @TablaNombreIDBitacora   nvarchar(100) = 'BcoMovimiento',	
		@Operacion	nvarchar(20) = '', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit
-- Variables para valores anteriores (Bitácora Update) 
DECLARE	@BcoMovimientoID_ int = @BcoMovimientoID,
		@PpalSerieID_ int = 0,
		@Folio_ int = 0,
		@PpalPersonalID_ int = 0,
		@Fecha_ datetime = 0,
		@Referencia_ varchar(50) = '',
		@Concepto_  varchar(100) = '',
		@Importe_   float = 0,
		@BcoTipoMovimientoID_ int = 0,
		@BcoCuentaID_ int = 0,
		@AuxFormaPagoID_ int = 0

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION

	SET @IDAActualizar = @BcoMovimientoID
	-- Si es UPDATE -> Lee valores anteriores de las columnas (Bitácora Update) 
	IF @IDAActualizar > 0
	BEGIN
		SELECT	@BcoMovimientoID_ =			IsNull(BcoMovimientoID,0),
				@PpalSerieID_  =			IsNull(PpalSerieID,0),
				@Folio_ =					IsNull(Folio,0),
				@PpalPersonalID_ =			IsNull(PpalPersonalID, 0),
				@Fecha_ =					IsNull(Fecha,0),
				@Referencia_ =				ISNull(Referencia, ''),
				@Concepto_ =				IsNull(Concepto, ''),
				@Importe_ =					ISNULL(Importe, 0.0),
				@BcoTipoMovimientoID_ =	ISNULL(BcoTipoMovimientoID, 0),
				@BcoCuentaID =			ISNULL(@BcoCuentaID, 0) ,
				@AuxFormaPagoID =		ISNULL(@AuxFormaPagoID, 0)
		   FROM	BcoMovimiento WHERE BcoMovimientoID = @IDAActualizar
		IF @@RowCount = 0
		SELECT @Errores = 999999, @Mensaje = CONCAT('No se encontró el ID a Actualizar:', ' ', @IDAActualizar);
	END
	-- Si no hubo error (es INSERT o es UPDATE y existe el registro)
	IF @Errores = 0
	BEGIN
		-- Si la llave existe hace UPDATE y si no, hace INSERT
		IF @IDAActualizar > 0
/************* FIN COPY 1  *********************/
		BEGIN
			UPDATE	BcoMovimiento
			SET		PpalSerieID			= @PpalSerieID,
					Folio				= @Folio,
					PpalPersonalID		= @PpalPersonalID,
					Fecha				= @Fecha,
					Referencia			= @Referencia,
					Concepto			= @Concepto,
					Importe				= @Importe,
					BcoTipoMovimientoID	= @BcoTipoMovimientoID,
					BcoCuentaID			= @BcoCuentaID,
					AuxFormaPagoID		= @AuxFormaPagoID
			WHERE	BcoMovimientoID	    = @IDAActualizar
		END
		ELSE
		BEGIN        
			INSERT  INTO BcoMovimiento(
					PpalSerieID,
					Folio,
					PpalPersonalID,
					Fecha,
					Referencia,
					Concepto,
					Importe,
					BcoTipoMovimientoID,
					BcoCuentaID,
					AuxFormaPagoID)
			VALUES  (
				    @PpalSerieID,
					@Folio,
					@PpalPersonalID,
					@Fecha,
					@Referencia,
					@Concepto,
					@Importe,
					@BcoTipoMovimientoID,
					@BcoCuentaID,
					@AuxFormaPagoID)
        
			SET     @IDAActualizar = SCOPE_IDENTITY()
		END

		IF @@RowCount > 0
		BEGIN
			/* Procesa Bitácora */
			-- Determina si fue UPDATE o INSERT
			IF @BcoMovimientoID_ > 0  SET @Operacion = 'Update' 	
						ELSE SET @Operacion = 'Create' 

			-- Revisa si el cambio debe ser guardado en Bitácora
			EXEC	@isChangeBeLogged	=   SistemaLogRegla_Consultar_LogBit
					@UsuarioID			=	@UsuarioIBitacora,
					@TablaNombre		=   @TablaNombreIDBitacora,
					@Operacion			=	@Operacion

			-- Si el cambio debe guardarse, prepara variables de Bitácora y lo guarda
			IF @isChangeBeLogged = 1 
			BEGIN
				-- logMessage = Cambios efectuados
				SET @logMessage = Concat('BcoMovimientoID::', @BcoMovimientoID_, ':', @BcoMovimientoID, ';')
				SET @logMessage = Concat(@logMessage, 'PpalSerieID::', @PpalSerieID_, ':', @PpalSerieID, ';')
				SET @logMessage = Concat(@logMessage, 'Folio::', @Folio_, ':', @Folio, ';')
				SET @logMessage = Concat(@logMessage, 'PpalPersonalID::', @PpalPersonalID_, ':', @PpalPersonalID, ';')
				SET @logMessage = Concat(@logMessage, 'Fecha::', @Fecha_, ':', @Fecha, ';')
				SET @logMessage = Concat(@logMessage, 'Referencia::', @Referencia_, ':', @Referencia, ';')
				SET @logMessage = Concat(@logMessage, 'Concepto::', @Concepto_, ':', @Concepto, ';')
				SET @logMessage = Concat(@logMessage, 'Importe::', @Importe_, ':', @Importe, ';')
				SET @logMessage = Concat(@logMessage, 'BcoTipoMovimientoID::', @BcoTipoMovimientoID_, ':', @BcoTipoMovimientoID, ';')
				SET @logMessage = Concat(@logMessage, 'BcoCuentaID::', @BcoCuentaID_, ':', @BcoCuentaID, ';')
				SET @logMessage = Concat(@logMessage, 'AuxFormaPagoID::', @AuxFormaPagoID_, ':', @AuxFormaPagoID, ';')
				
				
				PRINT @logMessage
				-- Guarda en Bitácora
				EXEC 	 [dbo].[SistemaLog_Guardar] @TablaNombre		= @TablaNombreIDBitacora
														,@TablaID			= @IDAActualizar
														,@TablaColumna1		= ''
														,@TablaColumna2		= ''
														,@Operacion			= @Operacion
														,@UsuarioID			= @UsuarioIBitacora
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