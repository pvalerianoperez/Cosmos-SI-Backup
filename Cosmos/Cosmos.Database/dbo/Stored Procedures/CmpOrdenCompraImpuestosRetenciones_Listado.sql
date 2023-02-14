
CREATE PROCEDURE [dbo].[CmpOrdenCompraImpuestosRetenciones_Listado]
@CmpOrdenCompraEncabezadoID int
-- Parámetros para Bitácora
	,@UsuarioIDBitcora		int
	,@DescripcionBitacora	varchar(500)	= null
	,@IpAddress			varchar(40)		= null
	,@HostName			varchar(50)		= null

AS
-- Variables para manejo de Errores
DECLARE @Errores int = 0, @Mensaje nvarchar(300)
-- Variables para Bitácora          
DECLARE @TablaNombreIDBitacora   nvarchar(100) = 'CmpOrdenCompraImpuestoRetencion',	
		@Operacion	nvarchar(20) = 'Read', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit
DECLARE @CfgEsquemaImpuestoRetencionID int = 0,
		@TotalOC decimal(18,6) = 0

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION
	SELECT @CfgEsquemaImpuestoRetencionID = CASE WHEN PP.AplicaRetenciones = 'S' THEN 1 ELSE 2 END
	  FROM CmpOrdenCompraEncabezado COCE
			LEFT OUTER JOIN PpalProveedor PP ON COCE.PpalProveedorID = PP.PpalProveedorID
	 WHERE COCE.CmpOrdenCompraEncabezadoID = @CmpOrdenCompraEncabezadoID

	SELECT @TotalOC = SUM(ROUND(COCD.Costo * COCD.Cantidad,2))
	  FROM CmpOrdenCompraDetalle COCD
	 WHERE COCD.CmpOrdenCompraEncabezadoID = @CmpOrdenCompraEncabezadoID

	SELECT 'I.V.A.' as Nombre, 'I' AS ImpuestoRetencion, SUM(ROUND(ROUND(COCD.Costo * COCD.Cantidad,2) *  CTI.PorcentajeIVA / 100,2)) Importe
	  FROM CmpOrdenCompraDetalle COCD
			LEFT OUTER JOIN PpalProducto PP ON COCD.PpalProductoID = PP.PpalProductoID
			LEFT OUTER JOIN CfgTasaIVA CTI ON PP.CfgTasaIVAID = CTI.CfgTasaIVAID
	WHERE COCD.CmpOrdenCompraEncabezadoID = @CmpOrdenCompraEncabezadoID
	UNION
	SELECT CIR.NombreCorto, CIR.ImpuestoRetencion,	ROUND(CEIRD.Porcentaje * @TotalOC / 100,2)
	  FROM CfgEsquemaImpuestoRetencionDetalle CEIRD
			LEFT OUTER JOIN CfgImpuestoRetencion CIR ON (CEIRD.CfgImpuestoRetencionID = CIR.CfgImpuestoRetencionID)
	 WHERE CEIRD.Activo = 'S' AND CEIRD.CfgEsquemaImpuestoRetencionID = @CfgEsquemaImpuestoRetencionID

	/* Procesa Bitácora */
	-- Revisa si el cambio debe ser guardado en Bitácora
	EXEC	@isChangeBeLogged	=   SistemaLogRegla_Consultar_LogBit
			@UsuarioID			=	@UsuarioIDBitcora,
			@TablaNombre		=   @TablaNombreIDBitacora,
			@Operacion			=	@Operacion

	-- Si el cambio debe guardarse, prepara variables de Bitácora y lo guarda
	IF @isChangeBeLogged = 1 And @@RowCount > 0
	BEGIN
		-- logMessage = Parámetros de Listado
		SET @logMessage =  Concat('CmpOrdenCompraEncabezadoID::', @CmpOrdenCompraEncabezadoID, ':',0, ';')

		-- Guarda en Bitácora
		EXEC 	 [dbo].[SistemaLog_Guardar] @TablaNombre		= @TablaNombreIDBitacora
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