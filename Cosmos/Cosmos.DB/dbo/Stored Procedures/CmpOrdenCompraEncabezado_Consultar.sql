CREATE PROCEDURE [dbo].[CmpOrdenCompraEncabezado_Consultar]
@CmpOrdenCompraEncabezadoID int
-- Parámetros para Bitácora
	,@UsuarioIDBitacora		int
	,@DescripcionBitacora	varchar(500)	= null
	,@IpAddress				varchar(40)		= null
	,@HostName				varchar(50)		= null

AS
-- Variables para manejo de Errores
DECLARE @Errores int = 0, @Mensaje nvarchar(300), @IDAConsultar int
-- Variables para Bitácora
DECLARE @TablaNombreBitacora   nvarchar(100) = 'CmpOrdenCompraEncabezado',	
		@Operacion	nvarchar(20) = 'Read', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION

	SET		@IDAConsultar = @CmpOrdenCompraEncabezadoID
	SELECT  CmpOrdenCompraEncabezadoID,				PpalSucursalID,				TipoDocumentoID,
			PpalSerieID,							Folio,						COCE.PpalProveedorID,
			PpalPersonalID,							Fecha,						Referencia,
			Concepto,								COCE.CfgEstatusDocumentoID,		LinkXML,
			LinkPDF,								EstatusFactura,				PpalCentroCostoID,
			PpalConceptoEgresoID,					PpalAreaID,					EP.RFC,	
			CED.Nombre AS CfgEstatusDocumentoNombre
	FROM    CmpOrdenCompraEncabezado COCE 
			LEFT OUTER JOIN PpalProveedor PP ON COCE.PpalProveedorID = PP.PpalProveedorID
			LEFT OUTER JOIN EspPersona EP ON PP.EspPersonaID = EP.EspPersonaID
			LEFT OUTER JOIN CfgEstatusDocumento CED ON COCE.CfgEstatusDocumentoID = CED.CfgEstatusDocumentoID
	WHERE   CmpOrdenCompraEncabezadoID = @IDAConsultar
			
	-- Si no se encontró registro a Consultar -> error
	IF @@RowCount = 0
		SELECT @Errores = 999997, @Mensaje = CONCAT('No se encontró el ID a Consultar:', ' ', @IDAConsultar)
	ELSE
	BEGIN
		/* Procesa Bitácora */
		-- Revisa si la consulta debe ser guardado en Bitácora
		EXEC	@isChangeBeLogged	=   SistemaLogRegla_Consultar_LogBit
				@UsuarioID			=	@UsuarioIDBitacora,
				@TablaNombre		=   @TablaNombreBitacora,
				@Operacion			=	@Operacion

		-- Si la consulta debe guardarse, prepara variables de Bitácora y lo guarda
		IF @isChangeBeLogged = 1 
		BEGIN
			-- LogMessage = Parámetros de Consulta
			SET @logMessage = Concat('CmpOrdenCompraEncabezadoID::', @CmpOrdenCompraEncabezadoID, ':', 0, ';')
	
			-- Guarda en Bitácora
			EXEC 	 [dbo].[SistemaLog_Guardar] @TablaNombre		= @TablaNombreBitacora
													,@TablaID			= @IDAConsultar
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
	-- Si no hubo errores -> COMMIT
	COMMIT TRANSACTION
END TRY
-- Si hubo error lo procesa y lo regresa
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
		COALESCE(ERROR_LINE(), 0) as Linea,
        @IDAConsultar as ConsultarID