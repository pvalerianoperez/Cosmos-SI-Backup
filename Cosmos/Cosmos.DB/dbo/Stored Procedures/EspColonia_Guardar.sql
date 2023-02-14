﻿

CREATE PROCEDURE [dbo].[EspColonia_Guardar]
@EspColoniaID int,
@EspColoniaClave varchar(7),
@Nombre varchar(60),
@NombreCorto varchar(15),
@TipoAsentamientoID int,
@CiudadID int,
@CP int
-- Parámetros para Bitácora
	,@UsuarioIDBitacora		int
	,@DescripcionBitacora	varchar(500)	= null
	,@IpAddress				varchar(40)		= null
	,@HostName				varchar(50)		= null

AS
-- Variables para manejo de Errores
DECLARE @Errores int = 0, @Mensaje nvarchar(300) = '', @IDAActualizar int
-- Variables para Bitácora
DECLARE @TablaNombreIDBitacora   nvarchar(100) = 'EspColonia',	
		@Operacion	nvarchar(20) = '', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit
-- Variables para valores anteriores (Bitácora Update) 
DECLARE	@EspColoniaID_ int = @EspColoniaID,
		@EspColoniaClave_ varchar(7) = '',
		@Nombre_ varchar(60) = '',
		@NombreCorto_ varchar(15) = '',
		@TipoAsentamientoID_ int = 0,
		@CiudadID_ int = 0,
		@CP_ int = 0

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION

	SET @IDAActualizar = @EspColoniaID
	-- Si es UPDATE -> Lee valores anteriores de las columnas (Bitácora Update) 
	IF @IDAActualizar > 0
	BEGIN
		SELECT	@EspColoniaID_  =		IsNull(EspColoniaID,''),
				@EspColoniaClave_ =		IsNull(EspColoniaClave,''),
				@Nombre_ =				IsNull(Nombre,''),
				@NombreCorto_ =			IsNull(NombreCorto,''),
				@TipoAsentamientoID_ =	IsNull(CfgTipoAsentamientoID,''),
				@CiudadID_ =			IsNull(EspCiudadID,''),
				@CP_ =					IsNull(EspCP,'')
		   FROM	EspColonia WHERE EspColoniaID = @IDAActualizar
		IF @@RowCount = 0
		SELECT @Errores = 999999, @Mensaje = CONCAT('No se encontró el ID a Actualizar:', ' ', @IDAActualizar);
	END
	-- Si no hubo error (es INSERT o es UPDATE y existe el registro)
	IF @Errores = 0
	BEGIN
		-- Si la llave existe hace UPDATE y si no, hace INSERT
		IF @IDAActualizar > 0

		BEGIN
			UPDATE  EspColonia
			SET     EspColoniaClave = @EspColoniaClave,				Nombre = @Nombre,			NombreCorto = @NombreCorto,	
					CfgTipoAsentamientoID = @TipoAsentamientoID,	EspCiudadID = @CiudadID,	EspCP = @CP
			WHERE   EspColoniaID = @IDAActualizar
		END
		ELSE
		BEGIN        
			INSERT  INTO EspColonia(
					EspColoniaID,
					EspColoniaClave,
					Nombre,
					NombreCorto,
					CfgTipoAsentamientoID,
					EspCiudadID,
					EspCP)
			VALUES  (
					@EspColoniaID,
					@EspColoniaClave,
					@Nombre,
					@NombreCorto,
					@TipoAsentamientoID,
					@CiudadID,
					@CP)
        
			SET     @IDAActualizar = SCOPE_IDENTITY()
		END

		IF @@RowCount > 0
		BEGIN
			/* Procesa Bitácora */
			-- Determina si fue UPDATE o INSERT
			IF @EspColoniaID_ > 0  SET @Operacion = 'Update' 	
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
				SET @logMessage = Concat('EspColoniaClave::', @EspColoniaClave_, ':', @EspColoniaClave, ';')
				SET @logMessage = Concat(@logMessage, 'Nombre::', @Nombre_, ':', @Nombre, ';')
				SET @logMessage = Concat(@logMessage, 'NombreCorto::', @NombreCorto_, ':', @NombreCorto, ';')
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