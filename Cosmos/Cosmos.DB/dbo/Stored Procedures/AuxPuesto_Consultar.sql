

CREATE PROCEDURE [dbo].[AuxPuesto_Consultar]
@AuxPuestoID int
-- Parámetros para Bitácora
	,@UsuarioIDBitacora		int
	,@DescripcionBitacora	varchar(500)	= null
	,@IpAddress				varchar(40)		= null
	,@HostName				varchar(50)		= null

AS
-- Variables para manejo de Errores
DECLARE @Errores int = 0, @Mensaje nvarchar(300), @IDAConsultar int
-- Variables para Bitácora
DECLARE @TablaNombreIDBitacora   nvarchar(100) = 'AuxPuesto',	
		@Operacion	nvarchar(20) = 'Read', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit
-- Variables para valores de columnas
DECLARE	@AuxPuestoClave_	nvarchar(60) = '',					@Nombre_			varchar(10) = '',
		@NombreCorto_		varchar(10) = '',					@Sueldo_			money = 0,
		@BaseNeto_			char(1) = '',						@Tipo_				char(1) = '',
		@Objetivo_			nvarchar(250) = '',					@ReqAcademicos_		nvarchar(100) = '',
		@TiempoDesempeno_	tinyint = 0,						@EmpresaID_			int = 0,
		@AuxPuestoID_		int = @AuxPuestoID

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION
	SET @IDAConsultar = @AuxPuestoID
	SELECT  @AuxPuestoID_ = AuxPuestoID,@AuxPuestoClave_ = AuxPuestoClave,@Nombre_ = Nombre,@NombreCorto_ = NombreCorto,
			@Sueldo_ = Sueldo,@BaseNeto_ = BaseNeto,@Tipo_ = Tipo,@Objetivo_ = Objetivo,@ReqAcademicos_ = ReqAcademicos,@TiempoDesempeno_ = TiempoDesempeno,@EmpresaID_	 = EmpresaID
	FROM    AuxPuesto
	WHERE   AuxPuestoID = @AuxPuestoID


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
			SET @logMessage = Concat('AuxPuestoID::', @AuxPuestoID, ':', 0, ';')
	
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
	SELECT  @IDAConsultar as AuxPuestoID,	@AuxPuestoClave_ as AuxPuestoClave,	@Nombre_ as Nombre,@NombreCorto_ as NombreCorto,
			@Sueldo_ as Sueldo,				@BaseNeto_ as BaseNeto,				@Tipo_ as Tipo,
			@Objetivo_ as Objetivo,			@ReqAcademicos_ as ReqAcademicos,	@TiempoDesempeno_ as TiempoDesempeno,
			@EmpresaID_ as EmpresaID
ELSE
	SELECT  COALESCE(@Errores, 0) as Errores, 
			COALESCE(@Mensaje, '') as Mensaje,
			COALESCE(ERROR_SEVERITY(), 0) as Severidad,
			COALESCE(ERROR_STATE(), 0) as Estado,
			COALESCE(ERROR_PROCEDURE(), '') as ProcedimientoAlmacenado,
			COALESCE(ERROR_LINE(), 0) as Linea,
		    @IDAConsultar as ConsultarID