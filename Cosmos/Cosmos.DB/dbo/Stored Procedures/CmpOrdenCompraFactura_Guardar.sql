

CREATE PROCEDURE [dbo].[CmpOrdenCompraFactura_Guardar]
@CmpOrdenCompraFacturaID int,
@CmpOrdenCompraEncabezadoID int,
@EspFacturaID int,
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
DECLARE @TablaNombreBitacora   nvarchar(100) = 'CmpOrdenCompraFactura',	
		@Operacion	nvarchar(20) = '', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit
-- Variables para valores anteriores (Bitácora Update) 
DECLARE	@CmpOrdenCompraEncabezadoID_ int = 0,
		@EspFacturaID_ int = 0,
		@Importe_ decimal(18,2) = 0.0,
		@CmpOrdenCompraFacturaID_ int = @CmpOrdenCompraFacturaID

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION

	SET @IDAActualizar = @CmpOrdenCompraFacturaID
	-- Si es UPDATE -> Lee valores anteriores de las columnas (Bitácora Update) 
	IF @IDAActualizar > 0
	BEGIN
		SELECT	@CmpOrdenCompraEncabezadoID_ = IsNull(CmpOrdenCompraEncabezadoID,0),
				@EspFacturaID_ = IsNull(EspFacturaID,0),
				@Importe_ = IsNull(Importe,0.0),
				@CmpOrdenCompraFacturaID_ = IsNull(CmpOrdenCompraFacturaID,0)
		   FROM	CmpOrdenCompraFactura WHERE CmpOrdenCompraFacturaID = @IDAActualizar
		IF @@RowCount = 0
			SELECT @Errores = 999999, @Mensaje = CONCAT('No se encontró el ID a Actualizar:', ' ', @IDAActualizar);
	END
	-- Si no hubo error (es INSERT o es UPDATE y existe el registro)
	IF @Errores = 0
	BEGIN
		-- Si la llave existe hace UPDATE y si no, hace INSERT
		IF @IDAActualizar > 0
		BEGIN

			UPDATE  CmpOrdenCompraFactura
			SET     CmpOrdenCompraEncabezadoID = @CmpOrdenCompraEncabezadoID,
					EspFacturaID = @EspFacturaID,
					Importe = @Importe
			WHERE   CmpOrdenCompraFacturaID = @IDAActualizar
		END
		ELSE
		BEGIN        
			INSERT  INTO CmpOrdenCompraFactura(
					CmpOrdenCompraEncabezadoID,
					EspFacturaID,
					Importe)
			VALUES  (
					@CmpOrdenCompraEncabezadoID,
					@EspFacturaID,
					@Importe)

			SET     @IDAActualizar = SCOPE_IDENTITY()
		END

		IF @@RowCount > 0
		BEGIN
			/* Procesa Bitácora */
			-- Determina si fue UPDATE o INSERT
			IF @CmpOrdenCompraFacturaID_ > 0  SET @Operacion = 'Update' 	
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
				SET @logMessage = Concat('CmpOrdenCompraEncabezadoID::', @CmpOrdenCompraEncabezadoID_, ':', @CmpOrdenCompraEncabezadoID, ';')
				SET @logMessage = Concat(@logMessage, 'EspFacturaID::', @EspFacturaID_, ':', @EspFacturaID, ';')
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