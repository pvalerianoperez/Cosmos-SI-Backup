

CREATE PROCEDURE [dbo].[CmpCompra_ListadoCargaFacturasPersonal]
@FechaInicial DateTime,
@FechaFinal DateTime,
@ProveedorID	int,
@EstatusFactura varchar(20)
-- Parámetros para Bitácora
	,@UsuarioIDBitacora		int
	,@DescripcionBitacora	varchar(500)	= null
	,@IpAddress				varchar(40)		= null
	,@HostName				varchar(50)		= null

AS
-- Variables para manejo de Errores
DECLARE @Errores int = 0, @Mensaje nvarchar(300)
-- Variables para Bitácora          
DECLARE @TablaNombreBitacora   nvarchar(100) = 'CmpCompraEncabezado',	
		@Operacion	nvarchar(20) = 'ListaParametros', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION

	SELECT CCE.CmpCompraEncabezadoID,							MAX(PSu.Nombre) AS SucursalNombre,				
		MAX(PSe.PpalSerieClave) AS SerieClave,						MAX(CCE.Folio) AS Folio,
		MAX(CCE.Fecha) AS Fecha,									MAX(CED.Nombre) AS EstatusNombre,
		MAX(CASE WHEN FisicaMoral = 'F' 
			THEN EP.Nombre + ' ' + EP.ApellidoPaterno + ' ' + EP.ApellidoMaterno
			ELSE EP.NombreComercial END) AS ProveedorNombre,		SUM(Cantidad * Costo) AS ImporteTotal,
		MAX(CCE.Referencia) AS Referencia,							MAX(CCE.Concepto) AS Concepto,
		MAX(CCE.LinkXML) as LinkXML,								MAX(CCE.LinkPDF) AS LinkPDF,
		MAX(CASE WHEN CCE.EstatusFactura = 'S' THEN 'CARGADA' WHEN CCE.EstatusFactura = 'N' THEN 'NO CARGADA' 
				 WHEN CCE.EstatusFactura = 'I' THEN 'INCORRECTA' ELSE 'REVISADA'  END) AS EstatusFactura,
		( SELECT SUM(ROUND(ROUND(CCD.Costo * CCD.Cantidad,2) *  CTI.PorcentajeIVA / 100,2)) Importe
			FROM CmpCompraDetalle CCD
			LEFT OUTER JOIN PpalProducto PP ON CCD.PpalProductoID = PP.PpalProductoID
			LEFT OUTER JOIN CfgTasaIVA CTI ON PP.CfgTasaIVAID = CTI.CfgTasaIVAID
		   WHERE CCD.CmpCompraEncabezadoID = CCE.CmpCompraEncabezadoID ) as IVA,
		( SELECT SUM(ROUND(CEIRD.Porcentaje * ROUND(CCD.Costo * CCD.Cantidad,2) / 100,2))
			FROM CmpCompraDetalle CCD, CfgEsquemaImpuestoRetencionDetalle CEIRD
			LEFT OUTER JOIN CfgImpuestoRetencion CIR ON (CEIRD.CfgImpuestoRetencionID = CIR.CfgImpuestoRetencionID)
		   WHERE CEIRD.Activo = 'S' AND CEIRD.CfgEsquemaImpuestoRetencionID = 1 and 
				CCD.CmpCompraEncabezadoID = CCE.CmpCompraEncabezadoID) as Retenciones
	  FROM CmpCompraEncabezado CCE
		LEFT OUTER JOIN PpalSucursal PSu ON CCE.PpalSucursalID = PSu.PpalSucursalID
		LEFT OUTER JOIN PpalSerie PSe ON CCE.PpalSerieID = PSe.PpalSerieID
		LEFT OUTER JOIN PpalProveedor PP ON CCE.PpalProveedorID = PP.PpalProveedorID
		LEFT OUTER JOIN CfgEstatusDocumento CED ON CCE.CfgEstatusDocumentoID = CED.CfgEstatusDocumentoID
		LEFT OUTER JOIN EspPersona EP ON PP.EspPersonaID = EP.EspPersonaID
		LEFT OUTER JOIN CmpCompraDetalle CCD ON CCE.CmpCompraEncabezadoID = CCD.CmpCompraEncabezadoID
	 WHERE CCE.Fecha Between @FechaInicial and @FechaFinal
	    AND (CCE.PpalProveedorID = @ProveedorID or @ProveedorID = 0)
	GROUP BY CCE.CmpCompraEncabezadoID
	/* Procesa Bitácora */
	-- Revisa si el cambio debe ser guardado en Bitácora
	EXEC	@isChangeBeLogged	=   SistemaLogRegla_Consultar_LogBit
			@UsuarioID			=	@UsuarioIDBitacora,
			@TablaNombre		=   @TablaNombreBitacora,
			@Operacion			=	@Operacion

	-- Si el cambio debe guardarse, prepara variables de Bitácora y lo guarda
	IF @isChangeBeLogged = 1 And @@RowCount > 0
	BEGIN
		-- logMessage = Parámetros de Listado
		SET @logMessage =  Concat('FechaInicial::', @FechaInicial, ':',0, ';')
		SET @logMessage = Concat(@logMessage, 'FechaFinal::', @FechaFinal, ':', 0, ';')
		SET @logMessage = Concat(@logMessage, 'EstatusFactura::', @EstatusFactura, ':', 0, ';')

		-- Guarda en Bitácora
		EXEC 	 [dbo].[SistemaLog_Guardar] @TablaNombre		= @TablaNombreBitacora
												,@TablaID			= 0
												,@TablaColumna1		= ''
												,@TablaColumna2		= ''
												,@Operacion			= @Operacion
												,@UsuarioID			= @UsuarioIDBitacora
												,@Descripcion		= @DescripcionBitacora
												,@Cambios			= @logMessage
												,@IpAddress			= @IpAddress
												,@HostName			= @HostName
	END
	-- Si no hubo errores -> COMMIT
	COMMIT TRANSACTION
END TRY
-- Si hubo error los procesa y lo regresa
BEGIN CATCH
	IF (XACT_STATE()) = -1 ROLLBACK TRANSACTION;
	IF (XACT_STATE()) = 1 COMMIT TRANSACTION;
    SELECT @Errores = ERROR_NUMBER(), 
			@Mensaje = dbo.FDecodificaError(ERROR_NUMBER(), ERROR_MESSAGE(), ERROR_SEVERITY(), ERROR_STATE(), ERROR_PROCEDURE(), ERROR_LINE())
END CATCH 

SELECT  COALESCE(@Errores, 0) as Errores, 
        COALESCE(@Mensaje, '') as Mensaje,
		COALESCE(ERROR_SEVERITY(), 0) as Severidad,
		COALESCE(ERROR_STATE(), 0) as Estado,
		COALESCE(ERROR_PROCEDURE(), '') as ProcedimientoAlmacenado,
		COALESCE(ERROR_LINE(), 0) as Linea