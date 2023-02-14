

CREATE PROCEDURE [dbo].[CmpOrdenCompraDesglose_Guardar]
@CmpOrdenCompraDesgloseID int,
@CmpOrdenCompraDetalleID int,
@Renglon int,
@PpalSucursalID int,
@PpalCentroCostoID int,
@PpalAreaID int,
@AlmacenID int,
@ConceptoEgresoID int,
@CuentaContableID int,
@Cantidad float,
@CmpRequisicionDetalleID int
-- Parámetros para Bitácora
	,@UsuarioIDBitacora		int
	,@DescripcionBitacora	varchar(500)	= null
	,@IpAddress			varchar(40)		= null
	,@HostName			varchar(50)		= null

AS
-- Variables para manejo de Errores
DECLARE @Errores int = 0, @Mensaje nvarchar(300) = '', @IDAActualizar int
-- Variables para Bitácora
DECLARE @TablaNombreIDBitacora   nvarchar(100) = 'CmpOrdenCompraDesglose',	
		@Operacion	nvarchar(20) = '', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit
-- Variables para valores anteriores (Bitácora Update) 
DECLARE	@CmpOrdenCompraDetalleID_ int = 0,
		@Renglon_ int = 0,
		@PpalSucursalID_ int = 0,
		@CentroCostoID_ int = 0,
		@AreaID_ int = 0,
		@AlmacenID_ int = 0,
		@ConceptoEgresoID_ int = 0,
		@CuentaContableID_ int = 0,
		@Cantidad_ float = 0.0,
		@CmpRequisicionDetalleID_ int = 0,
		@CmpOrdenCompraDesgloseID_ int = @CmpOrdenCompraDesgloseID

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION

	SET @IDAActualizar = @CmpOrdenCompraDesgloseID
	-- Si es UPDATE -> Lee valores anteriores de las columnas (Bitácora Update) 
	IF @IDAActualizar > 0
	BEGIN
		SELECT	@CmpOrdenCompraDetalleID_  = IsNull(CmpOrdenCompraDetalleID,0),
				@Renglon_  = IsNull(Renglon,0),
				@PpalSucursalID_  = IsNull(PpalSucursalID,0),
				@CentroCostoID_ = IsNull(PpalCentroCostoID,0),
				@AreaID_ = IsNull(PpalAreaID,0),
				@AlmacenID_ = IsNull(PpalAlmacenID,0),
				@ConceptoEgresoID_ = IsNull(ConceptoEgresoID,0),
				@CuentaContableID_ = IsNull(PpalCuentaContableID,0),
				@Cantidad_ = IsNull(Cantidad,0.0),
				@CmpRequisicionDetalleID_ = IsNull(CmpRequisicionDetalleID,0),
				@CmpOrdenCompraDesgloseID_ = IsNull(CmpOrdenCompraDesgloseID,0)
		   FROM CmpOrdenCompraDesglose WHERE CmpOrdenCompraDesgloseID = @IDAActualizar
		IF @@RowCount = 0
			SELECT @Errores = 999999, @Mensaje = CONCAT('No se encontró el ID a Actualizar:', ' ', @IDAActualizar);
	END
	-- Si no hubo error (es INSERT o es UPDATE y existe el registro)
	IF @Errores = 0
	BEGIN
		-- Si la llave existe hace UPDATE y si no, hace INSERT
		IF @IDAActualizar > 0
		BEGIN
			UPDATE  CmpOrdenCompraDesglose
			SET     CmpOrdenCompraDetalleID = @CmpOrdenCompraDetalleID,
					Renglon = @Renglon,
					PpalSucursalID = @PpalSucursalID,
					PpalCentroCostoID = @PpalCentroCostoID,
					PpalAreaID = @PpalAreaID,
					PpalAlmacenID = @AlmacenID,
					ConceptoEgresoID = @ConceptoEgresoID,
					PpalCuentaContableID = @CuentaContableID,
					Cantidad = @Cantidad,
					CmpRequisicionDetalleID = @CmpRequisicionDetalleID
			WHERE   CmpOrdenCompraDesgloseID = @IDAActualizar
		END
		ELSE
		BEGIN        
			INSERT  INTO CmpOrdenCompraDesglose(
					CmpOrdenCompraDetalleID,
					Renglon,
					PpalSucursalID,
					PpalCentroCostoID,
					PpalAreaID,
					PpalAlmacenID,
					ConceptoEgresoID,
					PpalCuentaContableID,
					Cantidad,
					CmpRequisicionDetalleID)
			VALUES  (
					@CmpOrdenCompraDetalleID,
					@Renglon,
					@PpalSucursalID,
					@PpalCentroCostoID,
					@PpalAreaID,
					@AlmacenID,
					@ConceptoEgresoID,
					@CuentaContableID,
					@Cantidad,
					@CmpRequisicionDetalleID)
        
			SET     @IDAActualizar = SCOPE_IDENTITY()
		END

		IF @@RowCount > 0
		BEGIN
			/* Procesa Bitácora */
			-- Determina si fue UPDATE o INSERT
			IF @CmpOrdenCompraDesgloseID_ > 0  SET @Operacion = 'Update' 	
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
				SET @logMessage = Concat('CmpOrdenCompraDetalleID::', @CmpOrdenCompraDetalleID_, ':', @CmpOrdenCompraDetalleID, ';')
				SET @logMessage = Concat(@logMessage, 'Renglon::', @Renglon_, ':', @Renglon, ';')
				SET @logMessage = Concat(@logMessage, 'PpalSucursalID::', @PpalSucursalID_, ':', @PpalSucursalID, ';')
				SET @logMessage = Concat(@logMessage, 'CentroCostoID::', @CentroCostoID_, ':', @PpalCentroCostoID, ';')
				SET @logMessage = Concat('PpalAreaID::', @AreaID_, ':', @PpalAreaID, ';')
				SET @logMessage = Concat('AlmacenID::', @AlmacenID_, ':', @AlmacenID, ';')
				SET @logMessage = Concat(@logMessage, 'ConceptoEgresoID::', @ConceptoEgresoID_, ':', @ConceptoEgresoID, ';')
				SET @logMessage = Concat(@logMessage, 'CuentaContableID::', @CuentaContableID_, ':', @CuentaContableID, ';')
				SET @logMessage = Concat(@logMessage, 'Cantidad::', @Cantidad_, ':', @Cantidad, ';')
				SET @logMessage = Concat(@logMessage, 'CmpRequisicionDetalleID::', @CmpRequisicionDetalleID_, ':', @CmpRequisicionDetalleID, ';')
				PRINT @logMessage
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