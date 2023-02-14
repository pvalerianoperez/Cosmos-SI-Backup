
CREATE PROCEDURE [dbo].[CmpOrdenCompra_ListadoParametrosDetalles]
@TipoDocumentoID int,
@SucursalInicialID int,
@SucursalFinalID int,
@FechaInicial DateTime,
@FechaFinal DateTime,
@ProveedorID int,
@SerieInicialID int,
@SerieFinalID int,
@EstatusAIncluir varchar(500)
-- Parámetros para Bitácora
	,@UsuarioIDBitcora		int
	,@DescripcionBitacora	varchar(500)	= null
	,@IpAddress				varchar(40)		= null
	,@HostName				varchar(50)		= null

AS
-- Variables para manejo de Errores
DECLARE @Errores int = 0, @Mensaje nvarchar(300)
-- Variables para Bitácora          
DECLARE @TablaNombreBitacora   nvarchar(100) = 'CmpOrdenCompraDetalle',	
		@Operacion	nvarchar(20) = 'List', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION

	SELECT  COCD.CmpOrdenCompraDetalleID,	COCD.CmpOrdenCompraEncabezadoID,	COCD.Renglon,	COCD.PpalProductoID,
			COCD.Cantidad,					COCD.AuxUnidadID,					COCD.Costo,		COCD.FechaCompromiso,
			COCD.DescripcionAdicional
	  FROM CmpOrdenCompraEncabezado COCE
		LEFT OUTER JOIN PpalSucursal PSu ON COCE.PpalSucursalID = PSu.PpalSucursalID
		LEFT OUTER JOIN PpalSerie PSe ON COCE.PpalSerieID = PSe.PpalSerieID
		LEFT OUTER JOIN PpalProveedor PP ON COCE.PpalProveedorID = PP.PpalProveedorID
		LEFT OUTER JOIN CfgEstatusDocumento CED ON COCE.CfgEstatusDocumentoID = CED.CfgEstatusDocumentoID
		LEFT OUTER JOIN EspPersona EP ON PP.EspPersonaID = EP.EspPersonaID
		LEFT OUTER JOIN CmpOrdenCompraDetalle COCD ON COCE.CmpOrdenCompraEncabezadoID = COCD.CmpOrdenCompraEncabezadoID
	 WHERE COCE.TipoDocumentoID = @TipoDocumentoID
		AND PSu.PpalSucursalClave Between (SELECT PpalSucursalClave FROM PpalSucursal WHERE PpalSucursal.PpalSucursalID = @SucursalInicialID) AND
									(SELECT PpalSucursalClave FROM PpalSucursal WHERE PpalSucursal.PpalSucursalID = @SucursalFinalID)					
		AND COCE.Fecha Between @FechaInicial and @FechaFinal
		AND (COCE.PpalProveedorID = @ProveedorID or @ProveedorID = 0)
		AND PSe.PpalSerieClave Between (SELECT PpalSerieClave FROM PpalSerie WHERE PpalSerie.PpalSerieID = @SerieInicialID) AND
									(SELECT PpalSerieClave FROM PpalSerie WHERE PpalSerie.PpalSerieID = @SerieFinalID)
		AND CHARINDEX('@@' + CAST(COCE.CfgEstatusDocumentoID AS varchar(10)) + '@@',  @EstatusAIncluir) > 0
	ORDER BY COCD.CmpOrdenCompraDetalleID,		COCD.Renglon

	/* Procesa Bitácora */
	-- Revisa si el cambio debe ser guardado en Bitácora
	EXEC	@isChangeBeLogged	=   SistemaLogRegla_Consultar_LogBit
			@UsuarioID			=	@UsuarioIDBitcora,
			@TablaNombre		=   @TablaNombreBitacora,
			@Operacion			=	@Operacion

	-- Si el cambio debe guardarse, prepara variables de Bitácora y lo guarda
	IF @isChangeBeLogged = 1 And @@RowCount > 0
	BEGIN
		-- logMessage = Parámetros de Listado
		SET @logMessage =  Concat('SucursalInicial::', @SucursalInicialID, ':',0, ';')

		-- Guarda en Bitácora
		EXEC 	 [dbo].[SistemaLog_Guardar] @TablaNombre		= @TablaNombreBitacora
												,@TablaID			= 0
												,@TablaColumna1		= ''
												,@TablaColumna2		= ''
												,@Operacion			= @Operacion
												,@UsuarioID			= @UsuarioIDBitcora
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