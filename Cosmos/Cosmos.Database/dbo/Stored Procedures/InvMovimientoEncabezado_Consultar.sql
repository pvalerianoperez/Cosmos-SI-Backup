-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[InvMovimientoEncabezado_Consultar]
@InvMovimientoEncabezadoID int
-- Parámetros para Bitácora
	,@UsuarioIDBitacora		int
	,@DescripcionBitacora	varchar(500)	= null
	,@IpAddress				varchar(40)		= null
	,@HostName				varchar(50)		= null
AS
-- Variables para manejo de Errores
DECLARE @Errores int = 0, @Mensaje nvarchar(500), @IDAConsultar int
-- Variables para Bitácora
DECLARE @TablaNombreIDBitacora   nvarchar(100) = 'InvMovimientoEncabezado',	
		@Operacion	nvarchar(20) = 'Read', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit
-- Variables para valores de columnas
DECLARE	@InvMovimientoEncabezadoID_ int = @InvMovimientoEncabezadoID,	
		@PpalSucursalID_ int = 0,
		@TipoDocumentoID_ int = 0,
		@PpalSerieID_ int = 0,
		@Folio_ int = 0,
		@InvTipoMovimientoInventarioID_ int = 0,
		@PpalPersonalID_ int = 0,
		@Fecha_ datetime = 0,
		@Concepto_ varchar(100) = '',
		@CfgEstatusDocumentoID_ int = 0

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION
	SET @IDAConsultar = @InvMovimientoEncabezadoID
	SELECT  InvMovimientoEncabezadoID,	PpalSucursalID,					TipoDocumentoID,	PpalSerieID,
			Folio,						InvTipoMovimientoInventarioID,	Fecha,				Referencia,
			Concepto,					CfgEstatusDocumentoID
	FROM    InvMovimientoEncabezado
	WHERE   InvMovimientoEncabezadoID = @IDAConsultar

-- Si no se encontró registro a Consultar -> error
	IF @@RowCount = 0
		SELECT @Errores = 999997, @Mensaje = CONCAT('No se encontró el ID a Consultar:', ' ', @IDAConsultar)
	ELSE
	BEGIN
		/* Procesa Bitácora */
		-- Revisa si la consulta debe ser guardado en Bitácora
		EXEC	@isChangeBeLogged	=   SistemaLogRegla_Consultar_LogBit
				@UsuarioID			=	@UsuarioIDBitacora,
				@TablaNombre		=   @TablaNombreIDBitacora,
				@Operacion			=	@Operacion

		-- Si la consulta debe guardarse, prepara variables de Bitácora y lo guarda
		IF @isChangeBeLogged = 1 
		BEGIN
			-- LogMessage = Parámetros de Consulta
			SET @logMessage = Concat('InvMovimientoEncabezadoID::', @IDAConsultar, ':', 0, ';')
	
			-- Guarda en Bitácora
			EXEC 	 [dbo].[SistemaLog_Guardar] @TablaNombre		= @TablaNombreIDBitacora
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

IF @Errores = 0
	SELECT  @InvMovimientoEncabezadoID_ as InvMovimientoEncabezadoID	,	
			@PpalSucursalID_			as	PpalSucursalID,
			@TipoDocumentoID_			as	TipoDocumentoID,
			@PpalSerieID_				as	PpalSerieID,
			@Folio_						as	Folio,
			@InvTipoMovimientoInventarioID_ as InvTipoMovimientoInventarioID,
			@PpalPersonalID_			as	PpalPersonalID,
			@Fecha_						as	Fecha,
			@Concepto_					as	Concepto,
			@CfgEstatusDocumentoID_		as	CfgEstatusDocumentoID
ELSE
	SELECT  COALESCE(@Errores, 0) as Errores, 
			COALESCE(@Mensaje, '') as Mensaje,
			COALESCE(ERROR_SEVERITY(), 0) as Severidad,
			COALESCE(ERROR_STATE(), 0) as Estado,
			COALESCE(ERROR_PROCEDURE(), '') as ProcedimientoAlmacenado,
			COALESCE(ERROR_LINE(), 0) as Linea,
		    @IDAConsultar as ConsultarID