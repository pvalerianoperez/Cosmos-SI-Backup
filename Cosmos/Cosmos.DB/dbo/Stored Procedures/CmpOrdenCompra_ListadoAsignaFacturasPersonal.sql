

CREATE PROCEDURE [dbo].[CmpOrdenCompra_ListadoAsignaFacturasPersonal]
@FechaOC DateTime,
@ProveedorID	int
-- Parámetros para Bitácora
	,@EmpresaIDSolicitudBase	int
	,@UsuarioIDBitacora			int
	,@OpcionIDSolicitudBase		int
	,@DescripcionBitacora	varchar(500)	= null
	,@IpAddress				varchar(40)		= null
	,@HostName				varchar(50)		= null

AS
-- Variables para manejo de Errores
DECLARE @Errores int = 0, @Mensaje nvarchar(300)
-- Variables para Bitácora          
DECLARE @TablaNombreBitacora   nvarchar(100) = 'CmpOrdenCompraEncabezado',	
		@Operacion	nvarchar(20) = 'ListaParametros', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION

	SELECT COCE.CmpOrdenCompraEncabezadoID,							MAX(PSu.Nombre) AS SucursalNombre,				
		MAX(PSe.PpalSerieClave) AS SerieClave,						MAX(COCE.Folio) AS Folio,
		MAX(COCE.Fecha) AS Fecha,								
		SUM(Cantidad * Costo) +
		( SELECT SUM(ROUND(ROUND(COCD.Costo * COCD.Cantidad,2) *  CTI.PorcentajeIVA / 100,2))
			FROM CmpOrdenCompraDetalle COCD
			LEFT OUTER JOIN PpalProducto PP ON COCD.PpalProductoID = PP.PpalProductoID
			LEFT OUTER JOIN CfgTasaIVA CTI ON PP.CfgTasaIVAID = CTI.CfgTasaIVAID
		   WHERE COCD.CmpOrdenCompraEncabezadoID = COCE.CmpOrdenCompraEncabezadoID ) -
		( SELECT SUM(ROUND(CEIRD.Porcentaje * ROUND(COCD.Costo * COCD.Cantidad,2) / 100,2))
			FROM CmpOrdenCompraDetalle COCD, CfgEsquemaImpuestoRetencionDetalle CEIRD
			LEFT OUTER JOIN CfgImpuestoRetencion CIR ON (CEIRD.CfgImpuestoRetencionID = CIR.CfgImpuestoRetencionID)
		   WHERE CEIRD.Activo = 'S' AND CEIRD.CfgEsquemaImpuestoRetencionID = 1 and 
				COCD.CmpOrdenCompraEncabezadoID = COCE.CmpOrdenCompraEncabezadoID)  AS Total,
	    ( SELECT SUM(Importe)
			FROM CmpOrdenCompraFactura COCF
		   WHERE COCF.CmpOrdenCompraEncabezadoID = COCE.CmpOrdenCompraEncabezadoID) AS Asignado
	  FROM CmpOrdenCompraEncabezado COCE
		LEFT OUTER JOIN PpalSucursal PSu ON COCE.PpalSucursalID = PSu.PpalSucursalID
		LEFT OUTER JOIN PpalSerie PSe ON COCE.PpalSerieID = PSe.PpalSerieID
		LEFT OUTER JOIN PpalProveedor PP ON COCE.PpalProveedorID = PP.PpalProveedorID
		LEFT OUTER JOIN CfgEstatusDocumento CED ON COCE.CfgEstatusDocumentoID = CED.CfgEstatusDocumentoID
		LEFT OUTER JOIN EspPersona EP ON PP.EspPersonaID = EP.EspPersonaID
		LEFT OUTER JOIN CmpOrdenCompraDetalle COCD ON COCD.CmpOrdenCompraEncabezadoID = COCE.CmpOrdenCompraEncabezadoID
	 WHERE COCE.Fecha >= @FechaOC
	    AND (COCE.PpalProveedorID = @ProveedorID or @ProveedorID = 0)
		AND (CED.SistemaEstatusTipoDocumentoID IN (SELECT EstatusTipoDocumentoID   
													FROM SistemaEstatusDocumentoOpcion
												   WHERE OpcionID = @OpcionIDSolicitudBase) or 1 = 1)
	GROUP BY COCE.CmpOrdenCompraEncabezadoID
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
		SET @logMessage =  Concat('FechaOC::', @FechaOC, ':',0, ';')
		SET @logMessage = Concat(@logMessage, 'ProveedorID::', @ProveedorID, ':', 0, ';')
		SET @logMessage = Concat(@logMessage, 'OpcionID::', @OpcionIDSolicitudBase, ':', 0, ';')

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