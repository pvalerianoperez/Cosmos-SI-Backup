

CREATE PROCEDURE [dbo].[SegUsuarioTipoDocumentoPermiso_Consultar]
@SegUsuarioTipoDocumentoPermisoID int
-- Parámetros para Bitácora
	,@UsuarioIDBitacora		int
	,@DescripcionBitacora	varchar(500)	= null
	,@IpAddress				varchar(40)		= null
	,@HostName				varchar(50)		= null

AS
-- Variables para manejo de Errores
DECLARE @Errores int = 0, @Mensaje nvarchar(300), @IDAConsultar int
-- Variables para Bitácora
DECLARE @TablaNombreIDBitacora   nvarchar(100) = 'SegUsuarioTipoDocumentoPermiso',	
		@Operacion	nvarchar(20) = 'Read', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit
-- Variables para valores de columnas
DECLARE	@SegUsuarioID_ int = 0,
		@TipoDocumentoID_ int = 0,
		@PpalCentroCostoID_ int = 0,
		@PpalAreaID_ int = 0,
		@EmpresaID_ int = 0,
		@AlmacenID_ int = 0,
		@PpalSucursalID_ int = 0,
		@Preautoriza_ bit = 0,
		@PreautorizarMonto_ money = 0,
		@Autoriza_ bit = 0,
		@AutorizarMonto_ money = 0


SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION

	SET @IDAConsultar = @SegUsuarioTipoDocumentoPermisoID
	SELECT  @SegUsuarioID_ = SegUsuarioID,		@TipoDocumentoID_ = TipoDocumentoID,	@PpalCentroCostoID_ = PpalCentroCostoID,
			@PpalAreaID_ = PpalAreaID,			@EmpresaID_ = EmpresaID,				@AlmacenID_ = PpalAlmacenID,
			@PpalSucursalID_ = PpalSucursalID,	@Preautoriza_ = Preautoriza,			@PreautorizarMonto_ = PreautorizarMonto,
			@Autoriza_ = Autoriza,				@AutorizarMonto_ = AutorizarMonto
	FROM    SegUsuarioTipoDocumentoPermiso
	WHERE   SegUsuarioTipoDocumentoPermisoID = @IDAConsultar

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
			SET @logMessage = Concat('SegUsuarioTipoDocumentoPermisoID::', @SegUsuarioTipoDocumentoPermisoID, ':', 0, ';')
	
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
	SELECT  @SegUsuarioID_   as SegUsuarioID,			@TipoDocumentoID_ as TipoDocumentoID,			@PpalCentroCostoID_ as PpalCentroCostoID,
			@PpalAreaID_     as PpalAreaID,				@EmpresaID_       as EmpresaID,					@AlmacenID_         as AlmacenID,
			@PpalSucursalID_ as PpalSucursalID,		    @Preautoriza_     as Preautoriza,				@PreautorizarMonto_ as PreautorizarMonto,
			@Autoriza_       as Autoriza,				@AutorizarMonto_  as AutorizarMonto
ELSE
	SELECT  COALESCE(@Errores, 0) as Errores, 
			COALESCE(@Mensaje, '') as Mensaje,
			COALESCE(ERROR_SEVERITY(), 0) as Severidad,
			COALESCE(ERROR_STATE(), 0) as Estado,
			COALESCE(ERROR_PROCEDURE(), '') as ProcedimientoAlmacenado,
			COALESCE(ERROR_LINE(), 0) as Linea,
		    @IDAConsultar as ConsultarID