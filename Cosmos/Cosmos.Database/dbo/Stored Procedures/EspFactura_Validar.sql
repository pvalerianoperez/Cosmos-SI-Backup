CREATE PROCEDURE [dbo].[EspFactura_Validar]
@UUID varchar(50)
/************   COPY 1  ************************************/
-- Parámetros para Bitácora
	,@UsuarioIDBitacora		int
	,@DescripcionBitacora	varchar(500)	= null
	,@IpAddress				varchar(40)		= null
	,@HostName				varchar(50)		= null
/************************************************/
AS
-- Variables para manejo de Errores
-- OJO PVP 2022-06-18 LA VALIDACIÓN NO ES NECESARIAMENTE CON EL ID, EN ESTE CASO ES CON EL UUID
DECLARE @Errores int = 0, @Mensaje nvarchar(500), @IDAConsultar int
-- Variables para Bitácora
DECLARE @TablaNombreBitacora   nvarchar(100) = 'EspFactura',	
		@Operacion	nvarchar(20) = 'Read', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit
-- Variables para valores de columnas
DECLARE	@UUID_ nvarchar(10) = '',
		@RFC_ nvarchar(60) = '',			
		@Serie_ varchar(10) = '',
		@Folio_ int = 0,
		@Importe_ decimal = 0,
		@Fecha_ dateTime = GetDate(),
		@LinkXML_ varchar(250) = '',
		@LinkPDF_ varchar(250) = '',
		@EstatusFactura_ char(1) = '',
		@MetodoPago_ varchar(4) = ''

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION
	--SET @IDAConsultar = @EspFacturaID
	/************* FIN COPY 1  *********************/
	SELECT  @UUID_ = UUID,			@RFC_ = RFC,			@Serie_ = Serie,
			@Folio_ = Folio,		@Importe_ = Importe,	@Fecha_ = Fecha,
			@LinkXML_ = LinkXML,	@LinkPDF_ = LinkPDF,	@EstatusFactura_ = EstatusFactura,
			@MetodoPago_ = MetodoPago,						@IDAConsultar = EspFacturaID
	FROM    EspFactura
	WHERE   UUID = @UUID

	/****************** COPY 2 ************************************************/
	-- Si no se encontró registro a Consultar -> ESTÁ CORRECTO
	IF @@RowCount = 0
		SET @IDAConsultar = 0
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
			SET @logMessage = Concat('UUID::', @UUID, ':', 0, ';')
	
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

IF @Errores = 0
	SELECT  @IDAConsultar as EspFacturaID,					@UUID_ as UUID,			
			@RFC_ as RFC,									@Serie_ as Serie,
			@Importe_ as Importe,							@Fecha_ as Fecha,
			@LinkXML_ as LinkXML,							@LinkPDF_ as LinkPDF,
			@EstatusFactura_ as EstatusFactura,				@MetodoPago_ as MetodoPago
ELSE
	SELECT  COALESCE(@Errores, 0) as Errores, 
			COALESCE(@Mensaje, '') as Mensaje,
			COALESCE(ERROR_SEVERITY(), 0) as Severidad,
			COALESCE(ERROR_STATE(), 0) as Estado,
			COALESCE(ERROR_PROCEDURE(), '') as ProcedimientoAlmacenado,
			COALESCE(ERROR_LINE(), 0) as Linea,
		    @IDAConsultar as ConsultarID
/**************** FIN COPY 2 *********************************************/