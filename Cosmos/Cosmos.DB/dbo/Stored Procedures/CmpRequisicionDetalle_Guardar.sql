

CREATE PROCEDURE [dbo].[CmpRequisicionDetalle_Guardar]
@CmpRequisicionDetalleID int,
@CmpRequisicionEncabezadoID int,
@Renglon int,
@PpalProductoID int,
@Cantidad float,
@UnidadID int,
@AlmacenID int,
@ConceptoEgresoID int,
@CuentaContableID int,
@DescripcioAdicional varchar(500),
@CfgEstatusDocumentoID int
-- Parámetros para Bitácora
	,@UsuarioIDBitacora		int
	,@DescripcionBitacora	varchar(500)	= null
	,@IpAddress				varchar(40)		= null
	,@HostName				varchar(50)		= null

AS
-- Variables para manejo de Errores
DECLARE @Errores int = 0, @Mensaje nvarchar(300) = '', @IDAActualizar int
-- Variables para Bitácora
DECLARE @TablaNombreIDBitacora  nvarchar(100) = 'CmpRequisicionDetalle',	
		@Operacion	nvarchar(20) = '', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit
-- Variables para valores anteriores (Bitácora Update) 
DECLARE	@CmpRequisicionEncabezadoID_ int = 0,
		@Renglon_ int = 0,
		@ProductoID_ int = 0,
		@Cantidad_ float = 0.0,
		@UnidadID_ int = 0,
		@AlmacenID_ int = 0,
		@ConceptoEgresoID_ int = 0,
		@CuentaContableID_ int = 0,
		@DescripcioAdicional_ varchar(500) = '',
		@EstatusDocumentoID_ int = 0,
		@CmpRequisicionDetalleID_ int = @CmpRequisicionDetalleID

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION

	SET @IDAActualizar = @CmpRequisicionDetalleID
	-- Si es UPDATE -> Lee valores anteriores de las columnas (Bitácora Update) 
	IF @IDAActualizar > 0
	BEGIN
		SELECT	@CmpRequisicionEncabezadoID_ = IsNull(CmpRequisicionEncabezadoID,0),
				@Renglon_ = IsNull(Renglon,0),
				@ProductoID_ = IsNull(PpalProductoID,0),
				@Cantidad_ = IsNull(Cantidad,0.0),
				@UnidadID_ = IsNull(AuxUnidadID,0),
				@AlmacenID_ = IsNull(PpalAlmacenID,0),
				@CuentaContableID_ = IsNull(PpalCuentaContableID,0),
				@DescripcioAdicional_ = IsNull(DescripcionAdicional,''),
				@EstatusDocumentoID_ = IsNull(CfgEstatusDocumentoID,0),
				@CmpRequisicionDetalleID_ = IsNull(CmpRequisicionDetalleID,0)
		   FROM	CmpRequisicionDetalle WHERE CmpRequisicionDetalleID = @IDAActualizar
		IF @@RowCount = 0
		SELECT @Errores = 999999, @Mensaje = CONCAT('No se encontró el ID a Actualizar:', ' ', @IDAActualizar);
	END
	-- Si no hubo error (es INSERT o es UPDATE y existe el registro)
	IF @Errores = 0
	BEGIN
		-- Si la llave existe hace UPDATE y si no, hace INSERT
		IF @IDAActualizar > 0
		BEGIN
			UPDATE  CmpRequisicionDetalle
			SET     CmpRequisicionEncabezadoID = @CmpRequisicionEncabezadoID,
					Renglon = @Renglon,
					PpalProductoID = @PpalProductoID,
					Cantidad = @Cantidad,
					AuxUnidadID = @UnidadID,
					PpalAlmacenID = @AlmacenID,
					PpalConceptoEgresoID = @ConceptoEgresoID,
					PpalCuentaContableID = @CuentaContableID,
					DescripcionAdicional = @DescripcioAdicional,
					CfgEstatusDocumentoID = @CfgEstatusDocumentoID
			WHERE   CmpRequisicionDetalleID = @IDAActualizar
		END
		ELSE
		BEGIN        
			INSERT  INTO CmpRequisicionDetalle(
					CmpRequisicionEncabezadoID,
					Renglon,
					PpalProductoID,
					Cantidad,
					AuxUnidadID,
					PpalAlmacenID,
					PpalConceptoEgresoID,
					PpalCuentaContableID,
					DescripcionAdicional,
					CfgEstatusDocumentoID)
			VALUES  (
					@CmpRequisicionEncabezadoID,
					@Renglon,
					@PpalProductoID,
					@Cantidad,
					@UnidadID,
					@AlmacenID,
				    @ConceptoEgresoID,
					@CuentaContableID,
					@DescripcioAdicional,
					@CfgEstatusDocumentoID)
        
			SET     @IDAActualizar = SCOPE_IDENTITY()
		END

		IF @@RowCount > 0
		BEGIN
			/* Procesa Bitácora */
			-- Determina si fue UPDATE o INSERT
			IF @CmpRequisicionDetalleID_ > 0  SET @Operacion = 'Update' 	
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
				SET @logMessage = Concat('CmpRequisicionEncabezadoID::', @CmpRequisicionEncabezadoID_, ':', @CmpRequisicionEncabezadoID, ';')
				SET @logMessage = Concat(@logMessage, 'Renglon::', @Renglon_, ':', @Renglon, ';')
				SET @logMessage = Concat(@logMessage, 'ProductoID::', @ProductoID_, ':', @PpalProductoID, ';')
				SET @logMessage = Concat(@logMessage, 'Cantidad::', @Cantidad_, ':', @Cantidad, ';')
				SET @logMessage = Concat('UnidadID::', @UnidadID_, ':', @UnidadID, ';')
				SET @logMessage = Concat('AlmacenID::', @AlmacenID_, ':', @AlmacenID, ';')
				SET @logMessage = Concat(@logMessage, 'ConceptoEgresoID::', @ConceptoEgresoID_, ':', @ConceptoEgresoID, ';')
				SET @logMessage = Concat(@logMessage, 'CuentaContableID::', @CuentaContableID_, ':', @CuentaContableID, ';')
				SET @logMessage = Concat(@logMessage, 'DescripcioAdicional::', @DescripcioAdicional_, ':', @DescripcioAdicional, ';')
				SET @logMessage = Concat(@logMessage, 'EstatusDocumentoID::', @EstatusDocumentoID_, ':', @CfgEstatusDocumentoID, ';')
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