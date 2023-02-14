

CREATE PROCEDURE [dbo].[CmpOrdenCompraEncabezado_Guardar]
@CmpOrdenCompraEncabezadoID int,
@PpalSucursalID int,
@TipoDocumentoID int,
@PpalSerieID int,
@Folio int,
@PpalProveedorID int,
@PpalPersonalID int,
@Fecha datetime,
@Referencia varchar(50) = null,
@Concepto varchar(100) = null,
@CfgEstatusDocumentoID int,
@LinkXML varchar(250),
@LinkPDF varchar(250),
@EstatusFactura char(1),
@PpalCentroCostoID int,
@PpalConceptoEgresoID int,
@PpalAreaID int

-- Parámetros para Bitácora
	,@UsuarioIDBitcora		int
	,@DescripcionBitacora	varchar(500)	= null
	,@IpAddress			varchar(40)		= null
	,@HostName			varchar(50)		= null

AS
-- Variables para manejo de Errores
DECLARE @Errores int = 0, @Mensaje nvarchar(300) = '', @IDAActualizar int
-- Variables para Bitácora
DECLARE @TablaNombreIDBitacora   nvarchar(100) = 'CmpOrdenCompraEncabezado',	
		@Operacion	nvarchar(20) = '', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit
-- Variables para valores anteriores (Bitácora Update) 
DECLARE	@PpalSucursalID_ int = 0,
		@TipoDocumentoID_ int = 0,
		@SerieID_ int = 0,
		@Folio_ int = 0,
		@PpalProveedorID_ int = 0,
		@PersonalID_ int = 0,
		@Fecha_ datetime = 0,
		@Referencia_ varchar(50) = '',
		@Concepto_ varchar(100) = '',
		@CfgEstatusDocumentoID_ int = 0,
		@LinkXML_ varchar(250),
		@LinkPDF_ varchar(250),
		@EstatusFactura_ char(1),
		@PpalCentroCostoID_ int,
		@PpalConceptoEgresoID_ int,
		@PpalAreaID_ int,
		@CmpOrdenCompraEncabezadoID_ int = @CmpOrdenCompraEncabezadoID

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION

	SET @IDAActualizar = @CmpOrdenCompraEncabezadoID
	-- Si es UPDATE -> Lee valores anteriores de las columnas (Bitácora Update) 
	IF @IDAActualizar > 0
	BEGIN
		SELECT	@PpalSucursalID_ = IsNull(PpalSucursalID,0),
				@TipoDocumentoID_ = IsNull(TipoDocumentoID,0),
				@SerieID_ = IsNull(PpalSerieID,0),
				@Folio_ = IsNull(Folio,0),
				@PpalProveedorID_ = IsNull(PpalProveedorID,0),
				@PersonalID_ = IsNull(PpalPersonalID,0),
				@Fecha_ = IsNull(Fecha,0),
				@Referencia_ = IsNull(Referencia,''),
				@Concepto_ = IsNull(Concepto,''),
				@CfgEstatusDocumentoID_ = IsNull(CfgEstatusDocumentoID,0),
				@LinkXML_ = LinkXML,
				@LinkPDF_ = LinkPDF,
				@EstatusFactura_ = EstatusFactura,
				@PpalCentroCostoID_ = PpalCentroCostoID,
				@PpalConceptoEgresoID_ = PpalConceptoEgresoID,
				@PpalAreaID_ = PpalAreaID,
				@CmpOrdenCompraEncabezadoID_ = IsNull(CmpOrdenCompraEncabezadoID,0)
		   FROM	CmpOrdenCompraEncabezado WHERE CmpOrdenCompraEncabezadoID = @IDAActualizar
		IF @@RowCount = 0
		SELECT @Errores = 999999, @Mensaje = CONCAT('No se encontró el ID a Actualizar:', ' ', @IDAActualizar);
	END
	-- Si no hubo error (es INSERT o es UPDATE y existe el registro)
	IF @Errores = 0
	BEGIN
		-- Si se indicó ID hace UPDATE y si no, hace INSERT
		IF @IDAActualizar > 0
		BEGIN
			UPDATE  CmpOrdenCompraEncabezado
			SET     PpalSucursalID = @PpalSucursalID,
					TipoDocumentoID = @TipoDocumentoID,
					PpalSerieID = @PpalSerieID,
					Folio = @Folio,
					PpalProveedorID = @PpalProveedorID,
					PpalPersonalID = @PpalPersonalID,
					Fecha = @Fecha,
					Referencia = @Referencia,
					Concepto = @Concepto,
					LinkXML = @LinkXML,
					LinkPDF = @LinkPDF,
					EstatusFactura = @EstatusFactura,
					PpalCentroCostoID = @PpalCentroCostoID,
					PpalConceptoEgresoID = @PpalConceptoEgresoID,
					PpalAreaID = @PpalAreaID,
					CfgEstatusDocumentoID = @CfgEstatusDocumentoID
			WHERE   CmpOrdenCompraEncabezadoID = @IDAActualizar
		END
		ELSE
		BEGIN
			-- Lo actualiza en serie
			UPDATE	PpalSerie
			   SET	UltimoFolio = UltimoFolio + 1
			 WHERE	PpalSerieID = @PpalSerieID
			-- Lee último folio de la serie
			SELECT	@Folio_ = UltimoFolio
			  FROM	PpalSerie
			 WHERE	PpalSerieID = @PpalSerieID
			SET @Folio = @Folio_
			INSERT  INTO CmpOrdenCompraEncabezado(
					PpalSucursalID,
					TipoDocumentoID,
					PpalSerieID,
					Folio,
					PpalProveedorID,
					PpalPersonalID,
					Fecha,
					Referencia,
					Concepto,
					LinkXML,
					LinkPDF,
					EstatusFactura,
					PpalCentroCostoID,
					PpalConceptoEgresoID,
					PpalAreaID,
					CfgEstatusDocumentoID)
			VALUES  (
					@PpalSucursalID,
					@TipoDocumentoID,
					@PpalSerieID,
					@Folio,
					@PpalProveedorID,
					@PpalPersonalID,
					@Fecha,
					@Referencia,
					@Concepto,
					@LinkXML,
					@LinkPDF,
					@EstatusFactura,
					@PpalCentroCostoID,
					@PpalConceptoEgresoID,
					@PpalAreaID,
					@CfgEstatusDocumentoID)
        
			SET     @IDAActualizar = SCOPE_IDENTITY()
		END

		IF @@RowCount > 0
		BEGIN
			/* Procesa Bitácora */
			-- Determina si fue UPDATE o INSERT
			IF @CmpOrdenCompraEncabezadoID_ > 0  SET @Operacion = 'Update' 	
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
				SET @logMessage = Concat('PpalSucursalID::', @PpalSucursalID_, ':', @PpalSucursalID, ';')
				SET @logMessage = Concat(@logMessage, 'TipoDocumentoID::', @TipoDocumentoID_, ':', @TipoDocumentoID, ';')
				SET @logMessage = Concat(@logMessage, 'SerieID::', @SerieID_, ':', @PpalSerieID, ';')
				SET @logMessage = Concat(@logMessage, 'Folio::', @Folio_, ':', @Folio, ';')
				SET @logMessage = Concat('PpalProveedorID::', @PpalProveedorID_, ':', @PpalProveedorID, ';')
				SET @logMessage = Concat('PpalPersonalID::', @PersonalID_, ':', @PpalPersonalID, ';')
				SET @logMessage = Concat(@logMessage, 'Fecha::', @Fecha_, ':', @Fecha, ';')
				SET @logMessage = Concat(@logMessage, 'Referencia::', @Referencia_, ':', @Referencia, ';')
				SET @logMessage = Concat(@logMessage, 'Concepto::', @Concepto_, ':', @Concepto, ';')
				SET @logMessage = Concat(@logMessage, 'CentroCostoID::', @PpalCentroCostoID_, ':', @PpalCentroCostoID, ';')
				SET @logMessage = Concat(@logMessage, 'ConceptoEgresoID::', @PpalConceptoEgresoID_, ':', @PpalConceptoEgresoID, ';')
				SET @logMessage = Concat(@logMessage, 'PpalAreaID::', @PpalAreaID_, ':', @PpalAreaID, ';')
				SET @logMessage = Concat('EstatusDocumentoID::', @CfgEstatusDocumentoID_, ':', @CfgEstatusDocumentoID, ';')
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