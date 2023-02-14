CREATE PROCEDURE [dbo].[CoTipoPresupuesto_Arbol]
@CoTipoPresupuestoID int
/************   COPY 1  ************************************/
-- Parámetros para Bitácora
	,@UsuarioIDBitcora		int
	,@DescripcionBitacora		varchar(500)	= null
	,@IpAddress			varchar(40)		= null
	,@HostName			varchar(50)		= null
/************************************************/
AS
-- Variables para manejo de Errores
DECLARE @Errores int = 0, @Mensaje nvarchar(500)
-- Variables para Bitácora          
DECLARE @TablaNombreIDBitacora   nvarchar(100) = 'CoTipoPresupuesto',	
		@Operacion	nvarchar(20) = 'Read', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION

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
		SET @logMessage =  Concat('CoTipoPresupuestoID::', @CoTipoPresupuestoID, ':',0, ';')

		-- Guarda en Bitácora
		EXEC 	 [dbo].[SistemaLog_Guardar] @TablaNombre		= @TablaNombreIDBitacora
												,@TablaID			= 0
												,@TablaColumna1		= ''
												,@TablaColumna2		= ''
												,@Operacion			= 'Tree'
												,@UsuarioID			= @UsuarioIDBitcora
												,@Descripcion		= @DescripcionBitacora
												,@Cambios			= @logMessage
												,@IpAddress			= @IpAddress
												,@HostName			= @HostName
	END

/************* FIN COPY 1  *********************/

	SELECT  CoPartidaID AS NodoID,			'Partida' as NodoTipo,
			CASE WHEN (SELECT CoPartidaClave FROM CoPartida CPb WHERE CPb.CoPartidaID = CP.PadreID) = 
						(SELECT ClaveNoAsignado  FROM SistemaParamCosmos) THEN 0 ELSE PadreID END as PadreID,	
						'Partida' as PadreTipo, 
			Nombre as NodoNombre, CoTipoPresupuestoID
	FROM    CoPartida CP
	WHERE	CoTipoPresupuestoID = @CoTipoPresupuestoID
	AND		CoPartidaClave <> (SELECT ClaveNoAsignado  FROM SistemaParamCosmos)

	UNION

	SELECT  CoPartidaDetalleID AS NodoID,	'Partida Detalle' AS NodoTipo,
			CPD.CoPartidaID AS PadreID,		'Partida' AS PadreTIpo,
			PP.NombreCorto as NodoNombre,	CoTipoPresupuestoID
	FROM    CoPartidaDetalle CPD
			LEFT OUTER JOIN CoPartida CP ON CPD.CoPartidaID = CP.CoPartidaID
			LEFT OUTER JOIN PpalProducto PP ON CPD.PpalProductoID = PP.PpalProductoID
	WHERE	CoTipoPresupuestoID = @CoTipoPresupuestoID
	ORDER BY 3, 1

/****************** COPY 2 ************************************************/
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

/**************** FIN COPY 2 *********************************************/