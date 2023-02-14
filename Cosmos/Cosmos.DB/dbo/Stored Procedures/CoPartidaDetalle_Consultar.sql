CREATE PROCEDURE [dbo].[CoPartidaDetalle_Consultar]
@CoPartidaDetalleID int
/************   COPY 1  ************************************/
-- Parámetros para Bitácora
	,@UsuarioIDBitcora		int
	,@DescripcionBitacora		varchar(500)	= null
	,@IpAddress			varchar(40)		= null
	,@HostName			varchar(50)		= null
/************************************************/
AS
-- Variables para manejo de Errores
DECLARE @Errores int = 0, @Mensaje nvarchar(500), @IDAConsultar int
-- Variables para Bitácora
DECLARE @TablaNombreIDBitacora   nvarchar(100) = 'CoPartidaDetalle',	
		@Operacion	nvarchar(20) = 'Read', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit
-- Variables para valores de columnas
DECLARE	@CoPartidaDetalleID_ int = @CoPartidaDetalleID,
		@CoPartidaID_ int = 0,
		@PpalProductoID_ int = 0,
		@Cantidad_ decimal(18,6) = 0,
		@Precio_ decimal(18,6) = 0,
		@AuxUnidadID_ int = 0,
		@Adicional_ varchar(500) = '',
		@Observaciones_ varchar(500) = '',
		@PpalAreaID_ int = 0,
		@SustituirConAdicional_ bit = 0,
		@PpalConceptoEgresoID_ int = 0

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION

	SET @IDAConsultar = @CoPartidaDetalleID
	/************* FIN COPY 1  *********************/
	SELECT  @CoPartidaDetalleID_ = CoPartidaDetalleID,		@CoPartidaID_ = CoPartidaID,		@PpalProductoID_  = PpalProductoID,
			@Cantidad_ = Cantidad,			@Precio_ = Precio,				@AuxUnidadID_  = AuxUnidadID,
			@Adicional_ = Adicional,		@Observaciones_ = Observaciones,		@PpalAreaID_  = PpalAreaID,
			@SustituirConAdicional_ = SustituirConAdicional,		@PpalConceptoEgresoID_  = PpalConceptoEgresoID
		
	FROM    CoPartidaDetalle
	WHERE   CoPartidaDetalleID = @IDAConsultar

	/****************** COPY 2 ************************************************/
	-- Si no se encontró registro a Consultar -> error
	IF @@RowCount = 0
		SELECT @Errores = 999997, @Mensaje = CONCAT('No se encontró el ID a Consultar:', ' ', @IDAConsultar)
	ELSE
	BEGIN
		/* Procesa Bitácora */
		-- Revisa si la consulta debe ser guardado en Bitácora
		EXEC	@isChangeBeLogged	=   SistemaLogRegla_Consultar_LogBit
				@UsuarioID			=	@UsuarioIDBitcora,
				@TablaNombre		=   @TablaNombreIDBitacora,
				@Operacion			=	@Operacion

		-- Si la consulta debe guardarse, prepara variables de Bitácora y lo guarda
		IF @isChangeBeLogged = 1 
		BEGIN
			-- LogMessage = Parámetros de Consulta
			SET @logMessage = Concat('CoPartidaDetalleID::', @IDAConsultar, ':', 0, ';')
	
			-- Guarda en Bitácora
			EXEC 	 [dbo].[SistemaLog_Guardar] @TablaNombre		= @TablaNombreIDBitacora
													,@TablaID			= @IDAConsultar
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
	SELECT  @CoPartidaDetalleID_ as CoPartidaDetalleID,		@CoPartidaID_ as CoPartidaID,		@PpalProductoID_  as PpalProductoID,
			@Cantidad_ as Cantidad,			@Precio_ as Precio,				@AuxUnidadID_  as AuxUnidadID,
			@Adicional_ as Adicional,		@Observaciones_ as Observaciones,		@PpalAreaID_  as PpalAreaID,
			@SustituirConAdicional_ as SustituirConAdicional,		@PpalConceptoEgresoID_  as PpalConceptoEgresoID
ELSE
	SELECT  COALESCE(@Errores, 0) as Errores, 
			COALESCE(@Mensaje, '') as Mensaje,
			COALESCE(ERROR_SEVERITY(), 0) as Severidad,
			COALESCE(ERROR_STATE(), 0) as Estado,
			COALESCE(ERROR_PROCEDURE(), '') as ProcedimientoAlmacenado,
			COALESCE(ERROR_LINE(), 0) as Linea,
		    @IDAConsultar as ConsultarID
/**************** FIN COPY 2 *********************************************/