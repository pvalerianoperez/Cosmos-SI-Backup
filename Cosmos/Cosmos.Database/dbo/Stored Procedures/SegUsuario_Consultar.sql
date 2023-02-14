CREATE PROCEDURE [dbo].[SegUsuario_Consultar]
@SegUsuarioID int
-- Parámetros para Bitácora
	,@UsuarioIDBitacora		int
	,@DescripcionBitacora	varchar(500)	= null
	,@IpAddress				varchar(40)		= null
	,@HostName				varchar(50)		= null

AS
-- Variables para manejo de Errores
DECLARE @Errores int = 0, @Mensaje nvarchar(500), @IDAConsultar int
-- Variables para Bitácora
DECLARE @TablaNombreIDBitacora   nvarchar(100) = 'SegUsuario',	
		@Operacion	nvarchar(20) = 'Read', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit
-- Variables para valores de columnas
DECLARE	@CorreoElectronico_		nvarchar(150) = '',
		@Nombre_				nvarchar(150) = '',
		@Alias_					nvarchar(50) = '',
		@Activo_				bit = 0,
		@Intentos_				tinyint = 0,
		@Bloqueado_				bit = 0,
		@UsuarioAD_				nvarchar(50) = '',
		@Administrador_			bit = 0,
		@UltimoAcceso_			datetime = 0,
		@UltimaEmpresaID_		int = 0,
		@UltimoModuloID_		int = 0,
		@UltimaOpcionID_		int = 0,
		@UltimaIP_				nvarchar(50) = '',
		@LinkFoto_				varchar(250) = '', 
		@EspPersonaID_			int = 0

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION

	SET		@IDAConsultar = @SegUsuarioID
	SELECT  @SegUsuarioID = SegUsuarioID,		@CorreoElectronico_ = CorreoElectronico,	@Nombre_ = Nombre,						@Alias_ = Alias,
			@Activo_ = Activo,					@Intentos_ = Intentos,						@Bloqueado_ = Bloqueado,				@UsuarioAD_ = UsuarioAD,
			@Administrador_ = Administrador,	@UltimoAcceso_ = UltimoAcceso,				@UltimaEmpresaID_ = UltimaEmpresaID,	@UltimoModuloID_ = UltimoModuloID,
			@UltimaOpcionID_ = UltimaOpcionID,	@UltimaIP_ = UltimaIP,						@LinkFoto_ = LinkFoto,					@EspPersonaID_ = EspPersonaID
	FROM    SegUsuario
	WHERE   SegUsuarioID = @IDAConsultar

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
			SET @logMessage = Concat('SegUsuarioID::', @IDAConsultar, ':', 0, ';')
	
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
	SELECT  @SegUsuarioID as SegUsuarioID,			@CorreoElectronico_ as CorreoElectronico,	@Nombre_ as Nombre,					@Alias_ as Alias,					@Activo_ as Activo,
			@Intentos_ as Intentos,					@Bloqueado_ as Bloqueado,					@UsuarioAD_ as UsuarioAD,			@Administrador_ as Administrador,	@UltimoAcceso_ as UltimoAcceso,	
			@UltimaEmpresaID_ as UltimaEmpresaID,	@UltimoModuloID_ as UltimoModuloID,			@UltimaOpcionID_ as UltimaOpcionID,	@UltimaIP_ as UltimaIP,
			@LinkFoto_ as LinkFoto,					@EspPersonaID_ as EspPersonaID
ELSE
	SELECT  COALESCE(@Errores, 0) as Errores, 
			COALESCE(@Mensaje, '') as Mensaje,
			COALESCE(ERROR_SEVERITY(), 0) as Severidad,
			COALESCE(ERROR_STATE(), 0) as Estado,
			COALESCE(ERROR_PROCEDURE(), '') as ProcedimientoAlmacenado,
			COALESCE(ERROR_LINE(), 0) as Linea,
		    @IDAConsultar as ConsultarID