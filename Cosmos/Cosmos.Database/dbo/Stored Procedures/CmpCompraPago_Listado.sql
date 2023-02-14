

CREATE PROCEDURE [dbo].[CmpCompraPago_Listado]
@BcoMovimientoID int
-- Parámetros para Bitácora
	,@UsuarioIDBitacora		int
	,@DescripcionBitacora	varchar(500)	= null
	,@IpAddress			varchar(40)		= null
	,@HostName			varchar(50)		= null

AS
-- Variables para manejo de Errores
DECLARE @Errores int = 0, @Mensaje nvarchar(300)
-- Variables para Bitácora          
DECLARE @TablaNombreBitacora   nvarchar(100) = 'CmpCompraPago',	
		@Operacion	nvarchar(20) = 'List', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION

	SELECT  MAX(CCP.CmpCompraPagoID) AS CmpCompraPagoID,		MAX(CCP.CmpCompraEncabezadoID) AS CmpCompraEncabezadoID,
			MAX(CCP.BcoMovimientoID) AS BcoMovimientoID,		MAX(CCP.Importe) AS Importe,
			MAX(PSu.Nombre) AS SucursalNombre,					MAX(PSe.PpalSerieClave) AS SerieClave,
			MAX(CCE.Folio) AS Folio,							MAX(CCE.Fecha) AS Fecha,
			SUM(Cantidad * Costo) +
			( SELECT SUM(ROUND(ROUND(CCD.Costo * CCD.Cantidad,2) *  CTI.PorcentajeIVA / 100,2))
				FROM CmpCompraDetalle CCD
				LEFT OUTER JOIN PpalProducto PP ON CCD.PpalProductoID = PP.PpalProductoID
				LEFT OUTER JOIN CfgTasaIVA CTI ON PP.CfgTasaIVAID = CTI.CfgTasaIVAID
			   WHERE CCD.CmpCompraEncabezadoID = CCE.CmpCompraEncabezadoID ) -
			( SELECT SUM(ROUND(CEIRD.Porcentaje * ROUND(CCD.Costo * CCD.Cantidad,2) / 100,2))
				FROM CmpCompraDetalle CCD, CfgEsquemaImpuestoRetencionDetalle CEIRD
				LEFT OUTER JOIN CfgImpuestoRetencion CIR ON (CEIRD.CfgImpuestoRetencionID = CIR.CfgImpuestoRetencionID)
			   WHERE CEIRD.Activo = 'S' AND CEIRD.CfgEsquemaImpuestoRetencionID = 1 and 
					CCD.CmpCompraEncabezadoID = CCE.CmpCompraEncabezadoID)  AS Total,
		    ( SELECT 0) AS Asignado
	FROM    CmpCompraPago CCP
	  LEFT OUTER JOIN CmpCompraEncabezado CCE ON CCP.CmpCompraEncabezadoID = CCE.CmpCompraEncabezadoID
	  LEFT OUTER JOIN PpalSucursal PSu ON CCE.PpalSucursalID = PSu.PpalSucursalID
	  LEFT OUTER JOIN PpalSerie PSe ON CCE.PpalSerieID = PSe.PpalSerieID
	  LEFT OUTER JOIN CmpCompraDetalle CCD ON CCE.CmpCompraEncabezadoID = CCD.CmpCompraEncabezadoID
	WHERE	BcoMovimientoID = @BcoMovimientoID
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
		SET @logMessage =  Concat('BcoMovimientoID::', @BcoMovimientoID, ':',0, ';')

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