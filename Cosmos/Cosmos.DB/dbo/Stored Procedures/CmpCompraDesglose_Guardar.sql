

CREATE PROCEDURE [dbo].[CmpCompraDesglose_Guardar]
@CmpCompraDesgloseID int,
@CmpCompraDetalleID int,
@Renglon int,
@PpalSucursalID int,
@CentroCostoID int,
@PpalAreaID  int,
@AlmacenID int,
@ConceptoEgresoID int,
@CuentaContableID int,
@Cantidad float,
@CmpOrdenCompraDesgloseID  int
-- Parámetros para Bitácora
	,@UsuarioIDBitcora		int
	,@DescripcionBitacora	varchar(500)	= null
	,@IpAddress			varchar(40)		= null
	,@HostName			varchar(50)		= null

AS
-- Variables para manejo de Errores
DECLARE @Errores int = 0, @Mensaje nvarchar(300) = '', @IDAActualizar int
-- Variables para Bitácora
DECLARE @TablaNombreIDBitacora   nvarchar(100) = 'CmpCompraDesglose',	
		@Operacion	nvarchar(20) = '', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit
-- Variables para valores anteriores (Bitácora Update) 
DECLARE	@CmpCompraDetalleID_ int,
		@Renglon_ int,
		@PpalSucursalID_ int,
		@CentroCostoID_ int,
		@AreaID_  int,
		@AlmacenID_ int,
		@ConceptoEgresoID_ int,
		@CuentaContableID_ int,
		@Cantidad_ float,
		@CmpOrdenCompraDesgloseID_ int,
		@CmpCompraDesgloseID_ int = @CmpCompraDesgloseID

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION

	SET @IDAActualizar = @CmpCompraDesgloseID
	-- Si es UPDATE -> Lee valores anteriores de las columnas (Bitácora Update) 
	IF @IDAActualizar > 0
	BEGIN
		SELECT	@CmpCompraDetalleID_ = IsNull(CmpCompraDetalleID,0),
				@Renglon_ = IsNull(Renglon,0),
				@PpalSucursalID_ = IsNull(PpalSucursalID,0),
				@CentroCostoID_ = IsNull(PpalCentroCostoID,0),
				@AreaID_  = IsNull(PpalAreaID,0),
				@AlmacenID_ = IsNull(PpalAlmacenID,0),
				@ConceptoEgresoID_ = IsNull(PpalConceptoEgresoID,0),
				@CuentaContableID_ = IsNull(PpalCuentaContableID,0),
				@Cantidad_ = IsNull(Cantidad,0),
				@CmpOrdenCompraDesgloseID_ = IsNull(CmpOrdenCompraDesgloseID ,0),
				@CmpCompraDesgloseID_  = @CmpCompraDesgloseID
		   FROM	CmpCompraDesglose WHERE CmpCompraDesgloseID = @IDAActualizar
		IF @@RowCount = 0
			SELECT @Errores = 999999, @Mensaje = CONCAT('No se encontró el ID a Actualizar:', ' ', @IDAActualizar);
	END
	-- Si no hubo error (es INSERT o es UPDATE y existe el registro)
	IF @Errores = 0
	BEGIN
		-- Si la llave existe hace UPDATE y si no, hace INSERT
		IF @IDAActualizar > 0
		BEGIN
			UPDATE  CmpCompraDesglose
			SET     CmpCompraDetalleID = @CmpCompraDetalleID,
					Renglon = @Renglon,
					PpalSucursalID = @PpalSucursalID,
					PpalCentroCostoID = @CentroCostoID,
					PpalAreaID = @PpalAreaID,
					PpalAlmacenID = @AlmacenID,
					PpalConceptoEgresoID = @ConceptoEgresoID,
					PpalCuentaContableID = @CuentaContableID,
					Cantidad = @Cantidad,
					CmpOrdenCompraDesgloseID  = @CmpOrdenCompraDesgloseID 
			WHERE   CmpCompraDesgloseID = @IDAActualizar
		END
		ELSE
		BEGIN        
			INSERT  INTO CmpCompraDesglose(
					CmpCompraDetalleID,
					Renglon,
					PpalSucursalID,
					PpalCentroCostoID,
					PpalAreaID,
					PpalAlmacenID,
					PpalConceptoEgresoID,
					PpalCuentaContableID,
					Cantidad,
					CmpOrdenCompraDesgloseID )
			VALUES  (
					@CmpCompraDetalleID,
					@Renglon,
					@PpalSucursalID,
					@CentroCostoID,
					@PpalAreaID,
					@AlmacenID,
					@ConceptoEgresoID,
					@CuentaContableID,
					@Cantidad,
					@CmpOrdenCompraDesgloseID )
        
			SET     @IDAActualizar = SCOPE_IDENTITY()
		END

		IF @@RowCount > 0
		BEGIN
			/* Procesa Bitácora */
			-- Determina si fue UPDATE o INSERT
			IF @CmpCompraDesgloseID_ > 0  SET @Operacion = 'Update' 	
						ELSE SET @Operacion = 'Create' 

			-- Revisa si el cambio debe ser guardado en Bitácora
			EXEC	@isChangeBeLogged	=   SistemaLogRegla_Consultar_LogBit
					@UsuarioID			=	@UsuarioIDBitcora,
					@TablaNombre		=   @TablaNombreIDBitacora,
					@Operacion			=	@Operacion

			-- Si el cambio debe guardarse, prepara variables de Bitácora y lo guarda
			IF @isChangeBeLogged = 1 
			BEGIN
				-- logMessage = Cambios efectuados
				SET @logMessage = Concat('CmpCompraDetalleID::', @CmpCompraDetalleID_, ':', @CmpCompraDetalleID, ';')
				SET @logMessage = Concat(@logMessage, 'Renglon::', @Renglon_, ':', @Renglon, ';')
				SET @logMessage = Concat(@logMessage, 'PpalSucursalID::', @PpalSucursalID_, ':', @PpalSucursalID, ';')
				SET @logMessage = Concat(@logMessage, 'CentroCostoID::', @CentroCostoID_, ':', @CentroCostoID, ';')
				SET @logMessage = Concat(@logMessage, 'AreaID::', @AreaID_, ':', @PpalAreaID, ';')
				SET @logMessage = Concat(@logMessage, 'AlmacenID::', @AlmacenID_, ':', @AlmacenID, ';')
				SET @logMessage = Concat(@logMessage, 'ConceptoEgresoID::', @ConceptoEgresoID_, ':', @ConceptoEgresoID, ';')
				SET @logMessage = Concat(@logMessage, 'CuentaContableID::', @CuentaContableID_, ':', @CuentaContableID, ';')
				SET @logMessage = Concat(@logMessage, 'Cantidad::', @Cantidad_, ':', @Cantidad, ';')
				SET @logMessage = Concat(@logMessage, 'CmpOrdenCompraDesgloseID ::', @CmpOrdenCompraDesgloseID_, ':', @CmpOrdenCompraDesgloseID , ';')
				PRINT @logMessage
				-- Guarda en Bitácora
				EXEC 	 [dbo].[SistemaLog_Guardar] @TablaNombre		= @TablaNombreIDBitacora
														,@TablaID			= @CmpCompraDesgloseID
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