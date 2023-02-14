
-- OJO PVP: FALTA VER TIPOMOVIMIENTOPROVEEDOR = COMPRA, ESTÁ FIJO EN 1
CREATE PROCEDURE [dbo].[CmpOrdenCompraACompra_Guardar]
@CmpOrdenCompraEncabezadoID int
-- Parámetros para Bitácora
	,@UsuarioIDBitcora		int
	,@DescripcionBitacora	varchar(500)	= null
	,@IpAddress			varchar(40)		= null
	,@HostName			varchar(50)		= null

AS
-- Variables para manejo de Errores
DECLARE @Errores int = 0, @Mensaje nvarchar(300) = ''
-- Variables para Bitácora
DECLARE @TablaNombreIDBitacora   nvarchar(100) = 'CmpCompraEncabezado', @IDDoctoAgregado int,
		@Operacion	nvarchar(20) = 'Create', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit
-- Variables para valores anteriores (Bitácora Update) 
DECLARE	@PpalSucursalID_ int = 0,
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
		@CmpOrdenCompraEncabezadoID_ int = @CmpOrdenCompraEncabezadoID

DECLARE @TipoDocumentoCompraID int = 4,  
		@SeriePredeterminadaID int,
		@SiguienteFolio int

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION

	-- Lee datos del encabezado de O.C. 
	IF @CmpOrdenCompraEncabezadoID_ > 0
	BEGIN
		SELECT	@PpalSucursalID_  = IsNull(PpalSucursalID,0),
				@TipoDocumentoID_ = IsNull(@TipoDocumentoCompraID,0),
				@SerieID_ = IsNull(PpalSerieID,0),
				@Folio_ = IsNull(Folio,0),
				@PpalProveedorID_  = IsNull(PpalProveedorID,0),
				@PersonalID_ = IsNull(PpalPersonalID,0),
				@Fecha_ = IsNull(Fecha,0),
				@Referencia_ = ISNull(Referencia,''),
				@Concepto_ = IsNull(Concepto,''),
				@EstatusDocumentoID_ = IsNull(CfgEstatusDocumentoID,0),
				@LinkXML_ = ISNull(LinkXML,''),
				@LinkPDF_ = ISNull(LinkPDF,''),
				@EstatusFactura_ = ISNull(EstatusFactura,''),
				@PpalCentroCostoID_ = IsNull(PpalCentroCostoID,0),
				@PpalConceptoEgresoID_ = IsNull(PpalConceptoEgresoID,0)
		   FROM	CmpOrdenCompraEncabezado WHERE CmpOrdenCompraEncabezadoID = @CmpOrdenCompraEncabezadoID_
		IF @@RowCount = 0
			SELECT @Errores = 999999, @Mensaje = CONCAT('No se encontró el ID de Orden de Compra:', ' ', @CmpOrdenCompraEncabezadoID);
		-- Si no hubo error Crea la Compra
		IF @Errores = 0
		BEGIN
			-- LEE SERIE PREDETERMINADA DE COMPRAS (SI NO EXISTE -> ERROR)
			SELECT @SeriePredeterminadaID = PpalSerieID, @SiguienteFolio = UltimoFolio + 1
			  FROM PpalSerie WHERE TipoDocumentoID = @TipoDocumentoCompraID AND Predeterminado = 1;
			IF @@RowCount = 0
				SELECT @Errores = 999999, @Mensaje = 'No se encontró el Serie Predeterminada de Compras';
			-- actualiza el folio en serie
			ELSE
				UPDATE	PpalSerie
				   SET	UltimoFolio = UltimoFolio + 1
				 WHERE	PpalSerieID = @SeriePredeterminadaID
			-- Lee último folio de la serie
			SELECT	@Folio_ = UltimoFolio
			  FROM	PpalSerie
			 WHERE	PpalSerieID = @SeriePredeterminadaID

			IF @Errores = 0
			BEGIN
				-- LEE ESTATUS INICIAL DE COMPRA
				SELECT @EstatusDocumentoID_ = CED.CfgEstatusDocumentoID
				  FROM CfgEstatusDocumento CED
					LEFT OUTER JOIN SistemaEstatusTipoDocumento SETD ON CED.SistemaEstatusTipoDocumentoID = SETD.SistemaEstatusTipoDocumentoID
				 WHERE SETD.TipoDocumentoID = 4 AND SETD.Predeterminado = 1
				IF @@RowCount = 0
					SELECT @Errores = 999999, @Mensaje = 'No se encontró el Serie Predeterminada de Compras';
				IF @Errores = 0
				BEGIN
					-- SI EXISTE-> AGREGA ENCABEZADO DE COMPRAS
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
							@PpalSucursalID_,
							@TipoDocumentoCompraID,
							@SeriePredeterminadaID,
							@Folio_,
							@PpalProveedorID_,
							1,
							@PersonalID_,
							GetDate(),
							@Referencia_,
							@Concepto_,
							@EstatusDocumentoID_,
							@LinkXML_,
							@LinkPDf_,
							@EstatusFactura_,
							@PpalCentroCostoID_,
							@PpalConceptoEgresoID_
							)
        
					SET     @IDDoctoAgregado = SCOPE_IDENTITY()
				END
				-- SI AGREGÓ -> AGREGA DETALLES
				IF @IDDoctoAgregado > 0
					INSERT INTO CmpCompraDetalle
							(CmpCompraEncabezadoID,				    Renglon,			PpalProductoID,
							Cantidad,								AuxUnidadID,		Costo,
							DescripcionAdicional)
					(SELECT @IDDoctoAgregado,						Renglon,			PpalProductoID,
							Cantidad,								AuxUnidadID,		Costo,
							DescripcionAdicional
					   FROM CmpOrdenCompraDetalle
					  WHERE CmpOrdenCompraEncabezadoID = @CmpOrdenCompraEncabezadoID)
			END

			IF @IDDoctoAgregado > 0
			BEGIN
				/* Procesa Bitácora */
				-- Revisa si el cambio debe ser guardado en Bitácora
				EXEC	@isChangeBeLogged	=   SistemaLogRegla_Consultar_LogBit
						@UsuarioID			=	@UsuarioIDBitcora,
						@TablaNombre		=   @TablaNombreIDBitacora,
						@Operacion			=	@Operacion

				-- Si el cambio debe guardarse, prepara variables de Bitácora y lo guarda
				IF @isChangeBeLogged = 1 
				BEGIN
					-- logMessage = Cambios efectuados
					SET @logMessage = Concat('CmpCompraEncabezadoID::', @CmpOrdenCompraEncabezadoID_, ':', 0, ';')
					SET @logMessage = Concat(@logMessage, 'PpalSucursalID::', @PpalSucursalID_, ':', 0, ';')
					SET @logMessage = Concat(@logMessage, 'TipoDocumentoID::', @TipoDocumentoID_, ':', 0, ';')
					SET @logMessage = Concat(@logMessage, 'SerieID::', @SerieID_, ':', 0, ';')
					SET @logMessage = Concat('Folio::', @Folio_, ':', 0, ';')
					SET @logMessage = Concat('PpalProveedorID::', @PpalProveedorID_, ':', 0, ';')
					SET @logMessage = Concat(@logMessage, 'TipoMovimientoProveedorID::', @TipoMovimientoProveedorID_, ':;')
					SET @logMessage = Concat(@logMessage, 'PersonalID::', @PersonalID_, ':;')
					SET @logMessage = Concat(@logMessage, 'Fecha::', @Fecha_, ':;')
					SET @logMessage = Concat('Referencia::', @Referencia_, ':;')
					SET @logMessage = Concat('Concepto::', @Concepto_, ':;')
					SET @logMessage = Concat(@logMessage, 'EstatusDocumentoID::', @EstatusDocumentoID_, ':', 0, ';')
					SET @logMessage = Concat('LinkXML::', @LinkXML_, ':;')
					SET @logMessage = Concat('LinkPDf::', @LinkPDf_, ':;')
					SET @logMessage = Concat('EstatusFactura::', @EstatusFactura_, ':;')
					SET @logMessage = Concat('PpalCentroCostoID::', @PpalCentroCostoID_, ':', 0, ';')
					SET @logMessage = Concat('PpalConceptoEgresoID::', @PpalConceptoEgresoID_, ':', 0, ';')

					PRINT @logMessage
					-- Guarda en Bitácora
					EXEC 	 [dbo].[SistemaLog_Guardar] @TablaNombre		= @TablaNombreIDBitacora
															,@TablaID			= @IDDoctoAgregado
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
		@IDDoctoAgregado as GuardarID