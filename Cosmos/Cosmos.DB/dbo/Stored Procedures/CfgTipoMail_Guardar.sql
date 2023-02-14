CREATE PROCEDURE [dbo].[CfgTipoMail_Guardar]
@TipoMailID int,
@SistemaTipoMailID int,
@TipoMailClave varchar(10) = null,
@Nombre varchar(40) = null,
@NombreCorto varchar(15) = null,
@Estatus bit
-- Parámetros para Bitácora
	,@UsuarioIDBitacora		int
	,@DescripcionBitacora	varchar(500)	= null
	,@IpAddress			varchar(40)		= null
	,@HostName			varchar(50)		= null

AS
-- Variables para manejo de Errores
DECLARE @Errores int = 0, @Mensaje nvarchar(300) = '', @IDAActualizar int
-- Variables para Bitácora
DECLARE @TablaNombreIDBitacora   nvarchar(100) = 'CfgTipoMail',	
		@Operacion	nvarchar(20) = '', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit
-- Variables para valores anteriores (Bitácora Update) 
DECLARE	@TipoMailClave_ nvarchar(10) = '',
		@Nombre_ nvarchar(60) = '',			
		@NombreCorto_ varchar(10) = '',
		@SistemaTipoMailID_ int = 0,
		@Estatus_ bit = 0,
		@TipoMailID_ int = @TipoMailID

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION

	SET @IDAActualizar = @TipoMailID
	-- Si es UPDATE -> Lee valores anteriores de las columnas (Bitácora Update) 
	IF @IDAActualizar > 0
	BEGIN
		SELECT	@TipoMailClave_ = IsNull(CfgTipoMailClave,''),
	 			@Nombre_ = IsNull(Nombre,''),
				@NombreCorto_ = IsNull(NombreCorto,''),
				@SistemaTipoMailID_ = IsNull(CfgSistemaTipoMailID,0),
				@Estatus_ = IsNull(Estatus,0),
				@TipoMailID_ = IsNull(CfgTipoMailID,0)
		   FROM	CfgTipoMail WHERE CfgTipoMailID = @IDAActualizar
		IF @@RowCount = 0
			SELECT @Errores = 999999, @Mensaje = CONCAT('No se encontró el ID a Actualizar:', ' ', @IDAActualizar);
	END
	-- Si no hubo error (es INSERT o es UPDATE y existe el registro)
	IF @Errores = 0
	BEGIN
		-- Si la llave existe hace UPDATE y si no, hace INSERT
		IF @IDAActualizar > 0
		BEGIN
			UPDATE  CfgTipoMail
			SET     CfgTipoMailClave = @TipoMailClave,
					Nombre = @Nombre,
					NombreCorto = @NombreCorto,
					Estatus = @Estatus,
					CfgSistemaTipoMailID = @SistemaTipoMailID
			WHERE   CfgTipoMailID = @IDAActualizar
		END
		ELSE
		BEGIN        
			INSERT  INTO CfgTipoMail(
					CfgTipoMailClave,
					Nombre,
					NombreCorto,
					Estatus,
					CfgSistemaTipoMailID)
			VALUES  (
					@TipoMailClave,
					@Nombre,
					@NombreCorto,
					@Estatus,
					@SistemaTipoMailID)
        
			SET     @IDAActualizar = SCOPE_IDENTITY()
		END

		IF @@RowCount > 0
		BEGIN
			/* Procesa Bitácora */
			-- Determina si fue UPDATE o INSERT
			IF @TipoMailID_ > 0  SET @Operacion = 'Update' 	
						ELSE SET @Operacion = 'Create' 

			-- Revisa si el cambio debe ser guardado en Bitácora
			EXEC	@isChangeBeLogged	=   SistemaLogRegla_Consultar_LogBit
					@UsuarioID			=	@UsuarioIDBitacora,
					@TablaNombre		=   @TablaNombreIDBitacora,
					@Operacion			=	@Operacion

			-- Si el cambio debe guardarse, prepara variables de Bitácora y lo guarda
			IF @isChangeBeLogged = 1 
			BEGIN
				-- logMessage = Cambios efectuados
				SET @logMessage = Concat('TipoMailClave::', @TipoMailClave_, ':', @TipoMailClave, ';')
				SET @logMessage = Concat(@logMessage, 'Nombre::', @Nombre_, ':', @Nombre, ';')
				SET @logMessage = Concat(@logMessage, 'NombreCorto::', @NombreCorto_, ':', @NombreCorto, ';')
				SET @logMessage = Concat(@logMessage, 'Estatus::', @Estatus_, ':', @Estatus, ';')
				SET @logMessage = Concat(@logMessage, 'SistemaTipoMailID::', @SistemaTipoMailID_, ':', @SistemaTipoMailID, ';')
				PRINT @logMessage
				-- Guarda en Bitácora
				EXEC 	 [dbo].[SistemaLog_Guardar] @TablaNombre		= @TablaNombreIDBitacora
														,@TablaID			= @IDAActualizar
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
		-- Fin de proceso sin errores -> COMMIT
		COMMIT TRANSACTION
	END
END TRY
-- Si hubo error los procesa y lo regresa
BEGIN CATCH
    SELECT @Errores = ERROR_NUMBER(), 
			@Mensaje = dbo.FDecodificaError(ERROR_NUMBER(), ERROR_MESSAGE(), ERROR_SEVERITY(), ERROR_STATE(), ERROR_PROCEDURE(), ERROR_LINE())
END CATCH 
IF (XACT_STATE()) = -1 ROLLBACK TRANSACTION;
IF (XACT_STATE()) = 1 COMMIT TRANSACTION;

SELECT  COALESCE(@Errores, 0) as Errores, 
        COALESCE(@Mensaje, '') as Mensaje,
		COALESCE(ERROR_SEVERITY(), 0) as Severidad,
		COALESCE(ERROR_STATE(), 0) as Estado,
		COALESCE(ERROR_PROCEDURE(), '') as ProcedimientoAlmacenado,
		COALESCE(ERROR_LINE(), 0) as Linea,
		@IDAActualizar as GuardarID