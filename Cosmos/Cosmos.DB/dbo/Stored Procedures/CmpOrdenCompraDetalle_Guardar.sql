

CREATE PROCEDURE [dbo].[CmpOrdenCompraDetalle_Guardar]
@CmpOrdenCompraDetalleID int,
@CmpOrdenCompraEncabezadoID int,
@Renglon int,
@PpalProductoID int,
@Cantidad float,
@UnidadID int,
@Costo float,
@FechaCompromiso datetime,
@DescripcionAdicional varchar(500)
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
DECLARE @TablaNombreBitacora   nvarchar(100) = 'CmpOrdenCompraDetalle',	
		@Operacion	nvarchar(20) = '', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit
-- Variables para valores anteriores (Bitácora Update) 
DECLARE	@CmpOrdenCompraEncabezadoID_ int = 0,
		@Renglon_ int = 0,
		@ProductoID_ int = 0,
		@Cantidad_ float = 0.0,
		@UnidadID_ int = 0,
		@Costo_ float = 0.0,
		@FechaCompromiso_ datetime = 0,
		@CmpOrdenCompraDetalleID_ int = @CmpOrdenCompraDetalleID,
		@DescripcionAdicional_ varchar(500) = ''

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION

	SET @IDAActualizar = @CmpOrdenCompraDetalleID
	-- Si es UPDATE -> Lee valores anteriores de las columnas (Bitácora Update) 
	IF @IDAActualizar > 0
	BEGIN
		SELECT	@CmpOrdenCompraEncabezadoID_ = IsNull(CmpOrdenCompraEncabezadoID,0),
				@Renglon_ = IsNull(Renglon,0),
				@ProductoID_ = IsNull(PpalProductoID,0),
				@Cantidad_ = IsNull(Cantidad,0.0),
				@UnidadID_ = IsNull(AuxUnidadID,0),
				@Costo_ = IsNull(Costo,0.0),
				@FechaCompromiso_ = IsNull(FechaCompromiso,0),
				@CmpOrdenCompraDetalleID_ = IsNull(CmpOrdenCompraDetalleID,0),
				@DescripcionAdicional_ = IsNull(@DescripcionAdicional,'')
		   FROM	CmpOrdenCompraDetalle WHERE CmpOrdenCompraDetalleID = @IDAActualizar
		IF @@RowCount = 0
			SELECT @Errores = 999999, @Mensaje = CONCAT('No se encontró el ID a Actualizar:', ' ', @IDAActualizar);
	END
	-- Si no hubo error (es INSERT o es UPDATE y existe el registro)
	IF @Errores = 0
	BEGIN
		-- Si la llave existe hace UPDATE y si no, hace INSERT
		IF @IDAActualizar > 0
		BEGIN

			UPDATE  CmpOrdenCompraDetalle
			SET     CmpOrdenCompraEncabezadoID = @CmpOrdenCompraEncabezadoID,
					Renglon = @Renglon,
					PpalProductoID = @PpalProductoID,
					Cantidad = @Cantidad,
					AuxUnidadID = @UnidadID,
					Costo = @Costo,
					FechaCompromiso = @FechaCompromiso,
					DescripcionAdicional = @DescripcionAdicional
			WHERE   CmpOrdenCompraDetalleID = @IDAActualizar
		END
		ELSE
		BEGIN        
			INSERT  INTO CmpOrdenCompraDetalle(
					CmpOrdenCompraEncabezadoID,
					Renglon,
					PpalProductoID,
					Cantidad,
					AuxUnidadID,
					Costo,
					FechaCompromiso,
					DescripcionAdicional)
			VALUES  (
					@CmpOrdenCompraEncabezadoID,
					@Renglon,
					@PpalProductoID,
					@Cantidad,
					@UnidadID,
					@Costo,
					@FechaCompromiso,
					@DescripcionAdicional)
        
			SET     @IDAActualizar = SCOPE_IDENTITY()
		END

		IF @@RowCount > 0
		BEGIN
			/* Procesa Bitácora */
			-- Determina si fue UPDATE o INSERT
			IF @CmpOrdenCompraDetalleID_ > 0  SET @Operacion = 'Update' 	
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
				SET @logMessage = Concat(@logMessage, 'Renglon::', @Renglon_, ':', @Renglon, ';')
				SET @logMessage = Concat(@logMessage, 'Cantidad::', @Cantidad_, ':', @Cantidad, ';')
				SET @logMessage = Concat(@logMessage, 'UnidadID::', @UnidadID_, ':', @UnidadID, ';')
				SET @logMessage = Concat(@logMessage, 'Costo::', @Costo_, ':', @Costo, ';')
				SET @logMessage = Concat(@logMessage, 'FechaCompromiso::', @FechaCompromiso_, ':', @FechaCompromiso, ';')
				SET @logMessage = Concat(@logMessage, 'DescripcionAdicional::', @DescripcionAdicional_, ':', @DescripcionAdicional, ';')
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