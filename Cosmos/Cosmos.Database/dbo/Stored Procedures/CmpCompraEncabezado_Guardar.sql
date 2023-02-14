

CREATE PROCEDURE [dbo].[CmpCompraEncabezado_Guardar]
@CmpCompraEncabezadoID int,
@SucursalID int,
@TipoDocumentoID int,
@PpalSerieID int,
@Folio int,
@PpalProveedorID int,
@TipoMovimientoProveedorID int,
@PersonalID int,
@Fecha datetime,
@Referencia varchar(50) = null,
@Concepto varchar(100) = null,
@EstatusDocumentoID int,
@LinkXML varchar(250),
@LinkPDF varchar(250),
@EstatusFactura char(1),
@PpalCentroCostoID int,
@PpalConceptoEgresoID int
-- Parámetros para Bitácora
	,@UsuarioIDBitcora		int
	,@DescripcionBitacora	varchar(500)	= null
	,@IpAddress			varchar(40)		= null
	,@HostName			varchar(50)		= null

AS
-- Variables para manejo de Errores
DECLARE @Errores int = 0, @Mensaje nvarchar(300) = ''
-- Variables para Bitácora
DECLARE @TablaNombreIDBitacora   nvarchar(100) = 'CmpCompraEncabezado', @IDAActualizar int,
		@Operacion	nvarchar(20) = '', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit
-- Variables para valores anteriores (Bitácora Update) 
DECLARE	@SucursalID_ int = 0,
		@TipoDocumentoID_ int = 0,
		@SerieID_ int = 0,
		@Folio_ int = 0,
		@PpalProveedorID_ int = 0,
		@TipoMovimientoProveedorID_ int = 0,
		@PersonalID_ int = 0,
		@Fecha_ datetime = 0,
		@Referencia_ varchar(50) = '',
		@Concepto_ varchar(100) = '',
		@EstatusDocumentoID_ int = 0,
		@LinkXML_ varchar(250) = '',
		@LinkPDF_ varchar(250) = '',
		@EstatusFactura_ char(1) = '',
		@PpalCentroCostoID_ int = 0,
		@PpalConceptoEgresoID_ int = 0,
		@CmpCompraEncabezadoID_ int = @CmpCompraEncabezadoID

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION

	SET @IDAActualizar = @CmpCompraEncabezadoID
	-- Si es UPDATE -> Lee valores anteriores de las columnas (Bitácora Update) 
	IF @IDAActualizar > 0
	BEGIN
		SELECT	@SucursalID_  = IsNull(PpalSucursalID,0),
				@TipoDocumentoID_ = IsNull(TipoDocumentoID,0),
				@SerieID_ = IsNull(PpalSerieID,0),
				@Folio_ = IsNull(Folio,0),
				@PpalProveedorID_  = IsNull(PpalProveedorID,0),
				@TipoMovimientoProveedorID_ = IsNull(CmpTipoMovimientoProveedorID,0),
				@PersonalID_ = IsNull(PpalPersonalID,0),
				@Fecha_ = IsNull(Fecha,0),
				@Referencia_ = ISNull(Referencia,''),
				@Concepto_ = IsNull(Concepto,''),
				@EstatusDocumentoID_ = IsNull(CfgEstatusDocumentoID,0),
				@LinkXML_ = ISNull(@LinkXML,''),
				@LinkPDF_ = ISNull(@LinkPDF,''),
				@EstatusFactura_ = ISNull(@EstatusFactura,''),
				@PpalCentroCostoID_ = IsNull(@PpalCentroCostoID,0),
				@PpalConceptoEgresoID_ = IsNull(@PpalConceptoEgresoID,0)
		   FROM	CmpCompraEncabezado WHERE CmpCompraEncabezadoID = @IDAActualizar
		IF @@RowCount = 0
			SELECT @Errores = 999999, @Mensaje = CONCAT('No se encontró el ID a Actualizar:', ' ', @IDAActualizar);
	END
	-- Si no hubo error (es INSERT o es UPDATE y existe el registro)
	IF @Errores = 0
	BEGIN
		-- Si la llave existe hace UPDATE y si no, hace INSERT
		IF @IDAActualizar > 0
		BEGIN
			UPDATE  CmpCompraEncabezado
			SET     PpalSucursalID = @SucursalID,
					TipoDocumentoID = @TipoDocumentoID,
					PpalSerieID  = @PpalSerieID,
					Folio = @Folio,
					PpalProveedorID = @PpalProveedorID,
					CmpTipoMovimientoProveedorID = @TipoMovimientoProveedorID,
					PpalPersonalID = @PersonalID,
					Fecha = @Fecha,
					Referencia = @Referencia,
					Concepto = @Concepto,
					CfgEstatusDocumentoID = @EstatusDocumentoID,
					LinkXML = @LinkXML,
					LinkPDf = @LinkPDf,
					EstatusFactura = @EstatusFactura,
					PpalCentroCostoID = @PpalCentroCostoID,
					PpalConceptoEgresoID = @PpalConceptoEgresoID
			WHERE   CmpCompraEncabezadoID = @IDAActualizar
		END
		ELSE
		BEGIN        
			INSERT  INTO CmpCompraEncabezado(
					PpalSucursalID,
					TipoDocumentoID,
					PpalSerieID,
					Folio,
					PpalProveedorID,
					CmpTipoMovimientoProveedorID,
					PpalPersonalID,
					Fecha,
					Referencia,
					Concepto,
					CfgEstatusDocumentoID,
					LinkXML,
					LinkPDf,
					EstatusFactura,
					PpalCentroCostoID,
					PpalConceptoEgresoID)
			VALUES  (
					@SucursalID,
					@TipoDocumentoID,
					@PpalSerieID,
					@Folio,
					@PpalProveedorID,
					@TipoMovimientoProveedorID,
					@PersonalID,
					@Fecha,
					@Referencia,
					@Concepto,
					@EstatusDocumentoID,
					@LinkXML,
					@LinkPDf,
					@EstatusFactura,
					@PpalCentroCostoID,
					@PpalConceptoEgresoID
)
        
			SET     @IDAActualizar = SCOPE_IDENTITY()
		END

		IF @@RowCount > 0
		BEGIN
			/* Procesa Bitácora */
			-- Determina si fue UPDATE o INSERT
			IF @CmpCompraEncabezadoID_ > 0  SET @Operacion = 'Update' 	
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
				SET @logMessage = Concat('CmpCompraEncabezadoID::', @CmpCompraEncabezadoID_, ':', @CmpCompraEncabezadoID, ';')
				SET @logMessage = Concat(@logMessage, 'SucursalID::', @SucursalID_, ':', @SucursalID, ';')
				SET @logMessage = Concat(@logMessage, 'TipoDocumentoID::', @TipoDocumentoID_, ':', @TipoDocumentoID, ';')
				SET @logMessage = Concat(@logMessage, 'SerieID::', @SerieID_, ':', @PpalSerieID, ';')
				SET @logMessage = Concat('Folio::', @Folio_, ':', @Folio, ';')
				SET @logMessage = Concat('PpalProveedorID::', @PpalProveedorID_, ':', @PpalProveedorID, ';')
				SET @logMessage = Concat(@logMessage, 'TipoMovimientoProveedorID::', @TipoMovimientoProveedorID_, ':', @TipoMovimientoProveedorID, ';')
				SET @logMessage = Concat(@logMessage, 'PersonalID::', @PersonalID_, ':', @PersonalID, ';')
				SET @logMessage = Concat(@logMessage, 'Fecha::', @Fecha_, ':', @Fecha, ';')
				SET @logMessage = Concat('Referencia::', @Referencia_, ':', @Referencia, ';')
				SET @logMessage = Concat('Concepto::', @Concepto_, ':', @Concepto, ';')
				SET @logMessage = Concat(@logMessage, 'EstatusDocumentoID::', @EstatusDocumentoID_, ':', @EstatusDocumentoID, ';')
				SET @logMessage = Concat('LinkXML::', @LinkXML_, ':', @LinkXML, ';')
				SET @logMessage = Concat('LinkPDf::', @LinkPDf_, ':', @LinkPDf, ';')
				SET @logMessage = Concat('EstatusFactura::', @EstatusFactura_, ':', @EstatusFactura, ';')
				SET @logMessage = Concat('PpalCentroCostoID::', @PpalCentroCostoID_, ':', @PpalCentroCostoID, ';')
				SET @logMessage = Concat('PpalConceptoEgresoID::', @PpalConceptoEgresoID_, ':', @PpalConceptoEgresoID, ';')

				PRINT @logMessage
				-- Guarda en Bitácora
				EXEC 	 [dbo].[SistemaLog_Guardar] @TablaNombre		= @TablaNombreIDBitacora
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