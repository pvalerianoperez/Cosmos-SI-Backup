

create PROCEDURE [dbo].[CmpCompraPago_Guardar]
@CmpCompraPagoID int,
@CmpCompraEncabezadoID int,
@BcoMovimientoID int,
@Importe decimal(18,2)
-- Parámetros para Bitácora
	,@UsuarioIDBitcora		int
	,@DescripcionBitacora	varchar(500)	= null
	,@IpAddress			varchar(40)		= null
	,@HostName			varchar(50)		= null

AS
SET NOCOUNT ON 
-- Variables para manejo de Errores
DECLARE @Errores int = 0, @Mensaje nvarchar(300) = '', @IDAActualizar int
-- Variables para Bitácora
DECLARE @TablaNombreBitacora   nvarchar(100) = 'CmpCompraPago',	
		@Operacion	nvarchar(20) = '', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit
-- Variables para valores anteriores (Bitácora Update) 
DECLARE	@CmpCompraEncabezadoID_ int = 0,
		@BcoMovimientoID_ int = 0,
		@Importe_ decimal(18,2) = 0.0,
		@CmpCompraPagoID_ int = @CmpCompraPagoID

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION

	SET @IDAActualizar = @CmpCompraPagoID
	-- Si es UPDATE -> Lee valores anteriores de las columnas (Bitácora Update) 
	IF @IDAActualizar > 0
	BEGIN
		SELECT	@CmpCompraEncabezadoID_ = IsNull(CmpCompraEncabezadoID,0),
				@BcoMovimientoID_ = IsNull(BcoMovimientoID,0),
				@Importe_ = IsNull(Importe,0.0),
				@CmpCompraPagoID_ = IsNull(CmpCompraPagoID,0)
		   FROM	CmpCompraPago WHERE CmpCompraPagoID = @IDAActualizar
		IF @@RowCount = 0
			SELECT @Errores = 999999, @Mensaje = CONCAT('No se encontró el ID a Actualizar:', ' ', @IDAActualizar);
	END
	-- Si no hubo error (es INSERT o es UPDATE y existe el registro)
	IF @Errores = 0
	BEGIN
		-- Si la llave existe hace UPDATE y si no, hace INSERT
		IF @IDAActualizar > 0
		BEGIN

			UPDATE  CmpCompraPago
			SET     CmpCompraEncabezadoID = @CmpCompraEncabezadoID,
					BcoMovimientoID = @BcoMovimientoID,
					Importe = @Importe
			WHERE   CmpCompraPagoID = @IDAActualizar
		END
		ELSE
		BEGIN        
			INSERT  INTO CmpCompraPago(
					CmpCompraEncabezadoID,
					BcoMovimientoID,
					Importe)
			VALUES  (
					@CmpCompraEncabezadoID,
					@BcoMovimientoID,
					@Importe)

			SET     @IDAActualizar = SCOPE_IDENTITY()
		END

		IF @@RowCount > 0
		BEGIN
			/* Procesa Bitácora */
			-- Determina si fue UPDATE o INSERT
			IF @CmpCompraPagoID_ > 0  SET @Operacion = 'Update' 	
						ELSE SET @Operacion = 'Create' 

			-- Revisa si el cambio debe ser guardado en Bitácora
			EXEC	@isChangeBeLogged	=   SistemaLogRegla_Consultar_LogBit
					@UsuarioID			=	@UsuarioIDBitcora,
					@TablaNombre		=   @TablaNombreBitacora,
					@Operacion			=	@Operacion

			-- Si el cambio debe guardarse, prepara variables de Bitácora y lo guarda
			IF @isChangeBeLogged = 1 
			BEGIN
				-- logMessage = Cambios efectuados
				SET @logMessage = Concat('CmpCompraEncabezadoID::', @CmpCompraEncabezadoID_, ':', @CmpCompraEncabezadoID, ';')
				SET @logMessage = Concat(@logMessage, 'BcoMovimientoID::', @BcoMovimientoID_, ':', @BcoMovimientoID, ';')
				SET @logMessage = Concat(@logMessage, 'Importe::', @Importe_, ':', @Importe, ';')
				PRINT @logMessage
				-- Guarda en Bitácora
				EXEC 	 [dbo].[SistemaLog_Guardar] @TablaNombre		= @TablaNombreBitacora
														,@TablaID			= @IDAActualizar
														,@TablaColumna1		= ''
														,@TablaColumna2		= ''
														,@Operacion			= @Operacion
														,@UsuarioID			= @UsuarioIDBitcora
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